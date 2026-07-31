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


public partial class Admin_EnrolledSite : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection
   (ConfigurationManager.ConnectionStrings["constr"].ToString());
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        InGridView();
    }
    protected void InGridView()
    {

        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT c.[Site] as CenterNumber,c.[ScreenID],c.[SubInitial],c.[Visit],c.[Page],c.[Field],c.[Query],c.[QueryResponse],c.[Status],c.[Date],c.Username,c.Username2,c.Date2 FROM [dbo].[tblQuery] as c inner Join [tblEnrollUsersWithSite] AS o ON c.[Site] =o.CenterNumber inner Join [Subject] AS d ON c.[Site] =d.SITENUM WHERE c.ScreenID=d.SUBNUM and c.Site=d.SITENUM and o.UserName='" + Session["UserName"] + "'", con);

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();

        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ErroeMess.Visible = false;
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        else
        {
            ErroeMess.Visible = true;
            Label1.Text = "No Record Found !!!";

        }
    }
}