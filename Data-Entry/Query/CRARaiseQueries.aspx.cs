using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;
using System.Text;


public partial class Admin_EnrolledSite : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection
   (ConfigurationManager.ConnectionStrings["constr"].ToString());
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        InGridView();
    }
    protected void InGridView()
    {

        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT c.[Site] as CenterNumber,c.[ScreenID],c.[SubInitial],c.[Visit],c.[Page],c.[Field],c.[Query],c.[Status],c.Username,c.[Date],c.Username2,c.Date2, c.SNO FROM [dbo].[tblQuery] as c inner Join [tblEnrollUsersWithSite] AS o ON c.[Site] =o.CenterNumber inner Join [Subject] AS d ON c.[Site] =d.SITENUM WHERE c.ScreenID=d.SUBNUM and c.Site=d.SITENUM and o.UserName='" + Session["UserName"] + "' and Status='Open'", con);

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();

        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ErroeMess.Visible = false;
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        else
        {
            ErroeMess.Visible = true;
            Label1.Text = "No Record Found !!!";

        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("dvview"))
        {
            int index = Convert.ToInt16(e.CommandArgument);
            Label lbl1 = (Label)GridView1.Rows[index].FindControl("lbSiteid");
            Label lbl2 = (Label)GridView1.Rows[index].FindControl("lbScreenID");
            Label lbl3 = (Label)GridView1.Rows[index].FindControl("lblSubIni");

            Label lbl6 = (Label)GridView1.Rows[index].FindControl("lblVisit");
            Label lbl7 = (Label)GridView1.Rows[index].FindControl("lblSNO");


            LinkButton lblPage = (LinkButton)GridView1.Rows[index].FindControl("lblPage");

            #region Visit 1
            if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("ECG"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/ECG.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Echocardiography"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/Echocardiography.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Eligibility Criteria"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/EligibilityCriteria.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Etilogy Of HF"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/EtilogyOfHF.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Informed Consent And Baseline Demographics"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/InformedConsentAndBaselineDemographics.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Date Of Patient Visit And ICF"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/InHospitalOutcome.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Laboratory Investigations"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/LaboratoryInvertigations.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Medical And Surgical History"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/MedicalAndSurgicalHistory.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Medical History"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/MedicalHistory.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Medication"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/Medication.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("NTproBNP"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/NTproBNP.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Patient Presentation (Symptoms And Signs)"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/PatientPresentationSymptomsAndSigns.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("-Risk Factor Assessment"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/RiskFactorAssessment.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Type Of Heart Failure And NYHA Class"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/TypeOfHeartFailureAndNYHAClass.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 1") && lblPage.Text.Equals("Vital Sign And Physical Examination"))
            {
                Response.Redirect("~/Study-Monitor/Visit1/VitalSignAndPhysicalExamination.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            #endregion
            #region Visit 2
            if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Adverse Event"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/AdverseEvent.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Composite Outcomes"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/CompositeOutcomes.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("ECG"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/ECG.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Echocardiography"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/Echocardiography.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Follow-Up"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/FollowUp.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Laboratory Investigations"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/LaboratoryInvertigations.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Medication"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/Medication.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Medication Adherence"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/MedicationAdherence.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("NYHA Class"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/NYHAClass.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Patient Presentation (Symptoms And Signs)"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/PatientPresentationSymptomsAndSigns.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 2") && lblPage.Text.Equals("Procedures Performed"))
            {
                Response.Redirect("~/Study-Monitor/Visit2/ProceduresPerformed.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            #endregion
            #region Visit 3
            if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Adverse Event"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/AdverseEvent.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Composite Outcomes"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/CompositeOutcomes.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("ECG"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/ECG.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Echocardiography"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/Echocardiography.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Follow-Up"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/FollowUp.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Laboratory Investigations"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/LaboratoryInvertigations.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Medication"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/Medication.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Medication Adherence"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/MedicationAdherence.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("NYHA Class"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/NYHAClass.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Patient Presentation (Symptoms And Signs)"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/PatientPresentationSymptomsAndSigns.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit 3") && lblPage.Text.Equals("Procedures Performed"))
            {
                Response.Redirect("~/Study-Monitor/Visit3/ProceduresPerformed.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            #endregion
            #region Visit Unscheduled
            if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Adverse Event"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/AdverseEvent.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Composite Outcomes"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/CompositeOutcomes.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("ECG"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/ECG.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Echocardiography"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/Echocardiography.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Follow-Up"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/FollowUp.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Laboratory Investigations"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/LaboratoryInvertigations.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Medication"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/Medication.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Medication Adherence"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/MedicationAdherence.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("NYHA Class"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/NYHAClass.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Patient Presentation (Symptoms And Signs)"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/PatientPresentationSymptomsAndSigns.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Visit Unscheduled") && lblPage.Text.Equals("Procedures Performed"))
            {
                Response.Redirect("~/Study-Monitor/Unscheduled/ProceduresPerformed.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            #endregion
            #region Additional Pages
            if (lbl6.Text.Equals("Adverse Event") && lblPage.Text.Equals("Adverse Event Record"))
            {
                Response.Redirect("~/Study-Monitor/AdVisit/AdverseEventRecord.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text + "&d=" + lbl6.Text + "&f=" + lbl7.Text);
            }
            else if (lbl6.Text.Equals("Concomitant Medication") && lblPage.Text.Equals("Prior/Concomitant Medication Form"))
            {
                Response.Redirect("~/Study-Monitor/AdVisit/ConcomitantMedication.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text + "&d=" + lbl6.Text + "&f=" + lbl7.Text);
            }
            else if (lbl6.Text.Equals("Withdrawal Form") && lblPage.Text.Equals("Study Completion/Early Termination Form"))
            {
                Response.Redirect("~/Study-Monitor/AdVisit/StudyCompletionForm.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text);
            }
            else if (lbl6.Text.Equals("Medical History") && lblPage.Text.Equals("Medical History Record"))
            {
                Response.Redirect("~/Study-Monitor/AdVisit/MedicalHistory.aspx?a=" + lbl1.Text + "&b=" + lbl2.Text + "&c=" + lbl3.Text + "&d=" + lbl6.Text + "&f=" + lbl7.Text);
            }

            #endregion
        }
    }
}