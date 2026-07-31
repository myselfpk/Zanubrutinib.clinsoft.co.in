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
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Net.Mail;

public partial class MasterPage_EnrollNewSubject : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
    (ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            
            SiteName();
            if (TextBoxSITENUM.Text == "")
            {
                Button1.Visible = false;
            }
            else
            {
                Button1.Visible = true;
            }
            AutoNumber();
        }
        
    }

    public void AutoNumber()
    {

        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT count([SUBNUM]) as tot FROM [dbo].[Subject] Where SITENUM='"+TextBoxSITENUM.Text+"'", con);

        SqlDataReader dr;

        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                int i = Convert.ToInt32(dr["tot"]);

                if (i > 0)
                {
                    int j = i + 1;
                    TextBoxSUBNUM.Text = "" + TextBoxSITENUM.Text + "-" + j.ToString("00");

                }
                else
                {
                    TextBoxSUBNUM.Text = "" + TextBoxSITENUM.Text + "-01";
                }

            }
        }
        else
        {
            TextBoxSUBNUM.Text = "" + TextBoxSITENUM.Text + "-01";
        }
        con.Close();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    private void SiteName()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT [CenterNumber] FROM [dbo].[tblEnrollUsersWithSite] where UserName='" + Session["UserName"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxSITENUM.Text = dt.Rows[0]["CenterNumber"].ToString();
        }
        con.Close();

    }
    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            try
            {
                cmd = new SqlCommand("sp_Subject", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SUBINI", TextBoxSUBINI.Text);
                cmd.Parameters.AddWithValue("@SUBNUM", TextBoxSUBNUM.Text);
                cmd.Parameters.AddWithValue("@SITENUM", TextBoxSITENUM.Text);
                cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
                cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //StringBuilder sb = new StringBuilder();

                    //sb.Append("<br/> Please find below Enroll New Subject details for accessing ClinSoft (production mode):<br/>");


                    //sb.Append("<b>Subject Number : </b>" + TextBoxSUBNUM.Text);

                    //sb.Append("<br/><b>Subject Initial : </b>" + TextBoxSUBINI.Text.Trim() + "</br></br>");

                    //sb.Append("<br/><b>Site Number : </b>" + TextBoxSITENUM.Text.Trim() + "</br></br>");


                    //sb.Append("<br/>");
                    //sb.Append("<br/><b>Request you to kindly acknowledge the receipt of Enroll New Subject.</b> <br/>");


                    //sb.Append("<br/><b> See you soon on ClinSoft. </b> <br/>");
                    //sb.Append("<br/><b>Thanks");
                    //sb.Append("<br/>ClinSoft Care Team");

                    ShowMessage("Subject is successfully enrolled", MessageType.Success);
                    TextBoxSITENUM.Text = "";
                    TextBoxSUBINI.Text = "";
                    TextBoxSUBNUM.Text = "";

                    SiteName();
                    AutoNumber();
                }

                else
                {
                    ShowMessage("Subject Number Already Exist !!", MessageType.Info);
                }
            }

            finally
            {
                con.Close();
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Subject is not Enrolled!')", true);
        }
    }
}
