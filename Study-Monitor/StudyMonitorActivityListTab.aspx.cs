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
using AjaxControlToolkit;

public partial class MasterPage_StudyMonitorActivityListTab : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
   (ConfigurationManager.ConnectionStrings["constr"].ToString());
    DataSet ds = new DataSet();

    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {

        lblCenterNumber.Text = Request.QueryString[0];
        lblScreeningNo.Text = Request.QueryString[1];
        lblSubjectInitial.Text = Request.QueryString[2];

        if (!IsPostBack)
        {

            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserRoles"])))
            {
                if (Session["UserRoles"].ToString() == "Principal Investigator")
                {
                    Visit1PI.Visible = true;
                    Visit2PI.Visible = true;
                    Visit3PI.Visible = true;
                    Visit4PI.Visible = true;
                    MHRPI.Visible = true;
                    CMRPI.Visible = true;
                    AEAENPI.Visible = true;
                    SCPI.Visible = true;
                }
                else
                {
                    Visit1PI.Visible = false;
                    Visit2PI.Visible = false;
                    Visit3PI.Visible = false;
                    Visit4PI.Visible = false;
                    MHRPI.Visible = false;
                    CMRPI.Visible = false;
                    AEAENPI.Visible = false;
                    SCPI.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }


        }
        #region QueryImage
        V1InformedConsentAndBaselineDemographics();
        V1InformedConsentAndBaselineDemographicsPI();
        V1EligibilityCriteria();
        V1EligibilityCriteriaPI();
        V1PatientPresentationSymptomsAndSigns();
        V1PatientPresentationSymptomsAndSignsPI();
        V1VitalSignAndPhysicalExamination();
        V1VitalSignAndPhysicalExaminationPI();
        V1RiskFactorAssessment();
        V1RiskFactorAssessmentPI();
        V1MedicalAndSurgicalHistory();
        V1MedicalAndSurgicalHistoryPI();
        V1MedicalHistory();
        V1MedicalHistoryPI();
        V1LaboratoryInvertigations();
        V1LaboratoryInvertigationsPI();
        V1ECG();
        V1ECGPI();
        V1Echocardiography();
        V1EchocardiographyPI();
        V1TypeOfHeartFailureAndNYHAClass();
        V1TypeOfHeartFailureAndNYHAClassPI();
        V1EtilogyOfHF();
        V1EtilogyOfHFPI();
        V1Medication();
        V1MedicationPI();
        V1InHospitalOutcome();
        V1InHospitalOutcomePI();

        V2FollowUp();
        V2FollowUpPI();
        V2PatientPresentationSymptomsAndSigns();
        V2PatientPresentationSymptomsAndSignsPI();
        V2NYHACLASS();
        V2NYHACLASSPI();
        V2ECG();
        V2ECGPI();
        V1NTproBNP();
        V1NTproBNPPI();
        V2Echocardiography();
        V2EchocardiographyPI();
        V2LaboratoryInvertigations();
        V2LaboratoryInvertigationsPI();
        V2Medication();
        V2MedicationPI();
        V2ProceduresPerformed();
        V2ProceduresPerformedPI();
        V2MedicationAdherence();
        V2MedicationAdherencePI();
        V2CompositeOutcomes();
        V2CompositeOutcomesPI();
        V2AdverseEvent();
        V2AdverseEventPI();

        V3FollowUp();
        V3FollowUpPI();
        V3PatientPresentationSymptomsAndSigns();
        V3PatientPresentationSymptomsAndSignsPI();
        V3NYHACLASS();
        V3NYHACLASSPI();
        V3ECG();
        V3ECGPI();
        V3Echocardiography();
        V3EchocardiographyPI();
        V3LaboratoryInvertigations();
        V3LaboratoryInvertigationsPI();
        V3Medication();
        V3MedicationPI();
        V3ProceduresPerformed();
        V3ProceduresPerformedPI();
        V3MedicationAdherence();
        V3MedicationAdherencePI();
        V3CompositeOutcomes();
        V3CompositeOutcomesPI();
        V3AdverseEvent();
        V3AdverseEventPI();

        V4FollowUp();
        V4FollowUpPI();
        V4PatientPresentationSymptomsAndSigns();
        V4PatientPresentationSymptomsAndSignsPI();
        V4NYHACLASS();
        V4NYHACLASSPI();
        V4ECG();
        V4ECGPI();
        V4Echocardiography();
        V4EchocardiographyPI();
        V4LaboratoryInvertigations();
        V4LaboratoryInvertigationsPI();
        V4Medication();
        V4MedicationPI();
        V4ProceduresPerformed();
        V4ProceduresPerformedPI();
        V4MedicationAdherence();
        V4MedicationAdherencePI();
        V4CompositeOutcomes();
        V4CompositeOutcomesPI();
        V4AdverseEvent();
        V4AdverseEventPI();

        BindGridViewMHR();
        BindGridViewCMR();
        BindGridViewAEAEN();
        StudyCompletionForm();
        StudyCompletionFormPI();

        fetchShowHide();
        #endregion

        //MedicalHistory();

        if (Request.QueryString[3].ToString() != "")
        {

            if (Request.QueryString[3].ToString() == "Visit 1")
            {
                TabContainer1.ActiveTabIndex = 0;
            }
            if (Request.QueryString[3].ToString() == "Visit 2")
            {
                TabContainer1.ActiveTabIndex = 1;
            }
            if (Request.QueryString[3].ToString() == "Visit 3")
            {
                TabContainer1.ActiveTabIndex = 2;
            }
            if (Request.QueryString[3].ToString() == "Visit Unscheduled")
            {
                TabContainer1.ActiveTabIndex = 3;
            }
            if (Request.QueryString[3].ToString() == "Medical History")
            {
                TabContainer1.ActiveTabIndex = 4;
            }
            if (Request.QueryString[3].ToString() == "Concomitant Medication")
            {
                TabContainer1.ActiveTabIndex = 5;
            }
            if (Request.QueryString[3].ToString() == "Adverse Event")
            {
                TabContainer1.ActiveTabIndex = 6;
            }
            if (Request.QueryString[3].ToString() == "Withdrawal Form")
            {
                TabContainer1.ActiveTabIndex = 7;
            }
        }

    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    #region Custom Functions

    private void fetchShowHide()
    {
        con.Close();
        DataTable dt = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT CASE WHEN  t1.IN1Question = 'Yes' and t1.IN2Question = 'Yes' and t1.IN3Question = 'Yes' and t1.EC1Question = 'No' and t1.EC2Question = 'No' and t1.EC3Question = 'No' THEN 'True' ELSE 'False' END AS 'IncSubAge' FROM [Visit1].[EligibilityCriteria] AS t1 where t1.SITENUM='" + Request.QueryString["a"] + "' and t1.SUBNUM='" + Request.QueryString["b"] + "' and t1.SUBINI='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToBoolean(dt.Rows[0]["IncSubAge"]) == true)
            {
                TabContainer1.Tabs[1].Enabled = true;
                TabPanelVisit2.Enabled = true;
                TabPanelVisit3.Enabled = true;
                TabPanelVisit4.Enabled = true;
            }
            else
            {
                TabContainer1.Tabs[1].Enabled = false;
                TabPanelVisit2.Enabled = false;
                TabPanelVisit3.Enabled = false;
                TabPanelVisit4.Enabled = false;
            }
        }
        con.Close();
    }
    //protected void MedicalHistory()
    //{
    //    con.Close();
    //    con.Open();
    //    DataTable dt1 = new DataTable();
    //    SqlCommand sqlCmd1 = new SqlCommand("SELECT MHYN,EntryStatus FROM [Visit1].[MedicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
    //    SqlDataAdapter sqlDa1 = new SqlDataAdapter(sqlCmd1);
    //    sqlDa1.Fill(dt1);
    //    if (dt1.Rows.Count > 0)
    //    {

    //        string history = dt1.Rows[0]["MHYN"].ToString();
    //        string Status = dt1.Rows[0]["EntryStatus"].ToString();
    //        if (history == "Yes" && Status == "Submit")
    //        {
    //            TabPanelMHR.Enabled = true;
    //        }
    //        else if (history == "No")
    //        {
    //            TabPanelMHR.Enabled = false;
    //        }


    //    }
    //    con.Close();
    //}
    #endregion

    #region Visit 1 All Image Binding Data
    private void V1InformedConsentAndBaselineDemographics()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[InformedConsentAndBaselineDemographics] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1ICDB.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1ICDB.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1ICDB.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1ICDB.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1ICDB.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1ICDB.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1ICDB.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1InformedConsentAndBaselineDemographicsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Informed Consent And Baseline Demographics'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1ICDBPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1ICDBPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1ICDBPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1EligibilityCriteria()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[EligibilityCriteria] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1ELCR.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1ELCR.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1ELCR.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1ELCR.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1ELCR.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1ELCR.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1ELCR.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1EligibilityCriteriaPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Eligibility Criteria'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1ELCRPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1ELCRPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1ELCRPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1PatientPresentationSymptomsAndSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[PatientPresentationSymptomsAndSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1PPSAS.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1PPSAS.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1PPSAS.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1PPSAS.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1PPSAS.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1PatientPresentationSymptomsAndSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Patient Presentation (Symptoms And Signs)'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1PPSASPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1VitalSignAndPhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[VitalSignAndPhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1VSPE.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1VSPE.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1VSPE.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1VSPE.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1VSPE.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1VSPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1VSPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1VitalSignAndPhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Vital Sign And Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1VSPEPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1VSPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1VSPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1RiskFactorAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[RiskFactorAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1RFA.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1RFA.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1RFA.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1RFA.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1RFA.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1RFA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1RFA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1RiskFactorAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Risk Factor Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1RFAPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1RFAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1RFAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1MedicalAndSurgicalHistory()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[MedicalAndSurgicalHistory] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1MSH.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1MSH.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1MSH.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1MSH.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1MSH.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1MSH.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1MSH.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1MedicalAndSurgicalHistoryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Medical And Surgical History'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1MSHPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1MSHPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1MSHPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1MedicalHistory()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[MedicalHistory] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1MEHI.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1MEHI.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1MEHI.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1MEHI.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1MEHI.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1MEHI.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1MEHI.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1MedicalHistoryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Medical History'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1MEHIPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1MEHIPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1MEHIPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1LaboratoryInvertigations()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[LaboratoryInvertigations] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1LAIN.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1LAIN.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1LAIN.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1LAIN.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1LAIN.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1LaboratoryInvertigationsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Laboratory Investigations'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1LAINPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1EG.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1EG.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1EG.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1EG.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1EG.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1EGPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1NTproBNP()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[NTproBNP] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1NTPB.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1NTPB.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1NTPB.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1NTPB.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1NTPB.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1NTPB.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1NTPB.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1NTproBNPPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='NTproBNP'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1NTPBPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1NTPBPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1NTPBPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1Echocardiography()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[Echocardiography] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1ECHY.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1ECHY.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1ECHY.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1ECHY.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1ECHY.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1EchocardiographyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Echocardiography'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1ECHYPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1TypeOfHeartFailureAndNYHAClass()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[TypeOfHeartFailureAndNYHAClass] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1THFNYC.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1THFNYC.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1THFNYC.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1THFNYC.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1THFNYC.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1THFNYC.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1THFNYC.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1TypeOfHeartFailureAndNYHAClassPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Type Of Heart Failure And NYHA Class'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1THFNYCPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1THFNYCPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1THFNYCPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1EtilogyOfHF()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[EtilogyOfHF] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1EOF.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1EOF.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1EOF.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1EOF.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1EOF.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1EOF.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1EOF.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1EtilogyOfHFPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Etilogy Of HF'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1EOFPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1EOFPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1EOFPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1Medication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[Medication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1MEDICA.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1MEDICA.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1MEDICA.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1MEDICA.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1MEDICA.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1MedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1MEDICAPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1InHospitalOutcome()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[InHospitalOutcome] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1IHO.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1IHO.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1IHO.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1IHO.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1IHO.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV1IHO.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1IHO.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1InHospitalOutcomePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Date Of Patient Visit And ICF'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1IHOPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1IHOPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1IHOPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 2 All Image Binding Data
    private void V2FollowUp()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[FollowUp] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2FOUP.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2FOUP.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2FOUP.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2FOUP.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2FOUP.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2FOUP.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2FOUP.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2FollowUpPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Follow-Up'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2FOUPPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2FOUPPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2FOUPPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2PatientPresentationSymptomsAndSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[PatientPresentationSymptomsAndSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2PPSAS.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2PPSAS.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2PPSAS.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2PPSAS.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2PPSAS.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2PatientPresentationSymptomsAndSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Patient Presentation (Symptoms And Signs)'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2PPSASPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2NYHACLASS()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[NYHACLASS] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2NCL.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2NCL.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2NCL.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2NCL.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2NCL.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2NCL.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2NCL.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2NYHACLASSPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='NYHA Class'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2NCLPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2NCLPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2NCLPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2EG.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2EG.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2EG.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2EG.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2EG.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2EGPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2Echocardiography()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[Echocardiography] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2ECHY.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2ECHY.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2ECHY.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2ECHY.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2ECHY.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2EchocardiographyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Echocardiography'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2ECHYPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2LaboratoryInvertigations()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[LaboratoryInvertigations] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2LAIN.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2LAIN.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2LAIN.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2LAIN.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2LAIN.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2LaboratoryInvertigationsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Laboratory Investigations'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2LAINPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2Medication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[Medication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2MEDICA.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2MEDICA.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2MEDICA.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2MEDICA.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2MEDICA.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2MedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2MEDICAPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2ProceduresPerformed()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[ProceduresPerformed] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2PRPE.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2PRPE.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2PRPE.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2PRPE.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2PRPE.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2PRPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2PRPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2ProceduresPerformedPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Procedures Performed'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2PRPEPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2PRPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2PRPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2MedicationAdherence()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[MedicationAdherence] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2MEAD.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2MEAD.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2MEAD.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2MEAD.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2MEAD.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2MEAD.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2MEAD.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2MedicationAdherencePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Medication Adherence'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2MEADPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2MEADPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2MEADPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2CompositeOutcomes()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[CompositeOutcomes] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2COOU.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2COOU.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2COOU.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2COOU.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2COOU.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2COOU.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2COOU.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2CompositeOutcomesPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Composite Outcomes'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2COOUPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2COOUPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2COOUPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2AdverseEvent()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[AdverseEvent] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 2'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2AE.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2AE.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2AE.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2AE.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2AE.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV2AE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2AE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2AdverseEventPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Adverse Event'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2AEPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2AEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2AEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 3 All Image Binding Data
    private void V3FollowUp()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[FollowUp] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3FOUP.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3FOUP.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3FOUP.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3FOUP.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3FOUP.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3FOUP.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3FOUP.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3FollowUpPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Follow-Up'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3FOUPPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3FOUPPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3FOUPPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3PatientPresentationSymptomsAndSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[PatientPresentationSymptomsAndSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3PPSAS.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3PPSAS.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3PPSAS.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3PPSAS.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3PPSAS.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3PatientPresentationSymptomsAndSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Patient Presentation (Symptoms And Signs)'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3PPSASPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3NYHACLASS()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[NYHACLASS] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3NCL.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3NCL.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3NCL.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3NCL.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3NCL.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3NCL.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3NCL.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3NYHACLASSPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='NYHA Class'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3NCLPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3NCLPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3NCLPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3EG.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3EG.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3EG.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3EG.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3EG.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3EGPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3Echocardiography()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[Echocardiography] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3ECHY.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3ECHY.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3ECHY.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3ECHY.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3ECHY.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3EchocardiographyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Echocardiography'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3ECHYPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3LaboratoryInvertigations()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[LaboratoryInvertigations] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3LAIN.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3LAIN.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3LAIN.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3LAIN.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3LAIN.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3LaboratoryInvertigationsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Laboratory Investigations'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3LAINPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3Medication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[Medication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3MEDICA.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3MEDICA.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3MEDICA.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3MEDICA.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3MEDICA.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3MedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3MEDICAPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3ProceduresPerformed()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[ProceduresPerformed] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3PRPE.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3PRPE.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3PRPE.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3PRPE.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3PRPE.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3PRPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3PRPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3ProceduresPerformedPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Procedures Performed'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3PRPEPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3PRPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3PRPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3MedicationAdherence()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[MedicationAdherence] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3MEAD.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3MEAD.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3MEAD.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3MEAD.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3MEAD.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3MEAD.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3MEAD.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3MedicationAdherencePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Medication Adherence'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3MEADPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3MEADPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3MEADPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3CompositeOutcomes()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[CompositeOutcomes] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3COOU.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3COOU.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3COOU.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3COOU.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3COOU.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3COOU.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3COOU.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3CompositeOutcomesPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Composite Outcomes'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3COOUPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3COOUPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3COOUPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3AdverseEvent()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[AdverseEvent] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit 3'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3AE.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3AE.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3AE.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3AE.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3AE.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV3AE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3AE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3AdverseEventPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Adverse Event'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3AEPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3AEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3AEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit Unscheduled All Image Binding Data
    private void V4FollowUp()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[FollowUp] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4FOUP.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4FOUP.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4FOUP.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4FOUP.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4FOUP.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4FOUP.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4FOUP.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4FollowUpPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Follow-Up'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4FOUPPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4FOUPPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4FOUPPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4PatientPresentationSymptomsAndSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[PatientPresentationSymptomsAndSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4PPSAS.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4PPSAS.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4PPSAS.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4PPSAS.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4PPSAS.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4PPSAS.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4PatientPresentationSymptomsAndSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Patient Presentation (Symptoms And Signs)'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4PPSASPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4PPSASPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4NYHACLASS()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[NYHACLASS] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4NCL.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4NCL.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4NCL.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4NCL.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4NCL.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4NCL.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4NCL.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4NYHACLASSPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='NYHA Class'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4NCLPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4NCLPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4NCLPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4EG.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4EG.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4EG.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4EG.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4EG.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4EG.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4EGPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4EGPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4Echocardiography()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[Echocardiography] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4ECHY.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4ECHY.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4ECHY.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4ECHY.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4ECHY.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4ECHY.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4EchocardiographyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Echocardiography'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4ECHYPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4ECHYPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4LaboratoryInvertigations()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[LaboratoryInvertigations] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4LAIN.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4LAIN.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4LAIN.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4LAIN.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4LAIN.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4LAIN.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4LaboratoryInvertigationsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Laboratory Investigations'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4LAINPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4LAINPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4Medication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[Medication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4MEDICA.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4MEDICA.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4MEDICA.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4MEDICA.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4MEDICA.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4MEDICA.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4MedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4MEDICAPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4MEDICAPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4ProceduresPerformed()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[ProceduresPerformed] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4PRPE.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4PRPE.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4PRPE.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4PRPE.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4PRPE.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4PRPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4PRPE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4ProceduresPerformedPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Procedures Performed'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4PRPEPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4PRPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4PRPEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4MedicationAdherence()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[MedicationAdherence] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4MEAD.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4MEAD.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4MEAD.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4MEAD.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4MEAD.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4MEAD.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4MEAD.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4MedicationAdherencePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Medication Adherence'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4MEADPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4MEADPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4MEADPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4CompositeOutcomes()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[CompositeOutcomes] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4COOU.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4COOU.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4COOU.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4COOU.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4COOU.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4COOU.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4COOU.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4CompositeOutcomesPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Composite Outcomes'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4COOUPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4COOUPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4COOUPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4AdverseEvent()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[AdverseEvent] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and [FUVSTNM]='Visit Unscheduled'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4AE.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4AE.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4AE.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4AE.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4AE.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonV4AE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4AE.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4AdverseEventPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit Unscheduled' and PAGENAME='Adverse Event'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4AEPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4AEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4AEPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    private void StudyCompletionForm()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Add].[StudyCompletionForm] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonSCTF.ImageUrl = "~/Study-Monitor/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonSCTF.ImageUrl = "~/Study-Monitor/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonSCTF.ImageUrl = "~/Study-Monitor/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonSCTF.ImageUrl = "~/Study-Monitor/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonSCTF.ImageUrl = "~/Study-Monitor/Images/SDV.png";
            }
            else
            {
                ImageButtonSCTF.ImageUrl = "~/Study-Monitor/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonSCTF.ImageUrl = "~/Study-Monitor/Images/Blank.png";
        }


        dr.Close();

        con.Close();
    }
    private void StudyCompletionFormPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Withdrawal Form' and PAGENAME='Study Completion/Early Termination Form'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonSCTFPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonSCTFPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonSCTFPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }

    #region Visit 1
    protected void ImageButtonV1ICDB_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1ICDB.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InformedConsentAndBaselineDemographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ICDB.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1ICDB.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InformedConsentAndBaselineDemographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ICDB.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InformedConsentAndBaselineDemographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ICDB.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InformedConsentAndBaselineDemographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1ELCR_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1ELCR.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ELCR.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1ELCR.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ELCR.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ELCR.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1PPSAS_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1PPSAS.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1PPSAS.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1PPSAS.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1PPSAS.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1PPSAS.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1VSPE_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1VSPE.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/VitalSignAndPhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1VSPE.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1VSPE.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/VitalSignAndPhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1VSPE.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/VitalSignAndPhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1VSPE.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/VitalSignAndPhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1RFA_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1RFA.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/RiskFactorAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1RFA.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1RFA.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/RiskFactorAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1RFA.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/RiskFactorAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1RFA.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/RiskFactorAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1MSH_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1MSH.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicalAndSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MSH.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1MSH.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicalAndSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MSH.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicalAndSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MSH.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicalAndSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1MEHI_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1MEHI.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicationHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MEHI.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1MEHI.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicationHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MEHI.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicationHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MEHI.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/MedicationHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1LAIN_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1LAIN.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1LAIN.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1LAIN.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1LAIN.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1LAIN.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1EG_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1EG.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1EG.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1EG.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1EG.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1EG.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1NTPB_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1NTPB.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/NTproBNP.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1NTPB.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1NTPB.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/NTproBNP.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1NTPB.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/NTproBNP.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1NTPB.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/NTproBNP.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1ECHY_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1ECHY.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ECHY.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1ECHY.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ECHY.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1ECHY.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1THFNYC_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1THFNYC.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/TypeOfHeartFailureAndNYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1THFNYC.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1THFNYC.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/TypeOfHeartFailureAndNYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1THFNYC.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/TypeOfHeartFailureAndNYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1THFNYC.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/TypeOfHeartFailureAndNYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1EOF_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1EOF.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EtilogyOfHF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1EOF.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1EOF.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EtilogyOfHF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1EOF.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EtilogyOfHF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1EOF.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/EtilogyOfHF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1MEDICA_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1MEDICA.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MEDICA.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1MEDICA.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MEDICA.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1MEDICA.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV1IHO_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1IHO.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InHospitalOutcome.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1IHO.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV1IHO.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InHospitalOutcome.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1IHO.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InHospitalOutcome.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1IHO.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit1/InHospitalOutcome.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    #endregion
    #region Visit 2
    protected void ImageButtonV2FOUP_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2FOUP.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2FOUP.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2FOUP.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2FOUP.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2FOUP.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2PPSAS_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2PPSAS.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2PPSAS.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2PPSAS.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2PPSAS.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2PPSAS.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2NCL_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2NCL.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2NCL.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2NCL.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2NCL.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2NCL.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2EG_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2EG.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2EG.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2EG.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2EG.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2EG.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2ECHY_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2ECHY.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2ECHY.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2ECHY.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2ECHY.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2ECHY.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2LAIN_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2LAIN.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2LAIN.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2LAIN.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2LAIN.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2LAIN.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2MEDICA_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2MEDICA.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2MEDICA.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2MEDICA.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2MEDICA.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2MEDICA.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2PRPE_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2PRPE.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2PRPE.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2PRPE.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2PRPE.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2PRPE.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2MEAD_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2MEAD.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2MEAD.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2MEAD.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2MEAD.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2MEAD.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2COOU_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2COOU.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2COOU.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2COOU.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2COOU.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2COOU.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV2AE_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2AE.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2AE.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV2AE.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2AE.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2AE.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit2/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    #endregion
    #region Visit 3
    protected void ImageButtonV3FOUP_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3FOUP.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3FOUP.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3FOUP.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3FOUP.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3FOUP.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3PPSAS_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3PPSAS.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3PPSAS.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3PPSAS.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3PPSAS.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3PPSAS.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3NCL_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3NCL.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3NCL.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3NCL.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3NCL.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3NCL.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3EG_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3EG.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3EG.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3EG.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3EG.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3EG.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3ECHY_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3ECHY.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3ECHY.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3ECHY.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3ECHY.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3ECHY.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3LAIN_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3LAIN.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3LAIN.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3LAIN.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3LAIN.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3LAIN.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3MEDICA_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3MEDICA.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3MEDICA.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3MEDICA.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3MEDICA.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3MEDICA.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3PRPE_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3PRPE.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3PRPE.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3PRPE.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3PRPE.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3PRPE.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3MEAD_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3MEAD.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3MEAD.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3MEAD.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3MEAD.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3MEAD.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3COOU_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3COOU.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3COOU.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3COOU.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3COOU.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3COOU.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV3AE_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3AE.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3AE.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV3AE.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3AE.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3AE.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Visit3/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    #endregion
    #region Visit Unscheduled
    protected void ImageButtonV4FOUP_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4FOUP.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4FOUP.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4FOUP.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4FOUP.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4FOUP.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/FollowUp.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4PPSAS_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4PPSAS.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4PPSAS.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4PPSAS.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4PPSAS.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4PPSAS.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/PatientPresentationSymptomsAndSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4NCL_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4NCL.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4NCL.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4NCL.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4NCL.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4NCL.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/NYHAClass.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4EG_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4EG.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4EG.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4EG.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4EG.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4EG.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4ECHY_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4ECHY.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4ECHY.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4ECHY.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4ECHY.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4ECHY.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Echocardiography.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4LAIN_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4LAIN.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4LAIN.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4LAIN.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4LAIN.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4LAIN.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/LaboratoryInvertigations.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4MEDICA_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4MEDICA.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4MEDICA.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4MEDICA.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4MEDICA.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4MEDICA.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/Medication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4PRPE_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4PRPE.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4PRPE.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4PRPE.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4PRPE.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4PRPE.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/ProceduresPerformed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4MEAD_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4MEAD.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4MEAD.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4MEAD.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4MEAD.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4MEAD.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/MedicationAdherence.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4COOU_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4COOU.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4COOU.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4COOU.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4COOU.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4COOU.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/CompositeOutcomes.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    protected void ImageButtonV4AE_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4AE.ImageUrl == "~/Study-Monitor/Images/Submit.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4AE.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }
        else if (ImageButtonV4AE.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4AE.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4AE.ImageUrl == "~/Study-Monitor/Images/SDV.png")
        {
            Response.Redirect("~/Study-Monitor/Unscheduled/AdverseEvent.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }
    }
    #endregion

    #region MHR
    private void BindGridViewMHR()
    {
        DataSet ds = new DataSet();

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [MSHSNO] , [QueryStatus],[LockStatus],[EntryStatus] FROM [Add].[MedicalHistoryRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            GridViewMHR.DataSource = ds;
            GridViewMHR.DataBind();
        }
    }

    protected void GridViewMHR_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Literal litActualMHR = (Literal)e.Row.FindControl("litActualMHR");
            var link2 = (HyperLink)e.Row.FindControl("HyperLinkMHR");
            string EntryStatus = ((DataRowView)e.Row.DataItem)["EntryStatus"].ToString();
            string LockStatus = ((DataRowView)e.Row.DataItem)["LockStatus"].ToString();
            string QueryStatus = ((DataRowView)e.Row.DataItem)["QueryStatus"].ToString();

            if (EntryStatus == "Save" && LockStatus != "Locked")
            {
                litActualMHR.Text += "<img id='Image3' src='/Study-Monitor/Images/Edit.png' alt='' height='40' width='40' />";

            }

            else if (EntryStatus == "Submit" && (LockStatus != "Locked" && LockStatus != "SDV") && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualMHR.Text += "<img id='Image3' src='/Study-Monitor/Images/Submit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/MedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["MSHSNO"].ToString();
            }
            else if (EntryStatus == "Submit" && LockStatus == "SDV" && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualMHR.Text += "<img id='Image3' src='/Study-Monitor/Images/SDV.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/MedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["MSHSNO"].ToString();

            }

            else if (EntryStatus == "Submit" && LockStatus != "Locked" && (QueryStatus == "Open" || QueryStatus == "Query Responded" || QueryStatus != "Query Closed"))
            {
                litActualMHR.Text += "<img id='Image3' src='/Study-Monitor/Images/Query.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/MedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["MSHSNO"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "Locked")
            {

                litActualMHR.Text += "<img id='Image3' src='/Study-Monitor/Images/DataLock.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/MedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["MSHSNO"].ToString();

            }
            else
            {
            }


            Image ImageButtonMedicalHistoryPI = e.Row.FindControl("ImageButtonMedicalHistoryPI") as Image;
            con.Close();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [SNO], [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and EntryStatus='Submit' and VISIT='Medical History' and PAGENAME='Medical History Record' and SNO ='" + ((DataRowView)e.Row.DataItem)["MSHSNO"].ToString() + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if ((dr["PISIGN"].ToString() == "True"))
                {
                    ImageButtonMedicalHistoryPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

                }
                else
                {
                    ImageButtonMedicalHistoryPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
                }


            }
            else
            {
                ImageButtonMedicalHistoryPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


            dr.Close();

            con.Close();

        }
    }


    protected void ButtonMHR_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Study-Monitor/AdVisit/MedicalHistoryDataEntry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

    }
    #endregion
    #region CMR
    private void BindGridViewCMR()
    {
        DataSet ds = new DataSet();

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [ConMedNo], [QueryStatus],[LockStatus],[EntryStatus] FROM [Add].[ConmedRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            GridViewCMR.DataSource = ds;
            GridViewCMR.DataBind();
        }
    }

    protected void GridViewCMR_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Literal litActualCMR = (Literal)e.Row.FindControl("litActualCMR");
            var link2 = (HyperLink)e.Row.FindControl("HyperLinkCMR");
            string EntryStatus = ((DataRowView)e.Row.DataItem)["EntryStatus"].ToString();
            string LockStatus = ((DataRowView)e.Row.DataItem)["LockStatus"].ToString();
            string QueryStatus = ((DataRowView)e.Row.DataItem)["QueryStatus"].ToString();

            if (EntryStatus == "Save" && LockStatus != "Locked")
            {
                litActualCMR.Text += "<img id='Image3' src='/Study-Monitor/Images/Edit.png' alt='' height='40' width='40' />";

            }

            else if (EntryStatus == "Submit" && (LockStatus != "Locked" && LockStatus != "SDV") && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualCMR.Text += "<img id='Image3' src='/Study-Monitor/Images/Submit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["ConMedNo"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "SDV" && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualCMR.Text += "<img id='Image3' src='/Study-Monitor/Images/SDV.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["ConMedNo"].ToString();

            }

            else if (EntryStatus == "Submit" && LockStatus != "Locked" && (QueryStatus == "Open" || QueryStatus == "Query Responded" || QueryStatus != "Query Closed"))
            {
                litActualCMR.Text += "<img id='Image3' src='/Study-Monitor/Images/Query.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["ConMedNo"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "Locked")
            {

                litActualCMR.Text += "<img id='Image3' src='/Study-Monitor/Images/DataLock.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["ConMedNo"].ToString();

            }
            else
            {
            }


            Image ImageButtonConMedPI = e.Row.FindControl("ImageButtonConMedPI") as Image;
            con.Close();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [SNO], [PISIGN] FROM [dbo].[tblPISignature]  where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and EntryStatus='Submit' and VISIT='Concomitant Medication' and PAGENAME='Prior/Concomitant Medication Form' and SNO ='" + ((DataRowView)e.Row.DataItem)["ConMedNo"].ToString() + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if ((dr["PISIGN"].ToString() == "True"))
                {
                    ImageButtonConMedPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

                }
                else
                {
                    ImageButtonConMedPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
                }


            }
            else
            {
                ImageButtonConMedPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }


            dr.Close();

            con.Close();

        }
    }


    protected void ButtonCMR_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Study-Monitor/AdVisit/ConcomitantMedicationDataEntry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

    }
    #endregion

    #region AEAEN
    private void BindGridViewAEAEN()
    {
        DataSet ds = new DataSet();

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [AEAEN] ,[QueryStatus],[LockStatus],[EntryStatus] FROM [Add].[AdverseEventRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            GridViewAEAEN.DataSource = ds;
            GridViewAEAEN.DataBind();
        }
    }

    protected void GridViewAEAEN_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Literal litActualAEAEN = (Literal)e.Row.FindControl("litActualAEAEN");
            var link2 = (HyperLink)e.Row.FindControl("HyperLinkAEAEN");
            string EntryStatus = ((DataRowView)e.Row.DataItem)["EntryStatus"].ToString();
            string LockStatus = ((DataRowView)e.Row.DataItem)["LockStatus"].ToString();
            string QueryStatus = ((DataRowView)e.Row.DataItem)["QueryStatus"].ToString();

            if (EntryStatus == "Save" && LockStatus != "Locked")
            {
                litActualAEAEN.Text += "<img id='Image3' src='/Study-Monitor/Images/Edit.png' alt='' height='40' width='40' />";

            }

            else if (EntryStatus == "Submit" && (LockStatus != "Locked" && LockStatus != "SDV") && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualAEAEN.Text += "<img id='Image3' src='/Study-Monitor/Images/Submit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/AdverseEventRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AEAEN"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "SDV" && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualAEAEN.Text += "<img id='Image3' src='/Study-Monitor/Images/SDV.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/AdverseEventRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AEAEN"].ToString();

            }

            else if (EntryStatus == "Submit" && LockStatus != "Locked" && (QueryStatus == "Open" || QueryStatus == "Query Responded" || QueryStatus != "Query Closed"))
            {
                litActualAEAEN.Text += "<img id='Image3' src='/Study-Monitor/Images/Query.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/AdverseEventRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AEAEN"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "Locked")
            {

                litActualAEAEN.Text += "<img id='Image3' src='/Study-Monitor/Images/DataLock.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Study-Monitor/AdVisit/AdverseEventRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AEAEN"].ToString();

            }
            else
            {
            }


            Image ImageButtonAEAENPI = e.Row.FindControl("ImageButtonAEAENPI") as Image;
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [SNO], [PISIGN] FROM [dbo].[tblPISignature]  where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and EntryStatus='Submit' and VISIT='Adverse Event' and PAGENAME='Adverse Event Record' and SNO ='" + ((DataRowView)e.Row.DataItem)["AEAEN"].ToString() + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if ((dr["PISIGN"].ToString() == "True"))
                {
                    ImageButtonAEAENPI.ImageUrl = "~/Study-Monitor/Images/Pisig.PNG";

                }
                else
                {
                    ImageButtonAEAENPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
                }


            }
            else
            {
                ImageButtonAEAENPI.ImageUrl = "~/Study-Monitor/Images/pisin.PNG";
            }
            dr.Close();

            con.Close();

        }
    }


    protected void ButtonAEAEN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Study-Monitor/AdVisit/AdverseEventRecordDataEntry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

    }
    #endregion

    #region Study Completion/Early Termination Form
    protected void ImageButtonSCTF_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonSCTF.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/AdVisit/StudyCompletionForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }

        else if (ImageButtonSCTF.ImageUrl == "~/Study-Monitor/Images/Edit.png")
        {

            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);

        }

        else if (ImageButtonSCTF.ImageUrl == "~/Study-Monitor/Images/Query.png")
        {
            Response.Redirect("~/Study-Monitor/AdVisit/StudyCompletionForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonSCTF.ImageUrl == "~/Study-Monitor/Images/DataLock.png")
        {
            Response.Redirect("~/Study-Monitor/AdVisit/StudyCompletionForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            ShowMessage("You cannot review this page until the page is Submitted !!", MessageType.Warning);
        }

    }

    #endregion

    #region PI Signature
    protected void ImageButtonV1PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/Visit1/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV2PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/Visit2/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV3PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/Visit3/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV4PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/Visit4/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonMHRPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/AdVisit/PiSingMHR.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonCMRPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/AdVisit/PiSingCMR.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonSCPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/AdVisit/PiSingSC.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonAEAENPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Study-Monitor/AdVisit/PiSingAE.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    #endregion
}