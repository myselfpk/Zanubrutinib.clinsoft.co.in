using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;

public partial class DatabaseLock_PIUndertaking : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd1;
    public enum MessageType { Success, Error, Info, Warning };
    private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteName();

            if (Session["UserRoles"].ToString() == "Data Manager")
            {
                Panel1.Visible = true;

            }
            else
            {
                Panel1.Visible = false;

            }
        }

        if (Session["UserSession"] != null)
        {
            LabelUserName.Text = Session["UserName"].ToString();

        }
        else
        {
            LabelUserName.Text = "";

        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    private void SiteName()
    {
        con.Open();
        string Site = "SELECT CenterNumber FROM [dbo].[tblEnrollUsersWithSite] where UserName='" + Session["UserName"] + "'";
        SqlCommand SiteCommand = new SqlCommand(Site, con);
        SiteCommand.CommandType = CommandType.Text;
        SqlDataReader PNoSIdData;
        DropDownList1.Items.Clear();
        PNoSIdData = SiteCommand.ExecuteReader();
        if (PNoSIdData.HasRows)
        {
            DropDownList1.DataSource = PNoSIdData;
            DropDownList1.DataValueField = "CenterNumber";
            DropDownList1.DataTextField = "CenterNumber";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Choose..", "0"));
        }
        else
        {
            DropDownList1.Items.Insert(0, new ListItem("Choose..", "0"));

        }
        con.Close();
    }
    public void OnConfirm(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "I Accept")
        {
            con.Close();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand sqlCmd = new SqlCommand(
                "SELECT UserRole FROM [dbo].[tbl_UserLogin] WHERE [LoginID] = @LoginID AND [Password] = @Password",
                con);
            sqlCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 250).Value = txtUsername.Text.Trim();
            sqlCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = Encrypt(txtPassword.Text.Trim());
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UserRole"].ToString() == "Data Manager")
                {
                    con.Close();
                    cmd = new SqlCommand("sp_tblDataManagerLock", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Siteid", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@DataManagerLock", RadioButtonList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);
                    cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                    cmd.Parameters.AddWithValue("@MDate", DateTime.Today.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        ShowMessage("Site locked successfully", MessageType.Success);

                    }
                }
                else
                {
                    dvMessage.Visible = true;
                    lblMessage.Text = "Username and/or password is incorrect.";
                    ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
                }
            }

            else
            {
                dvMessage.Visible = true;
                lblMessage.Text = "Username and/or password is incorrect.";
                ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
            }

        }
        else
        {
            dvMessage.Visible = true;
            lblMessage.Text = "Please Click on I Accept";
            ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
        }
    }
    private string Encrypt(string clearText)
    {
        string EncryptionKey = ConfigurationManager.AppSettings["LegacyPasswordEncryptionKey"];
        if (string.IsNullOrWhiteSpace(EncryptionKey))
        {
            throw new ConfigurationErrorsException("LegacyPasswordEncryptionKey is not configured.");
        }
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    
}
