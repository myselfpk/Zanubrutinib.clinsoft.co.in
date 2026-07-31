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

public partial class Data_Entry_AdVisit_PiSingCMR : System.Web.UI.Page
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
        lblCenterNumber.Text = Request.QueryString["a"];
        lblScreeningNo.Text = Request.QueryString["b"];
        lblSubjectInitial.Text = Request.QueryString["c"];
        if (Session["UserSession"] != null)
        {
            LabelUserName.Text = Session["UserName"].ToString();

        }
        else
        {
            LabelUserName.Text = "";

        }
        
        BindPage();




    }


    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT count(PISIGN) as UnsignedPages,(SELECT count(PISIGN) FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and PISIGN=1 and VISIT='Concomitant Medication') as SignedPages FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and PISIGN=0 and VISIT='" + lblVisit.Text + "' and  LockStatus='SDV' and EntryStatus='Submit'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblUnsigned.Text = dt.Rows[0]["UnsignedPages"].ToString();
            lblSigned.Text = dt.Rows[0]["SignedPages"].ToString();
           
        }
        con.Close();

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
        if (RadioButtonListPI.SelectedValue == "I declare that I have reviewed the data and statements Submitted for this subject for Concomitant Medication Log and found them accurate and complete to the best of my knowledge.")
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
                cmd = new SqlCommand("sp_tblPISignature", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);
                cmd.Parameters.AddWithValue("@EntryStatus", "Submit");
                cmd.Parameters.AddWithValue("@LockStatus", "SDV");
                cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                cmd.Parameters.AddWithValue("@PISIGN", "1");
                
                cmd.Parameters.AddWithValue("@MUser", Session["UserName"]);
                cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                cmd.Parameters.AddWithValue("@mode", "Update");
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
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
            lblMessage.Text = "Please click on I declare that I have reviewed the data and statements Submitted for this subject for Concomitant Medication Log and found them accurate and complete to the best of my knowledge.";
            ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
        }

    }
    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }
}
