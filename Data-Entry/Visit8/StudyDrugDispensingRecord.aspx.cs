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

public partial class Data_Entry_Visit8_StudyDrugDispensingRecord : System.Web.UI.Page
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

        SetImageQuerySDDRPER();
        SetImageQuerySDDDOSE();
        SetImageQuerySDDFRQ();
        SetImageQuerySDDDOD();

        BindQueryDataSDDRPER();
        BindQueryDataSDDDOSE();
        BindQueryDataSDDFRQ();
        BindQueryDataSDDDOD();

        if (RadioButtonListSDDRPER.SelectedValue == "Yes")
        {
            hideSDDR.Visible = true;
        }
        else
        {
            hideSDDR.Visible = false;
        }
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select SDDRPER , SDDDOSE , SDDFRQ , SDDDOD from [Visit8].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListSDDRPER.SelectedValue = dt.Rows[0]["SDDRPER"].ToString().Trim();
            TextBoxSDDDOSE.Text = dt.Rows[0]["SDDDOSE"].ToString().Trim();
            TextBoxSDDFRQ.Text = dt.Rows[0]["SDDFRQ"].ToString().Trim();
            TextBoxSDDDOD.Text = dt.Rows[0]["SDDDOD"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListSDDRPER.SelectedValue;
            ViewState["txt2"] = TextBoxSDDDOSE.Text;
            ViewState["txt3"] = TextBoxSDDFRQ.Text;
            ViewState["txt4"] = TextBoxSDDDOD.Text;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit8].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit8].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit8].[sp_StudyDrugDispensingRecord]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@SDDRPER", RadioButtonListSDDRPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@SDDDOSE", TextBoxSDDDOSE.Text);
                    cmd.Parameters.AddWithValue("@SDDFRQ", TextBoxSDDFRQ.Text);
                    cmd.Parameters.AddWithValue("@SDDDOD", TextBoxSDDDOD.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit8].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListSDDRPER.SelectedValue || ViewState["txt2"].ToString() != TextBoxSDDDOSE.Text || ViewState["txt3"].ToString() != TextBoxSDDFRQ.Text || ViewState["txt4"].ToString() != TextBoxSDDDOD.Text)
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
                cmd = new SqlCommand("[Visit8].[sp_StudyDrugDispensingRecord]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@SDDRPER", RadioButtonListSDDRPER.SelectedValue);
                cmd.Parameters.AddWithValue("@SDDDOSE", TextBoxSDDDOSE.Text);
                cmd.Parameters.AddWithValue("@SDDFRQ", TextBoxSDDFRQ.Text);
                cmd.Parameters.AddWithValue("@SDDDOD", TextBoxSDDDOD.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit8].[StudyDrugDispensingRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit8].[sp_StudyDrugDispensingRecord]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@SDDRPER", RadioButtonListSDDRPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@SDDDOSE", TextBoxSDDDOSE.Text);
                    cmd.Parameters.AddWithValue("@SDDFRQ", TextBoxSDDFRQ.Text);
                    cmd.Parameters.AddWithValue("@SDDDOD", TextBoxSDDDOD.Text);

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
                cmd = new SqlCommand("[Visit8].[sp_StudyDrugDispensingRecord]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@SDDRPER", RadioButtonListSDDRPER.SelectedValue);
                cmd.Parameters.AddWithValue("@SDDDOSE", TextBoxSDDDOSE.Text);
                cmd.Parameters.AddWithValue("@SDDFRQ", TextBoxSDDFRQ.Text);
                cmd.Parameters.AddWithValue("@SDDDOD", TextBoxSDDDOD.Text);

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
        if (!string.IsNullOrEmpty(RadioButtonListSDDRPER.SelectedValue) || !string.IsNullOrEmpty(TextBoxSDDDOSE.Text) || !string.IsNullOrEmpty(TextBoxSDDFRQ.Text) || !string.IsNullOrEmpty(TextBoxSDDDOD.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListSDDRPER.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblSDDRPER.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListSDDRPER.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() != TextBoxSDDDOSE.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblSDDDOSE.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxSDDDOSE.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() != TextBoxSDDFRQ.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblSDDFRQ.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxSDDFRQ.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() != TextBoxSDDDOD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblSDDDOD.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxSDDDOD.Text;
                dtEmp.Rows.Add(dtrow);
            }

        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit8].[sp_StudyDrugDispensingRecord]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@SDDRPER", RadioButtonListSDDRPER.SelectedValue);
            cmd.Parameters.AddWithValue("@SDDDOSE", TextBoxSDDDOSE.Text);
            cmd.Parameters.AddWithValue("@SDDFRQ", TextBoxSDDFRQ.Text);
            cmd.Parameters.AddWithValue("@SDDDOD", TextBoxSDDDOD.Text);

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
    #region QuerySDDRPER
    private void SetImageQuerySDDRPER()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDRPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySDDRPER.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySDDRPER.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySDDRPER.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQuerySDDRPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySDDRPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataSDDRPER()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDRPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSDDRPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER2.Visible = false;
                PanelRaiseSDDRPER3.Visible = false;
                PanelHideSDDRPER.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSDDRPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDRPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseSDDRPER3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER2.Visible = true;
                PanelRaiseSDDRPER3.Visible = true;
                PanelHideSDDRPER.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSDDRPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDRPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER2.Visible = true;
                PanelRaiseSDDRPER3.Visible = false;
                PanelHideSDDRPER.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQuerySDDRPER_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[StudyDrugDispensingRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDRPER = '" + RadioButtonListSDDRPER.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySDDRPER.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESDDRPER.Visible = true;
                RAISESDDRPER.ShowPopupWindow();
                QueryRaiseSDDRPER.Visible = false;
                TextBoxRaiseSDDRPER.Visible = false;
                PanelRaiseSDDRPER.Visible = false;
                PanelRaiseSDDRPER2.Visible = false;
                PanelRaiseSDDRPER3.Visible = false;

                LabelRespondSDDRPER.Visible = false;
            }

            else if ((ImageQuerySDDRPER.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDRPER.Visible = true;
                RAISESDDRPER.ShowPopupWindow();
                QueryRaiseSDDRPER.Visible = true;
                TextBoxRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER2.Visible = false;
                PanelRaiseSDDRPER3.Visible = false;
                LabelRespondSDDRPER.Visible = true;
            }

            else if ((ImageQuerySDDRPER.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDRPER.Visible = true;
                RAISESDDRPER.ShowPopupWindow();
                QueryRaiseSDDRPER.Visible = false;
                TextBoxRaiseSDDRPER.Visible = false;
                PanelRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER2.Visible = true;
                PanelRaiseSDDRPER3.Visible = false;
                LabelRespondSDDRPER.Visible = false;
            }
            else if ((ImageQuerySDDRPER.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDRPER.Visible = true;
                RAISESDDRPER.ShowPopupWindow();
                QueryRaiseSDDRPER.Visible = false;
                TextBoxRaiseSDDRPER.Visible = false;
                PanelRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER2.Visible = true;
                PanelRaiseSDDRPER3.Visible = true;
                LabelRespondSDDRPER.Visible = false;
            }
            else
            {
                RAISESDDRPER.Visible = true;
                RAISESDDRPER.ShowPopupWindow();
                QueryRaiseSDDRPER.Visible = false;
                TextBoxRaiseSDDRPER.Visible = false;
                PanelRaiseSDDRPER.Visible = true;
                PanelRaiseSDDRPER2.Visible = true;
                PanelRaiseSDDRPER3.Visible = true;
                LabelRespondSDDRPER.Visible = false;

            }
        }

    }
    protected void QueryRaiseSDDRPER_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseSDDRPER.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDRPER.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDRPER.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[StudyDrugDispensingRecord] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDRPER = '" + RadioButtonListSDDRPER.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESDDRPERMSG.ShowPopupWindow();
        RAISESDDRPER.Visible = false;


    }
    #endregion
    #region QuerySDDDOSE
    private void SetImageQuerySDDDOSE()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOSE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySDDDOSE.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySDDDOSE.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySDDDOSE.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQuerySDDDOSE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySDDDOSE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataSDDDOSE()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOSE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSDDDOSE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE2.Visible = false;
                PanelRaiseSDDDOSE3.Visible = false;
                PanelHideSDDDOSE.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSDDDOSE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDDOSE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseSDDDOSE3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE2.Visible = true;
                PanelRaiseSDDDOSE3.Visible = true;
                PanelHideSDDDOSE.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSDDDOSE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDDOSE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE2.Visible = true;
                PanelRaiseSDDDOSE3.Visible = false;
                PanelHideSDDDOSE.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQuerySDDDOSE_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[StudyDrugDispensingRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDDOSE = '" + TextBoxSDDDOSE.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySDDDOSE.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESDDDOSE.Visible = true;
                RAISESDDDOSE.ShowPopupWindow();
                QueryRaiseSDDDOSE.Visible = false;
                TextBoxRaiseSDDDOSE.Visible = false;
                PanelRaiseSDDDOSE.Visible = false;
                PanelRaiseSDDDOSE2.Visible = false;
                PanelRaiseSDDDOSE3.Visible = false;

                LabelRespondSDDDOSE.Visible = false;
            }

            else if ((ImageQuerySDDDOSE.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDDOSE.Visible = true;
                RAISESDDDOSE.ShowPopupWindow();
                QueryRaiseSDDDOSE.Visible = true;
                TextBoxRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE2.Visible = false;
                PanelRaiseSDDDOSE3.Visible = false;
                LabelRespondSDDDOSE.Visible = true;
            }

            else if ((ImageQuerySDDDOSE.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDDOSE.Visible = true;
                RAISESDDDOSE.ShowPopupWindow();
                QueryRaiseSDDDOSE.Visible = false;
                TextBoxRaiseSDDDOSE.Visible = false;
                PanelRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE2.Visible = true;
                PanelRaiseSDDDOSE3.Visible = false;
                LabelRespondSDDDOSE.Visible = false;
            }
            else if ((ImageQuerySDDDOSE.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDDOSE.Visible = true;
                RAISESDDDOSE.ShowPopupWindow();
                QueryRaiseSDDDOSE.Visible = false;
                TextBoxRaiseSDDDOSE.Visible = false;
                PanelRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE2.Visible = true;
                PanelRaiseSDDDOSE3.Visible = true;
                LabelRespondSDDDOSE.Visible = false;
            }
            else
            {
                RAISESDDDOSE.Visible = true;
                RAISESDDDOSE.ShowPopupWindow();
                QueryRaiseSDDDOSE.Visible = false;
                TextBoxRaiseSDDDOSE.Visible = false;
                PanelRaiseSDDDOSE.Visible = true;
                PanelRaiseSDDDOSE2.Visible = true;
                PanelRaiseSDDDOSE3.Visible = true;
                LabelRespondSDDDOSE.Visible = false;

            }
        }

    }
    protected void QueryRaiseSDDDOSE_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseSDDDOSE.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOSE.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOSE.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[StudyDrugDispensingRecord] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDDOSE = '" + TextBoxSDDDOSE.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESDDDOSEMSG.ShowPopupWindow();
        RAISESDDDOSE.Visible = false;


    }
    #endregion
    #region QuerySDDFRQ
    private void SetImageQuerySDDFRQ()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDFRQ.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySDDFRQ.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySDDFRQ.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySDDFRQ.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQuerySDDFRQ.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySDDFRQ.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataSDDFRQ()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDFRQ.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSDDFRQ.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ2.Visible = false;
                PanelRaiseSDDFRQ3.Visible = false;
                PanelHideSDDFRQ.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSDDFRQ.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDFRQ2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseSDDFRQ3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ2.Visible = true;
                PanelRaiseSDDFRQ3.Visible = true;
                PanelHideSDDFRQ.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSDDFRQ.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDFRQ2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ2.Visible = true;
                PanelRaiseSDDFRQ3.Visible = false;
                PanelHideSDDFRQ.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQuerySDDFRQ_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[StudyDrugDispensingRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDFRQ = '" + TextBoxSDDFRQ.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySDDFRQ.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESDDFRQ.Visible = true;
                RAISESDDFRQ.ShowPopupWindow();
                QueryRaiseSDDFRQ.Visible = false;
                TextBoxRaiseSDDFRQ.Visible = false;
                PanelRaiseSDDFRQ.Visible = false;
                PanelRaiseSDDFRQ2.Visible = false;
                PanelRaiseSDDFRQ3.Visible = false;

                LabelRespondSDDFRQ.Visible = false;
            }

            else if ((ImageQuerySDDFRQ.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDFRQ.Visible = true;
                RAISESDDFRQ.ShowPopupWindow();
                QueryRaiseSDDFRQ.Visible = true;
                TextBoxRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ2.Visible = false;
                PanelRaiseSDDFRQ3.Visible = false;
                LabelRespondSDDFRQ.Visible = true;
            }

            else if ((ImageQuerySDDFRQ.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDFRQ.Visible = true;
                RAISESDDFRQ.ShowPopupWindow();
                QueryRaiseSDDFRQ.Visible = false;
                TextBoxRaiseSDDFRQ.Visible = false;
                PanelRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ2.Visible = true;
                PanelRaiseSDDFRQ3.Visible = false;
                LabelRespondSDDFRQ.Visible = false;
            }
            else if ((ImageQuerySDDFRQ.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDFRQ.Visible = true;
                RAISESDDFRQ.ShowPopupWindow();
                QueryRaiseSDDFRQ.Visible = false;
                TextBoxRaiseSDDFRQ.Visible = false;
                PanelRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ2.Visible = true;
                PanelRaiseSDDFRQ3.Visible = true;
                LabelRespondSDDFRQ.Visible = false;
            }
            else
            {
                RAISESDDFRQ.Visible = true;
                RAISESDDFRQ.ShowPopupWindow();
                QueryRaiseSDDFRQ.Visible = false;
                TextBoxRaiseSDDFRQ.Visible = false;
                PanelRaiseSDDFRQ.Visible = true;
                PanelRaiseSDDFRQ2.Visible = true;
                PanelRaiseSDDFRQ3.Visible = true;
                LabelRespondSDDFRQ.Visible = false;

            }
        }

    }
    protected void QueryRaiseSDDFRQ_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseSDDFRQ.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDFRQ.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDFRQ.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[StudyDrugDispensingRecord] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDFRQ = '" + TextBoxSDDFRQ.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESDDFRQMSG.ShowPopupWindow();
        RAISESDDFRQ.Visible = false;


    }
    #endregion

    #region QuerySDDDOD
    private void SetImageQuerySDDDOD()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQuerySDDDOD.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQuerySDDDOD.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQuerySDDDOD.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQuerySDDDOD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQuerySDDDOD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataSDDDOD()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseSDDDOD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD2.Visible = false;
                PanelRaiseSDDDOD3.Visible = false;
                PanelHideSDDDOD.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseSDDDOD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDDOD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseSDDDOD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD2.Visible = true;
                PanelRaiseSDDDOD3.Visible = true;
                PanelHideSDDDOD.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseSDDDOD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseSDDDOD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD2.Visible = true;
                PanelRaiseSDDDOD3.Visible = false;
                PanelHideSDDDOD.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQuerySDDDOD_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[StudyDrugDispensingRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDDOD = '" + TextBoxSDDDOD.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQuerySDDDOD.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISESDDDOD.Visible = true;
                RAISESDDDOD.ShowPopupWindow();
                QueryRaiseSDDDOD.Visible = false;
                TextBoxRaiseSDDDOD.Visible = false;
                PanelRaiseSDDDOD.Visible = false;
                PanelRaiseSDDDOD2.Visible = false;
                PanelRaiseSDDDOD3.Visible = false;

                LabelRespondSDDDOD.Visible = false;
            }

            else if ((ImageQuerySDDDOD.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDDOD.Visible = true;
                RAISESDDDOD.ShowPopupWindow();
                QueryRaiseSDDDOD.Visible = true;
                TextBoxRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD2.Visible = false;
                PanelRaiseSDDDOD3.Visible = false;
                LabelRespondSDDDOD.Visible = true;
            }

            else if ((ImageQuerySDDDOD.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDDOD.Visible = true;
                RAISESDDDOD.ShowPopupWindow();
                QueryRaiseSDDDOD.Visible = false;
                TextBoxRaiseSDDDOD.Visible = false;
                PanelRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD2.Visible = true;
                PanelRaiseSDDDOD3.Visible = false;
                LabelRespondSDDDOD.Visible = false;
            }
            else if ((ImageQuerySDDDOD.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISESDDDOD.Visible = true;
                RAISESDDDOD.ShowPopupWindow();
                QueryRaiseSDDDOD.Visible = false;
                TextBoxRaiseSDDDOD.Visible = false;
                PanelRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD2.Visible = true;
                PanelRaiseSDDDOD3.Visible = true;
                LabelRespondSDDDOD.Visible = false;
            }
            else
            {
                RAISESDDDOD.Visible = true;
                RAISESDDDOD.ShowPopupWindow();
                QueryRaiseSDDDOD.Visible = false;
                TextBoxRaiseSDDDOD.Visible = false;
                PanelRaiseSDDDOD.Visible = true;
                PanelRaiseSDDDOD2.Visible = true;
                PanelRaiseSDDDOD3.Visible = true;
                LabelRespondSDDDOD.Visible = false;

            }
        }

    }
    protected void QueryRaiseSDDDOD_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseSDDDOD.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOD.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblSDDDOD.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[StudyDrugDispensingRecord] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and SDDDOD = '" + TextBoxSDDDOD.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISESDDDODMSG.ShowPopupWindow();
        RAISESDDDOD.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }



    protected void RadioButtonListSDDRPER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListSDDRPER.SelectedValue == "Yes")
        {
            hideSDDR.Visible = true;
        }
        else
        {
            hideSDDR.Visible = false;
            TextBoxSDDDOSE.Text = string.Empty;
            TextBoxSDDFRQ.Text = string.Empty;
            TextBoxSDDDOD.Text = string.Empty;
        }
    }
}