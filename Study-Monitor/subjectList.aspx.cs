using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;

public partial class MasterPage_subjectList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
   (ConfigurationManager.ConnectionStrings["constr"].ToString());
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        InGridView();
    }
    protected void InGridView()
    {

        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT t1.[SUBINI] as SubInitial, t1.[SUBNUM] as ScreeningId, t1.SITENUM as CenterNumber FROM  [dbo].[Subject] t1 LEFT OUTER JOIN [dbo].[tblEnrollUsersWithSite] t3 ON  t1.SITENUM=t3.CenterNumber LEFT OUTER JOIN [dbo].[Site] t2 ON t1.SITENUM = t2.CenterNumber WHERE t3.UserName='" + Session["UserName"] + "' order by t1.[SITENUM]", con);
      
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();

        
        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            ErroeMess.Visible = false;
        }
        else
        {
            ErroeMess.Visible = true;
            Label1.Text = "No Record Found";
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("dvview"))
        {
            int index = Convert.ToInt16(e.CommandArgument);
            Label lbl = (Label)GridView1.Rows[index].FindControl("lbCenterNumber");
            Label lbl1 = (Label)GridView1.Rows[index].FindControl("lbScreeningId");
            Label lbl2 = (Label)GridView1.Rows[index].FindControl("lbSubInitial");




            Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + lbl.Text + "&b=" + lbl1.Text + "&c=" + lbl2.Text + "&d=" + "Visit 0");

        }

    }
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        InGridView();
    }

   
}