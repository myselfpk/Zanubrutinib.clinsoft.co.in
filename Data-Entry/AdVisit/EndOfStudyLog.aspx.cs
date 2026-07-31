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

public partial class Data_Entry_AdVisit_EndOfStudyLog : System.Web.UI.Page
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

        SetImageQueryEOSPER();
        SetImageQueryEOSDSC();
        SetImageQueryEOSDPMD();
        SetImageQueryEOSRSN();
        SetImageQueryEOSLFUDT();
        SetImageQueryEOSDOD();
        SetImageQueryEOSSPRS();

        BindQueryDataEOSPER();
        BindQueryDataEOSDSC();
        BindQueryDataEOSDPMD();
        BindQueryDataEOSRSN();
        BindQueryDataEOSLFUDT();
        BindQueryDataEOSDOD();
        BindQueryDataEOSSPRS();

        ShowHide();

        TextBoxEOSDSC_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxEOSDPMD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxEOSLFUDT_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        TextBoxEOSDOD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
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

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT EOSPER ,EOSDSC ,EOSDPMD ,EOSRSN ,EOSLFUDT ,EOSDOD ,EOSSPRS FROM [Add].[EndOfStudyLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListEOSPER.SelectedValue = dt.Rows[0]["EOSPER"].ToString();
            TextBoxEOSDSC.Text = dt.Rows[0]["EOSDSC"].ToString();
            TextBoxEOSDPMD.Text = dt.Rows[0]["EOSDPMD"].ToString();
            RadioButtonListEOSRSN.SelectedValue = dt.Rows[0]["EOSRSN"].ToString();
            TextBoxEOSLFUDT.Text = dt.Rows[0]["EOSLFUDT"].ToString();
            TextBoxEOSDOD.Text = dt.Rows[0]["EOSDOD"].ToString();
            TextBoxEOSSPRS.Text = dt.Rows[0]["EOSSPRS"].ToString();

            ViewState["txt1"] = RadioButtonListEOSPER.SelectedValue;
            ViewState["txt2"] = TextBoxEOSDSC.Text;
            ViewState["txt3"] = TextBoxEOSDPMD.Text;
            ViewState["txt4"] = RadioButtonListEOSRSN.SelectedValue;
            ViewState["txt5"] = TextBoxEOSLFUDT.Text;
            ViewState["txt6"] = TextBoxEOSDOD.Text;
            ViewState["txt7"] = TextBoxEOSSPRS.Text;
        }
        con.Close();

    }

    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Add].[EndOfStudyLog]  where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Add].[EndOfStudyLog]  where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Add].[sp_EndOfStudyLog]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@EOSPER", RadioButtonListEOSPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@EOSDSC", TextBoxEOSDSC.Text);
                    cmd.Parameters.AddWithValue("@EOSDPMD", TextBoxEOSDPMD.Text);
                    cmd.Parameters.AddWithValue("@EOSRSN", RadioButtonListEOSRSN.SelectedValue);
                    cmd.Parameters.AddWithValue("@EOSLFUDT", TextBoxEOSLFUDT.Text);
                    cmd.Parameters.AddWithValue("@EOSDOD", TextBoxEOSDOD.Text);
                    cmd.Parameters.AddWithValue("@EOSSPRS", TextBoxEOSSPRS.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Add].[EndOfStudyLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListEOSPER.SelectedValue || ViewState["txt2"].ToString() != TextBoxEOSDSC.Text || ViewState["txt3"].ToString() != TextBoxEOSDPMD.Text || ViewState["txt4"].ToString() != RadioButtonListEOSRSN.SelectedValue || ViewState["txt5"].ToString() != TextBoxEOSLFUDT.Text || ViewState["txt6"].ToString() != TextBoxEOSDOD.Text || ViewState["txt7"].ToString() != TextBoxEOSSPRS.Text)
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
                cmd = new SqlCommand("[Add].[sp_EndOfStudyLog]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@EOSPER", RadioButtonListEOSPER.SelectedValue);
                cmd.Parameters.AddWithValue("@EOSDSC", TextBoxEOSDSC.Text);
                cmd.Parameters.AddWithValue("@EOSDPMD", TextBoxEOSDPMD.Text);
                cmd.Parameters.AddWithValue("@EOSRSN", RadioButtonListEOSRSN.SelectedValue);
                cmd.Parameters.AddWithValue("@EOSLFUDT", TextBoxEOSLFUDT.Text);
                cmd.Parameters.AddWithValue("@EOSDOD", TextBoxEOSDOD.Text);
                cmd.Parameters.AddWithValue("@EOSSPRS", TextBoxEOSSPRS.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Add].[EndOfStudyLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Add].[sp_EndOfStudyLog]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@EOSPER", RadioButtonListEOSPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@EOSDSC", TextBoxEOSDSC.Text);
                    cmd.Parameters.AddWithValue("@EOSDPMD", TextBoxEOSDPMD.Text);
                    cmd.Parameters.AddWithValue("@EOSRSN", RadioButtonListEOSRSN.SelectedValue);
                    cmd.Parameters.AddWithValue("@EOSLFUDT", TextBoxEOSLFUDT.Text);
                    cmd.Parameters.AddWithValue("@EOSDOD", TextBoxEOSDOD.Text);
                    cmd.Parameters.AddWithValue("@EOSSPRS", TextBoxEOSSPRS.Text);

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
                cmd = new SqlCommand("[Add].[sp_EndOfStudyLog]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@EOSPER", RadioButtonListEOSPER.SelectedValue);
                cmd.Parameters.AddWithValue("@EOSDSC", TextBoxEOSDSC.Text);
                cmd.Parameters.AddWithValue("@EOSDPMD", TextBoxEOSDPMD.Text);
                cmd.Parameters.AddWithValue("@EOSRSN", RadioButtonListEOSRSN.SelectedValue);
                cmd.Parameters.AddWithValue("@EOSLFUDT", TextBoxEOSLFUDT.Text);
                cmd.Parameters.AddWithValue("@EOSDOD", TextBoxEOSDOD.Text);
                cmd.Parameters.AddWithValue("@EOSSPRS", TextBoxEOSSPRS.Text);

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
        if (!string.IsNullOrEmpty(RadioButtonListEOSPER.SelectedValue) || !string.IsNullOrEmpty(TextBoxEOSDSC.Text) || !string.IsNullOrEmpty(TextBoxEOSDPMD.Text) || !string.IsNullOrEmpty(RadioButtonListEOSRSN.SelectedValue) || !string.IsNullOrEmpty(TextBoxEOSLFUDT.Text) || !string.IsNullOrEmpty(TextBoxEOSDOD.Text) || !string.IsNullOrEmpty(TextBoxEOSSPRS.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];

            if (ViewState["txt1"].ToString().Trim() != RadioButtonListEOSPER.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEOSPER.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListEOSPER.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString().Trim() != TextBoxEOSDSC.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEOSDSC.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxEOSDSC.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString().Trim() != TextBoxEOSDPMD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEOSDPMD.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxEOSDPMD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString().Trim() != RadioButtonListEOSRSN.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEOSRSN.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListEOSRSN.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString().Trim() != TextBoxEOSLFUDT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEOSLFUDT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxEOSLFUDT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString().Trim() != TextBoxEOSDOD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEOSDOD.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxEOSDOD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString().Trim() != TextBoxEOSSPRS.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEOSSPRS.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = TextBoxEOSSPRS.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Add].[sp_EndOfStudyLog]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@EOSPER", RadioButtonListEOSPER.SelectedValue);
            cmd.Parameters.AddWithValue("@EOSDSC", TextBoxEOSDSC.Text);
            cmd.Parameters.AddWithValue("@EOSDPMD", TextBoxEOSDPMD.Text);
            cmd.Parameters.AddWithValue("@EOSRSN", RadioButtonListEOSRSN.SelectedValue);
            cmd.Parameters.AddWithValue("@EOSLFUDT", TextBoxEOSLFUDT.Text);
            cmd.Parameters.AddWithValue("@EOSDOD", TextBoxEOSDOD.Text);
            cmd.Parameters.AddWithValue("@EOSSPRS", TextBoxEOSSPRS.Text);

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
            cmd.CommandText = "INSERT INTO tblReasonForChange (Site,  SubId,  Subini,  QuestionText,  OldValue,  NewValue,  Reason, PageName,  EUser) VALUES        (@Site,  @SubId,  @Subini,  @QuestionText,  @OldValue,  @NewValue,  @Reason, @PageName,  @EUser)";
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
    #region QueryEOSPER
    private void SetImageQueryEOSPER()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEOSPER.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEOSPER.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEOSPER.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEOSPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEOSPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEOSPER()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEOSPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER2.Visible = false;
                PanelRaiseEOSPER3.Visible = false;
                PanelHideEOSPER.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEOSPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEOSPER3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER2.Visible = true;
                PanelRaiseEOSPER3.Visible = true;
                PanelHideEOSPER.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEOSPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER2.Visible = true;
                PanelRaiseEOSPER3.Visible = false;
                PanelHideEOSPER.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEOSPER_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[EndOfStudyLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSPER = '" + RadioButtonListEOSPER.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEOSPER.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEOSPER.Visible = true;
                RAISEEOSPER.ShowPopupWindow();
                QueryRaiseEOSPER.Visible = false;
                TextBoxRaiseEOSPER.Visible = false;
                PanelRaiseEOSPER.Visible = false;
                PanelRaiseEOSPER2.Visible = false;
                PanelRaiseEOSPER3.Visible = false;

                LabelRespondEOSPER.Visible = false;
            }

            else if ((ImageQueryEOSPER.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSPER.Visible = true;
                RAISEEOSPER.ShowPopupWindow();
                QueryRaiseEOSPER.Visible = true;
                TextBoxRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER2.Visible = false;
                PanelRaiseEOSPER3.Visible = false;
                LabelRespondEOSPER.Visible = true;
            }

            else if ((ImageQueryEOSPER.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSPER.Visible = true;
                RAISEEOSPER.ShowPopupWindow();
                QueryRaiseEOSPER.Visible = false;
                TextBoxRaiseEOSPER.Visible = false;
                PanelRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER2.Visible = true;
                PanelRaiseEOSPER3.Visible = false;
                LabelRespondEOSPER.Visible = false;
            }
            else if ((ImageQueryEOSPER.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSPER.Visible = true;
                RAISEEOSPER.ShowPopupWindow();
                QueryRaiseEOSPER.Visible = false;
                TextBoxRaiseEOSPER.Visible = false;
                PanelRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER2.Visible = true;
                PanelRaiseEOSPER3.Visible = true;
                LabelRespondEOSPER.Visible = false;
            }
            else
            {
                RAISEEOSPER.Visible = true;
                RAISEEOSPER.ShowPopupWindow();
                QueryRaiseEOSPER.Visible = false;
                TextBoxRaiseEOSPER.Visible = false;
                PanelRaiseEOSPER.Visible = true;
                PanelRaiseEOSPER2.Visible = true;
                PanelRaiseEOSPER3.Visible = true;
                LabelRespondEOSPER.Visible = false;

            }
        }

    }
    protected void QueryRaiseEOSPER_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseEOSPER.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSPER.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSPER.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[EndOfStudyLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSPER = '" + RadioButtonListEOSPER.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEOSPERMSG.ShowPopupWindow();
        RAISEEOSPER.Visible = false;


    }
    #endregion
    #region QueryEOSRSN
    private void SetImageQueryEOSRSN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEOSRSN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEOSRSN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEOSRSN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEOSRSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEOSRSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEOSRSN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEOSRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN2.Visible = false;
                PanelRaiseEOSRSN3.Visible = false;
                PanelHideEOSRSN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEOSRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEOSRSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN2.Visible = true;
                PanelRaiseEOSRSN3.Visible = true;
                PanelHideEOSRSN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEOSRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN2.Visible = true;
                PanelRaiseEOSRSN3.Visible = false;
                PanelHideEOSRSN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEOSRSN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[EndOfStudyLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSRSN = '" + RadioButtonListEOSRSN.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEOSRSN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEOSRSN.Visible = true;
                RAISEEOSRSN.ShowPopupWindow();
                QueryRaiseEOSRSN.Visible = false;
                TextBoxRaiseEOSRSN.Visible = false;
                PanelRaiseEOSRSN.Visible = false;
                PanelRaiseEOSRSN2.Visible = false;
                PanelRaiseEOSRSN3.Visible = false;

                LabelRespondEOSRSN.Visible = false;
            }

            else if ((ImageQueryEOSRSN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSRSN.Visible = true;
                RAISEEOSRSN.ShowPopupWindow();
                QueryRaiseEOSRSN.Visible = true;
                TextBoxRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN2.Visible = false;
                PanelRaiseEOSRSN3.Visible = false;
                LabelRespondEOSRSN.Visible = true;
            }

            else if ((ImageQueryEOSRSN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSRSN.Visible = true;
                RAISEEOSRSN.ShowPopupWindow();
                QueryRaiseEOSRSN.Visible = false;
                TextBoxRaiseEOSRSN.Visible = false;
                PanelRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN2.Visible = true;
                PanelRaiseEOSRSN3.Visible = false;
                LabelRespondEOSRSN.Visible = false;
            }
            else if ((ImageQueryEOSRSN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSRSN.Visible = true;
                RAISEEOSRSN.ShowPopupWindow();
                QueryRaiseEOSRSN.Visible = false;
                TextBoxRaiseEOSRSN.Visible = false;
                PanelRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN2.Visible = true;
                PanelRaiseEOSRSN3.Visible = true;
                LabelRespondEOSRSN.Visible = false;
            }
            else
            {
                RAISEEOSRSN.Visible = true;
                RAISEEOSRSN.ShowPopupWindow();
                QueryRaiseEOSRSN.Visible = false;
                TextBoxRaiseEOSRSN.Visible = false;
                PanelRaiseEOSRSN.Visible = true;
                PanelRaiseEOSRSN2.Visible = true;
                PanelRaiseEOSRSN3.Visible = true;
                LabelRespondEOSRSN.Visible = false;

            }
        }

    }
    protected void QueryRaiseEOSRSN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseEOSRSN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSRSN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSRSN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[EndOfStudyLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSRSN = '" + RadioButtonListEOSRSN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEOSRSNMSG.ShowPopupWindow();
        RAISEEOSRSN.Visible = false;


    }
    #endregion
    #region QueryEOSDSC
    private void SetImageQueryEOSDSC()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDSC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEOSDSC.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEOSDSC.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEOSDSC.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEOSDSC.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEOSDSC.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEOSDSC()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDSC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEOSDSC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC2.Visible = false;
                PanelRaiseEOSDSC3.Visible = false;
                PanelHideEOSDSC.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEOSDSC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSDSC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEOSDSC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC2.Visible = true;
                PanelRaiseEOSDSC3.Visible = true;
                PanelHideEOSDSC.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEOSDSC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSDSC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC2.Visible = true;
                PanelRaiseEOSDSC3.Visible = false;
                PanelHideEOSDSC.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEOSDSC_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[EndOfStudyLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSDSC = '" + TextBoxEOSDSC.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEOSDSC.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEOSDSC.Visible = true;
                RAISEEOSDSC.ShowPopupWindow();
                QueryRaiseEOSDSC.Visible = false;
                TextBoxRaiseEOSDSC.Visible = false;
                PanelRaiseEOSDSC.Visible = false;
                PanelRaiseEOSDSC2.Visible = false;
                PanelRaiseEOSDSC3.Visible = false;

                LabelRespondEOSDSC.Visible = false;
            }

            else if ((ImageQueryEOSDSC.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDSC.Visible = true;
                RAISEEOSDSC.ShowPopupWindow();
                QueryRaiseEOSDSC.Visible = true;
                TextBoxRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC2.Visible = false;
                PanelRaiseEOSDSC3.Visible = false;
                LabelRespondEOSDSC.Visible = true;
            }

            else if ((ImageQueryEOSDSC.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDSC.Visible = true;
                RAISEEOSDSC.ShowPopupWindow();
                QueryRaiseEOSDSC.Visible = false;
                TextBoxRaiseEOSDSC.Visible = false;
                PanelRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC2.Visible = true;
                PanelRaiseEOSDSC3.Visible = false;
                LabelRespondEOSDSC.Visible = false;
            }
            else if ((ImageQueryEOSDSC.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDSC.Visible = true;
                RAISEEOSDSC.ShowPopupWindow();
                QueryRaiseEOSDSC.Visible = false;
                TextBoxRaiseEOSDSC.Visible = false;
                PanelRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC2.Visible = true;
                PanelRaiseEOSDSC3.Visible = true;
                LabelRespondEOSDSC.Visible = false;
            }
            else
            {
                RAISEEOSDSC.Visible = true;
                RAISEEOSDSC.ShowPopupWindow();
                QueryRaiseEOSDSC.Visible = false;
                TextBoxRaiseEOSDSC.Visible = false;
                PanelRaiseEOSDSC.Visible = true;
                PanelRaiseEOSDSC2.Visible = true;
                PanelRaiseEOSDSC3.Visible = true;
                LabelRespondEOSDSC.Visible = false;

            }
        }

    }
    protected void QueryRaiseEOSDSC_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseEOSDSC.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDSC.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDSC.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[EndOfStudyLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSDSC = '" + TextBoxEOSDSC.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEOSDSCMSG.ShowPopupWindow();
        RAISEEOSDSC.Visible = false;


    }
    #endregion
    #region QueryEOSDPMD
    private void SetImageQueryEOSDPMD()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDPMD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEOSDPMD.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEOSDPMD.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEOSDPMD.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEOSDPMD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEOSDPMD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEOSDPMD()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDPMD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEOSDPMD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD2.Visible = false;
                PanelRaiseEOSDPMD3.Visible = false;
                PanelHideEOSDPMD.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEOSDPMD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSDPMD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEOSDPMD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD2.Visible = true;
                PanelRaiseEOSDPMD3.Visible = true;
                PanelHideEOSDPMD.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEOSDPMD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSDPMD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD2.Visible = true;
                PanelRaiseEOSDPMD3.Visible = false;
                PanelHideEOSDPMD.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEOSDPMD_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[EndOfStudyLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSDPMD = '" + TextBoxEOSDPMD.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEOSDPMD.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEOSDPMD.Visible = true;
                RAISEEOSDPMD.ShowPopupWindow();
                QueryRaiseEOSDPMD.Visible = false;
                TextBoxRaiseEOSDPMD.Visible = false;
                PanelRaiseEOSDPMD.Visible = false;
                PanelRaiseEOSDPMD2.Visible = false;
                PanelRaiseEOSDPMD3.Visible = false;

                LabelRespondEOSDPMD.Visible = false;
            }

            else if ((ImageQueryEOSDPMD.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDPMD.Visible = true;
                RAISEEOSDPMD.ShowPopupWindow();
                QueryRaiseEOSDPMD.Visible = true;
                TextBoxRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD2.Visible = false;
                PanelRaiseEOSDPMD3.Visible = false;
                LabelRespondEOSDPMD.Visible = true;
            }

            else if ((ImageQueryEOSDPMD.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDPMD.Visible = true;
                RAISEEOSDPMD.ShowPopupWindow();
                QueryRaiseEOSDPMD.Visible = false;
                TextBoxRaiseEOSDPMD.Visible = false;
                PanelRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD2.Visible = true;
                PanelRaiseEOSDPMD3.Visible = false;
                LabelRespondEOSDPMD.Visible = false;
            }
            else if ((ImageQueryEOSDPMD.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDPMD.Visible = true;
                RAISEEOSDPMD.ShowPopupWindow();
                QueryRaiseEOSDPMD.Visible = false;
                TextBoxRaiseEOSDPMD.Visible = false;
                PanelRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD2.Visible = true;
                PanelRaiseEOSDPMD3.Visible = true;
                LabelRespondEOSDPMD.Visible = false;
            }
            else
            {
                RAISEEOSDPMD.Visible = true;
                RAISEEOSDPMD.ShowPopupWindow();
                QueryRaiseEOSDPMD.Visible = false;
                TextBoxRaiseEOSDPMD.Visible = false;
                PanelRaiseEOSDPMD.Visible = true;
                PanelRaiseEOSDPMD2.Visible = true;
                PanelRaiseEOSDPMD3.Visible = true;
                LabelRespondEOSDPMD.Visible = false;

            }
        }

    }
    protected void QueryRaiseEOSDPMD_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseEOSDPMD.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDPMD.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDPMD.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[EndOfStudyLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSDPMD = '" + TextBoxEOSDPMD.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEOSDPMDMSG.ShowPopupWindow();
        RAISEEOSDPMD.Visible = false;


    }
    #endregion
    #region QueryEOSLFUDT
    private void SetImageQueryEOSLFUDT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSLFUDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEOSLFUDT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEOSLFUDT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEOSLFUDT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEOSLFUDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEOSLFUDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEOSLFUDT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSLFUDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEOSLFUDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT2.Visible = false;
                PanelRaiseEOSLFUDT3.Visible = false;
                PanelHideEOSLFUDT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEOSLFUDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSLFUDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEOSLFUDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT2.Visible = true;
                PanelRaiseEOSLFUDT3.Visible = true;
                PanelHideEOSLFUDT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEOSLFUDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSLFUDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT2.Visible = true;
                PanelRaiseEOSLFUDT3.Visible = false;
                PanelHideEOSLFUDT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEOSLFUDT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[EndOfStudyLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSLFUDT = '" + TextBoxEOSLFUDT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEOSLFUDT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEOSLFUDT.Visible = true;
                RAISEEOSLFUDT.ShowPopupWindow();
                QueryRaiseEOSLFUDT.Visible = false;
                TextBoxRaiseEOSLFUDT.Visible = false;
                PanelRaiseEOSLFUDT.Visible = false;
                PanelRaiseEOSLFUDT2.Visible = false;
                PanelRaiseEOSLFUDT3.Visible = false;

                LabelRespondEOSLFUDT.Visible = false;
            }

            else if ((ImageQueryEOSLFUDT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSLFUDT.Visible = true;
                RAISEEOSLFUDT.ShowPopupWindow();
                QueryRaiseEOSLFUDT.Visible = true;
                TextBoxRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT2.Visible = false;
                PanelRaiseEOSLFUDT3.Visible = false;
                LabelRespondEOSLFUDT.Visible = true;
            }

            else if ((ImageQueryEOSLFUDT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSLFUDT.Visible = true;
                RAISEEOSLFUDT.ShowPopupWindow();
                QueryRaiseEOSLFUDT.Visible = false;
                TextBoxRaiseEOSLFUDT.Visible = false;
                PanelRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT2.Visible = true;
                PanelRaiseEOSLFUDT3.Visible = false;
                LabelRespondEOSLFUDT.Visible = false;
            }
            else if ((ImageQueryEOSLFUDT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSLFUDT.Visible = true;
                RAISEEOSLFUDT.ShowPopupWindow();
                QueryRaiseEOSLFUDT.Visible = false;
                TextBoxRaiseEOSLFUDT.Visible = false;
                PanelRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT2.Visible = true;
                PanelRaiseEOSLFUDT3.Visible = true;
                LabelRespondEOSLFUDT.Visible = false;
            }
            else
            {
                RAISEEOSLFUDT.Visible = true;
                RAISEEOSLFUDT.ShowPopupWindow();
                QueryRaiseEOSLFUDT.Visible = false;
                TextBoxRaiseEOSLFUDT.Visible = false;
                PanelRaiseEOSLFUDT.Visible = true;
                PanelRaiseEOSLFUDT2.Visible = true;
                PanelRaiseEOSLFUDT3.Visible = true;
                LabelRespondEOSLFUDT.Visible = false;

            }
        }

    }
    protected void QueryRaiseEOSLFUDT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseEOSLFUDT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSLFUDT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSLFUDT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[EndOfStudyLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSLFUDT = '" + TextBoxEOSLFUDT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEOSLFUDTMSG.ShowPopupWindow();
        RAISEEOSLFUDT.Visible = false;


    }
    #endregion
    #region QueryEOSDOD
    private void SetImageQueryEOSDOD()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDOD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEOSDOD.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEOSDOD.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEOSDOD.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEOSDOD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEOSDOD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEOSDOD()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDOD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEOSDOD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD2.Visible = false;
                PanelRaiseEOSDOD3.Visible = false;
                PanelHideEOSDOD.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEOSDOD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSDOD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEOSDOD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD2.Visible = true;
                PanelRaiseEOSDOD3.Visible = true;
                PanelHideEOSDOD.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEOSDOD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSDOD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD2.Visible = true;
                PanelRaiseEOSDOD3.Visible = false;
                PanelHideEOSDOD.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEOSDOD_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[EndOfStudyLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSDOD = '" + TextBoxEOSDOD.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEOSDOD.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEOSDOD.Visible = true;
                RAISEEOSDOD.ShowPopupWindow();
                QueryRaiseEOSDOD.Visible = false;
                TextBoxRaiseEOSDOD.Visible = false;
                PanelRaiseEOSDOD.Visible = false;
                PanelRaiseEOSDOD2.Visible = false;
                PanelRaiseEOSDOD3.Visible = false;

                LabelRespondEOSDOD.Visible = false;
            }

            else if ((ImageQueryEOSDOD.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDOD.Visible = true;
                RAISEEOSDOD.ShowPopupWindow();
                QueryRaiseEOSDOD.Visible = true;
                TextBoxRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD2.Visible = false;
                PanelRaiseEOSDOD3.Visible = false;
                LabelRespondEOSDOD.Visible = true;
            }

            else if ((ImageQueryEOSDOD.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDOD.Visible = true;
                RAISEEOSDOD.ShowPopupWindow();
                QueryRaiseEOSDOD.Visible = false;
                TextBoxRaiseEOSDOD.Visible = false;
                PanelRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD2.Visible = true;
                PanelRaiseEOSDOD3.Visible = false;
                LabelRespondEOSDOD.Visible = false;
            }
            else if ((ImageQueryEOSDOD.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSDOD.Visible = true;
                RAISEEOSDOD.ShowPopupWindow();
                QueryRaiseEOSDOD.Visible = false;
                TextBoxRaiseEOSDOD.Visible = false;
                PanelRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD2.Visible = true;
                PanelRaiseEOSDOD3.Visible = true;
                LabelRespondEOSDOD.Visible = false;
            }
            else
            {
                RAISEEOSDOD.Visible = true;
                RAISEEOSDOD.ShowPopupWindow();
                QueryRaiseEOSDOD.Visible = false;
                TextBoxRaiseEOSDOD.Visible = false;
                PanelRaiseEOSDOD.Visible = true;
                PanelRaiseEOSDOD2.Visible = true;
                PanelRaiseEOSDOD3.Visible = true;
                LabelRespondEOSDOD.Visible = false;

            }
        }

    }
    protected void QueryRaiseEOSDOD_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseEOSDOD.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDOD.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSDOD.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[EndOfStudyLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSDOD = '" + TextBoxEOSDOD.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEOSDODMSG.ShowPopupWindow();
        RAISEEOSDOD.Visible = false;


    }
    #endregion
    #region QueryEOSSPRS
    private void SetImageQueryEOSSPRS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSSPRS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEOSSPRS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEOSSPRS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEOSSPRS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEOSSPRS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEOSSPRS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEOSSPRS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSSPRS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEOSSPRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS2.Visible = false;
                PanelRaiseEOSSPRS3.Visible = false;
                PanelHideEOSSPRS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEOSSPRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSSPRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEOSSPRS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS2.Visible = true;
                PanelRaiseEOSSPRS3.Visible = true;
                PanelHideEOSSPRS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEOSSPRS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEOSSPRS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS2.Visible = true;
                PanelRaiseEOSSPRS3.Visible = false;
                PanelHideEOSSPRS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEOSSPRS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[EndOfStudyLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSSPRS = '" + TextBoxEOSSPRS.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEOSSPRS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEOSSPRS.Visible = true;
                RAISEEOSSPRS.ShowPopupWindow();
                QueryRaiseEOSSPRS.Visible = false;
                TextBoxRaiseEOSSPRS.Visible = false;
                PanelRaiseEOSSPRS.Visible = false;
                PanelRaiseEOSSPRS2.Visible = false;
                PanelRaiseEOSSPRS3.Visible = false;

                LabelRespondEOSSPRS.Visible = false;
            }

            else if ((ImageQueryEOSSPRS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSSPRS.Visible = true;
                RAISEEOSSPRS.ShowPopupWindow();
                QueryRaiseEOSSPRS.Visible = true;
                TextBoxRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS2.Visible = false;
                PanelRaiseEOSSPRS3.Visible = false;
                LabelRespondEOSSPRS.Visible = true;
            }

            else if ((ImageQueryEOSSPRS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSSPRS.Visible = true;
                RAISEEOSSPRS.ShowPopupWindow();
                QueryRaiseEOSSPRS.Visible = false;
                TextBoxRaiseEOSSPRS.Visible = false;
                PanelRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS2.Visible = true;
                PanelRaiseEOSSPRS3.Visible = false;
                LabelRespondEOSSPRS.Visible = false;
            }
            else if ((ImageQueryEOSSPRS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEOSSPRS.Visible = true;
                RAISEEOSSPRS.ShowPopupWindow();
                QueryRaiseEOSSPRS.Visible = false;
                TextBoxRaiseEOSSPRS.Visible = false;
                PanelRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS2.Visible = true;
                PanelRaiseEOSSPRS3.Visible = true;
                LabelRespondEOSSPRS.Visible = false;
            }
            else
            {
                RAISEEOSSPRS.Visible = true;
                RAISEEOSSPRS.ShowPopupWindow();
                QueryRaiseEOSSPRS.Visible = false;
                TextBoxRaiseEOSSPRS.Visible = false;
                PanelRaiseEOSSPRS.Visible = true;
                PanelRaiseEOSSPRS2.Visible = true;
                PanelRaiseEOSSPRS3.Visible = true;
                LabelRespondEOSSPRS.Visible = false;

            }
        }

    }
    protected void QueryRaiseEOSSPRS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseEOSSPRS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSSPRS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEOSSPRS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[EndOfStudyLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EOSSPRS = '" + TextBoxEOSSPRS.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEOSSPRSMSG.ShowPopupWindow();
        RAISEEOSSPRS.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListEOSPER.SelectedValue == "Yes")
        {
            hideEOSDSC.Visible = true;
            hideEOSDPMD.Visible = false;
            hideEOSRSN.Visible = false;
            hideEOSLFUDT.Visible = false;
            hideEOSDOD.Visible = false;
            if (RadioButtonListEOSRSN.SelectedValue == "Other")
            {
                hideEOSSPRS.Visible = true;
            }
            else if (RadioButtonListEOSRSN.SelectedValue == "Death")
            {
                hideEOSDOD.Visible = true;
            }
            else
            {
                hideEOSSPRS.Visible = false;
                hideEOSDOD.Visible = false;
                hideEOSLFUDT.Visible = true;
            }
        }
        else if (RadioButtonListEOSPER.SelectedValue == "No")
        {
            hideEOSDSC.Visible = false;
            hideEOSDPMD.Visible = true;
            hideEOSRSN.Visible = true;
        }
        else
        {
            hideEOSDSC.Visible = false;
            hideEOSDPMD.Visible = false;
            hideEOSRSN.Visible = false;
            hideEOSLFUDT.Visible = false;
            hideEOSDOD.Visible = false;
            hideEOSSPRS.Visible = false;
        }

        if (RadioButtonListEOSRSN.SelectedValue == "Other")
        {
            hideEOSSPRS.Visible = true;
        }
        else if (RadioButtonListEOSRSN.SelectedValue == "Death")
        {
            hideEOSDOD.Visible = true;
        }
        else
        {
            hideEOSSPRS.Visible = false;
            hideEOSDOD.Visible = false;
            hideEOSLFUDT.Visible = true;
        }
    }
    protected void RadioButtonListEOSPER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListEOSPER.SelectedValue == "Yes")
        {
            hideEOSDSC.Visible = true;
            hideEOSDPMD.Visible = false;
            TextBoxEOSDPMD.Text = string.Empty;
            hideEOSRSN.Visible = false;
            RadioButtonListEOSRSN.ClearSelection();
            hideEOSLFUDT.Visible = false;
            TextBoxEOSLFUDT.Text = string.Empty;
            hideEOSDOD.Visible = false;
            TextBoxEOSDOD.Text = string.Empty;
            if(RadioButtonListEOSRSN.SelectedValue == "Other")
            {
                hideEOSSPRS.Visible = true;
            }
            else if (RadioButtonListEOSRSN.SelectedValue == "Death")
            {
                hideEOSDOD.Visible = true;
            }
            else if (RadioButtonListEOSRSN.SelectedValue != "Other")
            {
                
            }
            else
            {
                hideEOSSPRS.Visible = false;
                TextBoxEOSSPRS.Text = string.Empty;
                hideEOSDOD.Visible = false;
                TextBoxEOSDOD.Text = string.Empty;
                hideEOSLFUDT.Visible = true;
            }
        }
        else if (RadioButtonListEOSPER.SelectedValue == "No")
        {
            hideEOSDSC.Visible = false;
            hideEOSDPMD.Visible = true;
            hideEOSRSN.Visible = true;
        }
        else
        {
            hideEOSDSC.Visible = false;
            TextBoxEOSDSC.Text = string.Empty;
            hideEOSDPMD.Visible = false;
            TextBoxEOSDPMD.Text = string.Empty;
            hideEOSRSN.Visible = false;
            RadioButtonListEOSRSN.ClearSelection();
            hideEOSLFUDT.Visible = false;
            TextBoxEOSLFUDT.Text = string.Empty;
            hideEOSDOD.Visible = false;
            TextBoxEOSDOD.Text = string.Empty;
            hideEOSSPRS.Visible = false;
            TextBoxEOSSPRS.Text = string.Empty;
        }
    }

    protected void RadioButtonListEOSRSN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListEOSRSN.SelectedValue == "Other")
        {
            hideEOSSPRS.Visible = true;
        }
        else if (RadioButtonListEOSRSN.SelectedValue == "Death")
        {
            hideEOSDOD.Visible = true;
        }
        else if (RadioButtonListEOSRSN.SelectedValue != "Other")
        {

        }
        else
        {
            hideEOSSPRS.Visible = false;
            TextBoxEOSSPRS.Text = string.Empty;
            hideEOSDOD.Visible = false;
            TextBoxEOSDOD.Text = string.Empty;
            hideEOSLFUDT.Visible = true;
        }
    }
}