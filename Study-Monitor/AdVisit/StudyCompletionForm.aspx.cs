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

public partial class Study_Monitor_AdVisit_StudyCompletionForm : System.Web.UI.Page
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
            PageStatus();
            ViewState["oldData"] = dt;

        }
        SetImageAddNote();
        BindGridviewAddNote();
        SetImageAttach();
        BindGridViewADDAddAttachment();

        SetImageAttachPageHistory();
        BindGridViewADDAttachmentPageHistory();
       
        SetImageQuerySCFYN();
        BindQueryDataSCFYN();

        SetImageQuerySCFDSCF();
        BindQueryDataSCFDSCF();

        SetImageQuerySCFRSN();
        BindQueryDataSCFRSN();

        SetImageQuerySCFDOFLC();
        BindQueryDataSCFDOFLC();

        SetImageQuerySCFRSNDT();
        BindQueryDataSCFRSNDT();

        SetImageQuerySCFRSNSPY();
        BindQueryDataSCFRSNSPY();

        TextBoxSCFDSCF_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxSCFDOFLC_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxSCFRSNDT_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        ShowHide();
    }
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

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT SCFYN ,SCFDSCF ,SCFRSN ,SCFDOFLC ,SCFRSNDT ,SCFRSNSPY ,LockStatus FROM [Add].[StudyCompletionForm] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        { 
            RadioButtonListSCFYN.SelectedValue = dt.Rows[0]["SCFYN"].ToString();
            TextBoxSCFDSCF.Text = dt.Rows[0]["SCFDSCF"].ToString();
            RadioButtonListSCFRSN.SelectedValue = dt.Rows[0]["SCFRSN"].ToString();
            TextBoxSCFDOFLC.Text = dt.Rows[0]["SCFDOFLC"].ToString();
            TextBoxSCFRSNDT.Text = dt.Rows[0]["SCFRSNDT"].ToString();
            TextBoxSCFRSNSPY.Text = dt.Rows[0]["SCFRSNSPY"].ToString();

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
        SqlCommand sqlCmd = new SqlCommand("Select [LockStatus],[EntryStatus],[PISIGN] FROM [dbo].[tblPISignature] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and VISIT='" + lblVisit.Text + "' and PAGENAME='" + lblPage.Text + "'", con);
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
            cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  LockStatus = 'Locked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

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
            cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  LockStatus = 'SDV' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

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
            cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  LockStatus = 'Unlocked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

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
    #region QuerySCFYN
    private void SetImageQuerySCFYN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFYN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySCFYN.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySCFYN.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySCFYN.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQuerySCFYN.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySCFYN.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataSCFYN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFYN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSCFYN.Visible = true;
                PanelRaiseSCFYN2.Visible = false;
                PanelRaiseSCFYN3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseSCFYN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedSCFYN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFYN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFYN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSCFYN.Visible = true;
                PanelRaiseSCFYN2.Visible = true;
                PanelRaiseSCFYN3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseSCFYN.Visible = true;
                PanelRaiseSCFYN2.Visible = true;
                PanelRaiseSCFYN3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQuerySCFYN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[StudyCompletionForm] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFYN = '" + RadioButtonListSCFYN.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySCFYN.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESCFYN.Visible = true;
                RAISESCFYN.ShowPopupWindow();
                QueryRaiseSCFYN.Visible = true;
                TextBoxRaiseSCFYN.Visible = true;
                PanelRaiseSCFYN.Visible = false;
                PanelRaiseSCFYN2.Visible = false;
                PanelRaiseSCFYN3.Visible = false;

            }

            else if ((ImageQuerySCFYN.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESCFYN.Visible = true;
                RAISESCFYN.ShowPopupWindow();
                QueryRaiseSCFYN.Visible = false;
                TextBoxRaiseSCFYN.Visible = false;
            }

            else if ((ImageQuerySCFYN.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedSCFYN.Visible = true;
                RespondedSCFYN.ShowPopupWindow();
            }
            else if ((ImageQuerySCFYN.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseSCFYN.Visible = true;
                CloseSCFYN.ShowPopupWindow();
            }
            else
            {
                LockSCFYN.Visible = true;
                LockSCFYN.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseSCFYN_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblSCFYN.Text + "','" + TextBoxRaiseSCFYN.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFYN = '" + RadioButtonListSCFYN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESCFYNMSG.ShowPopupWindow();
        RAISESCFYN.Visible = false;
        QueryRaiseSCFYN.Visible = false;
        TextBoxRaiseSCFYN.Visible = false;

    }

    protected void CloseQuerySCFYN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFYN.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFYN = '" + RadioButtonListSCFYN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSESCFYNMSG.ShowPopupWindow();
        RespondedSCFYN.Visible = false;
        RespondedSCFYNClose.Visible = false;


    }

    protected void SubmitReRaiseSCFYN_Click(object sender, EventArgs e)
    {
        CloseSCFYN.Visible = false;

        RAISESCFYN.Visible = true;
        RAISESCFYN.ShowPopupWindow();
        QueryRaiseSCFYN.Visible = true;
        TextBoxRaiseSCFYN.Visible = true;


    }
    #endregion
    #region QuerySCFDSCF
    private void SetImageQuerySCFDSCF()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFDSCF.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySCFDSCF.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySCFDSCF.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySCFDSCF.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQuerySCFDSCF.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySCFDSCF.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataSCFDSCF()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFDSCF.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSCFDSCF.Visible = true;
                PanelRaiseSCFDSCF2.Visible = false;
                PanelRaiseSCFDSCF3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseSCFDSCF3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedSCFDSCF3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFDSCF3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFDSCF3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSCFDSCF.Visible = true;
                PanelRaiseSCFDSCF2.Visible = true;
                PanelRaiseSCFDSCF3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFDSCF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFDSCF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseSCFDSCF.Visible = true;
                PanelRaiseSCFDSCF2.Visible = true;
                PanelRaiseSCFDSCF3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQuerySCFDSCF_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[StudyCompletionForm] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFDSCF = '" + TextBoxSCFDSCF.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySCFDSCF.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESCFDSCF.Visible = true;
                RAISESCFDSCF.ShowPopupWindow();
                QueryRaiseSCFDSCF.Visible = true;
                TextBoxRaiseSCFDSCF.Visible = true;
                PanelRaiseSCFDSCF.Visible = false;
                PanelRaiseSCFDSCF2.Visible = false;
                PanelRaiseSCFDSCF3.Visible = false;

            }

            else if ((ImageQuerySCFDSCF.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESCFDSCF.Visible = true;
                RAISESCFDSCF.ShowPopupWindow();
                QueryRaiseSCFDSCF.Visible = false;
                TextBoxRaiseSCFDSCF.Visible = false;
            }

            else if ((ImageQuerySCFDSCF.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedSCFDSCF.Visible = true;
                RespondedSCFDSCF.ShowPopupWindow();
            }
            else if ((ImageQuerySCFDSCF.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseSCFDSCF.Visible = true;
                CloseSCFDSCF.ShowPopupWindow();
            }
            else
            {
                LockSCFDSCF.Visible = true;
                LockSCFDSCF.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseSCFDSCF_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblSCFDSCF.Text + "','" + TextBoxRaiseSCFDSCF.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFDSCF = '" + TextBoxSCFDSCF.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESCFDSCFMSG.ShowPopupWindow();
        RAISESCFDSCF.Visible = false;
        QueryRaiseSCFDSCF.Visible = false;
        TextBoxRaiseSCFDSCF.Visible = false;

    }

    protected void CloseQuerySCFDSCF_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFDSCF.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFDSCF = '" + TextBoxSCFDSCF.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSESCFDSCFMSG.ShowPopupWindow();
        RespondedSCFDSCF.Visible = false;
        RespondedSCFDSCFClose.Visible = false;


    }

    protected void SubmitReRaiseSCFDSCF_Click(object sender, EventArgs e)
    {
        CloseSCFDSCF.Visible = false;

        RAISESCFDSCF.Visible = true;
        RAISESCFDSCF.ShowPopupWindow();
        QueryRaiseSCFDSCF.Visible = true;
        TextBoxRaiseSCFDSCF.Visible = true;


    }
    #endregion
    #region QuerySCFRSN
    private void SetImageQuerySCFRSN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySCFRSN.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySCFRSN.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySCFRSN.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQuerySCFRSN.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySCFRSN.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataSCFRSN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSCFRSN.Visible = true;
                PanelRaiseSCFRSN2.Visible = false;
                PanelRaiseSCFRSN3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseSCFRSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedSCFRSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFRSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFRSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSCFRSN.Visible = true;
                PanelRaiseSCFRSN2.Visible = true;
                PanelRaiseSCFRSN3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseSCFRSN.Visible = true;
                PanelRaiseSCFRSN2.Visible = true;
                PanelRaiseSCFRSN3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQuerySCFRSN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[StudyCompletionForm] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSN = '" + RadioButtonListSCFRSN.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySCFRSN.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESCFRSN.Visible = true;
                RAISESCFRSN.ShowPopupWindow();
                QueryRaiseSCFRSN.Visible = true;
                TextBoxRaiseSCFRSN.Visible = true;
                PanelRaiseSCFRSN.Visible = false;
                PanelRaiseSCFRSN2.Visible = false;
                PanelRaiseSCFRSN3.Visible = false;

            }

            else if ((ImageQuerySCFRSN.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESCFRSN.Visible = true;
                RAISESCFRSN.ShowPopupWindow();
                QueryRaiseSCFRSN.Visible = false;
                TextBoxRaiseSCFRSN.Visible = false;
            }

            else if ((ImageQuerySCFRSN.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedSCFRSN.Visible = true;
                RespondedSCFRSN.ShowPopupWindow();
            }
            else if ((ImageQuerySCFRSN.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseSCFRSN.Visible = true;
                CloseSCFRSN.ShowPopupWindow();
            }
            else
            {
                LockSCFRSN.Visible = true;
                LockSCFRSN.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseSCFRSN_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblSCFRSN.Text + "','" + TextBoxRaiseSCFRSN.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSN = '" + RadioButtonListSCFRSN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESCFRSNMSG.ShowPopupWindow();
        RAISESCFRSN.Visible = false;
        QueryRaiseSCFRSN.Visible = false;
        TextBoxRaiseSCFRSN.Visible = false;

    }

    protected void CloseQuerySCFRSN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSN.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSN = '" + RadioButtonListSCFRSN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSESCFRSNMSG.ShowPopupWindow();
        RespondedSCFRSN.Visible = false;
        RespondedSCFRSNClose.Visible = false;


    }

    protected void SubmitReRaiseSCFRSN_Click(object sender, EventArgs e)
    {
        CloseSCFRSN.Visible = false;

        RAISESCFRSN.Visible = true;
        RAISESCFRSN.ShowPopupWindow();
        QueryRaiseSCFRSN.Visible = true;
        TextBoxRaiseSCFRSN.Visible = true;


    }
    #endregion
    #region QuerySCFDOFLC
    private void SetImageQuerySCFDOFLC()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFDOFLC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySCFDOFLC.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySCFDOFLC.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySCFDOFLC.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQuerySCFDOFLC.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySCFDOFLC.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataSCFDOFLC()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFDOFLC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSCFDOFLC.Visible = true;
                PanelRaiseSCFDOFLC2.Visible = false;
                PanelRaiseSCFDOFLC3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseSCFDOFLC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedSCFDOFLC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFDOFLC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFDOFLC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSCFDOFLC.Visible = true;
                PanelRaiseSCFDOFLC2.Visible = true;
                PanelRaiseSCFDOFLC3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFDOFLC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFDOFLC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseSCFDOFLC.Visible = true;
                PanelRaiseSCFDOFLC2.Visible = true;
                PanelRaiseSCFDOFLC3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQuerySCFDOFLC_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[StudyCompletionForm] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFDOFLC = '" + TextBoxSCFDOFLC.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySCFDOFLC.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESCFDOFLC.Visible = true;
                RAISESCFDOFLC.ShowPopupWindow();
                QueryRaiseSCFDOFLC.Visible = true;
                TextBoxRaiseSCFDOFLC.Visible = true;
                PanelRaiseSCFDOFLC.Visible = false;
                PanelRaiseSCFDOFLC2.Visible = false;
                PanelRaiseSCFDOFLC3.Visible = false;

            }

            else if ((ImageQuerySCFDOFLC.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESCFDOFLC.Visible = true;
                RAISESCFDOFLC.ShowPopupWindow();
                QueryRaiseSCFDOFLC.Visible = false;
                TextBoxRaiseSCFDOFLC.Visible = false;
            }

            else if ((ImageQuerySCFDOFLC.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedSCFDOFLC.Visible = true;
                RespondedSCFDOFLC.ShowPopupWindow();
            }
            else if ((ImageQuerySCFDOFLC.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseSCFDOFLC.Visible = true;
                CloseSCFDOFLC.ShowPopupWindow();
            }
            else
            {
                LockSCFDOFLC.Visible = true;
                LockSCFDOFLC.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseSCFDOFLC_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblSCFDOFLC.Text + "','" + TextBoxRaiseSCFDOFLC.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFDOFLC = '" + TextBoxSCFDOFLC.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESCFDOFLCMSG.ShowPopupWindow();
        RAISESCFDOFLC.Visible = false;
        QueryRaiseSCFDOFLC.Visible = false;
        TextBoxRaiseSCFDOFLC.Visible = false;

    }

    protected void CloseQuerySCFDOFLC_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFDOFLC.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFDOFLC = '" + TextBoxSCFDOFLC.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSESCFDOFLCMSG.ShowPopupWindow();
        RespondedSCFDOFLC.Visible = false;
        RespondedSCFDOFLCClose.Visible = false;


    }

    protected void SubmitReRaiseSCFDOFLC_Click(object sender, EventArgs e)
    {
        CloseSCFDOFLC.Visible = false;

        RAISESCFDOFLC.Visible = true;
        RAISESCFDOFLC.ShowPopupWindow();
        QueryRaiseSCFDOFLC.Visible = true;
        TextBoxRaiseSCFDOFLC.Visible = true;


    }
    #endregion
    #region QuerySCFRSNDT
    private void SetImageQuerySCFRSNDT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSNDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySCFRSNDT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySCFRSNDT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySCFRSNDT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQuerySCFRSNDT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySCFRSNDT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataSCFRSNDT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSNDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSCFRSNDT.Visible = true;
                PanelRaiseSCFRSNDT2.Visible = false;
                PanelRaiseSCFRSNDT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseSCFRSNDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedSCFRSNDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFRSNDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFRSNDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSCFRSNDT.Visible = true;
                PanelRaiseSCFRSNDT2.Visible = true;
                PanelRaiseSCFRSNDT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFRSNDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSNDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseSCFRSNDT.Visible = true;
                PanelRaiseSCFRSNDT2.Visible = true;
                PanelRaiseSCFRSNDT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQuerySCFRSNDT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[StudyCompletionForm] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSNDT = '" + TextBoxSCFRSNDT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySCFRSNDT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESCFRSNDT.Visible = true;
                RAISESCFRSNDT.ShowPopupWindow();
                QueryRaiseSCFRSNDT.Visible = true;
                TextBoxRaiseSCFRSNDT.Visible = true;
                PanelRaiseSCFRSNDT.Visible = false;
                PanelRaiseSCFRSNDT2.Visible = false;
                PanelRaiseSCFRSNDT3.Visible = false;

            }

            else if ((ImageQuerySCFRSNDT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESCFRSNDT.Visible = true;
                RAISESCFRSNDT.ShowPopupWindow();
                QueryRaiseSCFRSNDT.Visible = false;
                TextBoxRaiseSCFRSNDT.Visible = false;
            }

            else if ((ImageQuerySCFRSNDT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedSCFRSNDT.Visible = true;
                RespondedSCFRSNDT.ShowPopupWindow();
            }
            else if ((ImageQuerySCFRSNDT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseSCFRSNDT.Visible = true;
                CloseSCFRSNDT.ShowPopupWindow();
            }
            else
            {
                LockSCFRSNDT.Visible = true;
                LockSCFRSNDT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseSCFRSNDT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblSCFRSNDT.Text + "','" + TextBoxRaiseSCFRSNDT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSNDT = '" + TextBoxSCFRSNDT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESCFRSNDTMSG.ShowPopupWindow();
        RAISESCFRSNDT.Visible = false;
        QueryRaiseSCFRSNDT.Visible = false;
        TextBoxRaiseSCFRSNDT.Visible = false;

    }

    protected void CloseQuerySCFRSNDT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSNDT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSNDT = '" + TextBoxSCFRSNDT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSESCFRSNDTMSG.ShowPopupWindow();
        RespondedSCFRSNDT.Visible = false;
        RespondedSCFRSNDTClose.Visible = false;


    }

    protected void SubmitReRaiseSCFRSNDT_Click(object sender, EventArgs e)
    {
        CloseSCFRSNDT.Visible = false;

        RAISESCFRSNDT.Visible = true;
        RAISESCFRSNDT.ShowPopupWindow();
        QueryRaiseSCFRSNDT.Visible = true;
        TextBoxRaiseSCFRSNDT.Visible = true;


    }
    #endregion
    #region QuerySCFRSNSPY
    private void SetImageQuerySCFRSNSPY()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSNSPY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySCFRSNSPY.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySCFRSNSPY.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySCFRSNSPY.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQuerySCFRSNSPY.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySCFRSNSPY.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataSCFRSNSPY()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSNSPY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSCFRSNSPY.Visible = true;
                PanelRaiseSCFRSNSPY2.Visible = false;
                PanelRaiseSCFRSNSPY3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseSCFRSNSPY3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedSCFRSNSPY3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFRSNSPY3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFRSNSPY3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSCFRSNSPY.Visible = true;
                PanelRaiseSCFRSNSPY2.Visible = true;
                PanelRaiseSCFRSNSPY3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockSCFRSNSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockSCFRSNSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseSCFRSNSPY.Visible = true;
                PanelRaiseSCFRSNSPY2.Visible = true;
                PanelRaiseSCFRSNSPY3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQuerySCFRSNSPY_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[StudyCompletionForm] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSNSPY = '" + TextBoxSCFRSNSPY.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySCFRSNSPY.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESCFRSNSPY.Visible = true;
                RAISESCFRSNSPY.ShowPopupWindow();
                QueryRaiseSCFRSNSPY.Visible = true;
                TextBoxRaiseSCFRSNSPY.Visible = true;
                PanelRaiseSCFRSNSPY.Visible = false;
                PanelRaiseSCFRSNSPY2.Visible = false;
                PanelRaiseSCFRSNSPY3.Visible = false;

            }

            else if ((ImageQuerySCFRSNSPY.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESCFRSNSPY.Visible = true;
                RAISESCFRSNSPY.ShowPopupWindow();
                QueryRaiseSCFRSNSPY.Visible = false;
                TextBoxRaiseSCFRSNSPY.Visible = false;
            }

            else if ((ImageQuerySCFRSNSPY.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedSCFRSNSPY.Visible = true;
                RespondedSCFRSNSPY.ShowPopupWindow();
            }
            else if ((ImageQuerySCFRSNSPY.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseSCFRSNSPY.Visible = true;
                CloseSCFRSNSPY.ShowPopupWindow();
            }
            else
            {
                LockSCFRSNSPY.Visible = true;
                LockSCFRSNSPY.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseSCFRSNSPY_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblSCFRSNSPY.Text + "','" + TextBoxRaiseSCFRSNSPY.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSNSPY = '" + TextBoxSCFRSNSPY.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESCFRSNSPYMSG.ShowPopupWindow();
        RAISESCFRSNSPY.Visible = false;
        QueryRaiseSCFRSNSPY.Visible = false;
        TextBoxRaiseSCFRSNSPY.Visible = false;

    }

    protected void CloseQuerySCFRSNSPY_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSCFRSNSPY.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[StudyCompletionForm] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SCFRSNSPY = '" + TextBoxSCFRSNSPY.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSESCFRSNSPYMSG.ShowPopupWindow();
        RespondedSCFRSNSPY.Visible = false;
        RespondedSCFRSNSPYClose.Visible = false;


    }

    protected void SubmitReRaiseSCFRSNSPY_Click(object sender, EventArgs e)
    {
        CloseSCFRSNSPY.Visible = false;

        RAISESCFRSNSPY.Visible = true;
        RAISESCFRSNSPY.ShowPopupWindow();
        QueryRaiseSCFRSNSPY.Visible = true;
        TextBoxRaiseSCFRSNSPY.Visible = true;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }


    protected void ShowHide()
    {
        if (RadioButtonListSCFYN.SelectedValue == "Yes")
        {
            hideSCFDSCF.Visible = true;
            hide1.Visible = false;
        }
        else if (RadioButtonListSCFYN.SelectedValue == "No")
        {
            hideSCFDSCF.Visible = false;
            hide1.Visible = true;
        }
    }

    protected void RadioButtonListSCFYN_SelectedIndexChanged(object sender, EventArgs e)
    {
       if(RadioButtonListSCFYN.SelectedValue == "Yes")
        {
            hideSCFDSCF.Visible = true;
            hide1.Visible = false;
            TextBoxSCFDOFLC.Text = string.Empty;
            RadioButtonListSCFRSN.ClearSelection();
            TextBoxSCFRSNDT.Text = string.Empty;
            TextBoxSCFRSNSPY.Text = string.Empty;
        }
        else if (RadioButtonListSCFYN.SelectedValue == "No")
        {
            hideSCFDSCF.Visible = false;
            TextBoxSCFDSCF.Text = string.Empty;
            hide1.Visible = true;
        }
    }
}