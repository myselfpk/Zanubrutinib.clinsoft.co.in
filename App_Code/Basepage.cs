using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

public class BasePage : System.Web.UI.Page
{    
    public static string _userName = string.Empty;
    public static string _CenterNumber = string.Empty;
    
    public static string UserName
    { 
        get
        {
            return _userName;
        }
        set
        {
            _userName = value;
        }
    }

    public static string CenterNumber
    {
        get
        {
            return _CenterNumber;
        }
        set
        {
            _CenterNumber = value;
        }
    }

    public bool IsAuthenticUser(string userName, out DataTable dt)
    {
        try
        {
            dt = new DataTable();
            string CS = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("proc_SiteByCRC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                SqlParameter paramUserName = new SqlParameter("@in_userName", userName);
                cmd.Parameters.Add(paramUserName);
                con.Open();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    CenterNumber = dt.Rows[0][0].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch
        {
            throw;
        }
    }
}
