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

public partial class Study_Monitor_Visit1_ECG : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd1;
    SqlConnection con2 = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd2;
    SqlDataAdapter da = new SqlDataAdapter();
    AuditLog objAuditLog = new AuditLog();

    private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCenterNumber.Text = Request.QueryString["a"];
        lblScreeningNo.Text = Request.QueryString["b"];
        lblSubjectInitial.Text = Request.QueryString["c"];

        if (Session["UserSession"] != null)
        {
            LabelUserName.Text = Session["UserName"].ToString();

        }
        else
        {
            LabelUserName.Text = "";

        }

        if (!IsPostBack)
        {
            BindPage();
            ViewState["oldData"] = dt;

        }
        PageStatus();
        SetImageAddNote();
        BindGridviewAddNote();
        SetImageAttach();
        BindGridViewADDAddAttachment();

        SetImageAttachPageHistory();
        BindGridViewADDAttachmentPageHistory();

        SetImageQueryECGDAT();
        BindQueryDataECGDAT();
        SetImageQueryECGFIND();
        BindQueryDataECGFIND();
        SetImageQueryECG1RHM();
        BindQueryDataECG1RHM();
        SetImageQueryECG2RHM();
        BindQueryDataECG2RHM();
        SetImageQueryECG3RHM();
        BindQueryDataECG3RHM();
        SetImageQueryECG4RHM();
        BindQueryDataECG4RHM();
        SetImageQueryECG4OTR();
        BindQueryDataECG4OTR();
        SetImageQueryECGQRS();
        BindQueryDataECGQRS();

        TextBoxECGDAT_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select ECGDAT ,ECGFIND ,ECG1RHM ,ECG2RHM ,ECG3RHM ,ECG4RHM ,ECG4OTR ,ECGQRS, LockStatus from [Visit1].[ECG] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxECGDAT.Text = dt.Rows[0]["ECGDAT"].ToString().Trim();
            TextBoxECGFIND.Text = dt.Rows[0]["ECGFIND"].ToString().Trim();
            chkECG1RHM.Checked = Convert.ToString(dt.Rows[0]["ECG1RHM"]).Equals("SR");
            chkECG2RHM.Checked = Convert.ToString(dt.Rows[0]["ECG2RHM"]).Equals("AF");
            chkECG3RHM.Checked = Convert.ToString(dt.Rows[0]["ECG3RHM"]).Equals("Paced");
            chkECG4RHM.Checked = Convert.ToString(dt.Rows[0]["ECG4RHM"]).Equals("Others");
            TextBoxECG4OTR.Text = dt.Rows[0]["ECG4OTR"].ToString().Trim();
            RadioButtonListECGQRS.SelectedValue = dt.Rows[0]["ECGQRS"].ToString().Trim();

            if (dt.Rows[0]["LockStatus"].ToString() == "Locked")
            {
                Lock.Visible = false;
                btnSDV.Visible = false;
                Unlocked.Visible = true;
            }
            else
            {
                PageStatus();
            }
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select [LockStatus],[EntryStatus],[PISIGN] FROM [dbo].[tblPISignature]  where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and VISIT='" + lblVisit.Text + "' and PAGENAME='" + lblPage.Text + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            if (dt1.Rows[0]["PISIGN"].ToString() == "False")
            {
                btnSDV.Visible = true;
                Lock.Visible = false;
                Unlocked.Visible = false;
            }

            else if (dt1.Rows[0]["PISIGN"].ToString() == "True" && dt1.Rows[0]["LockStatus"].ToString() == "SDV")
            {
                btnSDV.Visible = false;
                Lock.Visible = true;
                Unlocked.Visible = false;
            }
            else if (dt1.Rows[0]["PISIGN"].ToString() == "True" && dt1.Rows[0]["LockStatus"].ToString() == "Unlocked")
            {
                btnSDV.Visible = true;
                Lock.Visible = false;
                Unlocked.Visible = false;
            }
            else if (dt1.Rows[0]["PISIGN"].ToString() == "True" && dt1.Rows[0]["LockStatus"].ToString() == "Locked")
            {
                btnSDV.Visible = false;
                Lock.Visible = false;
                Unlocked.Visible = true;
            }
        }
    }
    #endregion

    #region Note Acttchment and PageHistory
    #region AddNote
    private void SetImageAddNote()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from ADDNOTE  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            ImgAddNote.ImageUrl = "~/Study-Monitor/Images/NoteADD.png";
        }
        else
        {
            ImgAddNote.ImageUrl = "~/Study-Monitor/Images/BlankNote.png";

        }

        dr.Close();

        con.Close();
    }
    protected void ImgAddNote_Click(object sender, ImageClickEventArgs e)
    {
        if (ImgAddNote.ImageUrl == "~/BlankNote.png")
        {
            AddNote.Visible = true;
            AddNote.ShowPopupWindow();
            AddAddNoteGridview.Visible = false;
        }
        else
        {
            AddNote.Visible = true;
            AddNote.ShowPopupWindow();
            AddAddNoteGridview.Visible = true;
        }
    }
    protected void ADDAddNote_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();

        cmd = new SqlCommand("insert into ADDNOTE values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + AddNoteFiledTextBox.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','" + AddNoteTextBox.Text + "','" + null + "')", con);
        cmd.ExecuteNonQuery();


        NoteAddedDov.ShowPopupWindow();
        AddNote.Visible = false;
        AddNoteTextBox.Text = "";

    }
    protected void MycloseWindow(object sender, EventArgs e)
    {

    }
    private void BindGridviewAddNote()
    {
        DataSet ds = new DataSet();

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ADDNOTE where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            GridviewAddNote.DataSource = ds;
            GridviewAddNote.DataBind();
        }
    }
    protected void GridviewAddNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridviewAddNote.PageIndex = e.NewPageIndex;
        BindGridviewAddNote();
    }

    protected void GridviewAddNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // find student id of edit row
        string id = GridviewAddNote.DataKeys[e.RowIndex].Value.ToString();

        SqlCommand cmd = new SqlCommand("delete from ADDNOTE where ID=" + id, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        // Refresh the GridView
        BindGridviewAddNote();
    }
    #endregion
    #region AddAttachment

    private void SetImageAttach()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from ADDATTACHMENT  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            ImgAddAttachment.ImageUrl = "~/Study-Monitor/Images/AttachmentADD.png";
        }
        else
        {
            ImgAddAttachment.ImageUrl = "~/Study-Monitor/Images/BlankAttachment.png";

        }

        dr.Close();

        con.Close();
    }
    protected void ImgAddAttachment_Click(object sender, ImageClickEventArgs e)
    {
        if (ImgAddAttachment.ImageUrl == "BlankAttachment.png")
        {
            AddAttachment.Visible = true;
            AddAttachment.ShowPopupWindow();

            PanelADDAddAttachment.Visible = true;
            ADDAddAttachmentGridview.Visible = false;
        }
        else
        {
            AddAttachment.Visible = true;
            AddAttachment.ShowPopupWindow();

            PanelADDAddAttachment.Visible = true;
            ADDAddAttachmentGridview.Visible = true;
        }
    }
    protected void ADDAddAttachment_Click(object sender, EventArgs e)
    {

        string filename = Path.GetFileName(FileUploadADDAddAttachment.PostedFile.FileName);
        string contentType = FileUploadADDAddAttachment.PostedFile.ContentType;
        using (Stream fs = FileUploadADDAddAttachment.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "insert into ADDATTACHMENT values (@Site,@ScreenID,@SubInitial,@Visit,@Page,@Field,@Username,@Date,@Title,@Name,@ContentType,@Data,@SNO)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Site", lblCenterNumber.Text);
                        cmd.Parameters.AddWithValue("@ScreenID", lblScreeningNo.Text);
                        cmd.Parameters.AddWithValue("@SubInitial", lblSubjectInitial.Text);
                        cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                        cmd.Parameters.AddWithValue("@Page", lblPage.Text);
                        cmd.Parameters.AddWithValue("@Field", AddAttachmentFiledTextBox.Text);
                        cmd.Parameters.AddWithValue("@Username", LabelUserName.Text);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today.ToString("dd-MMM-yyyy"));
                        cmd.Parameters.AddWithValue("@Title", TextBoxADDAddAttachment.Text);
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Parameters.AddWithValue("@SNO", "");
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        TextBoxADDAddAttachment.Text = "";

                    }
                }
            }
        }

        AttachmentAddedDov.ShowPopupWindow();
        AddAttachment.Visible = false;

    }
    private void BindGridViewADDAddAttachment()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select ID,Site,ScreenID,SubInitial ,Visit,Page,Field,Username,Date,Title,Name ,ContentType,Data from ADDATTACHMENT where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'";
                cmd.Connection = con;
                con.Open();
                GridViewADDAddAttachment.DataSource = cmd.ExecuteReader();
                GridViewADDAddAttachment.DataBind();
                con.Close();
            }
        }

    }
    protected void DownloadFileAddAttachment(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name,Title, Data, ContentType from ADDATTACHMENT where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
    protected void GridViewADDAddAttachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // find student id of edit row
        string id = GridViewADDAddAttachment.DataKeys[e.RowIndex].Value.ToString();

        SqlCommand cmd = new SqlCommand("delete from ADDATTACHMENT where ID=" + id, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        // Refresh the GridView
        BindGridViewADDAddAttachment();
    }

    #endregion


    #region AttachmentPageHistory

    private void SetImageAttachPageHistory()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from tblReasonForChange  where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            AttachmentPageHistory.ImageUrl = "~/Study-Monitor/Images/PageHistory.png";
        }
        else
        {
            AttachmentPageHistory.ImageUrl = "~/Study-Monitor/Images/PHistory.png";

        }

        dr.Close();

        con.Close();
    }
    protected void AttachmentPageHistory_Click(object sender, ImageClickEventArgs e)
    {
        if (AttachmentPageHistory.ImageUrl == "BlankAttachment.png")
        {
            AttachmentPageHistory.Visible = true;
            PageHistory.ShowPopupWindow();
            ADDAttachmentPageHistoryGridview.Visible = false;
        }
        else
        {
            AttachmentPageHistory.Visible = true;
            PageHistory.ShowPopupWindow();
            ADDAttachmentPageHistoryGridview.Visible = true;
        }
    }

    private void BindGridViewADDAttachmentPageHistory()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT ID, [QuestionText],[OldValue],[NewValue],[Reason],[PageName],[EUser],[EDate] FROM [dbo].[tblReasonForChange] where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'";
                cmd.Connection = con;
                con.Open();
                GridViewADDAttachmentPageHistory.DataSource = cmd.ExecuteReader();
                GridViewADDAttachmentPageHistory.DataBind();
                con.Close();
            }
        }

    }

    #endregion

    #endregion

    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            con.Close();
            con1.Close();
            con.Open();
            con1.Open();
            cmd = new SqlCommand("Update tblQuery set  LockStatus = 'Locked'   where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
            cmd1 = new SqlCommand("Update [Visit1].[ECG] set  LockStatus = 'Locked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

            con2.Close();
            con2.Open();
            cmd2 = new SqlCommand("Update tblPISignature set  LockStatus = 'Locked'   where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and VISIT = '" + lblVisit.Text + "' and PAGENAME = '" + lblPage.Text + "'", con2);
            cmd2.ExecuteNonQuery();
            con2.Close();

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
            con1.Close();
            #region Audit Log Manage for Lock
            objAuditLog.UserName = Session["UserName"].ToString();
            objAuditLog.Role = Session["UserRoles"].ToString();
            objAuditLog.Action = "Lock";
            objAuditLog.PageName = lblPage.Text;
            objAuditLog.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            objAuditLog.Description = "Locked";
            objAuditLog.AuditLogManage();
            #endregion
            Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
        }


        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + lblPage.Text + " Page is not Locked!')", true);
        }
    }
    public void OnConfirm1(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            con.Close();
            con1.Close();
            con.Open();
            con1.Open();
            cmd = new SqlCommand("Update tblQuery set  LockStatus = 'SDV'   where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
            cmd1 = new SqlCommand("Update [Visit1].[ECG] set  LockStatus = 'SDV' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

            con2.Close();
            con2.Open();
            cmd2 = new SqlCommand("Update tblPISignature set  LockStatus = 'SDV'   where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and VISIT = '" + lblVisit.Text + "' and PAGENAME = '" + lblPage.Text + "'", con2);
            cmd2.ExecuteNonQuery();
            con2.Close();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
            con1.Close();
            #region Audit Log Manage for SDV
            objAuditLog.UserName = Session["UserName"].ToString();
            objAuditLog.Role = Session["UserRoles"].ToString();
            objAuditLog.Action = "SDV";
            objAuditLog.PageName = lblPage.Text;
            objAuditLog.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            objAuditLog.Description = "SDV";
            objAuditLog.AuditLogManage();
            #endregion
            Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + lblPage.Text + " Page is not SDV!')", true);
        }
    }
    public void OnConfirm2(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            con.Close();
            con1.Close();
            con.Open();
            con1.Open();
            cmd = new SqlCommand("Update tblQuery set  LockStatus = 'Unlocked'   where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
            cmd1 = new SqlCommand("Update [Visit1].[ECG] set  LockStatus = 'Unlocked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

            con2.Close();
            con2.Open();
            cmd2 = new SqlCommand("Update tblPISignature set  LockStatus = 'Unlocked'   where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and VISIT = '" + lblVisit.Text + "' and PAGENAME = '" + lblPage.Text + "'", con2);
            cmd2.ExecuteNonQuery();
            con2.Close();

            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
            con1.Close();
            #region Audit Log Manage for unlock
            objAuditLog.UserName = Session["UserName"].ToString();
            objAuditLog.Role = Session["UserRoles"].ToString();
            objAuditLog.Action = "Unlock";
            objAuditLog.PageName = lblPage.Text;
            objAuditLog.PageUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            objAuditLog.Description = "Unlocked";
            objAuditLog.AuditLogManage();
            #endregion
            Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + lblPage.Text + " Page is not Unlocked!')", true);
        }
    }

    #region Query
    #region QueryECGDAT
    private void SetImageQueryECGDAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGDAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGDAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGDAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGDAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGDAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGDAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECGDAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGDAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGDAT.Visible = true;
                PanelRaiseECGDAT2.Visible = false;
                PanelRaiseECGDAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECGDAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECGDAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECGDAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECGDAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGDAT.Visible = true;
                PanelRaiseECGDAT2.Visible = true;
                PanelRaiseECGDAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECGDAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGDAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECGDAT.Visible = true;
                PanelRaiseECGDAT2.Visible = true;
                PanelRaiseECGDAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECGDAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGDAT = '" + TextBoxECGDAT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGDAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGDAT.Visible = true;
                RAISEECGDAT.ShowPopupWindow();
                QueryRaiseECGDAT.Visible = true;
                TextBoxRaiseECGDAT.Visible = true;
                PanelRaiseECGDAT.Visible = false;
                PanelRaiseECGDAT2.Visible = false;
                PanelRaiseECGDAT3.Visible = false;

            }

            else if ((ImageQueryECGDAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGDAT.Visible = true;
                RAISEECGDAT.ShowPopupWindow();
                QueryRaiseECGDAT.Visible = false;
                TextBoxRaiseECGDAT.Visible = false;
            }

            else if ((ImageQueryECGDAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECGDAT.Visible = true;
                RespondedECGDAT.ShowPopupWindow();
            }
            else if ((ImageQueryECGDAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECGDAT.Visible = true;
                CloseECGDAT.ShowPopupWindow();
            }
            else
            {
                LockECGDAT.Visible = true;
                LockECGDAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECGDAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECGDAT.Text + "','" + TextBoxRaiseECGDAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGDAT = '" + TextBoxECGDAT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGDATMSG.ShowPopupWindow();
        RAISEECGDAT.Visible = false;
        QueryRaiseECGDAT.Visible = false;
        TextBoxRaiseECGDAT.Visible = false;

    }

    protected void CloseQueryECGDAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGDAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGDAT = '" + TextBoxECGDAT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECGDATMSG.ShowPopupWindow();
        RespondedECGDAT.Visible = false;
        RespondedECGDATClose.Visible = false;


    }

    protected void SubmitReRaiseECGDAT_Click(object sender, EventArgs e)
    {
        CloseECGDAT.Visible = false;

        RAISEECGDAT.Visible = true;
        RAISEECGDAT.ShowPopupWindow();
        QueryRaiseECGDAT.Visible = true;
        TextBoxRaiseECGDAT.Visible = true;


    }
    #endregion
    #region QueryECGFIND
    private void SetImageQueryECGFIND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGFIND.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGFIND.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGFIND.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGFIND.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGFIND.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECGFIND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGFIND.Visible = true;
                PanelRaiseECGFIND2.Visible = false;
                PanelRaiseECGFIND3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECGFIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECGFIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECGFIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECGFIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGFIND.Visible = true;
                PanelRaiseECGFIND2.Visible = true;
                PanelRaiseECGFIND3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECGFIND.Visible = true;
                PanelRaiseECGFIND2.Visible = true;
                PanelRaiseECGFIND3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECGFIND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGFIND = '" + TextBoxECGFIND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGFIND.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGFIND.Visible = true;
                RAISEECGFIND.ShowPopupWindow();
                QueryRaiseECGFIND.Visible = true;
                TextBoxRaiseECGFIND.Visible = true;
                PanelRaiseECGFIND.Visible = false;
                PanelRaiseECGFIND2.Visible = false;
                PanelRaiseECGFIND3.Visible = false;

            }

            else if ((ImageQueryECGFIND.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGFIND.Visible = true;
                RAISEECGFIND.ShowPopupWindow();
                QueryRaiseECGFIND.Visible = false;
                TextBoxRaiseECGFIND.Visible = false;
            }

            else if ((ImageQueryECGFIND.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECGFIND.Visible = true;
                RespondedECGFIND.ShowPopupWindow();
            }
            else if ((ImageQueryECGFIND.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECGFIND.Visible = true;
                CloseECGFIND.ShowPopupWindow();
            }
            else
            {
                LockECGFIND.Visible = true;
                LockECGFIND.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECGFIND_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECGFIND.Text + "','" + TextBoxRaiseECGFIND.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGFIND = '" + TextBoxECGFIND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGFINDMSG.ShowPopupWindow();
        RAISEECGFIND.Visible = false;
        QueryRaiseECGFIND.Visible = false;
        TextBoxRaiseECGFIND.Visible = false;

    }

    protected void CloseQueryECGFIND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGFIND.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGFIND = '" + TextBoxECGFIND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECGFINDMSG.ShowPopupWindow();
        RespondedECGFIND.Visible = false;
        RespondedECGFINDClose.Visible = false;


    }

    protected void SubmitReRaiseECGFIND_Click(object sender, EventArgs e)
    {
        CloseECGFIND.Visible = false;

        RAISEECGFIND.Visible = true;
        RAISEECGFIND.ShowPopupWindow();
        QueryRaiseECGFIND.Visible = true;
        TextBoxRaiseECGFIND.Visible = true;


    }
    #endregion
    #region QueryECG1RHM
    private void SetImageQueryECG1RHM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and Field = '" + lblECG1RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG1RHM.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG1RHM.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG1RHM.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG1RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG1RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECG1RHM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG1RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG1RHM.Visible = true;
                PanelRaiseECG1RHM2.Visible = false;
                PanelRaiseECG1RHM3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECG1RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECG1RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG1RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG1RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG1RHM.Visible = true;
                PanelRaiseECG1RHM2.Visible = true;
                PanelRaiseECG1RHM3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG1RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG1RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECG1RHM.Visible = true;
                PanelRaiseECG1RHM2.Visible = true;
                PanelRaiseECG1RHM3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECG1RHM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG1RHM = '" + chkECG1RHM.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG1RHM.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG1RHM.Visible = true;
                RAISEECG1RHM.ShowPopupWindow();
                QueryRaiseECG1RHM.Visible = true;
                TextBoxRaiseECG1RHM.Visible = true;
                PanelRaiseECG1RHM.Visible = false;
                PanelRaiseECG1RHM2.Visible = false;
                PanelRaiseECG1RHM3.Visible = false;

            }

            else if ((ImageQueryECG1RHM.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG1RHM.Visible = true;
                RAISEECG1RHM.ShowPopupWindow();
                QueryRaiseECG1RHM.Visible = false;
                TextBoxRaiseECG1RHM.Visible = false;
            }

            else if ((ImageQueryECG1RHM.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECG1RHM.Visible = true;
                RespondedECG1RHM.ShowPopupWindow();
            }
            else if ((ImageQueryECG1RHM.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECG1RHM.Visible = true;
                CloseECG1RHM.ShowPopupWindow();
            }
            else
            {
                LockECG1RHM.Visible = true;
                LockECG1RHM.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECG1RHM_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECG1RHM.Text + "','" + TextBoxRaiseECG1RHM.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG1RHM = '" + chkECG1RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG1RHMMSG.ShowPopupWindow();
        RAISEECG1RHM.Visible = false;
        QueryRaiseECG1RHM.Visible = false;
        TextBoxRaiseECG1RHM.Visible = false;

    }

    protected void CloseQueryECG1RHM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG1RHM.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG1RHM = '" + chkECG1RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECG1RHMMSG.ShowPopupWindow();
        RespondedECG1RHM.Visible = false;
        RespondedECG1RHMClose.Visible = false;


    }

    protected void SubmitReRaiseECG1RHM_Click(object sender, EventArgs e)
    {
        CloseECG1RHM.Visible = false;

        RAISEECG1RHM.Visible = true;
        RAISEECG1RHM.ShowPopupWindow();
        QueryRaiseECG1RHM.Visible = true;
        TextBoxRaiseECG1RHM.Visible = true;


    }
    #endregion
    #region QueryECG2RHM
    private void SetImageQueryECG2RHM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG2RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG2RHM.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG2RHM.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG2RHM.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG2RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG2RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECG2RHM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG2RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG2RHM.Visible = true;
                PanelRaiseECG2RHM2.Visible = false;
                PanelRaiseECG2RHM3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECG2RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECG2RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG2RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG2RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG2RHM.Visible = true;
                PanelRaiseECG2RHM2.Visible = true;
                PanelRaiseECG2RHM3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG2RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG2RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECG2RHM.Visible = true;
                PanelRaiseECG2RHM2.Visible = true;
                PanelRaiseECG2RHM3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECG2RHM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG2RHM = '" + chkECG2RHM.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG2RHM.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG2RHM.Visible = true;
                RAISEECG2RHM.ShowPopupWindow();
                QueryRaiseECG2RHM.Visible = true;
                TextBoxRaiseECG2RHM.Visible = true;
                PanelRaiseECG2RHM.Visible = false;
                PanelRaiseECG2RHM2.Visible = false;
                PanelRaiseECG2RHM3.Visible = false;

            }

            else if ((ImageQueryECG2RHM.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG2RHM.Visible = true;
                RAISEECG2RHM.ShowPopupWindow();
                QueryRaiseECG2RHM.Visible = false;
                TextBoxRaiseECG2RHM.Visible = false;
            }

            else if ((ImageQueryECG2RHM.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECG2RHM.Visible = true;
                RespondedECG2RHM.ShowPopupWindow();
            }
            else if ((ImageQueryECG2RHM.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECG2RHM.Visible = true;
                CloseECG2RHM.ShowPopupWindow();
            }
            else
            {
                LockECG2RHM.Visible = true;
                LockECG2RHM.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECG2RHM_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECG2RHM.Text + "','" + TextBoxRaiseECG2RHM.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG2RHM = '" + chkECG2RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG2RHMMSG.ShowPopupWindow();
        RAISEECG2RHM.Visible = false;
        QueryRaiseECG2RHM.Visible = false;
        TextBoxRaiseECG2RHM.Visible = false;

    }

    protected void CloseQueryECG2RHM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG2RHM.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG2RHM = '" + chkECG2RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECG2RHMMSG.ShowPopupWindow();
        RespondedECG2RHM.Visible = false;
        RespondedECG2RHMClose.Visible = false;


    }

    protected void SubmitReRaiseECG2RHM_Click(object sender, EventArgs e)
    {
        CloseECG2RHM.Visible = false;

        RAISEECG2RHM.Visible = true;
        RAISEECG2RHM.ShowPopupWindow();
        QueryRaiseECG2RHM.Visible = true;
        TextBoxRaiseECG2RHM.Visible = true;


    }
    #endregion
    #region QueryECG3RHM
    private void SetImageQueryECG3RHM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG3RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG3RHM.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG3RHM.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG3RHM.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG3RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG3RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECG3RHM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG3RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG3RHM.Visible = true;
                PanelRaiseECG3RHM2.Visible = false;
                PanelRaiseECG3RHM3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECG3RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECG3RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG3RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG3RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG3RHM.Visible = true;
                PanelRaiseECG3RHM2.Visible = true;
                PanelRaiseECG3RHM3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG3RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG3RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECG3RHM.Visible = true;
                PanelRaiseECG3RHM2.Visible = true;
                PanelRaiseECG3RHM3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECG3RHM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG3RHM = '" + chkECG3RHM.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG3RHM.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG3RHM.Visible = true;
                RAISEECG3RHM.ShowPopupWindow();
                QueryRaiseECG3RHM.Visible = true;
                TextBoxRaiseECG3RHM.Visible = true;
                PanelRaiseECG3RHM.Visible = false;
                PanelRaiseECG3RHM2.Visible = false;
                PanelRaiseECG3RHM3.Visible = false;

            }

            else if ((ImageQueryECG3RHM.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG3RHM.Visible = true;
                RAISEECG3RHM.ShowPopupWindow();
                QueryRaiseECG3RHM.Visible = false;
                TextBoxRaiseECG3RHM.Visible = false;
            }

            else if ((ImageQueryECG3RHM.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECG3RHM.Visible = true;
                RespondedECG3RHM.ShowPopupWindow();
            }
            else if ((ImageQueryECG3RHM.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECG3RHM.Visible = true;
                CloseECG3RHM.ShowPopupWindow();
            }
            else
            {
                LockECG3RHM.Visible = true;
                LockECG3RHM.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECG3RHM_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECG3RHM.Text + "','" + TextBoxRaiseECG3RHM.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG3RHM = '" + chkECG3RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG3RHMMSG.ShowPopupWindow();
        RAISEECG3RHM.Visible = false;
        QueryRaiseECG3RHM.Visible = false;
        TextBoxRaiseECG3RHM.Visible = false;

    }

    protected void CloseQueryECG3RHM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG3RHM.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG3RHM = '" + chkECG3RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECG3RHMMSG.ShowPopupWindow();
        RespondedECG3RHM.Visible = false;
        RespondedECG3RHMClose.Visible = false;


    }

    protected void SubmitReRaiseECG3RHM_Click(object sender, EventArgs e)
    {
        CloseECG3RHM.Visible = false;

        RAISEECG3RHM.Visible = true;
        RAISEECG3RHM.ShowPopupWindow();
        QueryRaiseECG3RHM.Visible = true;
        TextBoxRaiseECG3RHM.Visible = true;


    }
    #endregion
    #region QueryECG4RHM
    private void SetImageQueryECG4RHM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG4RHM.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG4RHM.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG4RHM.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG4RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG4RHM.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECG4RHM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4RHM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG4RHM.Visible = true;
                PanelRaiseECG4RHM2.Visible = false;
                PanelRaiseECG4RHM3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECG4RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECG4RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG4RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG4RHM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG4RHM.Visible = true;
                PanelRaiseECG4RHM2.Visible = true;
                PanelRaiseECG4RHM3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG4RHM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG4RHM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECG4RHM.Visible = true;
                PanelRaiseECG4RHM2.Visible = true;
                PanelRaiseECG4RHM3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECG4RHM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4RHM = '" + chkECG4RHM.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG4RHM.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG4RHM.Visible = true;
                RAISEECG4RHM.ShowPopupWindow();
                QueryRaiseECG4RHM.Visible = true;
                TextBoxRaiseECG4RHM.Visible = true;
                PanelRaiseECG4RHM.Visible = false;
                PanelRaiseECG4RHM2.Visible = false;
                PanelRaiseECG4RHM3.Visible = false;

            }

            else if ((ImageQueryECG4RHM.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG4RHM.Visible = true;
                RAISEECG4RHM.ShowPopupWindow();
                QueryRaiseECG4RHM.Visible = false;
                TextBoxRaiseECG4RHM.Visible = false;
            }

            else if ((ImageQueryECG4RHM.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECG4RHM.Visible = true;
                RespondedECG4RHM.ShowPopupWindow();
            }
            else if ((ImageQueryECG4RHM.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECG4RHM.Visible = true;
                CloseECG4RHM.ShowPopupWindow();
            }
            else
            {
                LockECG4RHM.Visible = true;
                LockECG4RHM.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECG4RHM_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECG4RHM.Text + "','" + TextBoxRaiseECG4RHM.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4RHM = '" + chkECG4RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG4RHMMSG.ShowPopupWindow();
        RAISEECG4RHM.Visible = false;
        QueryRaiseECG4RHM.Visible = false;
        TextBoxRaiseECG4RHM.Visible = false;

    }

    protected void CloseQueryECG4RHM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4RHM.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4RHM = '" + chkECG4RHM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECG4RHMMSG.ShowPopupWindow();
        RespondedECG4RHM.Visible = false;
        RespondedECG4RHMClose.Visible = false;


    }

    protected void SubmitReRaiseECG4RHM_Click(object sender, EventArgs e)
    {
        CloseECG4RHM.Visible = false;

        RAISEECG4RHM.Visible = true;
        RAISEECG4RHM.ShowPopupWindow();
        QueryRaiseECG4RHM.Visible = true;
        TextBoxRaiseECG4RHM.Visible = true;


    }
    #endregion
    #region QueryECG4OTR
    private void SetImageQueryECG4OTR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4OTR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG4OTR.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG4OTR.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG4OTR.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG4OTR.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG4OTR.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECG4OTR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4OTR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG4OTR.Visible = true;
                PanelRaiseECG4OTR2.Visible = false;
                PanelRaiseECG4OTR3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECG4OTR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECG4OTR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG4OTR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG4OTR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG4OTR.Visible = true;
                PanelRaiseECG4OTR2.Visible = true;
                PanelRaiseECG4OTR3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECG4OTR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECG4OTR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECG4OTR.Visible = true;
                PanelRaiseECG4OTR2.Visible = true;
                PanelRaiseECG4OTR3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECG4OTR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4OTR = '" + TextBoxECG4OTR.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG4OTR.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG4OTR.Visible = true;
                RAISEECG4OTR.ShowPopupWindow();
                QueryRaiseECG4OTR.Visible = true;
                TextBoxRaiseECG4OTR.Visible = true;
                PanelRaiseECG4OTR.Visible = false;
                PanelRaiseECG4OTR2.Visible = false;
                PanelRaiseECG4OTR3.Visible = false;

            }

            else if ((ImageQueryECG4OTR.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG4OTR.Visible = true;
                RAISEECG4OTR.ShowPopupWindow();
                QueryRaiseECG4OTR.Visible = false;
                TextBoxRaiseECG4OTR.Visible = false;
            }

            else if ((ImageQueryECG4OTR.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECG4OTR.Visible = true;
                RespondedECG4OTR.ShowPopupWindow();
            }
            else if ((ImageQueryECG4OTR.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECG4OTR.Visible = true;
                CloseECG4OTR.ShowPopupWindow();
            }
            else
            {
                LockECG4OTR.Visible = true;
                LockECG4OTR.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECG4OTR_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECG4OTR.Text + "','" + TextBoxRaiseECG4OTR.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4OTR = '" + TextBoxECG4OTR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG4OTRMSG.ShowPopupWindow();
        RAISEECG4OTR.Visible = false;
        QueryRaiseECG4OTR.Visible = false;
        TextBoxRaiseECG4OTR.Visible = false;

    }

    protected void CloseQueryECG4OTR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4OTR.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4OTR = '" + TextBoxECG4OTR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECG4OTRMSG.ShowPopupWindow();
        RespondedECG4OTR.Visible = false;
        RespondedECG4OTRClose.Visible = false;


    }

    protected void SubmitReRaiseECG4OTR_Click(object sender, EventArgs e)
    {
        CloseECG4OTR.Visible = false;

        RAISEECG4OTR.Visible = true;
        RAISEECG4OTR.ShowPopupWindow();
        QueryRaiseECG4OTR.Visible = true;
        TextBoxRaiseECG4OTR.Visible = true;


    }
    #endregion
    #region QueryECGQRS
    private void SetImageQueryECGQRS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGQRS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGQRS.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGQRS.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGQRS.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGQRS.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGQRS.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataECGQRS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGQRS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGQRS.Visible = true;
                PanelRaiseECGQRS2.Visible = false;
                PanelRaiseECGQRS3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseECGQRS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedECGQRS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECGQRS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECGQRS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGQRS.Visible = true;
                PanelRaiseECGQRS2.Visible = true;
                PanelRaiseECGQRS3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockECGQRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockECGQRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseECGQRS.Visible = true;
                PanelRaiseECGQRS2.Visible = true;
                PanelRaiseECGQRS3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryECGQRS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGQRS = '" + RadioButtonListECGQRS.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGQRS.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGQRS.Visible = true;
                RAISEECGQRS.ShowPopupWindow();
                QueryRaiseECGQRS.Visible = true;
                TextBoxRaiseECGQRS.Visible = true;
                PanelRaiseECGQRS.Visible = false;
                PanelRaiseECGQRS2.Visible = false;
                PanelRaiseECGQRS3.Visible = false;

            }

            else if ((ImageQueryECGQRS.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGQRS.Visible = true;
                RAISEECGQRS.ShowPopupWindow();
                QueryRaiseECGQRS.Visible = false;
                TextBoxRaiseECGQRS.Visible = false;
            }

            else if ((ImageQueryECGQRS.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedECGQRS.Visible = true;
                RespondedECGQRS.ShowPopupWindow();
            }
            else if ((ImageQueryECGQRS.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseECGQRS.Visible = true;
                CloseECGQRS.ShowPopupWindow();
            }
            else
            {
                LockECGQRS.Visible = true;
                LockECGQRS.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseECGQRS_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblECGQRS.Text + "','" + TextBoxRaiseECGQRS.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGQRS = '" + RadioButtonListECGQRS.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGQRSMSG.ShowPopupWindow();
        RAISEECGQRS.Visible = false;
        QueryRaiseECGQRS.Visible = false;
        TextBoxRaiseECGQRS.Visible = false;

    }

    protected void CloseQueryECGQRS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGQRS.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[ECG] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGQRS = '" + RadioButtonListECGQRS.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEECGQRSMSG.ShowPopupWindow();
        RespondedECGQRS.Visible = false;
        RespondedECGQRSClose.Visible = false;


    }

    protected void SubmitReRaiseECGQRS_Click(object sender, EventArgs e)
    {
        CloseECGQRS.Visible = false;

        RAISEECGQRS.Visible = true;
        RAISEECGQRS.ShowPopupWindow();
        QueryRaiseECGQRS.Visible = true;
        TextBoxRaiseECGQRS.Visible = true;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }
}