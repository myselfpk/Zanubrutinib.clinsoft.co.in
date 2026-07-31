using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public partial class DataView_Day1_FullyLock : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd1;
    SqlDataAdapter da = new SqlDataAdapter();

    private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserSession"] != null)
        {
            LabelUserName.Text = Session["UserName"].ToString();

        }
        else
        {
            LabelUserName.Text = "";

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
    protected void ValidateUser(object sender, EventArgs e)
    {
        if (RadioButtonListPI.SelectedValue == "Database fully lock by the Data Manager")
        {

            con.Close();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand sqlCmd = new SqlCommand(
                "SELECT [UserName] FROM [dbo].[tbl_UserLogin] WHERE [LoginID] = @LoginID AND [Password] = @Password",
                con);
            sqlCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 250).Value = txtUsername.Text.Trim();
            sqlCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = Encrypt(txtPassword.Text.Trim());
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                con.Close();
                cmd = new SqlCommand("sp_DataManagerLock", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", Session["UserName"]);
                cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                cmd.Parameters.AddWithValue("@mode", "lock");
                cmd.Parameters.AddWithValue("@Action", "Database Lock");
                cmd.Parameters.AddWithValue("@PageName", "FullyLock.aspx");
                cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                cmd.Parameters.AddWithValue("@Description", "Fully Database lock by the Data Manager and the Data Manager is Mr. " + Session["UserName"]);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            else
            {
                dvMessage.Visible = true;
                lblMessage.Text = "User name and password is incorrect.";
                ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
            }
        }
        else
        {
            dvMessage.Visible = true;
            lblMessage.Text = "Please click on Database fully lock by the Data Manager";
            ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
        }

    }
    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}
