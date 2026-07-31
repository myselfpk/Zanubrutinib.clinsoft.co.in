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

public partial class Admin_AssignSite2User : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
     (ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.Equals(Convert.ToString(Session["UserRoles"]), "Administrator", StringComparison.Ordinal))
        {
            Response.Redirect("~/Login.aspx", true);
            return;
        }

        if (!IsPostBack)
        {
            SiteName();
            Coordinator();
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    public void SiteName()
    {
        con.Open();
        string Site = "SELECT [CenterNumber] FROM [dbo].[Site]";
        SqlCommand SiteCommand = new SqlCommand(Site, con);
        SiteCommand.CommandType = CommandType.Text;
        SqlDataReader hospitalData;
        hospitalData = SiteCommand.ExecuteReader();
        if (hospitalData.HasRows)
        {
            DropDownList2.DataSource = hospitalData;
            DropDownList2.DataValueField = "CenterNumber";
            DropDownList2.DataTextField = "CenterNumber";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Choose Center Number...", "0"));
        }
        else
        {
            DropDownList2.Items.Insert(0, new ListItem("Choose Center Number...", "0"));
        }
        con.Close();
    }
    public void Coordinator()
    {
        con.Open();
        string UserName = "SELECT UserName, UserName+'-'+UserRole as UserValue FROM [dbo].[tbl_UserLogin]";
        SqlCommand UserNameCommand = new SqlCommand(UserName, con);
        UserNameCommand.CommandType = CommandType.Text;
        SqlDataReader PNoSIdData;
        PNoSIdData = UserNameCommand.ExecuteReader();
        if (PNoSIdData.HasRows)
        {
            DropDownList1.DataSource = PNoSIdData;
            DropDownList1.DataValueField = "UserName";
            DropDownList1.DataTextField = "UserName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Please Select User Name", "0"));
        }
        else
        {
            DropDownList1.Items.Insert(0, new ListItem("Please Select User Name", "0"));
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Close();
        DataTable dt = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand(
            "SELECT [CenterAddress], [CenterNumber], [PIName] FROM [dbo].[Site] WHERE CenterNumber = @CenterNumber",
            con);
        sqlCmd.Parameters.Add("@CenterNumber", SqlDbType.NVarChar, 50).Value = DropDownList2.SelectedValue;
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            TextBox2.Text = dt.Rows[0]["CenterAddress"].ToString();
           
            TextBox4.Text = dt.Rows[0]["PIName"].ToString();

        }
        con.Close();
    }
    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            cmd = new SqlCommand("sp_EnrollUsersWithSite", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CenterNumber", DropDownList2.SelectedItem.Text);
          
            cmd.Parameters.AddWithValue("@Adress", TextBox2.Text);
            cmd.Parameters.AddWithValue("@PI", TextBox4.Text);
            cmd.Parameters.AddWithValue("@UserName", DropDownList1.SelectedItem.Text);

            cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
            cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
            cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                ShowMessage("Record Submitted successfully", MessageType.Success);
           

        TextBox2.Text = "";
                
                TextBox4.Text = "";

                DropDownList1.ClearSelection();
                DropDownList2.ClearSelection();
            }
            else
            {
                ShowMessage("Site already assigned to this user!!", MessageType.Info);
            }
        }

        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Site is not Assigned to user!')", true);
        }
    }
}
