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

public partial class Admin_EnrolledSite : System.Web.UI.Page
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
    SqlConnection con21 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd21;
    SqlConnection con22 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd22;
    SqlConnection con23 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd23;
   

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
        BindSubjectLock();

        BindSubject();
    }
    private void SiteName()
    {
        con.Open();
        string Site = "SELECT CenterNumber FROM [dbo].[tblEnrollUsersWithSite] where UserName='" + Session["UserName"] + "'";
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
            DropDownList1.Items.Insert(0, new ListItem("Choose..", "0"));
        }
        else
        {
            DropDownList1.Items.Insert(0, new ListItem("Choose..", "0"));

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


    private void BindSubjectLock()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select t1.LockStatus as 'InformedConsent',t2.LockStatus as 'Demography',t3.LockStatus as 'Day1MedicalHistory',t4.LockStatus as 'tblConModDay1',t5.LockStatus as 'Day1PhysicalExamination',t6.LockStatus as 'Day1VITALEXAMINATION',t7.LockStatus as 'Day1ONGOINGMEDICATION',t8.LockStatus as 'tblAssentForm',t9.LockStatus as 'Day1SubjectEnrolment',t10.LockStatus as 'Day1VACCINATIONBLOODSAMPLING',t11.LockStatus as 'Day1STUDYVACCINEADMINISTRATION',t12.LockStatus as 'tblSOLICITEDADVERSE',t13.LockStatus as 'tblUNSOLICITEDADVERSE',t14.LockStatus as 'Day1SubjectDiaryCard',t15.LockStatus as 'ExclusionCriteria',t16.LockStatus as 'InclusionCriteria',t17.LockStatus as 'Visit2VACCINATIONBLOODSAMPLING',t18.LockStatus as 'Visit2ADVERSEEVENTSBETWEEN' ,t19.LockStatus as 'Visit2HOSPITALIZATIONRecord',t20.LockStatus as 'tblConMod',t21.LockStatus as 'Visit2PhysicalExamination',t22.LockStatus as 'tblEndofStudy',t23.LockStatus as 'Visit2VITALEXAMINATION' from InformedConsent as t1  left join  Demography as t2 on t1.ScreeningID=t2.ScreeningID and t1.CenterNumber=t2.CenterNumber left join  Day1MedicalHistory as t3 on t2.ScreeningID=t3.ScreeningID and t2.CenterNumber=t3.CenterNumber  left join  tblConModDay1 as t4 on t3.ScreeningID=t4.ScreeningID and t3.CenterNumber=t4.CenterNumber  left join  Day1PhysicalExamination as t5 on t4.ScreeningID=t5.ScreeningID and t4.CenterNumber=t5.CenterNumber  left join  Day1VITALEXAMINATION as t6 on t5.ScreeningID=t6.ScreeningID and t5.CenterNumber=t6.CenterNumber  left join  Day1ONGOINGMEDICATION as t7 on t6.ScreeningID=t7.ScreeningID and t6.CenterNumber=t7.CenterNumber  left join  tblAssentForm as t8 on t7.ScreeningID=t8.ScreeningID and t7.CenterNumber=t8.CenterNumber  left join Day1SubjectEnrolment as t9 on t8.ScreeningID=t9.ScreeningID and t8.CenterNumber=t9.CenterNumber  left join  Day1VACCINATIONBLOODSAMPLING as t10 on t9.ScreeningID=t10.ScreeningID and t9.CenterNumber=t10.CenterNumber  left join Day1STUDYVACCINEADMINISTRATION as t11 on t10.ScreeningID=t11.ScreeningID and t10.CenterNumber=t11.CenterNumber  left join  tblSOLICITEDADVERSE as t12 on t11.ScreeningID=t12.ScreeningID and t11.CenterNumber=t12.CenterNumber  left join  tblUNSOLICITEDADVERSE as t13 on t12.ScreeningID=t13.ScreeningID and t12.CenterNumber=t13.CenterNumber left join  Day1SubjectDiaryCard as t14 on t13.ScreeningID=t14.ScreeningID and t13.CenterNumber=t14.CenterNumber left join  ExclusionCriteria as t15 on t14.ScreeningID=t15.ScreeningID and t14.CenterNumber=t15.CenterNo  left join  InclusionCriteria as t16 on t15.ScreeningID=t16.ScreeningID and t15.CenterNo =t16.CenterNumber  left join  Visit2VACCINATIONBLOODSAMPLING as t17 on t16.ScreeningID=t17.ScreeningID and t16.CenterNumber=t17.CenterNumber left join Visit2ADVERSEEVENTSBETWEEN as t18 on t17.ScreeningID=t18.ScreeningID and t17.CenterNumber=t18.CenterNumber left join Visit2HOSPITALIZATIONRecord as t19 on t18.ScreeningID=t19.ScreeningID and t18.CenterNumber=t19.CenterNumber left join tblConMod as t20 on t19.ScreeningID=t20.ScreeningID and t19.CenterNumber=t20.CenterNumber left join Visit2PhysicalExamination as t21 on t20.ScreeningID=t21.ScreeningID and t20.CenterNumber=t21.CenterNumber left join tblEndofStudy as t22 on t21.ScreeningID=t22.ScreeningID and t21.CenterNumber=t22.CenterNumber left join Visit2VITALEXAMINATION as t23 on t22.ScreeningID=t23.ScreeningID and t22.CenterNumber=t23.CenterNumber   where t1.[CenterNumber] ='" + DropDownList1.SelectedValue + "' and t1.[ScreeningID]='" + DropDownList2.SelectedValue + "'and t1.[SubjectInitial]='" + TextBox2.Text + "' ", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["InformedConsent"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Informed Consent page is not Locked";

            }
            else if ((dr["Demography"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Demography (Day 1) is not Locked";
            }
            else if ((dr["Day1MedicalHistory"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Medical History page (Day 1) is not Locked";
            }
            else if ((dr["tblConModDay1"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Concomitant Medication page (Day 1) is not Locked";
            }
            else if ((dr["Day1PhysicalExamination"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "PHYSICAL AND SYSTEMIC EXAMINATION page (Day 1) is not Locked";
            }

            else if ((dr["Day1VITALEXAMINATION"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Vital Examination page (Day 1) is not Locked";
            }
            else if ((dr["Day1ONGOINGMEDICATION"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "ONGOING MEDICATION page (Day 1) is not Locked";
            }
            else if ((dr["tblAssentForm"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Assent Form Panel page (Day 1) is not Locked";
            }
            else if ((dr["Day1SubjectEnrolment"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Subject Enrollment page (Day 1) is not Locked";
            }
            else if ((dr["Day1VACCINATIONBLOODSAMPLING"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "VACCINATION BLOOD SAMPLING page (Day 1) is not Locked";
            }
            else if ((dr["Day1STUDYVACCINEADMINISTRATION"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "STUDY VACCINE ADMINISTRATION page (Day 1) is not Locked";
            }
            else if ((dr["tblSOLICITEDADVERSE"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "SOLICITED ADVERSE page (Day 1) is not Locked";
            }
            else if ((dr["tblUNSOLICITEDADVERSE"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "UNSOLICITED ADVERSE page (Day 1) is not Locked";
            }
            else if ((dr["Day1SubjectDiaryCard"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Subject Diary Card page (Day 1) is not Locked";
            }

            else if ((dr["ExclusionCriteria"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Exclusion Criteria page is not Locked";
            }
            else if ((dr["InclusionCriteria"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Inclusion Criteria page is not Locked";
            }
            else if ((dr["Visit2VACCINATIONBLOODSAMPLING"].ToString() != "Locked"))
            {
                LabelSublock.Visible = true;
                LabelSublock.Text = "VACCINATION BLOOD SAMPLING page (visit 2) is not Locked";
                Button1.Visible = false;
            }
            else if ((dr["Visit2ADVERSEEVENTSBETWEEN"].ToString() != "Locked"))
            {
                LabelSublock.Visible = true;
                LabelSublock.Text = "Adverse EventS BETWEEN page (Visit 2) is not Locked";
                Button1.Visible = false;
            }
            else if ((dr["Visit2HOSPITALIZATIONRecord"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "HOSPITALIZATION Record page (Visit 2) is not Locked";
            }
            else if ((dr["tblConMod"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Concomitant Medication page (Visit 2)  is not Locked";
            }
            else if ((dr["Visit2PhysicalExamination"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "PHYSICAL AND SYSTEMIC EXAMINATION page (Visit 2) is not Locked";
            }
            else if ((dr["tblEndofStudy"].ToString() != "Locked"))
            {
                LabelSublock.Visible = true;
                LabelSublock.Text = "End  of Study page (Visit 2) is not Locked";
                Button1.Visible = false;
            }
            else if ((dr["Visit2VITALEXAMINATION"].ToString() != "Locked"))
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "VITAL EXAMINATION page (Visit 2) is not Locked";
            }
      

            else
            {
                Button1.Visible = true;
                LabelSublock.Visible = false;
            }

        }
        else
        {

        }


        dr.Close();

        con.Close();

    }
  

    private void BindSubject()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select LockStatus from Subject  where LockStatus = 'Locked' and  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubInitial]='" + TextBox2.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if (dr.HasRows)
            {
                Button1.Visible = false;
                LabelSublock.Visible = true;
                LabelSublock.Text = "Subject is already Locked";

            }


            else
            {
                Button1.Visible = true;
                LabelSublock.Visible = false;
            }

        }
        else
        {

        }


        dr.Close();

        con.Close();

    }

    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            con.Close();
            con.Open();
            con1.Open();
            con2.Open();
            con3.Open();
            con4.Open();
            con5.Open();
            con6.Open();
            con7.Open();
            con8.Open();
            con9.Open();
            con10.Open();
            con11.Open();
            con12.Open();
            con13.Open();
            con14.Open();
            con15.Open();
            con16.Open();
            con17.Open();
            con18.Open();
            con19.Open();
            con20.Open();
            con21.Open();
            con22.Open();
      
         

            cmd = new SqlCommand("Update InformedConsent set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con);
            cmd1 = new SqlCommand("Update Demography set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con1);
            cmd2 = new SqlCommand("Update Day1MedicalHistory set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con2);
            cmd3 = new SqlCommand("Update tblConModDay1 set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con3);
            cmd4 = new SqlCommand("Update Day1PhysicalExamination set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con4);
            cmd5 = new SqlCommand("Update Day1VITALEXAMINATION set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con5);
            cmd6 = new SqlCommand("Update Day1ONGOINGMEDICATION set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con6);
            cmd7 = new SqlCommand("Update tblAssentForm set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con7);
            cmd8 = new SqlCommand("Update Day1SubjectEnrolment set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con8);
            cmd9 = new SqlCommand("Update Day1VACCINATIONBLOODSAMPLING set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con9);
            cmd10 = new SqlCommand("Update Day1STUDYVACCINEADMINISTRATION set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con10);
            cmd11 = new SqlCommand("Update tblSOLICITEDADVERSE set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con11);
            cmd12 = new SqlCommand("Update tblUNSOLICITEDADVERSE set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con12);
            cmd13 = new SqlCommand("Update Day1SubjectDiaryCard set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con13);
            cmd14 = new SqlCommand("Update ExclusionCriteria set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con14);
            cmd15 = new SqlCommand("Update InclusionCriteria set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con15);
            cmd16 = new SqlCommand("Update Visit2VACCINATIONBLOODSAMPLING set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con16);
            cmd17 = new SqlCommand("Update Visit2ADVERSEEVENTSBETWEEN set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con17);
            cmd18 = new SqlCommand("Update Visit2HOSPITALIZATIONRecord set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con2);
            cmd19 = new SqlCommand("Update tblConMod set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con3);
            cmd20 = new SqlCommand("Update Visit2PhysicalExamination set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con4);
            cmd21 = new SqlCommand("Update tblEndofStudy set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con2);
            cmd22 = new SqlCommand("Update Visit2VITALEXAMINATION set  LockStatus = 'Locked' where  [CenterNumber] ='" + DropDownList1.SelectedValue + "' and [ScreeningID]='" + DropDownList2.SelectedValue + "'and [SubjectInitial]='" + TextBox2.Text + "'", con3);
      

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            cmd6.ExecuteNonQuery();
            cmd7.ExecuteNonQuery();
            cmd8.ExecuteNonQuery();
            cmd9.ExecuteNonQuery();
            cmd10.ExecuteNonQuery();
            cmd11.ExecuteNonQuery();
            cmd12.ExecuteNonQuery();
            cmd13.ExecuteNonQuery();
            cmd14.ExecuteNonQuery();
            cmd15.ExecuteNonQuery();
            cmd16.ExecuteNonQuery();
            cmd17.ExecuteNonQuery();
            cmd18.ExecuteNonQuery();
            cmd19.ExecuteNonQuery();
            cmd20.ExecuteNonQuery();
            cmd21.ExecuteNonQuery();
            cmd22.ExecuteNonQuery();
         
           

            con.Close();
            con1.Close();
            con2.Close();
            con3.Close();
            con4.Close();
            con5.Close();
            con6.Close();
            con7.Close();
            con8.Close();
            con9.Close();
            con10.Close();
            con11.Close();
            con12.Close();
            con13.Close();
            con14.Close();
            con15.Close();
            con16.Close();
            con17.Close();
            con18.Close();
            con19.Close();
            con20.Close();
            con21.Close();
            con22.Close();
        
          

        }


        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Subject is not locked!')", true);
        }
    }
}