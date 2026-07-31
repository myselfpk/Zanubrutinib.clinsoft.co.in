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

public partial class Data_Entry_Visit1_Demographics : System.Web.UI.Page
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


        SetImageQueryDMGEN();
        BindQueryDataDMGEN();
        SetImageQueryDMDOB();
        BindQueryDataDMDOB();
        SetImageQueryDMAGE();
        BindQueryDataDMAGE();
        SetImageQueryDMRACE();
        BindQueryDataDMRACE();
        SetImageQueryDMSPY();
        BindQueryDataDMSPY();
        SetImageQueryDMHEIGHT();
        BindQueryDataDMHEIGHT();
        SetImageQueryDMWEIGHT();
        BindQueryDataDMWEIGHT();
        SetImageQueryDMBMI();
        BindQueryDataDMBMI();
        TextBoxDMDOB_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
        CalculateAndValidateAge();
        if (RadioButtonListDMRACE.SelectedValue == "Other")
        {
            hideDMSPY.Visible = true;
        }
        else
        {
            hideDMSPY.Visible = false;
        }
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select DMGEN , DMDOB , DMAGE , DMRACE , DMSPY , DMHEIGHT , DMWEIGHT , DMBMI from [Visit1].[Demographics] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListDMGEN.SelectedValue = dt.Rows[0]["DMGEN"].ToString().Trim();
            TextBoxDMDOB.Text = dt.Rows[0]["DMDOB"].ToString().Trim();
            TextBoxDMAGE.Text = dt.Rows[0]["DMAGE"].ToString().Trim();
            RadioButtonListDMRACE.SelectedValue = dt.Rows[0]["DMRACE"].ToString().Trim();
            TextBoxDMSPY.Text = dt.Rows[0]["DMSPY"].ToString().Trim();
            TextBoxDMHEIGHT.Text = dt.Rows[0]["DMHEIGHT"].ToString().Trim();
            TextBoxDMWEIGHT.Text = dt.Rows[0]["DMWEIGHT"].ToString().Trim();
            TextBoxDMBMI.Text = dt.Rows[0]["DMBMI"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListDMGEN.SelectedValue;
            ViewState["txt2"] = TextBoxDMDOB.Text;
            ViewState["txt3"] = TextBoxDMAGE.Text;
            ViewState["txt4"] = RadioButtonListDMRACE.SelectedValue;
            ViewState["txt5"] = TextBoxDMSPY.Text;
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[Demographics] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[Demographics] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_Demographics]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@DMGEN", RadioButtonListDMGEN.SelectedValue);
                    cmd.Parameters.AddWithValue("@DMDOB", TextBoxDMDOB.Text);
                    cmd.Parameters.AddWithValue("@DMAGE", TextBoxDMAGE.Text);
                    cmd.Parameters.AddWithValue("@DMRACE", RadioButtonListDMRACE.SelectedValue);
                    cmd.Parameters.AddWithValue("@DMSPY", TextBoxDMSPY.Text);
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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[Demographics] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListDMGEN.SelectedValue || ViewState["txt2"].ToString() != TextBoxDMDOB.Text || ViewState["txt3"].ToString() != TextBoxDMAGE.Text || ViewState["txt4"].ToString() != RadioButtonListDMRACE.SelectedValue || ViewState["txt5"].ToString() != TextBoxDMSPY.Text || ViewState["txt6"].ToString() != TextBoxDMHEIGHT.Text || ViewState["txt7"].ToString() != TextBoxDMWEIGHT.Text || ViewState["txt8"].ToString() != TextBoxDMBMI.Text)
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
                cmd = new SqlCommand("[Visit1].[sp_Demographics]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@DMGEN", RadioButtonListDMGEN.SelectedValue);
                cmd.Parameters.AddWithValue("@DMDOB", TextBoxDMDOB.Text);
                cmd.Parameters.AddWithValue("@DMAGE", TextBoxDMAGE.Text);
                cmd.Parameters.AddWithValue("@DMRACE", RadioButtonListDMRACE.SelectedValue);
                cmd.Parameters.AddWithValue("@DMSPY", TextBoxDMSPY.Text);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[Demographics] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_Demographics]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@DMGEN", RadioButtonListDMGEN.SelectedValue);
                    cmd.Parameters.AddWithValue("@DMDOB", TextBoxDMDOB.Text);
                    cmd.Parameters.AddWithValue("@DMAGE", TextBoxDMAGE.Text);
                    cmd.Parameters.AddWithValue("@DMRACE", RadioButtonListDMRACE.SelectedValue);
                    cmd.Parameters.AddWithValue("@DMSPY", TextBoxDMSPY.Text);
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
                cmd = new SqlCommand("[Visit1].[sp_Demographics]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@DMGEN", RadioButtonListDMGEN.SelectedValue);
                cmd.Parameters.AddWithValue("@DMDOB", TextBoxDMDOB.Text);
                cmd.Parameters.AddWithValue("@DMAGE", TextBoxDMAGE.Text);
                cmd.Parameters.AddWithValue("@DMRACE", RadioButtonListDMRACE.SelectedValue);
                cmd.Parameters.AddWithValue("@DMSPY", TextBoxDMSPY.Text);
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
        if (!string.IsNullOrEmpty(RadioButtonListDMGEN.SelectedValue) || !string.IsNullOrEmpty(TextBoxDMDOB.Text) || !string.IsNullOrEmpty(TextBoxDMAGE.Text) || !string.IsNullOrEmpty(RadioButtonListDMRACE.SelectedValue) || !string.IsNullOrEmpty(TextBoxDMSPY.Text) || !string.IsNullOrEmpty(TextBoxDMHEIGHT.Text) || !string.IsNullOrEmpty(TextBoxDMWEIGHT.Text) || !string.IsNullOrEmpty(TextBoxDMBMI.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString().Trim() != RadioButtonListDMGEN.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMGEN.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListDMGEN.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString().Trim() != TextBoxDMDOB.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMDOB.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxDMDOB.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString().Trim() != TextBoxDMAGE.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMAGE.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxDMAGE.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString().Trim() != RadioButtonListDMRACE.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMRACE.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListDMRACE.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString().Trim() != TextBoxDMSPY.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblDMSPY.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxDMSPY.Text;
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

            cmd = new SqlCommand("[Visit1].[sp_Demographics]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@DMGEN", RadioButtonListDMGEN.SelectedValue);
            cmd.Parameters.AddWithValue("@DMDOB", TextBoxDMDOB.Text);
            cmd.Parameters.AddWithValue("@DMAGE", TextBoxDMAGE.Text);
            cmd.Parameters.AddWithValue("@DMRACE", RadioButtonListDMRACE.SelectedValue);
            cmd.Parameters.AddWithValue("@DMSPY", TextBoxDMSPY.Text);
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
    #region QueryDMGEN
    private void SetImageQueryDMGEN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMGEN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMGEN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMGEN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMGEN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMGEN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMGEN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMGEN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMGEN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMGEN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN2.Visible = false;
                PanelRaiseDMGEN3.Visible = false;
                PanelHideDMGEN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMGEN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMGEN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMGEN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN2.Visible = true;
                PanelRaiseDMGEN3.Visible = true;
                PanelHideDMGEN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMGEN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMGEN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN2.Visible = true;
                PanelRaiseDMGEN3.Visible = false;
                PanelHideDMGEN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMGEN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMGEN = '" + RadioButtonListDMGEN.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMGEN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMGEN.Visible = true;
                RAISEDMGEN.ShowPopupWindow();
                QueryRaiseDMGEN.Visible = false;
                TextBoxRaiseDMGEN.Visible = false;
                PanelRaiseDMGEN.Visible = false;
                PanelRaiseDMGEN2.Visible = false;
                PanelRaiseDMGEN3.Visible = false;

                LabelRespondDMGEN.Visible = false;
            }

            else if ((ImageQueryDMGEN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMGEN.Visible = true;
                RAISEDMGEN.ShowPopupWindow();
                QueryRaiseDMGEN.Visible = true;
                TextBoxRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN2.Visible = false;
                PanelRaiseDMGEN3.Visible = false;
                LabelRespondDMGEN.Visible = true;
            }

            else if ((ImageQueryDMGEN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMGEN.Visible = true;
                RAISEDMGEN.ShowPopupWindow();
                QueryRaiseDMGEN.Visible = false;
                TextBoxRaiseDMGEN.Visible = false;
                PanelRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN2.Visible = true;
                PanelRaiseDMGEN3.Visible = false;
                LabelRespondDMGEN.Visible = false;
            }
            else if ((ImageQueryDMGEN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMGEN.Visible = true;
                RAISEDMGEN.ShowPopupWindow();
                QueryRaiseDMGEN.Visible = false;
                TextBoxRaiseDMGEN.Visible = false;
                PanelRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN2.Visible = true;
                PanelRaiseDMGEN3.Visible = true;
                LabelRespondDMGEN.Visible = false;
            }
            else
            {
                RAISEDMGEN.Visible = true;
                RAISEDMGEN.ShowPopupWindow();
                QueryRaiseDMGEN.Visible = false;
                TextBoxRaiseDMGEN.Visible = false;
                PanelRaiseDMGEN.Visible = true;
                PanelRaiseDMGEN2.Visible = true;
                PanelRaiseDMGEN3.Visible = true;
                LabelRespondDMGEN.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMGEN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMGEN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMGEN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMGEN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMGEN = '" + RadioButtonListDMGEN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMGENMSG.ShowPopupWindow();
        RAISEDMGEN.Visible = false;


    }
    #endregion
    #region QueryDMDOB
    private void SetImageQueryDMDOB()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMDOB.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMDOB.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMDOB.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMDOB.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMDOB.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMDOB.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMDOB()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMDOB.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMDOB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB2.Visible = false;
                PanelRaiseDMDOB3.Visible = false;
                PanelHideDMDOB.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMDOB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMDOB2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMDOB3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB2.Visible = true;
                PanelRaiseDMDOB3.Visible = true;
                PanelHideDMDOB.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMDOB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMDOB2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB2.Visible = true;
                PanelRaiseDMDOB3.Visible = false;
                PanelHideDMDOB.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMDOB_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMDOB = '" + TextBoxDMDOB.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMDOB.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMDOB.Visible = true;
                RAISEDMDOB.ShowPopupWindow();
                QueryRaiseDMDOB.Visible = false;
                TextBoxRaiseDMDOB.Visible = false;
                PanelRaiseDMDOB.Visible = false;
                PanelRaiseDMDOB2.Visible = false;
                PanelRaiseDMDOB3.Visible = false;

                LabelRespondDMDOB.Visible = false;
            }

            else if ((ImageQueryDMDOB.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMDOB.Visible = true;
                RAISEDMDOB.ShowPopupWindow();
                QueryRaiseDMDOB.Visible = true;
                TextBoxRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB2.Visible = false;
                PanelRaiseDMDOB3.Visible = false;
                LabelRespondDMDOB.Visible = true;
            }

            else if ((ImageQueryDMDOB.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMDOB.Visible = true;
                RAISEDMDOB.ShowPopupWindow();
                QueryRaiseDMDOB.Visible = false;
                TextBoxRaiseDMDOB.Visible = false;
                PanelRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB2.Visible = true;
                PanelRaiseDMDOB3.Visible = false;
                LabelRespondDMDOB.Visible = false;
            }
            else if ((ImageQueryDMDOB.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMDOB.Visible = true;
                RAISEDMDOB.ShowPopupWindow();
                QueryRaiseDMDOB.Visible = false;
                TextBoxRaiseDMDOB.Visible = false;
                PanelRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB2.Visible = true;
                PanelRaiseDMDOB3.Visible = true;
                LabelRespondDMDOB.Visible = false;
            }
            else
            {
                RAISEDMDOB.Visible = true;
                RAISEDMDOB.ShowPopupWindow();
                QueryRaiseDMDOB.Visible = false;
                TextBoxRaiseDMDOB.Visible = false;
                PanelRaiseDMDOB.Visible = true;
                PanelRaiseDMDOB2.Visible = true;
                PanelRaiseDMDOB3.Visible = true;
                LabelRespondDMDOB.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMDOB_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMDOB.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMDOB.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMDOB.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMDOB = '" + TextBoxDMDOB.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMDOBMSG.ShowPopupWindow();
        RAISEDMDOB.Visible = false;


    }
    #endregion
    #region QueryDMAGE
    private void SetImageQueryDMAGE()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMAGE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMAGE.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMAGE.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMAGE.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMAGE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMAGE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMAGE()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMAGE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMAGE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE2.Visible = false;
                PanelRaiseDMAGE3.Visible = false;
                PanelHideDMAGE.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMAGE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMAGE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMAGE3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE2.Visible = true;
                PanelRaiseDMAGE3.Visible = true;
                PanelHideDMAGE.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMAGE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMAGE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE2.Visible = true;
                PanelRaiseDMAGE3.Visible = false;
                PanelHideDMAGE.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMAGE_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMAGE = '" + TextBoxDMAGE.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMAGE.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMAGE.Visible = true;
                RAISEDMAGE.ShowPopupWindow();
                QueryRaiseDMAGE.Visible = false;
                TextBoxRaiseDMAGE.Visible = false;
                PanelRaiseDMAGE.Visible = false;
                PanelRaiseDMAGE2.Visible = false;
                PanelRaiseDMAGE3.Visible = false;

                LabelRespondDMAGE.Visible = false;
            }

            else if ((ImageQueryDMAGE.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMAGE.Visible = true;
                RAISEDMAGE.ShowPopupWindow();
                QueryRaiseDMAGE.Visible = true;
                TextBoxRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE2.Visible = false;
                PanelRaiseDMAGE3.Visible = false;
                LabelRespondDMAGE.Visible = true;
            }

            else if ((ImageQueryDMAGE.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMAGE.Visible = true;
                RAISEDMAGE.ShowPopupWindow();
                QueryRaiseDMAGE.Visible = false;
                TextBoxRaiseDMAGE.Visible = false;
                PanelRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE2.Visible = true;
                PanelRaiseDMAGE3.Visible = false;
                LabelRespondDMAGE.Visible = false;
            }
            else if ((ImageQueryDMAGE.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMAGE.Visible = true;
                RAISEDMAGE.ShowPopupWindow();
                QueryRaiseDMAGE.Visible = false;
                TextBoxRaiseDMAGE.Visible = false;
                PanelRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE2.Visible = true;
                PanelRaiseDMAGE3.Visible = true;
                LabelRespondDMAGE.Visible = false;
            }
            else
            {
                RAISEDMAGE.Visible = true;
                RAISEDMAGE.ShowPopupWindow();
                QueryRaiseDMAGE.Visible = false;
                TextBoxRaiseDMAGE.Visible = false;
                PanelRaiseDMAGE.Visible = true;
                PanelRaiseDMAGE2.Visible = true;
                PanelRaiseDMAGE3.Visible = true;
                LabelRespondDMAGE.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMAGE_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMAGE.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMAGE.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMAGE.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMAGE = '" + TextBoxDMAGE.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMAGEMSG.ShowPopupWindow();
        RAISEDMAGE.Visible = false;


    }
    #endregion
    #region QueryDMRACE
    private void SetImageQueryDMRACE()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMRACE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMRACE.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMRACE.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMRACE.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMRACE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMRACE.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMRACE()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMRACE.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMRACE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE2.Visible = false;
                PanelRaiseDMRACE3.Visible = false;
                PanelHideDMRACE.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMRACE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMRACE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMRACE3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE2.Visible = true;
                PanelRaiseDMRACE3.Visible = true;
                PanelHideDMRACE.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMRACE.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMRACE2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE2.Visible = true;
                PanelRaiseDMRACE3.Visible = false;
                PanelHideDMRACE.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMRACE_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMRACE = '" + RadioButtonListDMRACE.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMRACE.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMRACE.Visible = true;
                RAISEDMRACE.ShowPopupWindow();
                QueryRaiseDMRACE.Visible = false;
                TextBoxRaiseDMRACE.Visible = false;
                PanelRaiseDMRACE.Visible = false;
                PanelRaiseDMRACE2.Visible = false;
                PanelRaiseDMRACE3.Visible = false;

                LabelRespondDMRACE.Visible = false;
            }

            else if ((ImageQueryDMRACE.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMRACE.Visible = true;
                RAISEDMRACE.ShowPopupWindow();
                QueryRaiseDMRACE.Visible = true;
                TextBoxRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE2.Visible = false;
                PanelRaiseDMRACE3.Visible = false;
                LabelRespondDMRACE.Visible = true;
            }

            else if ((ImageQueryDMRACE.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMRACE.Visible = true;
                RAISEDMRACE.ShowPopupWindow();
                QueryRaiseDMRACE.Visible = false;
                TextBoxRaiseDMRACE.Visible = false;
                PanelRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE2.Visible = true;
                PanelRaiseDMRACE3.Visible = false;
                LabelRespondDMRACE.Visible = false;
            }
            else if ((ImageQueryDMRACE.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMRACE.Visible = true;
                RAISEDMRACE.ShowPopupWindow();
                QueryRaiseDMRACE.Visible = false;
                TextBoxRaiseDMRACE.Visible = false;
                PanelRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE2.Visible = true;
                PanelRaiseDMRACE3.Visible = true;
                LabelRespondDMRACE.Visible = false;
            }
            else
            {
                RAISEDMRACE.Visible = true;
                RAISEDMRACE.ShowPopupWindow();
                QueryRaiseDMRACE.Visible = false;
                TextBoxRaiseDMRACE.Visible = false;
                PanelRaiseDMRACE.Visible = true;
                PanelRaiseDMRACE2.Visible = true;
                PanelRaiseDMRACE3.Visible = true;
                LabelRespondDMRACE.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMRACE_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMRACE.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMRACE.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMRACE.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMRACE = '" + RadioButtonListDMRACE.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMRACEMSG.ShowPopupWindow();
        RAISEDMRACE.Visible = false;


    }
    #endregion
    #region QueryDMSPY
    private void SetImageQueryDMSPY()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMSPY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDMSPY.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDMSPY.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDMSPY.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryDMSPY.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDMSPY.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataDMSPY()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMSPY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDMSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY2.Visible = false;
                PanelRaiseDMSPY3.Visible = false;
                PanelHideDMSPY.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDMSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseDMSPY3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY2.Visible = true;
                PanelRaiseDMSPY3.Visible = true;
                PanelHideDMSPY.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDMSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDMSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY2.Visible = true;
                PanelRaiseDMSPY3.Visible = false;
                PanelHideDMSPY.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryDMSPY_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMSPY = '" + TextBoxDMSPY.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDMSPY.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDMSPY.Visible = true;
                RAISEDMSPY.ShowPopupWindow();
                QueryRaiseDMSPY.Visible = false;
                TextBoxRaiseDMSPY.Visible = false;
                PanelRaiseDMSPY.Visible = false;
                PanelRaiseDMSPY2.Visible = false;
                PanelRaiseDMSPY3.Visible = false;

                LabelRespondDMSPY.Visible = false;
            }

            else if ((ImageQueryDMSPY.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMSPY.Visible = true;
                RAISEDMSPY.ShowPopupWindow();
                QueryRaiseDMSPY.Visible = true;
                TextBoxRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY2.Visible = false;
                PanelRaiseDMSPY3.Visible = false;
                LabelRespondDMSPY.Visible = true;
            }

            else if ((ImageQueryDMSPY.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMSPY.Visible = true;
                RAISEDMSPY.ShowPopupWindow();
                QueryRaiseDMSPY.Visible = false;
                TextBoxRaiseDMSPY.Visible = false;
                PanelRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY2.Visible = true;
                PanelRaiseDMSPY3.Visible = false;
                LabelRespondDMSPY.Visible = false;
            }
            else if ((ImageQueryDMSPY.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDMSPY.Visible = true;
                RAISEDMSPY.ShowPopupWindow();
                QueryRaiseDMSPY.Visible = false;
                TextBoxRaiseDMSPY.Visible = false;
                PanelRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY2.Visible = true;
                PanelRaiseDMSPY3.Visible = true;
                LabelRespondDMSPY.Visible = false;
            }
            else
            {
                RAISEDMSPY.Visible = true;
                RAISEDMSPY.ShowPopupWindow();
                QueryRaiseDMSPY.Visible = false;
                TextBoxRaiseDMSPY.Visible = false;
                PanelRaiseDMSPY.Visible = true;
                PanelRaiseDMSPY2.Visible = true;
                PanelRaiseDMSPY3.Visible = true;
                LabelRespondDMSPY.Visible = false;

            }
        }

    }
    protected void QueryRaiseDMSPY_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseDMSPY.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMSPY.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDMSPY.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMSPY = '" + TextBoxDMSPY.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDMSPYMSG.ShowPopupWindow();
        RAISEDMSPY.Visible = false;


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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMHEIGHT = '" + TextBoxDMHEIGHT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMHEIGHT = '" + TextBoxDMHEIGHT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMWEIGHT = '" + TextBoxDMWEIGHT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMWEIGHT = '" + TextBoxDMWEIGHT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Demographics] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMBMI = '" + TextBoxDMBMI.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[Demographics] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DMBMI = '" + TextBoxDMBMI.Text + "'", con1);

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

    #region DOB

    // Constants for validation
    private const int MIN_AGE = 18;
    private const int MAX_AGE = 99;
    private const string DATE_FORMAT_PATTERN = @"^(([0-9])|([0-2][0-9])|([3][0-1]))\-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\-\d{4}$";

    // User-friendly messages
    private const string MSG_INVALID_DATE = "Invalid date format. Please use DD-MMM-YYYY format.";
    private const string MSG_FILL_ICF_FIRST = "Please complete the Date Of Patient Visit And ICF page first.";
    private const string MSG_ICF_DATE_REQUIRED = "Date of Informed Consent is required.";
    private const string MSG_DOB_AFTER_ICF = "Date of Birth must be before Date of Informed Consent.";
    private const string MSG_AGE_REQUIREMENT = "Age must be between {0} years or older.";
    private const string MSG_INVALID_NUMERIC = "Please enter valid numeric values for weight and height.";

    protected void TextBoxDMDOB_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextBoxDMDOB.Text))
        {
            ClearAgeFields();
            return;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(TextBoxDMDOB.Text, DATE_FORMAT_PATTERN))
        {
            ShowError(lbldob, MSG_INVALID_DATE);
            Submit.Visible = false;
            return;
        }

        lbldob.Visible = false;
        CalculateAndValidateAge();
    }

    protected void CalculateAndValidateAge()
    {
        TextBoxDMAGE.Text = string.Empty;

        if (string.IsNullOrWhiteSpace(TextBoxDMDOB.Text))
        {
            return;
        }

        DateTime dateOfBirth;
        if (!DateTime.TryParse(TextBoxDMDOB.Text, out dateOfBirth))
        {
            ShowError(lbldob, MSG_INVALID_DATE);
            Submit.Visible = false;
            return;
        }

        string icfDate = GetInformedConsentDate();
        
        if (icfDate == null)
        {
            ShowError(lbldob, MSG_FILL_ICF_FIRST);
            Submit.Visible = false;
            return;
        }

        if (string.IsNullOrEmpty(icfDate))
        {
            ShowError(lbldob, MSG_ICF_DATE_REQUIRED);
            Submit.Visible = false;
            return;
        }

        DateTime informedConsentDate;
        if (!DateTime.TryParse(icfDate, out informedConsentDate))
        {
            ShowError(lbldob, MSG_INVALID_DATE);
            Submit.Visible = false;
            return;
        }

        if (informedConsentDate <= dateOfBirth)
        {
            ShowError(lbldob, MSG_DOB_AFTER_ICF);
            Submit.Visible = false;
            return;
        }

        DisplayAgeCalculation(dateOfBirth, informedConsentDate);
        ValidateAgeRequirement();
    }

    private string GetInformedConsentDate()
    {
        string query = "SELECT [SVDIC] FROM [Visit1].[DateOfPatientVisitAndICF] " +
                       "WHERE [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'";

        try
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SiteNum", Request.QueryString["a"] ?? string.Empty);
                command.Parameters.AddWithValue("@SubNum", Request.QueryString["b"] ?? string.Empty);
                command.Parameters.AddWithValue("@SubIni", Request.QueryString["c"] ?? string.Empty);

                connection.Open();
                object result = command.ExecuteScalar();
                
                if (result == null)
                {
                    return null; // No record found
                }

                return result.ToString();
            }
        }
        catch (SqlException ex)
        {
            // Log error here
            System.Diagnostics.Debug.WriteLine("Database error: " + ex.Message);
            return null;
        }
    }

    private void DisplayAgeCalculation(DateTime dateOfBirth, DateTime referenceDate)
    {
        int years = CalculateYears(dateOfBirth, referenceDate);
        int months = CalculateMonths(dateOfBirth, referenceDate, years);
        int days = CalculateDays(dateOfBirth, referenceDate, years, months);

        lbldob.Visible = true;
        lbldob.ForeColor = System.Drawing.Color.Green;
        lbldob.Text = string.Format("{0} Years {1} Months {2} Days", years, months, days);
        TextBoxDMAGE.Text = years.ToString();
    }

    private int CalculateYears(DateTime dateOfBirth, DateTime referenceDate)
    {
        int years = referenceDate.Year - dateOfBirth.Year;
        
        if (referenceDate.Month < dateOfBirth.Month || 
            (referenceDate.Month == dateOfBirth.Month && referenceDate.Day < dateOfBirth.Day))
        {
            years--;
        }
        
        return years;
    }

    private int CalculateMonths(DateTime dateOfBirth, DateTime referenceDate, int years)
    {
        DateTime pastYearDate = dateOfBirth.AddYears(years);
        int months = 0;

        for (int i = 1; i <= 12; i++)
        {
            DateTime testDate = pastYearDate.AddMonths(i);
            
            if (testDate >= referenceDate)
            {
                months = (testDate == referenceDate) ? i : i - 1;
                break;
            }
        }

        return months;
    }

    private int CalculateDays(DateTime dateOfBirth, DateTime referenceDate, int years, int months)
    {
        DateTime pastYearDate = dateOfBirth.AddYears(years).AddMonths(months);
        return referenceDate.Subtract(pastYearDate).Days;
    }

    private void ValidateAgeRequirement()
    {
        if (string.IsNullOrWhiteSpace(TextBoxDMAGE.Text))
        {
            return;
        }

        int age;
        if (!int.TryParse(TextBoxDMAGE.Text, out age))
        {
            ShowError(lblAge, "Invalid age value.");
            Submit.Visible = false;
            return;
        }

        if (age < MIN_AGE || age > MAX_AGE)
        {
            ShowError(lblAge, string.Format(MSG_AGE_REQUIREMENT, MIN_AGE, MAX_AGE));
            Submit.Visible = false;
        }
        else
        {
            lblAge.Visible = false;
            Submit.Visible = true;
        }
    }

    private void ClearAgeFields()
    {
        TextBoxDMDOB.Text = null;
        TextBoxDMAGE.Text = null;
    }

    private void ShowError(Label label, string message)
    {
        label.Visible = true;
        label.ForeColor = System.Drawing.Color.Red;
        label.Text = message;
    }

    #endregion

    #region BMI

    public void Bmi1()
    {
        if (string.IsNullOrWhiteSpace(TextBoxDMWEIGHT.Text) || 
            string.IsNullOrWhiteSpace(TextBoxDMHEIGHT.Text))
        {
            ClearBmiFields();
        }
    }

    public void Bmi()
    {
        double weight, height;

        if (!double.TryParse(TextBoxDMWEIGHT.Text, out weight) || 
            !double.TryParse(TextBoxDMHEIGHT.Text, out height))
        {
            // Consider adding a label to show this error message
            System.Diagnostics.Debug.WriteLine(MSG_INVALID_NUMERIC);
            return;
        }

        if (height <= 0)
        {
            System.Diagnostics.Debug.WriteLine("Height must be greater than zero.");
            return;
        }

        double heightInMeters = height / 100.0;
        double bmi = weight / (heightInMeters * heightInMeters);
        TextBoxDMBMI.Text = Math.Round(bmi, 2).ToString("F2");
    }

    private void ClearBmiFields()
    {
        TextBoxDMWEIGHT.Text = null;
        TextBoxDMHEIGHT.Text = null;
        TextBoxDMBMI.Text = null;
    }

    #endregion

    protected void RadioButtonListDMRACE_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListDMRACE.SelectedValue == "Other")
        {
            hideDMSPY.Visible = true;
        }
        else
        {
            hideDMSPY.Visible = false;
            TextBoxDMSPY.Text = string.Empty;
        }
    }
}