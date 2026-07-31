using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using System.Data.SqlClient;
using System.Configuration;
public partial class DataExtraction : System.Web.UI.Page
{
    protected void OnConfirmALL(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetAll";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.
                            ds.Tables[0].TableName = "V1_InformedConsent";
                            ds.Tables[1].TableName = "V1_EligibilityCriteria";
                            ds.Tables[2].TableName = "V1_PatientPresentation";
                            ds.Tables[3].TableName = "V1_VitalSignPhysicalExamination";
                            ds.Tables[4].TableName = "V1_RiskAssessment";
                            ds.Tables[5].TableName = "V1_MedicalAndSurgicalHistory";
                            ds.Tables[6].TableName = "V1_MedicationHistory";
                            ds.Tables[7].TableName = "V1_LabInvestigations";
                            ds.Tables[8].TableName = "V1_ECG";
                            ds.Tables[9].TableName = "V1_NTproBNP";
                            ds.Tables[10].TableName = "V1_Echocardiography";
                            ds.Tables[11].TableName = "V1_TypeOfHeartFailure";
                            ds.Tables[12].TableName = "V1_EtilogyOfHF";
                            ds.Tables[13].TableName = "V1_Medication";
                            ds.Tables[14].TableName = "V1_InHospitalOutcome";
                            ds.Tables[15].TableName = "V2_FollowUp";
                            ds.Tables[16].TableName = "V2_PatientPresentation";
                            ds.Tables[17].TableName = "V2_NYHAClass";
                            ds.Tables[18].TableName = "V2_ECG";
                            ds.Tables[19].TableName = "V2_Echocardiography";
                            ds.Tables[20].TableName = "V2_LabInvestigations";
                            ds.Tables[21].TableName = "V2_Medication";
                            ds.Tables[22].TableName = "V2_ProceduresPerformed";
                            ds.Tables[23].TableName = "V2_MedicationAdherence";
                            ds.Tables[24].TableName = "V2_CompositeOutcomes";
                            ds.Tables[25].TableName = "V2_AdverseEvent";
                            ds.Tables[26].TableName = "V3_FollowUp";
                            ds.Tables[27].TableName = "V3_PatientPresentation";
                            ds.Tables[28].TableName = "V3_NYHAClass";
                            ds.Tables[29].TableName = "V3_ECG";
                            ds.Tables[30].TableName = "V3_Echocardiography";
                            ds.Tables[31].TableName = "V3_LabInvestigations";
                            ds.Tables[32].TableName = "V3_Medication";
                            ds.Tables[33].TableName = "V3_ProceduresPerformed";
                            ds.Tables[34].TableName = "V3_MedicationAdherence";
                            ds.Tables[35].TableName = "V3_CompositeOutcomes";
                            ds.Tables[36].TableName = "V3_AdverseEvent";
                            ds.Tables[37].TableName = "VU_FollowUp";
                            ds.Tables[38].TableName = "VU_PatientPresentation";
                            ds.Tables[39].TableName = "VU_NYHAClass";
                            ds.Tables[40].TableName = "VU_ECG";
                            ds.Tables[41].TableName = "VU_Echocardiography";
                            ds.Tables[42].TableName = "VU_LabInvestigations";
                            ds.Tables[43].TableName = "VU_Medication";
                            ds.Tables[44].TableName = "VU_ProceduresPerformed";
                            ds.Tables[45].TableName = "VU_MedicationAdherence";
                            ds.Tables[46].TableName = "VU_CompositeOutcomes";
                            ds.Tables[47].TableName = "VU_AdverseEvent";
                            ds.Tables[48].TableName = "Medical History Record";
                            ds.Tables[49].TableName = "ConMed Record";
                            ds.Tables[50].TableName = "Adverse Event Record";
                            ds.Tables[51].TableName = "Study Completion Record";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=AllVisits.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirm1(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetVisit1";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.
                            ds.Tables[0].TableName = "V1_InformedConsent";
                            ds.Tables[1].TableName = "V1_EligibilityCriteria";
                            ds.Tables[2].TableName = "V1_PatientPresentation";
                            ds.Tables[3].TableName = "V1_VitalSignPhysicalExamination";
                            ds.Tables[4].TableName = "V1_RiskAssessment";
                            ds.Tables[5].TableName = "V1_MedicalAndSurgicalHistory";
                            ds.Tables[6].TableName = "V1_MedicationHistory";
                            ds.Tables[7].TableName = "V1_LabInvestigations";
                            ds.Tables[8].TableName = "V1_ECG";
                            ds.Tables[9].TableName = "V1_NTproBNP";
                            ds.Tables[10].TableName = "V1_Echocardiography";
                            ds.Tables[11].TableName = "V1_TypeOfHeartFailure";
                            ds.Tables[12].TableName = "V1_EtilogyOfHF";
                            ds.Tables[13].TableName = "V1_Medication";
                            ds.Tables[14].TableName = "V1_InHospitalOutcome";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Visit1.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirm2(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetVisit2";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.
                            ds.Tables[0].TableName = "V2_FollowUp";
                            ds.Tables[1].TableName = "V2_PatientPresentation";
                            ds.Tables[2].TableName = "V2_NYHAClass";
                            ds.Tables[3].TableName = "V2_ECG";
                            ds.Tables[4].TableName = "V2_Echocardiography";
                            ds.Tables[5].TableName = "V2_LabInvestigations";
                            ds.Tables[6].TableName = "V2_Medication";
                            ds.Tables[7].TableName = "V2_ProceduresPerformed";
                            ds.Tables[8].TableName = "V2_MedicationAdherence";
                            ds.Tables[9].TableName = "V2_CompositeOutcomes";
                            ds.Tables[10].TableName = "V2_AdverseEvent";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Visit2.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirm3(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetVisit3";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.
                           
                            ds.Tables[0].TableName = "V3_FollowUp";
                            ds.Tables[1].TableName = "V3_PatientPresentation";
                            ds.Tables[2].TableName = "V3_NYHAClass";
                            ds.Tables[3].TableName = "V3_ECG";
                            ds.Tables[4].TableName = "V3_Echocardiography";
                            ds.Tables[5].TableName = "V3_LabInvestigations";
                            ds.Tables[6].TableName = "V3_Medication";
                            ds.Tables[7].TableName = "V3_ProceduresPerformed";
                            ds.Tables[8].TableName = "V3_MedicationAdherence";
                            ds.Tables[9].TableName = "V3_CompositeOutcomes";
                            ds.Tables[10].TableName = "V3_AdverseEvent";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Visit3.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirm4(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetVisitUnscheduled";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.
                            ds.Tables[0].TableName = "VU_FollowUp";
                            ds.Tables[1].TableName = "VU_PatientPresentation";
                            ds.Tables[2].TableName = "VU_NYHAClass";
                            ds.Tables[3].TableName = "VU_ECG";
                            ds.Tables[4].TableName = "VU_Echocardiography";
                            ds.Tables[5].TableName = "VU_LabInvestigations";
                            ds.Tables[6].TableName = "VU_Medication";
                            ds.Tables[7].TableName = "VU_ProceduresPerformed";
                            ds.Tables[8].TableName = "VU_MedicationAdherence";
                            ds.Tables[9].TableName = "VU_CompositeOutcomes";
                            ds.Tables[10].TableName = "VU_AdverseEvent";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Visit_Unscheduled.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmMHR(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetMHR";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "MH_Record";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=MH_Record.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmConMed(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetCONMED";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "ConMed_Record";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=ConMed_Record.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmAE(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetAER";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "Adverse_Event_Record";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=AE_Record.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmSTUDY(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetSCF";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "Study_Completion_Record";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Study_Completion_Record.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmREASON(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetREASON";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "Reason_For_Changes";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=ReasonForChanges.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmQRIS(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetQRIS";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "Queries";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Queries.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmSTATUS(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetSTATUS";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "Status";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Status.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
    protected void OnConfirmREPORT(object sender, ImageClickEventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 5000;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_GetActivityReport";
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            //Set Name of DataTables.

                            ds.Tables[0].TableName = "Activity_Report";

                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                foreach (DataTable dt in ds.Tables)
                                {
                                    //Add DataTable as Worksheet.
                                    wb.Worksheets.Add(dt);
                                }

                                //Export the Excel file.
                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=Get_Activity_Report.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data is not downloaded!')", true);
        }
    }
}