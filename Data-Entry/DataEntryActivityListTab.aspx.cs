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

public partial class MasterPage_DataEntryActivityListTab : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
   (ConfigurationManager.ConnectionStrings["constr"].ToString());
    DataSet ds = new DataSet();
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
                    Visit5PI.Visible = true;
                    Visit6PI.Visible = true;
                    Visit7PI.Visible = true;
                    Visit8PI.Visible = true;
                    Visit9PI.Visible = true;
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
                    Visit5PI.Visible = false;
                    Visit6PI.Visible = false;
                    Visit7PI.Visible = false;
                    Visit8PI.Visible = false;
                    Visit9PI.Visible = false;
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
        V1DateOfPatientVisitAndICF();
        V1DateOfPatientVisitAndICFPI();
        V1Demographics();
        V1DemographicsPI();
        V1IndicationDiagnosis();
        V1IndicationDiagnosisPI();
        V1MedicalSurgicalHistory();
        V1MedicalSurgicalHistoryPI();
        V1ConMedForDiagnosed();
        V1ConMedForDiagnosedPI();
        V1ConMedForMedicalHistory();
        V1ConMedForMedicalHistoryPI();
        V1VitalSigns();
        V1VitalSignsPI();
        V1PhysicalExamination();
        V1PhysicalExaminationPI();
        V1ECOGPerformanceStatus();
        V1ECOGPerformanceStatusPI();
        V1EligibilityCriteria();
        V1EligibilityCriteriaPI();
        V1ECG();
        V1ECGPI();
        V1ChestXRay();
        V1ChestXRayPI();
        V1UPTExamination();
        V1UPTExaminationPI();
        V1LabCompleteBloodCount();
        V1LabCompleteBloodCountPI();
        V1LabBiochemistry();
        V1LabBiochemistryPI();
        V1LabUrinalysis();
        V1LabUrinalysisPI();
        V1LabVirologicalTests();
        V1LabVirologicalTestsPI();
        V1LabImmunologicalTests();
        V1LabImmunologicalTestsPI();
        V1Beta_2_Microglobulin();
        V1Beta_2_MicroglobulinPI();
        V1AE_SAE_Assessement();
        V1AE_SAE_AssessementPI();

        V2VisitDate();
        V2VisitDatePI();
        V2VitalSigns();
        V2VitalSignsPI();
        V2PhysicalExamination();
        V2PhysicalExaminationPI();
        V2HRQoL_Questionnaire();
        V2HRQoL_QuestionnairePI();
        V2CTWholeBody();
        V2CTWholeBodyPI();
        V2StudyDrugDispensingRecord();
        V2StudyDrugDispensingRecordPI();
        V2SubjectDiaryDispensing();
        V2SubjectDiaryDispensingPI();
        V2AE_SAE_Assessement();
        V2AE_SAE_AssessementPI();
        V2ConcomitantMedication();
        V2ConcomitantMedicationPI();

        V3VisitDate();
        V3VisitDatePI();
        V3VitalSigns();
        V3VitalSignsPI();
        V3PhysicalExamination();
        V3PhysicalExaminationPI();
        V3ECG();
        V3ECGPI();
        V3ImmunologicalTest();
        V3ImmunologicalTestPI();
        V3StudyDrugDispensingRecord();
        V3StudyDrugDispensingRecordPI();
        V3StudyDrugComplianceRecord();
        V3StudyDrugComplianceRecordPI();
        V3SubjectDiaryReview();
        V3SubjectDiaryReviewPI();
        V3AE_SAE_Assessement();
        V3AE_SAE_AssessementPI();
        V3DiseaseProgressionAssessment();
        V3DiseaseProgressionAssessmentPI();
        V3ConcomitantMedication();
        V3ConcomitantMedicationPI();

        V4VisitDate();
        V4VisitDatePI();
        V4VitalSigns();
        V4VitalSignsPI();
        V4PhysicalExamination();
        V4PhysicalExaminationPI();
        V4ECG();
        V4ECGPI();
        V4ChestXRay();
        V4ChestXRayPI();
        V4LabCompleteBloodCount();
        V4LabCompleteBloodCountPI();
        V4LabBiochemistry();
        V4LabBiochemistryPI();
        V4LabUrinalysis();
        V4LabUrinalysisPI();
        V4LabImmunologicalTests();
        V4LabImmunologicalTestsPI();
        V4StudyDrugDispensingRecord();
        V4StudyDrugDispensingRecordPI();
        V4StudyDrugComplianceRecord();
        V4StudyDrugComplianceRecordPI();
        V4SubjectDiaryDispensing();
        V4SubjectDiaryDispensingPI();
        V4SubjectDiaryReview();
        V4SubjectDiaryReviewPI();
        V4SubjectDiaryRetrieval();
        V4SubjectDiaryRetrievalPI();
        V4ConcomitantMedication();
        V4ConcomitantMedicationPI();
        V4DiseaseProgressionAssessment();
        V4DiseaseProgressionAssessmentPI();
        V4HRQoL_Questionnaire();
        V4HRQoL_QuestionnairePI();
        V4AE_SAE_Assessement();
        V4AE_SAE_AssessementPI();

        V5VisitDate();
        V5VisitDatePI();
        V5VitalSigns();
        V5VitalSignsPI();
        V5PhysicalExamination();
        V5PhysicalExaminationPI();
        V5ECG();
        V5ECGPI();
        V5ChestXRay();
        V5ChestXRayPI();
        V5LabCompleteBloodCount();
        V5LabCompleteBloodCountPI();
        V5LabBiochemistry();
        V5LabBiochemistryPI();
        V5LabUrinalysis();
        V5LabUrinalysisPI();
        V5LabImmunologicalTests();
        V5LabImmunologicalTestsPI();
        V5CTWholeBody();
        V5CTWholeBodyPI();
        V5ResponseCriteria();
        V5ResponseCriteriaPI();
        V5DiseaseProgressionAssessment();
        V5DiseaseProgressionAssessmentPI();
        V5StudyDrugDispensingRecord();
        V5StudyDrugDispensingRecordPI();
        V5StudyDrugComplianceRecord();
        V5StudyDrugComplianceRecordPI();
        V5SubjectDiaryDispensing();
        V5SubjectDiaryDispensingPI();
        V5SubjectDiaryReview();
        V5SubjectDiaryReviewPI();
        V5SubjectDiaryRetrieval();
        V5SubjectDiaryRetrievalPI();
        V5ConcomitantMedication();
        V5ConcomitantMedicationPI();
        V5HRQoL_Questionnaire();
        V5HRQoL_QuestionnairePI();
        V5AE_SAE_Assessement();
        V5AE_SAE_AssessementPI();

        V6VisitDate();
        V6VisitDatePI();
        V6VitalSigns();
        V6VitalSignsPI();
        V6PhysicalExamination();
        V6PhysicalExaminationPI();
        V6ECG();
        V6ECGPI();
        V6StudyDrugDispensingRecord();
        V6StudyDrugDispensingRecordPI();
        V6StudyDrugComplianceRecord();
        V6StudyDrugComplianceRecordPI();
        V6SubjectDiaryDispensing();
        V6SubjectDiaryDispensingPI();
        V6SubjectDiaryReview();
        V6SubjectDiaryReviewPI();
        V6SubjectDiaryRetrieval();
        V6SubjectDiaryRetrievalPI();
        V6ConcomitantMedication();
        V6ConcomitantMedicationPI();
        V6ImmunologicalTest();
        V6ImmunologicalTestPI();
        V6HRQoL_Questionnaire();
        V6HRQoL_QuestionnairePI();
        V6DiseaseProgressionAssessment();
        V6DiseaseProgressionAssessmentPI();
        V6AE_SAE_Assessement();
        V6AE_SAE_AssessementPI();

        V7VisitDate();
        V7VisitDatePI();
        V7VitalSigns();
        V7VitalSignsPI();
        V7PhysicalExamination();
        V7PhysicalExaminationPI();
        V7ECG();
        V7ECGPI();
        V7ChestXRay();
        V7ChestXRayPI();
        V7LabCompleteBloodCount();
        V7LabCompleteBloodCountPI();
        V7LabBiochemistry();
        V7LabBiochemistryPI();
        V7LabUrinalysis();
        V7LabUrinalysisPI();
        V7LabImmunologicalTests();
        V7LabImmunologicalTestsPI();
        V7CTWholeBody();
        V7CTWholeBodyPI();
        V7ResponseCriteria();
        V7ResponseCriteriaPI();
        V7DiseaseProgressionAssessment();
        V7DiseaseProgressionAssessmentPI();
        V7StudyDrugDispensingRecord();
        V7StudyDrugDispensingRecordPI();
        V7StudyDrugComplianceRecord();
        V7StudyDrugComplianceRecordPI();
        V7SubjectDiaryDispensing();
        V7SubjectDiaryDispensingPI();
        V7SubjectDiaryReview();
        V7SubjectDiaryReviewPI();
        V7SubjectDiaryRetrieval();
        V7SubjectDiaryRetrievalPI();
        V7ConcomitantMedication();
        V7ConcomitantMedicationPI();
        V7HRQoL_Questionnaire();
        V7HRQoL_QuestionnairePI();
        V7AE_SAE_Assessement();
        V7AE_SAE_AssessementPI();

        V8VisitDate();
        V8VisitDatePI();
        V8VitalSigns();
        V8VitalSignsPI();
        V8PhysicalExamination();
        V8PhysicalExaminationPI();
        V8ECG();
        V8ECGPI();
        V8ImmunologicalTest();
        V8ImmunologicalTestPI();
        V8StudyDrugDispensingRecord();
        V8StudyDrugDispensingRecordPI();
        V8StudyDrugComplianceRecord();
        V8StudyDrugComplianceRecordPI();
        V8SubjectDiaryDispensing();
        V8SubjectDiaryDispensingPI();
        V8SubjectDiaryReview();
        V8SubjectDiaryReviewPI();
        V8SubjectDiaryRetrieval();
        V8SubjectDiaryRetrievalPI();
        V8ConcomitantMedication();
        V8ConcomitantMedicationPI();
        V8HRQoL_Questionnaire();
        V8HRQoL_QuestionnairePI();
        V8DiseaseProgressionAssessment();
        V8DiseaseProgressionAssessmentPI();
        V8AE_SAE_Assessement();
        V8AE_SAE_AssessementPI();

        V9VisitDate();
        V9VisitDatePI();
        V9VitalSigns();
        V9VitalSignsPI();
        V9PhysicalExamination();
        V9PhysicalExaminationPI();
        V9ECG();
        V9ECGPI();
        V9ChestXRay();
        V9ChestXRayPI();
        V9LabCompleteBloodCount();
        V9LabCompleteBloodCountPI();
        V9LabBiochemistry();
        V9LabBiochemistryPI();
        V9LabUrinalysis();
        V9LabUrinalysisPI();
        V9LabImmunologicalTests();
        V9LabImmunologicalTestsPI();
        V9CTWholeBody();
        V9CTWholeBodyPI();
        V9ResponseCriteria();
        V9ResponseCriteriaPI();
        V9DiseaseProgressionAssessment();
        V9DiseaseProgressionAssessmentPI();
        V9StudyDrugComplianceRecord();
        V9StudyDrugComplianceRecordPI();
        V9SubjectDiaryReview();
        V9SubjectDiaryReviewPI();
        V9SubjectDiaryRetrieval();
        V9SubjectDiaryRetrievalPI();
        V9ConcomitantMedication();
        V9ConcomitantMedicationPI();
        V9HRQoL_Questionnaire();
        V9HRQoL_QuestionnairePI();
        V9AE_SAE_Assessement();
        V9AE_SAE_AssessementPI();
        BindGridViewMHR();
        BindGridViewCMR();
        BindGridViewAEAEN();
        EndOfStudyLog();
        EndOfStudyLogPI();

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
            if (Request.QueryString[3].ToString() == "Visit 4")
            {
                TabContainer1.ActiveTabIndex = 3;
            }
            if (Request.QueryString[3].ToString() == "Visit 5")
            {
                TabContainer1.ActiveTabIndex = 4;
            }
            if (Request.QueryString[3].ToString() == "Visit 6")
            {
                TabContainer1.ActiveTabIndex = 5;
            }
            if (Request.QueryString[3].ToString() == "Visit 7")
            {
                TabContainer1.ActiveTabIndex = 6;
            }
            if (Request.QueryString[3].ToString() == "Visit 8")
            {
                TabContainer1.ActiveTabIndex = 7;
            }
            if (Request.QueryString[3].ToString() == "Visit 9")
            {
                TabContainer1.ActiveTabIndex = 8;
            }
            if (Request.QueryString[3].ToString() == "Unscheduled Event")
            {
                TabContainer1.ActiveTabIndex = 9;
            }
            if (Request.QueryString[3].ToString() == "Concomitant Medication")
            {
                TabContainer1.ActiveTabIndex = 10;
            }
            if (Request.QueryString[3].ToString() == "Adverse Event")
            {
                TabContainer1.ActiveTabIndex = 11;
            }
            if (Request.QueryString[3].ToString() == "Withdrawal Form")
            {
                TabContainer1.ActiveTabIndex = 12;
            }
        }
    }

    #region Custom Functions

    private void fetchShowHide()
    {
        con.Close();
        DataTable dt = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT CASE WHEN  t1.IC1OPT = 'Yes' and t1.IC2OPT = 'Yes' and t1.IC3OPT = 'Yes' and t1.EC1OPT = 'No' and t1.EC2OPT = 'No' and t1.EC3OPT = 'No' and t1.EC4OPT = 'No' and t1.EC5OPT = 'No' and t1.EC6OPT = 'No' and t1.ELIGL = 'Yes' THEN 'True' ELSE 'False' END AS 'IncSubAge' FROM [Visit1].[EligibilityCriteria] AS t1 where t1.SITENUM='" + Request.QueryString["a"] + "' and t1.SUBNUM='" + Request.QueryString["b"] + "' and t1.SUBINI='" + Request.QueryString["c"] + "'", con);
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
                TabPanelVisit5.Enabled = true;
                TabPanelVisit6.Enabled = true;
                TabPanelVisit7.Enabled = true;
                TabPanelVisit8.Enabled = true;
                TabPanelVisit9.Enabled = true;
            }
            else
            {
                TabContainer1.Tabs[1].Enabled = false;
                TabPanelVisit2.Enabled = false;
                TabPanelVisit3.Enabled = false;
                TabPanelVisit4.Enabled = false;
                TabPanelVisit5.Enabled = false;
                TabPanelVisit6.Enabled = false;
                TabPanelVisit7.Enabled = false;
                TabPanelVisit8.Enabled = false;
                TabPanelVisit9.Enabled = false;
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
    private void V1DateOfPatientVisitAndICF()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[DateOfPatientVisitAndICF] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1DateOfPatientVisitAndICFPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Date Of Patient Visit And ICF'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1Demographics()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[Demographics] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1DemographicsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Demographics'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1IndicationDiagnosis()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[IndicationDiagnosis] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1IndicationDiagnosisPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Indication Diagnosis'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1MedicalSurgicalHistory()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[MedicalSurgicalHistory] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1MedicalSurgicalHistoryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Medical Surgical History'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1ConMedForDiagnosed()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[ConMedForDiagnosed] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1ConMedForDiagnosedPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Prior And Concomitant Medication (For Diagnosed MCL/ CLL/ WM/ MZL/ FL)'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1ConMedForMedicalHistory()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[ConMedForMedicalHistory] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1ConMedForMedicalHistoryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Prior And Concomitant Medication (For Other Medical History)'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1ECOGPerformanceStatus()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[ECOGPerformanceStatus] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1ECOGPerformanceStatusPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='ECOG Performance Status'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
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
                ImageButtonV1_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
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
                ImageButtonV1_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
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
                ImageButtonV1_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
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
                ImageButtonV1_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1ChestXRay()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[ChestXRay] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_12.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_12.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_12.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_12.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_12.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1ChestXRayPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Chest X Ray'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_12PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1UPTExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[UPTExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_13.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_13.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_13.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_13.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_13.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1UPTExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='UPT Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_13PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1LabCompleteBloodCount()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_14.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_14.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_14.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_14.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_14.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1LabCompleteBloodCountPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Complete Blood Count'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_14PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1LabBiochemistry()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[LabBiochemistry] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_15.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_15.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_15.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_15.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_15.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1LabBiochemistryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Biochemistry'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_15PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1LabUrinalysis()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_16.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_16.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_16.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_16.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_16.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1LabUrinalysisPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Urinalysis'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_16PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1LabVirologicalTests()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[LabVirologicalTests] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_17.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_17.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_17.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_17.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_17.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1LabVirologicalTestsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Virological Tests'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_17PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1LabImmunologicalTests()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[LabImmunologicalTests] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_18.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_18.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_18.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_18.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_18.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1LabImmunologicalTestsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Immunological Tests'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_18PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1Beta_2_Microglobulin()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[Beta_2_Microglobulin] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_19.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_19.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_19.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_19.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_19.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_19.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_19.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1Beta_2_MicroglobulinPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='Beta-2 Microglobulin'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_19PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_19PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_19PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V1AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit1].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV1_20.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV1_20.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV1_20.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV1_20.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV1_20.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV1_20.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV1_20.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V1AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 1' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV1_20PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV1_20PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV1_20PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 2 All Image Binding Data
    private void V2VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2HRQoL_Questionnaire()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2HRQoL_QuestionnairePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='HRQoL Questionnaire'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2CTWholeBody()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[CTWholeBody] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2CTWholeBodyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='CT Whole Body'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2StudyDrugDispensingRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2StudyDrugDispensingRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Study Drug Dispensing Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2SubjectDiaryDispensing()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[SubjectDiaryDispensing] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2SubjectDiaryDispensingPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Subject Diary Dispensing'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V2ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit2].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV2_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV2_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV2_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV2_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV2_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV2_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV2_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V2ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 2' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV2_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV2_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV2_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 3 All Image Binding Data
    private void V3VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
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
                ImageButtonV3_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3ImmunologicalTest()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[ImmunologicalTest] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3ImmunologicalTestPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Immunological Test'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3StudyDrugDispensingRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3StudyDrugDispensingRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Study Drug Dispensing Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3StudyDrugComplianceRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[StudyDrugComplianceRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3StudyDrugComplianceRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Study Drug Compliance Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3SubjectDiaryReview()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[SubjectDiaryReview] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3SubjectDiaryReviewPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Subject Diary Review'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3DiseaseProgressionAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[DiseaseProgressionAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3DiseaseProgressionAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Disease Progression Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V3ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit3].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV3_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV3_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV3_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV3_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV3_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV3_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV3_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V3ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 3' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV3_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV3_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV3_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 4 All Image Binding Data
    private void V4VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4ChestXRay()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[ChestXRay] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4ChestXRayPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Chest X Ray'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4LabCompleteBloodCount()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4LabCompleteBloodCountPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Complete Blood Count'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4LabBiochemistry()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[LabBiochemistry] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4LabBiochemistryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Biochemistry'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4LabUrinalysis()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4LabUrinalysisPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Urinalysis'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4LabImmunologicalTests()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[LabImmunologicalTests] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4LabImmunologicalTestsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Immunological Tests'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4StudyDrugDispensingRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4StudyDrugDispensingRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Study Drug Dispensing Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4StudyDrugComplianceRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[StudyDrugComplianceRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4StudyDrugComplianceRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Study Drug Compliance Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4SubjectDiaryDispensing()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[SubjectDiaryDispensing] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_12.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_12.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_12.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_12.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_12.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4SubjectDiaryDispensingPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Subject Diary Dispensing'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_12PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4SubjectDiaryReview()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[SubjectDiaryReview] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_13.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_13.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_13.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_13.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_13.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4SubjectDiaryReviewPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Subject Diary Review'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_13PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4SubjectDiaryRetrieval()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[SubjectDiaryRetrieval] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_14.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_14.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_14.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_14.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_14.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4SubjectDiaryRetrievalPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Subject Diary Retrieval'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_14PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_15.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_15.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_15.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_15.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_15.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_15PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4DiseaseProgressionAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[DiseaseProgressionAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_16.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_16.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_16.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_16.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_16.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4DiseaseProgressionAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='Disease Progression Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_16PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4HRQoL_Questionnaire()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_17.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_17.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_17.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_17.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_17.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4HRQoL_QuestionnairePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='HRQoL Questionnaire'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_17PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V4AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit4].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV4_18.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV4_18.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV4_18.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV4_18.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV4_18.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV4_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV4_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V4AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 4' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV4_18PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV4_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV4_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 5 All Image Binding Data
    private void V5VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5ChestXRay()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[ChestXRay] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5ChestXRayPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Chest X Ray'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5LabCompleteBloodCount()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5LabCompleteBloodCountPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Complete Blood Count'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5LabBiochemistry()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[LabBiochemistry] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5LabBiochemistryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Biochemistry'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5LabUrinalysis()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5LabUrinalysisPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Urinalysis'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5LabImmunologicalTests()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[LabImmunologicalTests] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5LabImmunologicalTestsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Immunological Tests'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5CTWholeBody()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[CTWholeBody] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5CTWholeBodyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='CT Whole Body'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5ResponseCriteria()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[ResponseCriteria] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5ResponseCriteriaPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Response Criteria'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5DiseaseProgressionAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[DiseaseProgressionAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_12.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_12.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_12.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_12.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_12.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5DiseaseProgressionAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Disease Progression Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_12PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5StudyDrugDispensingRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_13.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_13.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_13.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_13.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_13.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5StudyDrugDispensingRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Study Drug Dispensing Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_13PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5StudyDrugComplianceRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[StudyDrugComplianceRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_14.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_14.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_14.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_14.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_14.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5StudyDrugComplianceRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Study Drug Compliance Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_14PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5SubjectDiaryDispensing()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[SubjectDiaryDispensing] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_15.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_15.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_15.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_15.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_15.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5SubjectDiaryDispensingPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Subject Diary Dispensing'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_15PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5SubjectDiaryReview()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[SubjectDiaryReview] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_16.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_16.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_16.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_16.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_16.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5SubjectDiaryReviewPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Subject Diary Review'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_16PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5SubjectDiaryRetrieval()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[SubjectDiaryRetrieval] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_17.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_17.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_17.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_17.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_17.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5SubjectDiaryRetrievalPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Subject Diary Retrieval'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_17PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_18.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_18.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_18.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_18.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_18.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_18PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5HRQoL_Questionnaire()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_19.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_19.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_19.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_19.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_19.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_19.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_19.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5HRQoL_QuestionnairePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='HRQoL Questionnaire'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_19PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_19PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_19PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V5AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit5].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV5_20.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV5_20.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV5_20.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV5_20.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV5_20.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV5_20.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV5_20.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V5AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 5' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV5_20PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV5_20PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV5_20PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 6 All Image Binding Data
    private void V6VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6StudyDrugDispensingRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6StudyDrugDispensingRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Study Drug Dispensing Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6StudyDrugComplianceRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[StudyDrugComplianceRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6StudyDrugComplianceRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Study Drug Compliance Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6SubjectDiaryDispensing()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[SubjectDiaryDispensing] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6SubjectDiaryDispensingPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Subject Diary Dispensing'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6SubjectDiaryReview()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[SubjectDiaryReview] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6SubjectDiaryReviewPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Subject Diary Review'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6SubjectDiaryRetrieval()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[SubjectDiaryRetrieval] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6SubjectDiaryRetrievalPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Subject Diary Retrieval'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6ImmunologicalTest()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[ImmunologicalTest] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6ImmunologicalTestPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Immunological Test'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6HRQoL_Questionnaire()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_12.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_12.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_12.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_12.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_12.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6HRQoL_QuestionnairePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='HRQoL Questionnaire'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_12PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6DiseaseProgressionAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[DiseaseProgressionAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_13.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_13.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_13.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_13.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_13.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6DiseaseProgressionAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='Disease Progression Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_13PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V6AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit6].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV6_14.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV6_14.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV6_14.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV6_14.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV6_14.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV6_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV6_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V6AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 6' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV6_14PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV6_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV6_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 7 All Image Binding Data
    private void V7VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7ChestXRay()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[ChestXRay] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7ChestXRayPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Chest X Ray'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7LabCompleteBloodCount()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7LabCompleteBloodCountPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Complete Blood Count'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7LabBiochemistry()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[LabBiochemistry] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7LabBiochemistryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Biochemistry'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7LabUrinalysis()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7LabUrinalysisPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Urinalysis'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7LabImmunologicalTests()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[LabImmunologicalTests] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7LabImmunologicalTestsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Immunological Tests'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7CTWholeBody()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[CTWholeBody] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7CTWholeBodyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='CT Whole Body'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7ResponseCriteria()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[ResponseCriteria] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7ResponseCriteriaPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Response Criteria'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7DiseaseProgressionAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[DiseaseProgressionAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_12.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_12.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_12.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_12.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_12.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7DiseaseProgressionAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Disease Progression Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_12PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7StudyDrugDispensingRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_13.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_13.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_13.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_13.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_13.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7StudyDrugDispensingRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Study Drug Dispensing Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_13PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7StudyDrugComplianceRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[StudyDrugComplianceRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_14.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_14.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_14.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_14.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_14.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7StudyDrugComplianceRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Study Drug Compliance Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_14PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7SubjectDiaryDispensing()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[SubjectDiaryDispensing] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_15.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_15.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_15.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_15.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_15.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7SubjectDiaryDispensingPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Subject Diary Dispensing'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_15PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7SubjectDiaryReview()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[SubjectDiaryReview] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_16.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_16.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_16.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_16.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_16.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7SubjectDiaryReviewPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Subject Diary Review'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_16PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7SubjectDiaryRetrieval()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[SubjectDiaryRetrieval] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_17.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_17.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_17.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_17.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_17.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7SubjectDiaryRetrievalPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Subject Diary Retrieval'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_17PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_18.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_18.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_18.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_18.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_18.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_18PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7HRQoL_Questionnaire()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_19.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_19.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_19.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_19.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_19.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_19.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_19.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7HRQoL_QuestionnairePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='HRQoL Questionnaire'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_19PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_19PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_19PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V7AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit7].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV7_20.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV7_20.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV7_20.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV7_20.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV7_20.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV7_20.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV7_20.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V7AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 7' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV7_20PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV7_20PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV7_20PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 8 All Image Binding Data
    private void V8VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8ImmunologicalTest()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[ImmunologicalTest] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8ImmunologicalTestPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Immunological Test'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8StudyDrugDispensingRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8StudyDrugDispensingRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Study Drug Dispensing Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8StudyDrugComplianceRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[StudyDrugComplianceRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8StudyDrugComplianceRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Study Drug Compliance Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8SubjectDiaryDispensing()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[SubjectDiaryDispensing] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8SubjectDiaryDispensingPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Subject Diary Dispensing'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8SubjectDiaryReview()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[SubjectDiaryReview] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8SubjectDiaryReviewPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Subject Diary Review'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8SubjectDiaryRetrieval()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[SubjectDiaryRetrieval] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8SubjectDiaryRetrievalPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Subject Diary Retrieval'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8HRQoL_Questionnaire()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_12.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_12.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_12.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_12.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_12.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8HRQoL_QuestionnairePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='HRQoL Questionnaire'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_12PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8DiseaseProgressionAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[DiseaseProgressionAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_13.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_13.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_13.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_13.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_13.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8DiseaseProgressionAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='Disease Progression Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_13PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V8AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit8].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV8_14.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV8_14.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV8_14.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV8_14.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV8_14.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV8_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV8_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V8AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 8' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV8_14PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV8_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV8_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    #region Visit 9 All Image Binding Data
    private void V9VisitDate()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[VisitDate] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_01.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_01.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_01.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_01.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_01.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_01.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9VisitDatePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Visit Date'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_01PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_01PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9VitalSigns()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[VitalSigns] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_02.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_02.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_02.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_02.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_02.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_02.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9VitalSignsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Vital Signs'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_02PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_02PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9PhysicalExamination()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_03.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_03.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_03.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_03.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_03.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_03.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9PhysicalExaminationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Physical Examination'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_03PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_03PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9ECG()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[ECG] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_04.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_04.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_04.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_04.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_04.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_04.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9ECGPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='ECG'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_04PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_04PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9ChestXRay()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[ChestXRay] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_05.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_05.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_05.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_05.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_05.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_05.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9ChestXRayPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Chest X Ray'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_05PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_05PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9LabCompleteBloodCount()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_06.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_06.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_06.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_06.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_06.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_06.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9LabCompleteBloodCountPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Complete Blood Count'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_06PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_06PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9LabBiochemistry()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[LabBiochemistry] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_07.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_07.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_07.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_07.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_07.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_07.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9LabBiochemistryPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Biochemistry'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_07PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_07PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9LabUrinalysis()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_08.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_08.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_08.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_08.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_08.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_08.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9LabUrinalysisPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Urinalysis'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_08PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_08PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9LabImmunologicalTests()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[LabImmunologicalTests] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_09.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_09.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_09.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_09.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_09.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_09.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9LabImmunologicalTestsPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Immunological Tests'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_09PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_09PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9CTWholeBody()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[CTWholeBody] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_10.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_10.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_10.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_10.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_10.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_10.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9CTWholeBodyPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='CT Whole Body'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_10PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_10PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9ResponseCriteria()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[ResponseCriteria] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_11.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_11.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_11.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_11.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_11.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_11.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9ResponseCriteriaPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Response Criteria'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_11PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_11PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9DiseaseProgressionAssessment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[DiseaseProgressionAssessment] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_12.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_12.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_12.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_12.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_12.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_12.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9DiseaseProgressionAssessmentPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Disease Progression Assessment'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_12PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_12PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9StudyDrugComplianceRecord()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[StudyDrugComplianceRecord] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_13.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_13.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_13.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_13.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_13.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_13.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9StudyDrugComplianceRecordPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Study Drug Compliance Record'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_13PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_13PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9SubjectDiaryReview()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[SubjectDiaryReview] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_14.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_14.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_14.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_14.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_14.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_14.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9SubjectDiaryReviewPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Subject Diary Review'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_14PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_14PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9SubjectDiaryRetrieval()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[SubjectDiaryRetrieval] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_15.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_15.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_15.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_15.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_15.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_15.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9SubjectDiaryRetrievalPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Subject Diary Retrieval'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_15PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_15PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9ConcomitantMedication()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[ConcomitantMedication] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_16.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_16.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_16.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_16.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_16.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_16.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9ConcomitantMedicationPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='Concomitant Medication'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_16PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_16PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9HRQoL_Questionnaire()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_17.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_17.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_17.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_17.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_17.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_17.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9HRQoL_QuestionnairePI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='HRQoL Questionnaire'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_17PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_17PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    private void V9AE_SAE_Assessement()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Visit9].[AE_SAE_Assessement] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();
            if ((EntryStatus == "Save") && (LockStatus != "locked") && (LockStatus != "SDV"))
            {
                ImageButtonV9_18.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && ((LockStatus != "Locked") && (LockStatus != "SDV")) && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonV9_18.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && ((LockStatus == "Unlocked") || (LockStatus != "Locked") || (LockStatus != "SDV")) && ((QueryStatus == "Open") || (QueryStatus == "Query Responded")))
            {
                ImageButtonV9_18.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {
                ImageButtonV9_18.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "Query Closed") || (QueryStatus == "No Query")))
            {
                ImageButtonV9_18.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else
            {
                ImageButtonV9_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonV9_18.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void V9AE_SAE_AssessementPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Visit 9' and PAGENAME='AE/SAE Assessement'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonV9_18PI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonV9_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonV9_18PI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }
    #endregion
    
    private void EndOfStudyLog()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select EntryStatus,LockStatus,QueryStatus from [Add].[EndOfStudyLog] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string EntryStatus = dr["EntryStatus"].ToString();
            string LockStatus = dr["LockStatus"].ToString();
            string QueryStatus = dr["QueryStatus"].ToString();

            if ((EntryStatus == "Save") && (LockStatus != "locked"))
            {
                ImageButtonSCTF.ImageUrl = "~/Data-Entry/Images/Edit.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus != "Locked") && (LockStatus != "SDV") && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonSCTF.ImageUrl = "~/Data-Entry/Images/Submit.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus == "SDV") && ((QueryStatus == "No Query") || (QueryStatus == "Query Closed")))
            {
                ImageButtonSCTF.ImageUrl = "~/Data-Entry/Images/SDV.png";
            }
            else if ((EntryStatus == "Submit") && (LockStatus != "Locked") && ((QueryStatus == "Open") || (QueryStatus == "Query Responded") || (QueryStatus == "Query Closed")))
            {
                ImageButtonSCTF.ImageUrl = "~/Data-Entry/Images/Query.png";

            }
            else if ((EntryStatus == "Submit") && (LockStatus == "Locked"))
            {

                ImageButtonSCTF.ImageUrl = "~/Data-Entry/Images/DataLock.png";
            }
            else
            {
                ImageButtonSCTF.ImageUrl = "~/Data-Entry/Images/Blank.png";
            }

        }
        else
        {
            ImageButtonSCTF.ImageUrl = "~/Data-Entry/Images/Blank.png";
        }


        dr.Close();

        con.Close();

    }
    private void EndOfStudyLogPI()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and VISIT='Withdrawal Form' and PAGENAME='End of Study Log'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((dr["PISIGN"].ToString() == "True"))
            {
                ImageButtonSCTFPI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

            }
            else
            {
                ImageButtonSCTFPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


        }
        else
        {
            ImageButtonSCTFPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
        }
        dr.Close();

        con.Close();

    }

    #region Visit 1
    protected void ImageButtonV1_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/DateOfPatientVisitAndICF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/DateOfPatientVisitAndICF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/DateOfPatientVisitAndICF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/DateOfPatientVisitAndICF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/DateOfPatientVisitAndICF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/DateOfPatientVisitAndICF.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Demographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/Demographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Demographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Demographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Demographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/Demographics.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/IndicationDiagnosis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/IndicationDiagnosis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/IndicationDiagnosis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/IndicationDiagnosis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/IndicationDiagnosis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/IndicationDiagnosis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/MedicalSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/MedicalSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/MedicalSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/MedicalSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/MedicalSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/MedicalSurgicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForDiagnosed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/ConMedForDiagnosed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForDiagnosed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForDiagnosed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForDiagnosed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForDiagnosed.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForMedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/ConMedForMedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForMedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForMedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForMedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/ConMedForMedicalHistory.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECOGPerformanceStatus.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/ECOGPerformanceStatus.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECOGPerformanceStatus.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECOGPerformanceStatus.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECOGPerformanceStatus.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/ECOGPerformanceStatus.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/EligibilityCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_12_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_12.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_12.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_12.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_12.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_12.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_13_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_13.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/UPTExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_13.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/UPTExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_13.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/UPTExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_13.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/UPTExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_13.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/UPTExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/UPTExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_14_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_14.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_14.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_14.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_14.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_14.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_15_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_15.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_15.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_15.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_15.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_15.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_16_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_16.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_16.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_16.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_16.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_16.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_17_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_17.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VirologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_17.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/VirologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_17.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VirologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_17.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VirologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_17.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/VirologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/VirologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_18_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_18.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_18.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_18.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_18.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_18.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_19_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_19.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Beta_2_Microglobulin.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_19.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/Beta_2_Microglobulin.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_19.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Beta_2_Microglobulin.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_19.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Beta_2_Microglobulin.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_19.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/Beta_2_Microglobulin.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/Beta_2_Microglobulin.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV1_20_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV1_20.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_20.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit1/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_20.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_20.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV1_20.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit1/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit1/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 2
    protected void ImageButtonV2_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV2_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV2_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit2/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV2_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit2/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit2/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 3
    protected void ImageButtonV3_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV3_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV3_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit3/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV3_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit3/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit3/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 4
    protected void ImageButtonV4_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_12_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_12.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_12.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_12.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_12.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_12.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_13_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_13.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_13.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_13.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_13.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_13.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_14_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_14.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_14.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_14.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_14.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_14.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_15_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_15.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_15.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_15.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_15.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_15.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_16_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_16.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_16.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_16.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_16.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_16.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_17_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_17.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_17.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_17.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_17.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_17.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV4_18_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV4_18.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_18.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit4/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_18.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_18.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV4_18.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit4/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit4/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 5
    protected void ImageButtonV5_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_12_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_12.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_12.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_12.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_12.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_12.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_13_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_13.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_13.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_13.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_13.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_13.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_14_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_14.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_14.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_14.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_14.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_14.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_15_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_15.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_15.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_15.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_15.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_15.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_16_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_16.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_16.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_16.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_16.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_16.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_17_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_17.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_17.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_17.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_17.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_17.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_18_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_18.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_18.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_18.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_18.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_18.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_19_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_19.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_19.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_19.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_19.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_19.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV5_20_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV5_20.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_20.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit5/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_20.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_20.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV5_20.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit5/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit5/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 6
    protected void ImageButtonV6_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_12_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_12.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_12.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_12.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_12.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_12.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_13_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_13.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_13.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_13.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_13.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_13.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV6_14_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV6_14.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_14.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit6/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_14.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_14.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV6_14.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit6/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit6/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 7
    protected void ImageButtonV7_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_12_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_12.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_12.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_12.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_12.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_12.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_13_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_13.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_13.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_13.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_13.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_13.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_14_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_14.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_14.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_14.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_14.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_14.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_15_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_15.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_15.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_15.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_15.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_15.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_16_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_16.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_16.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_16.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_16.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_16.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_17_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_17.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_17.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_17.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_17.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_17.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_18_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_18.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_18.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_18.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_18.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_18.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_19_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_19.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_19.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_19.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_19.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_19.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV7_20_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV7_20.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_20.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit7/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_20.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_20.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV7_20.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit7/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit7/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 8
    protected void ImageButtonV8_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/ImmunologicalTest.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugDispensingRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryDispensing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_12_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_12.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_12.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_12.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_12.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_12.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_13_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_13.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_13.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_13.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_13.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_13.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV8_14_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV8_14.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_14.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit8/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_14.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_14.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV8_14.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit8/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit8/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion
    #region Visit 9
    protected void ImageButtonV9_01_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_01.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_01.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_01.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_01.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_01.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/VisitDate.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_02_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_02.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_02.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_02.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_02.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_02.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/VitalSigns.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_03_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_03.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_03.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_03.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_03.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_03.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/PhysicalExamination.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_04_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_04.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_04.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_04.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_04.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_04.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/ECG.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_05_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_05.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_05.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_05.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_05.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_05.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/ChestXRay.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_06_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_06.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_06.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_06.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_06.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_06.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/CompleteBloodCount.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_07_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_07.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_07.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_07.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_07.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_07.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/Biochemistry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_08_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_08.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_08.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_08.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_08.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_08.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/Urinalysis.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_09_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_09.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_09.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_09.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_09.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_09.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/ImmunologicalTests.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_10_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_10.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_10.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_10.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_10.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_10.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/CTWholeBody.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_11_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_11.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_11.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_11.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_11.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_11.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/ResponseCriteria.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_12_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_12.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_12.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_12.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_12.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_12.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/DiseaseProgressionAssessment.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_13_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_13.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_13.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_13.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_13.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_13.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/StudyDrugComplianceRecord.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_14_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_14.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_14.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_14.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_14.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_14.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryReview.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_15_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_15.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_15.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_15.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_15.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_15.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/SubjectDiaryRetrieval.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_16_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_16.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_16.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_16.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_16.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_16.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/ConcomitantMedication.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_17_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_17.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_17.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_17.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_17.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_17.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/HRQoL_Questionnaire.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    protected void ImageButtonV9_18_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonV9_18.ImageUrl == "~/Data-Entry/Images/Submit.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_18.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/Visit9/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_18.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_18.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonV9_18.ImageUrl == "~/Data-Entry/Images/SDV.png")
        {
            Response.Redirect("~/Data-Entry/Visit9/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/Visit9/AE_SAE_Assessement.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }
    }
    #endregion

    #region MHR
    private void BindGridViewMHR()
    {
        DataSet ds = new DataSet();

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [UISNO] , [QueryStatus],[LockStatus],[EntryStatus] FROM [Add].[UnscheduledInvestigationsAssessments] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                litActualMHR.Text += "<img id='Image3' src='/Data-Entry/Images/Edit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/UnscheduledInvestigationsAssessments.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["UISNO"].ToString();

            }

            else if (EntryStatus == "Submit" && (LockStatus != "Locked" && LockStatus != "SDV") && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualMHR.Text += "<img id='Image3' src='/Data-Entry/Images/Submit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/UnscheduledInvestigationsAssessments.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["UISNO"].ToString();
            }
            else if (EntryStatus == "Submit" && LockStatus == "SDV" && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualMHR.Text += "<img id='Image3' src='/Data-Entry/Images/SDV.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/UnscheduledInvestigationsAssessments.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["UISNO"].ToString();

            }

            else if (EntryStatus == "Submit" && LockStatus != "Locked" && (QueryStatus == "Open" || QueryStatus == "Query Responded" || QueryStatus != "Query Closed"))
            {
                litActualMHR.Text += "<img id='Image3' src='/Data-Entry/Images/Query.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/UnscheduledInvestigationsAssessments.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["UISNO"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "Locked")
            {

                litActualMHR.Text += "<img id='Image3' src='/Data-Entry/Images/DataLock.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/UnscheduledInvestigationsAssessments.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["UISNO"].ToString();

            }
            else
            {
            }


            Image ImageButtonMedicalHistoryPI = e.Row.FindControl("ImageButtonMedicalHistoryPI") as Image;
            con.Close();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [SNO], [PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and EntryStatus='Submit' and VISIT='Unscheduled Event' and PAGENAME='Unscheduled Investigations Assessments' and SNO ='" + ((DataRowView)e.Row.DataItem)["UISNO"].ToString() + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if ((dr["PISIGN"].ToString() == "True"))
                {
                    ImageButtonMedicalHistoryPI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

                }
                else
                {
                    ImageButtonMedicalHistoryPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
                }


            }
            else
            {
                ImageButtonMedicalHistoryPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


            dr.Close();

            con.Close();

        }
    }
    protected void ButtonMHR_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/AdVisit/UnscheduledInvestigationsAssessmentsDataEntry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

    }
    #endregion
    #region CMR
    private void BindGridViewCMR()
    {
        DataSet ds = new DataSet();

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [CNSNO], [QueryStatus],[LockStatus],[EntryStatus] FROM [Add].[ConcomitantMedicationLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                litActualCMR.Text += "<img id='Image3' src='/Data-Entry/Images/Edit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/ConcomitantMedicationLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["CNSNO"].ToString();

            }

            else if (EntryStatus == "Submit" && (LockStatus != "Locked" && LockStatus != "SDV") && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualCMR.Text += "<img id='Image3' src='/Data-Entry/Images/Submit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/ConcomitantMedicationLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["CNSNO"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "SDV" && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualCMR.Text += "<img id='Image3' src='/Data-Entry/Images/SDV.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/ConcomitantMedicationLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["CNSNO"].ToString();

            }

            else if (EntryStatus == "Submit" && LockStatus != "Locked" && (QueryStatus == "Open" || QueryStatus == "Query Responded" || QueryStatus != "Query Closed"))
            {
                litActualCMR.Text += "<img id='Image3' src='/Data-Entry/Images/Query.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/ConcomitantMedicationLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["CNSNO"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "Locked")
            {

                litActualCMR.Text += "<img id='Image3' src='/Data-Entry/Images/DataLock.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/ConcomitantMedicationLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["CNSNO"].ToString();

            }
            else
            {
            }


            Image ImageButtonConMedPI = e.Row.FindControl("ImageButtonConMedPI") as Image;
            con.Close();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [SNO], [PISIGN] FROM [dbo].[tblPISignature]  where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and EntryStatus='Submit' and VISIT='Concomitant Medication' and PAGENAME='Prior/Concomitant Medication Form' and SNO ='" + ((DataRowView)e.Row.DataItem)["CNSNO"].ToString() + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if ((dr["PISIGN"].ToString() == "True"))
                {
                    ImageButtonConMedPI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

                }
                else
                {
                    ImageButtonConMedPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
                }


            }
            else
            {
                ImageButtonConMedPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }


            dr.Close();

            con.Close();

        }
    }
    protected void ButtonCMR_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/AdVisit/ConcomitantMedicationLogDataEntry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

    }
    #endregion
    #region AEAEN
    private void BindGridViewAEAEN()
    {
        DataSet ds = new DataSet();

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [AESNO] ,[QueryStatus],[LockStatus],[EntryStatus] FROM [Add].[AdverseEventForm] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                litActualAEAEN.Text += "<img id='Image3' src='/Data-Entry/Images/Edit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/AdverseEventForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AESNO"].ToString();

            }

            else if (EntryStatus == "Submit" && (LockStatus != "Locked" && LockStatus != "SDV") && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualAEAEN.Text += "<img id='Image3' src='/Data-Entry/Images/Submit.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/AdverseEventForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AESNO"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "SDV" && (QueryStatus == "No Query" || QueryStatus == "Query Closed"))
            {
                litActualAEAEN.Text += "<img id='Image3' src='/Data-Entry/Images/SDV.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/AdverseEventForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AESNO"].ToString();

            }

            else if (EntryStatus == "Submit" && LockStatus != "Locked" && (QueryStatus == "Open" || QueryStatus == "Query Responded" || QueryStatus != "Query Closed"))
            {
                litActualAEAEN.Text += "<img id='Image3' src='/Data-Entry/Images/Query.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/AdverseEventForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AESNO"].ToString();

            }
            else if (EntryStatus == "Submit" && LockStatus == "Locked")
            {

                litActualAEAEN.Text += "<img id='Image3' src='/Data-Entry/Images/DataLock.png' alt='' height='40' width='40' />";
                link2.NavigateUrl = "~/Data-Entry/AdVisit/AdverseEventForm.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&f=" + ((DataRowView)e.Row.DataItem)["AESNO"].ToString();

            }
            else
            {
            }


            Image ImageButtonAEAENPI = e.Row.FindControl("ImageButtonAEAENPI") as Image;
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [SNO], [PISIGN] FROM [dbo].[tblPISignature]  where [SITENUM] ='" + Request.QueryString[0] + "' and [SUBNUM]='" + Request.QueryString[1] + "'and [SUBINI]='" + Request.QueryString[2] + "' and EntryStatus='Submit' and VISIT='Adverse Event' and PAGENAME='Adverse Event Record' and SNO ='" + ((DataRowView)e.Row.DataItem)["AESNO"].ToString() + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                if ((dr["PISIGN"].ToString() == "True"))
                {
                    ImageButtonAEAENPI.ImageUrl = "~/Data-Entry/Images/Pisig.PNG";

                }
                else
                {
                    ImageButtonAEAENPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
                }


            }
            else
            {
                ImageButtonAEAENPI.ImageUrl = "~/Data-Entry/Images/pisin.PNG";
            }
            dr.Close();

            con.Close();

        }
    }
    protected void ButtonAEAEN_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/AdVisit/AdverseEventFormDataEntry.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

    }
    #endregion

    #region End of Study Log
    protected void ImageButtonSCTF_Click(object sender, ImageClickEventArgs e)
    {
        if (ImageButtonSCTF.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/AdVisit/EndOfStudyLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }

        else if (ImageButtonSCTF.ImageUrl == "~/Data-Entry/Images/Edit.png")
        {

            Response.Redirect("~/Data-Entry/AdVisit/EndOfStudyLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }

        else if (ImageButtonSCTF.ImageUrl == "~/Data-Entry/Images/Query.png")
        {
            Response.Redirect("~/Data-Entry/AdVisit/EndOfStudyLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else if (ImageButtonSCTF.ImageUrl == "~/Data-Entry/Images/DataLock.png")
        {
            Response.Redirect("~/Data-Entry/AdVisit/EndOfStudyLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));

        }
        else
        {
            Response.Redirect("~/Data-Entry/AdVisit/EndOfStudyLog.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
        }

    }

    #endregion

    #region PI Signature
    protected void ImageButtonV1PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit1/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV2PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit2/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV3PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit3/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV4PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit4/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV5PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit5/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV6PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit6/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV7PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit7/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV8PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit8/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonV9PI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/Visit9/PiSing.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonMHRPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/AdVisit/PiSingMHR.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonCMRPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/AdVisit/PiSingCMR.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonSCPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/AdVisit/PiSingSC.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    protected void ImageButtonAEAENPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Data-Entry/AdVisit/PiSingAE.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()));
    }
    #endregion
}