using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EnrolledSite : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

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
    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string query = "UPDATE tbl_UserLogin SET [Password] = @Password,ActivefLag=@ActivefLag WHERE [UserName] = @UserName AND [Password] = @CurrentPassword";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@CurrentPassword", Encrypt(TextBox3.Text.Trim()));
                        cmd.Parameters.AddWithValue("@ActivefLag", "1");
                        cmd.Parameters.AddWithValue("@Password", Encrypt(TextBox5.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                        cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                        cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);
                        cmd.Connection = con;
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            #region Audit Log Manage
                            //AuditLog objAuditLog = new AuditLog();
                            //objAuditLog.UserID = Convert.ToInt32(BasePage.UserId);
                            //objAuditLog.UserName = BasePage.UserName;
                            //objAuditLog.Role = BasePage.Role;
                            //objAuditLog.Action = "Change Password";
                            //objAuditLog.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                            //objAuditLog.Description = "Old Password : " + TextBox3.Text + " New Password" +TextBox4.Text;
                            //objAuditLog.AuditLogManage();
                            #endregion
                            Session.Clear();
                            Session.RemoveAll();
                            Session.Abandon();
                            Response.Redirect("~/PasswordChanged.aspx");


                        }
                        else
                        {


                        }
                        con.Close();
                    }
                }
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password not Changed!')", true);
        }
    }
    
}
