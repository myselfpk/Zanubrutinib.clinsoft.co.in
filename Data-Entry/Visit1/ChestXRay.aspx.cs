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

public partial class Data_Entry_Visit1_ChestXRay : System.Web.UI.Page
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

        SetImageQueryXRAYPER();
        SetImageQueryXRAYRSN();
        SetImageQueryXRAYDT();
        SetImageQueryXRAYTM();
        SetImageQueryXRAYNAB();
        SetImageQueryXRAYCMNT();

        BindQueryDataXRAYPER();
        BindQueryDataXRAYRSN();
        BindQueryDataXRAYDT();
        BindQueryDataXRAYTM();
        BindQueryDataXRAYNAB();
        BindQueryDataXRAYCMNT();

        ShowHide();

        TextBoxXRAYDT_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select XRAYPER , XRAYRSN , XRAYDT , XRAYTM , XRAYNAB , XRAYCMNT from [Visit1].[ChestXRay] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListXRAYPER.SelectedValue = dt.Rows[0]["XRAYPER"].ToString().Trim();
            TextBoxXRAYRSN.Text = dt.Rows[0]["XRAYRSN"].ToString().Trim();
            TextBoxXRAYDT.Text = dt.Rows[0]["XRAYDT"].ToString().Trim();
            TextBoxXRAYTM.Text = dt.Rows[0]["XRAYTM"].ToString().Trim();
            RadioButtonListXRAYNAB.SelectedValue = dt.Rows[0]["XRAYNAB"].ToString().Trim();
            TextBoxXRAYCMNT.Text = dt.Rows[0]["XRAYCMNT"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListXRAYPER.SelectedValue;
            ViewState["txt2"] = TextBoxXRAYRSN.Text;
            ViewState["txt3"] = TextBoxXRAYDT.Text;
            ViewState["txt4"] = TextBoxXRAYTM.Text;
            ViewState["txt5"] = RadioButtonListXRAYNAB.SelectedValue;
            ViewState["txt6"] = TextBoxXRAYCMNT.Text;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[ChestXRay] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[ChestXRay] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_ChestXRay]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                    cmd.Parameters.AddWithValue("@XRAYPER", RadioButtonListXRAYPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@XRAYRSN", TextBoxXRAYRSN.Text);
                    cmd.Parameters.AddWithValue("@XRAYDT", TextBoxXRAYDT.Text);
                    cmd.Parameters.AddWithValue("@XRAYTM", TextBoxXRAYTM.Text);
                    cmd.Parameters.AddWithValue("@XRAYNAB", RadioButtonListXRAYNAB.SelectedValue);
                    cmd.Parameters.AddWithValue("@XRAYCMNT", TextBoxXRAYCMNT.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[ChestXRay] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListXRAYPER.SelectedValue || ViewState["txt2"].ToString() != TextBoxXRAYRSN.Text || ViewState["txt3"].ToString() != TextBoxXRAYDT.Text || ViewState["txt4"].ToString() != TextBoxXRAYTM.Text || ViewState["txt5"].ToString() != RadioButtonListXRAYNAB.SelectedValue || ViewState["txt6"].ToString() != TextBoxXRAYCMNT.Text)
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
                cmd = new SqlCommand("[Visit1].[sp_ChestXRay]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@XRAYPER", RadioButtonListXRAYPER.SelectedValue);
                cmd.Parameters.AddWithValue("@XRAYRSN", TextBoxXRAYRSN.Text);
                cmd.Parameters.AddWithValue("@XRAYDT", TextBoxXRAYDT.Text);
                cmd.Parameters.AddWithValue("@XRAYTM", TextBoxXRAYTM.Text);
                cmd.Parameters.AddWithValue("@XRAYNAB", RadioButtonListXRAYNAB.SelectedValue);
                cmd.Parameters.AddWithValue("@XRAYCMNT", TextBoxXRAYCMNT.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[ChestXRay] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_ChestXRay]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@XRAYPER", RadioButtonListXRAYPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@XRAYRSN", TextBoxXRAYRSN.Text);
                    cmd.Parameters.AddWithValue("@XRAYDT", TextBoxXRAYDT.Text);
                    cmd.Parameters.AddWithValue("@XRAYTM", TextBoxXRAYTM.Text);
                    cmd.Parameters.AddWithValue("@XRAYNAB", RadioButtonListXRAYNAB.SelectedValue);
                    cmd.Parameters.AddWithValue("@XRAYCMNT", TextBoxXRAYCMNT.Text);

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
                cmd = new SqlCommand("[Visit1].[sp_ChestXRay]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@XRAYPER", RadioButtonListXRAYPER.SelectedValue);
                cmd.Parameters.AddWithValue("@XRAYRSN", TextBoxXRAYRSN.Text);
                cmd.Parameters.AddWithValue("@XRAYDT", TextBoxXRAYDT.Text);
                cmd.Parameters.AddWithValue("@XRAYTM", TextBoxXRAYTM.Text);
                cmd.Parameters.AddWithValue("@XRAYNAB", RadioButtonListXRAYNAB.SelectedValue);
                cmd.Parameters.AddWithValue("@XRAYCMNT", TextBoxXRAYCMNT.Text);

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
        if (!string.IsNullOrEmpty(RadioButtonListXRAYPER.SelectedValue) || !string.IsNullOrEmpty(TextBoxXRAYRSN.Text) || !string.IsNullOrEmpty(TextBoxXRAYDT.Text) || !string.IsNullOrEmpty(TextBoxXRAYTM.Text) || !string.IsNullOrEmpty(RadioButtonListXRAYNAB.SelectedValue) || !string.IsNullOrEmpty(TextBoxXRAYCMNT.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListXRAYPER.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblXRAYPER.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListXRAYPER.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() != TextBoxXRAYRSN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblXRAYRSN.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxXRAYRSN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() != TextBoxXRAYDT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblXRAYDT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxXRAYDT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() != TextBoxXRAYTM.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblXRAYTM.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxXRAYTM.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() != RadioButtonListXRAYNAB.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblXRAYNAB.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListXRAYNAB.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() != TextBoxXRAYCMNT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblXRAYCMNT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxXRAYCMNT.Text;
                dtEmp.Rows.Add(dtrow);
            }
          
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_ChestXRay]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@XRAYPER", RadioButtonListXRAYPER.SelectedValue);
            cmd.Parameters.AddWithValue("@XRAYRSN", TextBoxXRAYRSN.Text);
            cmd.Parameters.AddWithValue("@XRAYDT", TextBoxXRAYDT.Text);
            cmd.Parameters.AddWithValue("@XRAYTM", TextBoxXRAYTM.Text);
            cmd.Parameters.AddWithValue("@XRAYNAB", RadioButtonListXRAYNAB.SelectedValue);
            cmd.Parameters.AddWithValue("@XRAYCMNT", TextBoxXRAYCMNT.Text);

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
    #region QueryXRAYPER
    private void SetImageQueryXRAYPER()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryXRAYPER.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryXRAYPER.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryXRAYPER.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryXRAYPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryXRAYPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataXRAYPER()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseXRAYPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER2.Visible = false;
                PanelRaiseXRAYPER3.Visible = false;
                PanelHideXRAYPER.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseXRAYPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseXRAYPER3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER2.Visible = true;
                PanelRaiseXRAYPER3.Visible = true;
                PanelHideXRAYPER.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseXRAYPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER2.Visible = true;
                PanelRaiseXRAYPER3.Visible = false;
                PanelHideXRAYPER.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryXRAYPER_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ChestXRay] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYPER = '" + RadioButtonListXRAYPER.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryXRAYPER.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEXRAYPER.Visible = true;
                RAISEXRAYPER.ShowPopupWindow();
                QueryRaiseXRAYPER.Visible = false;
                TextBoxRaiseXRAYPER.Visible = false;
                PanelRaiseXRAYPER.Visible = false;
                PanelRaiseXRAYPER2.Visible = false;
                PanelRaiseXRAYPER3.Visible = false;

                LabelRespondXRAYPER.Visible = false;
            }

            else if ((ImageQueryXRAYPER.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYPER.Visible = true;
                RAISEXRAYPER.ShowPopupWindow();
                QueryRaiseXRAYPER.Visible = true;
                TextBoxRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER2.Visible = false;
                PanelRaiseXRAYPER3.Visible = false;
                LabelRespondXRAYPER.Visible = true;
            }

            else if ((ImageQueryXRAYPER.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYPER.Visible = true;
                RAISEXRAYPER.ShowPopupWindow();
                QueryRaiseXRAYPER.Visible = false;
                TextBoxRaiseXRAYPER.Visible = false;
                PanelRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER2.Visible = true;
                PanelRaiseXRAYPER3.Visible = false;
                LabelRespondXRAYPER.Visible = false;
            }
            else if ((ImageQueryXRAYPER.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYPER.Visible = true;
                RAISEXRAYPER.ShowPopupWindow();
                QueryRaiseXRAYPER.Visible = false;
                TextBoxRaiseXRAYPER.Visible = false;
                PanelRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER2.Visible = true;
                PanelRaiseXRAYPER3.Visible = true;
                LabelRespondXRAYPER.Visible = false;
            }
            else
            {
                RAISEXRAYPER.Visible = true;
                RAISEXRAYPER.ShowPopupWindow();
                QueryRaiseXRAYPER.Visible = false;
                TextBoxRaiseXRAYPER.Visible = false;
                PanelRaiseXRAYPER.Visible = true;
                PanelRaiseXRAYPER2.Visible = true;
                PanelRaiseXRAYPER3.Visible = true;
                LabelRespondXRAYPER.Visible = false;

            }
        }

    }
    protected void QueryRaiseXRAYPER_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseXRAYPER.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYPER.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYPER.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ChestXRay] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYPER = '" + RadioButtonListXRAYPER.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEXRAYPERMSG.ShowPopupWindow();
        RAISEXRAYPER.Visible = false;


    }
    #endregion
    #region QueryXRAYNAB
    private void SetImageQueryXRAYNAB()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYNAB.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryXRAYNAB.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryXRAYNAB.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryXRAYNAB.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryXRAYNAB.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryXRAYNAB.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataXRAYNAB()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYNAB.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseXRAYNAB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB2.Visible = false;
                PanelRaiseXRAYNAB3.Visible = false;
                PanelHideXRAYNAB.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseXRAYNAB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYNAB2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseXRAYNAB3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB2.Visible = true;
                PanelRaiseXRAYNAB3.Visible = true;
                PanelHideXRAYNAB.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseXRAYNAB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYNAB2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB2.Visible = true;
                PanelRaiseXRAYNAB3.Visible = false;
                PanelHideXRAYNAB.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryXRAYNAB_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ChestXRay] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYNAB = '" + RadioButtonListXRAYNAB.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryXRAYNAB.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEXRAYNAB.Visible = true;
                RAISEXRAYNAB.ShowPopupWindow();
                QueryRaiseXRAYNAB.Visible = false;
                TextBoxRaiseXRAYNAB.Visible = false;
                PanelRaiseXRAYNAB.Visible = false;
                PanelRaiseXRAYNAB2.Visible = false;
                PanelRaiseXRAYNAB3.Visible = false;

                LabelRespondXRAYNAB.Visible = false;
            }

            else if ((ImageQueryXRAYNAB.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYNAB.Visible = true;
                RAISEXRAYNAB.ShowPopupWindow();
                QueryRaiseXRAYNAB.Visible = true;
                TextBoxRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB2.Visible = false;
                PanelRaiseXRAYNAB3.Visible = false;
                LabelRespondXRAYNAB.Visible = true;
            }

            else if ((ImageQueryXRAYNAB.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYNAB.Visible = true;
                RAISEXRAYNAB.ShowPopupWindow();
                QueryRaiseXRAYNAB.Visible = false;
                TextBoxRaiseXRAYNAB.Visible = false;
                PanelRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB2.Visible = true;
                PanelRaiseXRAYNAB3.Visible = false;
                LabelRespondXRAYNAB.Visible = false;
            }
            else if ((ImageQueryXRAYNAB.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYNAB.Visible = true;
                RAISEXRAYNAB.ShowPopupWindow();
                QueryRaiseXRAYNAB.Visible = false;
                TextBoxRaiseXRAYNAB.Visible = false;
                PanelRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB2.Visible = true;
                PanelRaiseXRAYNAB3.Visible = true;
                LabelRespondXRAYNAB.Visible = false;
            }
            else
            {
                RAISEXRAYNAB.Visible = true;
                RAISEXRAYNAB.ShowPopupWindow();
                QueryRaiseXRAYNAB.Visible = false;
                TextBoxRaiseXRAYNAB.Visible = false;
                PanelRaiseXRAYNAB.Visible = true;
                PanelRaiseXRAYNAB2.Visible = true;
                PanelRaiseXRAYNAB3.Visible = true;
                LabelRespondXRAYNAB.Visible = false;

            }
        }

    }
    protected void QueryRaiseXRAYNAB_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseXRAYNAB.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYNAB.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYNAB.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ChestXRay] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYNAB = '" + RadioButtonListXRAYNAB.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEXRAYNABMSG.ShowPopupWindow();
        RAISEXRAYNAB.Visible = false;


    }
    #endregion
    #region QueryXRAYRSN
    private void SetImageQueryXRAYRSN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryXRAYRSN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryXRAYRSN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryXRAYRSN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryXRAYRSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryXRAYRSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataXRAYRSN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseXRAYRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN2.Visible = false;
                PanelRaiseXRAYRSN3.Visible = false;
                PanelHideXRAYRSN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseXRAYRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseXRAYRSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN2.Visible = true;
                PanelRaiseXRAYRSN3.Visible = true;
                PanelHideXRAYRSN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseXRAYRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN2.Visible = true;
                PanelRaiseXRAYRSN3.Visible = false;
                PanelHideXRAYRSN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryXRAYRSN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ChestXRay] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYRSN = '" + TextBoxXRAYRSN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryXRAYRSN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEXRAYRSN.Visible = true;
                RAISEXRAYRSN.ShowPopupWindow();
                QueryRaiseXRAYRSN.Visible = false;
                TextBoxRaiseXRAYRSN.Visible = false;
                PanelRaiseXRAYRSN.Visible = false;
                PanelRaiseXRAYRSN2.Visible = false;
                PanelRaiseXRAYRSN3.Visible = false;

                LabelRespondXRAYRSN.Visible = false;
            }

            else if ((ImageQueryXRAYRSN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYRSN.Visible = true;
                RAISEXRAYRSN.ShowPopupWindow();
                QueryRaiseXRAYRSN.Visible = true;
                TextBoxRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN2.Visible = false;
                PanelRaiseXRAYRSN3.Visible = false;
                LabelRespondXRAYRSN.Visible = true;
            }

            else if ((ImageQueryXRAYRSN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYRSN.Visible = true;
                RAISEXRAYRSN.ShowPopupWindow();
                QueryRaiseXRAYRSN.Visible = false;
                TextBoxRaiseXRAYRSN.Visible = false;
                PanelRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN2.Visible = true;
                PanelRaiseXRAYRSN3.Visible = false;
                LabelRespondXRAYRSN.Visible = false;
            }
            else if ((ImageQueryXRAYRSN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYRSN.Visible = true;
                RAISEXRAYRSN.ShowPopupWindow();
                QueryRaiseXRAYRSN.Visible = false;
                TextBoxRaiseXRAYRSN.Visible = false;
                PanelRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN2.Visible = true;
                PanelRaiseXRAYRSN3.Visible = true;
                LabelRespondXRAYRSN.Visible = false;
            }
            else
            {
                RAISEXRAYRSN.Visible = true;
                RAISEXRAYRSN.ShowPopupWindow();
                QueryRaiseXRAYRSN.Visible = false;
                TextBoxRaiseXRAYRSN.Visible = false;
                PanelRaiseXRAYRSN.Visible = true;
                PanelRaiseXRAYRSN2.Visible = true;
                PanelRaiseXRAYRSN3.Visible = true;
                LabelRespondXRAYRSN.Visible = false;

            }
        }

    }
    protected void QueryRaiseXRAYRSN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseXRAYRSN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYRSN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYRSN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ChestXRay] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYRSN = '" + TextBoxXRAYRSN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEXRAYRSNMSG.ShowPopupWindow();
        RAISEXRAYRSN.Visible = false;


    }
    #endregion
    #region QueryXRAYDT
    private void SetImageQueryXRAYDT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryXRAYDT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryXRAYDT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryXRAYDT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryXRAYDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryXRAYDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataXRAYDT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseXRAYDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT2.Visible = false;
                PanelRaiseXRAYDT3.Visible = false;
                PanelHideXRAYDT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseXRAYDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseXRAYDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT2.Visible = true;
                PanelRaiseXRAYDT3.Visible = true;
                PanelHideXRAYDT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseXRAYDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT2.Visible = true;
                PanelRaiseXRAYDT3.Visible = false;
                PanelHideXRAYDT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryXRAYDT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ChestXRay] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYDT = '" + TextBoxXRAYDT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryXRAYDT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEXRAYDT.Visible = true;
                RAISEXRAYDT.ShowPopupWindow();
                QueryRaiseXRAYDT.Visible = false;
                TextBoxRaiseXRAYDT.Visible = false;
                PanelRaiseXRAYDT.Visible = false;
                PanelRaiseXRAYDT2.Visible = false;
                PanelRaiseXRAYDT3.Visible = false;

                LabelRespondXRAYDT.Visible = false;
            }

            else if ((ImageQueryXRAYDT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYDT.Visible = true;
                RAISEXRAYDT.ShowPopupWindow();
                QueryRaiseXRAYDT.Visible = true;
                TextBoxRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT2.Visible = false;
                PanelRaiseXRAYDT3.Visible = false;
                LabelRespondXRAYDT.Visible = true;
            }

            else if ((ImageQueryXRAYDT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYDT.Visible = true;
                RAISEXRAYDT.ShowPopupWindow();
                QueryRaiseXRAYDT.Visible = false;
                TextBoxRaiseXRAYDT.Visible = false;
                PanelRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT2.Visible = true;
                PanelRaiseXRAYDT3.Visible = false;
                LabelRespondXRAYDT.Visible = false;
            }
            else if ((ImageQueryXRAYDT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYDT.Visible = true;
                RAISEXRAYDT.ShowPopupWindow();
                QueryRaiseXRAYDT.Visible = false;
                TextBoxRaiseXRAYDT.Visible = false;
                PanelRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT2.Visible = true;
                PanelRaiseXRAYDT3.Visible = true;
                LabelRespondXRAYDT.Visible = false;
            }
            else
            {
                RAISEXRAYDT.Visible = true;
                RAISEXRAYDT.ShowPopupWindow();
                QueryRaiseXRAYDT.Visible = false;
                TextBoxRaiseXRAYDT.Visible = false;
                PanelRaiseXRAYDT.Visible = true;
                PanelRaiseXRAYDT2.Visible = true;
                PanelRaiseXRAYDT3.Visible = true;
                LabelRespondXRAYDT.Visible = false;

            }
        }

    }
    protected void QueryRaiseXRAYDT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseXRAYDT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYDT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYDT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ChestXRay] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYDT = '" + TextBoxXRAYDT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEXRAYDTMSG.ShowPopupWindow();
        RAISEXRAYDT.Visible = false;


    }
    #endregion
    #region QueryXRAYTM
    private void SetImageQueryXRAYTM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYTM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryXRAYTM.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryXRAYTM.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryXRAYTM.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryXRAYTM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryXRAYTM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataXRAYTM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYTM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseXRAYTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM2.Visible = false;
                PanelRaiseXRAYTM3.Visible = false;
                PanelHideXRAYTM.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseXRAYTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseXRAYTM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM2.Visible = true;
                PanelRaiseXRAYTM3.Visible = true;
                PanelHideXRAYTM.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseXRAYTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM2.Visible = true;
                PanelRaiseXRAYTM3.Visible = false;
                PanelHideXRAYTM.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryXRAYTM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ChestXRay] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYTM = '" + TextBoxXRAYTM.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryXRAYTM.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEXRAYTM.Visible = true;
                RAISEXRAYTM.ShowPopupWindow();
                QueryRaiseXRAYTM.Visible = false;
                TextBoxRaiseXRAYTM.Visible = false;
                PanelRaiseXRAYTM.Visible = false;
                PanelRaiseXRAYTM2.Visible = false;
                PanelRaiseXRAYTM3.Visible = false;

                LabelRespondXRAYTM.Visible = false;
            }

            else if ((ImageQueryXRAYTM.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYTM.Visible = true;
                RAISEXRAYTM.ShowPopupWindow();
                QueryRaiseXRAYTM.Visible = true;
                TextBoxRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM2.Visible = false;
                PanelRaiseXRAYTM3.Visible = false;
                LabelRespondXRAYTM.Visible = true;
            }

            else if ((ImageQueryXRAYTM.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYTM.Visible = true;
                RAISEXRAYTM.ShowPopupWindow();
                QueryRaiseXRAYTM.Visible = false;
                TextBoxRaiseXRAYTM.Visible = false;
                PanelRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM2.Visible = true;
                PanelRaiseXRAYTM3.Visible = false;
                LabelRespondXRAYTM.Visible = false;
            }
            else if ((ImageQueryXRAYTM.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYTM.Visible = true;
                RAISEXRAYTM.ShowPopupWindow();
                QueryRaiseXRAYTM.Visible = false;
                TextBoxRaiseXRAYTM.Visible = false;
                PanelRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM2.Visible = true;
                PanelRaiseXRAYTM3.Visible = true;
                LabelRespondXRAYTM.Visible = false;
            }
            else
            {
                RAISEXRAYTM.Visible = true;
                RAISEXRAYTM.ShowPopupWindow();
                QueryRaiseXRAYTM.Visible = false;
                TextBoxRaiseXRAYTM.Visible = false;
                PanelRaiseXRAYTM.Visible = true;
                PanelRaiseXRAYTM2.Visible = true;
                PanelRaiseXRAYTM3.Visible = true;
                LabelRespondXRAYTM.Visible = false;

            }
        }

    }
    protected void QueryRaiseXRAYTM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseXRAYTM.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYTM.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYTM.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ChestXRay] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYTM = '" + TextBoxXRAYTM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEXRAYTMMSG.ShowPopupWindow();
        RAISEXRAYTM.Visible = false;


    }
    #endregion
    #region QueryXRAYCMNT
    private void SetImageQueryXRAYCMNT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYCMNT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryXRAYCMNT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryXRAYCMNT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryXRAYCMNT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryXRAYCMNT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryXRAYCMNT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataXRAYCMNT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYCMNT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseXRAYCMNT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT2.Visible = false;
                PanelRaiseXRAYCMNT3.Visible = false;
                PanelHideXRAYCMNT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseXRAYCMNT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYCMNT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseXRAYCMNT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT2.Visible = true;
                PanelRaiseXRAYCMNT3.Visible = true;
                PanelHideXRAYCMNT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseXRAYCMNT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseXRAYCMNT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT2.Visible = true;
                PanelRaiseXRAYCMNT3.Visible = false;
                PanelHideXRAYCMNT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryXRAYCMNT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[ChestXRay] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYCMNT = '" + TextBoxXRAYCMNT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryXRAYCMNT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEXRAYCMNT.Visible = true;
                RAISEXRAYCMNT.ShowPopupWindow();
                QueryRaiseXRAYCMNT.Visible = false;
                TextBoxRaiseXRAYCMNT.Visible = false;
                PanelRaiseXRAYCMNT.Visible = false;
                PanelRaiseXRAYCMNT2.Visible = false;
                PanelRaiseXRAYCMNT3.Visible = false;

                LabelRespondXRAYCMNT.Visible = false;
            }

            else if ((ImageQueryXRAYCMNT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYCMNT.Visible = true;
                RAISEXRAYCMNT.ShowPopupWindow();
                QueryRaiseXRAYCMNT.Visible = true;
                TextBoxRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT2.Visible = false;
                PanelRaiseXRAYCMNT3.Visible = false;
                LabelRespondXRAYCMNT.Visible = true;
            }

            else if ((ImageQueryXRAYCMNT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYCMNT.Visible = true;
                RAISEXRAYCMNT.ShowPopupWindow();
                QueryRaiseXRAYCMNT.Visible = false;
                TextBoxRaiseXRAYCMNT.Visible = false;
                PanelRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT2.Visible = true;
                PanelRaiseXRAYCMNT3.Visible = false;
                LabelRespondXRAYCMNT.Visible = false;
            }
            else if ((ImageQueryXRAYCMNT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEXRAYCMNT.Visible = true;
                RAISEXRAYCMNT.ShowPopupWindow();
                QueryRaiseXRAYCMNT.Visible = false;
                TextBoxRaiseXRAYCMNT.Visible = false;
                PanelRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT2.Visible = true;
                PanelRaiseXRAYCMNT3.Visible = true;
                LabelRespondXRAYCMNT.Visible = false;
            }
            else
            {
                RAISEXRAYCMNT.Visible = true;
                RAISEXRAYCMNT.ShowPopupWindow();
                QueryRaiseXRAYCMNT.Visible = false;
                TextBoxRaiseXRAYCMNT.Visible = false;
                PanelRaiseXRAYCMNT.Visible = true;
                PanelRaiseXRAYCMNT2.Visible = true;
                PanelRaiseXRAYCMNT3.Visible = true;
                LabelRespondXRAYCMNT.Visible = false;

            }
        }

    }
    protected void QueryRaiseXRAYCMNT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseXRAYCMNT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYCMNT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblXRAYCMNT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[ChestXRay] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and XRAYCMNT = '" + TextBoxXRAYCMNT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEXRAYCMNTMSG.ShowPopupWindow();
        RAISEXRAYCMNT.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListXRAYNAB.SelectedValue == "Abnormal")
        {
            hideXRAYCMNT.Visible = true;
        }
        else
        {
            hideXRAYCMNT.Visible = false;
        }
        if (RadioButtonListXRAYPER.SelectedValue == "Yes")
        {
            XRAY.Visible = true;
            hideXRAYRSN.Visible = false;
        }
        else if (RadioButtonListXRAYPER.SelectedValue == "No")
        {
            hideXRAYRSN.Visible = true;
            XRAY.Visible = false;
            hideXRAYCMNT.Visible = false;
        }
        else
        {
            hideXRAYRSN.Visible = false;
            XRAY.Visible = false;
            hideXRAYCMNT.Visible = false;
        }
    }

    protected void RadioButtonListXRAYNAB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListXRAYNAB.SelectedValue == "Abnormal")
        {
            hideXRAYCMNT.Visible = true;
        }
        else
        {
            hideXRAYCMNT.Visible = false;
            TextBoxXRAYCMNT.Text = string.Empty;
        }
    }

    protected void RadioButtonListXRAYPER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListXRAYPER.SelectedValue == "Yes")
        {
            XRAY.Visible = true;
            hideXRAYRSN.Visible = false;
            TextBoxXRAYRSN.Text = string.Empty;
        }
        else if(RadioButtonListXRAYPER.SelectedValue == "No")
        {
            hideXRAYRSN.Visible = true;
            XRAY.Visible = false;
            TextBoxXRAYDT.Text = string.Empty;
            TextBoxXRAYTM.Text = string.Empty;
            RadioButtonListXRAYNAB.ClearSelection();
            hideXRAYCMNT.Visible = false;
            TextBoxXRAYCMNT.Text = string.Empty;
        }
        else
        {
            hideXRAYRSN.Visible = false;
            TextBoxXRAYRSN.Text = string.Empty;
            XRAY.Visible = false;
            TextBoxXRAYDT.Text = string.Empty;
            TextBoxXRAYTM.Text = string.Empty;
            RadioButtonListXRAYNAB.ClearSelection();
            hideXRAYCMNT.Visible = false;
            TextBoxXRAYCMNT.Text = string.Empty;
        }
    }
}