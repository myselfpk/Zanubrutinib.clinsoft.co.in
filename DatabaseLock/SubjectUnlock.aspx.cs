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


public partial class DatabaseLock_SubjectUnlock : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd1;
    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd2;
    SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd3;
    SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd4;
    SqlConnection con5 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd5;
    SqlConnection con6 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd6;
    SqlConnection con7 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd7;
    SqlConnection con8 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd8;
    SqlConnection con9 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd9;
    SqlConnection con10 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd10;
    SqlConnection con11 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd11;
    SqlConnection con12 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd12;
    SqlConnection con13 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd13;
    SqlConnection con14 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd14;
    SqlConnection con15 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd15;
    SqlConnection con16 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd16;
    SqlConnection con17 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd17;
    SqlConnection con18 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd18;
    SqlConnection con19 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd19;
    SqlConnection con20 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd20;

    public enum MessageType { Success, Error, Info, Warning };

    SqlDataReader dr = null;

    string strSqlCmd = string.Empty;
    private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");  protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteName();

            
        }
        BindPage();
        BindSubject();





    }
    private void SiteName()
    {
        con.Open();
        string Site = "SELECT  CenterNumber FROM [dbo].[tblEnrollUsersWithSite] where UserName='" + Session["UserName"] + "'";
        SqlCommand SiteCommand = new SqlCommand(Site, con);
        SiteCommand.CommandType = CommandType.Text;
        SqlDataReader PNoSIdData;
        DropDownList1.Items.Clear();
        PNoSIdData = SiteCommand.ExecuteReader();
        if (PNoSIdData.HasRows)
        {
            DropDownList1.DataSource = PNoSIdData;
            DropDownList1.DataValueField = "CenterNumber";
            DropDownList1.DataTextField = "CenterNumber";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Choose Center Number", ""));
        }
        else
        {
            DropDownList1.Items.Insert(0, new ListItem("Choose Center Number", ""));

        }
        con.Close();
    }
  
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }


    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select * from Subject  where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            
            TextBox2.Text = dt.Rows[0]["SubInitial"].ToString();
           

        }
        con.Close();

    }


    

    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Informed Consent"))
            {
                con.Open(); con1.Open();
                cmd = new SqlCommand("Update InformedConsent set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con);
                cmd1 = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con1);

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con1.Close();
                con.Close();

            }

            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Demography"))
            {
                con1.Open();
                con.Open();
                cmd1 = new SqlCommand("Update Demography set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con18);
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con1.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Medical History"))
            {
                con2.Open();
                con.Open();
                cmd2 = new SqlCommand("Update Day1MedicalHistory set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con20);
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con2.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Concomitant Medication"))
            {
                con3.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);

                cmd3 = new SqlCommand("Update tblConModDay1 set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con2);
                cmd.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                con3.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "PHYSICAL AND SYSTEMIC EXAMINATION"))
            {
                con7.Open();
                con.Open();

                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd7 = new SqlCommand("Update Day1PhysicalExamination set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con7);
                cmd.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                con7.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Vital Examination"))
            {
                con9.Open();
                con.Open();
                cmd9 = new SqlCommand("Update Day1VITALEXAMINATION set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con9);
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);

                cmd.ExecuteNonQuery();
                cmd9.ExecuteNonQuery();
                con9.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "ONGOING MEDICATION"))
            {
                con11.Open();
                con.Open();

                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd11 = new SqlCommand("Update Day1ONGOINGMEDICATION set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con11);
                cmd.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
                con11.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Assent Form"))
            {
                con12.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd12 = new SqlCommand("Update tblAssentForm  set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con12);
                cmd.ExecuteNonQuery();
                cmd12.ExecuteNonQuery();

                con.Close();
                con12.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Subject Enrolment"))
            {
                con14.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd14 = new SqlCommand("Update Day1SubjectEnrolment set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con14);

                cmd.ExecuteNonQuery(); cmd14.ExecuteNonQuery();
                con14.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "VACCINATION BLOOD SAMPLING"))
            {
                con4.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd4 = new SqlCommand("Update Day1VACCINATIONBLOODSAMPLING set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con4);
                cmd4.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con4.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "STUDY VACCINE ADMINISTRATION"))
            {
                con18.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd18 = new SqlCommand("Update Day1STUDYVACCINEADMINISTRATION set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con1);
                cmd18.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con18.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "SOLICITED ADVERSE"))
            {
                con19.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd19 = new SqlCommand("Update tblSOLICITEDADVERSE set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con19);
                cmd19.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con19.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Inclusion Criteria"))
            {
                con17.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd17 = new SqlCommand("Update InclusionCriteria set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con17);
                cmd17.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con17.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Exclusion Criteria"))
            {
                con16.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd16 = new SqlCommand("Update ExclusionCriteria set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con16);
                cmd16.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con16.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "UNSOLICITED ADVERSE"))
            {
                con20.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd20 = new SqlCommand("Update tblUNSOLICITEDADVERSE set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con3);
                cmd20.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con20.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Day 1") && (DropDownList4.SelectedValue == "Subject Diary Card"))
            {
                con8.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd8 = new SqlCommand("Update Day1SubjectDiaryCard set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con8);
                cmd8.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con8.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Visit 2") && (DropDownList4.SelectedValue == "VACCINATION BLOOD SAMPLING"))
            {
                con8.Open();
                con.Open();
                cmd8 = new SqlCommand("Update Visit2VACCINATIONBLOODSAMPLING set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con8);
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd8.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con8.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Visit 2") && (DropDownList4.SelectedValue == "Adverse EventS BETWEEN"))
            {
                con8.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd8 = new SqlCommand("Update Visit2ADVERSEEVENTSBETWEEN set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con8);
                cmd8.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con8.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Visit 2") && (DropDownList4.SelectedValue == "HOSPITALIZATION Record"))
            {
                con8.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd8 = new SqlCommand("Update Visit2HOSPITALIZATIONRecord set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con8);
                cmd8.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con8.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Visit 2") && (DropDownList4.SelectedValue == "Concomitant Medication"))
            {
                con8.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd8 = new SqlCommand("Update tblConMod  set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con8);
                cmd8.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con8.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Visit 2") && (DropDownList4.SelectedValue == "PHYSICAL AND SYSTEMIC EXAMINATION"))
            {
                con8.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd8 = new SqlCommand("Update Visit2PhysicalExamination set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con8);
                cmd8.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con8.Close(); con.Close();
            }
            else if ((DropDownList3.SelectedValue == "Visit 2") && (DropDownList4.SelectedValue == "End of Study"))
            {
                con10.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd10 = new SqlCommand("Update tblEndofStudy set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con10);
                cmd10.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con10.Close(); con.Close();
            }

            else if ((DropDownList3.SelectedValue == "Visit 2") && (DropDownList4.SelectedValue == "VITAL EXAMINATION"))
            {
                con13.Open();
                con.Open();
                cmd = new SqlCommand("Update Subject set  LockStatus = 'Unlocked' where [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
                cmd13 = new SqlCommand("Update Visit2VITALEXAMINATION  set  LockStatus = 'Unlocked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con13);
                cmd13.ExecuteNonQuery(); cmd.ExecuteNonQuery();
                con13.Close(); con.Close();
            }
      

            else {

            }


        }


        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Subject page is not Unlocked!')", true);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

     
        String strConnString = ConfigurationManager
            .ConnectionStrings["constr"].ConnectionString;
        String strQuery = "select ID, ScreeningId from Subject " +
                           "where CenterNumber=@CenterNumber";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@CenterNumber",
            DropDownList1.SelectedItem.Value);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            DropDownList2.DataSource = cmd.ExecuteReader();
            DropDownList2.DataTextField = "ScreeningId";
            DropDownList2.DataValueField = "ScreeningId";
            DropDownList2.Items.Clear();

            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Choose Screening Id", ""));
            if (DropDownList2.Items.Count > 1)
            {
                DropDownList2.Enabled = true;
            }
            else
            {
                DropDownList2.Enabled = false;
               
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        String strConnString = ConfigurationManager
           .ConnectionStrings["constr"].ConnectionString;
        String strQuery = "select ID, Page from VisitPage " +
                           "where Visit=@Visit";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@Visit",  DropDownList3.SelectedValue);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            
            con.Open();
            DropDownList4.DataSource = cmd.ExecuteReader();
            DropDownList4.DataTextField = "Page";
            DropDownList4.DataValueField = "Page";
            DropDownList4.Items.Clear();
           
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("Choose Page", ""));
            if (DropDownList4.Items.Count > 1)
            {
                DropDownList4.Enabled = true;
            }
            else
            {
                DropDownList4.Enabled = false;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

   

    private void BindSubject()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select LockStatus from Subject  where LockStatus != 'Locked' and  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if (dr.HasRows)
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Subject is already Unlocked";
                DropDownList3.Visible = false;
                DropDownList4.Visible = false;
            }


            else
            {
                Button1.Visible = true;
                LabelSublock.Visible = false;
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
            }

        }
        else
        {

        }


        dr.Close();

        con.Close();

    }


   
}