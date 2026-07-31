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

public partial class Study_Monitor_Visit3_ProceduresPerformed : System.Web.UI.Page
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

        SetImageQueryPP1DAT();
        BindQueryDataPP1DAT();
        SetImageQueryPP2DAT();
        BindQueryDataPP2DAT();
        SetImageQueryPP3DAT();
        BindQueryDataPP3DAT();
        SetImageQueryPP4DAT();
        BindQueryDataPP4DAT();
        SetImageQueryPP5DAT();
        BindQueryDataPP5DAT();
        SetImageQueryPP6DAT();
        BindQueryDataPP6DAT();
        SetImageQueryPP7DAT();
        BindQueryDataPP7DAT();
        SetImageQueryPP8DAT();
        BindQueryDataPP8DAT();
        SetImageQueryPP9DAT();
        BindQueryDataPP9DAT();
        SetImageQueryPP10DAT();
        BindQueryDataPP10DAT();
        SetImageQueryPP11DAT();
        BindQueryDataPP11DAT();
        SetImageQueryPP12DAT();
        BindQueryDataPP12DAT();
        SetImageQueryPP13DAT();
        BindQueryDataPP13DAT();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select PP1DAT ,PP2DAT ,PP3DAT ,PP4DAT ,PP5DAT ,PP6DAT ,PP7DAT ,PP8DAT ,PP9OPT ,PP9DAT ,PP10OPT ,PP10DAT ,PP11OPT ,PP11DAT ,PP12OPT ,PP12DAT ,PP13OPT ,PP13DAT, LockStatus from [Visit2].[ProceduresPerformed] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and [FUVSTNM]='"+ lblVisit .Text+ "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxPP1DAT.Text = dt.Rows[0]["PP1DAT"].ToString().Trim();
            TextBoxPP2DAT.Text = dt.Rows[0]["PP2DAT"].ToString().Trim();
            TextBoxPP3DAT.Text = dt.Rows[0]["PP3DAT"].ToString().Trim();
            TextBoxPP4DAT.Text = dt.Rows[0]["PP4DAT"].ToString().Trim();
            TextBoxPP5DAT.Text = dt.Rows[0]["PP5DAT"].ToString().Trim();
            TextBoxPP6DAT.Text = dt.Rows[0]["PP6DAT"].ToString().Trim();
            TextBoxPP7DAT.Text = dt.Rows[0]["PP7DAT"].ToString().Trim();
            TextBoxPP8DAT.Text = dt.Rows[0]["PP8DAT"].ToString().Trim();
            TextBoxPP9OPT.Text = dt.Rows[0]["PP9OPT"].ToString().Trim();
            TextBoxPP9DAT.Text = dt.Rows[0]["PP9DAT"].ToString().Trim();
            TextBoxPP10OPT.Text = dt.Rows[0]["PP10OPT"].ToString().Trim();
            TextBoxPP10DAT.Text = dt.Rows[0]["PP10DAT"].ToString().Trim();
            TextBoxPP11OPT.Text = dt.Rows[0]["PP11OPT"].ToString().Trim();
            TextBoxPP11DAT.Text = dt.Rows[0]["PP11DAT"].ToString().Trim();
            TextBoxPP12OPT.Text = dt.Rows[0]["PP12OPT"].ToString().Trim();
            TextBoxPP12DAT.Text = dt.Rows[0]["PP12DAT"].ToString().Trim();
            TextBoxPP13OPT.Text = dt.Rows[0]["PP13OPT"].ToString().Trim();
            TextBoxPP13DAT.Text = dt.Rows[0]["PP13DAT"].ToString().Trim();

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
            cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  LockStatus = 'Locked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

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
            cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  LockStatus = 'SDV' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

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
            cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  LockStatus = 'Unlocked' where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

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
    #region QueryPP1DAT
    private void SetImageQueryPP1DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP1DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP1DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP1DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP1DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP1DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP1DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP1DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP1DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP1DAT.Visible = true;
                PanelRaisePP1DAT2.Visible = false;
                PanelRaisePP1DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP1DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP1DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP1DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP1DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP1DAT.Visible = true;
                PanelRaisePP1DAT2.Visible = true;
                PanelRaisePP1DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP1DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP1DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP1DAT.Visible = true;
                PanelRaisePP1DAT2.Visible = true;
                PanelRaisePP1DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP1DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP1DAT = '" + TextBoxPP1DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP1DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP1DAT.Visible = true;
                RAISEPP1DAT.ShowPopupWindow();
                QueryRaisePP1DAT.Visible = true;
                TextBoxRaisePP1DAT.Visible = true;
                PanelRaisePP1DAT.Visible = false;
                PanelRaisePP1DAT2.Visible = false;
                PanelRaisePP1DAT3.Visible = false;

            }

            else if ((ImageQueryPP1DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP1DAT.Visible = true;
                RAISEPP1DAT.ShowPopupWindow();
                QueryRaisePP1DAT.Visible = false;
                TextBoxRaisePP1DAT.Visible = false;
            }

            else if ((ImageQueryPP1DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP1DAT.Visible = true;
                RespondedPP1DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP1DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP1DAT.Visible = true;
                ClosePP1DAT.ShowPopupWindow();
            }
            else
            {
                LockPP1DAT.Visible = true;
                LockPP1DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP1DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP1DAT.Text + "','" + TextBoxRaisePP1DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP1DAT = '" + TextBoxPP1DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP1DATMSG.ShowPopupWindow();
        RAISEPP1DAT.Visible = false;
        QueryRaisePP1DAT.Visible = false;
        TextBoxRaisePP1DAT.Visible = false;

    }

    protected void CloseQueryPP1DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP1DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP1DAT = '" + TextBoxPP1DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP1DATMSG.ShowPopupWindow();
        RespondedPP1DAT.Visible = false;
        RespondedPP1DATClose.Visible = false;


    }

    protected void SubmitReRaisePP1DAT_Click(object sender, EventArgs e)
    {
        ClosePP1DAT.Visible = false;

        RAISEPP1DAT.Visible = true;
        RAISEPP1DAT.ShowPopupWindow();
        QueryRaisePP1DAT.Visible = true;
        TextBoxRaisePP1DAT.Visible = true;


    }
    #endregion
    #region QueryPP2DAT
    private void SetImageQueryPP2DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP2DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP2DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP2DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP2DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP2DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP2DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP2DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP2DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP2DAT.Visible = true;
                PanelRaisePP2DAT2.Visible = false;
                PanelRaisePP2DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP2DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP2DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP2DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP2DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP2DAT.Visible = true;
                PanelRaisePP2DAT2.Visible = true;
                PanelRaisePP2DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP2DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP2DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP2DAT.Visible = true;
                PanelRaisePP2DAT2.Visible = true;
                PanelRaisePP2DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP2DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP2DAT = '" + TextBoxPP2DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP2DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP2DAT.Visible = true;
                RAISEPP2DAT.ShowPopupWindow();
                QueryRaisePP2DAT.Visible = true;
                TextBoxRaisePP2DAT.Visible = true;
                PanelRaisePP2DAT.Visible = false;
                PanelRaisePP2DAT2.Visible = false;
                PanelRaisePP2DAT3.Visible = false;

            }

            else if ((ImageQueryPP2DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP2DAT.Visible = true;
                RAISEPP2DAT.ShowPopupWindow();
                QueryRaisePP2DAT.Visible = false;
                TextBoxRaisePP2DAT.Visible = false;
            }

            else if ((ImageQueryPP2DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP2DAT.Visible = true;
                RespondedPP2DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP2DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP2DAT.Visible = true;
                ClosePP2DAT.ShowPopupWindow();
            }
            else
            {
                LockPP2DAT.Visible = true;
                LockPP2DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP2DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP2DAT.Text + "','" + TextBoxRaisePP2DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP2DAT = '" + TextBoxPP2DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP2DATMSG.ShowPopupWindow();
        RAISEPP2DAT.Visible = false;
        QueryRaisePP2DAT.Visible = false;
        TextBoxRaisePP2DAT.Visible = false;

    }

    protected void CloseQueryPP2DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP2DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP2DAT = '" + TextBoxPP2DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP2DATMSG.ShowPopupWindow();
        RespondedPP2DAT.Visible = false;
        RespondedPP2DATClose.Visible = false;


    }

    protected void SubmitReRaisePP2DAT_Click(object sender, EventArgs e)
    {
        ClosePP2DAT.Visible = false;

        RAISEPP2DAT.Visible = true;
        RAISEPP2DAT.ShowPopupWindow();
        QueryRaisePP2DAT.Visible = true;
        TextBoxRaisePP2DAT.Visible = true;


    }
    #endregion
    #region QueryPP3DAT
    private void SetImageQueryPP3DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP3DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP3DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP3DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP3DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP3DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP3DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP3DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP3DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP3DAT.Visible = true;
                PanelRaisePP3DAT2.Visible = false;
                PanelRaisePP3DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP3DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP3DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP3DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP3DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP3DAT.Visible = true;
                PanelRaisePP3DAT2.Visible = true;
                PanelRaisePP3DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP3DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP3DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP3DAT.Visible = true;
                PanelRaisePP3DAT2.Visible = true;
                PanelRaisePP3DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP3DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP3DAT = '" + TextBoxPP3DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP3DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP3DAT.Visible = true;
                RAISEPP3DAT.ShowPopupWindow();
                QueryRaisePP3DAT.Visible = true;
                TextBoxRaisePP3DAT.Visible = true;
                PanelRaisePP3DAT.Visible = false;
                PanelRaisePP3DAT2.Visible = false;
                PanelRaisePP3DAT3.Visible = false;

            }

            else if ((ImageQueryPP3DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP3DAT.Visible = true;
                RAISEPP3DAT.ShowPopupWindow();
                QueryRaisePP3DAT.Visible = false;
                TextBoxRaisePP3DAT.Visible = false;
            }

            else if ((ImageQueryPP3DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP3DAT.Visible = true;
                RespondedPP3DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP3DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP3DAT.Visible = true;
                ClosePP3DAT.ShowPopupWindow();
            }
            else
            {
                LockPP3DAT.Visible = true;
                LockPP3DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP3DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP3DAT.Text + "','" + TextBoxRaisePP3DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP3DAT = '" + TextBoxPP3DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP3DATMSG.ShowPopupWindow();
        RAISEPP3DAT.Visible = false;
        QueryRaisePP3DAT.Visible = false;
        TextBoxRaisePP3DAT.Visible = false;

    }

    protected void CloseQueryPP3DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP3DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP3DAT = '" + TextBoxPP3DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP3DATMSG.ShowPopupWindow();
        RespondedPP3DAT.Visible = false;
        RespondedPP3DATClose.Visible = false;


    }

    protected void SubmitReRaisePP3DAT_Click(object sender, EventArgs e)
    {
        ClosePP3DAT.Visible = false;

        RAISEPP3DAT.Visible = true;
        RAISEPP3DAT.ShowPopupWindow();
        QueryRaisePP3DAT.Visible = true;
        TextBoxRaisePP3DAT.Visible = true;


    }
    #endregion
    #region QueryPP4DAT
    private void SetImageQueryPP4DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP4DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP4DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP4DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP4DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP4DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP4DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP4DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP4DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP4DAT.Visible = true;
                PanelRaisePP4DAT2.Visible = false;
                PanelRaisePP4DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP4DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP4DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP4DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP4DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP4DAT.Visible = true;
                PanelRaisePP4DAT2.Visible = true;
                PanelRaisePP4DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP4DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP4DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP4DAT.Visible = true;
                PanelRaisePP4DAT2.Visible = true;
                PanelRaisePP4DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP4DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP4DAT = '" + TextBoxPP4DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP4DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP4DAT.Visible = true;
                RAISEPP4DAT.ShowPopupWindow();
                QueryRaisePP4DAT.Visible = true;
                TextBoxRaisePP4DAT.Visible = true;
                PanelRaisePP4DAT.Visible = false;
                PanelRaisePP4DAT2.Visible = false;
                PanelRaisePP4DAT3.Visible = false;

            }

            else if ((ImageQueryPP4DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP4DAT.Visible = true;
                RAISEPP4DAT.ShowPopupWindow();
                QueryRaisePP4DAT.Visible = false;
                TextBoxRaisePP4DAT.Visible = false;
            }

            else if ((ImageQueryPP4DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP4DAT.Visible = true;
                RespondedPP4DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP4DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP4DAT.Visible = true;
                ClosePP4DAT.ShowPopupWindow();
            }
            else
            {
                LockPP4DAT.Visible = true;
                LockPP4DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP4DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP4DAT.Text + "','" + TextBoxRaisePP4DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP4DAT = '" + TextBoxPP4DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP4DATMSG.ShowPopupWindow();
        RAISEPP4DAT.Visible = false;
        QueryRaisePP4DAT.Visible = false;
        TextBoxRaisePP4DAT.Visible = false;

    }

    protected void CloseQueryPP4DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP4DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP4DAT = '" + TextBoxPP4DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP4DATMSG.ShowPopupWindow();
        RespondedPP4DAT.Visible = false;
        RespondedPP4DATClose.Visible = false;


    }

    protected void SubmitReRaisePP4DAT_Click(object sender, EventArgs e)
    {
        ClosePP4DAT.Visible = false;

        RAISEPP4DAT.Visible = true;
        RAISEPP4DAT.ShowPopupWindow();
        QueryRaisePP4DAT.Visible = true;
        TextBoxRaisePP4DAT.Visible = true;


    }
    #endregion
    #region QueryPP5DAT
    private void SetImageQueryPP5DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP5DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP5DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP5DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP5DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP5DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP5DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP5DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP5DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP5DAT.Visible = true;
                PanelRaisePP5DAT2.Visible = false;
                PanelRaisePP5DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP5DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP5DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP5DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP5DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP5DAT.Visible = true;
                PanelRaisePP5DAT2.Visible = true;
                PanelRaisePP5DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP5DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP5DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP5DAT.Visible = true;
                PanelRaisePP5DAT2.Visible = true;
                PanelRaisePP5DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP5DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP5DAT = '" + TextBoxPP5DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP5DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP5DAT.Visible = true;
                RAISEPP5DAT.ShowPopupWindow();
                QueryRaisePP5DAT.Visible = true;
                TextBoxRaisePP5DAT.Visible = true;
                PanelRaisePP5DAT.Visible = false;
                PanelRaisePP5DAT2.Visible = false;
                PanelRaisePP5DAT3.Visible = false;

            }

            else if ((ImageQueryPP5DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP5DAT.Visible = true;
                RAISEPP5DAT.ShowPopupWindow();
                QueryRaisePP5DAT.Visible = false;
                TextBoxRaisePP5DAT.Visible = false;
            }

            else if ((ImageQueryPP5DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP5DAT.Visible = true;
                RespondedPP5DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP5DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP5DAT.Visible = true;
                ClosePP5DAT.ShowPopupWindow();
            }
            else
            {
                LockPP5DAT.Visible = true;
                LockPP5DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP5DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP5DAT.Text + "','" + TextBoxRaisePP5DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP5DAT = '" + TextBoxPP5DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP5DATMSG.ShowPopupWindow();
        RAISEPP5DAT.Visible = false;
        QueryRaisePP5DAT.Visible = false;
        TextBoxRaisePP5DAT.Visible = false;

    }

    protected void CloseQueryPP5DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP5DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP5DAT = '" + TextBoxPP5DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP5DATMSG.ShowPopupWindow();
        RespondedPP5DAT.Visible = false;
        RespondedPP5DATClose.Visible = false;


    }

    protected void SubmitReRaisePP5DAT_Click(object sender, EventArgs e)
    {
        ClosePP5DAT.Visible = false;

        RAISEPP5DAT.Visible = true;
        RAISEPP5DAT.ShowPopupWindow();
        QueryRaisePP5DAT.Visible = true;
        TextBoxRaisePP5DAT.Visible = true;


    }
    #endregion
    #region QueryPP6DAT
    private void SetImageQueryPP6DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP6DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP6DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP6DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP6DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP6DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP6DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP6DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP6DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP6DAT.Visible = true;
                PanelRaisePP6DAT2.Visible = false;
                PanelRaisePP6DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP6DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP6DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP6DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP6DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP6DAT.Visible = true;
                PanelRaisePP6DAT2.Visible = true;
                PanelRaisePP6DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP6DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP6DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP6DAT.Visible = true;
                PanelRaisePP6DAT2.Visible = true;
                PanelRaisePP6DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP6DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP6DAT = '" + TextBoxPP6DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP6DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP6DAT.Visible = true;
                RAISEPP6DAT.ShowPopupWindow();
                QueryRaisePP6DAT.Visible = true;
                TextBoxRaisePP6DAT.Visible = true;
                PanelRaisePP6DAT.Visible = false;
                PanelRaisePP6DAT2.Visible = false;
                PanelRaisePP6DAT3.Visible = false;

            }

            else if ((ImageQueryPP6DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP6DAT.Visible = true;
                RAISEPP6DAT.ShowPopupWindow();
                QueryRaisePP6DAT.Visible = false;
                TextBoxRaisePP6DAT.Visible = false;
            }

            else if ((ImageQueryPP6DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP6DAT.Visible = true;
                RespondedPP6DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP6DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP6DAT.Visible = true;
                ClosePP6DAT.ShowPopupWindow();
            }
            else
            {
                LockPP6DAT.Visible = true;
                LockPP6DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP6DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP6DAT.Text + "','" + TextBoxRaisePP6DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP6DAT = '" + TextBoxPP6DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP6DATMSG.ShowPopupWindow();
        RAISEPP6DAT.Visible = false;
        QueryRaisePP6DAT.Visible = false;
        TextBoxRaisePP6DAT.Visible = false;

    }

    protected void CloseQueryPP6DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP6DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP6DAT = '" + TextBoxPP6DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP6DATMSG.ShowPopupWindow();
        RespondedPP6DAT.Visible = false;
        RespondedPP6DATClose.Visible = false;


    }

    protected void SubmitReRaisePP6DAT_Click(object sender, EventArgs e)
    {
        ClosePP6DAT.Visible = false;

        RAISEPP6DAT.Visible = true;
        RAISEPP6DAT.ShowPopupWindow();
        QueryRaisePP6DAT.Visible = true;
        TextBoxRaisePP6DAT.Visible = true;


    }
    #endregion
    #region QueryPP7DAT
    private void SetImageQueryPP7DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP7DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP7DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP7DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP7DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP7DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP7DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP7DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP7DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP7DAT.Visible = true;
                PanelRaisePP7DAT2.Visible = false;
                PanelRaisePP7DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP7DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP7DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP7DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP7DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP7DAT.Visible = true;
                PanelRaisePP7DAT2.Visible = true;
                PanelRaisePP7DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP7DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP7DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP7DAT.Visible = true;
                PanelRaisePP7DAT2.Visible = true;
                PanelRaisePP7DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP7DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP7DAT = '" + TextBoxPP7DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP7DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP7DAT.Visible = true;
                RAISEPP7DAT.ShowPopupWindow();
                QueryRaisePP7DAT.Visible = true;
                TextBoxRaisePP7DAT.Visible = true;
                PanelRaisePP7DAT.Visible = false;
                PanelRaisePP7DAT2.Visible = false;
                PanelRaisePP7DAT3.Visible = false;

            }

            else if ((ImageQueryPP7DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP7DAT.Visible = true;
                RAISEPP7DAT.ShowPopupWindow();
                QueryRaisePP7DAT.Visible = false;
                TextBoxRaisePP7DAT.Visible = false;
            }

            else if ((ImageQueryPP7DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP7DAT.Visible = true;
                RespondedPP7DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP7DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP7DAT.Visible = true;
                ClosePP7DAT.ShowPopupWindow();
            }
            else
            {
                LockPP7DAT.Visible = true;
                LockPP7DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP7DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP7DAT.Text + "','" + TextBoxRaisePP7DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP7DAT = '" + TextBoxPP7DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP7DATMSG.ShowPopupWindow();
        RAISEPP7DAT.Visible = false;
        QueryRaisePP7DAT.Visible = false;
        TextBoxRaisePP7DAT.Visible = false;

    }

    protected void CloseQueryPP7DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP7DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP7DAT = '" + TextBoxPP7DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP7DATMSG.ShowPopupWindow();
        RespondedPP7DAT.Visible = false;
        RespondedPP7DATClose.Visible = false;


    }

    protected void SubmitReRaisePP7DAT_Click(object sender, EventArgs e)
    {
        ClosePP7DAT.Visible = false;

        RAISEPP7DAT.Visible = true;
        RAISEPP7DAT.ShowPopupWindow();
        QueryRaisePP7DAT.Visible = true;
        TextBoxRaisePP7DAT.Visible = true;


    }
    #endregion
    #region QueryPP8DAT
    private void SetImageQueryPP8DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP8DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP8DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP8DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP8DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP8DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP8DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP8DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP8DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP8DAT.Visible = true;
                PanelRaisePP8DAT2.Visible = false;
                PanelRaisePP8DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP8DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP8DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP8DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP8DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP8DAT.Visible = true;
                PanelRaisePP8DAT2.Visible = true;
                PanelRaisePP8DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP8DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP8DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP8DAT.Visible = true;
                PanelRaisePP8DAT2.Visible = true;
                PanelRaisePP8DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP8DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP8DAT = '" + TextBoxPP8DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP8DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP8DAT.Visible = true;
                RAISEPP8DAT.ShowPopupWindow();
                QueryRaisePP8DAT.Visible = true;
                TextBoxRaisePP8DAT.Visible = true;
                PanelRaisePP8DAT.Visible = false;
                PanelRaisePP8DAT2.Visible = false;
                PanelRaisePP8DAT3.Visible = false;

            }

            else if ((ImageQueryPP8DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP8DAT.Visible = true;
                RAISEPP8DAT.ShowPopupWindow();
                QueryRaisePP8DAT.Visible = false;
                TextBoxRaisePP8DAT.Visible = false;
            }

            else if ((ImageQueryPP8DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP8DAT.Visible = true;
                RespondedPP8DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP8DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP8DAT.Visible = true;
                ClosePP8DAT.ShowPopupWindow();
            }
            else
            {
                LockPP8DAT.Visible = true;
                LockPP8DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP8DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP8DAT.Text + "','" + TextBoxRaisePP8DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP8DAT = '" + TextBoxPP8DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP8DATMSG.ShowPopupWindow();
        RAISEPP8DAT.Visible = false;
        QueryRaisePP8DAT.Visible = false;
        TextBoxRaisePP8DAT.Visible = false;

    }

    protected void CloseQueryPP8DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP8DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP8DAT = '" + TextBoxPP8DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP8DATMSG.ShowPopupWindow();
        RespondedPP8DAT.Visible = false;
        RespondedPP8DATClose.Visible = false;


    }

    protected void SubmitReRaisePP8DAT_Click(object sender, EventArgs e)
    {
        ClosePP8DAT.Visible = false;

        RAISEPP8DAT.Visible = true;
        RAISEPP8DAT.ShowPopupWindow();
        QueryRaisePP8DAT.Visible = true;
        TextBoxRaisePP8DAT.Visible = true;


    }
    #endregion
    #region QueryPP9DAT
    private void SetImageQueryPP9DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP9DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP9DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP9DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP9DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP9DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP9DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP9DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP9DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP9DAT.Visible = true;
                PanelRaisePP9DAT2.Visible = false;
                PanelRaisePP9DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP9DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP9DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP9DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP9DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP9DAT.Visible = true;
                PanelRaisePP9DAT2.Visible = true;
                PanelRaisePP9DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP9DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP9DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP9DAT.Visible = true;
                PanelRaisePP9DAT2.Visible = true;
                PanelRaisePP9DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP9DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP9DAT = '" + TextBoxPP9DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP9DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP9DAT.Visible = true;
                RAISEPP9DAT.ShowPopupWindow();
                QueryRaisePP9DAT.Visible = true;
                TextBoxRaisePP9DAT.Visible = true;
                PanelRaisePP9DAT.Visible = false;
                PanelRaisePP9DAT2.Visible = false;
                PanelRaisePP9DAT3.Visible = false;

            }

            else if ((ImageQueryPP9DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP9DAT.Visible = true;
                RAISEPP9DAT.ShowPopupWindow();
                QueryRaisePP9DAT.Visible = false;
                TextBoxRaisePP9DAT.Visible = false;
            }

            else if ((ImageQueryPP9DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP9DAT.Visible = true;
                RespondedPP9DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP9DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP9DAT.Visible = true;
                ClosePP9DAT.ShowPopupWindow();
            }
            else
            {
                LockPP9DAT.Visible = true;
                LockPP9DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP9DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP9DAT.Text + "','" + TextBoxRaisePP9DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP9DAT = '" + TextBoxPP9DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP9DATMSG.ShowPopupWindow();
        RAISEPP9DAT.Visible = false;
        QueryRaisePP9DAT.Visible = false;
        TextBoxRaisePP9DAT.Visible = false;

    }

    protected void CloseQueryPP9DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP9DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP9DAT = '" + TextBoxPP9DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP9DATMSG.ShowPopupWindow();
        RespondedPP9DAT.Visible = false;
        RespondedPP9DATClose.Visible = false;


    }

    protected void SubmitReRaisePP9DAT_Click(object sender, EventArgs e)
    {
        ClosePP9DAT.Visible = false;

        RAISEPP9DAT.Visible = true;
        RAISEPP9DAT.ShowPopupWindow();
        QueryRaisePP9DAT.Visible = true;
        TextBoxRaisePP9DAT.Visible = true;


    }
    #endregion
    #region QueryPP10DAT
    private void SetImageQueryPP10DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP10DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP10DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP10DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP10DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP10DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP10DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP10DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP10DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP10DAT.Visible = true;
                PanelRaisePP10DAT2.Visible = false;
                PanelRaisePP10DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP10DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP10DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP10DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP10DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP10DAT.Visible = true;
                PanelRaisePP10DAT2.Visible = true;
                PanelRaisePP10DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP10DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP10DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP10DAT.Visible = true;
                PanelRaisePP10DAT2.Visible = true;
                PanelRaisePP10DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP10DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP10DAT = '" + TextBoxPP10DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP10DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP10DAT.Visible = true;
                RAISEPP10DAT.ShowPopupWindow();
                QueryRaisePP10DAT.Visible = true;
                TextBoxRaisePP10DAT.Visible = true;
                PanelRaisePP10DAT.Visible = false;
                PanelRaisePP10DAT2.Visible = false;
                PanelRaisePP10DAT3.Visible = false;

            }

            else if ((ImageQueryPP10DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP10DAT.Visible = true;
                RAISEPP10DAT.ShowPopupWindow();
                QueryRaisePP10DAT.Visible = false;
                TextBoxRaisePP10DAT.Visible = false;
            }

            else if ((ImageQueryPP10DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP10DAT.Visible = true;
                RespondedPP10DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP10DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP10DAT.Visible = true;
                ClosePP10DAT.ShowPopupWindow();
            }
            else
            {
                LockPP10DAT.Visible = true;
                LockPP10DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP10DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP10DAT.Text + "','" + TextBoxRaisePP10DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP10DAT = '" + TextBoxPP10DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP10DATMSG.ShowPopupWindow();
        RAISEPP10DAT.Visible = false;
        QueryRaisePP10DAT.Visible = false;
        TextBoxRaisePP10DAT.Visible = false;

    }

    protected void CloseQueryPP10DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP10DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP10DAT = '" + TextBoxPP10DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP10DATMSG.ShowPopupWindow();
        RespondedPP10DAT.Visible = false;
        RespondedPP10DATClose.Visible = false;


    }

    protected void SubmitReRaisePP10DAT_Click(object sender, EventArgs e)
    {
        ClosePP10DAT.Visible = false;

        RAISEPP10DAT.Visible = true;
        RAISEPP10DAT.ShowPopupWindow();
        QueryRaisePP10DAT.Visible = true;
        TextBoxRaisePP10DAT.Visible = true;


    }
    #endregion
    #region QueryPP11DAT
    private void SetImageQueryPP11DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP11DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP11DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP11DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP11DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP11DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP11DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP11DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP11DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP11DAT.Visible = true;
                PanelRaisePP11DAT2.Visible = false;
                PanelRaisePP11DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP11DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP11DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP11DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP11DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP11DAT.Visible = true;
                PanelRaisePP11DAT2.Visible = true;
                PanelRaisePP11DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP11DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP11DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP11DAT.Visible = true;
                PanelRaisePP11DAT2.Visible = true;
                PanelRaisePP11DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP11DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP11DAT = '" + TextBoxPP11DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP11DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP11DAT.Visible = true;
                RAISEPP11DAT.ShowPopupWindow();
                QueryRaisePP11DAT.Visible = true;
                TextBoxRaisePP11DAT.Visible = true;
                PanelRaisePP11DAT.Visible = false;
                PanelRaisePP11DAT2.Visible = false;
                PanelRaisePP11DAT3.Visible = false;

            }

            else if ((ImageQueryPP11DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP11DAT.Visible = true;
                RAISEPP11DAT.ShowPopupWindow();
                QueryRaisePP11DAT.Visible = false;
                TextBoxRaisePP11DAT.Visible = false;
            }

            else if ((ImageQueryPP11DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP11DAT.Visible = true;
                RespondedPP11DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP11DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP11DAT.Visible = true;
                ClosePP11DAT.ShowPopupWindow();
            }
            else
            {
                LockPP11DAT.Visible = true;
                LockPP11DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP11DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP11DAT.Text + "','" + TextBoxRaisePP11DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP11DAT = '" + TextBoxPP11DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP11DATMSG.ShowPopupWindow();
        RAISEPP11DAT.Visible = false;
        QueryRaisePP11DAT.Visible = false;
        TextBoxRaisePP11DAT.Visible = false;

    }

    protected void CloseQueryPP11DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP11DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP11DAT = '" + TextBoxPP11DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP11DATMSG.ShowPopupWindow();
        RespondedPP11DAT.Visible = false;
        RespondedPP11DATClose.Visible = false;


    }

    protected void SubmitReRaisePP11DAT_Click(object sender, EventArgs e)
    {
        ClosePP11DAT.Visible = false;

        RAISEPP11DAT.Visible = true;
        RAISEPP11DAT.ShowPopupWindow();
        QueryRaisePP11DAT.Visible = true;
        TextBoxRaisePP11DAT.Visible = true;


    }
    #endregion
    #region QueryPP12DAT
    private void SetImageQueryPP12DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP12DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP12DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP12DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP12DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP12DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP12DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP12DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP12DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP12DAT.Visible = true;
                PanelRaisePP12DAT2.Visible = false;
                PanelRaisePP12DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP12DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP12DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP12DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP12DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP12DAT.Visible = true;
                PanelRaisePP12DAT2.Visible = true;
                PanelRaisePP12DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP12DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP12DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP12DAT.Visible = true;
                PanelRaisePP12DAT2.Visible = true;
                PanelRaisePP12DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP12DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP12DAT = '" + TextBoxPP12DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP12DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP12DAT.Visible = true;
                RAISEPP12DAT.ShowPopupWindow();
                QueryRaisePP12DAT.Visible = true;
                TextBoxRaisePP12DAT.Visible = true;
                PanelRaisePP12DAT.Visible = false;
                PanelRaisePP12DAT2.Visible = false;
                PanelRaisePP12DAT3.Visible = false;

            }

            else if ((ImageQueryPP12DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP12DAT.Visible = true;
                RAISEPP12DAT.ShowPopupWindow();
                QueryRaisePP12DAT.Visible = false;
                TextBoxRaisePP12DAT.Visible = false;
            }

            else if ((ImageQueryPP12DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP12DAT.Visible = true;
                RespondedPP12DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP12DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP12DAT.Visible = true;
                ClosePP12DAT.ShowPopupWindow();
            }
            else
            {
                LockPP12DAT.Visible = true;
                LockPP12DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP12DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP12DAT.Text + "','" + TextBoxRaisePP12DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP12DAT = '" + TextBoxPP12DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP12DATMSG.ShowPopupWindow();
        RAISEPP12DAT.Visible = false;
        QueryRaisePP12DAT.Visible = false;
        TextBoxRaisePP12DAT.Visible = false;

    }

    protected void CloseQueryPP12DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP12DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP12DAT = '" + TextBoxPP12DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP12DATMSG.ShowPopupWindow();
        RespondedPP12DAT.Visible = false;
        RespondedPP12DATClose.Visible = false;


    }

    protected void SubmitReRaisePP12DAT_Click(object sender, EventArgs e)
    {
        ClosePP12DAT.Visible = false;

        RAISEPP12DAT.Visible = true;
        RAISEPP12DAT.ShowPopupWindow();
        QueryRaisePP12DAT.Visible = true;
        TextBoxRaisePP12DAT.Visible = true;


    }
    #endregion
    #region QueryPP13DAT
    private void SetImageQueryPP13DAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP13DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPP13DAT.ImageUrl = "~/Study-Monitor/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPP13DAT.ImageUrl = "~/Study-Monitor/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPP13DAT.ImageUrl = "~/Study-Monitor/Images/Yellow.png";

            }
            else
            {
                ImageQueryPP13DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPP13DAT.ImageUrl = "~/Study-Monitor/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataPP13DAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP13DAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePP13DAT.Visible = true;
                PanelRaisePP13DAT2.Visible = false;
                PanelRaisePP13DAT3.Visible = false;
                Lock.Visible = false;
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaisePP13DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedPP13DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelClosePP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP13DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockPP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP13DAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePP13DAT.Visible = true;
                PanelRaisePP13DAT2.Visible = true;
                PanelRaisePP13DAT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedPP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedPP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelClosePP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelClosePP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockPP13DAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockPP13DAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaisePP13DAT.Visible = true;
                PanelRaisePP13DAT2.Visible = true;
                PanelRaisePP13DAT3.Visible = false;
                Lock.Visible = false;
            }
            else
            {
            }

        }
    }
    protected void ImageQueryPP13DAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[ProceduresPerformed] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP13DAT = '" + TextBoxPP13DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPP13DAT.ImageUrl == "~/Study-Monitor/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPP13DAT.Visible = true;
                RAISEPP13DAT.ShowPopupWindow();
                QueryRaisePP13DAT.Visible = true;
                TextBoxRaisePP13DAT.Visible = true;
                PanelRaisePP13DAT.Visible = false;
                PanelRaisePP13DAT2.Visible = false;
                PanelRaisePP13DAT3.Visible = false;

            }

            else if ((ImageQueryPP13DAT.ImageUrl == "~/Study-Monitor/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPP13DAT.Visible = true;
                RAISEPP13DAT.ShowPopupWindow();
                QueryRaisePP13DAT.Visible = false;
                TextBoxRaisePP13DAT.Visible = false;
            }

            else if ((ImageQueryPP13DAT.ImageUrl == "~/Study-Monitor/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedPP13DAT.Visible = true;
                RespondedPP13DAT.ShowPopupWindow();
            }
            else if ((ImageQueryPP13DAT.ImageUrl == "~/Study-Monitor/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                ClosePP13DAT.Visible = true;
                ClosePP13DAT.ShowPopupWindow();
            }
            else
            {
                LockPP13DAT.Visible = true;
                LockPP13DAT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaisePP13DAT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblPP13DAT.Text + "','" + TextBoxRaisePP13DAT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP13DAT = '" + TextBoxPP13DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPP13DATMSG.ShowPopupWindow();
        RAISEPP13DAT.Visible = false;
        QueryRaisePP13DAT.Visible = false;
        TextBoxRaisePP13DAT.Visible = false;

    }

    protected void CloseQueryPP13DAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPP13DAT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[ProceduresPerformed] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PP13DAT = '" + TextBoxPP13DAT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEPP13DATMSG.ShowPopupWindow();
        RespondedPP13DAT.Visible = false;
        RespondedPP13DATClose.Visible = false;


    }

    protected void SubmitReRaisePP13DAT_Click(object sender, EventArgs e)
    {
        ClosePP13DAT.Visible = false;

        RAISEPP13DAT.Visible = true;
        RAISEPP13DAT.ShowPopupWindow();
        QueryRaisePP13DAT.Visible = true;
        TextBoxRaisePP13DAT.Visible = true;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Study-Monitor/StudyMonitorActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }
}