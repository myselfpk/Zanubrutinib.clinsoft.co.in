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

public partial class Admin_EnrolledSite : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
     (ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            try
            {
                cmd = new SqlCommand("sp_Site", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProtocolNumber", txtProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@CenterNumber", txtCenterid.Text);
                cmd.Parameters.AddWithValue("@Studytitle", txtOfficialtitle.Text);
                cmd.Parameters.AddWithValue("@PIName", txtPInvestigator.Text);

                cmd.Parameters.AddWithValue("@CenterAddress", txtCenterAddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtCNo.Text);

                cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");

                cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    ShowMessage("Site Enrolled successfully", MessageType.Success);

                    //txtProtocolNumber.Text = "";

                    txtCenterid.Text = "";
                    //txtOfficialtitle.Text = "";
                    txtPInvestigator.Text = "";

                    txtCenterAddress.Text = "";

                    txtCNo.Text = "";


                }

                else
                {
                    ShowMessage("Site ID Already Exist !!", MessageType.Info);
                }
            }
            catch
            {
                ShowMessage("Incorret Data Entry Please Check !!", MessageType.Warning);
            }
            finally
            {
                con.Close();
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Site is not Enrolled!')", true);
        }
    }
}