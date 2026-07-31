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
using System.Net.Mail;

public partial class Admin_EnrolledSite : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
   (ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
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
    private string Decrypt(string cipherText)
    {
        string EncryptionKey = ConfigurationManager.AppSettings["LegacyPasswordEncryptionKey"];
        if (string.IsNullOrWhiteSpace(EncryptionKey))
        {
            throw new ConfigurationErrorsException("LegacyPasswordEncryptionKey is not configured.");
        }
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            cmd = new SqlCommand("sp_CreateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LoginID", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Password", Encrypt(TextBox3.Text.Trim()));
            cmd.Parameters.AddWithValue("@Email", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Mobile", TextBox6.Text);
            cmd.Parameters.AddWithValue("@UserRole", DropDownList1.SelectedItem.Text);


            cmd.Parameters.AddWithValue("@IsLocked", "N");
            cmd.Parameters.AddWithValue("@IsLogin", "0");
            cmd.Parameters.AddWithValue("@LoginCnt", "0");
            cmd.Parameters.AddWithValue("@IsActive", "1");
            cmd.Parameters.AddWithValue("@IsDelete", "0");
            cmd.Parameters.AddWithValue("@ActiveFlag", "0");

            cmd.Parameters.AddWithValue("@CrBy", Session["UserID"].ToString());
            cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
            cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
            cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Dear " + TextBox1.Text + ",<br/>");
                
                sb.Append("<br/> Please find below login details for accessing ClinSoft (production mode):<br/>");


                sb.Append("<br/><b>URL : </b>https://Zanubrutinib.clinsoft.co.in<br/>");
                sb.Append("<b>Login ID : </b>" + TextBox5.Text);

                sb.Append("<br/><b>Password : </b>" + TextBox3.Text.Trim() + "</br></br>");
                sb.Append("<br/><b>User Role : </b>" + DropDownList1.SelectedValue + "</br></br>");


                sb.Append("<br/>");
                sb.Append("<br/><b>Request you to kindly acknowledge the receipt of login details.</b> <br/>");


                sb.Append("<br/><b> See you soon on ClinSoft. </b> <br/>");
                sb.Append("<br/><b>Thanks");
                sb.Append("<br/>ClinSoft Care Team");

                string smtpFrom = ConfigurationManager.AppSettings["SmtpFrom"];
                if (string.IsNullOrWhiteSpace(smtpFrom))
                {
                    throw new ConfigurationErrorsException("SmtpFrom is not configured.");
                }

                using (MailMessage message = new MailMessage(smtpFrom, TextBox4.Text, "Site User Creation (GPL ZANU-401 Study)", sb.ToString()))
                using (SmtpClient smtp = new SmtpClient())
                {
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }



                ShowMessage("User ID created successfully", MessageType.Success);
                TextBox1.Text = "";
                TextBox5.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox6.Text = "";
                DropDownList1.ClearSelection();
            }
            else
            {
                ShowMessage("User Login ID Already Exist !!", MessageType.Info);
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User ID is not Created!')", true);
        }
    }
}
