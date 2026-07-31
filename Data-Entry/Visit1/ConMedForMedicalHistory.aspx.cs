using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Data_Entry_Visit1_ConMedForMedicalHistory : System.Web.UI.Page
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
            ViewState["oldData"] = dt;
        }
        PageStatus();
        SetImageAddNote();
        BindGridviewAddNote();
        SetImageAttach();
        BindGridViewADDAddAttachment();

        SetImageAttachPageHistory();
        BindGridViewADDAttachmentPageHistory();

        SetImageQueryPDM1MN();
        SetImageQueryPDM2MN();
        SetImageQueryPDM3MN();
        SetImageQueryPDM4MN();
        SetImageQueryPDM5MN();
       
        BindQueryDataPDM1MN();
        BindQueryDataPDM2MN();
        BindQueryDataPDM3MN();
        BindQueryDataPDM4MN();
        BindQueryDataPDM5MN();

        ShowHide();

        TextBoxPDM1SD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM2SD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM3SD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM4SD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM5SD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        TextBoxPDM1ED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM2ED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM3ED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM4ED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxPDM5ED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select PDM1MN , PDM1SD , PDM1ONGO , PDM1ED , PDM2MN , PDM2SD , PDM2ONGO , PDM2ED , PDM3MN , PDM3SD , PDM3ONGO , PDM3ED , PDM4MN , PDM4SD , PDM4ONGO , PDM4ED , PDM5MN , PDM5SD , PDM5ONGO , PDM5ED from [Visit1].[ConMedForMedicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            
            TextBoxPDM1MN.Text = dt.Rows[0]["PDM1MN"].ToString().Trim();
            TextBoxPDM1SD.Text = dt.Rows[0]["PDM1SD"].ToString().Trim();
            RadioButtonListPDM1ONGO.SelectedValue = dt.Rows[0]["PDM1ONGO"].ToString().Trim();
            TextBoxPDM1ED.Text = dt.Rows[0]["PDM1ED"].ToString().Trim();
            TextBoxPDM2MN.Text = dt.Rows[0]["PDM2MN"].ToString().Trim();
            TextBoxPDM2SD.Text = dt.Rows[0]["PDM2SD"].ToString().Trim();
            RadioButtonListPDM2ONGO.SelectedValue = dt.Rows[0]["PDM2ONGO"].ToString().Trim();
            TextBoxPDM2ED.Text = dt.Rows[0]["PDM2ED"].ToString().Trim();
            TextBoxPDM3MN.Text = dt.Rows[0]["PDM3MN"].ToString().Trim();
            TextBoxPDM3SD.Text = dt.Rows[0]["PDM3SD"].ToString().Trim();
            RadioButtonListPDM3ONGO.SelectedValue = dt.Rows[0]["PDM3ONGO"].ToString().Trim();
            TextBoxPDM3ED.Text = dt.Rows[0]["PDM3ED"].ToString().Trim();
            TextBoxPDM4MN.Text = dt.Rows[0]["PDM4MN"].ToString().Trim();
            TextBoxPDM4SD.Text = dt.Rows[0]["PDM4SD"].ToString().Trim();
            RadioButtonListPDM4ONGO.SelectedValue = dt.Rows[0]["PDM4ONGO"].ToString().Trim();
            TextBoxPDM4ED.Text = dt.Rows[0]["PDM4ED"].ToString().Trim();
            TextBoxPDM5MN.Text = dt.Rows[0]["PDM5MN"].ToString().Trim();
            TextBoxPDM5SD.Text = dt.Rows[0]["PDM5SD"].ToString().Trim();
            RadioButtonListPDM5ONGO.SelectedValue = dt.Rows[0]["PDM5ONGO"].ToString().Trim();
            TextBoxPDM5ED.Text = dt.Rows[0]["PDM5ED"].ToString().Trim();

           
            ViewState["txt1"] = TextBoxPDM1MN.Text;
            ViewState["txt2"] = TextBoxPDM1SD.Text;
            ViewState["txt3"] = RadioButtonListPDM1ONGO.SelectedValue;
            ViewState["txt4"] = TextBoxPDM1ED.Text;
            ViewState["txt5"] = TextBoxPDM2MN.Text;
            ViewState["txt6"] = TextBoxPDM2SD.Text;
            ViewState["txt7"] = RadioButtonListPDM2ONGO.SelectedValue;
            ViewState["txt8"] = TextBoxPDM2ED.Text;
            ViewState["txt9"] = TextBoxPDM3MN.Text;
            ViewState["txt10"] = TextBoxPDM3SD.Text;
            ViewState["txt11"] = RadioButtonListPDM3ONGO.SelectedValue;
            ViewState["txt12"] = TextBoxPDM3ED.Text;
            ViewState["txt13"] = TextBoxPDM4MN.Text;
            ViewState["txt14"] = TextBoxPDM4SD.Text;
            ViewState["txt15"] = RadioButtonListPDM4ONGO.SelectedValue;
            ViewState["txt16"] = TextBoxPDM4ED.Text;
            ViewState["txt17"] = TextBoxPDM5MN.Text;
            ViewState["txt18"] = TextBoxPDM5SD.Text;
            ViewState["txt19"] = RadioButtonListPDM5ONGO.SelectedValue;
            ViewState["txt20"] = TextBoxPDM5ED.Text;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[ConMedForMedicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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

    #region Data Save And Submit 
    public void OnConfirm(object sender, EventArgs e)
    {
        con.Close();
        DataTable dt2 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[ConMedForMedicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_ConMedForMedicalHistory]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    
                    cmd.Parameters.AddWithValue("@PDM1MN", TextBoxPDM1MN.Text);
                    cmd.Parameters.AddWithValue("@PDM1SD", TextBoxPDM1SD.Text);
                    cmd.Parameters.AddWithValue("@PDM1ONGO", RadioButtonListPDM1ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM1ED", TextBoxPDM1ED.Text);
                    cmd.Parameters.AddWithValue("@PDM2MN", TextBoxPDM2MN.Text);
                    cmd.Parameters.AddWithValue("@PDM2SD", TextBoxPDM2SD.Text);
                    cmd.Parameters.AddWithValue("@PDM2ONGO", RadioButtonListPDM2ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM2ED", TextBoxPDM2ED.Text);
                    cmd.Parameters.AddWithValue("@PDM3MN", TextBoxPDM3MN.Text);
                    cmd.Parameters.AddWithValue("@PDM3SD", TextBoxPDM3SD.Text);
                    cmd.Parameters.AddWithValue("@PDM3ONGO", RadioButtonListPDM3ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM3ED", TextBoxPDM3ED.Text);
                    cmd.Parameters.AddWithValue("@PDM4MN", TextBoxPDM4MN.Text);
                    cmd.Parameters.AddWithValue("@PDM4SD", TextBoxPDM4SD.Text);
                    cmd.Parameters.AddWithValue("@PDM4ONGO", RadioButtonListPDM4ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM4ED", TextBoxPDM4ED.Text);
                    cmd.Parameters.AddWithValue("@PDM5MN", TextBoxPDM5MN.Text);
                    cmd.Parameters.AddWithValue("@PDM5SD", TextBoxPDM5SD.Text);
                    cmd.Parameters.AddWithValue("@PDM5ONGO", RadioButtonListPDM5ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM5ED", TextBoxPDM5ED.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[ConMedForMedicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != TextBoxPDM1MN.Text || ViewState["txt2"].ToString() != TextBoxPDM1SD.Text || ViewState["txt3"].ToString() != RadioButtonListPDM1ONGO.SelectedValue || ViewState["txt4"].ToString() != TextBoxPDM1ED.Text || ViewState["txt5"].ToString() != TextBoxPDM2MN.Text || ViewState["txt6"].ToString() != TextBoxPDM2SD.Text || ViewState["txt7"].ToString() != RadioButtonListPDM2ONGO.SelectedValue || ViewState["txt8"].ToString() != TextBoxPDM2ED.Text || ViewState["txt9"].ToString() != TextBoxPDM3MN.Text || ViewState["txt10"].ToString() != TextBoxPDM3SD.Text || ViewState["txt11"].ToString() != RadioButtonListPDM3ONGO.SelectedValue || ViewState["txt12"].ToString() != TextBoxPDM3ED.Text || ViewState["txt13"].ToString() != TextBoxPDM4MN.Text || ViewState["txt14"].ToString() != TextBoxPDM4SD.Text || ViewState["txt15"].ToString() != RadioButtonListPDM4ONGO.SelectedValue || ViewState["txt16"].ToString() != TextBoxPDM4ED.Text || ViewState["txt17"].ToString() != TextBoxPDM5MN.Text || ViewState["txt18"].ToString() != TextBoxPDM5SD.Text || ViewState["txt19"].ToString() != RadioButtonListPDM5ONGO.SelectedValue || ViewState["txt20"].ToString() != TextBoxPDM5ED.Text)
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
                cmd = new SqlCommand("[Visit1].[sp_ConMedForMedicalHistory]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@PDM1MN", TextBoxPDM1MN.Text);
                cmd.Parameters.AddWithValue("@PDM1SD", TextBoxPDM1SD.Text);
                cmd.Parameters.AddWithValue("@PDM1ONGO", RadioButtonListPDM1ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM1ED", TextBoxPDM1ED.Text);
                cmd.Parameters.AddWithValue("@PDM2MN", TextBoxPDM2MN.Text);
                cmd.Parameters.AddWithValue("@PDM2SD", TextBoxPDM2SD.Text);
                cmd.Parameters.AddWithValue("@PDM2ONGO", RadioButtonListPDM2ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM2ED", TextBoxPDM2ED.Text);
                cmd.Parameters.AddWithValue("@PDM3MN", TextBoxPDM3MN.Text);
                cmd.Parameters.AddWithValue("@PDM3SD", TextBoxPDM3SD.Text);
                cmd.Parameters.AddWithValue("@PDM3ONGO", RadioButtonListPDM3ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM3ED", TextBoxPDM3ED.Text);
                cmd.Parameters.AddWithValue("@PDM4MN", TextBoxPDM4MN.Text);
                cmd.Parameters.AddWithValue("@PDM4SD", TextBoxPDM4SD.Text);
                cmd.Parameters.AddWithValue("@PDM4ONGO", RadioButtonListPDM4ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM4ED", TextBoxPDM4ED.Text);
                cmd.Parameters.AddWithValue("@PDM5MN", TextBoxPDM5MN.Text);
                cmd.Parameters.AddWithValue("@PDM5SD", TextBoxPDM5SD.Text);
                cmd.Parameters.AddWithValue("@PDM5ONGO", RadioButtonListPDM5ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM5ED", TextBoxPDM5ED.Text);

                cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                cmd.Parameters.AddWithValue("@PAGENAME", lblPage.Text);
                cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
                cmd.Parameters.AddWithValue("@EntryStatus", "Submit");
                cmd.Parameters.AddWithValue("@QueryStatus", "No Query");
                cmd.Parameters.AddWithValue("@mode", "insert");
                cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[ConMedForMedicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_ConMedForMedicalHistory]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@PDM1MN", TextBoxPDM1MN.Text);
                    cmd.Parameters.AddWithValue("@PDM1SD", TextBoxPDM1SD.Text);
                    cmd.Parameters.AddWithValue("@PDM1ONGO", RadioButtonListPDM1ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM1ED", TextBoxPDM1ED.Text);
                    cmd.Parameters.AddWithValue("@PDM2MN", TextBoxPDM2MN.Text);
                    cmd.Parameters.AddWithValue("@PDM2SD", TextBoxPDM2SD.Text);
                    cmd.Parameters.AddWithValue("@PDM2ONGO", RadioButtonListPDM2ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM2ED", TextBoxPDM2ED.Text);
                    cmd.Parameters.AddWithValue("@PDM3MN", TextBoxPDM3MN.Text);
                    cmd.Parameters.AddWithValue("@PDM3SD", TextBoxPDM3SD.Text);
                    cmd.Parameters.AddWithValue("@PDM3ONGO", RadioButtonListPDM3ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM3ED", TextBoxPDM3ED.Text);
                    cmd.Parameters.AddWithValue("@PDM4MN", TextBoxPDM4MN.Text);
                    cmd.Parameters.AddWithValue("@PDM4SD", TextBoxPDM4SD.Text);
                    cmd.Parameters.AddWithValue("@PDM4ONGO", RadioButtonListPDM4ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM4ED", TextBoxPDM4ED.Text);
                    cmd.Parameters.AddWithValue("@PDM5MN", TextBoxPDM5MN.Text);
                    cmd.Parameters.AddWithValue("@PDM5SD", TextBoxPDM5SD.Text);
                    cmd.Parameters.AddWithValue("@PDM5ONGO", RadioButtonListPDM5ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@PDM5ED", TextBoxPDM5ED.Text);

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
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not saved!')", true);
                }
            }
        }
        else
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                con.Close();
                cmd = new SqlCommand("[Visit1].[sp_ConMedForMedicalHistory]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@PDM1MN", TextBoxPDM1MN.Text);
                cmd.Parameters.AddWithValue("@PDM1SD", TextBoxPDM1SD.Text);
                cmd.Parameters.AddWithValue("@PDM1ONGO", RadioButtonListPDM1ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM1ED", TextBoxPDM1ED.Text);
                cmd.Parameters.AddWithValue("@PDM2MN", TextBoxPDM2MN.Text);
                cmd.Parameters.AddWithValue("@PDM2SD", TextBoxPDM2SD.Text);
                cmd.Parameters.AddWithValue("@PDM2ONGO", RadioButtonListPDM2ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM2ED", TextBoxPDM2ED.Text);
                cmd.Parameters.AddWithValue("@PDM3MN", TextBoxPDM3MN.Text);
                cmd.Parameters.AddWithValue("@PDM3SD", TextBoxPDM3SD.Text);
                cmd.Parameters.AddWithValue("@PDM3ONGO", RadioButtonListPDM3ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM3ED", TextBoxPDM3ED.Text);
                cmd.Parameters.AddWithValue("@PDM4MN", TextBoxPDM4MN.Text);
                cmd.Parameters.AddWithValue("@PDM4SD", TextBoxPDM4SD.Text);
                cmd.Parameters.AddWithValue("@PDM4ONGO", RadioButtonListPDM4ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM4ED", TextBoxPDM4ED.Text);
                cmd.Parameters.AddWithValue("@PDM5MN", TextBoxPDM5MN.Text);
                cmd.Parameters.AddWithValue("@PDM5SD", TextBoxPDM5SD.Text);
                cmd.Parameters.AddWithValue("@PDM5ONGO", RadioButtonListPDM5ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@PDM5ED", TextBoxPDM5ED.Text);

                cmd.Parameters.AddWithValue("@VISIT", lblVisit.Text);
                cmd.Parameters.AddWithValue("@PAGENAME", lblPage.Text);
                cmd.Parameters.AddWithValue("@LockStatus", "Unlocked");
                cmd.Parameters.AddWithValue("@EntryStatus", "Save");
                cmd.Parameters.AddWithValue("@QueryStatus", "No Query");
                cmd.Parameters.AddWithValue("@mode", "insert");
                cmd.Parameters.AddWithValue("@EUser", Session["UserName"]);
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Page is not saved!')", true);
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
        if (!string.IsNullOrEmpty(TextBoxPDM1MN.Text) || !string.IsNullOrEmpty(TextBoxPDM1SD.Text) || !string.IsNullOrEmpty(RadioButtonListPDM1ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxPDM1ED.Text) || !string.IsNullOrEmpty(TextBoxPDM2MN.Text) || !string.IsNullOrEmpty(TextBoxPDM2SD.Text) || !string.IsNullOrEmpty(RadioButtonListPDM2ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxPDM2ED.Text) || !string.IsNullOrEmpty(TextBoxPDM3MN.Text) || !string.IsNullOrEmpty(TextBoxPDM3SD.Text) || !string.IsNullOrEmpty(RadioButtonListPDM3ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxPDM3ED.Text) || !string.IsNullOrEmpty(TextBoxPDM4MN.Text) || !string.IsNullOrEmpty(TextBoxPDM4SD.Text) || !string.IsNullOrEmpty(RadioButtonListPDM4ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxPDM4ED.Text) || !string.IsNullOrEmpty(TextBoxPDM5MN.Text) || !string.IsNullOrEmpty(TextBoxPDM5SD.Text) || !string.IsNullOrEmpty(RadioButtonListPDM5ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxPDM5ED.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() !=  TextBoxPDM1MN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM1MN.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = TextBoxPDM1MN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() !=  TextBoxPDM1SD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM1SD.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxPDM1SD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() !=  RadioButtonListPDM1ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM1ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = RadioButtonListPDM1ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() !=  TextBoxPDM1ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM1ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxPDM1ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() !=  TextBoxPDM2MN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM2MN.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxPDM2MN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() !=  TextBoxPDM2SD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM2SD.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxPDM2SD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() !=  RadioButtonListPDM2ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM2ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListPDM2ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() !=  TextBoxPDM2ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM2ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = TextBoxPDM2ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() != TextBoxPDM3MN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM3MN.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = TextBoxPDM3MN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != TextBoxPDM3SD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM3SD.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = TextBoxPDM3SD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != RadioButtonListPDM3ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM3ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = RadioButtonListPDM3ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != TextBoxPDM3ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM3ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = TextBoxPDM3ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != TextBoxPDM4MN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM4MN.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = TextBoxPDM4MN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString() != TextBoxPDM4SD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM4SD.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = TextBoxPDM4SD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString() != RadioButtonListPDM4ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM4ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = RadioButtonListPDM4ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt16"].ToString() != TextBoxPDM4ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM4ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][15];
                dtrow["NewValue"] = TextBoxPDM4ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt17"].ToString() != TextBoxPDM5MN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM5MN.Text;
                dtrow["OldValue"] = dt1.Rows[0][16];
                dtrow["NewValue"] = TextBoxPDM5MN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt18"].ToString() != TextBoxPDM5SD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM5SD.Text;
                dtrow["OldValue"] = dt1.Rows[0][17];
                dtrow["NewValue"] = TextBoxPDM5SD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt19"].ToString() != RadioButtonListPDM5ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM5ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][18];
                dtrow["NewValue"] = RadioButtonListPDM5ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt20"].ToString() != TextBoxPDM5ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPDM5ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][19];
                dtrow["NewValue"] = TextBoxPDM5ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_ConMedForMedicalHistory]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@PDM1MN", TextBoxPDM1MN.Text);
            cmd.Parameters.AddWithValue("@PDM1SD", TextBoxPDM1SD.Text);
            cmd.Parameters.AddWithValue("@PDM1ONGO", RadioButtonListPDM1ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@PDM1ED", TextBoxPDM1ED.Text);
            cmd.Parameters.AddWithValue("@PDM2MN", TextBoxPDM2MN.Text);
            cmd.Parameters.AddWithValue("@PDM2SD", TextBoxPDM2SD.Text);
            cmd.Parameters.AddWithValue("@PDM2ONGO", RadioButtonListPDM2ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@PDM2ED", TextBoxPDM2ED.Text);
            cmd.Parameters.AddWithValue("@PDM3MN", TextBoxPDM3MN.Text);
            cmd.Parameters.AddWithValue("@PDM3SD", TextBoxPDM3SD.Text);
            cmd.Parameters.AddWithValue("@PDM3ONGO", RadioButtonListPDM3ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@PDM3ED", TextBoxPDM3ED.Text);
            cmd.Parameters.AddWithValue("@PDM4MN", TextBoxPDM4MN.Text);
            cmd.Parameters.AddWithValue("@PDM4SD", TextBoxPDM4SD.Text);
            cmd.Parameters.AddWithValue("@PDM4ONGO", RadioButtonListPDM4ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@PDM4ED", TextBoxPDM4ED.Text);
            cmd.Parameters.AddWithValue("@PDM5MN", TextBoxPDM5MN.Text);
            cmd.Parameters.AddWithValue("@PDM5SD", TextBoxPDM5SD.Text);
            cmd.Parameters.AddWithValue("@PDM5ONGO", RadioButtonListPDM5ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@PDM5ED", TextBoxPDM5ED.Text);

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
            cmd.CommandText = "INSERT INTO tblReasonForChange (Site, SubId, Subini, QuestionText, OldValue,  NewValue, Reason, PageName, EUser) VALUES (@Site, @SubId, @Subini, @QuestionText, @OldValue,  @NewValue, @Reason, @PageName, @EUser)";
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
    
    #region QueryPDM1MN
    private void SetImageQueryPDM1MN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM1MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPDM1MN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPDM1MN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPDM1MN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPDM1MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPDM1MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPDM1MN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM1MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePDM1MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN2.Visible = false;
                PanelRaisePDM1MN3.Visible = false;
                PanelHidePDM1MN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePDM1MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM1MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePDM1MN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN2.Visible = true;
                PanelRaisePDM1MN3.Visible = true;
                PanelHidePDM1MN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePDM1MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM1MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN2.Visible = true;
                PanelRaisePDM1MN3.Visible = false;
                PanelHidePDM1MN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPDM1MN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ConMedForMedicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM1MN = '" + TextBoxPDM1MN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPDM1MN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPDM1MN.Visible = true;
                RAISEPDM1MN.ShowPopupWindow();
                QueryRaisePDM1MN.Visible = false;
                TextBoxRaisePDM1MN.Visible = false;
                PanelRaisePDM1MN.Visible = false;
                PanelRaisePDM1MN2.Visible = false;
                PanelRaisePDM1MN3.Visible = false;

                LabelRespondPDM1MN.Visible = false;
            }

            else if ((ImageQueryPDM1MN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM1MN.Visible = true;
                RAISEPDM1MN.ShowPopupWindow();
                QueryRaisePDM1MN.Visible = true;
                TextBoxRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN2.Visible = false;
                PanelRaisePDM1MN3.Visible = false;
                LabelRespondPDM1MN.Visible = true;
            }

            else if ((ImageQueryPDM1MN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM1MN.Visible = true;
                RAISEPDM1MN.ShowPopupWindow();
                QueryRaisePDM1MN.Visible = false;
                TextBoxRaisePDM1MN.Visible = false;
                PanelRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN2.Visible = true;
                PanelRaisePDM1MN3.Visible = false;
                LabelRespondPDM1MN.Visible = false;
            }
            else if ((ImageQueryPDM1MN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM1MN.Visible = true;
                RAISEPDM1MN.ShowPopupWindow();
                QueryRaisePDM1MN.Visible = false;
                TextBoxRaisePDM1MN.Visible = false;
                PanelRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN2.Visible = true;
                PanelRaisePDM1MN3.Visible = true;
                LabelRespondPDM1MN.Visible = false;
            }
            else
            {
                RAISEPDM1MN.Visible = true;
                RAISEPDM1MN.ShowPopupWindow();
                QueryRaisePDM1MN.Visible = false;
                TextBoxRaisePDM1MN.Visible = false;
                PanelRaisePDM1MN.Visible = true;
                PanelRaisePDM1MN2.Visible = true;
                PanelRaisePDM1MN3.Visible = true;
                LabelRespondPDM1MN.Visible = false;

            }
        }

    }
    protected void QueryRaisePDM1MN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePDM1MN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM1MN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM1MN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ConMedForMedicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM1MN = '" + TextBoxPDM1MN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPDM1MNMSG.ShowPopupWindow();
        RAISEPDM1MN.Visible = false;


    }
    #endregion
    #region QueryPDM2MN
    private void SetImageQueryPDM2MN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM2MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPDM2MN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPDM2MN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPDM2MN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPDM2MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPDM2MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPDM2MN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM2MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePDM2MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN2.Visible = false;
                PanelRaisePDM2MN3.Visible = false;
                PanelHidePDM2MN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePDM2MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM2MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePDM2MN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN2.Visible = true;
                PanelRaisePDM2MN3.Visible = true;
                PanelHidePDM2MN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePDM2MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM2MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN2.Visible = true;
                PanelRaisePDM2MN3.Visible = false;
                PanelHidePDM2MN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPDM2MN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ConMedForMedicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM2MN = '" + TextBoxPDM2MN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPDM2MN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPDM2MN.Visible = true;
                RAISEPDM2MN.ShowPopupWindow();
                QueryRaisePDM2MN.Visible = false;
                TextBoxRaisePDM2MN.Visible = false;
                PanelRaisePDM2MN.Visible = false;
                PanelRaisePDM2MN2.Visible = false;
                PanelRaisePDM2MN3.Visible = false;

                LabelRespondPDM2MN.Visible = false;
            }

            else if ((ImageQueryPDM2MN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM2MN.Visible = true;
                RAISEPDM2MN.ShowPopupWindow();
                QueryRaisePDM2MN.Visible = true;
                TextBoxRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN2.Visible = false;
                PanelRaisePDM2MN3.Visible = false;
                LabelRespondPDM2MN.Visible = true;
            }

            else if ((ImageQueryPDM2MN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM2MN.Visible = true;
                RAISEPDM2MN.ShowPopupWindow();
                QueryRaisePDM2MN.Visible = false;
                TextBoxRaisePDM2MN.Visible = false;
                PanelRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN2.Visible = true;
                PanelRaisePDM2MN3.Visible = false;
                LabelRespondPDM2MN.Visible = false;
            }
            else if ((ImageQueryPDM2MN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM2MN.Visible = true;
                RAISEPDM2MN.ShowPopupWindow();
                QueryRaisePDM2MN.Visible = false;
                TextBoxRaisePDM2MN.Visible = false;
                PanelRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN2.Visible = true;
                PanelRaisePDM2MN3.Visible = true;
                LabelRespondPDM2MN.Visible = false;
            }
            else
            {
                RAISEPDM2MN.Visible = true;
                RAISEPDM2MN.ShowPopupWindow();
                QueryRaisePDM2MN.Visible = false;
                TextBoxRaisePDM2MN.Visible = false;
                PanelRaisePDM2MN.Visible = true;
                PanelRaisePDM2MN2.Visible = true;
                PanelRaisePDM2MN3.Visible = true;
                LabelRespondPDM2MN.Visible = false;

            }
        }

    }
    protected void QueryRaisePDM2MN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePDM2MN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM2MN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM2MN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ConMedForMedicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM2MN = '" + TextBoxPDM2MN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPDM2MNMSG.ShowPopupWindow();
        RAISEPDM2MN.Visible = false;


    }
    #endregion
    #region QueryPDM3MN
    private void SetImageQueryPDM3MN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM3MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPDM3MN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPDM3MN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPDM3MN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPDM3MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPDM3MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPDM3MN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM3MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePDM3MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN2.Visible = false;
                PanelRaisePDM3MN3.Visible = false;
                PanelHidePDM3MN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePDM3MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM3MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePDM3MN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN2.Visible = true;
                PanelRaisePDM3MN3.Visible = true;
                PanelHidePDM3MN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePDM3MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM3MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN2.Visible = true;
                PanelRaisePDM3MN3.Visible = false;
                PanelHidePDM3MN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPDM3MN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ConMedForMedicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM3MN = '" + TextBoxPDM3MN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPDM3MN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPDM3MN.Visible = true;
                RAISEPDM3MN.ShowPopupWindow();
                QueryRaisePDM3MN.Visible = false;
                TextBoxRaisePDM3MN.Visible = false;
                PanelRaisePDM3MN.Visible = false;
                PanelRaisePDM3MN2.Visible = false;
                PanelRaisePDM3MN3.Visible = false;

                LabelRespondPDM3MN.Visible = false;
            }

            else if ((ImageQueryPDM3MN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM3MN.Visible = true;
                RAISEPDM3MN.ShowPopupWindow();
                QueryRaisePDM3MN.Visible = true;
                TextBoxRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN2.Visible = false;
                PanelRaisePDM3MN3.Visible = false;
                LabelRespondPDM3MN.Visible = true;
            }

            else if ((ImageQueryPDM3MN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM3MN.Visible = true;
                RAISEPDM3MN.ShowPopupWindow();
                QueryRaisePDM3MN.Visible = false;
                TextBoxRaisePDM3MN.Visible = false;
                PanelRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN2.Visible = true;
                PanelRaisePDM3MN3.Visible = false;
                LabelRespondPDM3MN.Visible = false;
            }
            else if ((ImageQueryPDM3MN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM3MN.Visible = true;
                RAISEPDM3MN.ShowPopupWindow();
                QueryRaisePDM3MN.Visible = false;
                TextBoxRaisePDM3MN.Visible = false;
                PanelRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN2.Visible = true;
                PanelRaisePDM3MN3.Visible = true;
                LabelRespondPDM3MN.Visible = false;
            }
            else
            {
                RAISEPDM3MN.Visible = true;
                RAISEPDM3MN.ShowPopupWindow();
                QueryRaisePDM3MN.Visible = false;
                TextBoxRaisePDM3MN.Visible = false;
                PanelRaisePDM3MN.Visible = true;
                PanelRaisePDM3MN2.Visible = true;
                PanelRaisePDM3MN3.Visible = true;
                LabelRespondPDM3MN.Visible = false;

            }
        }

    }
    protected void QueryRaisePDM3MN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePDM3MN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM3MN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM3MN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ConMedForMedicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM3MN = '" + TextBoxPDM3MN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPDM3MNMSG.ShowPopupWindow();
        RAISEPDM3MN.Visible = false;


    }
    #endregion
    #region QueryPDM4MN
    private void SetImageQueryPDM4MN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM4MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPDM4MN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPDM4MN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPDM4MN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPDM4MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPDM4MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPDM4MN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM4MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePDM4MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN2.Visible = false;
                PanelRaisePDM4MN3.Visible = false;
                PanelHidePDM4MN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePDM4MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM4MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePDM4MN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN2.Visible = true;
                PanelRaisePDM4MN3.Visible = true;
                PanelHidePDM4MN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePDM4MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM4MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN2.Visible = true;
                PanelRaisePDM4MN3.Visible = false;
                PanelHidePDM4MN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPDM4MN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ConMedForMedicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM4MN = '" + TextBoxPDM4MN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPDM4MN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPDM4MN.Visible = true;
                RAISEPDM4MN.ShowPopupWindow();
                QueryRaisePDM4MN.Visible = false;
                TextBoxRaisePDM4MN.Visible = false;
                PanelRaisePDM4MN.Visible = false;
                PanelRaisePDM4MN2.Visible = false;
                PanelRaisePDM4MN3.Visible = false;

                LabelRespondPDM4MN.Visible = false;
            }

            else if ((ImageQueryPDM4MN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM4MN.Visible = true;
                RAISEPDM4MN.ShowPopupWindow();
                QueryRaisePDM4MN.Visible = true;
                TextBoxRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN2.Visible = false;
                PanelRaisePDM4MN3.Visible = false;
                LabelRespondPDM4MN.Visible = true;
            }

            else if ((ImageQueryPDM4MN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM4MN.Visible = true;
                RAISEPDM4MN.ShowPopupWindow();
                QueryRaisePDM4MN.Visible = false;
                TextBoxRaisePDM4MN.Visible = false;
                PanelRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN2.Visible = true;
                PanelRaisePDM4MN3.Visible = false;
                LabelRespondPDM4MN.Visible = false;
            }
            else if ((ImageQueryPDM4MN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM4MN.Visible = true;
                RAISEPDM4MN.ShowPopupWindow();
                QueryRaisePDM4MN.Visible = false;
                TextBoxRaisePDM4MN.Visible = false;
                PanelRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN2.Visible = true;
                PanelRaisePDM4MN3.Visible = true;
                LabelRespondPDM4MN.Visible = false;
            }
            else
            {
                RAISEPDM4MN.Visible = true;
                RAISEPDM4MN.ShowPopupWindow();
                QueryRaisePDM4MN.Visible = false;
                TextBoxRaisePDM4MN.Visible = false;
                PanelRaisePDM4MN.Visible = true;
                PanelRaisePDM4MN2.Visible = true;
                PanelRaisePDM4MN3.Visible = true;
                LabelRespondPDM4MN.Visible = false;

            }
        }

    }
    protected void QueryRaisePDM4MN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePDM4MN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM4MN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM4MN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ConMedForMedicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM4MN = '" + TextBoxPDM4MN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPDM4MNMSG.ShowPopupWindow();
        RAISEPDM4MN.Visible = false;


    }
    #endregion
    #region QueryPDM5MN
    private void SetImageQueryPDM5MN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM5MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPDM5MN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPDM5MN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPDM5MN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPDM5MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPDM5MN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPDM5MN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM5MN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePDM5MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN2.Visible = false;
                PanelRaisePDM5MN3.Visible = false;
                PanelHidePDM5MN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePDM5MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM5MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePDM5MN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN2.Visible = true;
                PanelRaisePDM5MN3.Visible = true;
                PanelHidePDM5MN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePDM5MN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePDM5MN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN2.Visible = true;
                PanelRaisePDM5MN3.Visible = false;
                PanelHidePDM5MN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPDM5MN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ConMedForMedicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM5MN = '" + TextBoxPDM5MN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPDM5MN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPDM5MN.Visible = true;
                RAISEPDM5MN.ShowPopupWindow();
                QueryRaisePDM5MN.Visible = false;
                TextBoxRaisePDM5MN.Visible = false;
                PanelRaisePDM5MN.Visible = false;
                PanelRaisePDM5MN2.Visible = false;
                PanelRaisePDM5MN3.Visible = false;

                LabelRespondPDM5MN.Visible = false;
            }

            else if ((ImageQueryPDM5MN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM5MN.Visible = true;
                RAISEPDM5MN.ShowPopupWindow();
                QueryRaisePDM5MN.Visible = true;
                TextBoxRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN2.Visible = false;
                PanelRaisePDM5MN3.Visible = false;
                LabelRespondPDM5MN.Visible = true;
            }

            else if ((ImageQueryPDM5MN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM5MN.Visible = true;
                RAISEPDM5MN.ShowPopupWindow();
                QueryRaisePDM5MN.Visible = false;
                TextBoxRaisePDM5MN.Visible = false;
                PanelRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN2.Visible = true;
                PanelRaisePDM5MN3.Visible = false;
                LabelRespondPDM5MN.Visible = false;
            }
            else if ((ImageQueryPDM5MN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPDM5MN.Visible = true;
                RAISEPDM5MN.ShowPopupWindow();
                QueryRaisePDM5MN.Visible = false;
                TextBoxRaisePDM5MN.Visible = false;
                PanelRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN2.Visible = true;
                PanelRaisePDM5MN3.Visible = true;
                LabelRespondPDM5MN.Visible = false;
            }
            else
            {
                RAISEPDM5MN.Visible = true;
                RAISEPDM5MN.ShowPopupWindow();
                QueryRaisePDM5MN.Visible = false;
                TextBoxRaisePDM5MN.Visible = false;
                PanelRaisePDM5MN.Visible = true;
                PanelRaisePDM5MN2.Visible = true;
                PanelRaisePDM5MN3.Visible = true;
                LabelRespondPDM5MN.Visible = false;

            }
        }

    }
    protected void QueryRaisePDM5MN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePDM5MN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM5MN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPDM5MN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ConMedForMedicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PDM5MN = '" + TextBoxPDM5MN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPDM5MNMSG.ShowPopupWindow();
        RAISEPDM5MN.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListPDM1ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM1ED.Visible = true;
        }
        else
        {
            TextBoxPDM1ED.Visible = false;
        }
        if (RadioButtonListPDM2ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM2ED.Visible = true;
        }
        else
        {
            TextBoxPDM2ED.Visible = false;
        }
        if (RadioButtonListPDM3ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM3ED.Visible = true;
        }
        else
        {
            TextBoxPDM3ED.Visible = false;
        }
        if (RadioButtonListPDM4ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM4ED.Visible = true;
        }
        else
        {
            TextBoxPDM4ED.Visible = false;
        }
        if (RadioButtonListPDM5ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM5ED.Visible = true;
        }
        else
        {
            TextBoxPDM5ED.Visible = false;
        }
    }

    protected void RadioButtonListPDM1ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListPDM1ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM1ED.Visible = true;
        }
        else
        {
            TextBoxPDM1ED.Visible = false;
            TextBoxPDM1ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListPDM2ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListPDM2ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM2ED.Visible = true;
        }
        else
        {
            TextBoxPDM2ED.Visible = false;
            TextBoxPDM2ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListPDM3ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListPDM3ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM3ED.Visible = true;
        }
        else
        {
            TextBoxPDM3ED.Visible = false;
            TextBoxPDM3ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListPDM4ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListPDM4ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM4ED.Visible = true;
        }
        else
        {
            TextBoxPDM4ED.Visible = false;
            TextBoxPDM4ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListPDM5ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListPDM5ONGO.SelectedValue == "Yes")
        {
            TextBoxPDM5ED.Visible = true;
        }
        else
        {
            TextBoxPDM5ED.Visible = false;
            TextBoxPDM5ED.Text = string.Empty;
        }
    }
}