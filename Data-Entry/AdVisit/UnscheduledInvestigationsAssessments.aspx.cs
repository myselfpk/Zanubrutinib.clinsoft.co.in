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

public partial class Data_Entry_AdVisit_UnscheduledInvestigationsAssessments : System.Web.UI.Page
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
        SetImageAddNote();
        BindGridviewAddNote();
        SetImageAttach();
        BindGridViewADDAddAttachment();

        SetImageAttachPageHistory();
        BindGridViewADDAttachmentPageHistory();
        TextBoxUIADT_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        SetImageQueryUISNO();
        SetImageQueryUIADT();
        SetImageQueryUIASS();
        SetImageQueryUIARSLT();
        SetImageQueryUIAUT();
        SetImageQueryUIARSN();
        SetImageQueryUIAABN();
        SetImageQueryUIACS();

        BindQueryDataUISNO();
        BindQueryDataUIADT();
        BindQueryDataUIASS();
        BindQueryDataUIARSLT();
        BindQueryDataUIAUT();
        BindQueryDataUIARSN();
        BindQueryDataUIAABN();
        BindQueryDataUIACS();
        if (RadioButtonListUIAABN.SelectedValue == "Abnormal")
        {
            hideUIACS.Visible = true;
        }
        else
        {
            hideUIACS.Visible = false;
        }
    }
    #region Note Acttchment and PageHistory
    #region AddNote
    private void SetImageAddNote()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from ADDNOTE where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'", con);
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

        cmd = new SqlCommand("insert into ADDNOTE values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + AddNoteFiledTextBox.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','" + AddNoteTextBox.Text + "','" + TextBoxUISNO.Text + "')", con);
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
            SqlCommand cmd = new SqlCommand("select * from ADDNOTE where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
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
        SqlCommand cmd = new SqlCommand("Select * from ADDATTACHMENT where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "'", con);
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
                        cmd.Parameters.AddWithValue("@SNO", TextBoxUISNO.Text);
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
                cmd.CommandText = "select ID,Site,ScreenID,SubInitial ,Visit,Page,Field,Username,Date,Title,Name ,ContentType,Data from ADDATTACHMENT where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "'";
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
        SqlCommand cmd = new SqlCommand("Select * from tblReasonForChange where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'", con);
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
                cmd.CommandText = "SELECT ID, [QuestionText],[OldValue],[NewValue],[Reason],[PageName],[EUser],[EDate] FROM [dbo].[tblReasonForChange] where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'and SNO = '" + TextBoxUISNO.Text + "'";
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
        SqlCommand sqlCmd = new SqlCommand("SELECT UISNO ,UIADT ,UIASS ,UIARSLT ,UIAUT ,UIARSN ,UIAABN ,UIACS FROM [Add].[UnscheduledInvestigationsAssessments] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxUISNO.Text = dt.Rows[0]["UISNO"].ToString();
            TextBoxUIADT.Text = dt.Rows[0]["UIADT"].ToString();
            TextBoxUIASS.Text = dt.Rows[0]["UIASS"].ToString();
            TextBoxUIARSLT.Text = dt.Rows[0]["UIARSLT"].ToString();
            TextBoxUIAUT.Text = dt.Rows[0]["UIAUT"].ToString();
            TextBoxUIARSN.Text = dt.Rows[0]["UIARSN"].ToString();
            RadioButtonListUIAABN.SelectedValue = dt.Rows[0]["UIAABN"].ToString();
            RadioButtonListUIACS.SelectedValue = dt.Rows[0]["UIACS"].ToString();

            ViewState["txt1"] = TextBoxUISNO.Text;
            ViewState["txt2"] = TextBoxUIADT.Text;
            ViewState["txt3"] = TextBoxUIASS.Text;
            ViewState["txt4"] = TextBoxUIARSLT.Text;
            ViewState["txt5"] = TextBoxUIAUT.Text;
            ViewState["txt6"] = TextBoxUIARSN.Text;
            ViewState["txt7"] = RadioButtonListUIAABN.SelectedValue;
            ViewState["txt8"] = RadioButtonListUIACS.SelectedValue;
        }
        con.Close();

    }

    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Add].[UnscheduledInvestigationsAssessments] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "' and [UISNO]='" + Request.QueryString["f"] + "' and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Add].[UnscheduledInvestigationsAssessments] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "' and [UISNO]='" + Request.QueryString["f"] + "' and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Add].[sp_UnscheduledInvestigationsAssessments]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@UISNO", TextBoxUISNO.Text);
                    cmd.Parameters.AddWithValue("@UIADT", TextBoxUIADT.Text);
                    cmd.Parameters.AddWithValue("@UIASS", TextBoxUIASS.Text);
                    cmd.Parameters.AddWithValue("@UIARSLT", TextBoxUIARSLT.Text);
                    cmd.Parameters.AddWithValue("@UIAUT", TextBoxUIAUT.Text);
                    cmd.Parameters.AddWithValue("@UIARSN", TextBoxUIARSN.Text);
                    cmd.Parameters.AddWithValue("@UIAABN", RadioButtonListUIAABN.SelectedValue);
                    cmd.Parameters.AddWithValue("@UIACS", RadioButtonListUIACS.SelectedValue);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Add].[UnscheduledInvestigationsAssessments] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "' and [UISNO]='" + Request.QueryString["f"] + "' and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != TextBoxUISNO.Text || ViewState["txt2"].ToString() != TextBoxUIADT.Text || ViewState["txt3"].ToString() != TextBoxUIASS.Text || ViewState["txt4"].ToString() != TextBoxUIARSLT.Text || ViewState["txt5"].ToString() != TextBoxUIAUT.Text || ViewState["txt6"].ToString() != TextBoxUIARSN.Text || ViewState["txt7"].ToString() != RadioButtonListUIAABN.SelectedValue || ViewState["txt8"].ToString() != RadioButtonListUIACS.SelectedValue)
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
                cmd = new SqlCommand("[Add].[sp_UnscheduledInvestigationsAssessments]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@UISNO", TextBoxUISNO.Text);
                cmd.Parameters.AddWithValue("@UIADT", TextBoxUIADT.Text);
                cmd.Parameters.AddWithValue("@UIASS", TextBoxUIASS.Text);
                cmd.Parameters.AddWithValue("@UIARSLT", TextBoxUIARSLT.Text);
                cmd.Parameters.AddWithValue("@UIAUT", TextBoxUIAUT.Text);
                cmd.Parameters.AddWithValue("@UIARSN", TextBoxUIARSN.Text);
                cmd.Parameters.AddWithValue("@UIAABN", RadioButtonListUIAABN.SelectedValue);
                cmd.Parameters.AddWithValue("@UIACS", RadioButtonListUIACS.SelectedValue);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Add].[UnscheduledInvestigationsAssessments] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "' and [UISNO]='" + Request.QueryString["f"] + "' and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Add].[sp_UnscheduledInvestigationsAssessments]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@UISNO", TextBoxUISNO.Text);
                    cmd.Parameters.AddWithValue("@UIADT", TextBoxUIADT.Text);
                    cmd.Parameters.AddWithValue("@UIASS", TextBoxUIASS.Text);
                    cmd.Parameters.AddWithValue("@UIARSLT", TextBoxUIARSLT.Text);
                    cmd.Parameters.AddWithValue("@UIAUT", TextBoxUIAUT.Text);
                    cmd.Parameters.AddWithValue("@UIARSN", TextBoxUIARSN.Text);
                    cmd.Parameters.AddWithValue("@UIAABN", RadioButtonListUIAABN.SelectedValue);
                    cmd.Parameters.AddWithValue("@UIACS", RadioButtonListUIACS.SelectedValue);

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
                cmd = new SqlCommand("[Add].[sp_UnscheduledInvestigationsAssessments]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@UISNO", TextBoxUISNO.Text);
                cmd.Parameters.AddWithValue("@UIADT", TextBoxUIADT.Text);
                cmd.Parameters.AddWithValue("@UIASS", TextBoxUIASS.Text);
                cmd.Parameters.AddWithValue("@UIARSLT", TextBoxUIARSLT.Text);
                cmd.Parameters.AddWithValue("@UIAUT", TextBoxUIAUT.Text);
                cmd.Parameters.AddWithValue("@UIARSN", TextBoxUIARSN.Text);
                cmd.Parameters.AddWithValue("@UIAABN", RadioButtonListUIAABN.SelectedValue);
                cmd.Parameters.AddWithValue("@UIACS", RadioButtonListUIACS.SelectedValue);

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
        if (!string.IsNullOrEmpty(TextBoxUISNO.Text) || !string.IsNullOrEmpty(TextBoxUIADT.Text) || !string.IsNullOrEmpty(TextBoxUIASS.Text) || !string.IsNullOrEmpty(TextBoxUIARSLT.Text) || !string.IsNullOrEmpty(TextBoxUIAUT.Text) || !string.IsNullOrEmpty(TextBoxUIARSN.Text) || !string.IsNullOrEmpty(RadioButtonListUIAABN.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListUIACS.SelectedValue))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString().Trim() != TextBoxUISNO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUISNO.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = TextBoxUISNO.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString().Trim() != TextBoxUIADT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUIADT.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxUIADT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString().Trim() != TextBoxUIASS.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUIASS.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxUIASS.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString().Trim() != TextBoxUIARSLT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUIARSLT.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxUIARSLT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString().Trim() != TextBoxUIAUT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUIAUT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxUIAUT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString().Trim() != TextBoxUIARSN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUIARSN.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxUIARSN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString().Trim() != RadioButtonListUIAABN.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUIAABN.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListUIAABN.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString().Trim() != RadioButtonListUIACS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUIACS.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListUIACS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Add].[sp_UnscheduledInvestigationsAssessments]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@UISNO", TextBoxUISNO.Text);
            cmd.Parameters.AddWithValue("@UIADT", TextBoxUIADT.Text);
            cmd.Parameters.AddWithValue("@UIASS", TextBoxUIASS.Text);
            cmd.Parameters.AddWithValue("@UIARSLT", TextBoxUIARSLT.Text);
            cmd.Parameters.AddWithValue("@UIAUT", TextBoxUIAUT.Text);
            cmd.Parameters.AddWithValue("@UIARSN", TextBoxUIARSN.Text);
            cmd.Parameters.AddWithValue("@UIAABN", RadioButtonListUIAABN.SelectedValue);
            cmd.Parameters.AddWithValue("@UIACS", RadioButtonListUIACS.SelectedValue);

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
            cmd.CommandText = "INSERT INTO tblReasonForChange (Site, SubId, Subini, QuestionText, OldValue, NewValue, Reason, PageName, EUser,SNO) VALUES    (@Site, @SubId, @Subini, @QuestionText, @OldValue, @NewValue, @Reason, @PageName, @EUser,@SNO)";
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
            cmd.Parameters.AddWithValue("@SNO", TextBoxUISNO.Text);

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


    #region QueryUISNO
    private void SetImageQueryUISNO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUISNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUISNO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUISNO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUISNO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUISNO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUISNO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUISNO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUISNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUISNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUISNO.Visible = true;
                PanelRaiseUISNO2.Visible = false;
                PanelRaiseUISNO3.Visible = false;
                PanelHideUISNO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUISNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUISNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUISNO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUISNO.Visible = true;
                PanelRaiseUISNO2.Visible = true;
                PanelRaiseUISNO3.Visible = true;
                PanelHideUISNO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUISNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUISNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUISNO.Visible = true;
                PanelRaiseUISNO2.Visible = true;
                PanelRaiseUISNO3.Visible = false;
                PanelHideUISNO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUISNO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UISNO = '" + TextBoxUISNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUISNO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUISNO.Visible = true;
                RAISEUISNO.ShowPopupWindow();
                QueryRaiseUISNO.Visible = false;
                TextBoxRaiseUISNO.Visible = false;
                PanelRaiseUISNO.Visible = false;
                PanelRaiseUISNO2.Visible = false;
                PanelRaiseUISNO3.Visible = false;

                LabelRespondUISNO.Visible = false;
            }

            else if ((ImageQueryUISNO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUISNO.Visible = true;
                RAISEUISNO.ShowPopupWindow();
                QueryRaiseUISNO.Visible = true;
                TextBoxRaiseUISNO.Visible = true;
                PanelRaiseUISNO.Visible = true;
                PanelRaiseUISNO2.Visible = false;
                PanelRaiseUISNO3.Visible = false;
                LabelRespondUISNO.Visible = true;
            }

            else if ((ImageQueryUISNO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUISNO.Visible = true;
                RAISEUISNO.ShowPopupWindow();
                QueryRaiseUISNO.Visible = false;
                TextBoxRaiseUISNO.Visible = false;
                PanelRaiseUISNO.Visible = true;
                PanelRaiseUISNO2.Visible = true;
                PanelRaiseUISNO3.Visible = false;
                LabelRespondUISNO.Visible = false;
            }
            else if ((ImageQueryUISNO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUISNO.Visible = true;
                RAISEUISNO.ShowPopupWindow();
                QueryRaiseUISNO.Visible = false;
                TextBoxRaiseUISNO.Visible = false;
                PanelRaiseUISNO.Visible = true;
                PanelRaiseUISNO2.Visible = true;
                PanelRaiseUISNO3.Visible = true;
                LabelRespondUISNO.Visible = false;
            }
            else
            {
                RAISEUISNO.Visible = true;
                RAISEUISNO.ShowPopupWindow();
                QueryRaiseUISNO.Visible = false;
                TextBoxRaiseUISNO.Visible = false;
                PanelRaiseUISNO.Visible = true;
                PanelRaiseUISNO2.Visible = true;
                PanelRaiseUISNO3.Visible = true;
                LabelRespondUISNO.Visible = false;

            }
        }

    }
    protected void QueryRaiseUISNO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUISNO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUISNO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UISNO = '" + TextBoxUISNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUISNOMSG.ShowPopupWindow();
        RAISEUISNO.Visible = false;


    }
    #endregion
    #region QueryUIADT
    private void SetImageQueryUIADT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIADT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUIADT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUIADT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUIADT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUIADT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUIADT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUIADT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIADT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUIADT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUIADT.Visible = true;
                PanelRaiseUIADT2.Visible = false;
                PanelRaiseUIADT3.Visible = false;
                PanelHideUIADT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUIADT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIADT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUIADT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUIADT.Visible = true;
                PanelRaiseUIADT2.Visible = true;
                PanelRaiseUIADT3.Visible = true;
                PanelHideUIADT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUIADT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIADT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUIADT.Visible = true;
                PanelRaiseUIADT2.Visible = true;
                PanelRaiseUIADT3.Visible = false;
                PanelHideUIADT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUIADT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and UIADT = '" + TextBoxUIADT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUIADT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUIADT.Visible = true;
                RAISEUIADT.ShowPopupWindow();
                QueryRaiseUIADT.Visible = false;
                TextBoxRaiseUIADT.Visible = false;
                PanelRaiseUIADT.Visible = false;
                PanelRaiseUIADT2.Visible = false;
                PanelRaiseUIADT3.Visible = false;

                LabelRespondUIADT.Visible = false;
            }

            else if ((ImageQueryUIADT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIADT.Visible = true;
                RAISEUIADT.ShowPopupWindow();
                QueryRaiseUIADT.Visible = true;
                TextBoxRaiseUIADT.Visible = true;
                PanelRaiseUIADT.Visible = true;
                PanelRaiseUIADT2.Visible = false;
                PanelRaiseUIADT3.Visible = false;
                LabelRespondUIADT.Visible = true;
            }

            else if ((ImageQueryUIADT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIADT.Visible = true;
                RAISEUIADT.ShowPopupWindow();
                QueryRaiseUIADT.Visible = false;
                TextBoxRaiseUIADT.Visible = false;
                PanelRaiseUIADT.Visible = true;
                PanelRaiseUIADT2.Visible = true;
                PanelRaiseUIADT3.Visible = false;
                LabelRespondUIADT.Visible = false;
            }
            else if ((ImageQueryUIADT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIADT.Visible = true;
                RAISEUIADT.ShowPopupWindow();
                QueryRaiseUIADT.Visible = false;
                TextBoxRaiseUIADT.Visible = false;
                PanelRaiseUIADT.Visible = true;
                PanelRaiseUIADT2.Visible = true;
                PanelRaiseUIADT3.Visible = true;
                LabelRespondUIADT.Visible = false;
            }
            else
            {
                RAISEUIADT.Visible = true;
                RAISEUIADT.ShowPopupWindow();
                QueryRaiseUIADT.Visible = false;
                TextBoxRaiseUIADT.Visible = false;
                PanelRaiseUIADT.Visible = true;
                PanelRaiseUIADT2.Visible = true;
                PanelRaiseUIADT3.Visible = true;
                LabelRespondUIADT.Visible = false;

            }
        }

    }
    protected void QueryRaiseUIADT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUIADT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIADT.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Field = '" + lblUIADT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UIADT = '" + TextBoxUIADT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUIADTMSG.ShowPopupWindow();
        RAISEUIADT.Visible = false;


    }
    #endregion
    #region QueryUIASS
    private void SetImageQueryUIASS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIASS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUIASS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUIASS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUIASS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUIASS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUIASS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUIASS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIASS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUIASS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUIASS.Visible = true;
                PanelRaiseUIASS2.Visible = false;
                PanelRaiseUIASS3.Visible = false;
                PanelHideUIASS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUIASS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIASS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUIASS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUIASS.Visible = true;
                PanelRaiseUIASS2.Visible = true;
                PanelRaiseUIASS3.Visible = true;
                PanelHideUIASS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUIASS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIASS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUIASS.Visible = true;
                PanelRaiseUIASS2.Visible = true;
                PanelRaiseUIASS3.Visible = false;
                PanelHideUIASS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUIASS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and UIASS = '" + TextBoxUIASS.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUIASS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUIASS.Visible = true;
                RAISEUIASS.ShowPopupWindow();
                QueryRaiseUIASS.Visible = false;
                TextBoxRaiseUIASS.Visible = false;
                PanelRaiseUIASS.Visible = false;
                PanelRaiseUIASS2.Visible = false;
                PanelRaiseUIASS3.Visible = false;

                LabelRespondUIASS.Visible = false;
            }

            else if ((ImageQueryUIASS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIASS.Visible = true;
                RAISEUIASS.ShowPopupWindow();
                QueryRaiseUIASS.Visible = true;
                TextBoxRaiseUIASS.Visible = true;
                PanelRaiseUIASS.Visible = true;
                PanelRaiseUIASS2.Visible = false;
                PanelRaiseUIASS3.Visible = false;
                LabelRespondUIASS.Visible = true;
            }

            else if ((ImageQueryUIASS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIASS.Visible = true;
                RAISEUIASS.ShowPopupWindow();
                QueryRaiseUIASS.Visible = false;
                TextBoxRaiseUIASS.Visible = false;
                PanelRaiseUIASS.Visible = true;
                PanelRaiseUIASS2.Visible = true;
                PanelRaiseUIASS3.Visible = false;
                LabelRespondUIASS.Visible = false;
            }
            else if ((ImageQueryUIASS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIASS.Visible = true;
                RAISEUIASS.ShowPopupWindow();
                QueryRaiseUIASS.Visible = false;
                TextBoxRaiseUIASS.Visible = false;
                PanelRaiseUIASS.Visible = true;
                PanelRaiseUIASS2.Visible = true;
                PanelRaiseUIASS3.Visible = true;
                LabelRespondUIASS.Visible = false;
            }
            else
            {
                RAISEUIASS.Visible = true;
                RAISEUIASS.ShowPopupWindow();
                QueryRaiseUIASS.Visible = false;
                TextBoxRaiseUIASS.Visible = false;
                PanelRaiseUIASS.Visible = true;
                PanelRaiseUIASS2.Visible = true;
                PanelRaiseUIASS3.Visible = true;
                LabelRespondUIASS.Visible = false;

            }
        }

    }
    protected void QueryRaiseUIASS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUIASS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIASS.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Field = '" + lblUIASS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UIASS = '" + TextBoxUIASS.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUIASSMSG.ShowPopupWindow();
        RAISEUIASS.Visible = false;


    }
    #endregion
    #region QueryUIARSLT
    private void SetImageQueryUIARSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIARSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUIARSLT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUIARSLT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUIARSLT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUIARSLT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUIARSLT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUIARSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIARSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUIARSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT2.Visible = false;
                PanelRaiseUIARSLT3.Visible = false;
                PanelHideUIARSLT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUIARSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIARSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUIARSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT2.Visible = true;
                PanelRaiseUIARSLT3.Visible = true;
                PanelHideUIARSLT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUIARSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIARSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT2.Visible = true;
                PanelRaiseUIARSLT3.Visible = false;
                PanelHideUIARSLT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUIARSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and UIARSLT = '" + TextBoxUIARSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUIARSLT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUIARSLT.Visible = true;
                RAISEUIARSLT.ShowPopupWindow();
                QueryRaiseUIARSLT.Visible = false;
                TextBoxRaiseUIARSLT.Visible = false;
                PanelRaiseUIARSLT.Visible = false;
                PanelRaiseUIARSLT2.Visible = false;
                PanelRaiseUIARSLT3.Visible = false;

                LabelRespondUIARSLT.Visible = false;
            }

            else if ((ImageQueryUIARSLT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIARSLT.Visible = true;
                RAISEUIARSLT.ShowPopupWindow();
                QueryRaiseUIARSLT.Visible = true;
                TextBoxRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT2.Visible = false;
                PanelRaiseUIARSLT3.Visible = false;
                LabelRespondUIARSLT.Visible = true;
            }

            else if ((ImageQueryUIARSLT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIARSLT.Visible = true;
                RAISEUIARSLT.ShowPopupWindow();
                QueryRaiseUIARSLT.Visible = false;
                TextBoxRaiseUIARSLT.Visible = false;
                PanelRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT2.Visible = true;
                PanelRaiseUIARSLT3.Visible = false;
                LabelRespondUIARSLT.Visible = false;
            }
            else if ((ImageQueryUIARSLT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIARSLT.Visible = true;
                RAISEUIARSLT.ShowPopupWindow();
                QueryRaiseUIARSLT.Visible = false;
                TextBoxRaiseUIARSLT.Visible = false;
                PanelRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT2.Visible = true;
                PanelRaiseUIARSLT3.Visible = true;
                LabelRespondUIARSLT.Visible = false;
            }
            else
            {
                RAISEUIARSLT.Visible = true;
                RAISEUIARSLT.ShowPopupWindow();
                QueryRaiseUIARSLT.Visible = false;
                TextBoxRaiseUIARSLT.Visible = false;
                PanelRaiseUIARSLT.Visible = true;
                PanelRaiseUIARSLT2.Visible = true;
                PanelRaiseUIARSLT3.Visible = true;
                LabelRespondUIARSLT.Visible = false;

            }
        }

    }
    protected void QueryRaiseUIARSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUIARSLT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIARSLT.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Field = '" + lblUIARSLT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UIARSLT = '" + TextBoxUIARSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUIARSLTMSG.ShowPopupWindow();
        RAISEUIARSLT.Visible = false;


    }
    #endregion
    #region QueryUIAUT
    private void SetImageQueryUIAUT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIAUT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUIAUT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUIAUT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUIAUT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUIAUT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUIAUT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUIAUT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIAUT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUIAUT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT2.Visible = false;
                PanelRaiseUIAUT3.Visible = false;
                PanelHideUIAUT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUIAUT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIAUT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUIAUT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT2.Visible = true;
                PanelRaiseUIAUT3.Visible = true;
                PanelHideUIAUT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUIAUT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIAUT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT2.Visible = true;
                PanelRaiseUIAUT3.Visible = false;
                PanelHideUIAUT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUIAUT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and UIAUT = '" + TextBoxUIAUT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUIAUT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUIAUT.Visible = true;
                RAISEUIAUT.ShowPopupWindow();
                QueryRaiseUIAUT.Visible = false;
                TextBoxRaiseUIAUT.Visible = false;
                PanelRaiseUIAUT.Visible = false;
                PanelRaiseUIAUT2.Visible = false;
                PanelRaiseUIAUT3.Visible = false;

                LabelRespondUIAUT.Visible = false;
            }

            else if ((ImageQueryUIAUT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIAUT.Visible = true;
                RAISEUIAUT.ShowPopupWindow();
                QueryRaiseUIAUT.Visible = true;
                TextBoxRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT2.Visible = false;
                PanelRaiseUIAUT3.Visible = false;
                LabelRespondUIAUT.Visible = true;
            }

            else if ((ImageQueryUIAUT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIAUT.Visible = true;
                RAISEUIAUT.ShowPopupWindow();
                QueryRaiseUIAUT.Visible = false;
                TextBoxRaiseUIAUT.Visible = false;
                PanelRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT2.Visible = true;
                PanelRaiseUIAUT3.Visible = false;
                LabelRespondUIAUT.Visible = false;
            }
            else if ((ImageQueryUIAUT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIAUT.Visible = true;
                RAISEUIAUT.ShowPopupWindow();
                QueryRaiseUIAUT.Visible = false;
                TextBoxRaiseUIAUT.Visible = false;
                PanelRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT2.Visible = true;
                PanelRaiseUIAUT3.Visible = true;
                LabelRespondUIAUT.Visible = false;
            }
            else
            {
                RAISEUIAUT.Visible = true;
                RAISEUIAUT.ShowPopupWindow();
                QueryRaiseUIAUT.Visible = false;
                TextBoxRaiseUIAUT.Visible = false;
                PanelRaiseUIAUT.Visible = true;
                PanelRaiseUIAUT2.Visible = true;
                PanelRaiseUIAUT3.Visible = true;
                LabelRespondUIAUT.Visible = false;

            }
        }

    }
    protected void QueryRaiseUIAUT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUIAUT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIAUT.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Field = '" + lblUIAUT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UIAUT = '" + TextBoxUIAUT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUIAUTMSG.ShowPopupWindow();
        RAISEUIAUT.Visible = false;


    }
    #endregion
    #region QueryUIARSN
    private void SetImageQueryUIARSN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIARSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUIARSN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUIARSN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUIARSN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUIARSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUIARSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUIARSN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIARSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUIARSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN2.Visible = false;
                PanelRaiseUIARSN3.Visible = false;
                PanelHideUIARSN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUIARSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIARSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUIARSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN2.Visible = true;
                PanelRaiseUIARSN3.Visible = true;
                PanelHideUIARSN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUIARSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIARSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN2.Visible = true;
                PanelRaiseUIARSN3.Visible = false;
                PanelHideUIARSN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUIARSN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and UIARSN = '" + TextBoxUIARSN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUIARSN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUIARSN.Visible = true;
                RAISEUIARSN.ShowPopupWindow();
                QueryRaiseUIARSN.Visible = false;
                TextBoxRaiseUIARSN.Visible = false;
                PanelRaiseUIARSN.Visible = false;
                PanelRaiseUIARSN2.Visible = false;
                PanelRaiseUIARSN3.Visible = false;

                LabelRespondUIARSN.Visible = false;
            }

            else if ((ImageQueryUIARSN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIARSN.Visible = true;
                RAISEUIARSN.ShowPopupWindow();
                QueryRaiseUIARSN.Visible = true;
                TextBoxRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN2.Visible = false;
                PanelRaiseUIARSN3.Visible = false;
                LabelRespondUIARSN.Visible = true;
            }

            else if ((ImageQueryUIARSN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIARSN.Visible = true;
                RAISEUIARSN.ShowPopupWindow();
                QueryRaiseUIARSN.Visible = false;
                TextBoxRaiseUIARSN.Visible = false;
                PanelRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN2.Visible = true;
                PanelRaiseUIARSN3.Visible = false;
                LabelRespondUIARSN.Visible = false;
            }
            else if ((ImageQueryUIARSN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIARSN.Visible = true;
                RAISEUIARSN.ShowPopupWindow();
                QueryRaiseUIARSN.Visible = false;
                TextBoxRaiseUIARSN.Visible = false;
                PanelRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN2.Visible = true;
                PanelRaiseUIARSN3.Visible = true;
                LabelRespondUIARSN.Visible = false;
            }
            else
            {
                RAISEUIARSN.Visible = true;
                RAISEUIARSN.ShowPopupWindow();
                QueryRaiseUIARSN.Visible = false;
                TextBoxRaiseUIARSN.Visible = false;
                PanelRaiseUIARSN.Visible = true;
                PanelRaiseUIARSN2.Visible = true;
                PanelRaiseUIARSN3.Visible = true;
                LabelRespondUIARSN.Visible = false;

            }
        }

    }
    protected void QueryRaiseUIARSN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUIARSN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIARSN.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Field = '" + lblUIARSN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UIARSN = '" + TextBoxUIARSN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUIARSNMSG.ShowPopupWindow();
        RAISEUIARSN.Visible = false;


    }
    #endregion
    #region QueryUIAABN
    private void SetImageQueryUIAABN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIAABN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUIAABN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUIAABN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUIAABN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUIAABN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUIAABN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUIAABN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIAABN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUIAABN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN2.Visible = false;
                PanelRaiseUIAABN3.Visible = false;
                PanelHideUIAABN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUIAABN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIAABN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUIAABN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN2.Visible = true;
                PanelRaiseUIAABN3.Visible = true;
                PanelHideUIAABN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUIAABN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIAABN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN2.Visible = true;
                PanelRaiseUIAABN3.Visible = false;
                PanelHideUIAABN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUIAABN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and UIAABN = '" + RadioButtonListUIAABN.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUIAABN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUIAABN.Visible = true;
                RAISEUIAABN.ShowPopupWindow();
                QueryRaiseUIAABN.Visible = false;
                TextBoxRaiseUIAABN.Visible = false;
                PanelRaiseUIAABN.Visible = false;
                PanelRaiseUIAABN2.Visible = false;
                PanelRaiseUIAABN3.Visible = false;

                LabelRespondUIAABN.Visible = false;
            }

            else if ((ImageQueryUIAABN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIAABN.Visible = true;
                RAISEUIAABN.ShowPopupWindow();
                QueryRaiseUIAABN.Visible = true;
                TextBoxRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN2.Visible = false;
                PanelRaiseUIAABN3.Visible = false;
                LabelRespondUIAABN.Visible = true;
            }

            else if ((ImageQueryUIAABN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIAABN.Visible = true;
                RAISEUIAABN.ShowPopupWindow();
                QueryRaiseUIAABN.Visible = false;
                TextBoxRaiseUIAABN.Visible = false;
                PanelRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN2.Visible = true;
                PanelRaiseUIAABN3.Visible = false;
                LabelRespondUIAABN.Visible = false;
            }
            else if ((ImageQueryUIAABN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIAABN.Visible = true;
                RAISEUIAABN.ShowPopupWindow();
                QueryRaiseUIAABN.Visible = false;
                TextBoxRaiseUIAABN.Visible = false;
                PanelRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN2.Visible = true;
                PanelRaiseUIAABN3.Visible = true;
                LabelRespondUIAABN.Visible = false;
            }
            else
            {
                RAISEUIAABN.Visible = true;
                RAISEUIAABN.ShowPopupWindow();
                QueryRaiseUIAABN.Visible = false;
                TextBoxRaiseUIAABN.Visible = false;
                PanelRaiseUIAABN.Visible = true;
                PanelRaiseUIAABN2.Visible = true;
                PanelRaiseUIAABN3.Visible = true;
                LabelRespondUIAABN.Visible = false;

            }
        }

    }
    protected void QueryRaiseUIAABN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUIAABN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIAABN.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Field = '" + lblUIAABN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UIAABN = '" + RadioButtonListUIAABN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUIAABNMSG.ShowPopupWindow();
        RAISEUIAABN.Visible = false;


    }
    #endregion
    #region QueryUIACS
    private void SetImageQueryUIACS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIACS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryUIACS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryUIACS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryUIACS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryUIACS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryUIACS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataUIACS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIACS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseUIACS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseUIACS.Visible = true;
                PanelRaiseUIACS2.Visible = false;
                PanelRaiseUIACS3.Visible = false;
                PanelHideUIACS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseUIACS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIACS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseUIACS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseUIACS.Visible = true;
                PanelRaiseUIACS2.Visible = true;
                PanelRaiseUIACS3.Visible = true;
                PanelHideUIACS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseUIACS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseUIACS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseUIACS.Visible = true;
                PanelRaiseUIACS2.Visible = true;
                PanelRaiseUIACS3.Visible = false;
                PanelHideUIACS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryUIACS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[UnscheduledInvestigationsAssessments] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and UIACS = '" + RadioButtonListUIACS.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryUIACS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEUIACS.Visible = true;
                RAISEUIACS.ShowPopupWindow();
                QueryRaiseUIACS.Visible = false;
                TextBoxRaiseUIACS.Visible = false;
                PanelRaiseUIACS.Visible = false;
                PanelRaiseUIACS2.Visible = false;
                PanelRaiseUIACS3.Visible = false;

                LabelRespondUIACS.Visible = false;
            }

            else if ((ImageQueryUIACS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIACS.Visible = true;
                RAISEUIACS.ShowPopupWindow();
                QueryRaiseUIACS.Visible = true;
                TextBoxRaiseUIACS.Visible = true;
                PanelRaiseUIACS.Visible = true;
                PanelRaiseUIACS2.Visible = false;
                PanelRaiseUIACS3.Visible = false;
                LabelRespondUIACS.Visible = true;
            }

            else if ((ImageQueryUIACS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIACS.Visible = true;
                RAISEUIACS.ShowPopupWindow();
                QueryRaiseUIACS.Visible = false;
                TextBoxRaiseUIACS.Visible = false;
                PanelRaiseUIACS.Visible = true;
                PanelRaiseUIACS2.Visible = true;
                PanelRaiseUIACS3.Visible = false;
                LabelRespondUIACS.Visible = false;
            }
            else if ((ImageQueryUIACS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEUIACS.Visible = true;
                RAISEUIACS.ShowPopupWindow();
                QueryRaiseUIACS.Visible = false;
                TextBoxRaiseUIACS.Visible = false;
                PanelRaiseUIACS.Visible = true;
                PanelRaiseUIACS2.Visible = true;
                PanelRaiseUIACS3.Visible = true;
                LabelRespondUIACS.Visible = false;
            }
            else
            {
                RAISEUIACS.Visible = true;
                RAISEUIACS.ShowPopupWindow();
                QueryRaiseUIACS.Visible = false;
                TextBoxRaiseUIACS.Visible = false;
                PanelRaiseUIACS.Visible = true;
                PanelRaiseUIACS2.Visible = true;
                PanelRaiseUIACS3.Visible = true;
                LabelRespondUIACS.Visible = false;

            }
        }

    }
    protected void QueryRaiseUIACS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseUIACS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblUIACS.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxUISNO.Text + "' and Field = '" + lblUIACS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[UnscheduledInvestigationsAssessments] set QueryStatus = 'Query Responded' where SITENUM='" + lblCenterNumber.Text + "' and UISNO = '" + TextBoxUISNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and UIACS = '" + RadioButtonListUIACS.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEUIACSMSG.ShowPopupWindow();
        RAISEUIACS.Visible = false;


    }
    #endregion
    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void RadioButtonListUIAABN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListUIAABN.SelectedValue == "Abnormal")
        {
            hideUIACS.Visible = true;
        }
        else
        {
            hideUIACS.Visible = false;
            RadioButtonListUIACS.ClearSelection();
        }
    }
}