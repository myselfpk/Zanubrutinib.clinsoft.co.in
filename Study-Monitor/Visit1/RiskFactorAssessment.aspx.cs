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

public partial class Study_Monitor_Visit1_RiskFactorAssessment : System.Web.UI.Page
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

        SetImageQueryDURA1OPT();
        BindQueryDataDURA1OPT();
        SetImageQueryDURA2OPT();
        BindQueryDataDURA2OPT();
        SetImageQueryDURA3OPT();
        BindQueryDataDURA3OPT();
        SetImageQueryDURA4OPT();
        BindQueryDataDURA4OPT();
        SetImageQueryDURA5OPT();
        BindQueryDataDURA5OPT();
        SetImageQueryDURA6OPT();
        BindQueryDataDURA6OPT();
        SetImageQueryDURA7OPT();
        BindQueryDataDURA7OPT();
        SetImageQueryDURA8OPT();
        BindQueryDataDURA8OPT();
        SetImageQueryDURA9OPT();
        BindQueryDataDURA9OPT();
        SetImageQueryDURA10OPT();
        BindQueryDataDURA10OPT();
        SetImageQueryDURA11OPT();
        BindQueryDataDURA11OPT();
        SetImageQueryDURA12OPT();
        BindQueryDataDURA12OPT();
        SetImageQueryDURA13OPT();
        BindQueryDataDURA13OPT();
        SetImageQueryDURA14OPT();
        BindQueryDataDURA14OPT();
        SetImageQueryDURA15OPT();
        BindQueryDataDURA15OPT();
        SetImageQueryDURA16OPT();
        BindQueryDataDURA16OPT();
        SetImageQueryDURA17OPT();
        BindQueryDataDURA17OPT();
        SetImageQueryDURA18OPT();
        BindQueryDataDURA18OPT();
        SetImageQueryDURA19OPT();
        BindQueryDataDURA19OPT();
        SetImageQueryDURA20OPT();
        BindQueryDataDURA20OPT();

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
        con.Close();
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
        SqlCommand sqlCmd = new SqlCommand("SELECT DURA1OPT ,DURA2OPT ,DURA3OPT ,DURA4OPT ,DURA5OPT ,DURA6OPT ,DURA7OPT ,DURA8OPT ,DURA9OPT ,DURA10OPT ,DURA11OPT ,DURA12OPT ,DURA13OPT ,DURA14OPT ,DURA15OPT ,DURA16OPT,RFA17OPT ,DURA17OPT ,RFA18OPT ,DURA18OPT ,RFA19OPT ,DURA19OPT ,RFA20OPT ,DURA20OPT, LockStatus FROM [Visit1].[RiskFactorAssessment] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxDURA1OPT.Text = dt.Rows[0]["DURA1OPT"].ToString();
            TextBoxDURA2OPT.Text = dt.Rows[0]["DURA2OPT"].ToString();
            TextBoxDURA3OPT.Text = dt.Rows[0]["DURA3OPT"].ToString();
            TextBoxDURA4OPT.Text = dt.Rows[0]["DURA4OPT"].ToString();
            TextBoxDURA5OPT.Text = dt.Rows[0]["DURA5OPT"].ToString();
            TextBoxDURA6OPT.Text = dt.Rows[0]["DURA6OPT"].ToString();
            TextBoxDURA7OPT.Text = dt.Rows[0]["DURA7OPT"].ToString();
            TextBoxDURA8OPT.Text = dt.Rows[0]["DURA8OPT"].ToString();
            TextBoxDURA9OPT.Text = dt.Rows[0]["DURA9OPT"].ToString();
            TextBoxDURA10OPT.Text = dt.Rows[0]["DURA10OPT"].ToString();
            TextBoxDURA11OPT.Text = dt.Rows[0]["DURA11OPT"].ToString();
            TextBoxDURA12OPT.Text = dt.Rows[0]["DURA12OPT"].ToString();
            TextBoxDURA13OPT.Text = dt.Rows[0]["DURA13OPT"].ToString();
            TextBoxDURA14OPT.Text = dt.Rows[0]["DURA14OPT"].ToString();
            TextBoxDURA15OPT.Text = dt.Rows[0]["DURA15OPT"].ToString();
            TextBoxDURA16OPT.Text = dt.Rows[0]["DURA16OPT"].ToString();
            TextBoxRFA17OPT.Text = dt.Rows[0]["RFA17OPT"].ToString();
            TextBoxDURA17OPT.Text = dt.Rows[0]["DURA17OPT"].ToString();
            TextBoxRFA18OPT.Text = dt.Rows[0]["RFA18OPT"].ToString();
            TextBoxDURA18OPT.Text = dt.Rows[0]["DURA18OPT"].ToString();
            TextBoxRFA19OPT.Text = dt.Rows[0]["RFA19OPT"].ToString();
            TextBoxDURA19OPT.Text = dt.Rows[0]["DURA19OPT"].ToString();
            TextBoxRFA20OPT.Text = dt.Rows[0]["RFA20OPT"].ToString();
            TextBoxDURA20OPT.Text = dt.Rows[0]["DURA20OPT"].ToString();

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
            cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  LockStatus = 'Locked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

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
            cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  LockStatus = 'SDV' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

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
            cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  LockStatus = 'Unlocked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con1);

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
    #region QueryDURA1OPT
    private void SetImageQueryDURA1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA1OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA1OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA1OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA1OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA1OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA1OPT.Visible = true;
                PanelRaiseDURA1OPT2.Visible = false;
                PanelRaiseDURA1OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA1OPT.Visible = true;
                PanelRaiseDURA1OPT2.Visible = true;
                PanelRaiseDURA1OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA1OPT.Visible = true;
                PanelRaiseDURA1OPT2.Visible = true;
                PanelRaiseDURA1OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA1OPT = '" + TextBoxDURA1OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA1OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA1OPT.Visible = true;
                RAISEDURA1OPT.ShowPopupWindow();
                QueryRaiseDURA1OPT.Visible = true;
                TextBoxRaiseDURA1OPT.Visible = true;
                PanelRaiseDURA1OPT.Visible = false;
                PanelRaiseDURA1OPT2.Visible = false;
                PanelRaiseDURA1OPT3.Visible = false;

            }

            else if ((ImageQueryDURA1OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA1OPT.Visible = true;
                RAISEDURA1OPT.ShowPopupWindow();
                QueryRaiseDURA1OPT.Visible = false;
                TextBoxRaiseDURA1OPT.Visible = false;
            }

            else if ((ImageQueryDURA1OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA1OPT.Visible = true;
                RespondedDURA1OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA1OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA1OPT.Visible = true;
                CloseDURA1OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA1OPT.Visible = true;
                LockDURA1OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA1OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA1OPT.Text + "','" + TextBoxRaiseDURA1OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA1OPT = '" + TextBoxDURA1OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA1OPTMSG.ShowPopupWindow();
        RAISEDURA1OPT.Visible = false;
        QueryRaiseDURA1OPT.Visible = false;
        TextBoxRaiseDURA1OPT.Visible = false;

    }

    protected void CloseQueryDURA1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA1OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA1OPT = '" + TextBoxDURA1OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA1OPTMSG.ShowPopupWindow();
        RespondedDURA1OPT.Visible = false;
        RespondedDURA1OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA1OPT_Click(object sender, EventArgs e)
    {
        CloseDURA1OPT.Visible = false;

        RAISEDURA1OPT.Visible = true;
        RAISEDURA1OPT.ShowPopupWindow();
        QueryRaiseDURA1OPT.Visible = true;
        TextBoxRaiseDURA1OPT.Visible = true;


    }
    #endregion
    #region QueryDURA2OPT
    private void SetImageQueryDURA2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA2OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA2OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA2OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA2OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA2OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA2OPT.Visible = true;
                PanelRaiseDURA2OPT2.Visible = false;
                PanelRaiseDURA2OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA2OPT.Visible = true;
                PanelRaiseDURA2OPT2.Visible = true;
                PanelRaiseDURA2OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA2OPT.Visible = true;
                PanelRaiseDURA2OPT2.Visible = true;
                PanelRaiseDURA2OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA2OPT = '" + TextBoxDURA2OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA2OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA2OPT.Visible = true;
                RAISEDURA2OPT.ShowPopupWindow();
                QueryRaiseDURA2OPT.Visible = true;
                TextBoxRaiseDURA2OPT.Visible = true;
                PanelRaiseDURA2OPT.Visible = false;
                PanelRaiseDURA2OPT2.Visible = false;
                PanelRaiseDURA2OPT3.Visible = false;

            }

            else if ((ImageQueryDURA2OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA2OPT.Visible = true;
                RAISEDURA2OPT.ShowPopupWindow();
                QueryRaiseDURA2OPT.Visible = false;
                TextBoxRaiseDURA2OPT.Visible = false;
            }

            else if ((ImageQueryDURA2OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA2OPT.Visible = true;
                RespondedDURA2OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA2OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA2OPT.Visible = true;
                CloseDURA2OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA2OPT.Visible = true;
                LockDURA2OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA2OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA2OPT.Text + "','" + TextBoxRaiseDURA2OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA2OPT = '" + TextBoxDURA2OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA2OPTMSG.ShowPopupWindow();
        RAISEDURA2OPT.Visible = false;
        QueryRaiseDURA2OPT.Visible = false;
        TextBoxRaiseDURA2OPT.Visible = false;

    }

    protected void CloseQueryDURA2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA2OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA2OPT = '" + TextBoxDURA2OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA2OPTMSG.ShowPopupWindow();
        RespondedDURA2OPT.Visible = false;
        RespondedDURA2OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA2OPT_Click(object sender, EventArgs e)
    {
        CloseDURA2OPT.Visible = false;

        RAISEDURA2OPT.Visible = true;
        RAISEDURA2OPT.ShowPopupWindow();
        QueryRaiseDURA2OPT.Visible = true;
        TextBoxRaiseDURA2OPT.Visible = true;


    }
    #endregion
    #region QueryDURA3OPT
    private void SetImageQueryDURA3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA3OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA3OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA3OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA3OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA3OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA3OPT.Visible = true;
                PanelRaiseDURA3OPT2.Visible = false;
                PanelRaiseDURA3OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA3OPT.Visible = true;
                PanelRaiseDURA3OPT2.Visible = true;
                PanelRaiseDURA3OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA3OPT.Visible = true;
                PanelRaiseDURA3OPT2.Visible = true;
                PanelRaiseDURA3OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA3OPT = '" + TextBoxDURA3OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA3OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA3OPT.Visible = true;
                RAISEDURA3OPT.ShowPopupWindow();
                QueryRaiseDURA3OPT.Visible = true;
                TextBoxRaiseDURA3OPT.Visible = true;
                PanelRaiseDURA3OPT.Visible = false;
                PanelRaiseDURA3OPT2.Visible = false;
                PanelRaiseDURA3OPT3.Visible = false;

            }

            else if ((ImageQueryDURA3OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA3OPT.Visible = true;
                RAISEDURA3OPT.ShowPopupWindow();
                QueryRaiseDURA3OPT.Visible = false;
                TextBoxRaiseDURA3OPT.Visible = false;
            }

            else if ((ImageQueryDURA3OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA3OPT.Visible = true;
                RespondedDURA3OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA3OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA3OPT.Visible = true;
                CloseDURA3OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA3OPT.Visible = true;
                LockDURA3OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA3OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA3OPT.Text + "','" + TextBoxRaiseDURA3OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA3OPT = '" + TextBoxDURA3OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA3OPTMSG.ShowPopupWindow();
        RAISEDURA3OPT.Visible = false;
        QueryRaiseDURA3OPT.Visible = false;
        TextBoxRaiseDURA3OPT.Visible = false;

    }

    protected void CloseQueryDURA3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA3OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA3OPT = '" + TextBoxDURA3OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA3OPTMSG.ShowPopupWindow();
        RespondedDURA3OPT.Visible = false;
        RespondedDURA3OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA3OPT_Click(object sender, EventArgs e)
    {
        CloseDURA3OPT.Visible = false;

        RAISEDURA3OPT.Visible = true;
        RAISEDURA3OPT.ShowPopupWindow();
        QueryRaiseDURA3OPT.Visible = true;
        TextBoxRaiseDURA3OPT.Visible = true;


    }
    #endregion
    #region QueryDURA4OPT
    private void SetImageQueryDURA4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA4OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA4OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA4OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA4OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA4OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA4OPT.Visible = true;
                PanelRaiseDURA4OPT2.Visible = false;
                PanelRaiseDURA4OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA4OPT.Visible = true;
                PanelRaiseDURA4OPT2.Visible = true;
                PanelRaiseDURA4OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA4OPT.Visible = true;
                PanelRaiseDURA4OPT2.Visible = true;
                PanelRaiseDURA4OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA4OPT = '" + TextBoxDURA4OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA4OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA4OPT.Visible = true;
                RAISEDURA4OPT.ShowPopupWindow();
                QueryRaiseDURA4OPT.Visible = true;
                TextBoxRaiseDURA4OPT.Visible = true;
                PanelRaiseDURA4OPT.Visible = false;
                PanelRaiseDURA4OPT2.Visible = false;
                PanelRaiseDURA4OPT3.Visible = false;

            }

            else if ((ImageQueryDURA4OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA4OPT.Visible = true;
                RAISEDURA4OPT.ShowPopupWindow();
                QueryRaiseDURA4OPT.Visible = false;
                TextBoxRaiseDURA4OPT.Visible = false;
            }

            else if ((ImageQueryDURA4OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA4OPT.Visible = true;
                RespondedDURA4OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA4OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA4OPT.Visible = true;
                CloseDURA4OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA4OPT.Visible = true;
                LockDURA4OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA4OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA4OPT.Text + "','" + TextBoxRaiseDURA4OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA4OPT = '" + TextBoxDURA4OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA4OPTMSG.ShowPopupWindow();
        RAISEDURA4OPT.Visible = false;
        QueryRaiseDURA4OPT.Visible = false;
        TextBoxRaiseDURA4OPT.Visible = false;

    }

    protected void CloseQueryDURA4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA4OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA4OPT = '" + TextBoxDURA4OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA4OPTMSG.ShowPopupWindow();
        RespondedDURA4OPT.Visible = false;
        RespondedDURA4OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA4OPT_Click(object sender, EventArgs e)
    {
        CloseDURA4OPT.Visible = false;

        RAISEDURA4OPT.Visible = true;
        RAISEDURA4OPT.ShowPopupWindow();
        QueryRaiseDURA4OPT.Visible = true;
        TextBoxRaiseDURA4OPT.Visible = true;


    }
    #endregion
    #region QueryDURA5OPT
    private void SetImageQueryDURA5OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA5OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA5OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA5OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA5OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA5OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA5OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA5OPT.Visible = true;
                PanelRaiseDURA5OPT2.Visible = false;
                PanelRaiseDURA5OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA5OPT.Visible = true;
                PanelRaiseDURA5OPT2.Visible = true;
                PanelRaiseDURA5OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA5OPT.Visible = true;
                PanelRaiseDURA5OPT2.Visible = true;
                PanelRaiseDURA5OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA5OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA5OPT = '" + TextBoxDURA5OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA5OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA5OPT.Visible = true;
                RAISEDURA5OPT.ShowPopupWindow();
                QueryRaiseDURA5OPT.Visible = true;
                TextBoxRaiseDURA5OPT.Visible = true;
                PanelRaiseDURA5OPT.Visible = false;
                PanelRaiseDURA5OPT2.Visible = false;
                PanelRaiseDURA5OPT3.Visible = false;

            }

            else if ((ImageQueryDURA5OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA5OPT.Visible = true;
                RAISEDURA5OPT.ShowPopupWindow();
                QueryRaiseDURA5OPT.Visible = false;
                TextBoxRaiseDURA5OPT.Visible = false;
            }

            else if ((ImageQueryDURA5OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA5OPT.Visible = true;
                RespondedDURA5OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA5OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA5OPT.Visible = true;
                CloseDURA5OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA5OPT.Visible = true;
                LockDURA5OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA5OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA5OPT.Text + "','" + TextBoxRaiseDURA5OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA5OPT = '" + TextBoxDURA5OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA5OPTMSG.ShowPopupWindow();
        RAISEDURA5OPT.Visible = false;
        QueryRaiseDURA5OPT.Visible = false;
        TextBoxRaiseDURA5OPT.Visible = false;

    }

    protected void CloseQueryDURA5OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA5OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA5OPT = '" + TextBoxDURA5OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA5OPTMSG.ShowPopupWindow();
        RespondedDURA5OPT.Visible = false;
        RespondedDURA5OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA5OPT_Click(object sender, EventArgs e)
    {
        CloseDURA5OPT.Visible = false;

        RAISEDURA5OPT.Visible = true;
        RAISEDURA5OPT.ShowPopupWindow();
        QueryRaiseDURA5OPT.Visible = true;
        TextBoxRaiseDURA5OPT.Visible = true;


    }
    #endregion
    #region QueryDURA6OPT
    private void SetImageQueryDURA6OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA6OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA6OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA6OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA6OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA6OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA6OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA6OPT.Visible = true;
                PanelRaiseDURA6OPT2.Visible = false;
                PanelRaiseDURA6OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA6OPT.Visible = true;
                PanelRaiseDURA6OPT2.Visible = true;
                PanelRaiseDURA6OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA6OPT.Visible = true;
                PanelRaiseDURA6OPT2.Visible = true;
                PanelRaiseDURA6OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA6OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA6OPT = '" + TextBoxDURA6OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA6OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA6OPT.Visible = true;
                RAISEDURA6OPT.ShowPopupWindow();
                QueryRaiseDURA6OPT.Visible = true;
                TextBoxRaiseDURA6OPT.Visible = true;
                PanelRaiseDURA6OPT.Visible = false;
                PanelRaiseDURA6OPT2.Visible = false;
                PanelRaiseDURA6OPT3.Visible = false;

            }

            else if ((ImageQueryDURA6OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA6OPT.Visible = true;
                RAISEDURA6OPT.ShowPopupWindow();
                QueryRaiseDURA6OPT.Visible = false;
                TextBoxRaiseDURA6OPT.Visible = false;
            }

            else if ((ImageQueryDURA6OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA6OPT.Visible = true;
                RespondedDURA6OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA6OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA6OPT.Visible = true;
                CloseDURA6OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA6OPT.Visible = true;
                LockDURA6OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA6OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA6OPT.Text + "','" + TextBoxRaiseDURA6OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA6OPT = '" + TextBoxDURA6OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA6OPTMSG.ShowPopupWindow();
        RAISEDURA6OPT.Visible = false;
        QueryRaiseDURA6OPT.Visible = false;
        TextBoxRaiseDURA6OPT.Visible = false;

    }

    protected void CloseQueryDURA6OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA6OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA6OPT = '" + TextBoxDURA6OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA6OPTMSG.ShowPopupWindow();
        RespondedDURA6OPT.Visible = false;
        RespondedDURA6OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA6OPT_Click(object sender, EventArgs e)
    {
        CloseDURA6OPT.Visible = false;

        RAISEDURA6OPT.Visible = true;
        RAISEDURA6OPT.ShowPopupWindow();
        QueryRaiseDURA6OPT.Visible = true;
        TextBoxRaiseDURA6OPT.Visible = true;


    }
    #endregion
    #region QueryDURA7OPT
    private void SetImageQueryDURA7OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA7OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA7OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA7OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA7OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA7OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA7OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA7OPT.Visible = true;
                PanelRaiseDURA7OPT2.Visible = false;
                PanelRaiseDURA7OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA7OPT.Visible = true;
                PanelRaiseDURA7OPT2.Visible = true;
                PanelRaiseDURA7OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA7OPT.Visible = true;
                PanelRaiseDURA7OPT2.Visible = true;
                PanelRaiseDURA7OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA7OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA7OPT = '" + TextBoxDURA7OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA7OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA7OPT.Visible = true;
                RAISEDURA7OPT.ShowPopupWindow();
                QueryRaiseDURA7OPT.Visible = true;
                TextBoxRaiseDURA7OPT.Visible = true;
                PanelRaiseDURA7OPT.Visible = false;
                PanelRaiseDURA7OPT2.Visible = false;
                PanelRaiseDURA7OPT3.Visible = false;

            }

            else if ((ImageQueryDURA7OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA7OPT.Visible = true;
                RAISEDURA7OPT.ShowPopupWindow();
                QueryRaiseDURA7OPT.Visible = false;
                TextBoxRaiseDURA7OPT.Visible = false;
            }

            else if ((ImageQueryDURA7OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA7OPT.Visible = true;
                RespondedDURA7OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA7OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA7OPT.Visible = true;
                CloseDURA7OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA7OPT.Visible = true;
                LockDURA7OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA7OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA7OPT.Text + "','" + TextBoxRaiseDURA7OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA7OPT = '" + TextBoxDURA7OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA7OPTMSG.ShowPopupWindow();
        RAISEDURA7OPT.Visible = false;
        QueryRaiseDURA7OPT.Visible = false;
        TextBoxRaiseDURA7OPT.Visible = false;

    }

    protected void CloseQueryDURA7OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA7OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA7OPT = '" + TextBoxDURA7OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA7OPTMSG.ShowPopupWindow();
        RespondedDURA7OPT.Visible = false;
        RespondedDURA7OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA7OPT_Click(object sender, EventArgs e)
    {
        CloseDURA7OPT.Visible = false;

        RAISEDURA7OPT.Visible = true;
        RAISEDURA7OPT.ShowPopupWindow();
        QueryRaiseDURA7OPT.Visible = true;
        TextBoxRaiseDURA7OPT.Visible = true;


    }
    #endregion
    #region QueryDURA8OPT
    private void SetImageQueryDURA8OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA8OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA8OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA8OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA8OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA8OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA8OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA8OPT.Visible = true;
                PanelRaiseDURA8OPT2.Visible = false;
                PanelRaiseDURA8OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA8OPT.Visible = true;
                PanelRaiseDURA8OPT2.Visible = true;
                PanelRaiseDURA8OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA8OPT.Visible = true;
                PanelRaiseDURA8OPT2.Visible = true;
                PanelRaiseDURA8OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA8OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA8OPT = '" + TextBoxDURA8OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA8OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA8OPT.Visible = true;
                RAISEDURA8OPT.ShowPopupWindow();
                QueryRaiseDURA8OPT.Visible = true;
                TextBoxRaiseDURA8OPT.Visible = true;
                PanelRaiseDURA8OPT.Visible = false;
                PanelRaiseDURA8OPT2.Visible = false;
                PanelRaiseDURA8OPT3.Visible = false;

            }

            else if ((ImageQueryDURA8OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA8OPT.Visible = true;
                RAISEDURA8OPT.ShowPopupWindow();
                QueryRaiseDURA8OPT.Visible = false;
                TextBoxRaiseDURA8OPT.Visible = false;
            }

            else if ((ImageQueryDURA8OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA8OPT.Visible = true;
                RespondedDURA8OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA8OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA8OPT.Visible = true;
                CloseDURA8OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA8OPT.Visible = true;
                LockDURA8OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA8OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA8OPT.Text + "','" + TextBoxRaiseDURA8OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA8OPT = '" + TextBoxDURA8OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA8OPTMSG.ShowPopupWindow();
        RAISEDURA8OPT.Visible = false;
        QueryRaiseDURA8OPT.Visible = false;
        TextBoxRaiseDURA8OPT.Visible = false;

    }

    protected void CloseQueryDURA8OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA8OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA8OPT = '" + TextBoxDURA8OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA8OPTMSG.ShowPopupWindow();
        RespondedDURA8OPT.Visible = false;
        RespondedDURA8OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA8OPT_Click(object sender, EventArgs e)
    {
        CloseDURA8OPT.Visible = false;

        RAISEDURA8OPT.Visible = true;
        RAISEDURA8OPT.ShowPopupWindow();
        QueryRaiseDURA8OPT.Visible = true;
        TextBoxRaiseDURA8OPT.Visible = true;


    }
    #endregion
    #region QueryDURA9OPT
    private void SetImageQueryDURA9OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA9OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA9OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA9OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA9OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA9OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA9OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA9OPT.Visible = true;
                PanelRaiseDURA9OPT2.Visible = false;
                PanelRaiseDURA9OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA9OPT.Visible = true;
                PanelRaiseDURA9OPT2.Visible = true;
                PanelRaiseDURA9OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA9OPT.Visible = true;
                PanelRaiseDURA9OPT2.Visible = true;
                PanelRaiseDURA9OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA9OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA9OPT = '" + TextBoxDURA9OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA9OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA9OPT.Visible = true;
                RAISEDURA9OPT.ShowPopupWindow();
                QueryRaiseDURA9OPT.Visible = true;
                TextBoxRaiseDURA9OPT.Visible = true;
                PanelRaiseDURA9OPT.Visible = false;
                PanelRaiseDURA9OPT2.Visible = false;
                PanelRaiseDURA9OPT3.Visible = false;

            }

            else if ((ImageQueryDURA9OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA9OPT.Visible = true;
                RAISEDURA9OPT.ShowPopupWindow();
                QueryRaiseDURA9OPT.Visible = false;
                TextBoxRaiseDURA9OPT.Visible = false;
            }

            else if ((ImageQueryDURA9OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA9OPT.Visible = true;
                RespondedDURA9OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA9OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA9OPT.Visible = true;
                CloseDURA9OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA9OPT.Visible = true;
                LockDURA9OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA9OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA9OPT.Text + "','" + TextBoxRaiseDURA9OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA9OPT = '" + TextBoxDURA9OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA9OPTMSG.ShowPopupWindow();
        RAISEDURA9OPT.Visible = false;
        QueryRaiseDURA9OPT.Visible = false;
        TextBoxRaiseDURA9OPT.Visible = false;

    }

    protected void CloseQueryDURA9OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA9OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA9OPT = '" + TextBoxDURA9OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA9OPTMSG.ShowPopupWindow();
        RespondedDURA9OPT.Visible = false;
        RespondedDURA9OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA9OPT_Click(object sender, EventArgs e)
    {
        CloseDURA9OPT.Visible = false;

        RAISEDURA9OPT.Visible = true;
        RAISEDURA9OPT.ShowPopupWindow();
        QueryRaiseDURA9OPT.Visible = true;
        TextBoxRaiseDURA9OPT.Visible = true;


    }
    #endregion
    #region QueryDURA10OPT
    private void SetImageQueryDURA10OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA10OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA10OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA10OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA10OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA10OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA10OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA10OPT.Visible = true;
                PanelRaiseDURA10OPT2.Visible = false;
                PanelRaiseDURA10OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA10OPT.Visible = true;
                PanelRaiseDURA10OPT2.Visible = true;
                PanelRaiseDURA10OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA10OPT.Visible = true;
                PanelRaiseDURA10OPT2.Visible = true;
                PanelRaiseDURA10OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA10OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA10OPT = '" + TextBoxDURA10OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA10OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA10OPT.Visible = true;
                RAISEDURA10OPT.ShowPopupWindow();
                QueryRaiseDURA10OPT.Visible = true;
                TextBoxRaiseDURA10OPT.Visible = true;
                PanelRaiseDURA10OPT.Visible = false;
                PanelRaiseDURA10OPT2.Visible = false;
                PanelRaiseDURA10OPT3.Visible = false;

            }

            else if ((ImageQueryDURA10OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA10OPT.Visible = true;
                RAISEDURA10OPT.ShowPopupWindow();
                QueryRaiseDURA10OPT.Visible = false;
                TextBoxRaiseDURA10OPT.Visible = false;
            }

            else if ((ImageQueryDURA10OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA10OPT.Visible = true;
                RespondedDURA10OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA10OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA10OPT.Visible = true;
                CloseDURA10OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA10OPT.Visible = true;
                LockDURA10OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA10OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA10OPT.Text + "','" + TextBoxRaiseDURA10OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA10OPT = '" + TextBoxDURA10OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA10OPTMSG.ShowPopupWindow();
        RAISEDURA10OPT.Visible = false;
        QueryRaiseDURA10OPT.Visible = false;
        TextBoxRaiseDURA10OPT.Visible = false;

    }

    protected void CloseQueryDURA10OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA10OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA10OPT = '" + TextBoxDURA10OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA10OPTMSG.ShowPopupWindow();
        RespondedDURA10OPT.Visible = false;
        RespondedDURA10OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA10OPT_Click(object sender, EventArgs e)
    {
        CloseDURA10OPT.Visible = false;

        RAISEDURA10OPT.Visible = true;
        RAISEDURA10OPT.ShowPopupWindow();
        QueryRaiseDURA10OPT.Visible = true;
        TextBoxRaiseDURA10OPT.Visible = true;


    }
    #endregion
    #region QueryDURA11OPT
    private void SetImageQueryDURA11OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA11OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA11OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA11OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA11OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA11OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA11OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA11OPT.Visible = true;
                PanelRaiseDURA11OPT2.Visible = false;
                PanelRaiseDURA11OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA11OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA11OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA11OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA11OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA11OPT.Visible = true;
                PanelRaiseDURA11OPT2.Visible = true;
                PanelRaiseDURA11OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA11OPT.Visible = true;
                PanelRaiseDURA11OPT2.Visible = true;
                PanelRaiseDURA11OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA11OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA11OPT = '" + TextBoxDURA11OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA11OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA11OPT.Visible = true;
                RAISEDURA11OPT.ShowPopupWindow();
                QueryRaiseDURA11OPT.Visible = true;
                TextBoxRaiseDURA11OPT.Visible = true;
                PanelRaiseDURA11OPT.Visible = false;
                PanelRaiseDURA11OPT2.Visible = false;
                PanelRaiseDURA11OPT3.Visible = false;

            }

            else if ((ImageQueryDURA11OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA11OPT.Visible = true;
                RAISEDURA11OPT.ShowPopupWindow();
                QueryRaiseDURA11OPT.Visible = false;
                TextBoxRaiseDURA11OPT.Visible = false;
            }

            else if ((ImageQueryDURA11OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA11OPT.Visible = true;
                RespondedDURA11OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA11OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA11OPT.Visible = true;
                CloseDURA11OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA11OPT.Visible = true;
                LockDURA11OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA11OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA11OPT.Text + "','" + TextBoxRaiseDURA11OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA11OPT = '" + TextBoxDURA11OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA11OPTMSG.ShowPopupWindow();
        RAISEDURA11OPT.Visible = false;
        QueryRaiseDURA11OPT.Visible = false;
        TextBoxRaiseDURA11OPT.Visible = false;

    }

    protected void CloseQueryDURA11OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA11OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA11OPT = '" + TextBoxDURA11OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA11OPTMSG.ShowPopupWindow();
        RespondedDURA11OPT.Visible = false;
        RespondedDURA11OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA11OPT_Click(object sender, EventArgs e)
    {
        CloseDURA11OPT.Visible = false;

        RAISEDURA11OPT.Visible = true;
        RAISEDURA11OPT.ShowPopupWindow();
        QueryRaiseDURA11OPT.Visible = true;
        TextBoxRaiseDURA11OPT.Visible = true;


    }
    #endregion
    #region QueryDURA12OPT
    private void SetImageQueryDURA12OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA12OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA12OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA12OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA12OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA12OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA12OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA12OPT.Visible = true;
                PanelRaiseDURA12OPT2.Visible = false;
                PanelRaiseDURA12OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA12OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA12OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA12OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA12OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA12OPT.Visible = true;
                PanelRaiseDURA12OPT2.Visible = true;
                PanelRaiseDURA12OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA12OPT.Visible = true;
                PanelRaiseDURA12OPT2.Visible = true;
                PanelRaiseDURA12OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA12OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA12OPT = '" + TextBoxDURA12OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA12OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA12OPT.Visible = true;
                RAISEDURA12OPT.ShowPopupWindow();
                QueryRaiseDURA12OPT.Visible = true;
                TextBoxRaiseDURA12OPT.Visible = true;
                PanelRaiseDURA12OPT.Visible = false;
                PanelRaiseDURA12OPT2.Visible = false;
                PanelRaiseDURA12OPT3.Visible = false;

            }

            else if ((ImageQueryDURA12OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA12OPT.Visible = true;
                RAISEDURA12OPT.ShowPopupWindow();
                QueryRaiseDURA12OPT.Visible = false;
                TextBoxRaiseDURA12OPT.Visible = false;
            }

            else if ((ImageQueryDURA12OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA12OPT.Visible = true;
                RespondedDURA12OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA12OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA12OPT.Visible = true;
                CloseDURA12OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA12OPT.Visible = true;
                LockDURA12OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA12OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA12OPT.Text + "','" + TextBoxRaiseDURA12OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA12OPT = '" + TextBoxDURA12OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA12OPTMSG.ShowPopupWindow();
        RAISEDURA12OPT.Visible = false;
        QueryRaiseDURA12OPT.Visible = false;
        TextBoxRaiseDURA12OPT.Visible = false;

    }

    protected void CloseQueryDURA12OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA12OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA12OPT = '" + TextBoxDURA12OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA12OPTMSG.ShowPopupWindow();
        RespondedDURA12OPT.Visible = false;
        RespondedDURA12OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA12OPT_Click(object sender, EventArgs e)
    {
        CloseDURA12OPT.Visible = false;

        RAISEDURA12OPT.Visible = true;
        RAISEDURA12OPT.ShowPopupWindow();
        QueryRaiseDURA12OPT.Visible = true;
        TextBoxRaiseDURA12OPT.Visible = true;


    }
    #endregion
    #region QueryDURA13OPT
    private void SetImageQueryDURA13OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA13OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA13OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA13OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA13OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA13OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA13OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA13OPT.Visible = true;
                PanelRaiseDURA13OPT2.Visible = false;
                PanelRaiseDURA13OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA13OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA13OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA13OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA13OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA13OPT.Visible = true;
                PanelRaiseDURA13OPT2.Visible = true;
                PanelRaiseDURA13OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA13OPT.Visible = true;
                PanelRaiseDURA13OPT2.Visible = true;
                PanelRaiseDURA13OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA13OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA13OPT = '" + TextBoxDURA13OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA13OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA13OPT.Visible = true;
                RAISEDURA13OPT.ShowPopupWindow();
                QueryRaiseDURA13OPT.Visible = true;
                TextBoxRaiseDURA13OPT.Visible = true;
                PanelRaiseDURA13OPT.Visible = false;
                PanelRaiseDURA13OPT2.Visible = false;
                PanelRaiseDURA13OPT3.Visible = false;

            }

            else if ((ImageQueryDURA13OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA13OPT.Visible = true;
                RAISEDURA13OPT.ShowPopupWindow();
                QueryRaiseDURA13OPT.Visible = false;
                TextBoxRaiseDURA13OPT.Visible = false;
            }

            else if ((ImageQueryDURA13OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA13OPT.Visible = true;
                RespondedDURA13OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA13OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA13OPT.Visible = true;
                CloseDURA13OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA13OPT.Visible = true;
                LockDURA13OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA13OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA13OPT.Text + "','" + TextBoxRaiseDURA13OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA13OPT = '" + TextBoxDURA13OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA13OPTMSG.ShowPopupWindow();
        RAISEDURA13OPT.Visible = false;
        QueryRaiseDURA13OPT.Visible = false;
        TextBoxRaiseDURA13OPT.Visible = false;

    }

    protected void CloseQueryDURA13OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA13OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA13OPT = '" + TextBoxDURA13OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA13OPTMSG.ShowPopupWindow();
        RespondedDURA13OPT.Visible = false;
        RespondedDURA13OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA13OPT_Click(object sender, EventArgs e)
    {
        CloseDURA13OPT.Visible = false;

        RAISEDURA13OPT.Visible = true;
        RAISEDURA13OPT.ShowPopupWindow();
        QueryRaiseDURA13OPT.Visible = true;
        TextBoxRaiseDURA13OPT.Visible = true;


    }
    #endregion
    #region QueryDURA14OPT
    private void SetImageQueryDURA14OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA14OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA14OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA14OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA14OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA14OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA14OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA14OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA14OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA14OPT.Visible = true;
                PanelRaiseDURA14OPT2.Visible = false;
                PanelRaiseDURA14OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA14OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA14OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA14OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA14OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA14OPT.Visible = true;
                PanelRaiseDURA14OPT2.Visible = true;
                PanelRaiseDURA14OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA14OPT.Visible = true;
                PanelRaiseDURA14OPT2.Visible = true;
                PanelRaiseDURA14OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA14OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA14OPT = '" + TextBoxDURA14OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA14OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA14OPT.Visible = true;
                RAISEDURA14OPT.ShowPopupWindow();
                QueryRaiseDURA14OPT.Visible = true;
                TextBoxRaiseDURA14OPT.Visible = true;
                PanelRaiseDURA14OPT.Visible = false;
                PanelRaiseDURA14OPT2.Visible = false;
                PanelRaiseDURA14OPT3.Visible = false;

            }

            else if ((ImageQueryDURA14OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA14OPT.Visible = true;
                RAISEDURA14OPT.ShowPopupWindow();
                QueryRaiseDURA14OPT.Visible = false;
                TextBoxRaiseDURA14OPT.Visible = false;
            }

            else if ((ImageQueryDURA14OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA14OPT.Visible = true;
                RespondedDURA14OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA14OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA14OPT.Visible = true;
                CloseDURA14OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA14OPT.Visible = true;
                LockDURA14OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA14OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA14OPT.Text + "','" + TextBoxRaiseDURA14OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA14OPT = '" + TextBoxDURA14OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA14OPTMSG.ShowPopupWindow();
        RAISEDURA14OPT.Visible = false;
        QueryRaiseDURA14OPT.Visible = false;
        TextBoxRaiseDURA14OPT.Visible = false;

    }

    protected void CloseQueryDURA14OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA14OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA14OPT = '" + TextBoxDURA14OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA14OPTMSG.ShowPopupWindow();
        RespondedDURA14OPT.Visible = false;
        RespondedDURA14OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA14OPT_Click(object sender, EventArgs e)
    {
        CloseDURA14OPT.Visible = false;

        RAISEDURA14OPT.Visible = true;
        RAISEDURA14OPT.ShowPopupWindow();
        QueryRaiseDURA14OPT.Visible = true;
        TextBoxRaiseDURA14OPT.Visible = true;


    }
    #endregion
    #region QueryDURA15OPT
    private void SetImageQueryDURA15OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA15OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA15OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA15OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA15OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA15OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA15OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA15OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA15OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA15OPT.Visible = true;
                PanelRaiseDURA15OPT2.Visible = false;
                PanelRaiseDURA15OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA15OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA15OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA15OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA15OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA15OPT.Visible = true;
                PanelRaiseDURA15OPT2.Visible = true;
                PanelRaiseDURA15OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA15OPT.Visible = true;
                PanelRaiseDURA15OPT2.Visible = true;
                PanelRaiseDURA15OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA15OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA15OPT = '" + TextBoxDURA15OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA15OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA15OPT.Visible = true;
                RAISEDURA15OPT.ShowPopupWindow();
                QueryRaiseDURA15OPT.Visible = true;
                TextBoxRaiseDURA15OPT.Visible = true;
                PanelRaiseDURA15OPT.Visible = false;
                PanelRaiseDURA15OPT2.Visible = false;
                PanelRaiseDURA15OPT3.Visible = false;

            }

            else if ((ImageQueryDURA15OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA15OPT.Visible = true;
                RAISEDURA15OPT.ShowPopupWindow();
                QueryRaiseDURA15OPT.Visible = false;
                TextBoxRaiseDURA15OPT.Visible = false;
            }

            else if ((ImageQueryDURA15OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA15OPT.Visible = true;
                RespondedDURA15OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA15OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA15OPT.Visible = true;
                CloseDURA15OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA15OPT.Visible = true;
                LockDURA15OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA15OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA15OPT.Text + "','" + TextBoxRaiseDURA15OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA15OPT = '" + TextBoxDURA15OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA15OPTMSG.ShowPopupWindow();
        RAISEDURA15OPT.Visible = false;
        QueryRaiseDURA15OPT.Visible = false;
        TextBoxRaiseDURA15OPT.Visible = false;

    }

    protected void CloseQueryDURA15OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA15OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA15OPT = '" + TextBoxDURA15OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA15OPTMSG.ShowPopupWindow();
        RespondedDURA15OPT.Visible = false;
        RespondedDURA15OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA15OPT_Click(object sender, EventArgs e)
    {
        CloseDURA15OPT.Visible = false;

        RAISEDURA15OPT.Visible = true;
        RAISEDURA15OPT.ShowPopupWindow();
        QueryRaiseDURA15OPT.Visible = true;
        TextBoxRaiseDURA15OPT.Visible = true;


    }
    #endregion
    #region QueryDURA16OPT
    private void SetImageQueryDURA16OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA16OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA16OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA16OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA16OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA16OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA16OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA16OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA16OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA16OPT.Visible = true;
                PanelRaiseDURA16OPT2.Visible = false;
                PanelRaiseDURA16OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA16OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA16OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA16OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA16OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA16OPT.Visible = true;
                PanelRaiseDURA16OPT2.Visible = true;
                PanelRaiseDURA16OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA16OPT.Visible = true;
                PanelRaiseDURA16OPT2.Visible = true;
                PanelRaiseDURA16OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA16OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA16OPT = '" + TextBoxDURA16OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA16OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA16OPT.Visible = true;
                RAISEDURA16OPT.ShowPopupWindow();
                QueryRaiseDURA16OPT.Visible = true;
                TextBoxRaiseDURA16OPT.Visible = true;
                PanelRaiseDURA16OPT.Visible = false;
                PanelRaiseDURA16OPT2.Visible = false;
                PanelRaiseDURA16OPT3.Visible = false;

            }

            else if ((ImageQueryDURA16OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA16OPT.Visible = true;
                RAISEDURA16OPT.ShowPopupWindow();
                QueryRaiseDURA16OPT.Visible = false;
                TextBoxRaiseDURA16OPT.Visible = false;
            }

            else if ((ImageQueryDURA16OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA16OPT.Visible = true;
                RespondedDURA16OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA16OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA16OPT.Visible = true;
                CloseDURA16OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA16OPT.Visible = true;
                LockDURA16OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA16OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA16OPT.Text + "','" + TextBoxRaiseDURA16OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA16OPT = '" + TextBoxDURA16OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA16OPTMSG.ShowPopupWindow();
        RAISEDURA16OPT.Visible = false;
        QueryRaiseDURA16OPT.Visible = false;
        TextBoxRaiseDURA16OPT.Visible = false;

    }

    protected void CloseQueryDURA16OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA16OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA16OPT = '" + TextBoxDURA16OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA16OPTMSG.ShowPopupWindow();
        RespondedDURA16OPT.Visible = false;
        RespondedDURA16OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA16OPT_Click(object sender, EventArgs e)
    {
        CloseDURA16OPT.Visible = false;

        RAISEDURA16OPT.Visible = true;
        RAISEDURA16OPT.ShowPopupWindow();
        QueryRaiseDURA16OPT.Visible = true;
        TextBoxRaiseDURA16OPT.Visible = true;


    }
    #endregion
    #region QueryDURA17OPT
    private void SetImageQueryDURA17OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA17OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA17OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA17OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA17OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA17OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA17OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA17OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA17OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA17OPT.Visible = true;
                PanelRaiseDURA17OPT2.Visible = false;
                PanelRaiseDURA17OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA17OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA17OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA17OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA17OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA17OPT.Visible = true;
                PanelRaiseDURA17OPT2.Visible = true;
                PanelRaiseDURA17OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA17OPT.Visible = true;
                PanelRaiseDURA17OPT2.Visible = true;
                PanelRaiseDURA17OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA17OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA17OPT = '" + TextBoxDURA17OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA17OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA17OPT.Visible = true;
                RAISEDURA17OPT.ShowPopupWindow();
                QueryRaiseDURA17OPT.Visible = true;
                TextBoxRaiseDURA17OPT.Visible = true;
                PanelRaiseDURA17OPT.Visible = false;
                PanelRaiseDURA17OPT2.Visible = false;
                PanelRaiseDURA17OPT3.Visible = false;

            }

            else if ((ImageQueryDURA17OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA17OPT.Visible = true;
                RAISEDURA17OPT.ShowPopupWindow();
                QueryRaiseDURA17OPT.Visible = false;
                TextBoxRaiseDURA17OPT.Visible = false;
            }

            else if ((ImageQueryDURA17OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA17OPT.Visible = true;
                RespondedDURA17OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA17OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA17OPT.Visible = true;
                CloseDURA17OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA17OPT.Visible = true;
                LockDURA17OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA17OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA17OPT.Text + "','" + TextBoxRaiseDURA17OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA17OPT = '" + TextBoxDURA17OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA17OPTMSG.ShowPopupWindow();
        RAISEDURA17OPT.Visible = false;
        QueryRaiseDURA17OPT.Visible = false;
        TextBoxRaiseDURA17OPT.Visible = false;

    }

    protected void CloseQueryDURA17OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA17OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA17OPT = '" + TextBoxDURA17OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA17OPTMSG.ShowPopupWindow();
        RespondedDURA17OPT.Visible = false;
        RespondedDURA17OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA17OPT_Click(object sender, EventArgs e)
    {
        CloseDURA17OPT.Visible = false;

        RAISEDURA17OPT.Visible = true;
        RAISEDURA17OPT.ShowPopupWindow();
        QueryRaiseDURA17OPT.Visible = true;
        TextBoxRaiseDURA17OPT.Visible = true;


    }
    #endregion
    #region QueryDURA18OPT
    private void SetImageQueryDURA18OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA18OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA18OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA18OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA18OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA18OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA18OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA18OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA18OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA18OPT.Visible = true;
                PanelRaiseDURA18OPT2.Visible = false;
                PanelRaiseDURA18OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA18OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA18OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA18OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA18OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA18OPT.Visible = true;
                PanelRaiseDURA18OPT2.Visible = true;
                PanelRaiseDURA18OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA18OPT.Visible = true;
                PanelRaiseDURA18OPT2.Visible = true;
                PanelRaiseDURA18OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA18OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA18OPT = '" + TextBoxDURA18OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA18OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA18OPT.Visible = true;
                RAISEDURA18OPT.ShowPopupWindow();
                QueryRaiseDURA18OPT.Visible = true;
                TextBoxRaiseDURA18OPT.Visible = true;
                PanelRaiseDURA18OPT.Visible = false;
                PanelRaiseDURA18OPT2.Visible = false;
                PanelRaiseDURA18OPT3.Visible = false;

            }

            else if ((ImageQueryDURA18OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA18OPT.Visible = true;
                RAISEDURA18OPT.ShowPopupWindow();
                QueryRaiseDURA18OPT.Visible = false;
                TextBoxRaiseDURA18OPT.Visible = false;
            }

            else if ((ImageQueryDURA18OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA18OPT.Visible = true;
                RespondedDURA18OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA18OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA18OPT.Visible = true;
                CloseDURA18OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA18OPT.Visible = true;
                LockDURA18OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA18OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA18OPT.Text + "','" + TextBoxRaiseDURA18OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA18OPT = '" + TextBoxDURA18OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA18OPTMSG.ShowPopupWindow();
        RAISEDURA18OPT.Visible = false;
        QueryRaiseDURA18OPT.Visible = false;
        TextBoxRaiseDURA18OPT.Visible = false;

    }

    protected void CloseQueryDURA18OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA18OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA18OPT = '" + TextBoxDURA18OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA18OPTMSG.ShowPopupWindow();
        RespondedDURA18OPT.Visible = false;
        RespondedDURA18OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA18OPT_Click(object sender, EventArgs e)
    {
        CloseDURA18OPT.Visible = false;

        RAISEDURA18OPT.Visible = true;
        RAISEDURA18OPT.ShowPopupWindow();
        QueryRaiseDURA18OPT.Visible = true;
        TextBoxRaiseDURA18OPT.Visible = true;


    }
    #endregion
    #region QueryDURA19OPT
    private void SetImageQueryDURA19OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA19OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA19OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA19OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA19OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA19OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA19OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA19OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA19OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA19OPT.Visible = true;
                PanelRaiseDURA19OPT2.Visible = false;
                PanelRaiseDURA19OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA19OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA19OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA19OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA19OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA19OPT.Visible = true;
                PanelRaiseDURA19OPT2.Visible = true;
                PanelRaiseDURA19OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA19OPT.Visible = true;
                PanelRaiseDURA19OPT2.Visible = true;
                PanelRaiseDURA19OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA19OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA19OPT = '" + TextBoxDURA19OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA19OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA19OPT.Visible = true;
                RAISEDURA19OPT.ShowPopupWindow();
                QueryRaiseDURA19OPT.Visible = true;
                TextBoxRaiseDURA19OPT.Visible = true;
                PanelRaiseDURA19OPT.Visible = false;
                PanelRaiseDURA19OPT2.Visible = false;
                PanelRaiseDURA19OPT3.Visible = false;

            }

            else if ((ImageQueryDURA19OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA19OPT.Visible = true;
                RAISEDURA19OPT.ShowPopupWindow();
                QueryRaiseDURA19OPT.Visible = false;
                TextBoxRaiseDURA19OPT.Visible = false;
            }

            else if ((ImageQueryDURA19OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA19OPT.Visible = true;
                RespondedDURA19OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA19OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA19OPT.Visible = true;
                CloseDURA19OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA19OPT.Visible = true;
                LockDURA19OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA19OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA19OPT.Text + "','" + TextBoxRaiseDURA19OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA19OPT = '" + TextBoxDURA19OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA19OPTMSG.ShowPopupWindow();
        RAISEDURA19OPT.Visible = false;
        QueryRaiseDURA19OPT.Visible = false;
        TextBoxRaiseDURA19OPT.Visible = false;

    }

    protected void CloseQueryDURA19OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA19OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA19OPT = '" + TextBoxDURA19OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA19OPTMSG.ShowPopupWindow();
        RespondedDURA19OPT.Visible = false;
        RespondedDURA19OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA19OPT_Click(object sender, EventArgs e)
    {
        CloseDURA19OPT.Visible = false;

        RAISEDURA19OPT.Visible = true;
        RAISEDURA19OPT.ShowPopupWindow();
        QueryRaiseDURA19OPT.Visible = true;
        TextBoxRaiseDURA19OPT.Visible = true;


    }
    #endregion
    #region QueryDURA20OPT
    private void SetImageQueryDURA20OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA20OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDURA20OPT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDURA20OPT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDURA20OPT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryDURA20OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDURA20OPT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDURA20OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA20OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDURA20OPT.Visible = true;
                PanelRaiseDURA20OPT2.Visible = false;
                PanelRaiseDURA20OPT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDURA20OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDURA20OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA20OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA20OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDURA20OPT.Visible = true;
                PanelRaiseDURA20OPT2.Visible = true;
                PanelRaiseDURA20OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDURA20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDURA20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDURA20OPT.Visible = true;
                PanelRaiseDURA20OPT2.Visible = true;
                PanelRaiseDURA20OPT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDURA20OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[RiskFactorAssessment]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA20OPT = '" + TextBoxDURA20OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDURA20OPT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDURA20OPT.Visible = true;
                RAISEDURA20OPT.ShowPopupWindow();
                QueryRaiseDURA20OPT.Visible = true;
                TextBoxRaiseDURA20OPT.Visible = true;
                PanelRaiseDURA20OPT.Visible = false;
                PanelRaiseDURA20OPT2.Visible = false;
                PanelRaiseDURA20OPT3.Visible = false;

            }

            else if ((ImageQueryDURA20OPT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDURA20OPT.Visible = true;
                RAISEDURA20OPT.ShowPopupWindow();
                QueryRaiseDURA20OPT.Visible = false;
                TextBoxRaiseDURA20OPT.Visible = false;
            }

            else if ((ImageQueryDURA20OPT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDURA20OPT.Visible = true;
                RespondedDURA20OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDURA20OPT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDURA20OPT.Visible = true;
                CloseDURA20OPT.ShowPopupWindow();
            }
            else
            {
                LockDURA20OPT.Visible = true;
                LockDURA20OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDURA20OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDURA20OPT.Text + "','" + TextBoxRaiseDURA20OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA20OPT = '" + TextBoxDURA20OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDURA20OPTMSG.ShowPopupWindow();
        RAISEDURA20OPT.Visible = false;
        QueryRaiseDURA20OPT.Visible = false;
        TextBoxRaiseDURA20OPT.Visible = false;

    }

    protected void CloseQueryDURA20OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDURA20OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[RiskFactorAssessment]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DURA20OPT = '" + TextBoxDURA20OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDURA20OPTMSG.ShowPopupWindow();
        RespondedDURA20OPT.Visible = false;
        RespondedDURA20OPTClose.Visible = false;


    }

    protected void SubmitReRaiseDURA20OPT_Click(object sender, EventArgs e)
    {
        CloseDURA20OPT.Visible = false;

        RAISEDURA20OPT.Visible = true;
        RAISEDURA20OPT.ShowPopupWindow();
        QueryRaiseDURA20OPT.Visible = true;
        TextBoxRaiseDURA20OPT.Visible = true;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }
}