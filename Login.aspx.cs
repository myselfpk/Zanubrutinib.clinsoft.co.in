#region " [ using ] "
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
#endregion

public partial class Login : System.Web.UI.Page
{
    BasePage basePage = new BasePage();

    #region " [ Button Event ] "
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;

        Page.Validate("Login1");
        if (!Page.IsValid || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            ShowLoginError("Enter your login ID and password.");
            return;
        }

        DataTable dtUser = new DataTable();
        string userSession = Guid.NewGuid().ToString();

        try
        {
            dtUser = CheckUserLogin(userSession, "Login");

            if (dtUser == null || dtUser.Rows.Count == 0)
            {
                ShowLoginError("Unable to sign in with those credentials.");
                return;
            }

            DataRow userRow = dtUser.Rows[0];
            if (dtUser.Columns.Contains("RES"))
            {
                AuditLog failedLogin = new AuditLog();
                failedLogin.UserName = txtLogin.Text.Trim();
                failedLogin.Role = string.Empty;
                failedLogin.Action = "Unauthorized Login";
                failedLogin.PageName = "Login";
                failedLogin.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                failedLogin.Description = Convert.ToString(userRow["RES"]);
                failedLogin.AuditLogManage();

                ShowLoginError("Unable to sign in with those credentials.");
                return;
            }

            Session["UserSession"] = userSession;
            Session["UserID"] = userRow["UserID"];
            Session["UserName"] = userRow["UserName"];
            Session["loginID"] = userRow["LoginID"];
            Session["LastLogin"] = userRow["LastLogin"];
            Session["UserRoles"] = userRow["UserRole"];
            Session["ActivefLag"] = userRow["ActiveFlag"];

            AuditLog successfulLogin = new AuditLog();
            successfulLogin.UserName = Convert.ToString(Session["UserName"]);
            successfulLogin.Role = Convert.ToString(Session["UserRoles"]);
            successfulLogin.Action = "Login";
            successfulLogin.PageName = "Login";
            successfulLogin.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            successfulLogin.Description = "User Login Successfully";
            successfulLogin.AuditLogManage();

            bool mustChangePassword;
            bool.TryParse(Convert.ToString(Session["ActivefLag"]), out mustChangePassword);
            if (!mustChangePassword)
            {
                RedirectWithoutAbort("~/ChangePassword.aspx");
                return;
            }

            DataTable siteData;
            basePage.IsAuthenticUser(Convert.ToString(Session["UserName"]), out siteData);
            if (siteData != null)
            {
                siteData.Dispose();
            }

            RedirectWithoutAbort("~/Home.aspx");
        }
        catch (Exception ex)
        {
            Trace.Warn("Login", "Unexpected sign-in error.", ex);
            ShowLoginError("Unable to sign in right now. Please try again shortly.");
        }
        finally
        {
            dtUser.Dispose();
        }
    }
    #endregion

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

    #region " [ Private Function ] "
    private DataTable CheckUserLogin(string userSession, string mode)
    {
        DataTable userTable = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(
            ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
        using (SqlDataAdapter sqlCmd = new SqlDataAdapter("USP_UserLogin", sqlCon))
        {
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@loginID", SqlDbType.VarChar, 25).Value = txtLogin.Text.Trim();
            sqlCmd.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar, 200).Value = Encrypt(txtPassword.Text);
            sqlCmd.SelectCommand.Parameters.Add("@sessionID", SqlDbType.VarChar, 200).Value = userSession;
            sqlCmd.SelectCommand.Parameters.Add("@UserRole", SqlDbType.VarChar, 250).Value = DBNull.Value;
            sqlCmd.SelectCommand.Parameters.Add("@ActiveFlag", SqlDbType.VarChar, 1).Value = DBNull.Value;
            sqlCmd.SelectCommand.Parameters.Add("@mode", SqlDbType.VarChar, 15).Value = mode;

            sqlCmd.Fill(userTable);
        }

        return userTable;
    }

    private void ShowLoginError(string message)
    {
        lblError.Text = message;
        txtLogin.Attributes["aria-invalid"] = "true";
        txtPassword.Attributes["aria-invalid"] = "true";
        txtLogin.Focus();
    }

    private void RedirectWithoutAbort(string url)
    {
        Response.Redirect(url, false);
        Context.ApplicationInstance.CompleteRequest();
    }

    #endregion
}
