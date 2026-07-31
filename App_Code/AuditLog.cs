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

/// <summary>
/// Summary description for AuditLog
/// </summary>
public class AuditLog
{
    SqlCommand cmd;
    public AuditLog()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string UserName { set; get; }
    public string Role { set; get; }
    public string Action { set; get; }
    public string PageName { set; get; }
    public string PageUrl { set; get; }
    public string Description { set; get; }

    public string DateTime { set; get; }

    public string AuditLogManage()
    {
        string sqlMsg = string.Empty;
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (cmd = new SqlCommand("usp_InsertAuditLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Role", Role);
                    cmd.Parameters.AddWithValue("@Action", Action);

                    cmd.Parameters.AddWithValue("@PageName", PageName);

                    cmd.Parameters.AddWithValue("@PageUrl", PageUrl);
                    cmd.Parameters.AddWithValue("@Description", Description);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        catch (Exception ex)
        {

            sqlMsg = ex.Message;
        }
        return sqlMsg;
    }
}
