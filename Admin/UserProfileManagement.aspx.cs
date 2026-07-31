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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.Equals(Convert.ToString(Session["UserRoles"]), "Administrator", StringComparison.Ordinal))
        {
            Response.Redirect("~/Login.aspx", true);
            return;
        }

        if (!IsPostBack)
        {

            BindData();
        }
    }

    private void BindData()
    {


        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [UserID], [UserName], [LoginID], [Email], [UserRole], [IsLocked], [LastLogin] FROM [dbo].[tbl_UserLogin]", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        int count = ds.Tables[0].Rows.Count;
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            Label1.Visible = true;
            Label1.Text = " No data found !!!";

        }

    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        BindData();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void EditCustomer(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();

    }
    protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
    {
        int userId;
        if (!int.TryParse(GridView1.DataKeys[e.RowIndex].Values["UserID"].ToString(), out userId))
        {
            throw new InvalidOperationException("Invalid user identifier.");
        }
        TextBox txtUserName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUserName");
        TextBox txtLoginID = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLoginID");
        TextBox txtEmail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
        TextBox txtUserRole = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtUserRole");
        TextBox txtIsLocked = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtIsLocked");
        con.Open();
        using (SqlCommand cmd = new SqlCommand(
            @"UPDATE [dbo].[tbl_UserLogin]
              SET UserName = @UserName,
                  LoginID = @LoginID,
                  Email = @Email,
                  UserRole = @UserRole,
                  IsLocked = @IsLocked,
                  LoginCnt = 0
              WHERE UserID = @UserID",
            con))
        {
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = txtUserName.Text.Trim();
            cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 250).Value = txtLoginID.Text.Trim();
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250).Value = txtEmail.Text.Trim();
            cmd.Parameters.Add("@UserRole", SqlDbType.NVarChar, 250).Value = txtUserRole.Text.Trim();
            cmd.Parameters.Add("@IsLocked", SqlDbType.VarChar, 1).Value = txtIsLocked.Text.Trim();
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
            cmd.ExecuteNonQuery();
        }
        con.Close();
        Label1.Visible = true;
        Label1.BackColor = Color.Blue;
        Label1.ForeColor = Color.White;
        Label1.Text = userId + "        Updated successfully........    ";
        GridView1.EditIndex = -1;
        BindData();
    }

}
