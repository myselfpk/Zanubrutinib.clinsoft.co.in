using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
    (ConfigurationManager.ConnectionStrings["constr"].ToString());
    DataTable dt = new DataTable();
    private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");  protected void Page_Load(object sender, EventArgs e)
    {


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
    protected void btnsend_Click(object sender, EventArgs e)
    {

        try
        {

            Session["email"] = txtemail.Text;

            SqlDataAdapter adp = new SqlDataAdapter("select UserName,LoginID,[Password],Email from [dbo].[tbl_UserLogin] where LoginID=@LoginID", con);
            con.Open();

            adp.SelectCommand.Parameters.AddWithValue("@LoginID", txtemail.Text);

            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                #region Audit Log Manage
                AuditLog objAuditLog = new AuditLog();

                objAuditLog.UserName = txtemail.Text;
                objAuditLog.Role = "";
                objAuditLog.Action = "Forgot Password";
                objAuditLog.PageName = "Forgot Password";
                objAuditLog.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                objAuditLog.Description = "Successfully sent reset link on  your mail ,please check once! Thank you.";
                objAuditLog.AuditLogManage();
                #endregion


                ViewState["UName"] = dt.Rows[0]["UserName"].ToString();
                ViewState["LoginID"] = dt.Rows[0]["LoginID"].ToString();
                ViewState["UPassword"] = Decrypt(dt.Rows[0]["Password"].ToString());
                ViewState["UEmail"] = dt.Rows[0]["Email"].ToString();
                SendEmail();
                lbresult.ForeColor = System.Drawing.Color.Green;
                lbresult.Text = "Successfully sent reset link on  your mail ,please check once! Thank you.";
                con.Close();

                txtemail.Text = "";

            }
            else
            {
                lbresult.ForeColor = System.Drawing.Color.Red;
                lbresult.Text = "Please enter vaild user name,please check once! Thank you.";

                #region Audit Log Manage
                AuditLog objAuditLog = new AuditLog();

                objAuditLog.UserName = txtemail.Text;
                objAuditLog.Role = "";
                objAuditLog.Action = "Forgot Password";
                objAuditLog.PageName = "Forgot Password";
                objAuditLog.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                objAuditLog.Description = "Please enter vaild user name ,please check once! Thank you.";
                objAuditLog.AuditLogManage();
                #endregion

            }
            con.Close();
        }

        catch (Exception ex)
        {

        }

    }

    // using this method we sent the mail to reciever

    private void SendEmail()
    {

        try
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<br/>");
            sb.Append("Hi " + ViewState["UName"] + ",<br/><br/><br/>You recently asked to reset your password of your ClinSoft Account for GPL ZANU-401 Study.<br/>");
            sb.Append("<br/><b>URL : </b>https://Zanubrutinib.clinsoft.co.in<br/>");
            sb.Append("<br/><b>Login ID : </b>" + ViewState["LoginID"] + "<br/>");

            sb.Append("<br/><b>Password : </b>" + ViewState["UPassword"] + "<br/>");

            sb.Append("<br/>If you did not request a password reset, please ignore this email or reply to let us know.");
            sb.Append("<br/><b> See you soon on ClinSoft. </b> <br/>");
            sb.Append("<br/><b>Thanks");
            sb.Append("<br/>ClinSoft Care Team");

            string smtpFrom = ConfigurationManager.AppSettings["SmtpFrom"];
            if (string.IsNullOrWhiteSpace(smtpFrom))
            {
                throw new ConfigurationErrorsException("SmtpFrom is not configured.");
            }

            using (MailMessage message = new MailMessage(smtpFrom, ViewState["UEmail"].ToString(), "Reset Your Password (GPL ZANU-401 Study)", sb.ToString()))
            using (SmtpClient smtp = new SmtpClient())
            {
                message.IsBodyHtml = true;
                smtp.Send(message);
            }

        }

        catch (Exception ex)
        {

        }
    }

    private string GetUserEmail(string Email)
    {
        SqlCommand cmd = new SqlCommand("select Email from [dbo].[tbl_UserLogin] WHERE LoginID=@LoginID", con);
        cmd.Parameters.AddWithValue("@LoginID", txtemail.Text);

        string username = cmd.ExecuteScalar().ToString();
        return username;
    }
}
