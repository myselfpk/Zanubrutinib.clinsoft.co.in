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

public partial class Data_Entry_AdVisit_AdverseEventForm : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd1;
    SqlDataAdapter da = new SqlDataAdapter();

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

        SetImageQueryAESNO();
        SetImageQueryAEOND();
        SetImageQueryAEED();
        SetImageQueryAEOTCM();
        SetImageQueryAESVR();
        SetImageQueryAERIP();
        SetImageQueryAEAT();
        SetImageQueryAECS();
        SetImageQueryAETEAE();
        SetImageQueryAESAECR();
        SetImageQueryAESAECRO();

        BindQueryDataAESNO();
        BindQueryDataAEOND();
        BindQueryDataAEED();
        BindQueryDataAEOTCM();
        BindQueryDataAESVR();
        BindQueryDataAERIP();
        BindQueryDataAEAT();
        BindQueryDataAECS();
        BindQueryDataAETEAE();
        BindQueryDataAESAECR();
        BindQueryDataAESAECRO();

        TextBoxAEOND_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxAEED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        if (RadioButtonListAESAECR.SelectedValue == "Other medically significant events")
        {
            hideAESAECRO.Visible = true;
        }
        else
        {
            hideAESAECRO.Visible = false;
        }
    }

    #region Note Acttchment and PageHistory
    #region AddNote
    private void SetImageAddNote()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from ADDNOTE  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and Page = '" + lblPage.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            ImgAddNote.ImageUrl = "~/Data-Entry/Images/NoteADD.png";
        }
        else
        {
            ImgAddNote.ImageUrl = "~/Data-Entry/Images/BlankNote.png";

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

        cmd = new SqlCommand("insert into ADDNOTE values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + AddNoteFiledTextBox.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','" + AddNoteTextBox.Text + "','" + TextBoxAESNO.Text + "')", con);
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
            SqlCommand cmd = new SqlCommand("select * from ADDNOTE where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxAESNO.Text + "'  and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
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
        con.Close(); string id = GridviewAddNote.DataKeys[e.RowIndex].Value.ToString();

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
        SqlCommand cmd = new SqlCommand("Select * from ADDATTACHMENT  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxAESNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            ImgAddAttachment.ImageUrl = "~/Data-Entry/Images/AttachmentADD.png";
        }
        else
        {
            ImgAddAttachment.ImageUrl = "~/Data-Entry/Images/BlankAttachment.png";

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
                        cmd.Parameters.AddWithValue("@Visit", lblVisit.Text);
                        cmd.Parameters.AddWithValue("@Page", lblPage.Text);
                        cmd.Parameters.AddWithValue("@Field", AddAttachmentFiledTextBox.Text);
                        cmd.Parameters.AddWithValue("@Username", LabelUserName.Text);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today.ToString("dd-MMM-yyyy"));
                        cmd.Parameters.AddWithValue("@Title", TextBoxADDAddAttachment.Text);
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Parameters.AddWithValue("@SNO", TextBoxAESNO.Text);
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
                cmd.CommandText = "select ID,Site,ScreenID,SubInitial ,Visit,Page,Field,Username,Date,Title,Name ,ContentType,Data from ADDATTACHMENT where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxAESNO.Text + "'";
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
        con.Close(); string id = GridViewADDAddAttachment.DataKeys[e.RowIndex].Value.ToString();

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
        SqlCommand cmd = new SqlCommand("Select * from tblReasonForChange  where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            AttachmentPageHistory.ImageUrl = "~/Data-Entry/Images/PageHistory.png";
        }
        else
        {
            AttachmentPageHistory.ImageUrl = "~/Data-Entry/Images/PHistory.png";

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
                cmd.CommandText = "SELECT ID, [QuestionText],[OldValue],[NewValue],[Reason],[PageName],[EUser],[EDate] FROM [dbo].[tblReasonForChange] where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'and SNO = '" + TextBoxAESNO.Text + "'";
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
        SqlCommand sqlCmd = new SqlCommand("SELECT AESNO ,AEOND ,AEED ,AEOTCM ,AESVR ,AERIP ,AEAT ,AECS ,AETEAE ,AESAECR ,AESAECRO FROM [Add].[AdverseEventForm] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and [AESNO]='" + Request.QueryString["f"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxAESNO.Text = dt.Rows[0]["AESNO"].ToString();
            TextBoxAEOND.Text = dt.Rows[0]["AEOND"].ToString();
            TextBoxAEED.Text = dt.Rows[0]["AEED"].ToString();
            RadioButtonListAEOTCM.SelectedValue = dt.Rows[0]["AEOTCM"].ToString();
            RadioButtonListAESVR.SelectedValue = dt.Rows[0]["AESVR"].ToString();
            RadioButtonListAERIP.SelectedValue = dt.Rows[0]["AERIP"].ToString();
            RadioButtonListAEAT.SelectedValue = dt.Rows[0]["AEAT"].ToString();
            RadioButtonListAECS.SelectedValue = dt.Rows[0]["AECS"].ToString();
            RadioButtonListAETEAE.SelectedValue = dt.Rows[0]["AETEAE"].ToString();
            RadioButtonListAESAECR.SelectedValue = dt.Rows[0]["AESAECR"].ToString();
            TextBoxAESAECRO.Text = dt.Rows[0]["AESAECRO"].ToString();

            ViewState["txt1"] = TextBoxAESNO.Text;
            ViewState["txt2"] = TextBoxAEOND.Text;
            ViewState["txt3"] = TextBoxAEED.Text;
            ViewState["txt4"] = RadioButtonListAEOTCM.SelectedValue;
            ViewState["txt5"] = RadioButtonListAESVR.SelectedValue;
            ViewState["txt6"] = RadioButtonListAERIP.SelectedValue;
            ViewState["txt7"] = RadioButtonListAEAT.SelectedValue;
            ViewState["txt8"] = RadioButtonListAECS.SelectedValue;
            ViewState["txt9"] = RadioButtonListAETEAE.SelectedValue;
            ViewState["txt10"] = RadioButtonListAESAECR.SelectedValue;
            ViewState["txt11"] = TextBoxAESAECRO.Text;
        }
        con.Close();

    }

    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Add].[AdverseEventForm]  where [SITENUM] ='" + Request.QueryString["a"] + "' and [AESNO]='" + Request.QueryString["f"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            if (dt1.Rows[0]["EntryStatus"].ToString() == "Save" && dt1.Rows[0]["LockStatus"].ToString() == "Unlocked")
            {
                Save.Visible = true;
                Submit.Visible = true;
            }
            if (dt1.Rows[0]["EntryStatus"].ToString() == "Submit" && dt1.Rows[0]["LockStatus"].ToString() == "Unlocked")
            {
                Submit.Visible = true;
                Save.Visible = false;
            }
            if (dt1.Rows[0]["EntryStatus"].ToString() == "Submit" && dt1.Rows[0]["LockStatus"].ToString() == "SDV")
            {
                Save.Visible = false;
                Submit.Visible = true;
            }
            if (dt1.Rows[0]["EntryStatus"].ToString() == "Submit" && dt1.Rows[0]["LockStatus"].ToString() == "Locked")
            {
                Save.Visible = false;
                Submit.Visible = false;
            }
        }
    }

    #endregion

    #region Data Save And Submit 
    public void OnConfirm(object sender, EventArgs e)
    {
        con.Close();
        DataTable dt2 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Add].[AdverseEventForm]  where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'and AESNO='"+ Request.QueryString["f"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {

            if (dt2.Rows[0]["EntryStatus"].ToString() == "Save")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    con.Close();
                    cmd = new SqlCommand("[Add].[sp_AdverseEventForm]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@AESNO", TextBoxAESNO.Text);
                    cmd.Parameters.AddWithValue("@AEOND", TextBoxAEOND.Text);
                    cmd.Parameters.AddWithValue("@AEED", TextBoxAEED.Text);
                    cmd.Parameters.AddWithValue("@AEOTCM", RadioButtonListAEOTCM.SelectedValue);
                    cmd.Parameters.AddWithValue("@AESVR", RadioButtonListAESVR.SelectedValue);
                    cmd.Parameters.AddWithValue("@AERIP", RadioButtonListAERIP.SelectedValue);
                    cmd.Parameters.AddWithValue("@AEAT", RadioButtonListAEAT.SelectedValue);
                    cmd.Parameters.AddWithValue("@AECS", RadioButtonListAECS.SelectedValue);
                    cmd.Parameters.AddWithValue("@AETEAE", RadioButtonListAETEAE.SelectedValue);
                    cmd.Parameters.AddWithValue("@AESAECR", RadioButtonListAESAECR.SelectedValue);
                    cmd.Parameters.AddWithValue("@AESAECRO", TextBoxAESAECRO.Text);

                    cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                    cmd.Parameters.AddWithValue("@PAGENAME", lblPage.Text);

                    cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
                    cmd.Parameters.AddWithValue("@EntryStatus", "Submit");
                    cmd.Parameters.AddWithValue("@QueryStatus", "No Query");
                    cmd.Parameters.AddWithValue("@mode", "Update");
                    cmd.Parameters.AddWithValue("@MUser", Session["UserName"]);
                    cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                    cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                    cmd.Parameters.AddWithValue("@ActivefLag", "1");
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);

                    }

                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Already Exists !!')", true);
                    }


                }


                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not Submitted!')", true);
                }
            }
            if (dt2.Rows[0]["EntryStatus"].ToString() == "Submit")
            {

                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    con.Close();
                    DataTable dt1 = new DataTable();
                    con.Open();
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Add].[AdverseEventForm] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "' and AESNO='" + Request.QueryString["f"] + "' and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString().Trim() != TextBoxAESNO.Text || ViewState["txt2"].ToString().Trim() != TextBoxAEOND.Text || ViewState["txt3"].ToString().Trim() != TextBoxAEED.Text || ViewState["txt4"].ToString().Trim() != RadioButtonListAEOTCM.SelectedValue || ViewState["txt5"].ToString().Trim() != RadioButtonListAESVR.SelectedValue || ViewState["txt6"].ToString().Trim() != RadioButtonListAERIP.SelectedValue || ViewState["txt7"].ToString().Trim() != RadioButtonListAEAT.SelectedValue || ViewState["txt8"].ToString().Trim() != RadioButtonListAECS.SelectedValue || ViewState["txt9"].ToString().Trim() != RadioButtonListAETEAE.SelectedValue || ViewState["txt10"].ToString().Trim() != RadioButtonListAESAECR.SelectedValue || ViewState["txt11"].ToString().Trim() != TextBoxAESAECRO.Text)
                            {
                                GridView1.Visible = true;
                                AddDefaultFirstRecord();
                                PanelChangedata.Visible = true;
                                MainPanel.Visible = false;

                            }
                        }
                        else
                        {
                        }
                    }
                }


                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not Submitted!')", true);
                }
            }
        }
        else
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                con.Close();
                cmd = new SqlCommand("[Add].[sp_AdverseEventForm]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@AESNO", TextBoxAESNO.Text);
                cmd.Parameters.AddWithValue("@AEOND", TextBoxAEOND.Text);
                cmd.Parameters.AddWithValue("@AEED", TextBoxAEED.Text);
                cmd.Parameters.AddWithValue("@AEOTCM", RadioButtonListAEOTCM.SelectedValue);
                cmd.Parameters.AddWithValue("@AESVR", RadioButtonListAESVR.SelectedValue);
                cmd.Parameters.AddWithValue("@AERIP", RadioButtonListAERIP.SelectedValue);
                cmd.Parameters.AddWithValue("@AEAT", RadioButtonListAEAT.SelectedValue);
                cmd.Parameters.AddWithValue("@AECS", RadioButtonListAECS.SelectedValue);
                cmd.Parameters.AddWithValue("@AETEAE", RadioButtonListAETEAE.SelectedValue);
                cmd.Parameters.AddWithValue("@AESAECR", RadioButtonListAESAECR.SelectedValue);
                cmd.Parameters.AddWithValue("@AESAECRO", TextBoxAESAECRO.Text);

                cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                cmd.Parameters.AddWithValue("@PAGENAME", lblPage.Text);

                cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
                cmd.Parameters.AddWithValue("@EntryStatus", "Submit");
                cmd.Parameters.AddWithValue("@QueryStatus", "No Query");
                cmd.Parameters.AddWithValue("@mode", "Update");
                cmd.Parameters.AddWithValue("@MUser", Session["UserName"]);
                cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                cmd.Parameters.AddWithValue("@ActivefLag", "1");
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);

                }

                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Already Exists !!')", true);
                }


            }


            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not Submitted!')", true);
            }
        }
    }
    public void OnConfirm1(object sender, EventArgs e)
    {
        con.Close();
        DataTable dt3 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Add].[AdverseEventForm]  where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'and AESNO='"+ Request.QueryString["f"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            if (dt3.Rows[0]["EntryStatus"].ToString() == "Save")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    con.Close();
                    cmd = new SqlCommand("[Add].[sp_AdverseEventForm]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@AESNO", TextBoxAESNO.Text);
                    cmd.Parameters.AddWithValue("@AEOND", TextBoxAEOND.Text);
                    cmd.Parameters.AddWithValue("@AEED", TextBoxAEED.Text);
                    cmd.Parameters.AddWithValue("@AEOTCM", RadioButtonListAEOTCM.SelectedValue);
                    cmd.Parameters.AddWithValue("@AESVR", RadioButtonListAESVR.SelectedValue);
                    cmd.Parameters.AddWithValue("@AERIP", RadioButtonListAERIP.SelectedValue);
                    cmd.Parameters.AddWithValue("@AEAT", RadioButtonListAEAT.SelectedValue);
                    cmd.Parameters.AddWithValue("@AECS", RadioButtonListAECS.SelectedValue);
                    cmd.Parameters.AddWithValue("@AETEAE", RadioButtonListAETEAE.SelectedValue);
                    cmd.Parameters.AddWithValue("@AESAECR", RadioButtonListAESAECR.SelectedValue);
                    cmd.Parameters.AddWithValue("@AESAECRO", TextBoxAESAECRO.Text);

                    cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                    cmd.Parameters.AddWithValue("@PAGENAME", lblPage.Text);

                    cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
                    cmd.Parameters.AddWithValue("@EntryStatus", "Save");
                    cmd.Parameters.AddWithValue("@QueryStatus", "No Query");
                    cmd.Parameters.AddWithValue("@mode", "Update");
                    cmd.Parameters.AddWithValue("@MUser", Session["UserName"]);
                    cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                    cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                    cmd.Parameters.AddWithValue("@ActivefLag", "");
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {

                        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
                    }

                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Already Exists !!')", true);
                    }

                }


                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not Saved!')", true);
                }
            }
        }
        else
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                con.Close();
                cmd = new SqlCommand("[Add].[sp_AdverseEventForm]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@AESNO", TextBoxAESNO.Text);
                cmd.Parameters.AddWithValue("@AEOND", TextBoxAEOND.Text);
                cmd.Parameters.AddWithValue("@AEED", TextBoxAEED.Text);
                cmd.Parameters.AddWithValue("@AEOTCM", RadioButtonListAEOTCM.SelectedValue);
                cmd.Parameters.AddWithValue("@AESVR", RadioButtonListAESVR.SelectedValue);
                cmd.Parameters.AddWithValue("@AERIP", RadioButtonListAERIP.SelectedValue);
                cmd.Parameters.AddWithValue("@AEAT", RadioButtonListAEAT.SelectedValue);
                cmd.Parameters.AddWithValue("@AECS", RadioButtonListAECS.SelectedValue);
                cmd.Parameters.AddWithValue("@AETEAE", RadioButtonListAETEAE.SelectedValue);
                cmd.Parameters.AddWithValue("@AESAECR", RadioButtonListAESAECR.SelectedValue);
                cmd.Parameters.AddWithValue("@AESAECRO", TextBoxAESAECRO.Text);

                cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                cmd.Parameters.AddWithValue("@PAGENAME", lblPage.Text);

                cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
                cmd.Parameters.AddWithValue("@EntryStatus", "Save");
                cmd.Parameters.AddWithValue("@QueryStatus", "No Query");
                cmd.Parameters.AddWithValue("@mode", "Update");
                cmd.Parameters.AddWithValue("@MUser", Session["UserName"]);
                cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
                cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
                cmd.Parameters.AddWithValue("@ActivefLag", "");
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {

                    Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
                }

                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data Already Exists !!')", true);
                }

            }


            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not Saved!')", true);
            }
        }
    }





    private void AddDefaultFirstRecord()
    {

        DataTable dt = AddRow();

        GridView1.DataSource = dt;
        GridView1.DataBind();


    }
    private DataTable AddRow()
    {
        DataTable dtEmp = new DataTable();
        if (ViewState["dtEmp"] == null)
        {
            dtEmp.Columns.Add("Column", typeof(string));
            dtEmp.Columns.Add("OldValue", typeof(string));
            dtEmp.Columns.Add("NewValue", typeof(string));

        }
        else
        {
            dtEmp = (DataTable)ViewState["dtEmp"];
        }
        if (!string.IsNullOrEmpty(TextBoxAESNO.Text) || !string.IsNullOrEmpty(TextBoxAEOND.Text) || !string.IsNullOrEmpty(TextBoxAEED.Text) || !string.IsNullOrEmpty(RadioButtonListAEOTCM.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListAESVR.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListAERIP.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListAEAT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListAECS.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListAETEAE.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListAESAECR.SelectedValue) || !string.IsNullOrEmpty(TextBoxAESAECRO.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString().Trim() != TextBoxAESNO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAESNO.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = TextBoxAESNO.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString().Trim() != TextBoxAEOND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAEOND.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxAEOND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString().Trim() != TextBoxAEED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAEED.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxAEED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString().Trim() != RadioButtonListAEOTCM.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAEOTCM.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListAEOTCM.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString().Trim() != RadioButtonListAESVR.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAESVR.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListAESVR.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString().Trim() != RadioButtonListAERIP.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAERIP.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = RadioButtonListAERIP.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString().Trim() != RadioButtonListAEAT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAEAT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListAEAT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString().Trim() != RadioButtonListAECS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAECS.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListAECS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString().Trim() != RadioButtonListAETEAE.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAETEAE.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListAETEAE.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString().Trim() != RadioButtonListAESAECR.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAESAECR.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = RadioButtonListAESAECR.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString().Trim() != TextBoxAESAECRO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblAESAECRO.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = TextBoxAESAECRO.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Add].[sp_AdverseEventForm]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@AESNO", TextBoxAESNO.Text);
            cmd.Parameters.AddWithValue("@AEOND", TextBoxAEOND.Text);
            cmd.Parameters.AddWithValue("@AEED", TextBoxAEED.Text);
            cmd.Parameters.AddWithValue("@AEOTCM", RadioButtonListAEOTCM.SelectedValue);
            cmd.Parameters.AddWithValue("@AESVR", RadioButtonListAESVR.SelectedValue);
            cmd.Parameters.AddWithValue("@AERIP", RadioButtonListAERIP.SelectedValue);
            cmd.Parameters.AddWithValue("@AEAT", RadioButtonListAEAT.SelectedValue);
            cmd.Parameters.AddWithValue("@AECS", RadioButtonListAECS.SelectedValue);
            cmd.Parameters.AddWithValue("@AETEAE", RadioButtonListAETEAE.SelectedValue);
            cmd.Parameters.AddWithValue("@AESAECR", RadioButtonListAESAECR.SelectedValue);
            cmd.Parameters.AddWithValue("@AESAECRO", TextBoxAESAECRO.Text);

            cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
            cmd.Parameters.AddWithValue("@PAGENAME", lblPage.Text);

            cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
            cmd.Parameters.AddWithValue("@EntryStatus", "Submit");
            cmd.Parameters.AddWithValue("@QueryStatus", "No Query");
            cmd.Parameters.AddWithValue("@mode", "Update");
            cmd.Parameters.AddWithValue("@MUser", Session["UserName"]);
            cmd.Parameters.AddWithValue("@Role", Session["UserRoles"]);
            cmd.Parameters.AddWithValue("@PageUrl", HttpContext.Current.Request.Url.AbsoluteUri);
            cmd.Parameters.AddWithValue("@ActivefLag", "1");
            con.Close();
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                #region Gridview Reason Data Insert
                foreach (GridViewRow row in GridView1.Rows)
                {

                    Label lbColumn = (Label)row.FindControl("lbColumn");
                    Label lbOldValue = (Label)row.FindControl("lbOldValue");
                    Label lbNewValue = (Label)row.FindControl("lbNewValue");
                    TextBox txtComment = (TextBox)row.FindControl("txtComment");

                    dataInsert(lbColumn.Text, lbOldValue.Text, lbNewValue.Text, txtComment.Text);
                }

                #endregion

                Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
            }

            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not Submitted!')", true);
            }
        }



        finally
        {
            con.Close();
        }
    }
    public void dataInsert(string QuestionText, string OldValue, string NewValue, string Reason)
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            con.Close();
            cmd.CommandText = "INSERT INTO tblReasonForChange (Site,  SubId,  Subini,  QuestionText,  OldValue,  NewValue,  Reason, PageName,  EUser,SNO) VALUES        (@Site,  @SubId,  @Subini,  @QuestionText,  @OldValue,  @NewValue,  @Reason, @PageName,  @EUser,@SNO)";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.AddWithValue("@Site", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SubID", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SubIni", Request.QueryString["c"]);
            cmd.Parameters.AddWithValue("@QuestionText", QuestionText);
            cmd.Parameters.AddWithValue("@OldValue", OldValue);
            cmd.Parameters.AddWithValue("@NewValue", NewValue);
            cmd.Parameters.AddWithValue("@Reason", Reason);
            cmd.Parameters.AddWithValue("@PageName", lblVisit.Text + "-" + lblPage.Text);
            cmd.Parameters.AddWithValue("@EUser", LabelUserName.Text);
            cmd.Parameters.AddWithValue("@SNO", TextBoxAESNO.Text);


            con.Open();
            cmd.ExecuteNonQuery();
        }
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        MainPanel.Visible = true;
        PanelChangedata.Visible = false;
    }

    #endregion
    #region Query
    #region QueryAESNO
    private void SetImageQueryAESNO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAESNO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAESNO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAESNO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAESNO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAESNO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAESNO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAESNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAESNO.Visible = true;
                PanelRaiseAESNO2.Visible = false;
                PanelRaiseAESNO3.Visible = false;
                PanelHideAESNO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAESNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAESNO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAESNO.Visible = true;
                PanelRaiseAESNO2.Visible = true;
                PanelRaiseAESNO3.Visible = true;
                PanelHideAESNO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAESNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAESNO.Visible = true;
                PanelRaiseAESNO2.Visible = true;
                PanelRaiseAESNO3.Visible = false;
                PanelHideAESNO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAESNO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESNO = '" + TextBoxAESNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAESNO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAESNO.Visible = true;
                RAISEAESNO.ShowPopupWindow();
                QueryRaiseAESNO.Visible = false;
                TextBoxRaiseAESNO.Visible = false;
                PanelRaiseAESNO.Visible = false;
                PanelRaiseAESNO2.Visible = false;
                PanelRaiseAESNO3.Visible = false;

                LabelRespondAESNO.Visible = false;
            }

            else if ((ImageQueryAESNO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESNO.Visible = true;
                RAISEAESNO.ShowPopupWindow();
                QueryRaiseAESNO.Visible = true;
                TextBoxRaiseAESNO.Visible = true;
                PanelRaiseAESNO.Visible = true;
                PanelRaiseAESNO2.Visible = false;
                PanelRaiseAESNO3.Visible = false;
                LabelRespondAESNO.Visible = true;
            }

            else if ((ImageQueryAESNO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESNO.Visible = true;
                RAISEAESNO.ShowPopupWindow();
                QueryRaiseAESNO.Visible = false;
                TextBoxRaiseAESNO.Visible = false;
                PanelRaiseAESNO.Visible = true;
                PanelRaiseAESNO2.Visible = true;
                PanelRaiseAESNO3.Visible = false;
                LabelRespondAESNO.Visible = false;
            }
            else if ((ImageQueryAESNO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESNO.Visible = true;
                RAISEAESNO.ShowPopupWindow();
                QueryRaiseAESNO.Visible = false;
                TextBoxRaiseAESNO.Visible = false;
                PanelRaiseAESNO.Visible = true;
                PanelRaiseAESNO2.Visible = true;
                PanelRaiseAESNO3.Visible = true;
                LabelRespondAESNO.Visible = false;
            }
            else
            {
                RAISEAESNO.Visible = true;
                RAISEAESNO.ShowPopupWindow();
                QueryRaiseAESNO.Visible = false;
                TextBoxRaiseAESNO.Visible = false;
                PanelRaiseAESNO.Visible = true;
                PanelRaiseAESNO2.Visible = true;
                PanelRaiseAESNO3.Visible = true;
                LabelRespondAESNO.Visible = false;

            }
        }

    }
    protected void QueryRaiseAESNO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAESNO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAESNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESNO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESNO = '" + TextBoxAESNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAESNOMSG.ShowPopupWindow();
        RAISEAESNO.Visible = false;


    }
    #endregion
    #region QueryAEOND
    private void SetImageQueryAEOND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEOND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAEOND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAEOND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAEOND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAEOND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAEOND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAEOND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEOND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAEOND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAEOND.Visible = true;
                PanelRaiseAEOND2.Visible = false;
                PanelRaiseAEOND3.Visible = false;
                PanelHideAEOND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAEOND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEOND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAEOND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAEOND.Visible = true;
                PanelRaiseAEOND2.Visible = true;
                PanelRaiseAEOND3.Visible = true;
                PanelHideAEOND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAEOND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEOND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAEOND.Visible = true;
                PanelRaiseAEOND2.Visible = true;
                PanelRaiseAEOND3.Visible = false;
                PanelHideAEOND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAEOND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEOND = '" + TextBoxAEOND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAEOND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAEOND.Visible = true;
                RAISEAEOND.ShowPopupWindow();
                QueryRaiseAEOND.Visible = false;
                TextBoxRaiseAEOND.Visible = false;
                PanelRaiseAEOND.Visible = false;
                PanelRaiseAEOND2.Visible = false;
                PanelRaiseAEOND3.Visible = false;

                LabelRespondAEOND.Visible = false;
            }

            else if ((ImageQueryAEOND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEOND.Visible = true;
                RAISEAEOND.ShowPopupWindow();
                QueryRaiseAEOND.Visible = true;
                TextBoxRaiseAEOND.Visible = true;
                PanelRaiseAEOND.Visible = true;
                PanelRaiseAEOND2.Visible = false;
                PanelRaiseAEOND3.Visible = false;
                LabelRespondAEOND.Visible = true;
            }

            else if ((ImageQueryAEOND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEOND.Visible = true;
                RAISEAEOND.ShowPopupWindow();
                QueryRaiseAEOND.Visible = false;
                TextBoxRaiseAEOND.Visible = false;
                PanelRaiseAEOND.Visible = true;
                PanelRaiseAEOND2.Visible = true;
                PanelRaiseAEOND3.Visible = false;
                LabelRespondAEOND.Visible = false;
            }
            else if ((ImageQueryAEOND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEOND.Visible = true;
                RAISEAEOND.ShowPopupWindow();
                QueryRaiseAEOND.Visible = false;
                TextBoxRaiseAEOND.Visible = false;
                PanelRaiseAEOND.Visible = true;
                PanelRaiseAEOND2.Visible = true;
                PanelRaiseAEOND3.Visible = true;
                LabelRespondAEOND.Visible = false;
            }
            else
            {
                RAISEAEOND.Visible = true;
                RAISEAEOND.ShowPopupWindow();
                QueryRaiseAEOND.Visible = false;
                TextBoxRaiseAEOND.Visible = false;
                PanelRaiseAEOND.Visible = true;
                PanelRaiseAEOND2.Visible = true;
                PanelRaiseAEOND3.Visible = true;
                LabelRespondAEOND.Visible = false;

            }
        }

    }
    protected void QueryRaiseAEOND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAEOND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAEOND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEOND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEOND = '" + TextBoxAEOND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAEONDMSG.ShowPopupWindow();
        RAISEAEOND.Visible = false;


    }
    #endregion
    #region QueryAEED
    private void SetImageQueryAEED()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEED.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAEED.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAEED.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAEED.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAEED.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAEED.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAEED()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEED.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAEED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAEED.Visible = true;
                PanelRaiseAEED2.Visible = false;
                PanelRaiseAEED3.Visible = false;
                PanelHideAEED.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAEED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAEED3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAEED.Visible = true;
                PanelRaiseAEED2.Visible = true;
                PanelRaiseAEED3.Visible = true;
                PanelHideAEED.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAEED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAEED.Visible = true;
                PanelRaiseAEED2.Visible = true;
                PanelRaiseAEED3.Visible = false;
                PanelHideAEED.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAEED_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEED = '" + TextBoxAEED.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAEED.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAEED.Visible = true;
                RAISEAEED.ShowPopupWindow();
                QueryRaiseAEED.Visible = false;
                TextBoxRaiseAEED.Visible = false;
                PanelRaiseAEED.Visible = false;
                PanelRaiseAEED2.Visible = false;
                PanelRaiseAEED3.Visible = false;

                LabelRespondAEED.Visible = false;
            }

            else if ((ImageQueryAEED.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEED.Visible = true;
                RAISEAEED.ShowPopupWindow();
                QueryRaiseAEED.Visible = true;
                TextBoxRaiseAEED.Visible = true;
                PanelRaiseAEED.Visible = true;
                PanelRaiseAEED2.Visible = false;
                PanelRaiseAEED3.Visible = false;
                LabelRespondAEED.Visible = true;
            }

            else if ((ImageQueryAEED.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEED.Visible = true;
                RAISEAEED.ShowPopupWindow();
                QueryRaiseAEED.Visible = false;
                TextBoxRaiseAEED.Visible = false;
                PanelRaiseAEED.Visible = true;
                PanelRaiseAEED2.Visible = true;
                PanelRaiseAEED3.Visible = false;
                LabelRespondAEED.Visible = false;
            }
            else if ((ImageQueryAEED.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEED.Visible = true;
                RAISEAEED.ShowPopupWindow();
                QueryRaiseAEED.Visible = false;
                TextBoxRaiseAEED.Visible = false;
                PanelRaiseAEED.Visible = true;
                PanelRaiseAEED2.Visible = true;
                PanelRaiseAEED3.Visible = true;
                LabelRespondAEED.Visible = false;
            }
            else
            {
                RAISEAEED.Visible = true;
                RAISEAEED.ShowPopupWindow();
                QueryRaiseAEED.Visible = false;
                TextBoxRaiseAEED.Visible = false;
                PanelRaiseAEED.Visible = true;
                PanelRaiseAEED2.Visible = true;
                PanelRaiseAEED3.Visible = true;
                LabelRespondAEED.Visible = false;

            }
        }

    }
    protected void QueryRaiseAEED_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAEED.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAEED.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEED.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEED = '" + TextBoxAEED.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAEEDMSG.ShowPopupWindow();
        RAISEAEED.Visible = false;


    }
    #endregion
    #region QueryAESAECRO
    private void SetImageQueryAESAECRO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESAECRO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAESAECRO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAESAECRO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAESAECRO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAESAECRO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAESAECRO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAESAECRO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESAECRO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAESAECRO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO2.Visible = false;
                PanelRaiseAESAECRO3.Visible = false;
                PanelHideAESAECRO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAESAECRO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESAECRO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAESAECRO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO2.Visible = true;
                PanelRaiseAESAECRO3.Visible = true;
                PanelHideAESAECRO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAESAECRO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESAECRO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO2.Visible = true;
                PanelRaiseAESAECRO3.Visible = false;
                PanelHideAESAECRO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAESAECRO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESAECRO = '" + TextBoxAESAECRO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAESAECRO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAESAECRO.Visible = true;
                RAISEAESAECRO.ShowPopupWindow();
                QueryRaiseAESAECRO.Visible = false;
                TextBoxRaiseAESAECRO.Visible = false;
                PanelRaiseAESAECRO.Visible = false;
                PanelRaiseAESAECRO2.Visible = false;
                PanelRaiseAESAECRO3.Visible = false;

                LabelRespondAESAECRO.Visible = false;
            }

            else if ((ImageQueryAESAECRO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESAECRO.Visible = true;
                RAISEAESAECRO.ShowPopupWindow();
                QueryRaiseAESAECRO.Visible = true;
                TextBoxRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO2.Visible = false;
                PanelRaiseAESAECRO3.Visible = false;
                LabelRespondAESAECRO.Visible = true;
            }

            else if ((ImageQueryAESAECRO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESAECRO.Visible = true;
                RAISEAESAECRO.ShowPopupWindow();
                QueryRaiseAESAECRO.Visible = false;
                TextBoxRaiseAESAECRO.Visible = false;
                PanelRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO2.Visible = true;
                PanelRaiseAESAECRO3.Visible = false;
                LabelRespondAESAECRO.Visible = false;
            }
            else if ((ImageQueryAESAECRO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESAECRO.Visible = true;
                RAISEAESAECRO.ShowPopupWindow();
                QueryRaiseAESAECRO.Visible = false;
                TextBoxRaiseAESAECRO.Visible = false;
                PanelRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO2.Visible = true;
                PanelRaiseAESAECRO3.Visible = true;
                LabelRespondAESAECRO.Visible = false;
            }
            else
            {
                RAISEAESAECRO.Visible = true;
                RAISEAESAECRO.ShowPopupWindow();
                QueryRaiseAESAECRO.Visible = false;
                TextBoxRaiseAESAECRO.Visible = false;
                PanelRaiseAESAECRO.Visible = true;
                PanelRaiseAESAECRO2.Visible = true;
                PanelRaiseAESAECRO3.Visible = true;
                LabelRespondAESAECRO.Visible = false;

            }
        }

    }
    protected void QueryRaiseAESAECRO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAESAECRO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAESAECRO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESAECRO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESAECRO = '" + TextBoxAESAECRO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAESAECROMSG.ShowPopupWindow();
        RAISEAESAECRO.Visible = false;


    }
    #endregion
    #region QueryAEOTCM
    private void SetImageQueryAEOTCM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEOTCM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAEOTCM.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAEOTCM.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAEOTCM.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAEOTCM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAEOTCM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAEOTCM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEOTCM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAEOTCM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM2.Visible = false;
                PanelRaiseAEOTCM3.Visible = false;
                PanelHideAEOTCM.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAEOTCM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEOTCM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAEOTCM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM2.Visible = true;
                PanelRaiseAEOTCM3.Visible = true;
                PanelHideAEOTCM.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAEOTCM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEOTCM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM2.Visible = true;
                PanelRaiseAEOTCM3.Visible = false;
                PanelHideAEOTCM.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAEOTCM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEOTCM = '" + RadioButtonListAEOTCM.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAEOTCM.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAEOTCM.Visible = true;
                RAISEAEOTCM.ShowPopupWindow();
                QueryRaiseAEOTCM.Visible = false;
                TextBoxRaiseAEOTCM.Visible = false;
                PanelRaiseAEOTCM.Visible = false;
                PanelRaiseAEOTCM2.Visible = false;
                PanelRaiseAEOTCM3.Visible = false;

                LabelRespondAEOTCM.Visible = false;
            }

            else if ((ImageQueryAEOTCM.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEOTCM.Visible = true;
                RAISEAEOTCM.ShowPopupWindow();
                QueryRaiseAEOTCM.Visible = true;
                TextBoxRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM2.Visible = false;
                PanelRaiseAEOTCM3.Visible = false;
                LabelRespondAEOTCM.Visible = true;
            }

            else if ((ImageQueryAEOTCM.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEOTCM.Visible = true;
                RAISEAEOTCM.ShowPopupWindow();
                QueryRaiseAEOTCM.Visible = false;
                TextBoxRaiseAEOTCM.Visible = false;
                PanelRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM2.Visible = true;
                PanelRaiseAEOTCM3.Visible = false;
                LabelRespondAEOTCM.Visible = false;
            }
            else if ((ImageQueryAEOTCM.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEOTCM.Visible = true;
                RAISEAEOTCM.ShowPopupWindow();
                QueryRaiseAEOTCM.Visible = false;
                TextBoxRaiseAEOTCM.Visible = false;
                PanelRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM2.Visible = true;
                PanelRaiseAEOTCM3.Visible = true;
                LabelRespondAEOTCM.Visible = false;
            }
            else
            {
                RAISEAEOTCM.Visible = true;
                RAISEAEOTCM.ShowPopupWindow();
                QueryRaiseAEOTCM.Visible = false;
                TextBoxRaiseAEOTCM.Visible = false;
                PanelRaiseAEOTCM.Visible = true;
                PanelRaiseAEOTCM2.Visible = true;
                PanelRaiseAEOTCM3.Visible = true;
                LabelRespondAEOTCM.Visible = false;

            }
        }

    }
    protected void QueryRaiseAEOTCM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAEOTCM.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAEOTCM.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEOTCM.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEOTCM = '" + RadioButtonListAEOTCM.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAEOTCMMSG.ShowPopupWindow();
        RAISEAEOTCM.Visible = false;


    }
    #endregion
    #region QueryAESVR
    private void SetImageQueryAESVR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESVR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAESVR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAESVR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAESVR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAESVR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAESVR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAESVR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESVR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAESVR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAESVR.Visible = true;
                PanelRaiseAESVR2.Visible = false;
                PanelRaiseAESVR3.Visible = false;
                PanelHideAESVR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAESVR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESVR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAESVR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAESVR.Visible = true;
                PanelRaiseAESVR2.Visible = true;
                PanelRaiseAESVR3.Visible = true;
                PanelHideAESVR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAESVR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESVR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAESVR.Visible = true;
                PanelRaiseAESVR2.Visible = true;
                PanelRaiseAESVR3.Visible = false;
                PanelHideAESVR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAESVR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESVR = '" + RadioButtonListAESVR.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAESVR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAESVR.Visible = true;
                RAISEAESVR.ShowPopupWindow();
                QueryRaiseAESVR.Visible = false;
                TextBoxRaiseAESVR.Visible = false;
                PanelRaiseAESVR.Visible = false;
                PanelRaiseAESVR2.Visible = false;
                PanelRaiseAESVR3.Visible = false;

                LabelRespondAESVR.Visible = false;
            }

            else if ((ImageQueryAESVR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESVR.Visible = true;
                RAISEAESVR.ShowPopupWindow();
                QueryRaiseAESVR.Visible = true;
                TextBoxRaiseAESVR.Visible = true;
                PanelRaiseAESVR.Visible = true;
                PanelRaiseAESVR2.Visible = false;
                PanelRaiseAESVR3.Visible = false;
                LabelRespondAESVR.Visible = true;
            }

            else if ((ImageQueryAESVR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESVR.Visible = true;
                RAISEAESVR.ShowPopupWindow();
                QueryRaiseAESVR.Visible = false;
                TextBoxRaiseAESVR.Visible = false;
                PanelRaiseAESVR.Visible = true;
                PanelRaiseAESVR2.Visible = true;
                PanelRaiseAESVR3.Visible = false;
                LabelRespondAESVR.Visible = false;
            }
            else if ((ImageQueryAESVR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESVR.Visible = true;
                RAISEAESVR.ShowPopupWindow();
                QueryRaiseAESVR.Visible = false;
                TextBoxRaiseAESVR.Visible = false;
                PanelRaiseAESVR.Visible = true;
                PanelRaiseAESVR2.Visible = true;
                PanelRaiseAESVR3.Visible = true;
                LabelRespondAESVR.Visible = false;
            }
            else
            {
                RAISEAESVR.Visible = true;
                RAISEAESVR.ShowPopupWindow();
                QueryRaiseAESVR.Visible = false;
                TextBoxRaiseAESVR.Visible = false;
                PanelRaiseAESVR.Visible = true;
                PanelRaiseAESVR2.Visible = true;
                PanelRaiseAESVR3.Visible = true;
                LabelRespondAESVR.Visible = false;

            }
        }

    }
    protected void QueryRaiseAESVR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAESVR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAESVR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESVR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESVR = '" + RadioButtonListAESVR.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAESVRMSG.ShowPopupWindow();
        RAISEAESVR.Visible = false;


    }
    #endregion
    #region QueryAERIP
    private void SetImageQueryAERIP()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAERIP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAERIP.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAERIP.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAERIP.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAERIP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAERIP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAERIP()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAERIP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAERIP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAERIP.Visible = true;
                PanelRaiseAERIP2.Visible = false;
                PanelRaiseAERIP3.Visible = false;
                PanelHideAERIP.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAERIP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAERIP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAERIP3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAERIP.Visible = true;
                PanelRaiseAERIP2.Visible = true;
                PanelRaiseAERIP3.Visible = true;
                PanelHideAERIP.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAERIP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAERIP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAERIP.Visible = true;
                PanelRaiseAERIP2.Visible = true;
                PanelRaiseAERIP3.Visible = false;
                PanelHideAERIP.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAERIP_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AERIP = '" + RadioButtonListAERIP.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAERIP.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAERIP.Visible = true;
                RAISEAERIP.ShowPopupWindow();
                QueryRaiseAERIP.Visible = false;
                TextBoxRaiseAERIP.Visible = false;
                PanelRaiseAERIP.Visible = false;
                PanelRaiseAERIP2.Visible = false;
                PanelRaiseAERIP3.Visible = false;

                LabelRespondAERIP.Visible = false;
            }

            else if ((ImageQueryAERIP.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAERIP.Visible = true;
                RAISEAERIP.ShowPopupWindow();
                QueryRaiseAERIP.Visible = true;
                TextBoxRaiseAERIP.Visible = true;
                PanelRaiseAERIP.Visible = true;
                PanelRaiseAERIP2.Visible = false;
                PanelRaiseAERIP3.Visible = false;
                LabelRespondAERIP.Visible = true;
            }

            else if ((ImageQueryAERIP.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAERIP.Visible = true;
                RAISEAERIP.ShowPopupWindow();
                QueryRaiseAERIP.Visible = false;
                TextBoxRaiseAERIP.Visible = false;
                PanelRaiseAERIP.Visible = true;
                PanelRaiseAERIP2.Visible = true;
                PanelRaiseAERIP3.Visible = false;
                LabelRespondAERIP.Visible = false;
            }
            else if ((ImageQueryAERIP.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAERIP.Visible = true;
                RAISEAERIP.ShowPopupWindow();
                QueryRaiseAERIP.Visible = false;
                TextBoxRaiseAERIP.Visible = false;
                PanelRaiseAERIP.Visible = true;
                PanelRaiseAERIP2.Visible = true;
                PanelRaiseAERIP3.Visible = true;
                LabelRespondAERIP.Visible = false;
            }
            else
            {
                RAISEAERIP.Visible = true;
                RAISEAERIP.ShowPopupWindow();
                QueryRaiseAERIP.Visible = false;
                TextBoxRaiseAERIP.Visible = false;
                PanelRaiseAERIP.Visible = true;
                PanelRaiseAERIP2.Visible = true;
                PanelRaiseAERIP3.Visible = true;
                LabelRespondAERIP.Visible = false;

            }
        }

    }
    protected void QueryRaiseAERIP_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAERIP.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAERIP.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAERIP.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AERIP = '" + RadioButtonListAERIP.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAERIPMSG.ShowPopupWindow();
        RAISEAERIP.Visible = false;


    }
    #endregion
    #region QueryAEAT
    private void SetImageQueryAEAT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAEAT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAEAT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAEAT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAEAT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAEAT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAEAT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEAT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAEAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAEAT.Visible = true;
                PanelRaiseAEAT2.Visible = false;
                PanelRaiseAEAT3.Visible = false;
                PanelHideAEAT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAEAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAEAT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAEAT.Visible = true;
                PanelRaiseAEAT2.Visible = true;
                PanelRaiseAEAT3.Visible = true;
                PanelHideAEAT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAEAT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAEAT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAEAT.Visible = true;
                PanelRaiseAEAT2.Visible = true;
                PanelRaiseAEAT3.Visible = false;
                PanelHideAEAT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAEAT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEAT = '" + RadioButtonListAEAT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAEAT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAEAT.Visible = true;
                RAISEAEAT.ShowPopupWindow();
                QueryRaiseAEAT.Visible = false;
                TextBoxRaiseAEAT.Visible = false;
                PanelRaiseAEAT.Visible = false;
                PanelRaiseAEAT2.Visible = false;
                PanelRaiseAEAT3.Visible = false;

                LabelRespondAEAT.Visible = false;
            }

            else if ((ImageQueryAEAT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEAT.Visible = true;
                RAISEAEAT.ShowPopupWindow();
                QueryRaiseAEAT.Visible = true;
                TextBoxRaiseAEAT.Visible = true;
                PanelRaiseAEAT.Visible = true;
                PanelRaiseAEAT2.Visible = false;
                PanelRaiseAEAT3.Visible = false;
                LabelRespondAEAT.Visible = true;
            }

            else if ((ImageQueryAEAT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEAT.Visible = true;
                RAISEAEAT.ShowPopupWindow();
                QueryRaiseAEAT.Visible = false;
                TextBoxRaiseAEAT.Visible = false;
                PanelRaiseAEAT.Visible = true;
                PanelRaiseAEAT2.Visible = true;
                PanelRaiseAEAT3.Visible = false;
                LabelRespondAEAT.Visible = false;
            }
            else if ((ImageQueryAEAT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAEAT.Visible = true;
                RAISEAEAT.ShowPopupWindow();
                QueryRaiseAEAT.Visible = false;
                TextBoxRaiseAEAT.Visible = false;
                PanelRaiseAEAT.Visible = true;
                PanelRaiseAEAT2.Visible = true;
                PanelRaiseAEAT3.Visible = true;
                LabelRespondAEAT.Visible = false;
            }
            else
            {
                RAISEAEAT.Visible = true;
                RAISEAEAT.ShowPopupWindow();
                QueryRaiseAEAT.Visible = false;
                TextBoxRaiseAEAT.Visible = false;
                PanelRaiseAEAT.Visible = true;
                PanelRaiseAEAT2.Visible = true;
                PanelRaiseAEAT3.Visible = true;
                LabelRespondAEAT.Visible = false;

            }
        }

    }
    protected void QueryRaiseAEAT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAEAT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAEAT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAEAT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AEAT = '" + RadioButtonListAEAT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAEATMSG.ShowPopupWindow();
        RAISEAEAT.Visible = false;


    }
    #endregion
    #region QueryAECS
    private void SetImageQueryAECS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAECS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAECS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAECS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAECS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAECS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAECS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAECS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAECS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAECS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAECS.Visible = true;
                PanelRaiseAECS2.Visible = false;
                PanelRaiseAECS3.Visible = false;
                PanelHideAECS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAECS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAECS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAECS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAECS.Visible = true;
                PanelRaiseAECS2.Visible = true;
                PanelRaiseAECS3.Visible = true;
                PanelHideAECS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAECS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAECS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAECS.Visible = true;
                PanelRaiseAECS2.Visible = true;
                PanelRaiseAECS3.Visible = false;
                PanelHideAECS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAECS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AECS = '" + RadioButtonListAECS.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAECS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAECS.Visible = true;
                RAISEAECS.ShowPopupWindow();
                QueryRaiseAECS.Visible = false;
                TextBoxRaiseAECS.Visible = false;
                PanelRaiseAECS.Visible = false;
                PanelRaiseAECS2.Visible = false;
                PanelRaiseAECS3.Visible = false;

                LabelRespondAECS.Visible = false;
            }

            else if ((ImageQueryAECS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAECS.Visible = true;
                RAISEAECS.ShowPopupWindow();
                QueryRaiseAECS.Visible = true;
                TextBoxRaiseAECS.Visible = true;
                PanelRaiseAECS.Visible = true;
                PanelRaiseAECS2.Visible = false;
                PanelRaiseAECS3.Visible = false;
                LabelRespondAECS.Visible = true;
            }

            else if ((ImageQueryAECS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAECS.Visible = true;
                RAISEAECS.ShowPopupWindow();
                QueryRaiseAECS.Visible = false;
                TextBoxRaiseAECS.Visible = false;
                PanelRaiseAECS.Visible = true;
                PanelRaiseAECS2.Visible = true;
                PanelRaiseAECS3.Visible = false;
                LabelRespondAECS.Visible = false;
            }
            else if ((ImageQueryAECS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAECS.Visible = true;
                RAISEAECS.ShowPopupWindow();
                QueryRaiseAECS.Visible = false;
                TextBoxRaiseAECS.Visible = false;
                PanelRaiseAECS.Visible = true;
                PanelRaiseAECS2.Visible = true;
                PanelRaiseAECS3.Visible = true;
                LabelRespondAECS.Visible = false;
            }
            else
            {
                RAISEAECS.Visible = true;
                RAISEAECS.ShowPopupWindow();
                QueryRaiseAECS.Visible = false;
                TextBoxRaiseAECS.Visible = false;
                PanelRaiseAECS.Visible = true;
                PanelRaiseAECS2.Visible = true;
                PanelRaiseAECS3.Visible = true;
                LabelRespondAECS.Visible = false;

            }
        }

    }
    protected void QueryRaiseAECS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAECS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAECS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAECS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AECS = '" + RadioButtonListAECS.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAECSMSG.ShowPopupWindow();
        RAISEAECS.Visible = false;


    }
    #endregion
    #region QueryAETEAE
    private void SetImageQueryAETEAE()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAETEAE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAETEAE.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAETEAE.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAETEAE.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAETEAE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAETEAE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAETEAE()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAETEAE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAETEAE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE2.Visible = false;
                PanelRaiseAETEAE3.Visible = false;
                PanelHideAETEAE.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAETEAE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAETEAE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAETEAE3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE2.Visible = true;
                PanelRaiseAETEAE3.Visible = true;
                PanelHideAETEAE.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAETEAE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAETEAE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE2.Visible = true;
                PanelRaiseAETEAE3.Visible = false;
                PanelHideAETEAE.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAETEAE_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AETEAE = '" + RadioButtonListAETEAE.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAETEAE.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAETEAE.Visible = true;
                RAISEAETEAE.ShowPopupWindow();
                QueryRaiseAETEAE.Visible = false;
                TextBoxRaiseAETEAE.Visible = false;
                PanelRaiseAETEAE.Visible = false;
                PanelRaiseAETEAE2.Visible = false;
                PanelRaiseAETEAE3.Visible = false;

                LabelRespondAETEAE.Visible = false;
            }

            else if ((ImageQueryAETEAE.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAETEAE.Visible = true;
                RAISEAETEAE.ShowPopupWindow();
                QueryRaiseAETEAE.Visible = true;
                TextBoxRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE2.Visible = false;
                PanelRaiseAETEAE3.Visible = false;
                LabelRespondAETEAE.Visible = true;
            }

            else if ((ImageQueryAETEAE.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAETEAE.Visible = true;
                RAISEAETEAE.ShowPopupWindow();
                QueryRaiseAETEAE.Visible = false;
                TextBoxRaiseAETEAE.Visible = false;
                PanelRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE2.Visible = true;
                PanelRaiseAETEAE3.Visible = false;
                LabelRespondAETEAE.Visible = false;
            }
            else if ((ImageQueryAETEAE.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAETEAE.Visible = true;
                RAISEAETEAE.ShowPopupWindow();
                QueryRaiseAETEAE.Visible = false;
                TextBoxRaiseAETEAE.Visible = false;
                PanelRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE2.Visible = true;
                PanelRaiseAETEAE3.Visible = true;
                LabelRespondAETEAE.Visible = false;
            }
            else
            {
                RAISEAETEAE.Visible = true;
                RAISEAETEAE.ShowPopupWindow();
                QueryRaiseAETEAE.Visible = false;
                TextBoxRaiseAETEAE.Visible = false;
                PanelRaiseAETEAE.Visible = true;
                PanelRaiseAETEAE2.Visible = true;
                PanelRaiseAETEAE3.Visible = true;
                LabelRespondAETEAE.Visible = false;

            }
        }

    }
    protected void QueryRaiseAETEAE_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAETEAE.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAETEAE.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAETEAE.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AETEAE = '" + RadioButtonListAETEAE.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAETEAEMSG.ShowPopupWindow();
        RAISEAETEAE.Visible = false;


    }
    #endregion
    #region QueryAESAECR
    private void SetImageQueryAESAECR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESAECR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryAESAECR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryAESAECR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryAESAECR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryAESAECR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryAESAECR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataAESAECR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESAECR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseAESAECR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR2.Visible = false;
                PanelRaiseAESAECR3.Visible = false;
                PanelHideAESAECR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseAESAECR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESAECR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseAESAECR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR2.Visible = true;
                PanelRaiseAESAECR3.Visible = true;
                PanelHideAESAECR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseAESAECR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseAESAECR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR2.Visible = true;
                PanelRaiseAESAECR3.Visible = false;
                PanelHideAESAECR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryAESAECR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[AdverseEventForm]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESAECR = '" + RadioButtonListAESAECR.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryAESAECR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEAESAECR.Visible = true;
                RAISEAESAECR.ShowPopupWindow();
                QueryRaiseAESAECR.Visible = false;
                TextBoxRaiseAESAECR.Visible = false;
                PanelRaiseAESAECR.Visible = false;
                PanelRaiseAESAECR2.Visible = false;
                PanelRaiseAESAECR3.Visible = false;

                LabelRespondAESAECR.Visible = false;
            }

            else if ((ImageQueryAESAECR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESAECR.Visible = true;
                RAISEAESAECR.ShowPopupWindow();
                QueryRaiseAESAECR.Visible = true;
                TextBoxRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR2.Visible = false;
                PanelRaiseAESAECR3.Visible = false;
                LabelRespondAESAECR.Visible = true;
            }

            else if ((ImageQueryAESAECR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESAECR.Visible = true;
                RAISEAESAECR.ShowPopupWindow();
                QueryRaiseAESAECR.Visible = false;
                TextBoxRaiseAESAECR.Visible = false;
                PanelRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR2.Visible = true;
                PanelRaiseAESAECR3.Visible = false;
                LabelRespondAESAECR.Visible = false;
            }
            else if ((ImageQueryAESAECR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEAESAECR.Visible = true;
                RAISEAESAECR.ShowPopupWindow();
                QueryRaiseAESAECR.Visible = false;
                TextBoxRaiseAESAECR.Visible = false;
                PanelRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR2.Visible = true;
                PanelRaiseAESAECR3.Visible = true;
                LabelRespondAESAECR.Visible = false;
            }
            else
            {
                RAISEAESAECR.Visible = true;
                RAISEAESAECR.ShowPopupWindow();
                QueryRaiseAESAECR.Visible = false;
                TextBoxRaiseAESAECR.Visible = false;
                PanelRaiseAESAECR.Visible = true;
                PanelRaiseAESAECR2.Visible = true;
                PanelRaiseAESAECR3.Visible = true;
                LabelRespondAESAECR.Visible = false;

            }
        }

    }
    protected void QueryRaiseAESAECR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseAESAECR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxAESNO.Text + "' and Field = '" + lblAESAECR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxAESNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblAESAECR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[AdverseEventForm] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and AESNO = '" + TextBoxAESNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and AESAECR = '" + RadioButtonListAESAECR.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEAESAECRMSG.ShowPopupWindow();
        RAISEAESAECR.Visible = false;


    }
    #endregion

    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void RadioButtonListAESAECR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListAESAECR.SelectedValue == "Other medically significant events")
        {
            hideAESAECRO.Visible = true;
        }
        else
        {
            hideAESAECRO.Visible = false;
            TextBoxAESAECRO.Text = string.Empty;
        }
    }
}