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

public partial class DatabaseLock_PIUndertaking : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();



    public enum MessageType { Success, Error, Info, Warning };

    SqlDataReader dr = null;

    string strSqlCmd = string.Empty;
    private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["UserSession"] != null)
        {
            LabelUserName.Text = Session["UserName"].ToString();

        }
        else
        {
            LabelUserName.Text = "";

        }
        if (Session["UserRoles"].ToString() == "Principal Investigator")
        {
            Panel1.Visible = true;

        }
        else
        {
            Panel1.Visible = false;

        }
        if (!IsPostBack)
        {

            
        }
        BindSubjectLock();
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SiteName();
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        string Site = "SELECT ScreeningId FROM [dbo].[Subject] where CenterNumber='" + DropDownList1.SelectedValue + "' and AgeGroup='" + RadioButtonList2.SelectedValue + "' and PIAuth='UnLock'";
        SqlCommand SiteCommand = new SqlCommand(Site, con);
        SiteCommand.CommandType = CommandType.Text;
        SqlDataReader ScreeningIdData;
        DropDownList2.Items.Clear();
        ScreeningIdData = SiteCommand.ExecuteReader();
        if (ScreeningIdData.HasRows)
        {
            DropDownList2.DataSource = ScreeningIdData;
            DropDownList2.DataValueField = "ScreeningId";
            DropDownList2.DataTextField = "ScreeningId";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Choose..", "0"));
        }
        else
        {
            DropDownList2.Items.Insert(0, new ListItem("Choose..", "0"));

        }
        con.Close();

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        DataTable dt = new DataTable();
        SqlCommand sqlCmd = new SqlCommand("SELECT SubInitial FROM [dbo].[Subject] where CenterNumber='" + DropDownList1.SelectedValue + "' and AgeGroup='" + RadioButtonList2.SelectedValue + "' and ScreeningId='" + DropDownList2.SelectedValue + "'", con);
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
        if (RadioButtonList2.SelectedValue == "19 Years to 49 Years of age")
        {
            con.Close();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("select t1.LockStatus as 'VISIT-1-Informed Consent' ,t2.LockStatus as 'VISIT-1-Demography' ,t3.LockStatus as 'VISIT-1-Medical History' ,t4.LockStatus as 'VISIT-1-ONGOING MEDICATION DETAILS' ,t5.LockStatus as 'VISIT-1-VACCINATION HISTORY' ,t6.LockStatus as 'VISIT-1-GENERAL AND VITAL EXAMINATION' ,t7.LockStatus as 'VISIT-1-PHYSICAL AND SYSTEMIC EXAMINATION' ,t8.LockStatus as 'VISIT-1-Inclusion Criteria' ,t9.LockStatus as 'VISIT-1-Exclusion Criteria' ,t10.LockStatus as 'VISIT-1-SUBJECT ENROLLMENT' ,t11.LockStatus as 'VISIT-1-PRE-VACCINATION BLOOD SAMPLING' ,t12.LockStatus as 'VISIT-1-STUDY VACCINE ADMINISTRATION' ,t13.LockStatus as 'VISIT-1-SOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION' ,t14.LockStatus as 'VISIT-1-UNSOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION' ,t15.LockStatus as 'VISIT-1-SUBJECT DIARY CARD' ,t16.LockStatus as 'VISIT-1-Concomitant Medication' ,t17.LockStatus as 'VISIT-2-GENERAL AND VITAL EXAMINATION' ,t18.LockStatus as 'VISIT-2-PHYSICAL AND SYSTEMIC EXAMINATION' ,t19.LockStatus as 'VISIT-2-POST-VACCINATION BLOOD SAMPLING' ,t20.LockStatus as 'VISIT-2-Adverse EventS BETWEEN Day 1 AND 2 AS MENTIONED ON DIARY CARD (BOTH SOLICITED & UNSOLICITED)' ,t21.LockStatus as 'VISIT-2-HOSPITALIZATION Record' ,t22.LockStatus as 'VISIT-2-Concomitant Medication' ,t23.LockStatus as 'VISIT-2-END OF STUDY' from InformedConsent as t1 left join Demography as t2 on t1.ScreeningID=t2.ScreeningID and t1.CenterNumber=t2.CenterNumber left join Day1MedicalHistory as t3 on t2.ScreeningID=t3.ScreeningID and t2.CenterNumber=t3.CenterNumber left join Day1ONGOINGMEDICATION as t4 on t3.ScreeningID=t4.ScreeningID and t3.CenterNumber=t4.CenterNumber left join Day1VACCINATIONHISTORY as t5 on t4.ScreeningID=t5.ScreeningID and t4.CenterNumber=t5.CenterNumber left join Day1VITALEXAMINATION as t6 on t5.ScreeningID=t6.ScreeningID and t5.CenterNumber=t6.CenterNumber left join Day1PhysicalExamination as t7 on t6.ScreeningID=t7.ScreeningID and t6.CenterNumber=t7.CenterNumber left join InclusionCriteria as t8 on t7.ScreeningID=t8.ScreeningID and t7.CenterNumber=t8.CenterNumber left join ExclusionCriteria as t9 on t8.ScreeningID=t9.ScreeningID and t8.CenterNumber=t9.CenterNo left join Day1SubjectEnrolment as t10 on t9.ScreeningID=t10.ScreeningID and t9.CenterNo=t10.CenterNumber left join Day1VACCINATIONBLOODSAMPLING as t11 on t10.ScreeningID=t11.ScreeningID and t10.CenterNumber=t11.CenterNumber left join Day1STUDYVACCINEADMINISTRATION as t12 on t11.ScreeningID=t12.ScreeningID and t11.CenterNumber=t12.CenterNumber left join tblSOLICITEDADVERSE as t13 on t12.ScreeningID=t13.ScreeningID and t12.CenterNumber=t13.CenterNumber left join tblUNSOLICITEDADVERSE as t14 on t13.ScreeningID=t14.ScreeningID and t13.CenterNumber=t14.CenterNumber left join Day1SubjectDiaryCard as t15 on t14.ScreeningID=t15.ScreeningID and t14.CenterNumber=t15.CenterNumber left join tblConModDay1 as t16 on t15.ScreeningID=t16.ScreeningID and t15.CenterNumber =t16.CenterNumber left join Visit2VITALEXAMINATION as t17 on t16.ScreeningID=t17.ScreeningID and t16.CenterNumber=t17.CenterNumber left join Visit2PhysicalExamination as t18 on t17.ScreeningID=t18.ScreeningID and t17.CenterNumber=t18.CenterNumber left join Visit2VACCINATIONBLOODSAMPLING as t19 on t18.ScreeningID=t19.ScreeningID and t18.CenterNumber=t19.CenterNumber left join Visit2ADVERSEEVENTSBETWEEN as t20 on t19.ScreeningID=t20.ScreeningID and t19.CenterNumber=t20.CenterNumber left join Visit2HOSPITALIZATIONRecord as t21 on t20.ScreeningID=t21.ScreeningID and t20.CenterNumber=t21.CenterNumber left join tblConModDay1 as t22 on t21.ScreeningID=t22.ScreeningID and t21.CenterNumber=t22.CenterNumber left join tblEndofStudy as t23 on t22.ScreeningID=t23.ScreeningID and t22.CenterNumber=t23.CenterNumber where t1.[CenterNumber] ='" + DropDownList1.SelectedValue + "' and t1.[ScreeningID]='" + DropDownList2.SelectedValue + "' and t1.[SubjectInitial]='" + TextBox2.Text + "'", con);
cmd.CommandTimeout = 50;
        cmd.CommandType = CommandType.Text;
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                if ((dt.Rows[0]["VISIT-1-Informed Consent"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Informed Consent page is not Locked";

                }
                else if ((dt.Rows[0]["VISIT-1-Demography"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Demography (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-Medical History"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Medical History page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-ONGOING MEDICATION DETAILS"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "ONGOING MEDICATION DETAILS page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-VACCINATION HISTORY"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "VACCINATION HISTORY page (Day 1) is not Locked";
                }

                else if ((dt.Rows[0]["VISIT-1-GENERAL AND VITAL EXAMINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "GENERAL AND VITAL EXAMINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-PHYSICAL AND SYSTEMIC EXAMINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "PHYSICAL AND SYSTEMIC EXAMINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-Inclusion Criteria"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Inclusion Criteria page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-Exclusion Criteria"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Exclusion Criteria page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-SUBJECT ENROLLMENT"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "SUBJECT ENROLLMENT page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-STUDY VACCINE ADMINISTRATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "STUDY VACCINE ADMINISTRATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-SOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "SOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-UNSOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "UNSOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-SUBJECT DIARY CARD"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "SUBJECT DIARY CARD page (Day 1) is not Locked";
                }

                else if ((dt.Rows[0]["VISIT-1-Concomitant Medication"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Concomitant Medication page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-GENERAL AND VITAL EXAMINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "GENERAL AND VITAL EXAMINATION page (visit 2) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-PHYSICAL AND SYSTEMIC EXAMINATION"].ToString() != "Locked"))
                {
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "PHYSICAL AND SYSTEMIC EXAMINATION page (visit 2) is not Locked";
                    Panel2.Visible = false;
                }
                else if ((dt.Rows[0]["VISIT-2-POST-VACCINATION BLOOD SAMPLING"].ToString() != "Locked"))
                {
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "POST-VACCINATION BLOOD SAMPLING page (Visit 2) is not Locked";
                    Panel2.Visible = false;
                }
                else if ((dt.Rows[0]["VISIT-2-Adverse EventS BETWEEN Day 1 AND 2 AS MENTIONED ON DIARY CARD (BOTH SOLICITED & UNSOLICITED)"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Adverse EventS BETWEEN Day 1 AND 2 AS MENTIONED ON DIARY CARD (BOTH SOLICITED & UNSOLICITED) page (Visit 2) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-HOSPITALIZATION Record"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "HOSPITALIZATION Record page (Visit 2)  is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-Concomitant Medication"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Concomitant Medication page (Visit 2) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-END OF STUDY"].ToString() != "Locked"))
                {
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "END OF STUDY page (Visit 2) is not Locked";
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                    LabelSublock.Visible = false;
                }

            }
            else
            {

            }

            con.Close();
        }
        else if (RadioButtonList2.SelectedValue == "12 Years up to 19 Years of age")
        {
            con.Close();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("select t1.LockStatus as 'VISIT-1-Informed Consent' ,t24.LockStatus as  'VISIT-1-ASSENT FORM',t2.LockStatus as 'VISIT-1-Demography' ,t3.LockStatus as 'VISIT-1-Medical History' ,t4.LockStatus as 'VISIT-1-ONGOING MEDICATION DETAILS' ,t5.LockStatus as 'VISIT-1-VACCINATION HISTORY' ,t6.LockStatus as 'VISIT-1-GENERAL AND VITAL EXAMINATION' ,t7.LockStatus as 'VISIT-1-PHYSICAL AND SYSTEMIC EXAMINATION' ,t8.LockStatus as 'VISIT-1-Inclusion Criteria' ,t9.LockStatus as 'VISIT-1-Exclusion Criteria' ,t10.LockStatus as 'VISIT-1-SUBJECT ENROLLMENT' ,t11.LockStatus as 'VISIT-1-PRE-VACCINATION BLOOD SAMPLING' ,t12.LockStatus as 'VISIT-1-STUDY VACCINE ADMINISTRATION' ,t13.LockStatus as 'VISIT-1-SOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION' ,t14.LockStatus as 'VISIT-1-UNSOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION' ,t15.LockStatus as 'VISIT-1-SUBJECT DIARY CARD' ,t16.LockStatus as 'VISIT-1-Concomitant Medication' ,t17.LockStatus as 'VISIT-2-GENERAL AND VITAL EXAMINATION' ,t18.LockStatus as 'VISIT-2-PHYSICAL AND SYSTEMIC EXAMINATION' ,t19.LockStatus as 'VISIT-2-POST-VACCINATION BLOOD SAMPLING' ,t20.LockStatus as 'VISIT-2-Adverse EventS BETWEEN Day 1 AND 2 AS MENTIONED ON DIARY CARD (BOTH SOLICITED & UNSOLICITED)' ,t21.LockStatus as 'VISIT-2-HOSPITALIZATION Record' ,t22.LockStatus as 'VISIT-2-Concomitant Medication' ,t23.LockStatus as 'VISIT-2-END OF STUDY' from InformedConsent as t1 left join Demography as t2 on t1.ScreeningID=t2.ScreeningID and t1.CenterNumber=t2.CenterNumber left join Day1MedicalHistory as t3 on t2.ScreeningID=t3.ScreeningID and t2.CenterNumber=t3.CenterNumber left join Day1ONGOINGMEDICATION as t4 on t3.ScreeningID=t4.ScreeningID and t3.CenterNumber=t4.CenterNumber left join Day1VACCINATIONHISTORY as t5 on t4.ScreeningID=t5.ScreeningID and t4.CenterNumber=t5.CenterNumber left join Day1VITALEXAMINATION as t6 on t5.ScreeningID=t6.ScreeningID and t5.CenterNumber=t6.CenterNumber left join Day1PhysicalExamination as t7 on t6.ScreeningID=t7.ScreeningID and t6.CenterNumber=t7.CenterNumber left join InclusionCriteria as t8 on t7.ScreeningID=t8.ScreeningID and t7.CenterNumber=t8.CenterNumber left join ExclusionCriteria as t9 on t8.ScreeningID=t9.ScreeningID and t8.CenterNumber=t9.CenterNo left join Day1SubjectEnrolment as t10 on t9.ScreeningID=t10.ScreeningID and t9.CenterNo=t10.CenterNumber left join Day1VACCINATIONBLOODSAMPLING as t11 on t10.ScreeningID=t11.ScreeningID and t10.CenterNumber=t11.CenterNumber left join Day1STUDYVACCINEADMINISTRATION as t12 on t11.ScreeningID=t12.ScreeningID and t11.CenterNumber=t12.CenterNumber left join tblSOLICITEDADVERSE as t13 on t12.ScreeningID=t13.ScreeningID and t12.CenterNumber=t13.CenterNumber left join tblUNSOLICITEDADVERSE as t14 on t13.ScreeningID=t14.ScreeningID and t13.CenterNumber=t14.CenterNumber left join Day1SubjectDiaryCard as t15 on t14.ScreeningID=t15.ScreeningID and t14.CenterNumber=t15.CenterNumber left join tblConModDay1 as t16 on t15.ScreeningID=t16.ScreeningID and t15.CenterNumber =t16.CenterNumber left join Visit2VITALEXAMINATION as t17 on t16.ScreeningID=t17.ScreeningID and t16.CenterNumber=t17.CenterNumber left join Visit2PhysicalExamination as t18 on t17.ScreeningID=t18.ScreeningID and t17.CenterNumber=t18.CenterNumber left join Visit2VACCINATIONBLOODSAMPLING as t19 on t18.ScreeningID=t19.ScreeningID and t18.CenterNumber=t19.CenterNumber left join Visit2ADVERSEEVENTSBETWEEN as t20 on t19.ScreeningID=t20.ScreeningID and t19.CenterNumber=t20.CenterNumber left join Visit2HOSPITALIZATIONRecord as t21 on t20.ScreeningID=t21.ScreeningID and t20.CenterNumber=t21.CenterNumber left join tblConModDay1 as t22 on t21.ScreeningID=t22.ScreeningID and t21.CenterNumber=t22.CenterNumber left join tblEndofStudy as t23 on t22.ScreeningID=t23.ScreeningID and t22.CenterNumber=t23.CenterNumber left join  tblAssentForm as t24 on t24.ScreeningID=t2.ScreeningID and t1.CenterNumber=t24.CenterNumber  where t1.[CenterNumber] ='" + DropDownList1.SelectedValue + "' and t1.[ScreeningID]='" + DropDownList2.SelectedValue + "' and t1.[SubjectInitial]='" + TextBox2.Text + "'", con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                if ((dt.Rows[0]["VISIT-1-Informed Consent"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Informed Consent page is not Locked";

                }
                else if ((dt.Rows[0]["VISIT-1-ASSENT FORM"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "ASSENT FORM (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-Demography"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Demography (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-Medical History"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Medical History page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-ONGOING MEDICATION DETAILS"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "ONGOING MEDICATION DETAILS page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-VACCINATION HISTORY"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "VACCINATION HISTORY page (Day 1) is not Locked";
                }

                else if ((dt.Rows[0]["VISIT-1-GENERAL AND VITAL EXAMINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "GENERAL AND VITAL EXAMINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-PHYSICAL AND SYSTEMIC EXAMINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "PHYSICAL AND SYSTEMIC EXAMINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-Inclusion Criteria"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Inclusion Criteria page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-Exclusion Criteria"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Exclusion Criteria page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-SUBJECT ENROLLMENT"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "SUBJECT ENROLLMENT page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-STUDY VACCINE ADMINISTRATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "STUDY VACCINE ADMINISTRATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-SOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "SOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-UNSOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "UNSOLICITED Adverse EventS: UPTO 30 MINS TO 60 MINS AFTER VACCINATION page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-1-SUBJECT DIARY CARD"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "SUBJECT DIARY CARD page (Day 1) is not Locked";
                }

                else if ((dt.Rows[0]["VISIT-1-Concomitant Medication"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Concomitant Medication page (Day 1) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-GENERAL AND VITAL EXAMINATION"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "GENERAL AND VITAL EXAMINATION page (visit 2) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-PHYSICAL AND SYSTEMIC EXAMINATION"].ToString() != "Locked"))
                {
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "PHYSICAL AND SYSTEMIC EXAMINATION page (visit 2) is not Locked";
                    Panel2.Visible = false;
                }
                else if ((dt.Rows[0]["VISIT-2-POST-VACCINATION BLOOD SAMPLING"].ToString() != "Locked"))
                {
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "POST-VACCINATION BLOOD SAMPLING page (Visit 2) is not Locked";
                    Panel2.Visible = false;
                }
                else if ((dt.Rows[0]["VISIT-2-Adverse EventS BETWEEN Day 1 AND 2 AS MENTIONED ON DIARY CARD (BOTH SOLICITED & UNSOLICITED)"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Adverse EventS BETWEEN Day 1 AND 2 AS MENTIONED ON DIARY CARD (BOTH SOLICITED & UNSOLICITED) page (Visit 2) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-HOSPITALIZATION Record"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "HOSPITALIZATION Record page (Visit 2)  is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-Concomitant Medication"].ToString() != "Locked"))
                {
                    Panel2.Visible = false;
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "Concomitant Medication page (Visit 2) is not Locked";
                }
                else if ((dt.Rows[0]["VISIT-2-END OF STUDY"].ToString() != "Locked"))
                {
                    LabelSublock.Visible = true;
                    LabelSublock.Text = "END OF STUDY page (Visit 2) is not Locked";
                    Panel2.Visible = false;
                }
                else
                {
                    Panel2.Visible = true;
                    LabelSublock.Visible = false;
                }

            }
            else
            {

            }

            con.Close();
        }

    }
    public void OnConfirm(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "I Accept")
        {
            con.Close();
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand sqlCmd = new SqlCommand(
                "SELECT UserRole FROM [dbo].[tbl_UserLogin] WHERE [LoginID] = @LoginID AND [Password] = @Password",
                con);
            sqlCmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 250).Value = txtUsername.Text.Trim();
            sqlCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = Encrypt(txtPassword.Text.Trim());
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UserRole"].ToString() == "Investigator")
                {
                    con.Close();
                    cmd = new SqlCommand("sp_SubjectLockOneByOne", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CenterNumber", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@ScreeningID", DropDownList2.SelectedValue);
                    cmd.Parameters.AddWithValue("@SubInitial", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@AgeGroup", RadioButtonList2.SelectedValue);

                    cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);
                    cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                    cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        ShowMessage("Subject locked successfully", MessageType.Success);

                    }
                }
                else
                {
                    dvMessage.Visible = true;
                    lblMessage.Text = "Username and/or password is incorrect.";
                    ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
                }
            }

            else
            {
                dvMessage.Visible = true;
                lblMessage.Text = "Username and/or password is incorrect.";
                ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
            }
        }
        else
        {
            dvMessage.Visible = true;
            lblMessage.Text = "Please Click on I Accept";
            ClientScript.RegisterStartupScript(this.GetType(), "JS", "$(function () { $('#LoginModal').modal('show'); });", true);
        }


    }
    private string Encrypt(string clearText)
    {
        string EncryptionKey = ConfigurationManager.AppSettings["LegacyPasswordEncryptionKey"];
        if (string.IsNullOrWhiteSpace(EncryptionKey))
        {
            throw new ConfigurationErrorsException("LegacyPasswordEncryptionKey is not configured.");
        }
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
}
