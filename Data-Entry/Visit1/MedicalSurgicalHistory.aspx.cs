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

public partial class Data_Entry_Visit1_MedicalSurgicalHistory : System.Web.UI.Page
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

        SetImageQueryMSHYN();
        SetImageQueryMH1COND();
        SetImageQueryMH2COND();
        SetImageQueryMH3COND();
        SetImageQueryMH4COND();
        SetImageQueryMH5COND();
        BindQueryDataMSHYN();
        BindQueryDataMH1COND();
        BindQueryDataMH2COND();
        BindQueryDataMH3COND();
        BindQueryDataMH4COND();
        BindQueryDataMH5COND();

        ShowHide();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select MSHYN , MH1COND , MH1OD , MH1ONGO , MH1ED , MH2COND , MH2OD , MH2ONGO , MH2ED , MH3COND , MH3OD , MH3ONGO , MH3ED , MH4COND , MH4OD , MH4ONGO , MH4ED , MH5COND , MH5OD , MH5ONGO , MH5ED from [Visit1].[MedicalSurgicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListMSHYN.SelectedValue = dt.Rows[0]["MSHYN"].ToString().Trim();
            TextBoxMH1COND.Text = dt.Rows[0]["MH1COND"].ToString().Trim();
            TextBoxMH1OD.Text = dt.Rows[0]["MH1OD"].ToString().Trim();
            RadioButtonListMH1ONGO.SelectedValue = dt.Rows[0]["MH1ONGO"].ToString().Trim();
            TextBoxMH1ED.Text = dt.Rows[0]["MH1ED"].ToString().Trim();
            TextBoxMH2COND.Text = dt.Rows[0]["MH2COND"].ToString().Trim();
            TextBoxMH2OD.Text = dt.Rows[0]["MH2OD"].ToString().Trim();
            RadioButtonListMH2ONGO.SelectedValue = dt.Rows[0]["MH2ONGO"].ToString().Trim();
            TextBoxMH2ED.Text = dt.Rows[0]["MH2ED"].ToString().Trim();
            TextBoxMH3COND.Text = dt.Rows[0]["MH3COND"].ToString().Trim();
            TextBoxMH3OD.Text = dt.Rows[0]["MH3OD"].ToString().Trim();
            RadioButtonListMH3ONGO.SelectedValue = dt.Rows[0]["MH3ONGO"].ToString().Trim();
            TextBoxMH3ED.Text = dt.Rows[0]["MH3ED"].ToString().Trim();
            TextBoxMH4COND.Text = dt.Rows[0]["MH4COND"].ToString().Trim();
            TextBoxMH4OD.Text = dt.Rows[0]["MH4OD"].ToString().Trim();
            RadioButtonListMH4ONGO.SelectedValue = dt.Rows[0]["MH4ONGO"].ToString().Trim();
            TextBoxMH4ED.Text = dt.Rows[0]["MH4ED"].ToString().Trim();
            TextBoxMH5COND.Text = dt.Rows[0]["MH5COND"].ToString().Trim();
            TextBoxMH5OD.Text = dt.Rows[0]["MH5OD"].ToString().Trim();
            RadioButtonListMH5ONGO.SelectedValue = dt.Rows[0]["MH5ONGO"].ToString().Trim();
            TextBoxMH5ED.Text = dt.Rows[0]["MH5ED"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListMSHYN.SelectedValue;
            ViewState["txt2"] = TextBoxMH1COND.Text;
            ViewState["txt3"] = TextBoxMH1OD.Text;
            ViewState["txt4"] = RadioButtonListMH1ONGO.SelectedValue;
            ViewState["txt5"] = TextBoxMH1ED.Text;
            ViewState["txt6"] = TextBoxMH2COND.Text;
            ViewState["txt7"] = TextBoxMH2OD.Text;
            ViewState["txt8"] = RadioButtonListMH2ONGO.SelectedValue;
            ViewState["txt9"] = TextBoxMH2ED.Text;
            ViewState["txt10"] = TextBoxMH3COND.Text;
            ViewState["txt11"] = TextBoxMH3OD.Text;
            ViewState["txt12"] = RadioButtonListMH3ONGO.SelectedValue;
            ViewState["txt13"] = TextBoxMH3ED.Text;
            ViewState["txt14"] = TextBoxMH4COND.Text;
            ViewState["txt15"] = TextBoxMH4OD.Text;
            ViewState["txt16"] = RadioButtonListMH4ONGO.SelectedValue;
            ViewState["txt17"] = TextBoxMH4ED.Text;
            ViewState["txt18"] = TextBoxMH5COND.Text;
            ViewState["txt19"] = TextBoxMH5OD.Text;
            ViewState["txt20"] = RadioButtonListMH5ONGO.SelectedValue;
            ViewState["txt21"] = TextBoxMH5ED.Text;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[MedicalSurgicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[MedicalSurgicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_MedicalSurgicalHistory]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@MSHYN", RadioButtonListMSHYN.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH1COND", TextBoxMH1COND.Text);
                    cmd.Parameters.AddWithValue("@MH1OD", TextBoxMH1OD.Text);
                    cmd.Parameters.AddWithValue("@MH1ONGO", RadioButtonListMH1ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH1ED", TextBoxMH1ED.Text);
                    cmd.Parameters.AddWithValue("@MH2COND", TextBoxMH2COND.Text);
                    cmd.Parameters.AddWithValue("@MH2OD", TextBoxMH2OD.Text);
                    cmd.Parameters.AddWithValue("@MH2ONGO", RadioButtonListMH2ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH2ED", TextBoxMH2ED.Text);
                    cmd.Parameters.AddWithValue("@MH3COND", TextBoxMH3COND.Text);
                    cmd.Parameters.AddWithValue("@MH3OD", TextBoxMH3OD.Text);
                    cmd.Parameters.AddWithValue("@MH3ONGO", RadioButtonListMH3ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH3ED", TextBoxMH3ED.Text);
                    cmd.Parameters.AddWithValue("@MH4COND", TextBoxMH4COND.Text);
                    cmd.Parameters.AddWithValue("@MH4OD", TextBoxMH4OD.Text);
                    cmd.Parameters.AddWithValue("@MH4ONGO", RadioButtonListMH4ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH4ED", TextBoxMH4ED.Text);
                    cmd.Parameters.AddWithValue("@MH5COND", TextBoxMH5COND.Text);
                    cmd.Parameters.AddWithValue("@MH5OD", TextBoxMH5OD.Text);
                    cmd.Parameters.AddWithValue("@MH5ONGO", RadioButtonListMH5ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH5ED", TextBoxMH5ED.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[MedicalSurgicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListMSHYN.SelectedValue || ViewState["txt2"].ToString() != TextBoxMH1COND.Text || ViewState["txt3"].ToString() != TextBoxMH1OD.Text || ViewState["txt4"].ToString() != RadioButtonListMH1ONGO.SelectedValue || ViewState["txt5"].ToString() != TextBoxMH1ED.Text || ViewState["txt6"].ToString() != TextBoxMH2COND.Text || ViewState["txt7"].ToString() != TextBoxMH2OD.Text || ViewState["txt8"].ToString() != RadioButtonListMH2ONGO.SelectedValue || ViewState["txt9"].ToString() != TextBoxMH2ED.Text || ViewState["txt10"].ToString() != TextBoxMH3COND.Text || ViewState["txt11"].ToString() != TextBoxMH3OD.Text || ViewState["txt12"].ToString() != RadioButtonListMH3ONGO.SelectedValue || ViewState["txt13"].ToString() != TextBoxMH3ED.Text || ViewState["txt14"].ToString() != TextBoxMH4COND.Text || ViewState["txt15"].ToString() != TextBoxMH4OD.Text || ViewState["txt16"].ToString() != RadioButtonListMH4ONGO.SelectedValue || ViewState["txt17"].ToString() != TextBoxMH4ED.Text || ViewState["txt18"].ToString() != TextBoxMH5COND.Text || ViewState["txt19"].ToString() != TextBoxMH5OD.Text || ViewState["txt20"].ToString() != RadioButtonListMH5ONGO.SelectedValue || ViewState["txt21"].ToString() != TextBoxMH5ED.Text)
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
                cmd = new SqlCommand("[Visit1].[sp_MedicalSurgicalHistory]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@MSHYN", RadioButtonListMSHYN.SelectedValue);
                cmd.Parameters.AddWithValue("@MH1COND", TextBoxMH1COND.Text);
                cmd.Parameters.AddWithValue("@MH1OD", TextBoxMH1OD.Text);
                cmd.Parameters.AddWithValue("@MH1ONGO", RadioButtonListMH1ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH1ED", TextBoxMH1ED.Text);
                cmd.Parameters.AddWithValue("@MH2COND", TextBoxMH2COND.Text);
                cmd.Parameters.AddWithValue("@MH2OD", TextBoxMH2OD.Text);
                cmd.Parameters.AddWithValue("@MH2ONGO", RadioButtonListMH2ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH2ED", TextBoxMH2ED.Text);
                cmd.Parameters.AddWithValue("@MH3COND", TextBoxMH3COND.Text);
                cmd.Parameters.AddWithValue("@MH3OD", TextBoxMH3OD.Text);
                cmd.Parameters.AddWithValue("@MH3ONGO", RadioButtonListMH3ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH3ED", TextBoxMH3ED.Text);
                cmd.Parameters.AddWithValue("@MH4COND", TextBoxMH4COND.Text);
                cmd.Parameters.AddWithValue("@MH4OD", TextBoxMH4OD.Text);
                cmd.Parameters.AddWithValue("@MH4ONGO", RadioButtonListMH4ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH4ED", TextBoxMH4ED.Text);
                cmd.Parameters.AddWithValue("@MH5COND", TextBoxMH5COND.Text);
                cmd.Parameters.AddWithValue("@MH5OD", TextBoxMH5OD.Text);
                cmd.Parameters.AddWithValue("@MH5ONGO", RadioButtonListMH5ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH5ED", TextBoxMH5ED.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[MedicalSurgicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_MedicalSurgicalHistory]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@MSHYN", RadioButtonListMSHYN.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH1COND", TextBoxMH1COND.Text);
                    cmd.Parameters.AddWithValue("@MH1OD", TextBoxMH1OD.Text);
                    cmd.Parameters.AddWithValue("@MH1ONGO", RadioButtonListMH1ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH1ED", TextBoxMH1ED.Text);
                    cmd.Parameters.AddWithValue("@MH2COND", TextBoxMH2COND.Text);
                    cmd.Parameters.AddWithValue("@MH2OD", TextBoxMH2OD.Text);
                    cmd.Parameters.AddWithValue("@MH2ONGO", RadioButtonListMH2ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH2ED", TextBoxMH2ED.Text);
                    cmd.Parameters.AddWithValue("@MH3COND", TextBoxMH3COND.Text);
                    cmd.Parameters.AddWithValue("@MH3OD", TextBoxMH3OD.Text);
                    cmd.Parameters.AddWithValue("@MH3ONGO", RadioButtonListMH3ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH3ED", TextBoxMH3ED.Text);
                    cmd.Parameters.AddWithValue("@MH4COND", TextBoxMH4COND.Text);
                    cmd.Parameters.AddWithValue("@MH4OD", TextBoxMH4OD.Text);
                    cmd.Parameters.AddWithValue("@MH4ONGO", RadioButtonListMH4ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH4ED", TextBoxMH4ED.Text);
                    cmd.Parameters.AddWithValue("@MH5COND", TextBoxMH5COND.Text);
                    cmd.Parameters.AddWithValue("@MH5OD", TextBoxMH5OD.Text);
                    cmd.Parameters.AddWithValue("@MH5ONGO", RadioButtonListMH5ONGO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MH5ED", TextBoxMH5ED.Text);

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
                cmd = new SqlCommand("[Visit1].[sp_MedicalSurgicalHistory]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@MSHYN", RadioButtonListMSHYN.SelectedValue);
                cmd.Parameters.AddWithValue("@MH1COND", TextBoxMH1COND.Text);
                cmd.Parameters.AddWithValue("@MH1OD", TextBoxMH1OD.Text);
                cmd.Parameters.AddWithValue("@MH1ONGO", RadioButtonListMH1ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH1ED", TextBoxMH1ED.Text);
                cmd.Parameters.AddWithValue("@MH2COND", TextBoxMH2COND.Text);
                cmd.Parameters.AddWithValue("@MH2OD", TextBoxMH2OD.Text);
                cmd.Parameters.AddWithValue("@MH2ONGO", RadioButtonListMH2ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH2ED", TextBoxMH2ED.Text);
                cmd.Parameters.AddWithValue("@MH3COND", TextBoxMH3COND.Text);
                cmd.Parameters.AddWithValue("@MH3OD", TextBoxMH3OD.Text);
                cmd.Parameters.AddWithValue("@MH3ONGO", RadioButtonListMH3ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH3ED", TextBoxMH3ED.Text);
                cmd.Parameters.AddWithValue("@MH4COND", TextBoxMH4COND.Text);
                cmd.Parameters.AddWithValue("@MH4OD", TextBoxMH4OD.Text);
                cmd.Parameters.AddWithValue("@MH4ONGO", RadioButtonListMH4ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH4ED", TextBoxMH4ED.Text);
                cmd.Parameters.AddWithValue("@MH5COND", TextBoxMH5COND.Text);
                cmd.Parameters.AddWithValue("@MH5OD", TextBoxMH5OD.Text);
                cmd.Parameters.AddWithValue("@MH5ONGO", RadioButtonListMH5ONGO.SelectedValue);
                cmd.Parameters.AddWithValue("@MH5ED", TextBoxMH5ED.Text);

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
        if (!string.IsNullOrEmpty(RadioButtonListMSHYN.SelectedValue) || !string.IsNullOrEmpty(TextBoxMH1COND.Text) || !string.IsNullOrEmpty(TextBoxMH1OD.Text) || !string.IsNullOrEmpty(RadioButtonListMH1ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxMH1ED.Text) || !string.IsNullOrEmpty(TextBoxMH2COND.Text) || !string.IsNullOrEmpty(TextBoxMH2OD.Text) || !string.IsNullOrEmpty(RadioButtonListMH2ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxMH2ED.Text) || !string.IsNullOrEmpty(TextBoxMH3COND.Text) || !string.IsNullOrEmpty(TextBoxMH3OD.Text) || !string.IsNullOrEmpty(RadioButtonListMH3ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxMH3ED.Text) || !string.IsNullOrEmpty(TextBoxMH4COND.Text) || !string.IsNullOrEmpty(TextBoxMH4OD.Text) || !string.IsNullOrEmpty(RadioButtonListMH4ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxMH4ED.Text) || !string.IsNullOrEmpty(TextBoxMH5COND.Text) || !string.IsNullOrEmpty(TextBoxMH5OD.Text) || !string.IsNullOrEmpty(RadioButtonListMH5ONGO.SelectedValue) || !string.IsNullOrEmpty(TextBoxMH5ED.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() !=  RadioButtonListMSHYN.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMSHYN.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListMSHYN.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() !=  TextBoxMH1COND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH1COND.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxMH1COND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() !=  TextBoxMH1OD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH1OD.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxMH1OD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() !=  RadioButtonListMH1ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH1ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListMH1ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() !=  TextBoxMH1ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH1ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxMH1ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() !=  TextBoxMH2COND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH2COND.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxMH2COND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() !=  TextBoxMH2OD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH2OD.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = TextBoxMH2OD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() !=  RadioButtonListMH2ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH2ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListMH2ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() !=  TextBoxMH2ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH2ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = TextBoxMH2ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != TextBoxMH3COND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH3COND.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = TextBoxMH3COND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != TextBoxMH3OD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH3OD.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = TextBoxMH3OD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != RadioButtonListMH3ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH3ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = RadioButtonListMH3ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != TextBoxMH3ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH3ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = TextBoxMH3ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString() != TextBoxMH4COND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH4COND.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = TextBoxMH4COND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString() != TextBoxMH4OD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH4OD.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = TextBoxMH4OD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt16"].ToString() != RadioButtonListMH4ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH4ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][15];
                dtrow["NewValue"] = RadioButtonListMH4ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt17"].ToString() != TextBoxMH4ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH4ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][16];
                dtrow["NewValue"] = TextBoxMH4ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt18"].ToString() != TextBoxMH5COND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH5COND.Text;
                dtrow["OldValue"] = dt1.Rows[0][17];
                dtrow["NewValue"] = TextBoxMH5COND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt19"].ToString() != TextBoxMH5OD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH5OD.Text;
                dtrow["OldValue"] = dt1.Rows[0][18];
                dtrow["NewValue"] = TextBoxMH5OD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt20"].ToString() != RadioButtonListMH5ONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH5ONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][19];
                dtrow["NewValue"] = RadioButtonListMH5ONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt21"].ToString() != TextBoxMH5ED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblMH5ED.Text;
                dtrow["OldValue"] = dt1.Rows[0][20];
                dtrow["NewValue"] = TextBoxMH5ED.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_MedicalSurgicalHistory]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@MSHYN", RadioButtonListMSHYN.SelectedValue);
            cmd.Parameters.AddWithValue("@MH1COND", TextBoxMH1COND.Text);
            cmd.Parameters.AddWithValue("@MH1OD", TextBoxMH1OD.Text);
            cmd.Parameters.AddWithValue("@MH1ONGO", RadioButtonListMH1ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@MH1ED", TextBoxMH1ED.Text);
            cmd.Parameters.AddWithValue("@MH2COND", TextBoxMH2COND.Text);
            cmd.Parameters.AddWithValue("@MH2OD", TextBoxMH2OD.Text);
            cmd.Parameters.AddWithValue("@MH2ONGO", RadioButtonListMH2ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@MH2ED", TextBoxMH2ED.Text);
            cmd.Parameters.AddWithValue("@MH3COND", TextBoxMH3COND.Text);
            cmd.Parameters.AddWithValue("@MH3OD", TextBoxMH3OD.Text);
            cmd.Parameters.AddWithValue("@MH3ONGO", RadioButtonListMH3ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@MH3ED", TextBoxMH3ED.Text);
            cmd.Parameters.AddWithValue("@MH4COND", TextBoxMH4COND.Text);
            cmd.Parameters.AddWithValue("@MH4OD", TextBoxMH4OD.Text);
            cmd.Parameters.AddWithValue("@MH4ONGO", RadioButtonListMH4ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@MH4ED", TextBoxMH4ED.Text);
            cmd.Parameters.AddWithValue("@MH5COND", TextBoxMH5COND.Text);
            cmd.Parameters.AddWithValue("@MH5OD", TextBoxMH5OD.Text);
            cmd.Parameters.AddWithValue("@MH5ONGO", RadioButtonListMH5ONGO.SelectedValue);
            cmd.Parameters.AddWithValue("@MH5ED", TextBoxMH5ED.Text);

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
    #region QueryMSHYN
    private void SetImageQueryMSHYN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHYN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMSHYN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMSHYN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMSHYN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMSHYN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMSHYN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMSHYN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHYN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMSHYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN2.Visible = false;
                PanelRaiseMSHYN3.Visible = false;
                PanelHideMSHYN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMSHYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMSHYN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN2.Visible = true;
                PanelRaiseMSHYN3.Visible = true;
                PanelHideMSHYN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMSHYN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHYN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN2.Visible = true;
                PanelRaiseMSHYN3.Visible = false;
                PanelHideMSHYN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMSHYN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalSurgicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHYN = '" + RadioButtonListMSHYN.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMSHYN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMSHYN.Visible = true;
                RAISEMSHYN.ShowPopupWindow();
                QueryRaiseMSHYN.Visible = false;
                TextBoxRaiseMSHYN.Visible = false;
                PanelRaiseMSHYN.Visible = false;
                PanelRaiseMSHYN2.Visible = false;
                PanelRaiseMSHYN3.Visible = false;

                LabelRespondMSHYN.Visible = false;
            }

            else if ((ImageQueryMSHYN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHYN.Visible = true;
                RAISEMSHYN.ShowPopupWindow();
                QueryRaiseMSHYN.Visible = true;
                TextBoxRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN2.Visible = false;
                PanelRaiseMSHYN3.Visible = false;
                LabelRespondMSHYN.Visible = true;
            }

            else if ((ImageQueryMSHYN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHYN.Visible = true;
                RAISEMSHYN.ShowPopupWindow();
                QueryRaiseMSHYN.Visible = false;
                TextBoxRaiseMSHYN.Visible = false;
                PanelRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN2.Visible = true;
                PanelRaiseMSHYN3.Visible = false;
                LabelRespondMSHYN.Visible = false;
            }
            else if ((ImageQueryMSHYN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHYN.Visible = true;
                RAISEMSHYN.ShowPopupWindow();
                QueryRaiseMSHYN.Visible = false;
                TextBoxRaiseMSHYN.Visible = false;
                PanelRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN2.Visible = true;
                PanelRaiseMSHYN3.Visible = true;
                LabelRespondMSHYN.Visible = false;
            }
            else
            {
                RAISEMSHYN.Visible = true;
                RAISEMSHYN.ShowPopupWindow();
                QueryRaiseMSHYN.Visible = false;
                TextBoxRaiseMSHYN.Visible = false;
                PanelRaiseMSHYN.Visible = true;
                PanelRaiseMSHYN2.Visible = true;
                PanelRaiseMSHYN3.Visible = true;
                LabelRespondMSHYN.Visible = false;

            }
        }

    }
    protected void QueryRaiseMSHYN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseMSHYN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHYN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHYN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[MedicalSurgicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHYN = '" + RadioButtonListMSHYN.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMSHYNMSG.ShowPopupWindow();
        RAISEMSHYN.Visible = false;


    }
    #endregion
    #region QueryMH1COND
    private void SetImageQueryMH1COND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH1COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH1COND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH1COND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH1COND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH1COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH1COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMH1COND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH1COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH1COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND2.Visible = false;
                PanelRaiseMH1COND3.Visible = false;
                PanelHideMH1COND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH1COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH1COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMH1COND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND2.Visible = true;
                PanelRaiseMH1COND3.Visible = true;
                PanelHideMH1COND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH1COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH1COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND2.Visible = true;
                PanelRaiseMH1COND3.Visible = false;
                PanelHideMH1COND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMH1COND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalSurgicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH1COND = '" + TextBoxMH1COND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH1COND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH1COND.Visible = true;
                RAISEMH1COND.ShowPopupWindow();
                QueryRaiseMH1COND.Visible = false;
                TextBoxRaiseMH1COND.Visible = false;
                PanelRaiseMH1COND.Visible = false;
                PanelRaiseMH1COND2.Visible = false;
                PanelRaiseMH1COND3.Visible = false;

                LabelRespondMH1COND.Visible = false;
            }

            else if ((ImageQueryMH1COND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH1COND.Visible = true;
                RAISEMH1COND.ShowPopupWindow();
                QueryRaiseMH1COND.Visible = true;
                TextBoxRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND2.Visible = false;
                PanelRaiseMH1COND3.Visible = false;
                LabelRespondMH1COND.Visible = true;
            }

            else if ((ImageQueryMH1COND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH1COND.Visible = true;
                RAISEMH1COND.ShowPopupWindow();
                QueryRaiseMH1COND.Visible = false;
                TextBoxRaiseMH1COND.Visible = false;
                PanelRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND2.Visible = true;
                PanelRaiseMH1COND3.Visible = false;
                LabelRespondMH1COND.Visible = false;
            }
            else if ((ImageQueryMH1COND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH1COND.Visible = true;
                RAISEMH1COND.ShowPopupWindow();
                QueryRaiseMH1COND.Visible = false;
                TextBoxRaiseMH1COND.Visible = false;
                PanelRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND2.Visible = true;
                PanelRaiseMH1COND3.Visible = true;
                LabelRespondMH1COND.Visible = false;
            }
            else
            {
                RAISEMH1COND.Visible = true;
                RAISEMH1COND.ShowPopupWindow();
                QueryRaiseMH1COND.Visible = false;
                TextBoxRaiseMH1COND.Visible = false;
                PanelRaiseMH1COND.Visible = true;
                PanelRaiseMH1COND2.Visible = true;
                PanelRaiseMH1COND3.Visible = true;
                LabelRespondMH1COND.Visible = false;

            }
        }

    }
    protected void QueryRaiseMH1COND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseMH1COND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH1COND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH1COND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[MedicalSurgicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH1COND = '" + TextBoxMH1COND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH1CONDMSG.ShowPopupWindow();
        RAISEMH1COND.Visible = false;


    }
    #endregion
    #region QueryMH2COND
    private void SetImageQueryMH2COND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH2COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH2COND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH2COND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH2COND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH2COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH2COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMH2COND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH2COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH2COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND2.Visible = false;
                PanelRaiseMH2COND3.Visible = false;
                PanelHideMH2COND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH2COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH2COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMH2COND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND2.Visible = true;
                PanelRaiseMH2COND3.Visible = true;
                PanelHideMH2COND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH2COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH2COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND2.Visible = true;
                PanelRaiseMH2COND3.Visible = false;
                PanelHideMH2COND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMH2COND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalSurgicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH2COND = '" + TextBoxMH2COND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH2COND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH2COND.Visible = true;
                RAISEMH2COND.ShowPopupWindow();
                QueryRaiseMH2COND.Visible = false;
                TextBoxRaiseMH2COND.Visible = false;
                PanelRaiseMH2COND.Visible = false;
                PanelRaiseMH2COND2.Visible = false;
                PanelRaiseMH2COND3.Visible = false;

                LabelRespondMH2COND.Visible = false;
            }

            else if ((ImageQueryMH2COND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH2COND.Visible = true;
                RAISEMH2COND.ShowPopupWindow();
                QueryRaiseMH2COND.Visible = true;
                TextBoxRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND2.Visible = false;
                PanelRaiseMH2COND3.Visible = false;
                LabelRespondMH2COND.Visible = true;
            }

            else if ((ImageQueryMH2COND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH2COND.Visible = true;
                RAISEMH2COND.ShowPopupWindow();
                QueryRaiseMH2COND.Visible = false;
                TextBoxRaiseMH2COND.Visible = false;
                PanelRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND2.Visible = true;
                PanelRaiseMH2COND3.Visible = false;
                LabelRespondMH2COND.Visible = false;
            }
            else if ((ImageQueryMH2COND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH2COND.Visible = true;
                RAISEMH2COND.ShowPopupWindow();
                QueryRaiseMH2COND.Visible = false;
                TextBoxRaiseMH2COND.Visible = false;
                PanelRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND2.Visible = true;
                PanelRaiseMH2COND3.Visible = true;
                LabelRespondMH2COND.Visible = false;
            }
            else
            {
                RAISEMH2COND.Visible = true;
                RAISEMH2COND.ShowPopupWindow();
                QueryRaiseMH2COND.Visible = false;
                TextBoxRaiseMH2COND.Visible = false;
                PanelRaiseMH2COND.Visible = true;
                PanelRaiseMH2COND2.Visible = true;
                PanelRaiseMH2COND3.Visible = true;
                LabelRespondMH2COND.Visible = false;

            }
        }

    }
    protected void QueryRaiseMH2COND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseMH2COND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH2COND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH2COND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[MedicalSurgicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH2COND = '" + TextBoxMH2COND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH2CONDMSG.ShowPopupWindow();
        RAISEMH2COND.Visible = false;


    }
    #endregion
    #region QueryMH3COND
    private void SetImageQueryMH3COND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH3COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH3COND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH3COND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH3COND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH3COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH3COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMH3COND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH3COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH3COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND2.Visible = false;
                PanelRaiseMH3COND3.Visible = false;
                PanelHideMH3COND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH3COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH3COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMH3COND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND2.Visible = true;
                PanelRaiseMH3COND3.Visible = true;
                PanelHideMH3COND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH3COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH3COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND2.Visible = true;
                PanelRaiseMH3COND3.Visible = false;
                PanelHideMH3COND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMH3COND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalSurgicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH3COND = '" + TextBoxMH3COND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH3COND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH3COND.Visible = true;
                RAISEMH3COND.ShowPopupWindow();
                QueryRaiseMH3COND.Visible = false;
                TextBoxRaiseMH3COND.Visible = false;
                PanelRaiseMH3COND.Visible = false;
                PanelRaiseMH3COND2.Visible = false;
                PanelRaiseMH3COND3.Visible = false;

                LabelRespondMH3COND.Visible = false;
            }

            else if ((ImageQueryMH3COND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH3COND.Visible = true;
                RAISEMH3COND.ShowPopupWindow();
                QueryRaiseMH3COND.Visible = true;
                TextBoxRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND2.Visible = false;
                PanelRaiseMH3COND3.Visible = false;
                LabelRespondMH3COND.Visible = true;
            }

            else if ((ImageQueryMH3COND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH3COND.Visible = true;
                RAISEMH3COND.ShowPopupWindow();
                QueryRaiseMH3COND.Visible = false;
                TextBoxRaiseMH3COND.Visible = false;
                PanelRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND2.Visible = true;
                PanelRaiseMH3COND3.Visible = false;
                LabelRespondMH3COND.Visible = false;
            }
            else if ((ImageQueryMH3COND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH3COND.Visible = true;
                RAISEMH3COND.ShowPopupWindow();
                QueryRaiseMH3COND.Visible = false;
                TextBoxRaiseMH3COND.Visible = false;
                PanelRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND2.Visible = true;
                PanelRaiseMH3COND3.Visible = true;
                LabelRespondMH3COND.Visible = false;
            }
            else
            {
                RAISEMH3COND.Visible = true;
                RAISEMH3COND.ShowPopupWindow();
                QueryRaiseMH3COND.Visible = false;
                TextBoxRaiseMH3COND.Visible = false;
                PanelRaiseMH3COND.Visible = true;
                PanelRaiseMH3COND2.Visible = true;
                PanelRaiseMH3COND3.Visible = true;
                LabelRespondMH3COND.Visible = false;

            }
        }

    }
    protected void QueryRaiseMH3COND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseMH3COND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH3COND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH3COND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[MedicalSurgicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH3COND = '" + TextBoxMH3COND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH3CONDMSG.ShowPopupWindow();
        RAISEMH3COND.Visible = false;


    }
    #endregion
    #region QueryMH4COND
    private void SetImageQueryMH4COND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH4COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH4COND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH4COND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH4COND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH4COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH4COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMH4COND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH4COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH4COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND2.Visible = false;
                PanelRaiseMH4COND3.Visible = false;
                PanelHideMH4COND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH4COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH4COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMH4COND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND2.Visible = true;
                PanelRaiseMH4COND3.Visible = true;
                PanelHideMH4COND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH4COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH4COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND2.Visible = true;
                PanelRaiseMH4COND3.Visible = false;
                PanelHideMH4COND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMH4COND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalSurgicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH4COND = '" + TextBoxMH4COND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH4COND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH4COND.Visible = true;
                RAISEMH4COND.ShowPopupWindow();
                QueryRaiseMH4COND.Visible = false;
                TextBoxRaiseMH4COND.Visible = false;
                PanelRaiseMH4COND.Visible = false;
                PanelRaiseMH4COND2.Visible = false;
                PanelRaiseMH4COND3.Visible = false;

                LabelRespondMH4COND.Visible = false;
            }

            else if ((ImageQueryMH4COND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH4COND.Visible = true;
                RAISEMH4COND.ShowPopupWindow();
                QueryRaiseMH4COND.Visible = true;
                TextBoxRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND2.Visible = false;
                PanelRaiseMH4COND3.Visible = false;
                LabelRespondMH4COND.Visible = true;
            }

            else if ((ImageQueryMH4COND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH4COND.Visible = true;
                RAISEMH4COND.ShowPopupWindow();
                QueryRaiseMH4COND.Visible = false;
                TextBoxRaiseMH4COND.Visible = false;
                PanelRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND2.Visible = true;
                PanelRaiseMH4COND3.Visible = false;
                LabelRespondMH4COND.Visible = false;
            }
            else if ((ImageQueryMH4COND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH4COND.Visible = true;
                RAISEMH4COND.ShowPopupWindow();
                QueryRaiseMH4COND.Visible = false;
                TextBoxRaiseMH4COND.Visible = false;
                PanelRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND2.Visible = true;
                PanelRaiseMH4COND3.Visible = true;
                LabelRespondMH4COND.Visible = false;
            }
            else
            {
                RAISEMH4COND.Visible = true;
                RAISEMH4COND.ShowPopupWindow();
                QueryRaiseMH4COND.Visible = false;
                TextBoxRaiseMH4COND.Visible = false;
                PanelRaiseMH4COND.Visible = true;
                PanelRaiseMH4COND2.Visible = true;
                PanelRaiseMH4COND3.Visible = true;
                LabelRespondMH4COND.Visible = false;

            }
        }

    }
    protected void QueryRaiseMH4COND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseMH4COND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH4COND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH4COND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[MedicalSurgicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH4COND = '" + TextBoxMH4COND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH4CONDMSG.ShowPopupWindow();
        RAISEMH4COND.Visible = false;


    }
    #endregion
    #region QueryMH5COND
    private void SetImageQueryMH5COND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH5COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH5COND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH5COND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH5COND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH5COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH5COND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataMH5COND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH5COND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH5COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND2.Visible = false;
                PanelRaiseMH5COND3.Visible = false;
                PanelHideMH5COND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH5COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH5COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseMH5COND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND2.Visible = true;
                PanelRaiseMH5COND3.Visible = true;
                PanelHideMH5COND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH5COND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH5COND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND2.Visible = true;
                PanelRaiseMH5COND3.Visible = false;
                PanelHideMH5COND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryMH5COND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalSurgicalHistory] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH5COND = '" + TextBoxMH5COND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH5COND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH5COND.Visible = true;
                RAISEMH5COND.ShowPopupWindow();
                QueryRaiseMH5COND.Visible = false;
                TextBoxRaiseMH5COND.Visible = false;
                PanelRaiseMH5COND.Visible = false;
                PanelRaiseMH5COND2.Visible = false;
                PanelRaiseMH5COND3.Visible = false;

                LabelRespondMH5COND.Visible = false;
            }

            else if ((ImageQueryMH5COND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH5COND.Visible = true;
                RAISEMH5COND.ShowPopupWindow();
                QueryRaiseMH5COND.Visible = true;
                TextBoxRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND2.Visible = false;
                PanelRaiseMH5COND3.Visible = false;
                LabelRespondMH5COND.Visible = true;
            }

            else if ((ImageQueryMH5COND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH5COND.Visible = true;
                RAISEMH5COND.ShowPopupWindow();
                QueryRaiseMH5COND.Visible = false;
                TextBoxRaiseMH5COND.Visible = false;
                PanelRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND2.Visible = true;
                PanelRaiseMH5COND3.Visible = false;
                LabelRespondMH5COND.Visible = false;
            }
            else if ((ImageQueryMH5COND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH5COND.Visible = true;
                RAISEMH5COND.ShowPopupWindow();
                QueryRaiseMH5COND.Visible = false;
                TextBoxRaiseMH5COND.Visible = false;
                PanelRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND2.Visible = true;
                PanelRaiseMH5COND3.Visible = true;
                LabelRespondMH5COND.Visible = false;
            }
            else
            {
                RAISEMH5COND.Visible = true;
                RAISEMH5COND.ShowPopupWindow();
                QueryRaiseMH5COND.Visible = false;
                TextBoxRaiseMH5COND.Visible = false;
                PanelRaiseMH5COND.Visible = true;
                PanelRaiseMH5COND2.Visible = true;
                PanelRaiseMH5COND3.Visible = true;
                LabelRespondMH5COND.Visible = false;

            }
        }

    }
    protected void QueryRaiseMH5COND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseMH5COND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH5COND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH5COND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[MedicalSurgicalHistory] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH5COND = '" + TextBoxMH5COND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH5CONDMSG.ShowPopupWindow();
        RAISEMH5COND.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListMH1ONGO.SelectedValue == "Yes")
        {
            TextBoxMH1ED.Visible = true;
        }
        else
        {
            TextBoxMH1ED.Visible = false;
        }
        if (RadioButtonListMH2ONGO.SelectedValue == "Yes")
        {
            TextBoxMH2ED.Visible = true;
        }
        else
        {
            TextBoxMH2ED.Visible = false;
        }
        if (RadioButtonListMH3ONGO.SelectedValue == "Yes")
        {
            TextBoxMH3ED.Visible = true;
        }
        else
        {
            TextBoxMH3ED.Visible = false;
        }
        if (RadioButtonListMH4ONGO.SelectedValue == "Yes")
        {
            TextBoxMH4ED.Visible = true;
        }
        else
        {
            TextBoxMH4ED.Visible = false;
        }
        if (RadioButtonListMH5ONGO.SelectedValue == "Yes")
        {
            TextBoxMH5ED.Visible = true;
        }
        else
        {
            TextBoxMH5ED.Visible = false;
        }
        if (RadioButtonListMSHYN.SelectedValue == "Yes")
        {
            hideMSH.Visible = true;
        }
        else
        {
            hideMSH.Visible = false;
        }
    }

    protected void RadioButtonListMH1ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListMH1ONGO.SelectedValue == "Yes")
        {
            TextBoxMH1ED.Visible = true;
        }
        else
        {
            TextBoxMH1ED.Visible = false;
            TextBoxMH1ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListMH2ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListMH2ONGO.SelectedValue == "Yes")
        {
            TextBoxMH2ED.Visible = true;
        }
        else
        {
            TextBoxMH2ED.Visible = false;
            TextBoxMH2ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListMH3ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListMH3ONGO.SelectedValue == "Yes")
        {
            TextBoxMH3ED.Visible = true;
        }
        else
        {
            TextBoxMH3ED.Visible = false;
            TextBoxMH3ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListMH4ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListMH4ONGO.SelectedValue == "Yes")
        {
            TextBoxMH4ED.Visible = true;
        }
        else
        {
            TextBoxMH4ED.Visible = false;
            TextBoxMH4ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListMH5ONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListMH5ONGO.SelectedValue == "Yes")
        {
            TextBoxMH5ED.Visible = true;
        }
        else
        {
            TextBoxMH5ED.Visible = false;
            TextBoxMH5ED.Text = string.Empty;
        }
    }

    protected void RadioButtonListMSHYN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListMSHYN.SelectedValue == "Yes")
        {
            hideMSH.Visible = true;
        }
        else
        {
            hideMSH.Visible = false;
            TextBoxMH1COND.Text = string.Empty;
            TextBoxMH1OD.Text = string.Empty;
            RadioButtonListMH1ONGO.ClearSelection();
            TextBoxMH1ED.Text = string.Empty;

            TextBoxMH2COND.Text = string.Empty;
            TextBoxMH2OD.Text = string.Empty;
            RadioButtonListMH2ONGO.ClearSelection();
            TextBoxMH2ED.Text = string.Empty;

            TextBoxMH3COND.Text = string.Empty;
            TextBoxMH3OD.Text = string.Empty;
            RadioButtonListMH3ONGO.ClearSelection();
            TextBoxMH3ED.Text = string.Empty;

            TextBoxMH4COND.Text = string.Empty;
            TextBoxMH4OD.Text = string.Empty;
            RadioButtonListMH4ONGO.ClearSelection();
            TextBoxMH4ED.Text = string.Empty;

            TextBoxMH5COND.Text = string.Empty;
            TextBoxMH5OD.Text = string.Empty;
            RadioButtonListMH5ONGO.ClearSelection();
            TextBoxMH5ED.Text = string.Empty;
        }
    }
}