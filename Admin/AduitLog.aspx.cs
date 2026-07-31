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

public partial class Admin_UserProfileManagement : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    public void Search()
    {
        DataTable dt = new DataTable();
        SqlCommand com = new SqlCommand("proc_AditLogSearching", con);
        com.Parameters.AddWithValue("@mode", "SELECT");
        com.Parameters.AddWithValue("@Date1", TextBox4.Text);
        com.Parameters.AddWithValue("@Date2", TextBox1.Text);
        com.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(com);
        try
        {
            con.Open();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                ShowMessage("No data found", MessageType.Info);
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }
}