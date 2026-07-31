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

public partial class Data_Entry_Visit7_VisitDate : System.Web.UI.Page
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
            Bmi1();
        }
        else
        {
            Bmi();
        }
        PageStatus();
        SetImageAddNote();
        BindGridviewAddNote();
        SetImageAttach();
        BindGridViewADDAddAttachment();

        SetImageAttachPageHistory();
        BindGridViewADDAttachmentPageHistory();


        SetImageQueryVSDT();
        SetImageQueryMHSLV();
        SetImageQueryMHSLVKS();
        SetImageQueryHOH();
        SetImageQueryHOHKS();
        SetImageQueryDMHEIGHT();
        SetImageQueryDMWEIGHT();
        SetImageQueryDMBMI();
        BindQueryDataVSDT();
        BindQueryDataMHSLV();
        BindQueryDataMHSLVKS();
        BindQueryDataHOH();
        BindQueryDataHOHKS();
        BindQueryDataDMHEIGHT();
        BindQueryDataDMWEIGHT();
        BindQueryDataDMBMI();

        ShowHide();

    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select VSDT , MHSLV , MHSLVKS , HOH , HOHKS , DMHEIGHT , DMWEIGHT , DMBMI from [Visit7].[VisitDate] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxVSDT.Text = dt.Rows[0]["VSDT"].ToString().Trim();
            RadioButtonListMHSLV.SelectedValue = dt.Rows[0]["MHSLV"].ToString().Trim();
            TextBoxMHSLVKS.Text = dt.Rows[0]["MHSLVKS"].ToString().Trim();
            RadioButtonListHOH.SelectedValue = dt.Rows[0]["HOH"].ToString().Trim();
            TextBoxHOHKS.Text = dt.Rows[0]["HOHKS"].ToString().Trim();
            TextBoxDMHEIGHT.Text = dt.Rows[0]["DMHEIGHT"].ToString().Trim();
            TextBoxDMWEIGHT.Text = dt.Rows[0]["DMWEIGHT"].ToString().Trim();
            TextBoxDMBMI.Text = dt.Rows[0]["DMBMI"].ToString().Trim();

            ViewState["txt1"] = TextBoxVSDT.Text;
            ViewState["txt2"] = RadioButtonListMHSLV.SelectedValue;
            ViewState["txt3"] = TextBoxMHSLVKS.Text;
            ViewState["txt4"] = RadioButtonListHOH.SelectedValue;
            ViewState["txt5"] = TextBoxHOHKS.Text;
            ViewState["txt6"] = TextBoxDMHEIGHT.Text;
            ViewState["txt7"] = TextBoxDMWEIGHT.Text;
            ViewState["txt8"] = TextBoxDMBMI.Text;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit7].[VisitDate] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit7].[VisitDate] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit7].[sp_VisitDate]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@VSDT", TextBoxVSDT.Text);
                    cmd.Parameters.AddWithValue("@MHSLV", RadioButtonListMHSLV.SelectedValue);
                    cmd.Parameters.AddWithValue("@MHSLVKS", TextBoxMHSLVKS.Text);
                    cmd.Parameters.AddWithValue("@HOH", RadioButtonListHOH.SelectedValue);
                    cmd.Parameters.AddWithValue("@HOHKS", TextBoxHOHKS.Text);
                    cmd.Parameters.AddWithValue("@DMHEIGHT", TextBoxDMHEIGHT.Text);
                    cmd.Parameters.AddWithValue("@DMWEIGHT", TextBoxDMWEIGHT.Text);
                    cmd.Parameters.AddWithValue("@DMBMI", TextBoxDMBMI.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit7].[VisitDate] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != TextBoxVSDT.Text || ViewState["txt2"].ToString() != RadioButtonListMHSLV.SelectedValue || ViewState["txt3"].ToString() != TextBoxMHSLVKS.Text || ViewState["txt4"].ToString() != RadioButtonListHOH.SelectedValue || ViewState["txt5"].ToString() != TextBoxHOHKS.Text || ViewState["txt6"].ToString() != TextBoxDMHEIGHT.Text || ViewState["txt7"].ToString() != TextBoxDMWEIGHT.Text || ViewState["txt8"].ToString() != TextBoxDMBMI.Text)
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
                cmd = new SqlCommand("[Visit7].[sp_VisitDate]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@VSDT", TextBoxVSDT.Text);
                cmd.Parameters.AddWithValue("@MHSLV", RadioButtonListMHSLV.SelectedValue);
                cmd.Parameters.AddWithValue("@MHSLVKS", TextBoxMHSLVKS.Text);
                cmd.Parameters.AddWithValue("@HOH", RadioButtonListHOH.SelectedValue);
                cmd.Parameters.AddWithValue("@HOHKS", TextBoxHOHKS.Text);
                cmd.Parameters.AddWithValue("@DMHEIGHT", TextBoxDMHEIGHT.Text);
                cmd.Parameters.AddWithValue("@DMWEIGHT", TextBoxDMWEIGHT.Text);
                cmd.Parameters.AddWithValue("@DMBMI", TextBoxDMBMI.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit7].[VisitDate] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit7].[sp_VisitDate]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@VSDT", TextBoxVSDT.Text);
                    cmd.Parameters.AddWithValue("@MHSLV", RadioButtonListMHSLV.SelectedValue);
                    cmd.Parameters.AddWithValue("@MHSLVKS", TextBoxMHSLVKS.Text);
                    cmd.Parameters.AddWithValue("@HOH", RadioButtonListHOH.SelectedValue);
                    cmd.Parameters.AddWithValue("@HOHKS", TextBoxHOHKS.Text);
                    cmd.Parameters.AddWithValue("@DMHEIGHT", TextBoxDMHEIGHT.Text);
                    cmd.Parameters.AddWithValue("@DMWEIGHT", TextBoxDMWEIGHT.Text);
                    cmd.Parameters.AddWithValue("@DMBMI", TextBoxDMBMI.Text);

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
                cmd = new SqlCommand("[Visit7].[sp_VisitDate]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@VSDT", TextBoxVSDT.Text);
                cmd.Parameters.AddWithValue("@MHSLV", RadioButtonListMHSLV.SelectedValue);
                cmd.Parameters.AddWithValue("@MHSLVKS", TextBoxMHSLVKS.Text);
                cmd.Parameters.AddWithValue("@HOH", RadioButtonListHOH.SelectedValue);
                cmd.Parameters.AddWithValue("@HOHKS", TextBoxHOHKS.Text);
                cmd.Parameters.AddWithValue("@DMHEIGHT", TextBoxDMHEIGHT.Text);
                cmd.Parameters.AddWithValue("@DMWEIGHT", TextBoxDMWEIGHT.Text);
                cmd.Parameters.AddWithValue("@DMBMI", TextBoxDMBMI.Text);

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
        if (!string.IsNullOrEmpty(TextBoxVSDT.Text) || !string.IsNullOrEmpty(RadioButtonListMHSLV.SelectedValue) || !string.IsNullOrEmpty(TextBoxMHSLVKS.Text) || !string.IsNullOrEmpty(RadioButtonListHOH.SelectedValue) || !string.IsNullOrEmpty(TextBoxHOHKS.Text) || !string.IsNullOrEmpty(TextBoxDMHEIGHT.Text) || !string.IsNullOrEmpty(TextBoxDMWEIGHT.Text) || !string.IsNullOrEmpty(TextBoxDMBMI.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString().Trim() != TextBoxVSDT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSDT.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = TextBoxVSDT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString().Trim() != RadioButtonListMHSLV.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMHSLV.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = RadioButtonListMHSLV.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString().Trim() != TextBoxMHSLVKS.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMHSLVKS.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxMHSLVKS.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString().Trim() != RadioButtonListHOH.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHOH.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListHOH.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString().Trim() != TextBoxHOHKS.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHOHKS.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxHOHKS.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString().Trim() != TextBoxDMHEIGHT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMHEIGHT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxDMHEIGHT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString().Trim() != TextBoxDMWEIGHT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMWEIGHT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = TextBoxDMWEIGHT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString().Trim() != TextBoxDMBMI.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMBMI.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = TextBoxDMBMI.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit7].[sp_VisitDate]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@VSDT", TextBoxVSDT.Text);
            cmd.Parameters.AddWithValue("@MHSLV", RadioButtonListMHSLV.SelectedValue);
            cmd.Parameters.AddWithValue("@MHSLVKS", TextBoxMHSLVKS.Text);
            cmd.Parameters.AddWithValue("@HOH", RadioButtonListHOH.SelectedValue);
            cmd.Parameters.AddWithValue("@HOHKS", TextBoxHOHKS.Text);
            cmd.Parameters.AddWithValue("@DMHEIGHT", TextBoxDMHEIGHT.Text);
            cmd.Parameters.AddWithValue("@DMWEIGHT", TextBoxDMWEIGHT.Text);
            cmd.Parameters.AddWithValue("@DMBMI", TextBoxDMBMI.Text);

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
    #region QueryVSDT
    private void SetImageQueryVSDT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSDT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSDT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSDT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSDT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSDT.Visible = true;
                PanelRaiseVSDT2.Visible = false;
                PanelRaiseVSDT3.Visible = false;
                PanelHideVSDT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSDT.Visible = true;
                PanelRaiseVSDT2.Visible = true;
                PanelRaiseVSDT3.Visible = true;
                PanelHideVSDT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSDT.Visible = true;
                PanelRaiseVSDT2.Visible = true;
                PanelRaiseVSDT3.Visible = false;
                PanelHideVSDT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSDT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSDT = '" + TextBoxVSDT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSDT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSDT.Visible = true;
                RAISEVSDT.ShowPopupWindow();
                QueryRaiseVSDT.Visible = false;
                TextBoxRaiseVSDT.Visible = false;
                PanelRaiseVSDT.Visible = false;
                PanelRaiseVSDT2.Visible = false;
                PanelRaiseVSDT3.Visible = false;

                LabelRespondVSDT.Visible = false;
            }

            else if ((ImageQueryVSDT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDT.Visible = true;
                RAISEVSDT.ShowPopupWindow();
                QueryRaiseVSDT.Visible = true;
                TextBoxRaiseVSDT.Visible = true;
                PanelRaiseVSDT.Visible = true;
                PanelRaiseVSDT2.Visible = false;
                PanelRaiseVSDT3.Visible = false;
                LabelRespondVSDT.Visible = true;
            }

            else if ((ImageQueryVSDT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDT.Visible = true;
                RAISEVSDT.ShowPopupWindow();
                QueryRaiseVSDT.Visible = false;
                TextBoxRaiseVSDT.Visible = false;
                PanelRaiseVSDT.Visible = true;
                PanelRaiseVSDT2.Visible = true;
                PanelRaiseVSDT3.Visible = false;
                LabelRespondVSDT.Visible = false;
            }
            else if ((ImageQueryVSDT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDT.Visible = true;
                RAISEVSDT.ShowPopupWindow();
                QueryRaiseVSDT.Visible = false;
                TextBoxRaiseVSDT.Visible = false;
                PanelRaiseVSDT.Visible = true;
                PanelRaiseVSDT2.Visible = true;
                PanelRaiseVSDT3.Visible = true;
                LabelRespondVSDT.Visible = false;
            }
            else
            {
                RAISEVSDT.Visible = true;
                RAISEVSDT.ShowPopupWindow();
                QueryRaiseVSDT.Visible = false;
                TextBoxRaiseVSDT.Visible = false;
                PanelRaiseVSDT.Visible = true;
                PanelRaiseVSDT2.Visible = true;
                PanelRaiseVSDT3.Visible = true;
                LabelRespondVSDT.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSDT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseVSDT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSDT = '" + TextBoxVSDT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSDTMSG.ShowPopupWindow();
        RAISEVSDT.Visible = false;


    }
    #endregion
    #region QueryMHSLV
    private void SetImageQueryMHSLV()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLV.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMHSLV.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMHSLV.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMHSLV.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMHSLV.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMHSLV.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMHSLV()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLV.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMHSLV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV2.Visible = false;
                PanelRaiseMHSLV3.Visible = false;
                PanelHideMHSLV.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMHSLV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMHSLV2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMHSLV3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV2.Visible = true;
                PanelRaiseMHSLV3.Visible = true;
                PanelHideMHSLV.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMHSLV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMHSLV2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV2.Visible = true;
                PanelRaiseMHSLV3.Visible = false;
                PanelHideMHSLV.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMHSLV_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MHSLV = '" + RadioButtonListMHSLV.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMHSLV.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMHSLV.Visible = true;
                RAISEMHSLV.ShowPopupWindow();
                QueryRaiseMHSLV.Visible = false;
                TextBoxRaiseMHSLV.Visible = false;
                PanelRaiseMHSLV.Visible = false;
                PanelRaiseMHSLV2.Visible = false;
                PanelRaiseMHSLV3.Visible = false;

                LabelRespondMHSLV.Visible = false;
            }

            else if ((ImageQueryMHSLV.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMHSLV.Visible = true;
                RAISEMHSLV.ShowPopupWindow();
                QueryRaiseMHSLV.Visible = true;
                TextBoxRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV2.Visible = false;
                PanelRaiseMHSLV3.Visible = false;
                LabelRespondMHSLV.Visible = true;
            }

            else if ((ImageQueryMHSLV.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMHSLV.Visible = true;
                RAISEMHSLV.ShowPopupWindow();
                QueryRaiseMHSLV.Visible = false;
                TextBoxRaiseMHSLV.Visible = false;
                PanelRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV2.Visible = true;
                PanelRaiseMHSLV3.Visible = false;
                LabelRespondMHSLV.Visible = false;
            }
            else if ((ImageQueryMHSLV.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMHSLV.Visible = true;
                RAISEMHSLV.ShowPopupWindow();
                QueryRaiseMHSLV.Visible = false;
                TextBoxRaiseMHSLV.Visible = false;
                PanelRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV2.Visible = true;
                PanelRaiseMHSLV3.Visible = true;
                LabelRespondMHSLV.Visible = false;
            }
            else
            {
                RAISEMHSLV.Visible = true;
                RAISEMHSLV.ShowPopupWindow();
                QueryRaiseMHSLV.Visible = false;
                TextBoxRaiseMHSLV.Visible = false;
                PanelRaiseMHSLV.Visible = true;
                PanelRaiseMHSLV2.Visible = true;
                PanelRaiseMHSLV3.Visible = true;
                LabelRespondMHSLV.Visible = false;

            }
        }

    }
    protected void QueryRaiseMHSLV_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseMHSLV.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLV.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLV.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MHSLV = '" + RadioButtonListMHSLV.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMHSLVMSG.ShowPopupWindow();
        RAISEMHSLV.Visible = false;


    }
    #endregion
    #region QueryMHSLVKS
    private void SetImageQueryMHSLVKS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLVKS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMHSLVKS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMHSLVKS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMHSLVKS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMHSLVKS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMHSLVKS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMHSLVKS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLVKS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMHSLVKS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS2.Visible = false;
                PanelRaiseMHSLVKS3.Visible = false;
                PanelHideMHSLVKS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMHSLVKS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMHSLVKS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMHSLVKS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS2.Visible = true;
                PanelRaiseMHSLVKS3.Visible = true;
                PanelHideMHSLVKS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMHSLVKS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMHSLVKS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS2.Visible = true;
                PanelRaiseMHSLVKS3.Visible = false;
                PanelHideMHSLVKS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMHSLVKS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MHSLVKS = '" + TextBoxMHSLVKS.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMHSLVKS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMHSLVKS.Visible = true;
                RAISEMHSLVKS.ShowPopupWindow();
                QueryRaiseMHSLVKS.Visible = false;
                TextBoxRaiseMHSLVKS.Visible = false;
                PanelRaiseMHSLVKS.Visible = false;
                PanelRaiseMHSLVKS2.Visible = false;
                PanelRaiseMHSLVKS3.Visible = false;

                LabelRespondMHSLVKS.Visible = false;
            }

            else if ((ImageQueryMHSLVKS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMHSLVKS.Visible = true;
                RAISEMHSLVKS.ShowPopupWindow();
                QueryRaiseMHSLVKS.Visible = true;
                TextBoxRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS2.Visible = false;
                PanelRaiseMHSLVKS3.Visible = false;
                LabelRespondMHSLVKS.Visible = true;
            }

            else if ((ImageQueryMHSLVKS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMHSLVKS.Visible = true;
                RAISEMHSLVKS.ShowPopupWindow();
                QueryRaiseMHSLVKS.Visible = false;
                TextBoxRaiseMHSLVKS.Visible = false;
                PanelRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS2.Visible = true;
                PanelRaiseMHSLVKS3.Visible = false;
                LabelRespondMHSLVKS.Visible = false;
            }
            else if ((ImageQueryMHSLVKS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMHSLVKS.Visible = true;
                RAISEMHSLVKS.ShowPopupWindow();
                QueryRaiseMHSLVKS.Visible = false;
                TextBoxRaiseMHSLVKS.Visible = false;
                PanelRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS2.Visible = true;
                PanelRaiseMHSLVKS3.Visible = true;
                LabelRespondMHSLVKS.Visible = false;
            }
            else
            {
                RAISEMHSLVKS.Visible = true;
                RAISEMHSLVKS.ShowPopupWindow();
                QueryRaiseMHSLVKS.Visible = false;
                TextBoxRaiseMHSLVKS.Visible = false;
                PanelRaiseMHSLVKS.Visible = true;
                PanelRaiseMHSLVKS2.Visible = true;
                PanelRaiseMHSLVKS3.Visible = true;
                LabelRespondMHSLVKS.Visible = false;

            }
        }

    }
    protected void QueryRaiseMHSLVKS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseMHSLVKS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLVKS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMHSLVKS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MHSLVKS = '" + TextBoxMHSLVKS.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMHSLVKSMSG.ShowPopupWindow();
        RAISEMHSLVKS.Visible = false;


    }
    #endregion
    #region QueryHOH
    private void SetImageQueryHOH()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOH.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHOH.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHOH.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHOH.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHOH.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHOH.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHOH()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOH.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHOH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHOH.Visible = true;
                PanelRaiseHOH2.Visible = false;
                PanelRaiseHOH3.Visible = false;
                PanelHideHOH.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHOH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHOH2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHOH3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHOH.Visible = true;
                PanelRaiseHOH2.Visible = true;
                PanelRaiseHOH3.Visible = true;
                PanelHideHOH.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHOH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHOH2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHOH.Visible = true;
                PanelRaiseHOH2.Visible = true;
                PanelRaiseHOH3.Visible = false;
                PanelHideHOH.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHOH_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HOH = '" + RadioButtonListHOH.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHOH.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHOH.Visible = true;
                RAISEHOH.ShowPopupWindow();
                QueryRaiseHOH.Visible = false;
                TextBoxRaiseHOH.Visible = false;
                PanelRaiseHOH.Visible = false;
                PanelRaiseHOH2.Visible = false;
                PanelRaiseHOH3.Visible = false;

                LabelRespondHOH.Visible = false;
            }

            else if ((ImageQueryHOH.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHOH.Visible = true;
                RAISEHOH.ShowPopupWindow();
                QueryRaiseHOH.Visible = true;
                TextBoxRaiseHOH.Visible = true;
                PanelRaiseHOH.Visible = true;
                PanelRaiseHOH2.Visible = false;
                PanelRaiseHOH3.Visible = false;
                LabelRespondHOH.Visible = true;
            }

            else if ((ImageQueryHOH.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHOH.Visible = true;
                RAISEHOH.ShowPopupWindow();
                QueryRaiseHOH.Visible = false;
                TextBoxRaiseHOH.Visible = false;
                PanelRaiseHOH.Visible = true;
                PanelRaiseHOH2.Visible = true;
                PanelRaiseHOH3.Visible = false;
                LabelRespondHOH.Visible = false;
            }
            else if ((ImageQueryHOH.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHOH.Visible = true;
                RAISEHOH.ShowPopupWindow();
                QueryRaiseHOH.Visible = false;
                TextBoxRaiseHOH.Visible = false;
                PanelRaiseHOH.Visible = true;
                PanelRaiseHOH2.Visible = true;
                PanelRaiseHOH3.Visible = true;
                LabelRespondHOH.Visible = false;
            }
            else
            {
                RAISEHOH.Visible = true;
                RAISEHOH.ShowPopupWindow();
                QueryRaiseHOH.Visible = false;
                TextBoxRaiseHOH.Visible = false;
                PanelRaiseHOH.Visible = true;
                PanelRaiseHOH2.Visible = true;
                PanelRaiseHOH3.Visible = true;
                LabelRespondHOH.Visible = false;

            }
        }

    }
    protected void QueryRaiseHOH_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseHOH.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOH.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOH.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HOH = '" + RadioButtonListHOH.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHOHMSG.ShowPopupWindow();
        RAISEHOH.Visible = false;


    }
    #endregion
    #region QueryHOHKS
    private void SetImageQueryHOHKS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOHKS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHOHKS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHOHKS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHOHKS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHOHKS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHOHKS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHOHKS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOHKS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHOHKS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS2.Visible = false;
                PanelRaiseHOHKS3.Visible = false;
                PanelHideHOHKS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHOHKS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHOHKS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHOHKS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS2.Visible = true;
                PanelRaiseHOHKS3.Visible = true;
                PanelHideHOHKS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHOHKS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHOHKS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS2.Visible = true;
                PanelRaiseHOHKS3.Visible = false;
                PanelHideHOHKS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHOHKS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HOHKS = '" + TextBoxHOHKS.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHOHKS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHOHKS.Visible = true;
                RAISEHOHKS.ShowPopupWindow();
                QueryRaiseHOHKS.Visible = false;
                TextBoxRaiseHOHKS.Visible = false;
                PanelRaiseHOHKS.Visible = false;
                PanelRaiseHOHKS2.Visible = false;
                PanelRaiseHOHKS3.Visible = false;

                LabelRespondHOHKS.Visible = false;
            }

            else if ((ImageQueryHOHKS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHOHKS.Visible = true;
                RAISEHOHKS.ShowPopupWindow();
                QueryRaiseHOHKS.Visible = true;
                TextBoxRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS2.Visible = false;
                PanelRaiseHOHKS3.Visible = false;
                LabelRespondHOHKS.Visible = true;
            }

            else if ((ImageQueryHOHKS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHOHKS.Visible = true;
                RAISEHOHKS.ShowPopupWindow();
                QueryRaiseHOHKS.Visible = false;
                TextBoxRaiseHOHKS.Visible = false;
                PanelRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS2.Visible = true;
                PanelRaiseHOHKS3.Visible = false;
                LabelRespondHOHKS.Visible = false;
            }
            else if ((ImageQueryHOHKS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHOHKS.Visible = true;
                RAISEHOHKS.ShowPopupWindow();
                QueryRaiseHOHKS.Visible = false;
                TextBoxRaiseHOHKS.Visible = false;
                PanelRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS2.Visible = true;
                PanelRaiseHOHKS3.Visible = true;
                LabelRespondHOHKS.Visible = false;
            }
            else
            {
                RAISEHOHKS.Visible = true;
                RAISEHOHKS.ShowPopupWindow();
                QueryRaiseHOHKS.Visible = false;
                TextBoxRaiseHOHKS.Visible = false;
                PanelRaiseHOHKS.Visible = true;
                PanelRaiseHOHKS2.Visible = true;
                PanelRaiseHOHKS3.Visible = true;
                LabelRespondHOHKS.Visible = false;

            }
        }

    }
    protected void QueryRaiseHOHKS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseHOHKS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOHKS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHOHKS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HOHKS = '" + TextBoxHOHKS.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHOHKSMSG.ShowPopupWindow();
        RAISEHOHKS.Visible = false;


    }
    #endregion
    #region QueryDMHEIGHT
    private void SetImageQueryDMHEIGHT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMHEIGHT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMHEIGHT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMHEIGHT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMHEIGHT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMHEIGHT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMHEIGHT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMHEIGHT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMHEIGHT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMHEIGHT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT2.Visible = false;
                PanelRaiseDMHEIGHT3.Visible = false;
                PanelHideDMHEIGHT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMHEIGHT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMHEIGHT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMHEIGHT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT2.Visible = true;
                PanelRaiseDMHEIGHT3.Visible = true;
                PanelHideDMHEIGHT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMHEIGHT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMHEIGHT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT2.Visible = true;
                PanelRaiseDMHEIGHT3.Visible = false;
                PanelHideDMHEIGHT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMHEIGHT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMHEIGHT = '" + TextBoxDMHEIGHT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMHEIGHT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMHEIGHT.Visible = true;
                RAISEDMHEIGHT.ShowPopupWindow();
                QueryRaiseDMHEIGHT.Visible = false;
                TextBoxRaiseDMHEIGHT.Visible = false;
                PanelRaiseDMHEIGHT.Visible = false;
                PanelRaiseDMHEIGHT2.Visible = false;
                PanelRaiseDMHEIGHT3.Visible = false;

                LabelRespondDMHEIGHT.Visible = false;
            }

            else if ((ImageQueryDMHEIGHT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMHEIGHT.Visible = true;
                RAISEDMHEIGHT.ShowPopupWindow();
                QueryRaiseDMHEIGHT.Visible = true;
                TextBoxRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT2.Visible = false;
                PanelRaiseDMHEIGHT3.Visible = false;
                LabelRespondDMHEIGHT.Visible = true;
            }

            else if ((ImageQueryDMHEIGHT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMHEIGHT.Visible = true;
                RAISEDMHEIGHT.ShowPopupWindow();
                QueryRaiseDMHEIGHT.Visible = false;
                TextBoxRaiseDMHEIGHT.Visible = false;
                PanelRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT2.Visible = true;
                PanelRaiseDMHEIGHT3.Visible = false;
                LabelRespondDMHEIGHT.Visible = false;
            }
            else if ((ImageQueryDMHEIGHT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMHEIGHT.Visible = true;
                RAISEDMHEIGHT.ShowPopupWindow();
                QueryRaiseDMHEIGHT.Visible = false;
                TextBoxRaiseDMHEIGHT.Visible = false;
                PanelRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT2.Visible = true;
                PanelRaiseDMHEIGHT3.Visible = true;
                LabelRespondDMHEIGHT.Visible = false;
            }
            else
            {
                RAISEDMHEIGHT.Visible = true;
                RAISEDMHEIGHT.ShowPopupWindow();
                QueryRaiseDMHEIGHT.Visible = false;
                TextBoxRaiseDMHEIGHT.Visible = false;
                PanelRaiseDMHEIGHT.Visible = true;
                PanelRaiseDMHEIGHT2.Visible = true;
                PanelRaiseDMHEIGHT3.Visible = true;
                LabelRespondDMHEIGHT.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMHEIGHT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMHEIGHT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMHEIGHT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMHEIGHT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMHEIGHT = '" + TextBoxDMHEIGHT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMHEIGHTMSG.ShowPopupWindow();
        RAISEDMHEIGHT.Visible = false;


    }
    #endregion
    #region QueryDMWEIGHT
    private void SetImageQueryDMWEIGHT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMWEIGHT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMWEIGHT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMWEIGHT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMWEIGHT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMWEIGHT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMWEIGHT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMWEIGHT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMWEIGHT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMWEIGHT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT2.Visible = false;
                PanelRaiseDMWEIGHT3.Visible = false;
                PanelHideDMWEIGHT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMWEIGHT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMWEIGHT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMWEIGHT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT2.Visible = true;
                PanelRaiseDMWEIGHT3.Visible = true;
                PanelHideDMWEIGHT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMWEIGHT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMWEIGHT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT2.Visible = true;
                PanelRaiseDMWEIGHT3.Visible = false;
                PanelHideDMWEIGHT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMWEIGHT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMWEIGHT = '" + TextBoxDMWEIGHT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMWEIGHT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMWEIGHT.Visible = true;
                RAISEDMWEIGHT.ShowPopupWindow();
                QueryRaiseDMWEIGHT.Visible = false;
                TextBoxRaiseDMWEIGHT.Visible = false;
                PanelRaiseDMWEIGHT.Visible = false;
                PanelRaiseDMWEIGHT2.Visible = false;
                PanelRaiseDMWEIGHT3.Visible = false;

                LabelRespondDMWEIGHT.Visible = false;
            }

            else if ((ImageQueryDMWEIGHT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMWEIGHT.Visible = true;
                RAISEDMWEIGHT.ShowPopupWindow();
                QueryRaiseDMWEIGHT.Visible = true;
                TextBoxRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT2.Visible = false;
                PanelRaiseDMWEIGHT3.Visible = false;
                LabelRespondDMWEIGHT.Visible = true;
            }

            else if ((ImageQueryDMWEIGHT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMWEIGHT.Visible = true;
                RAISEDMWEIGHT.ShowPopupWindow();
                QueryRaiseDMWEIGHT.Visible = false;
                TextBoxRaiseDMWEIGHT.Visible = false;
                PanelRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT2.Visible = true;
                PanelRaiseDMWEIGHT3.Visible = false;
                LabelRespondDMWEIGHT.Visible = false;
            }
            else if ((ImageQueryDMWEIGHT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMWEIGHT.Visible = true;
                RAISEDMWEIGHT.ShowPopupWindow();
                QueryRaiseDMWEIGHT.Visible = false;
                TextBoxRaiseDMWEIGHT.Visible = false;
                PanelRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT2.Visible = true;
                PanelRaiseDMWEIGHT3.Visible = true;
                LabelRespondDMWEIGHT.Visible = false;
            }
            else
            {
                RAISEDMWEIGHT.Visible = true;
                RAISEDMWEIGHT.ShowPopupWindow();
                QueryRaiseDMWEIGHT.Visible = false;
                TextBoxRaiseDMWEIGHT.Visible = false;
                PanelRaiseDMWEIGHT.Visible = true;
                PanelRaiseDMWEIGHT2.Visible = true;
                PanelRaiseDMWEIGHT3.Visible = true;
                LabelRespondDMWEIGHT.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMWEIGHT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMWEIGHT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMWEIGHT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMWEIGHT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMWEIGHT = '" + TextBoxDMWEIGHT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMWEIGHTMSG.ShowPopupWindow();
        RAISEDMWEIGHT.Visible = false;


    }
    #endregion
    #region QueryDMBMI
    private void SetImageQueryDMBMI()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMBMI.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMBMI.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMBMI.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMBMI.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMBMI.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMBMI.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMBMI()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMBMI.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMBMI.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI2.Visible = false;
                PanelRaiseDMBMI3.Visible = false;
                PanelHideDMBMI.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMBMI.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMBMI2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMBMI3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI2.Visible = true;
                PanelRaiseDMBMI3.Visible = true;
                PanelHideDMBMI.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMBMI.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMBMI2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI2.Visible = true;
                PanelRaiseDMBMI3.Visible = false;
                PanelHideDMBMI.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMBMI_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit7].[VisitDate] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMBMI = '" + TextBoxDMBMI.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMBMI.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMBMI.Visible = true;
                RAISEDMBMI.ShowPopupWindow();
                QueryRaiseDMBMI.Visible = false;
                TextBoxRaiseDMBMI.Visible = false;
                PanelRaiseDMBMI.Visible = false;
                PanelRaiseDMBMI2.Visible = false;
                PanelRaiseDMBMI3.Visible = false;

                LabelRespondDMBMI.Visible = false;
            }

            else if ((ImageQueryDMBMI.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMBMI.Visible = true;
                RAISEDMBMI.ShowPopupWindow();
                QueryRaiseDMBMI.Visible = true;
                TextBoxRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI2.Visible = false;
                PanelRaiseDMBMI3.Visible = false;
                LabelRespondDMBMI.Visible = true;
            }

            else if ((ImageQueryDMBMI.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMBMI.Visible = true;
                RAISEDMBMI.ShowPopupWindow();
                QueryRaiseDMBMI.Visible = false;
                TextBoxRaiseDMBMI.Visible = false;
                PanelRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI2.Visible = true;
                PanelRaiseDMBMI3.Visible = false;
                LabelRespondDMBMI.Visible = false;
            }
            else if ((ImageQueryDMBMI.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMBMI.Visible = true;
                RAISEDMBMI.ShowPopupWindow();
                QueryRaiseDMBMI.Visible = false;
                TextBoxRaiseDMBMI.Visible = false;
                PanelRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI2.Visible = true;
                PanelRaiseDMBMI3.Visible = true;
                LabelRespondDMBMI.Visible = false;
            }
            else
            {
                RAISEDMBMI.Visible = true;
                RAISEDMBMI.ShowPopupWindow();
                QueryRaiseDMBMI.Visible = false;
                TextBoxRaiseDMBMI.Visible = false;
                PanelRaiseDMBMI.Visible = true;
                PanelRaiseDMBMI2.Visible = true;
                PanelRaiseDMBMI3.Visible = true;
                LabelRespondDMBMI.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMBMI_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMBMI.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMBMI.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMBMI.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit7].[VisitDate] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMBMI = '" + TextBoxDMBMI.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMBMIMSG.ShowPopupWindow();
        RAISEDMBMI.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListMHSLV.SelectedValue == "Yes")
        {
            hideMHSLVKS.Visible = true;
        }
        else
        {
            hideMHSLVKS.Visible = false;
        }

        if (RadioButtonListHOH.SelectedValue == "Yes")
        {
            hideHOHKS.Visible = true;
        }
        else
        {
            hideHOHKS.Visible = false;
        }
    }

    protected void RadioButtonListMHSLV_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListMHSLV.SelectedValue == "Yes")
        {
            hideMHSLVKS.Visible = true;
        }
        else
        {
            hideMHSLVKS.Visible = false;
            TextBoxMHSLVKS.Text = string.Empty;
        }
    }

    protected void RadioButtonListHOH_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListHOH.SelectedValue == "Yes")
        {
            hideHOHKS.Visible = true;
        }
        else
        {
            hideHOHKS.Visible = false;
            TextBoxHOHKS.Text = string.Empty;
        }
    }

    public void Bmi1()
    {

        if (TextBoxDMWEIGHT.Text == "" || TextBoxDMHEIGHT.Text == "" || TextBoxDMBMI.Text == "")
        {
            TextBoxDMWEIGHT.Text = null;
            TextBoxDMHEIGHT.Text = null;
            TextBoxDMBMI.Text = null;
        }
    }
    public void Bmi()
    {
        try
        {
            double weight = Convert.ToDouble(TextBoxDMWEIGHT.Text);
            double height = Convert.ToDouble(TextBoxDMHEIGHT.Text);
            // double feet = Convert.ToDouble(TextBox4.Text) * 0.0254;

            double fm = (height);
            double bmi = weight / (fm / 100 * fm / 100);
            double output = Math.Round(bmi, 2);
            TextBoxDMBMI.Text = output.ToString();
            // LinkButton3.Text = "";
        }
        catch
        {
            //LinkButton2.Text = "Please enter numeric values(Like Weight=70, Height [Feet]=6,  [Inch]=2).If value not available(Like [Weight] = NA, Height [Feet] = NA,  [Inch] = NA).";
            //TextBox5.Text = "";
        }

    }
}