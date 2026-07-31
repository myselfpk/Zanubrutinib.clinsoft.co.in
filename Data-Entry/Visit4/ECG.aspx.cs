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

public partial class Data_Entry_Visit4_ECG : System.Web.UI.Page
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

        SetImageQueryECGPER();
        SetImageQueryECGRSN();
        SetImageQueryECGDT();
        SetImageQueryECGTM();
        SetImageQueryECGNAB();
        SetImageQueryECG1OPT();
        SetImageQueryECG2OPT();
        SetImageQueryECG3OPT();
        SetImageQueryECG4OPT();

        BindQueryDataECGPER();
        BindQueryDataECGRSN();
        BindQueryDataECGDT();
        BindQueryDataECGTM();
        BindQueryDataECGNAB();
        BindQueryDataECG1OPT();
        BindQueryDataECG2OPT();
        BindQueryDataECG3OPT();
        BindQueryDataECG4OPT();

        ShowHide();

        TextBoxECGDT_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select ECGPER , ECGRSN , ECGDT , ECGTM , ECGNAB , ECG1OPT, ECG2OPT, ECG3OPT, ECG4OPT from [Visit4].[ECG] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListECGPER.SelectedValue = dt.Rows[0]["ECGPER"].ToString().Trim();
            TextBoxECGRSN.Text = dt.Rows[0]["ECGRSN"].ToString().Trim();
            TextBoxECGDT.Text = dt.Rows[0]["ECGDT"].ToString().Trim();
            TextBoxECGTM.Text = dt.Rows[0]["ECGTM"].ToString().Trim();
            RadioButtonListECGNAB.SelectedValue = dt.Rows[0]["ECGNAB"].ToString().Trim();
            TextBoxECG1OPT.Text = dt.Rows[0]["ECG1OPT"].ToString().Trim();
            TextBoxECG2OPT.Text = dt.Rows[0]["ECG2OPT"].ToString().Trim();
            TextBoxECG3OPT.Text = dt.Rows[0]["ECG3OPT"].ToString().Trim();
            TextBoxECG4OPT.Text = dt.Rows[0]["ECG4OPT"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListECGPER.SelectedValue;
            ViewState["txt2"] = TextBoxECGRSN.Text;
            ViewState["txt3"] = TextBoxECGDT.Text;
            ViewState["txt4"] = TextBoxECGTM.Text;
            ViewState["txt5"] = RadioButtonListECGNAB.SelectedValue;
            ViewState["txt6"] = TextBoxECG1OPT.Text;
            ViewState["txt7"] = TextBoxECG2OPT.Text;
            ViewState["txt8"] = TextBoxECG3OPT.Text;
            ViewState["txt9"] = TextBoxECG4OPT.Text;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit4].[ECG] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit4].[ECG] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit4].[sp_ECG]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                    cmd.Parameters.AddWithValue("@ECGPER", RadioButtonListECGPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@ECGRSN", TextBoxECGRSN.Text);
                    cmd.Parameters.AddWithValue("@ECGDT", TextBoxECGDT.Text);
                    cmd.Parameters.AddWithValue("@ECGTM", TextBoxECGTM.Text);
                    cmd.Parameters.AddWithValue("@ECGNAB", RadioButtonListECGNAB.SelectedValue);
                    cmd.Parameters.AddWithValue("@ECG1OPT", TextBoxECG1OPT.Text);
                    cmd.Parameters.AddWithValue("@ECG2OPT", TextBoxECG2OPT.Text);
                    cmd.Parameters.AddWithValue("@ECG3OPT", TextBoxECG3OPT.Text);
                    cmd.Parameters.AddWithValue("@ECG4OPT", TextBoxECG4OPT.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit4].[ECG] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListECGPER.SelectedValue || ViewState["txt2"].ToString() != TextBoxECGRSN.Text || ViewState["txt3"].ToString() != TextBoxECGDT.Text || ViewState["txt4"].ToString() != TextBoxECGTM.Text || ViewState["txt5"].ToString() != RadioButtonListECGNAB.SelectedValue || ViewState["txt6"].ToString() != TextBoxECG1OPT.Text || ViewState["txt7"].ToString() != TextBoxECG2OPT.Text || ViewState["txt8"].ToString() != TextBoxECG3OPT.Text || ViewState["txt9"].ToString() != TextBoxECG4OPT.Text)
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
                cmd = new SqlCommand("[Visit4].[sp_ECG]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@ECGPER", RadioButtonListECGPER.SelectedValue);
                cmd.Parameters.AddWithValue("@ECGRSN", TextBoxECGRSN.Text);
                cmd.Parameters.AddWithValue("@ECGDT", TextBoxECGDT.Text);
                cmd.Parameters.AddWithValue("@ECGTM", TextBoxECGTM.Text);
                cmd.Parameters.AddWithValue("@ECGNAB", RadioButtonListECGNAB.SelectedValue);
                cmd.Parameters.AddWithValue("@ECG1OPT", TextBoxECG1OPT.Text);
                cmd.Parameters.AddWithValue("@ECG2OPT", TextBoxECG2OPT.Text);
                cmd.Parameters.AddWithValue("@ECG3OPT", TextBoxECG3OPT.Text);
                cmd.Parameters.AddWithValue("@ECG4OPT", TextBoxECG4OPT.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit4].[ECG] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit4].[sp_ECG]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@ECGPER", RadioButtonListECGPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@ECGRSN", TextBoxECGRSN.Text);
                    cmd.Parameters.AddWithValue("@ECGDT", TextBoxECGDT.Text);
                    cmd.Parameters.AddWithValue("@ECGTM", TextBoxECGTM.Text);
                    cmd.Parameters.AddWithValue("@ECGNAB", RadioButtonListECGNAB.SelectedValue);
                    cmd.Parameters.AddWithValue("@ECG1OPT", TextBoxECG1OPT.Text);
                    cmd.Parameters.AddWithValue("@ECG2OPT", TextBoxECG2OPT.Text);
                    cmd.Parameters.AddWithValue("@ECG3OPT", TextBoxECG3OPT.Text);
                    cmd.Parameters.AddWithValue("@ECG4OPT", TextBoxECG4OPT.Text);

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
                cmd = new SqlCommand("[Visit4].[sp_ECG]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@ECGPER", RadioButtonListECGPER.SelectedValue);
                cmd.Parameters.AddWithValue("@ECGRSN", TextBoxECGRSN.Text);
                cmd.Parameters.AddWithValue("@ECGDT", TextBoxECGDT.Text);
                cmd.Parameters.AddWithValue("@ECGTM", TextBoxECGTM.Text);
                cmd.Parameters.AddWithValue("@ECGNAB", RadioButtonListECGNAB.SelectedValue);
                cmd.Parameters.AddWithValue("@ECG1OPT", TextBoxECG1OPT.Text);
                cmd.Parameters.AddWithValue("@ECG2OPT", TextBoxECG2OPT.Text);
                cmd.Parameters.AddWithValue("@ECG3OPT", TextBoxECG3OPT.Text);
                cmd.Parameters.AddWithValue("@ECG4OPT", TextBoxECG4OPT.Text);

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
        if (!string.IsNullOrEmpty(RadioButtonListECGPER.SelectedValue) || !string.IsNullOrEmpty(TextBoxECGRSN.Text) || !string.IsNullOrEmpty(TextBoxECGDT.Text) || !string.IsNullOrEmpty(TextBoxECGTM.Text) || !string.IsNullOrEmpty(RadioButtonListECGNAB.SelectedValue) || !string.IsNullOrEmpty(TextBoxECG1OPT.Text) || !string.IsNullOrEmpty(TextBoxECG2OPT.Text) || !string.IsNullOrEmpty(TextBoxECG3OPT.Text) || !string.IsNullOrEmpty(TextBoxECG4OPT.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListECGPER.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECGPER.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListECGPER.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() != TextBoxECGRSN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECGRSN.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxECGRSN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() != TextBoxECGDT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECGDT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxECGDT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() != TextBoxECGTM.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECGTM.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxECGTM.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() != RadioButtonListECGNAB.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECGNAB.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListECGNAB.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() != TextBoxECG1OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECG1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxECG1OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() != TextBoxECG2OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECG2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = TextBoxECG2OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() != TextBoxECG3OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECG3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = TextBoxECG3OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() != TextBoxECG4OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblECG4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = TextBoxECG4OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit4].[sp_ECG]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@ECGPER", RadioButtonListECGPER.SelectedValue);
            cmd.Parameters.AddWithValue("@ECGRSN", TextBoxECGRSN.Text);
            cmd.Parameters.AddWithValue("@ECGDT", TextBoxECGDT.Text);
            cmd.Parameters.AddWithValue("@ECGTM", TextBoxECGTM.Text);
            cmd.Parameters.AddWithValue("@ECGNAB", RadioButtonListECGNAB.SelectedValue);
            cmd.Parameters.AddWithValue("@ECG1OPT", TextBoxECG1OPT.Text);
            cmd.Parameters.AddWithValue("@ECG2OPT", TextBoxECG2OPT.Text);
            cmd.Parameters.AddWithValue("@ECG3OPT", TextBoxECG3OPT.Text);
            cmd.Parameters.AddWithValue("@ECG4OPT", TextBoxECG4OPT.Text);

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
    #region QueryECGPER
    private void SetImageQueryECGPER()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGPER.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGPER.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGPER.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECGPER()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGPER.Visible = true;
                PanelRaiseECGPER2.Visible = false;
                PanelRaiseECGPER3.Visible = false;
                PanelHideECGPER.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECGPER3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGPER.Visible = true;
                PanelRaiseECGPER2.Visible = true;
                PanelRaiseECGPER3.Visible = true;
                PanelHideECGPER.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECGPER.Visible = true;
                PanelRaiseECGPER2.Visible = true;
                PanelRaiseECGPER3.Visible = false;
                PanelHideECGPER.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECGPER_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGPER = '" + RadioButtonListECGPER.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGPER.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGPER.Visible = true;
                RAISEECGPER.ShowPopupWindow();
                QueryRaiseECGPER.Visible = false;
                TextBoxRaiseECGPER.Visible = false;
                PanelRaiseECGPER.Visible = false;
                PanelRaiseECGPER2.Visible = false;
                PanelRaiseECGPER3.Visible = false;

                LabelRespondECGPER.Visible = false;
            }

            else if ((ImageQueryECGPER.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGPER.Visible = true;
                RAISEECGPER.ShowPopupWindow();
                QueryRaiseECGPER.Visible = true;
                TextBoxRaiseECGPER.Visible = true;
                PanelRaiseECGPER.Visible = true;
                PanelRaiseECGPER2.Visible = false;
                PanelRaiseECGPER3.Visible = false;
                LabelRespondECGPER.Visible = true;
            }

            else if ((ImageQueryECGPER.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGPER.Visible = true;
                RAISEECGPER.ShowPopupWindow();
                QueryRaiseECGPER.Visible = false;
                TextBoxRaiseECGPER.Visible = false;
                PanelRaiseECGPER.Visible = true;
                PanelRaiseECGPER2.Visible = true;
                PanelRaiseECGPER3.Visible = false;
                LabelRespondECGPER.Visible = false;
            }
            else if ((ImageQueryECGPER.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGPER.Visible = true;
                RAISEECGPER.ShowPopupWindow();
                QueryRaiseECGPER.Visible = false;
                TextBoxRaiseECGPER.Visible = false;
                PanelRaiseECGPER.Visible = true;
                PanelRaiseECGPER2.Visible = true;
                PanelRaiseECGPER3.Visible = true;
                LabelRespondECGPER.Visible = false;
            }
            else
            {
                RAISEECGPER.Visible = true;
                RAISEECGPER.ShowPopupWindow();
                QueryRaiseECGPER.Visible = false;
                TextBoxRaiseECGPER.Visible = false;
                PanelRaiseECGPER.Visible = true;
                PanelRaiseECGPER2.Visible = true;
                PanelRaiseECGPER3.Visible = true;
                LabelRespondECGPER.Visible = false;

            }
        }

    }
    protected void QueryRaiseECGPER_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECGPER.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGPER.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGPER.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGPER = '" + RadioButtonListECGPER.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGPERMSG.ShowPopupWindow();
        RAISEECGPER.Visible = false;


    }
    #endregion
    #region QueryECGNAB
    private void SetImageQueryECGNAB()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGNAB.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGNAB.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGNAB.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGNAB.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGNAB.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGNAB.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECGNAB()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGNAB.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGNAB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB2.Visible = false;
                PanelRaiseECGNAB3.Visible = false;
                PanelHideECGNAB.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGNAB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGNAB2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECGNAB3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB2.Visible = true;
                PanelRaiseECGNAB3.Visible = true;
                PanelHideECGNAB.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGNAB.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGNAB2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB2.Visible = true;
                PanelRaiseECGNAB3.Visible = false;
                PanelHideECGNAB.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECGNAB_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGNAB = '" + RadioButtonListECGNAB.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGNAB.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGNAB.Visible = true;
                RAISEECGNAB.ShowPopupWindow();
                QueryRaiseECGNAB.Visible = false;
                TextBoxRaiseECGNAB.Visible = false;
                PanelRaiseECGNAB.Visible = false;
                PanelRaiseECGNAB2.Visible = false;
                PanelRaiseECGNAB3.Visible = false;

                LabelRespondECGNAB.Visible = false;
            }

            else if ((ImageQueryECGNAB.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGNAB.Visible = true;
                RAISEECGNAB.ShowPopupWindow();
                QueryRaiseECGNAB.Visible = true;
                TextBoxRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB2.Visible = false;
                PanelRaiseECGNAB3.Visible = false;
                LabelRespondECGNAB.Visible = true;
            }

            else if ((ImageQueryECGNAB.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGNAB.Visible = true;
                RAISEECGNAB.ShowPopupWindow();
                QueryRaiseECGNAB.Visible = false;
                TextBoxRaiseECGNAB.Visible = false;
                PanelRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB2.Visible = true;
                PanelRaiseECGNAB3.Visible = false;
                LabelRespondECGNAB.Visible = false;
            }
            else if ((ImageQueryECGNAB.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGNAB.Visible = true;
                RAISEECGNAB.ShowPopupWindow();
                QueryRaiseECGNAB.Visible = false;
                TextBoxRaiseECGNAB.Visible = false;
                PanelRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB2.Visible = true;
                PanelRaiseECGNAB3.Visible = true;
                LabelRespondECGNAB.Visible = false;
            }
            else
            {
                RAISEECGNAB.Visible = true;
                RAISEECGNAB.ShowPopupWindow();
                QueryRaiseECGNAB.Visible = false;
                TextBoxRaiseECGNAB.Visible = false;
                PanelRaiseECGNAB.Visible = true;
                PanelRaiseECGNAB2.Visible = true;
                PanelRaiseECGNAB3.Visible = true;
                LabelRespondECGNAB.Visible = false;

            }
        }

    }
    protected void QueryRaiseECGNAB_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECGNAB.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGNAB.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGNAB.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGNAB = '" + RadioButtonListECGNAB.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGNABMSG.ShowPopupWindow();
        RAISEECGNAB.Visible = false;


    }
    #endregion
    #region QueryECGRSN
    private void SetImageQueryECGRSN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGRSN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGRSN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGRSN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGRSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGRSN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECGRSN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGRSN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN2.Visible = false;
                PanelRaiseECGRSN3.Visible = false;
                PanelHideECGRSN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECGRSN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN2.Visible = true;
                PanelRaiseECGRSN3.Visible = true;
                PanelHideECGRSN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGRSN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGRSN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN2.Visible = true;
                PanelRaiseECGRSN3.Visible = false;
                PanelHideECGRSN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECGRSN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGRSN = '" + TextBoxECGRSN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGRSN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGRSN.Visible = true;
                RAISEECGRSN.ShowPopupWindow();
                QueryRaiseECGRSN.Visible = false;
                TextBoxRaiseECGRSN.Visible = false;
                PanelRaiseECGRSN.Visible = false;
                PanelRaiseECGRSN2.Visible = false;
                PanelRaiseECGRSN3.Visible = false;

                LabelRespondECGRSN.Visible = false;
            }

            else if ((ImageQueryECGRSN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGRSN.Visible = true;
                RAISEECGRSN.ShowPopupWindow();
                QueryRaiseECGRSN.Visible = true;
                TextBoxRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN2.Visible = false;
                PanelRaiseECGRSN3.Visible = false;
                LabelRespondECGRSN.Visible = true;
            }

            else if ((ImageQueryECGRSN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGRSN.Visible = true;
                RAISEECGRSN.ShowPopupWindow();
                QueryRaiseECGRSN.Visible = false;
                TextBoxRaiseECGRSN.Visible = false;
                PanelRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN2.Visible = true;
                PanelRaiseECGRSN3.Visible = false;
                LabelRespondECGRSN.Visible = false;
            }
            else if ((ImageQueryECGRSN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGRSN.Visible = true;
                RAISEECGRSN.ShowPopupWindow();
                QueryRaiseECGRSN.Visible = false;
                TextBoxRaiseECGRSN.Visible = false;
                PanelRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN2.Visible = true;
                PanelRaiseECGRSN3.Visible = true;
                LabelRespondECGRSN.Visible = false;
            }
            else
            {
                RAISEECGRSN.Visible = true;
                RAISEECGRSN.ShowPopupWindow();
                QueryRaiseECGRSN.Visible = false;
                TextBoxRaiseECGRSN.Visible = false;
                PanelRaiseECGRSN.Visible = true;
                PanelRaiseECGRSN2.Visible = true;
                PanelRaiseECGRSN3.Visible = true;
                LabelRespondECGRSN.Visible = false;

            }
        }

    }
    protected void QueryRaiseECGRSN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECGRSN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGRSN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGRSN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGRSN = '" + TextBoxECGRSN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGRSNMSG.ShowPopupWindow();
        RAISEECGRSN.Visible = false;


    }
    #endregion
    #region QueryECGDT
    private void SetImageQueryECGDT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGDT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGDT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGDT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGDT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECGDT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGDT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGDT.Visible = true;
                PanelRaiseECGDT2.Visible = false;
                PanelRaiseECGDT3.Visible = false;
                PanelHideECGDT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECGDT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGDT.Visible = true;
                PanelRaiseECGDT2.Visible = true;
                PanelRaiseECGDT3.Visible = true;
                PanelHideECGDT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGDT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGDT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECGDT.Visible = true;
                PanelRaiseECGDT2.Visible = true;
                PanelRaiseECGDT3.Visible = false;
                PanelHideECGDT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECGDT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGDT = '" + TextBoxECGDT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGDT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGDT.Visible = true;
                RAISEECGDT.ShowPopupWindow();
                QueryRaiseECGDT.Visible = false;
                TextBoxRaiseECGDT.Visible = false;
                PanelRaiseECGDT.Visible = false;
                PanelRaiseECGDT2.Visible = false;
                PanelRaiseECGDT3.Visible = false;

                LabelRespondECGDT.Visible = false;
            }

            else if ((ImageQueryECGDT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGDT.Visible = true;
                RAISEECGDT.ShowPopupWindow();
                QueryRaiseECGDT.Visible = true;
                TextBoxRaiseECGDT.Visible = true;
                PanelRaiseECGDT.Visible = true;
                PanelRaiseECGDT2.Visible = false;
                PanelRaiseECGDT3.Visible = false;
                LabelRespondECGDT.Visible = true;
            }

            else if ((ImageQueryECGDT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGDT.Visible = true;
                RAISEECGDT.ShowPopupWindow();
                QueryRaiseECGDT.Visible = false;
                TextBoxRaiseECGDT.Visible = false;
                PanelRaiseECGDT.Visible = true;
                PanelRaiseECGDT2.Visible = true;
                PanelRaiseECGDT3.Visible = false;
                LabelRespondECGDT.Visible = false;
            }
            else if ((ImageQueryECGDT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGDT.Visible = true;
                RAISEECGDT.ShowPopupWindow();
                QueryRaiseECGDT.Visible = false;
                TextBoxRaiseECGDT.Visible = false;
                PanelRaiseECGDT.Visible = true;
                PanelRaiseECGDT2.Visible = true;
                PanelRaiseECGDT3.Visible = true;
                LabelRespondECGDT.Visible = false;
            }
            else
            {
                RAISEECGDT.Visible = true;
                RAISEECGDT.ShowPopupWindow();
                QueryRaiseECGDT.Visible = false;
                TextBoxRaiseECGDT.Visible = false;
                PanelRaiseECGDT.Visible = true;
                PanelRaiseECGDT2.Visible = true;
                PanelRaiseECGDT3.Visible = true;
                LabelRespondECGDT.Visible = false;

            }
        }

    }
    protected void QueryRaiseECGDT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECGDT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGDT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGDT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGDT = '" + TextBoxECGDT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGDTMSG.ShowPopupWindow();
        RAISEECGDT.Visible = false;


    }
    #endregion
    #region QueryECGTM
    private void SetImageQueryECGTM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGTM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECGTM.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECGTM.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECGTM.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECGTM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECGTM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECGTM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGTM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECGTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECGTM.Visible = true;
                PanelRaiseECGTM2.Visible = false;
                PanelRaiseECGTM3.Visible = false;
                PanelHideECGTM.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECGTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECGTM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECGTM.Visible = true;
                PanelRaiseECGTM2.Visible = true;
                PanelRaiseECGTM3.Visible = true;
                PanelHideECGTM.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECGTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECGTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECGTM.Visible = true;
                PanelRaiseECGTM2.Visible = true;
                PanelRaiseECGTM3.Visible = false;
                PanelHideECGTM.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECGTM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGTM = '" + TextBoxECGTM.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECGTM.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECGTM.Visible = true;
                RAISEECGTM.ShowPopupWindow();
                QueryRaiseECGTM.Visible = false;
                TextBoxRaiseECGTM.Visible = false;
                PanelRaiseECGTM.Visible = false;
                PanelRaiseECGTM2.Visible = false;
                PanelRaiseECGTM3.Visible = false;

                LabelRespondECGTM.Visible = false;
            }

            else if ((ImageQueryECGTM.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGTM.Visible = true;
                RAISEECGTM.ShowPopupWindow();
                QueryRaiseECGTM.Visible = true;
                TextBoxRaiseECGTM.Visible = true;
                PanelRaiseECGTM.Visible = true;
                PanelRaiseECGTM2.Visible = false;
                PanelRaiseECGTM3.Visible = false;
                LabelRespondECGTM.Visible = true;
            }

            else if ((ImageQueryECGTM.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGTM.Visible = true;
                RAISEECGTM.ShowPopupWindow();
                QueryRaiseECGTM.Visible = false;
                TextBoxRaiseECGTM.Visible = false;
                PanelRaiseECGTM.Visible = true;
                PanelRaiseECGTM2.Visible = true;
                PanelRaiseECGTM3.Visible = false;
                LabelRespondECGTM.Visible = false;
            }
            else if ((ImageQueryECGTM.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECGTM.Visible = true;
                RAISEECGTM.ShowPopupWindow();
                QueryRaiseECGTM.Visible = false;
                TextBoxRaiseECGTM.Visible = false;
                PanelRaiseECGTM.Visible = true;
                PanelRaiseECGTM2.Visible = true;
                PanelRaiseECGTM3.Visible = true;
                LabelRespondECGTM.Visible = false;
            }
            else
            {
                RAISEECGTM.Visible = true;
                RAISEECGTM.ShowPopupWindow();
                QueryRaiseECGTM.Visible = false;
                TextBoxRaiseECGTM.Visible = false;
                PanelRaiseECGTM.Visible = true;
                PanelRaiseECGTM2.Visible = true;
                PanelRaiseECGTM3.Visible = true;
                LabelRespondECGTM.Visible = false;

            }
        }

    }
    protected void QueryRaiseECGTM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECGTM.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGTM.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECGTM.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECGTM = '" + TextBoxECGTM.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECGTMMSG.ShowPopupWindow();
        RAISEECGTM.Visible = false;


    }
    #endregion
    #region QueryECG1OPT
    private void SetImageQueryECG1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG1OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG1OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG1OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECG1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT2.Visible = false;
                PanelRaiseECG1OPT3.Visible = false;
                PanelHideECG1OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECG1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT2.Visible = true;
                PanelRaiseECG1OPT3.Visible = true;
                PanelHideECG1OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT2.Visible = true;
                PanelRaiseECG1OPT3.Visible = false;
                PanelHideECG1OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECG1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG1OPT = '" + TextBoxECG1OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG1OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG1OPT.Visible = true;
                RAISEECG1OPT.ShowPopupWindow();
                QueryRaiseECG1OPT.Visible = false;
                TextBoxRaiseECG1OPT.Visible = false;
                PanelRaiseECG1OPT.Visible = false;
                PanelRaiseECG1OPT2.Visible = false;
                PanelRaiseECG1OPT3.Visible = false;

                LabelRespondECG1OPT.Visible = false;
            }

            else if ((ImageQueryECG1OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG1OPT.Visible = true;
                RAISEECG1OPT.ShowPopupWindow();
                QueryRaiseECG1OPT.Visible = true;
                TextBoxRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT2.Visible = false;
                PanelRaiseECG1OPT3.Visible = false;
                LabelRespondECG1OPT.Visible = true;
            }

            else if ((ImageQueryECG1OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG1OPT.Visible = true;
                RAISEECG1OPT.ShowPopupWindow();
                QueryRaiseECG1OPT.Visible = false;
                TextBoxRaiseECG1OPT.Visible = false;
                PanelRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT2.Visible = true;
                PanelRaiseECG1OPT3.Visible = false;
                LabelRespondECG1OPT.Visible = false;
            }
            else if ((ImageQueryECG1OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG1OPT.Visible = true;
                RAISEECG1OPT.ShowPopupWindow();
                QueryRaiseECG1OPT.Visible = false;
                TextBoxRaiseECG1OPT.Visible = false;
                PanelRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT2.Visible = true;
                PanelRaiseECG1OPT3.Visible = true;
                LabelRespondECG1OPT.Visible = false;
            }
            else
            {
                RAISEECG1OPT.Visible = true;
                RAISEECG1OPT.ShowPopupWindow();
                QueryRaiseECG1OPT.Visible = false;
                TextBoxRaiseECG1OPT.Visible = false;
                PanelRaiseECG1OPT.Visible = true;
                PanelRaiseECG1OPT2.Visible = true;
                PanelRaiseECG1OPT3.Visible = true;
                LabelRespondECG1OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseECG1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECG1OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG1OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG1OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG1OPT = '" + TextBoxECG1OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG1OPTMSG.ShowPopupWindow();
        RAISEECG1OPT.Visible = false;


    }
    #endregion
    #region QueryECG2OPT
    private void SetImageQueryECG2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG2OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG2OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG2OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECG2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT2.Visible = false;
                PanelRaiseECG2OPT3.Visible = false;
                PanelHideECG2OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECG2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT2.Visible = true;
                PanelRaiseECG2OPT3.Visible = true;
                PanelHideECG2OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT2.Visible = true;
                PanelRaiseECG2OPT3.Visible = false;
                PanelHideECG2OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECG2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG2OPT = '" + TextBoxECG2OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG2OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG2OPT.Visible = true;
                RAISEECG2OPT.ShowPopupWindow();
                QueryRaiseECG2OPT.Visible = false;
                TextBoxRaiseECG2OPT.Visible = false;
                PanelRaiseECG2OPT.Visible = false;
                PanelRaiseECG2OPT2.Visible = false;
                PanelRaiseECG2OPT3.Visible = false;

                LabelRespondECG2OPT.Visible = false;
            }

            else if ((ImageQueryECG2OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG2OPT.Visible = true;
                RAISEECG2OPT.ShowPopupWindow();
                QueryRaiseECG2OPT.Visible = true;
                TextBoxRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT2.Visible = false;
                PanelRaiseECG2OPT3.Visible = false;
                LabelRespondECG2OPT.Visible = true;
            }

            else if ((ImageQueryECG2OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG2OPT.Visible = true;
                RAISEECG2OPT.ShowPopupWindow();
                QueryRaiseECG2OPT.Visible = false;
                TextBoxRaiseECG2OPT.Visible = false;
                PanelRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT2.Visible = true;
                PanelRaiseECG2OPT3.Visible = false;
                LabelRespondECG2OPT.Visible = false;
            }
            else if ((ImageQueryECG2OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG2OPT.Visible = true;
                RAISEECG2OPT.ShowPopupWindow();
                QueryRaiseECG2OPT.Visible = false;
                TextBoxRaiseECG2OPT.Visible = false;
                PanelRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT2.Visible = true;
                PanelRaiseECG2OPT3.Visible = true;
                LabelRespondECG2OPT.Visible = false;
            }
            else
            {
                RAISEECG2OPT.Visible = true;
                RAISEECG2OPT.ShowPopupWindow();
                QueryRaiseECG2OPT.Visible = false;
                TextBoxRaiseECG2OPT.Visible = false;
                PanelRaiseECG2OPT.Visible = true;
                PanelRaiseECG2OPT2.Visible = true;
                PanelRaiseECG2OPT3.Visible = true;
                LabelRespondECG2OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseECG2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECG2OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG2OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG2OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG2OPT = '" + TextBoxECG2OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG2OPTMSG.ShowPopupWindow();
        RAISEECG2OPT.Visible = false;


    }
    #endregion
    #region QueryECG3OPT
    private void SetImageQueryECG3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG3OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG3OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG3OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECG3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT2.Visible = false;
                PanelRaiseECG3OPT3.Visible = false;
                PanelHideECG3OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECG3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT2.Visible = true;
                PanelRaiseECG3OPT3.Visible = true;
                PanelHideECG3OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT2.Visible = true;
                PanelRaiseECG3OPT3.Visible = false;
                PanelHideECG3OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECG3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG3OPT = '" + TextBoxECG3OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG3OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG3OPT.Visible = true;
                RAISEECG3OPT.ShowPopupWindow();
                QueryRaiseECG3OPT.Visible = false;
                TextBoxRaiseECG3OPT.Visible = false;
                PanelRaiseECG3OPT.Visible = false;
                PanelRaiseECG3OPT2.Visible = false;
                PanelRaiseECG3OPT3.Visible = false;

                LabelRespondECG3OPT.Visible = false;
            }

            else if ((ImageQueryECG3OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG3OPT.Visible = true;
                RAISEECG3OPT.ShowPopupWindow();
                QueryRaiseECG3OPT.Visible = true;
                TextBoxRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT2.Visible = false;
                PanelRaiseECG3OPT3.Visible = false;
                LabelRespondECG3OPT.Visible = true;
            }

            else if ((ImageQueryECG3OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG3OPT.Visible = true;
                RAISEECG3OPT.ShowPopupWindow();
                QueryRaiseECG3OPT.Visible = false;
                TextBoxRaiseECG3OPT.Visible = false;
                PanelRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT2.Visible = true;
                PanelRaiseECG3OPT3.Visible = false;
                LabelRespondECG3OPT.Visible = false;
            }
            else if ((ImageQueryECG3OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG3OPT.Visible = true;
                RAISEECG3OPT.ShowPopupWindow();
                QueryRaiseECG3OPT.Visible = false;
                TextBoxRaiseECG3OPT.Visible = false;
                PanelRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT2.Visible = true;
                PanelRaiseECG3OPT3.Visible = true;
                LabelRespondECG3OPT.Visible = false;
            }
            else
            {
                RAISEECG3OPT.Visible = true;
                RAISEECG3OPT.ShowPopupWindow();
                QueryRaiseECG3OPT.Visible = false;
                TextBoxRaiseECG3OPT.Visible = false;
                PanelRaiseECG3OPT.Visible = true;
                PanelRaiseECG3OPT2.Visible = true;
                PanelRaiseECG3OPT3.Visible = true;
                LabelRespondECG3OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseECG3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECG3OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG3OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG3OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG3OPT = '" + TextBoxECG3OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG3OPTMSG.ShowPopupWindow();
        RAISEECG3OPT.Visible = false;


    }
    #endregion
    #region QueryECG4OPT
    private void SetImageQueryECG4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryECG4OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryECG4OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryECG4OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryECG4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryECG4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataECG4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseECG4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT2.Visible = false;
                PanelRaiseECG4OPT3.Visible = false;
                PanelHideECG4OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseECG4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseECG4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT2.Visible = true;
                PanelRaiseECG4OPT3.Visible = true;
                PanelHideECG4OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseECG4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseECG4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT2.Visible = true;
                PanelRaiseECG4OPT3.Visible = false;
                PanelHideECG4OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryECG4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit4].[ECG] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4OPT = '" + TextBoxECG4OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryECG4OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEECG4OPT.Visible = true;
                RAISEECG4OPT.ShowPopupWindow();
                QueryRaiseECG4OPT.Visible = false;
                TextBoxRaiseECG4OPT.Visible = false;
                PanelRaiseECG4OPT.Visible = false;
                PanelRaiseECG4OPT2.Visible = false;
                PanelRaiseECG4OPT3.Visible = false;

                LabelRespondECG4OPT.Visible = false;
            }

            else if ((ImageQueryECG4OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG4OPT.Visible = true;
                RAISEECG4OPT.ShowPopupWindow();
                QueryRaiseECG4OPT.Visible = true;
                TextBoxRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT2.Visible = false;
                PanelRaiseECG4OPT3.Visible = false;
                LabelRespondECG4OPT.Visible = true;
            }

            else if ((ImageQueryECG4OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG4OPT.Visible = true;
                RAISEECG4OPT.ShowPopupWindow();
                QueryRaiseECG4OPT.Visible = false;
                TextBoxRaiseECG4OPT.Visible = false;
                PanelRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT2.Visible = true;
                PanelRaiseECG4OPT3.Visible = false;
                LabelRespondECG4OPT.Visible = false;
            }
            else if ((ImageQueryECG4OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEECG4OPT.Visible = true;
                RAISEECG4OPT.ShowPopupWindow();
                QueryRaiseECG4OPT.Visible = false;
                TextBoxRaiseECG4OPT.Visible = false;
                PanelRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT2.Visible = true;
                PanelRaiseECG4OPT3.Visible = true;
                LabelRespondECG4OPT.Visible = false;
            }
            else
            {
                RAISEECG4OPT.Visible = true;
                RAISEECG4OPT.ShowPopupWindow();
                QueryRaiseECG4OPT.Visible = false;
                TextBoxRaiseECG4OPT.Visible = false;
                PanelRaiseECG4OPT.Visible = true;
                PanelRaiseECG4OPT2.Visible = true;
                PanelRaiseECG4OPT3.Visible = true;
                LabelRespondECG4OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseECG4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseECG4OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblECG4OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit4].[ECG] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ECG4OPT = '" + TextBoxECG4OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEECG4OPTMSG.ShowPopupWindow();
        RAISEECG4OPT.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListECGPER.SelectedValue == "Yes")
        {
            hideECGPER.Visible = true;
            hideECGRSN.Visible = false;
        }
        else if (RadioButtonListECGPER.SelectedValue == "No")
        {
            hideECGPER.Visible = false;
            hideECGRSN.Visible = true;
        }
        else
        {
            hideECGPER.Visible = false;
            hideECGRSN.Visible = false;
        }
    }
    protected void RadioButtonListECGPER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListECGPER.SelectedValue == "Yes")
        {
            hideECGPER.Visible = true;
            hideECGRSN.Visible = false;
            TextBoxECGRSN.Text = string.Empty;
        }
        else if (RadioButtonListECGPER.SelectedValue == "No")
        {
            hideECGPER.Visible = false;
            hideECGRSN.Visible = true;
            TextBoxECGDT.Text = string.Empty;
            TextBoxECGTM.Text = string.Empty;
            RadioButtonListECGNAB.ClearSelection();
            TextBoxECG1OPT.Text = string.Empty;
            TextBoxECG2OPT.Text = string.Empty;
            TextBoxECG3OPT.Text = string.Empty;
            TextBoxECG4OPT.Text = string.Empty;
        }
        else
        {
            hideECGPER.Visible = false;
            hideECGRSN.Visible = false;
            TextBoxECGRSN.Text = string.Empty;
            TextBoxECGDT.Text = string.Empty;
            TextBoxECGTM.Text = string.Empty;
            RadioButtonListECGNAB.ClearSelection();
            TextBoxECG1OPT.Text = string.Empty;
            TextBoxECG2OPT.Text = string.Empty;
            TextBoxECG3OPT.Text = string.Empty;
            TextBoxECG4OPT.Text = string.Empty;
        }
    }

}