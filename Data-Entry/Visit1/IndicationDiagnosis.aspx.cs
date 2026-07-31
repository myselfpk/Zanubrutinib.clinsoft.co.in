using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Data_Entry_Visit1_IndicationDiagnosis : System.Web.UI.Page
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


        SetImageQueryIDDIA();
        SetImageQueryIDDCT();
        SetImageQueryIDSF();
        SetImageQueryIDDODYR();
        SetImageQueryIDDODMT();
        SetImageQueryIDAOM();
        SetImageQueryIDAOMSPY();
        SetImageQueryIDAOMYR();
        SetImageQueryIDCT();
        SetImageQueryIDCTFIND();
        SetImageQueryIDXRAY();
        SetImageQueryIDXRAYFIND();
        SetImageQueryIDUSG();
        SetImageQueryIDUSGFIND();
        SetImageQueryCSRSS();
        SetImageQueryCSBSS();
        SetImageQueryCSSH();
        SetImageQueryCSSHYR();
        SetImageQueryCSAUH();
        SetImageQueryCSAUHYR();

        BindQueryDataIDDIA();
        BindQueryDataIDDCT();
        BindQueryDataIDSF();
        BindQueryDataIDDODYR();
        BindQueryDataIDDODMT();
        BindQueryDataIDAOM();
        BindQueryDataIDAOMSPY();
        BindQueryDataIDAOMYR();
        BindQueryDataIDCT();
        BindQueryDataIDCTFIND();
        BindQueryDataIDXRAY();
        BindQueryDataIDXRAYFIND();
        BindQueryDataIDUSG();
        BindQueryDataIDUSGFIND();
        BindQueryDataCSRSS();
        BindQueryDataCSBSS();
        BindQueryDataCSSH();
        BindQueryDataCSSHYR();
        BindQueryDataCSAUH();
        BindQueryDataCSAUHYR();
        ShowHide();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select IDDIA , IDDCT , IDSF , IDDODYR , IDDODMT , IDAOM , IDAOMSPY , IDAOMYR , IDCT , IDCTFIND , IDXRAY , IDXRAYFIND , IDUSG , IDUSGFIND , CSRSS , CSBSS , CSSH , CSSHYR , CSAUH , CSAUHYR from [Visit1].[IndicationDiagnosis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListIDDIA.SelectedValue = dt.Rows[0]["IDDIA"].ToString().Trim();
            RadioButtonListIDDCT.SelectedValue = dt.Rows[0]["IDDCT"].ToString().Trim();
            TextBoxIDSF.Text = dt.Rows[0]["IDSF"].ToString().Trim();
            TextBoxIDDODYR.Text = dt.Rows[0]["IDDODYR"].ToString().Trim();
            TextBoxIDDODMT.Text = dt.Rows[0]["IDDODMT"].ToString().Trim();
            RadioButtonListIDAOM.SelectedValue = dt.Rows[0]["IDAOM"].ToString().Trim();
            TextBoxIDAOMSPY.Text = dt.Rows[0]["IDAOMSPY"].ToString().Trim();
            TextBoxIDAOMYR.Text = dt.Rows[0]["IDAOMYR"].ToString().Trim();
            RadioButtonListIDCT.SelectedValue = dt.Rows[0]["IDCT"].ToString().Trim();
            TextBoxIDCTFIND.Text = dt.Rows[0]["IDCTFIND"].ToString().Trim();
            RadioButtonListIDXRAY.SelectedValue = dt.Rows[0]["IDXRAY"].ToString().Trim();
            TextBoxIDXRAYFIND.Text = dt.Rows[0]["IDXRAYFIND"].ToString().Trim();
            RadioButtonListIDUSG.SelectedValue = dt.Rows[0]["IDUSG"].ToString().Trim();
            TextBoxIDUSGFIND.Text = dt.Rows[0]["IDUSGFIND"].ToString().Trim();
            RadioButtonListCSRSS.SelectedValue = dt.Rows[0]["CSRSS"].ToString().Trim();
            RadioButtonListCSBSS.SelectedValue = dt.Rows[0]["CSBSS"].ToString().Trim();
            RadioButtonListCSSH.SelectedValue = dt.Rows[0]["CSSH"].ToString().Trim();
            TextBoxCSSHYR.Text = dt.Rows[0]["CSSHYR"].ToString().Trim();
            RadioButtonListCSAUH.SelectedValue = dt.Rows[0]["CSAUH"].ToString().Trim();
            TextBoxCSAUHYR.Text = dt.Rows[0]["CSAUHYR"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListIDDIA.SelectedValue;
            ViewState["txt2"] = RadioButtonListIDDCT.SelectedValue;
            ViewState["txt3"] = TextBoxIDSF.Text;
            ViewState["txt4"] = TextBoxIDDODYR.Text;
            ViewState["txt5"] = TextBoxIDDODMT.Text;
            ViewState["txt6"] = RadioButtonListIDAOM.SelectedValue;
            ViewState["txt7"] = TextBoxIDAOMSPY.Text;
            ViewState["txt8"] = TextBoxIDAOMYR.Text;
            ViewState["txt9"] = RadioButtonListIDCT.SelectedValue;
            ViewState["txt10"] = TextBoxIDCTFIND.Text;
            ViewState["txt11"] = RadioButtonListIDXRAY.SelectedValue;
            ViewState["txt12"] = TextBoxIDXRAYFIND.Text;
            ViewState["txt13"] = RadioButtonListIDUSG.SelectedValue;
            ViewState["txt14"] = TextBoxIDUSGFIND.Text;
            ViewState["txt15"] = RadioButtonListCSRSS.SelectedValue;
            ViewState["txt16"] = RadioButtonListCSBSS.SelectedValue;
            ViewState["txt17"] = RadioButtonListCSSH.SelectedValue;
            ViewState["txt18"] = TextBoxCSSHYR.Text;
            ViewState["txt19"] = RadioButtonListCSAUH.SelectedValue;
            ViewState["txt20"] = TextBoxCSAUHYR.Text;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[IndicationDiagnosis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[IndicationDiagnosis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_IndicationDiagnosis]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@IDDIA", RadioButtonListIDDIA.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDDCT", RadioButtonListIDDCT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDSF", TextBoxIDSF.Text);
                    cmd.Parameters.AddWithValue("@IDDODYR", TextBoxIDDODYR.Text);
                    cmd.Parameters.AddWithValue("@IDDODMT", TextBoxIDDODMT.Text);
                    cmd.Parameters.AddWithValue("@IDAOM", RadioButtonListIDAOM.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDAOMSPY", TextBoxIDAOMSPY.Text);
                    cmd.Parameters.AddWithValue("@IDAOMYR", TextBoxIDAOMYR.Text);
                    cmd.Parameters.AddWithValue("@IDCT", RadioButtonListIDCT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDCTFIND", TextBoxIDCTFIND.Text);
                    cmd.Parameters.AddWithValue("@IDXRAY", RadioButtonListIDXRAY.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDXRAYFIND", TextBoxIDXRAYFIND.Text);
                    cmd.Parameters.AddWithValue("@IDUSG", RadioButtonListIDUSG.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDUSGFIND", TextBoxIDUSGFIND.Text);
                    cmd.Parameters.AddWithValue("@CSRSS", RadioButtonListCSRSS.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSBSS", RadioButtonListCSBSS.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSSH", RadioButtonListCSSH.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSSHYR", TextBoxCSSHYR.Text);
                    cmd.Parameters.AddWithValue("@CSAUH", RadioButtonListCSAUH.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSAUHYR", TextBoxCSAUHYR.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[IndicationDiagnosis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListIDDIA.SelectedValue || ViewState["txt2"].ToString() != RadioButtonListIDDCT.SelectedValue || ViewState["txt3"].ToString() != TextBoxIDSF.Text || ViewState["txt4"].ToString() != TextBoxIDDODYR.Text || ViewState["txt5"].ToString() != TextBoxIDDODMT.Text || ViewState["txt6"].ToString() != RadioButtonListIDAOM.SelectedValue || ViewState["txt7"].ToString() != TextBoxIDAOMSPY.Text || ViewState["txt8"].ToString() != TextBoxIDAOMYR.Text || ViewState["txt9"].ToString() != RadioButtonListIDCT.SelectedValue || ViewState["txt10"].ToString() != TextBoxIDCTFIND.Text || ViewState["txt11"].ToString() != RadioButtonListIDXRAY.SelectedValue || ViewState["txt12"].ToString() != TextBoxIDXRAYFIND.Text || ViewState["txt13"].ToString() != RadioButtonListIDUSG.SelectedValue || ViewState["txt14"].ToString() != TextBoxIDUSGFIND.Text || ViewState["txt15"].ToString() != RadioButtonListCSRSS.SelectedValue || ViewState["txt16"].ToString() != RadioButtonListCSBSS.SelectedValue || ViewState["txt17"].ToString() != RadioButtonListCSSH.SelectedValue || ViewState["txt18"].ToString() != TextBoxCSSHYR.Text || ViewState["txt19"].ToString() != RadioButtonListCSAUH.SelectedValue || ViewState["txt20"].ToString() != TextBoxCSAUHYR.Text)
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
                cmd = new SqlCommand("[Visit1].[sp_IndicationDiagnosis]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@IDDIA", RadioButtonListIDDIA.SelectedValue);
                cmd.Parameters.AddWithValue("@IDDCT", RadioButtonListIDDCT.SelectedValue);
                cmd.Parameters.AddWithValue("@IDSF", TextBoxIDSF.Text);
                cmd.Parameters.AddWithValue("@IDDODYR", TextBoxIDDODYR.Text);
                cmd.Parameters.AddWithValue("@IDDODMT", TextBoxIDDODMT.Text);
                cmd.Parameters.AddWithValue("@IDAOM", RadioButtonListIDAOM.SelectedValue);
                cmd.Parameters.AddWithValue("@IDAOMSPY", TextBoxIDAOMSPY.Text);
                cmd.Parameters.AddWithValue("@IDAOMYR", TextBoxIDAOMYR.Text);
                cmd.Parameters.AddWithValue("@IDCT", RadioButtonListIDCT.SelectedValue);
                cmd.Parameters.AddWithValue("@IDCTFIND", TextBoxIDCTFIND.Text);
                cmd.Parameters.AddWithValue("@IDXRAY", RadioButtonListIDXRAY.SelectedValue);
                cmd.Parameters.AddWithValue("@IDXRAYFIND", TextBoxIDXRAYFIND.Text);
                cmd.Parameters.AddWithValue("@IDUSG", RadioButtonListIDUSG.SelectedValue);
                cmd.Parameters.AddWithValue("@IDUSGFIND", TextBoxIDUSGFIND.Text);
                cmd.Parameters.AddWithValue("@CSRSS", RadioButtonListCSRSS.SelectedValue);
                cmd.Parameters.AddWithValue("@CSBSS", RadioButtonListCSBSS.SelectedValue);
                cmd.Parameters.AddWithValue("@CSSH", RadioButtonListCSSH.SelectedValue);
                cmd.Parameters.AddWithValue("@CSSHYR", TextBoxCSSHYR.Text);
                cmd.Parameters.AddWithValue("@CSAUH", RadioButtonListCSAUH.SelectedValue);
                cmd.Parameters.AddWithValue("@CSAUHYR", TextBoxCSAUHYR.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[IndicationDiagnosis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_IndicationDiagnosis]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@IDDIA", RadioButtonListIDDIA.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDDCT", RadioButtonListIDDCT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDSF", TextBoxIDSF.Text);
                    cmd.Parameters.AddWithValue("@IDDODYR", TextBoxIDDODYR.Text);
                    cmd.Parameters.AddWithValue("@IDDODMT", TextBoxIDDODMT.Text);
                    cmd.Parameters.AddWithValue("@IDAOM", RadioButtonListIDAOM.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDAOMSPY", TextBoxIDAOMSPY.Text);
                    cmd.Parameters.AddWithValue("@IDAOMYR", TextBoxIDAOMYR.Text);
                    cmd.Parameters.AddWithValue("@IDCT", RadioButtonListIDCT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDCTFIND", TextBoxIDCTFIND.Text);
                    cmd.Parameters.AddWithValue("@IDXRAY", RadioButtonListIDXRAY.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDXRAYFIND", TextBoxIDXRAYFIND.Text);
                    cmd.Parameters.AddWithValue("@IDUSG", RadioButtonListIDUSG.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDUSGFIND", TextBoxIDUSGFIND.Text);
                    cmd.Parameters.AddWithValue("@CSRSS", RadioButtonListCSRSS.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSBSS", RadioButtonListCSBSS.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSSH", RadioButtonListCSSH.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSSHYR", TextBoxCSSHYR.Text);
                    cmd.Parameters.AddWithValue("@CSAUH", RadioButtonListCSAUH.SelectedValue);
                    cmd.Parameters.AddWithValue("@CSAUHYR", TextBoxCSAUHYR.Text);

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
                cmd = new SqlCommand("[Visit1].[sp_IndicationDiagnosis]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@IDDIA", RadioButtonListIDDIA.SelectedValue);
                cmd.Parameters.AddWithValue("@IDDCT", RadioButtonListIDDCT.SelectedValue);
                cmd.Parameters.AddWithValue("@IDSF", TextBoxIDSF.Text);
                cmd.Parameters.AddWithValue("@IDDODYR", TextBoxIDDODYR.Text);
                cmd.Parameters.AddWithValue("@IDDODMT", TextBoxIDDODMT.Text);
                cmd.Parameters.AddWithValue("@IDAOM", RadioButtonListIDAOM.SelectedValue);
                cmd.Parameters.AddWithValue("@IDAOMSPY", TextBoxIDAOMSPY.Text);
                cmd.Parameters.AddWithValue("@IDAOMYR", TextBoxIDAOMYR.Text);
                cmd.Parameters.AddWithValue("@IDCT", RadioButtonListIDCT.SelectedValue);
                cmd.Parameters.AddWithValue("@IDCTFIND", TextBoxIDCTFIND.Text);
                cmd.Parameters.AddWithValue("@IDXRAY", RadioButtonListIDXRAY.SelectedValue);
                cmd.Parameters.AddWithValue("@IDXRAYFIND", TextBoxIDXRAYFIND.Text);
                cmd.Parameters.AddWithValue("@IDUSG", RadioButtonListIDUSG.SelectedValue);
                cmd.Parameters.AddWithValue("@IDUSGFIND", TextBoxIDUSGFIND.Text);
                cmd.Parameters.AddWithValue("@CSRSS", RadioButtonListCSRSS.SelectedValue);
                cmd.Parameters.AddWithValue("@CSBSS", RadioButtonListCSBSS.SelectedValue);
                cmd.Parameters.AddWithValue("@CSSH", RadioButtonListCSSH.SelectedValue);
                cmd.Parameters.AddWithValue("@CSSHYR", TextBoxCSSHYR.Text);
                cmd.Parameters.AddWithValue("@CSAUH", RadioButtonListCSAUH.SelectedValue);
                cmd.Parameters.AddWithValue("@CSAUHYR", TextBoxCSAUHYR.Text);

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
        if (!string.IsNullOrEmpty(RadioButtonListIDDIA.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListIDDCT.SelectedValue) || !string.IsNullOrEmpty(TextBoxIDSF.Text) || !string.IsNullOrEmpty(TextBoxIDDODYR.Text) || !string.IsNullOrEmpty(TextBoxIDDODMT.Text) || !string.IsNullOrEmpty(RadioButtonListIDAOM.SelectedValue) || !string.IsNullOrEmpty(TextBoxIDAOMSPY.Text) || !string.IsNullOrEmpty(TextBoxIDAOMYR.Text) || !string.IsNullOrEmpty(RadioButtonListIDCT.SelectedValue) || !string.IsNullOrEmpty(TextBoxIDCTFIND.Text) || !string.IsNullOrEmpty(RadioButtonListIDXRAY.SelectedValue) || !string.IsNullOrEmpty(TextBoxIDXRAYFIND.Text) || !string.IsNullOrEmpty(RadioButtonListIDUSG.SelectedValue) || !string.IsNullOrEmpty(TextBoxIDUSGFIND.Text) || !string.IsNullOrEmpty(RadioButtonListCSRSS.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListCSBSS.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListCSSH.SelectedValue) || !string.IsNullOrEmpty(TextBoxCSSHYR.Text) || !string.IsNullOrEmpty(RadioButtonListCSAUH.SelectedValue) || !string.IsNullOrEmpty(TextBoxCSAUHYR.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListIDDIA.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDDIA.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListIDDIA.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() != RadioButtonListIDDCT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDDCT.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = RadioButtonListIDDCT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() != TextBoxIDSF.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDSF.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxIDSF.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() != TextBoxIDDODYR.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDDODYR.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxIDDODYR.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() != TextBoxIDDODMT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDDODMT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxIDDODMT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() != RadioButtonListIDAOM.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDAOM.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = RadioButtonListIDAOM.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() != TextBoxIDAOMSPY.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDAOMSPY.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = TextBoxIDAOMSPY.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() != TextBoxIDAOMYR.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDAOMYR.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = TextBoxIDAOMYR.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() != RadioButtonListIDCT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDCT.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListIDCT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != TextBoxIDCTFIND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDCTFIND.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = TextBoxIDCTFIND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != RadioButtonListIDXRAY.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDXRAY.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = RadioButtonListIDXRAY.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != TextBoxIDXRAYFIND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDXRAYFIND.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = TextBoxIDXRAYFIND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != RadioButtonListIDUSG.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDUSG.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = RadioButtonListIDUSG.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString() != TextBoxIDUSGFIND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIDUSGFIND.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = TextBoxIDUSGFIND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString() != RadioButtonListCSRSS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCSRSS.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = RadioButtonListCSRSS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt16"].ToString() != RadioButtonListCSBSS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCSBSS.Text;
                dtrow["OldValue"] = dt1.Rows[0][15];
                dtrow["NewValue"] = RadioButtonListCSBSS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt17"].ToString() != RadioButtonListCSSH.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCSSH.Text;
                dtrow["OldValue"] = dt1.Rows[0][16];
                dtrow["NewValue"] = RadioButtonListCSSH.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt18"].ToString() != TextBoxCSSHYR.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCSSHYR.Text;
                dtrow["OldValue"] = dt1.Rows[0][17];
                dtrow["NewValue"] = TextBoxCSSHYR.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt19"].ToString() != RadioButtonListCSAUH.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCSAUH.Text;
                dtrow["OldValue"] = dt1.Rows[0][18];
                dtrow["NewValue"] = RadioButtonListCSAUH.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt20"].ToString() != TextBoxCSAUHYR.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCSAUHYR.Text;
                dtrow["OldValue"] = dt1.Rows[0][19];
                dtrow["NewValue"] = TextBoxCSAUHYR.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_IndicationDiagnosis]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@IDDIA", RadioButtonListIDDIA.SelectedValue);
            cmd.Parameters.AddWithValue("@IDDCT", RadioButtonListIDDCT.SelectedValue);
            cmd.Parameters.AddWithValue("@IDSF", TextBoxIDSF.Text);
            cmd.Parameters.AddWithValue("@IDDODYR", TextBoxIDDODYR.Text);
            cmd.Parameters.AddWithValue("@IDDODMT", TextBoxIDDODMT.Text);
            cmd.Parameters.AddWithValue("@IDAOM", RadioButtonListIDAOM.SelectedValue);
            cmd.Parameters.AddWithValue("@IDAOMSPY", TextBoxIDAOMSPY.Text);
            cmd.Parameters.AddWithValue("@IDAOMYR", TextBoxIDAOMYR.Text);
            cmd.Parameters.AddWithValue("@IDCT", RadioButtonListIDCT.SelectedValue);
            cmd.Parameters.AddWithValue("@IDCTFIND", TextBoxIDCTFIND.Text);
            cmd.Parameters.AddWithValue("@IDXRAY", RadioButtonListIDXRAY.SelectedValue);
            cmd.Parameters.AddWithValue("@IDXRAYFIND", TextBoxIDXRAYFIND.Text);
            cmd.Parameters.AddWithValue("@IDUSG", RadioButtonListIDUSG.SelectedValue);
            cmd.Parameters.AddWithValue("@IDUSGFIND", TextBoxIDUSGFIND.Text);
            cmd.Parameters.AddWithValue("@CSRSS", RadioButtonListCSRSS.SelectedValue);
            cmd.Parameters.AddWithValue("@CSBSS", RadioButtonListCSBSS.SelectedValue);
            cmd.Parameters.AddWithValue("@CSSH", RadioButtonListCSSH.SelectedValue);
            cmd.Parameters.AddWithValue("@CSSHYR", TextBoxCSSHYR.Text);
            cmd.Parameters.AddWithValue("@CSAUH", RadioButtonListCSAUH.SelectedValue);
            cmd.Parameters.AddWithValue("@CSAUHYR", TextBoxCSAUHYR.Text);

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
    #region QueryIDDIA
    private void SetImageQueryIDDIA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDIA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDDIA.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDDIA.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDDIA.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDDIA.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDDIA.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDDIA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDIA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDDIA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA2.Visible = false;
                PanelRaiseIDDIA3.Visible = false;
                PanelHideIDDIA.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDDIA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDIA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDDIA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA2.Visible = true;
                PanelRaiseIDDIA3.Visible = true;
                PanelHideIDDIA.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDDIA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDIA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA2.Visible = true;
                PanelRaiseIDDIA3.Visible = false;
                PanelHideIDDIA.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDDIA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDIA = '" + RadioButtonListIDDIA.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDDIA.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDDIA.Visible = true;
                RAISEIDDIA.ShowPopupWindow();
                QueryRaiseIDDIA.Visible = false;
                TextBoxRaiseIDDIA.Visible = false;
                PanelRaiseIDDIA.Visible = false;
                PanelRaiseIDDIA2.Visible = false;
                PanelRaiseIDDIA3.Visible = false;

                LabelRespondIDDIA.Visible = false;
            }

            else if ((ImageQueryIDDIA.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDIA.Visible = true;
                RAISEIDDIA.ShowPopupWindow();
                QueryRaiseIDDIA.Visible = true;
                TextBoxRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA2.Visible = false;
                PanelRaiseIDDIA3.Visible = false;
                LabelRespondIDDIA.Visible = true;
            }

            else if ((ImageQueryIDDIA.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDIA.Visible = true;
                RAISEIDDIA.ShowPopupWindow();
                QueryRaiseIDDIA.Visible = false;
                TextBoxRaiseIDDIA.Visible = false;
                PanelRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA2.Visible = true;
                PanelRaiseIDDIA3.Visible = false;
                LabelRespondIDDIA.Visible = false;
            }
            else if ((ImageQueryIDDIA.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDIA.Visible = true;
                RAISEIDDIA.ShowPopupWindow();
                QueryRaiseIDDIA.Visible = false;
                TextBoxRaiseIDDIA.Visible = false;
                PanelRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA2.Visible = true;
                PanelRaiseIDDIA3.Visible = true;
                LabelRespondIDDIA.Visible = false;
            }
            else
            {
                RAISEIDDIA.Visible = true;
                RAISEIDDIA.ShowPopupWindow();
                QueryRaiseIDDIA.Visible = false;
                TextBoxRaiseIDDIA.Visible = false;
                PanelRaiseIDDIA.Visible = true;
                PanelRaiseIDDIA2.Visible = true;
                PanelRaiseIDDIA3.Visible = true;
                LabelRespondIDDIA.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDDIA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDDIA.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDIA.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDIA.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDIA = '" + RadioButtonListIDDIA.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDDIAMSG.ShowPopupWindow();
        RAISEIDDIA.Visible = false;


    }
    #endregion
    #region QueryIDDCT
    private void SetImageQueryIDDCT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDCT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDDCT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDDCT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDDCT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDDCT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDDCT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDDCT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDCT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDDCT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT2.Visible = false;
                PanelRaiseIDDCT3.Visible = false;
                PanelHideIDDCT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDDCT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDCT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDDCT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT2.Visible = true;
                PanelRaiseIDDCT3.Visible = true;
                PanelHideIDDCT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDDCT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDCT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT2.Visible = true;
                PanelRaiseIDDCT3.Visible = false;
                PanelHideIDDCT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDDCT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDCT = '" + RadioButtonListIDDCT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDDCT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDDCT.Visible = true;
                RAISEIDDCT.ShowPopupWindow();
                QueryRaiseIDDCT.Visible = false;
                TextBoxRaiseIDDCT.Visible = false;
                PanelRaiseIDDCT.Visible = false;
                PanelRaiseIDDCT2.Visible = false;
                PanelRaiseIDDCT3.Visible = false;

                LabelRespondIDDCT.Visible = false;
            }

            else if ((ImageQueryIDDCT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDCT.Visible = true;
                RAISEIDDCT.ShowPopupWindow();
                QueryRaiseIDDCT.Visible = true;
                TextBoxRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT2.Visible = false;
                PanelRaiseIDDCT3.Visible = false;
                LabelRespondIDDCT.Visible = true;
            }

            else if ((ImageQueryIDDCT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDCT.Visible = true;
                RAISEIDDCT.ShowPopupWindow();
                QueryRaiseIDDCT.Visible = false;
                TextBoxRaiseIDDCT.Visible = false;
                PanelRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT2.Visible = true;
                PanelRaiseIDDCT3.Visible = false;
                LabelRespondIDDCT.Visible = false;
            }
            else if ((ImageQueryIDDCT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDCT.Visible = true;
                RAISEIDDCT.ShowPopupWindow();
                QueryRaiseIDDCT.Visible = false;
                TextBoxRaiseIDDCT.Visible = false;
                PanelRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT2.Visible = true;
                PanelRaiseIDDCT3.Visible = true;
                LabelRespondIDDCT.Visible = false;
            }
            else
            {
                RAISEIDDCT.Visible = true;
                RAISEIDDCT.ShowPopupWindow();
                QueryRaiseIDDCT.Visible = false;
                TextBoxRaiseIDDCT.Visible = false;
                PanelRaiseIDDCT.Visible = true;
                PanelRaiseIDDCT2.Visible = true;
                PanelRaiseIDDCT3.Visible = true;
                LabelRespondIDDCT.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDDCT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDDCT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDCT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDCT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDCT = '" + RadioButtonListIDDCT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDDCTMSG.ShowPopupWindow();
        RAISEIDDCT.Visible = false;


    }
    #endregion
    #region QueryIDSF
    private void SetImageQueryIDSF()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDSF.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDSF.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDSF.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDSF.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDSF.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDSF.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDSF()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDSF.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDSF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDSF.Visible = true;
                PanelRaiseIDSF2.Visible = false;
                PanelRaiseIDSF3.Visible = false;
                PanelHideIDSF.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDSF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDSF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDSF3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDSF.Visible = true;
                PanelRaiseIDSF2.Visible = true;
                PanelRaiseIDSF3.Visible = true;
                PanelHideIDSF.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDSF.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDSF2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDSF.Visible = true;
                PanelRaiseIDSF2.Visible = true;
                PanelRaiseIDSF3.Visible = false;
                PanelHideIDSF.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDSF_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDSF = '" + TextBoxIDSF.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDSF.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDSF.Visible = true;
                RAISEIDSF.ShowPopupWindow();
                QueryRaiseIDSF.Visible = false;
                TextBoxRaiseIDSF.Visible = false;
                PanelRaiseIDSF.Visible = false;
                PanelRaiseIDSF2.Visible = false;
                PanelRaiseIDSF3.Visible = false;

                LabelRespondIDSF.Visible = false;
            }

            else if ((ImageQueryIDSF.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDSF.Visible = true;
                RAISEIDSF.ShowPopupWindow();
                QueryRaiseIDSF.Visible = true;
                TextBoxRaiseIDSF.Visible = true;
                PanelRaiseIDSF.Visible = true;
                PanelRaiseIDSF2.Visible = false;
                PanelRaiseIDSF3.Visible = false;
                LabelRespondIDSF.Visible = true;
            }

            else if ((ImageQueryIDSF.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDSF.Visible = true;
                RAISEIDSF.ShowPopupWindow();
                QueryRaiseIDSF.Visible = false;
                TextBoxRaiseIDSF.Visible = false;
                PanelRaiseIDSF.Visible = true;
                PanelRaiseIDSF2.Visible = true;
                PanelRaiseIDSF3.Visible = false;
                LabelRespondIDSF.Visible = false;
            }
            else if ((ImageQueryIDSF.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDSF.Visible = true;
                RAISEIDSF.ShowPopupWindow();
                QueryRaiseIDSF.Visible = false;
                TextBoxRaiseIDSF.Visible = false;
                PanelRaiseIDSF.Visible = true;
                PanelRaiseIDSF2.Visible = true;
                PanelRaiseIDSF3.Visible = true;
                LabelRespondIDSF.Visible = false;
            }
            else
            {
                RAISEIDSF.Visible = true;
                RAISEIDSF.ShowPopupWindow();
                QueryRaiseIDSF.Visible = false;
                TextBoxRaiseIDSF.Visible = false;
                PanelRaiseIDSF.Visible = true;
                PanelRaiseIDSF2.Visible = true;
                PanelRaiseIDSF3.Visible = true;
                LabelRespondIDSF.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDSF_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDSF.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDSF.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDSF.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDSF = '" + TextBoxIDSF.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDSFMSG.ShowPopupWindow();
        RAISEIDSF.Visible = false;


    }
    #endregion
    #region QueryIDDODYR
    private void SetImageQueryIDDODYR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDDODYR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDDODYR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDDODYR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDDODYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDDODYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDDODYR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDDODYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR2.Visible = false;
                PanelRaiseIDDODYR3.Visible = false;
                PanelHideIDDODYR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDDODYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDODYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDDODYR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR2.Visible = true;
                PanelRaiseIDDODYR3.Visible = true;
                PanelHideIDDODYR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDDODYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDODYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR2.Visible = true;
                PanelRaiseIDDODYR3.Visible = false;
                PanelHideIDDODYR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDDODYR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDODYR = '" + TextBoxIDDODYR.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDDODYR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDDODYR.Visible = true;
                RAISEIDDODYR.ShowPopupWindow();
                QueryRaiseIDDODYR.Visible = false;
                TextBoxRaiseIDDODYR.Visible = false;
                PanelRaiseIDDODYR.Visible = false;
                PanelRaiseIDDODYR2.Visible = false;
                PanelRaiseIDDODYR3.Visible = false;

                LabelRespondIDDODYR.Visible = false;
            }

            else if ((ImageQueryIDDODYR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDODYR.Visible = true;
                RAISEIDDODYR.ShowPopupWindow();
                QueryRaiseIDDODYR.Visible = true;
                TextBoxRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR2.Visible = false;
                PanelRaiseIDDODYR3.Visible = false;
                LabelRespondIDDODYR.Visible = true;
            }

            else if ((ImageQueryIDDODYR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDODYR.Visible = true;
                RAISEIDDODYR.ShowPopupWindow();
                QueryRaiseIDDODYR.Visible = false;
                TextBoxRaiseIDDODYR.Visible = false;
                PanelRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR2.Visible = true;
                PanelRaiseIDDODYR3.Visible = false;
                LabelRespondIDDODYR.Visible = false;
            }
            else if ((ImageQueryIDDODYR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDODYR.Visible = true;
                RAISEIDDODYR.ShowPopupWindow();
                QueryRaiseIDDODYR.Visible = false;
                TextBoxRaiseIDDODYR.Visible = false;
                PanelRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR2.Visible = true;
                PanelRaiseIDDODYR3.Visible = true;
                LabelRespondIDDODYR.Visible = false;
            }
            else
            {
                RAISEIDDODYR.Visible = true;
                RAISEIDDODYR.ShowPopupWindow();
                QueryRaiseIDDODYR.Visible = false;
                TextBoxRaiseIDDODYR.Visible = false;
                PanelRaiseIDDODYR.Visible = true;
                PanelRaiseIDDODYR2.Visible = true;
                PanelRaiseIDDODYR3.Visible = true;
                LabelRespondIDDODYR.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDDODYR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDDODYR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODYR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODYR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDODYR = '" + TextBoxIDDODYR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDDODYRMSG.ShowPopupWindow();
        RAISEIDDODYR.Visible = false;


    }
    #endregion
    #region QueryIDDODMT
    private void SetImageQueryIDDODMT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODMT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDDODMT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDDODMT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDDODMT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDDODMT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDDODMT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDDODMT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODMT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDDODMT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT2.Visible = false;
                PanelRaiseIDDODMT3.Visible = false;
                PanelHideIDDODMT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDDODMT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDODMT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDDODMT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT2.Visible = true;
                PanelRaiseIDDODMT3.Visible = true;
                PanelHideIDDODMT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDDODMT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDDODMT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT2.Visible = true;
                PanelRaiseIDDODMT3.Visible = false;
                PanelHideIDDODMT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDDODMT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDODMT = '" + TextBoxIDDODMT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDDODMT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDDODMT.Visible = true;
                RAISEIDDODMT.ShowPopupWindow();
                QueryRaiseIDDODMT.Visible = false;
                TextBoxRaiseIDDODMT.Visible = false;
                PanelRaiseIDDODMT.Visible = false;
                PanelRaiseIDDODMT2.Visible = false;
                PanelRaiseIDDODMT3.Visible = false;

                LabelRespondIDDODMT.Visible = false;
            }

            else if ((ImageQueryIDDODMT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDODMT.Visible = true;
                RAISEIDDODMT.ShowPopupWindow();
                QueryRaiseIDDODMT.Visible = true;
                TextBoxRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT2.Visible = false;
                PanelRaiseIDDODMT3.Visible = false;
                LabelRespondIDDODMT.Visible = true;
            }

            else if ((ImageQueryIDDODMT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDODMT.Visible = true;
                RAISEIDDODMT.ShowPopupWindow();
                QueryRaiseIDDODMT.Visible = false;
                TextBoxRaiseIDDODMT.Visible = false;
                PanelRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT2.Visible = true;
                PanelRaiseIDDODMT3.Visible = false;
                LabelRespondIDDODMT.Visible = false;
            }
            else if ((ImageQueryIDDODMT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDDODMT.Visible = true;
                RAISEIDDODMT.ShowPopupWindow();
                QueryRaiseIDDODMT.Visible = false;
                TextBoxRaiseIDDODMT.Visible = false;
                PanelRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT2.Visible = true;
                PanelRaiseIDDODMT3.Visible = true;
                LabelRespondIDDODMT.Visible = false;
            }
            else
            {
                RAISEIDDODMT.Visible = true;
                RAISEIDDODMT.ShowPopupWindow();
                QueryRaiseIDDODMT.Visible = false;
                TextBoxRaiseIDDODMT.Visible = false;
                PanelRaiseIDDODMT.Visible = true;
                PanelRaiseIDDODMT2.Visible = true;
                PanelRaiseIDDODMT3.Visible = true;
                LabelRespondIDDODMT.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDDODMT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDDODMT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODMT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDDODMT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDDODMT = '" + TextBoxIDDODMT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDDODMTMSG.ShowPopupWindow();
        RAISEIDDODMT.Visible = false;


    }
    #endregion
    #region QueryIDAOM
    private void SetImageQueryIDAOM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDAOM.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDAOM.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDAOM.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDAOM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDAOM.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDAOM()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDAOM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM2.Visible = false;
                PanelRaiseIDAOM3.Visible = false;
                PanelHideIDAOM.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDAOM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDAOM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDAOM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM2.Visible = true;
                PanelRaiseIDAOM3.Visible = true;
                PanelHideIDAOM.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDAOM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDAOM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM2.Visible = true;
                PanelRaiseIDAOM3.Visible = false;
                PanelHideIDAOM.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDAOM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDAOM = '" + RadioButtonListIDAOM.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDAOM.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDAOM.Visible = true;
                RAISEIDAOM.ShowPopupWindow();
                QueryRaiseIDAOM.Visible = false;
                TextBoxRaiseIDAOM.Visible = false;
                PanelRaiseIDAOM.Visible = false;
                PanelRaiseIDAOM2.Visible = false;
                PanelRaiseIDAOM3.Visible = false;

                LabelRespondIDAOM.Visible = false;
            }

            else if ((ImageQueryIDAOM.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOM.Visible = true;
                RAISEIDAOM.ShowPopupWindow();
                QueryRaiseIDAOM.Visible = true;
                TextBoxRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM2.Visible = false;
                PanelRaiseIDAOM3.Visible = false;
                LabelRespondIDAOM.Visible = true;
            }

            else if ((ImageQueryIDAOM.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOM.Visible = true;
                RAISEIDAOM.ShowPopupWindow();
                QueryRaiseIDAOM.Visible = false;
                TextBoxRaiseIDAOM.Visible = false;
                PanelRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM2.Visible = true;
                PanelRaiseIDAOM3.Visible = false;
                LabelRespondIDAOM.Visible = false;
            }
            else if ((ImageQueryIDAOM.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOM.Visible = true;
                RAISEIDAOM.ShowPopupWindow();
                QueryRaiseIDAOM.Visible = false;
                TextBoxRaiseIDAOM.Visible = false;
                PanelRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM2.Visible = true;
                PanelRaiseIDAOM3.Visible = true;
                LabelRespondIDAOM.Visible = false;
            }
            else
            {
                RAISEIDAOM.Visible = true;
                RAISEIDAOM.ShowPopupWindow();
                QueryRaiseIDAOM.Visible = false;
                TextBoxRaiseIDAOM.Visible = false;
                PanelRaiseIDAOM.Visible = true;
                PanelRaiseIDAOM2.Visible = true;
                PanelRaiseIDAOM3.Visible = true;
                LabelRespondIDAOM.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDAOM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDAOM.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOM.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOM.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDAOM = '" + RadioButtonListIDAOM.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDAOMMSG.ShowPopupWindow();
        RAISEIDAOM.Visible = false;


    }
    #endregion
    #region QueryIDAOMSPY
    private void SetImageQueryIDAOMSPY()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMSPY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDAOMSPY.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDAOMSPY.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDAOMSPY.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDAOMSPY.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDAOMSPY.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDAOMSPY()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMSPY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDAOMSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY2.Visible = false;
                PanelRaiseIDAOMSPY3.Visible = false;
                PanelHideIDAOMSPY.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDAOMSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDAOMSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDAOMSPY3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY2.Visible = true;
                PanelRaiseIDAOMSPY3.Visible = true;
                PanelHideIDAOMSPY.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDAOMSPY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDAOMSPY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY2.Visible = true;
                PanelRaiseIDAOMSPY3.Visible = false;
                PanelHideIDAOMSPY.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDAOMSPY_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDAOMSPY = '" + TextBoxIDAOMSPY.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDAOMSPY.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDAOMSPY.Visible = true;
                RAISEIDAOMSPY.ShowPopupWindow();
                QueryRaiseIDAOMSPY.Visible = false;
                TextBoxRaiseIDAOMSPY.Visible = false;
                PanelRaiseIDAOMSPY.Visible = false;
                PanelRaiseIDAOMSPY2.Visible = false;
                PanelRaiseIDAOMSPY3.Visible = false;

                LabelRespondIDAOMSPY.Visible = false;
            }

            else if ((ImageQueryIDAOMSPY.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOMSPY.Visible = true;
                RAISEIDAOMSPY.ShowPopupWindow();
                QueryRaiseIDAOMSPY.Visible = true;
                TextBoxRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY2.Visible = false;
                PanelRaiseIDAOMSPY3.Visible = false;
                LabelRespondIDAOMSPY.Visible = true;
            }

            else if ((ImageQueryIDAOMSPY.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOMSPY.Visible = true;
                RAISEIDAOMSPY.ShowPopupWindow();
                QueryRaiseIDAOMSPY.Visible = false;
                TextBoxRaiseIDAOMSPY.Visible = false;
                PanelRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY2.Visible = true;
                PanelRaiseIDAOMSPY3.Visible = false;
                LabelRespondIDAOMSPY.Visible = false;
            }
            else if ((ImageQueryIDAOMSPY.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOMSPY.Visible = true;
                RAISEIDAOMSPY.ShowPopupWindow();
                QueryRaiseIDAOMSPY.Visible = false;
                TextBoxRaiseIDAOMSPY.Visible = false;
                PanelRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY2.Visible = true;
                PanelRaiseIDAOMSPY3.Visible = true;
                LabelRespondIDAOMSPY.Visible = false;
            }
            else
            {
                RAISEIDAOMSPY.Visible = true;
                RAISEIDAOMSPY.ShowPopupWindow();
                QueryRaiseIDAOMSPY.Visible = false;
                TextBoxRaiseIDAOMSPY.Visible = false;
                PanelRaiseIDAOMSPY.Visible = true;
                PanelRaiseIDAOMSPY2.Visible = true;
                PanelRaiseIDAOMSPY3.Visible = true;
                LabelRespondIDAOMSPY.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDAOMSPY_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDAOMSPY.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMSPY.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMSPY.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDAOMSPY = '" + TextBoxIDAOMSPY.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDAOMSPYMSG.ShowPopupWindow();
        RAISEIDAOMSPY.Visible = false;


    }
    #endregion
    #region QueryIDAOMYR
    private void SetImageQueryIDAOMYR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDAOMYR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDAOMYR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDAOMYR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDAOMYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDAOMYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDAOMYR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDAOMYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR2.Visible = false;
                PanelRaiseIDAOMYR3.Visible = false;
                PanelHideIDAOMYR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDAOMYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDAOMYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDAOMYR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR2.Visible = true;
                PanelRaiseIDAOMYR3.Visible = true;
                PanelHideIDAOMYR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDAOMYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDAOMYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR2.Visible = true;
                PanelRaiseIDAOMYR3.Visible = false;
                PanelHideIDAOMYR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDAOMYR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDAOMYR = '" + TextBoxIDAOMYR.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDAOMYR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDAOMYR.Visible = true;
                RAISEIDAOMYR.ShowPopupWindow();
                QueryRaiseIDAOMYR.Visible = false;
                TextBoxRaiseIDAOMYR.Visible = false;
                PanelRaiseIDAOMYR.Visible = false;
                PanelRaiseIDAOMYR2.Visible = false;
                PanelRaiseIDAOMYR3.Visible = false;

                LabelRespondIDAOMYR.Visible = false;
            }

            else if ((ImageQueryIDAOMYR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOMYR.Visible = true;
                RAISEIDAOMYR.ShowPopupWindow();
                QueryRaiseIDAOMYR.Visible = true;
                TextBoxRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR2.Visible = false;
                PanelRaiseIDAOMYR3.Visible = false;
                LabelRespondIDAOMYR.Visible = true;
            }

            else if ((ImageQueryIDAOMYR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOMYR.Visible = true;
                RAISEIDAOMYR.ShowPopupWindow();
                QueryRaiseIDAOMYR.Visible = false;
                TextBoxRaiseIDAOMYR.Visible = false;
                PanelRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR2.Visible = true;
                PanelRaiseIDAOMYR3.Visible = false;
                LabelRespondIDAOMYR.Visible = false;
            }
            else if ((ImageQueryIDAOMYR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDAOMYR.Visible = true;
                RAISEIDAOMYR.ShowPopupWindow();
                QueryRaiseIDAOMYR.Visible = false;
                TextBoxRaiseIDAOMYR.Visible = false;
                PanelRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR2.Visible = true;
                PanelRaiseIDAOMYR3.Visible = true;
                LabelRespondIDAOMYR.Visible = false;
            }
            else
            {
                RAISEIDAOMYR.Visible = true;
                RAISEIDAOMYR.ShowPopupWindow();
                QueryRaiseIDAOMYR.Visible = false;
                TextBoxRaiseIDAOMYR.Visible = false;
                PanelRaiseIDAOMYR.Visible = true;
                PanelRaiseIDAOMYR2.Visible = true;
                PanelRaiseIDAOMYR3.Visible = true;
                LabelRespondIDAOMYR.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDAOMYR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDAOMYR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMYR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDAOMYR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDAOMYR = '" + TextBoxIDAOMYR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDAOMYRMSG.ShowPopupWindow();
        RAISEIDAOMYR.Visible = false;


    }
    #endregion
    #region QueryIDCT
    private void SetImageQueryIDCT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDCT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDCT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDCT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDCT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDCT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDCT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDCT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDCT.Visible = true;
                PanelRaiseIDCT2.Visible = false;
                PanelRaiseIDCT3.Visible = false;
                PanelHideIDCT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDCT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDCT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDCT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDCT.Visible = true;
                PanelRaiseIDCT2.Visible = true;
                PanelRaiseIDCT3.Visible = true;
                PanelHideIDCT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDCT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDCT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDCT.Visible = true;
                PanelRaiseIDCT2.Visible = true;
                PanelRaiseIDCT3.Visible = false;
                PanelHideIDCT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDCT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDCT = '" + RadioButtonListIDCT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDCT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDCT.Visible = true;
                RAISEIDCT.ShowPopupWindow();
                QueryRaiseIDCT.Visible = false;
                TextBoxRaiseIDCT.Visible = false;
                PanelRaiseIDCT.Visible = false;
                PanelRaiseIDCT2.Visible = false;
                PanelRaiseIDCT3.Visible = false;

                LabelRespondIDCT.Visible = false;
            }

            else if ((ImageQueryIDCT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDCT.Visible = true;
                RAISEIDCT.ShowPopupWindow();
                QueryRaiseIDCT.Visible = true;
                TextBoxRaiseIDCT.Visible = true;
                PanelRaiseIDCT.Visible = true;
                PanelRaiseIDCT2.Visible = false;
                PanelRaiseIDCT3.Visible = false;
                LabelRespondIDCT.Visible = true;
            }

            else if ((ImageQueryIDCT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDCT.Visible = true;
                RAISEIDCT.ShowPopupWindow();
                QueryRaiseIDCT.Visible = false;
                TextBoxRaiseIDCT.Visible = false;
                PanelRaiseIDCT.Visible = true;
                PanelRaiseIDCT2.Visible = true;
                PanelRaiseIDCT3.Visible = false;
                LabelRespondIDCT.Visible = false;
            }
            else if ((ImageQueryIDCT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDCT.Visible = true;
                RAISEIDCT.ShowPopupWindow();
                QueryRaiseIDCT.Visible = false;
                TextBoxRaiseIDCT.Visible = false;
                PanelRaiseIDCT.Visible = true;
                PanelRaiseIDCT2.Visible = true;
                PanelRaiseIDCT3.Visible = true;
                LabelRespondIDCT.Visible = false;
            }
            else
            {
                RAISEIDCT.Visible = true;
                RAISEIDCT.ShowPopupWindow();
                QueryRaiseIDCT.Visible = false;
                TextBoxRaiseIDCT.Visible = false;
                PanelRaiseIDCT.Visible = true;
                PanelRaiseIDCT2.Visible = true;
                PanelRaiseIDCT3.Visible = true;
                LabelRespondIDCT.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDCT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDCT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDCT = '" + RadioButtonListIDCT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDCTMSG.ShowPopupWindow();
        RAISEIDCT.Visible = false;


    }
    #endregion
    #region QueryIDCTFIND
    private void SetImageQueryIDCTFIND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCTFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDCTFIND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDCTFIND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDCTFIND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDCTFIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDCTFIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDCTFIND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCTFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDCTFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND2.Visible = false;
                PanelRaiseIDCTFIND3.Visible = false;
                PanelHideIDCTFIND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDCTFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDCTFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDCTFIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND2.Visible = true;
                PanelRaiseIDCTFIND3.Visible = true;
                PanelHideIDCTFIND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDCTFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDCTFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND2.Visible = true;
                PanelRaiseIDCTFIND3.Visible = false;
                PanelHideIDCTFIND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDCTFIND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDCTFIND = '" + TextBoxIDCTFIND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDCTFIND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDCTFIND.Visible = true;
                RAISEIDCTFIND.ShowPopupWindow();
                QueryRaiseIDCTFIND.Visible = false;
                TextBoxRaiseIDCTFIND.Visible = false;
                PanelRaiseIDCTFIND.Visible = false;
                PanelRaiseIDCTFIND2.Visible = false;
                PanelRaiseIDCTFIND3.Visible = false;

                LabelRespondIDCTFIND.Visible = false;
            }

            else if ((ImageQueryIDCTFIND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDCTFIND.Visible = true;
                RAISEIDCTFIND.ShowPopupWindow();
                QueryRaiseIDCTFIND.Visible = true;
                TextBoxRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND2.Visible = false;
                PanelRaiseIDCTFIND3.Visible = false;
                LabelRespondIDCTFIND.Visible = true;
            }

            else if ((ImageQueryIDCTFIND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDCTFIND.Visible = true;
                RAISEIDCTFIND.ShowPopupWindow();
                QueryRaiseIDCTFIND.Visible = false;
                TextBoxRaiseIDCTFIND.Visible = false;
                PanelRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND2.Visible = true;
                PanelRaiseIDCTFIND3.Visible = false;
                LabelRespondIDCTFIND.Visible = false;
            }
            else if ((ImageQueryIDCTFIND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDCTFIND.Visible = true;
                RAISEIDCTFIND.ShowPopupWindow();
                QueryRaiseIDCTFIND.Visible = false;
                TextBoxRaiseIDCTFIND.Visible = false;
                PanelRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND2.Visible = true;
                PanelRaiseIDCTFIND3.Visible = true;
                LabelRespondIDCTFIND.Visible = false;
            }
            else
            {
                RAISEIDCTFIND.Visible = true;
                RAISEIDCTFIND.ShowPopupWindow();
                QueryRaiseIDCTFIND.Visible = false;
                TextBoxRaiseIDCTFIND.Visible = false;
                PanelRaiseIDCTFIND.Visible = true;
                PanelRaiseIDCTFIND2.Visible = true;
                PanelRaiseIDCTFIND3.Visible = true;
                LabelRespondIDCTFIND.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDCTFIND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDCTFIND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCTFIND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDCTFIND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDCTFIND = '" + TextBoxIDCTFIND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDCTFINDMSG.ShowPopupWindow();
        RAISEIDCTFIND.Visible = false;


    }
    #endregion
    #region QueryIDXRAY
    private void SetImageQueryIDXRAY()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDXRAY.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDXRAY.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDXRAY.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDXRAY.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDXRAY.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDXRAY()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAY.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDXRAY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY2.Visible = false;
                PanelRaiseIDXRAY3.Visible = false;
                PanelHideIDXRAY.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDXRAY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDXRAY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDXRAY3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY2.Visible = true;
                PanelRaiseIDXRAY3.Visible = true;
                PanelHideIDXRAY.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDXRAY.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDXRAY2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY2.Visible = true;
                PanelRaiseIDXRAY3.Visible = false;
                PanelHideIDXRAY.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDXRAY_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDXRAY = '" + RadioButtonListIDXRAY.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDXRAY.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDXRAY.Visible = true;
                RAISEIDXRAY.ShowPopupWindow();
                QueryRaiseIDXRAY.Visible = false;
                TextBoxRaiseIDXRAY.Visible = false;
                PanelRaiseIDXRAY.Visible = false;
                PanelRaiseIDXRAY2.Visible = false;
                PanelRaiseIDXRAY3.Visible = false;

                LabelRespondIDXRAY.Visible = false;
            }

            else if ((ImageQueryIDXRAY.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDXRAY.Visible = true;
                RAISEIDXRAY.ShowPopupWindow();
                QueryRaiseIDXRAY.Visible = true;
                TextBoxRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY2.Visible = false;
                PanelRaiseIDXRAY3.Visible = false;
                LabelRespondIDXRAY.Visible = true;
            }

            else if ((ImageQueryIDXRAY.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDXRAY.Visible = true;
                RAISEIDXRAY.ShowPopupWindow();
                QueryRaiseIDXRAY.Visible = false;
                TextBoxRaiseIDXRAY.Visible = false;
                PanelRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY2.Visible = true;
                PanelRaiseIDXRAY3.Visible = false;
                LabelRespondIDXRAY.Visible = false;
            }
            else if ((ImageQueryIDXRAY.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDXRAY.Visible = true;
                RAISEIDXRAY.ShowPopupWindow();
                QueryRaiseIDXRAY.Visible = false;
                TextBoxRaiseIDXRAY.Visible = false;
                PanelRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY2.Visible = true;
                PanelRaiseIDXRAY3.Visible = true;
                LabelRespondIDXRAY.Visible = false;
            }
            else
            {
                RAISEIDXRAY.Visible = true;
                RAISEIDXRAY.ShowPopupWindow();
                QueryRaiseIDXRAY.Visible = false;
                TextBoxRaiseIDXRAY.Visible = false;
                PanelRaiseIDXRAY.Visible = true;
                PanelRaiseIDXRAY2.Visible = true;
                PanelRaiseIDXRAY3.Visible = true;
                LabelRespondIDXRAY.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDXRAY_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDXRAY.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAY.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAY.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDXRAY = '" + RadioButtonListIDXRAY.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDXRAYMSG.ShowPopupWindow();
        RAISEIDXRAY.Visible = false;


    }
    #endregion
    #region QueryIDXRAYFIND
    private void SetImageQueryIDXRAYFIND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAYFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDXRAYFIND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDXRAYFIND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDXRAYFIND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDXRAYFIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDXRAYFIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDXRAYFIND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAYFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDXRAYFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND2.Visible = false;
                PanelRaiseIDXRAYFIND3.Visible = false;
                PanelHideIDXRAYFIND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDXRAYFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDXRAYFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDXRAYFIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND2.Visible = true;
                PanelRaiseIDXRAYFIND3.Visible = true;
                PanelHideIDXRAYFIND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDXRAYFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDXRAYFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND2.Visible = true;
                PanelRaiseIDXRAYFIND3.Visible = false;
                PanelHideIDXRAYFIND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDXRAYFIND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDXRAYFIND = '" + TextBoxIDXRAYFIND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDXRAYFIND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDXRAYFIND.Visible = true;
                RAISEIDXRAYFIND.ShowPopupWindow();
                QueryRaiseIDXRAYFIND.Visible = false;
                TextBoxRaiseIDXRAYFIND.Visible = false;
                PanelRaiseIDXRAYFIND.Visible = false;
                PanelRaiseIDXRAYFIND2.Visible = false;
                PanelRaiseIDXRAYFIND3.Visible = false;

                LabelRespondIDXRAYFIND.Visible = false;
            }

            else if ((ImageQueryIDXRAYFIND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDXRAYFIND.Visible = true;
                RAISEIDXRAYFIND.ShowPopupWindow();
                QueryRaiseIDXRAYFIND.Visible = true;
                TextBoxRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND2.Visible = false;
                PanelRaiseIDXRAYFIND3.Visible = false;
                LabelRespondIDXRAYFIND.Visible = true;
            }

            else if ((ImageQueryIDXRAYFIND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDXRAYFIND.Visible = true;
                RAISEIDXRAYFIND.ShowPopupWindow();
                QueryRaiseIDXRAYFIND.Visible = false;
                TextBoxRaiseIDXRAYFIND.Visible = false;
                PanelRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND2.Visible = true;
                PanelRaiseIDXRAYFIND3.Visible = false;
                LabelRespondIDXRAYFIND.Visible = false;
            }
            else if ((ImageQueryIDXRAYFIND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDXRAYFIND.Visible = true;
                RAISEIDXRAYFIND.ShowPopupWindow();
                QueryRaiseIDXRAYFIND.Visible = false;
                TextBoxRaiseIDXRAYFIND.Visible = false;
                PanelRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND2.Visible = true;
                PanelRaiseIDXRAYFIND3.Visible = true;
                LabelRespondIDXRAYFIND.Visible = false;
            }
            else
            {
                RAISEIDXRAYFIND.Visible = true;
                RAISEIDXRAYFIND.ShowPopupWindow();
                QueryRaiseIDXRAYFIND.Visible = false;
                TextBoxRaiseIDXRAYFIND.Visible = false;
                PanelRaiseIDXRAYFIND.Visible = true;
                PanelRaiseIDXRAYFIND2.Visible = true;
                PanelRaiseIDXRAYFIND3.Visible = true;
                LabelRespondIDXRAYFIND.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDXRAYFIND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDXRAYFIND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAYFIND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDXRAYFIND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDXRAYFIND = '" + TextBoxIDXRAYFIND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDXRAYFINDMSG.ShowPopupWindow();
        RAISEIDXRAYFIND.Visible = false;


    }
    #endregion
    #region QueryIDUSG
    private void SetImageQueryIDUSG()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSG.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDUSG.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDUSG.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDUSG.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDUSG.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDUSG.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDUSG()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSG.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDUSG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG2.Visible = false;
                PanelRaiseIDUSG3.Visible = false;
                PanelHideIDUSG.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDUSG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDUSG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDUSG3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG2.Visible = true;
                PanelRaiseIDUSG3.Visible = true;
                PanelHideIDUSG.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDUSG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDUSG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG2.Visible = true;
                PanelRaiseIDUSG3.Visible = false;
                PanelHideIDUSG.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDUSG_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDUSG = '" + RadioButtonListIDUSG.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDUSG.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDUSG.Visible = true;
                RAISEIDUSG.ShowPopupWindow();
                QueryRaiseIDUSG.Visible = false;
                TextBoxRaiseIDUSG.Visible = false;
                PanelRaiseIDUSG.Visible = false;
                PanelRaiseIDUSG2.Visible = false;
                PanelRaiseIDUSG3.Visible = false;

                LabelRespondIDUSG.Visible = false;
            }

            else if ((ImageQueryIDUSG.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDUSG.Visible = true;
                RAISEIDUSG.ShowPopupWindow();
                QueryRaiseIDUSG.Visible = true;
                TextBoxRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG2.Visible = false;
                PanelRaiseIDUSG3.Visible = false;
                LabelRespondIDUSG.Visible = true;
            }

            else if ((ImageQueryIDUSG.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDUSG.Visible = true;
                RAISEIDUSG.ShowPopupWindow();
                QueryRaiseIDUSG.Visible = false;
                TextBoxRaiseIDUSG.Visible = false;
                PanelRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG2.Visible = true;
                PanelRaiseIDUSG3.Visible = false;
                LabelRespondIDUSG.Visible = false;
            }
            else if ((ImageQueryIDUSG.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDUSG.Visible = true;
                RAISEIDUSG.ShowPopupWindow();
                QueryRaiseIDUSG.Visible = false;
                TextBoxRaiseIDUSG.Visible = false;
                PanelRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG2.Visible = true;
                PanelRaiseIDUSG3.Visible = true;
                LabelRespondIDUSG.Visible = false;
            }
            else
            {
                RAISEIDUSG.Visible = true;
                RAISEIDUSG.ShowPopupWindow();
                QueryRaiseIDUSG.Visible = false;
                TextBoxRaiseIDUSG.Visible = false;
                PanelRaiseIDUSG.Visible = true;
                PanelRaiseIDUSG2.Visible = true;
                PanelRaiseIDUSG3.Visible = true;
                LabelRespondIDUSG.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDUSG_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDUSG.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSG.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSG.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDUSG = '" + RadioButtonListIDUSG.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDUSGMSG.ShowPopupWindow();
        RAISEIDUSG.Visible = false;


    }
    #endregion
    #region QueryIDUSGFIND
    private void SetImageQueryIDUSGFIND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSGFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIDUSGFIND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIDUSGFIND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIDUSGFIND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIDUSGFIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIDUSGFIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIDUSGFIND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSGFIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIDUSGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND2.Visible = false;
                PanelRaiseIDUSGFIND3.Visible = false;
                PanelHideIDUSGFIND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIDUSGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDUSGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIDUSGFIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND2.Visible = true;
                PanelRaiseIDUSGFIND3.Visible = true;
                PanelHideIDUSGFIND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIDUSGFIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIDUSGFIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND2.Visible = true;
                PanelRaiseIDUSGFIND3.Visible = false;
                PanelHideIDUSGFIND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIDUSGFIND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDUSGFIND = '" + TextBoxIDUSGFIND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIDUSGFIND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIDUSGFIND.Visible = true;
                RAISEIDUSGFIND.ShowPopupWindow();
                QueryRaiseIDUSGFIND.Visible = false;
                TextBoxRaiseIDUSGFIND.Visible = false;
                PanelRaiseIDUSGFIND.Visible = false;
                PanelRaiseIDUSGFIND2.Visible = false;
                PanelRaiseIDUSGFIND3.Visible = false;

                LabelRespondIDUSGFIND.Visible = false;
            }

            else if ((ImageQueryIDUSGFIND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDUSGFIND.Visible = true;
                RAISEIDUSGFIND.ShowPopupWindow();
                QueryRaiseIDUSGFIND.Visible = true;
                TextBoxRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND2.Visible = false;
                PanelRaiseIDUSGFIND3.Visible = false;
                LabelRespondIDUSGFIND.Visible = true;
            }

            else if ((ImageQueryIDUSGFIND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDUSGFIND.Visible = true;
                RAISEIDUSGFIND.ShowPopupWindow();
                QueryRaiseIDUSGFIND.Visible = false;
                TextBoxRaiseIDUSGFIND.Visible = false;
                PanelRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND2.Visible = true;
                PanelRaiseIDUSGFIND3.Visible = false;
                LabelRespondIDUSGFIND.Visible = false;
            }
            else if ((ImageQueryIDUSGFIND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIDUSGFIND.Visible = true;
                RAISEIDUSGFIND.ShowPopupWindow();
                QueryRaiseIDUSGFIND.Visible = false;
                TextBoxRaiseIDUSGFIND.Visible = false;
                PanelRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND2.Visible = true;
                PanelRaiseIDUSGFIND3.Visible = true;
                LabelRespondIDUSGFIND.Visible = false;
            }
            else
            {
                RAISEIDUSGFIND.Visible = true;
                RAISEIDUSGFIND.ShowPopupWindow();
                QueryRaiseIDUSGFIND.Visible = false;
                TextBoxRaiseIDUSGFIND.Visible = false;
                PanelRaiseIDUSGFIND.Visible = true;
                PanelRaiseIDUSGFIND2.Visible = true;
                PanelRaiseIDUSGFIND3.Visible = true;
                LabelRespondIDUSGFIND.Visible = false;

            }
        }

    }
    protected void QueryRaiseIDUSGFIND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIDUSGFIND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSGFIND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIDUSGFIND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IDUSGFIND = '" + TextBoxIDUSGFIND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIDUSGFINDMSG.ShowPopupWindow();
        RAISEIDUSGFIND.Visible = false;


    }
    #endregion
    #region QueryCSRSS
    private void SetImageQueryCSRSS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSRSS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCSRSS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCSRSS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCSRSS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCSRSS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCSRSS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCSRSS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSRSS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCSRSS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS2.Visible = false;
                PanelRaiseCSRSS3.Visible = false;
                PanelHideCSRSS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCSRSS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSRSS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCSRSS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS2.Visible = true;
                PanelRaiseCSRSS3.Visible = true;
                PanelHideCSRSS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCSRSS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSRSS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS2.Visible = true;
                PanelRaiseCSRSS3.Visible = false;
                PanelHideCSRSS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCSRSS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSRSS = '" + RadioButtonListCSRSS.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCSRSS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECSRSS.Visible = true;
                RAISECSRSS.ShowPopupWindow();
                QueryRaiseCSRSS.Visible = false;
                TextBoxRaiseCSRSS.Visible = false;
                PanelRaiseCSRSS.Visible = false;
                PanelRaiseCSRSS2.Visible = false;
                PanelRaiseCSRSS3.Visible = false;

                LabelRespondCSRSS.Visible = false;
            }

            else if ((ImageQueryCSRSS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSRSS.Visible = true;
                RAISECSRSS.ShowPopupWindow();
                QueryRaiseCSRSS.Visible = true;
                TextBoxRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS2.Visible = false;
                PanelRaiseCSRSS3.Visible = false;
                LabelRespondCSRSS.Visible = true;
            }

            else if ((ImageQueryCSRSS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSRSS.Visible = true;
                RAISECSRSS.ShowPopupWindow();
                QueryRaiseCSRSS.Visible = false;
                TextBoxRaiseCSRSS.Visible = false;
                PanelRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS2.Visible = true;
                PanelRaiseCSRSS3.Visible = false;
                LabelRespondCSRSS.Visible = false;
            }
            else if ((ImageQueryCSRSS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSRSS.Visible = true;
                RAISECSRSS.ShowPopupWindow();
                QueryRaiseCSRSS.Visible = false;
                TextBoxRaiseCSRSS.Visible = false;
                PanelRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS2.Visible = true;
                PanelRaiseCSRSS3.Visible = true;
                LabelRespondCSRSS.Visible = false;
            }
            else
            {
                RAISECSRSS.Visible = true;
                RAISECSRSS.ShowPopupWindow();
                QueryRaiseCSRSS.Visible = false;
                TextBoxRaiseCSRSS.Visible = false;
                PanelRaiseCSRSS.Visible = true;
                PanelRaiseCSRSS2.Visible = true;
                PanelRaiseCSRSS3.Visible = true;
                LabelRespondCSRSS.Visible = false;

            }
        }

    }
    protected void QueryRaiseCSRSS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseCSRSS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSRSS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSRSS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSRSS = '" + RadioButtonListCSRSS.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECSRSSMSG.ShowPopupWindow();
        RAISECSRSS.Visible = false;


    }
    #endregion
    #region QueryCSBSS
    private void SetImageQueryCSBSS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSBSS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCSBSS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCSBSS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCSBSS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCSBSS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCSBSS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCSBSS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSBSS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCSBSS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS2.Visible = false;
                PanelRaiseCSBSS3.Visible = false;
                PanelHideCSBSS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCSBSS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSBSS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCSBSS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS2.Visible = true;
                PanelRaiseCSBSS3.Visible = true;
                PanelHideCSBSS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCSBSS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSBSS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS2.Visible = true;
                PanelRaiseCSBSS3.Visible = false;
                PanelHideCSBSS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCSBSS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSBSS = '" + RadioButtonListCSBSS.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCSBSS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECSBSS.Visible = true;
                RAISECSBSS.ShowPopupWindow();
                QueryRaiseCSBSS.Visible = false;
                TextBoxRaiseCSBSS.Visible = false;
                PanelRaiseCSBSS.Visible = false;
                PanelRaiseCSBSS2.Visible = false;
                PanelRaiseCSBSS3.Visible = false;

                LabelRespondCSBSS.Visible = false;
            }

            else if ((ImageQueryCSBSS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSBSS.Visible = true;
                RAISECSBSS.ShowPopupWindow();
                QueryRaiseCSBSS.Visible = true;
                TextBoxRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS2.Visible = false;
                PanelRaiseCSBSS3.Visible = false;
                LabelRespondCSBSS.Visible = true;
            }

            else if ((ImageQueryCSBSS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSBSS.Visible = true;
                RAISECSBSS.ShowPopupWindow();
                QueryRaiseCSBSS.Visible = false;
                TextBoxRaiseCSBSS.Visible = false;
                PanelRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS2.Visible = true;
                PanelRaiseCSBSS3.Visible = false;
                LabelRespondCSBSS.Visible = false;
            }
            else if ((ImageQueryCSBSS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSBSS.Visible = true;
                RAISECSBSS.ShowPopupWindow();
                QueryRaiseCSBSS.Visible = false;
                TextBoxRaiseCSBSS.Visible = false;
                PanelRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS2.Visible = true;
                PanelRaiseCSBSS3.Visible = true;
                LabelRespondCSBSS.Visible = false;
            }
            else
            {
                RAISECSBSS.Visible = true;
                RAISECSBSS.ShowPopupWindow();
                QueryRaiseCSBSS.Visible = false;
                TextBoxRaiseCSBSS.Visible = false;
                PanelRaiseCSBSS.Visible = true;
                PanelRaiseCSBSS2.Visible = true;
                PanelRaiseCSBSS3.Visible = true;
                LabelRespondCSBSS.Visible = false;

            }
        }

    }
    protected void QueryRaiseCSBSS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseCSBSS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSBSS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSBSS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSBSS = '" + RadioButtonListCSBSS.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECSBSSMSG.ShowPopupWindow();
        RAISECSBSS.Visible = false;


    }
    #endregion
    #region QueryCSSH
    private void SetImageQueryCSSH()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSH.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCSSH.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCSSH.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCSSH.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCSSH.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCSSH.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCSSH()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSH.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCSSH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCSSH.Visible = true;
                PanelRaiseCSSH2.Visible = false;
                PanelRaiseCSSH3.Visible = false;
                PanelHideCSSH.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCSSH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSSH2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCSSH3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCSSH.Visible = true;
                PanelRaiseCSSH2.Visible = true;
                PanelRaiseCSSH3.Visible = true;
                PanelHideCSSH.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCSSH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSSH2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCSSH.Visible = true;
                PanelRaiseCSSH2.Visible = true;
                PanelRaiseCSSH3.Visible = false;
                PanelHideCSSH.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCSSH_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSSH = '" + RadioButtonListCSSH.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCSSH.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECSSH.Visible = true;
                RAISECSSH.ShowPopupWindow();
                QueryRaiseCSSH.Visible = false;
                TextBoxRaiseCSSH.Visible = false;
                PanelRaiseCSSH.Visible = false;
                PanelRaiseCSSH2.Visible = false;
                PanelRaiseCSSH3.Visible = false;

                LabelRespondCSSH.Visible = false;
            }

            else if ((ImageQueryCSSH.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSSH.Visible = true;
                RAISECSSH.ShowPopupWindow();
                QueryRaiseCSSH.Visible = true;
                TextBoxRaiseCSSH.Visible = true;
                PanelRaiseCSSH.Visible = true;
                PanelRaiseCSSH2.Visible = false;
                PanelRaiseCSSH3.Visible = false;
                LabelRespondCSSH.Visible = true;
            }

            else if ((ImageQueryCSSH.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSSH.Visible = true;
                RAISECSSH.ShowPopupWindow();
                QueryRaiseCSSH.Visible = false;
                TextBoxRaiseCSSH.Visible = false;
                PanelRaiseCSSH.Visible = true;
                PanelRaiseCSSH2.Visible = true;
                PanelRaiseCSSH3.Visible = false;
                LabelRespondCSSH.Visible = false;
            }
            else if ((ImageQueryCSSH.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSSH.Visible = true;
                RAISECSSH.ShowPopupWindow();
                QueryRaiseCSSH.Visible = false;
                TextBoxRaiseCSSH.Visible = false;
                PanelRaiseCSSH.Visible = true;
                PanelRaiseCSSH2.Visible = true;
                PanelRaiseCSSH3.Visible = true;
                LabelRespondCSSH.Visible = false;
            }
            else
            {
                RAISECSSH.Visible = true;
                RAISECSSH.ShowPopupWindow();
                QueryRaiseCSSH.Visible = false;
                TextBoxRaiseCSSH.Visible = false;
                PanelRaiseCSSH.Visible = true;
                PanelRaiseCSSH2.Visible = true;
                PanelRaiseCSSH3.Visible = true;
                LabelRespondCSSH.Visible = false;

            }
        }

    }
    protected void QueryRaiseCSSH_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseCSSH.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSH.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSH.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSSH = '" + RadioButtonListCSSH.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECSSHMSG.ShowPopupWindow();
        RAISECSSH.Visible = false;


    }
    #endregion
    #region QueryCSSHYR
    private void SetImageQueryCSSHYR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSHYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCSSHYR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCSSHYR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCSSHYR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCSSHYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCSSHYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCSSHYR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSHYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCSSHYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR2.Visible = false;
                PanelRaiseCSSHYR3.Visible = false;
                PanelHideCSSHYR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCSSHYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSSHYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCSSHYR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR2.Visible = true;
                PanelRaiseCSSHYR3.Visible = true;
                PanelHideCSSHYR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCSSHYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSSHYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR2.Visible = true;
                PanelRaiseCSSHYR3.Visible = false;
                PanelHideCSSHYR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCSSHYR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSSHYR = '" + TextBoxCSSHYR.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCSSHYR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECSSHYR.Visible = true;
                RAISECSSHYR.ShowPopupWindow();
                QueryRaiseCSSHYR.Visible = false;
                TextBoxRaiseCSSHYR.Visible = false;
                PanelRaiseCSSHYR.Visible = false;
                PanelRaiseCSSHYR2.Visible = false;
                PanelRaiseCSSHYR3.Visible = false;

                LabelRespondCSSHYR.Visible = false;
            }

            else if ((ImageQueryCSSHYR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSSHYR.Visible = true;
                RAISECSSHYR.ShowPopupWindow();
                QueryRaiseCSSHYR.Visible = true;
                TextBoxRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR2.Visible = false;
                PanelRaiseCSSHYR3.Visible = false;
                LabelRespondCSSHYR.Visible = true;
            }

            else if ((ImageQueryCSSHYR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSSHYR.Visible = true;
                RAISECSSHYR.ShowPopupWindow();
                QueryRaiseCSSHYR.Visible = false;
                TextBoxRaiseCSSHYR.Visible = false;
                PanelRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR2.Visible = true;
                PanelRaiseCSSHYR3.Visible = false;
                LabelRespondCSSHYR.Visible = false;
            }
            else if ((ImageQueryCSSHYR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSSHYR.Visible = true;
                RAISECSSHYR.ShowPopupWindow();
                QueryRaiseCSSHYR.Visible = false;
                TextBoxRaiseCSSHYR.Visible = false;
                PanelRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR2.Visible = true;
                PanelRaiseCSSHYR3.Visible = true;
                LabelRespondCSSHYR.Visible = false;
            }
            else
            {
                RAISECSSHYR.Visible = true;
                RAISECSSHYR.ShowPopupWindow();
                QueryRaiseCSSHYR.Visible = false;
                TextBoxRaiseCSSHYR.Visible = false;
                PanelRaiseCSSHYR.Visible = true;
                PanelRaiseCSSHYR2.Visible = true;
                PanelRaiseCSSHYR3.Visible = true;
                LabelRespondCSSHYR.Visible = false;

            }
        }

    }
    protected void QueryRaiseCSSHYR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseCSSHYR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSHYR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSSHYR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSSHYR = '" + TextBoxCSSHYR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECSSHYRMSG.ShowPopupWindow();
        RAISECSSHYR.Visible = false;


    }
    #endregion
    #region QueryCSAUH
    private void SetImageQueryCSAUH()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUH.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCSAUH.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCSAUH.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCSAUH.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCSAUH.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCSAUH.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCSAUH()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUH.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCSAUH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH2.Visible = false;
                PanelRaiseCSAUH3.Visible = false;
                PanelHideCSAUH.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCSAUH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSAUH2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCSAUH3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH2.Visible = true;
                PanelRaiseCSAUH3.Visible = true;
                PanelHideCSAUH.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCSAUH.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSAUH2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH2.Visible = true;
                PanelRaiseCSAUH3.Visible = false;
                PanelHideCSAUH.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCSAUH_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSAUH = '" + RadioButtonListCSAUH.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCSAUH.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECSAUH.Visible = true;
                RAISECSAUH.ShowPopupWindow();
                QueryRaiseCSAUH.Visible = false;
                TextBoxRaiseCSAUH.Visible = false;
                PanelRaiseCSAUH.Visible = false;
                PanelRaiseCSAUH2.Visible = false;
                PanelRaiseCSAUH3.Visible = false;

                LabelRespondCSAUH.Visible = false;
            }

            else if ((ImageQueryCSAUH.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSAUH.Visible = true;
                RAISECSAUH.ShowPopupWindow();
                QueryRaiseCSAUH.Visible = true;
                TextBoxRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH2.Visible = false;
                PanelRaiseCSAUH3.Visible = false;
                LabelRespondCSAUH.Visible = true;
            }

            else if ((ImageQueryCSAUH.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSAUH.Visible = true;
                RAISECSAUH.ShowPopupWindow();
                QueryRaiseCSAUH.Visible = false;
                TextBoxRaiseCSAUH.Visible = false;
                PanelRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH2.Visible = true;
                PanelRaiseCSAUH3.Visible = false;
                LabelRespondCSAUH.Visible = false;
            }
            else if ((ImageQueryCSAUH.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSAUH.Visible = true;
                RAISECSAUH.ShowPopupWindow();
                QueryRaiseCSAUH.Visible = false;
                TextBoxRaiseCSAUH.Visible = false;
                PanelRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH2.Visible = true;
                PanelRaiseCSAUH3.Visible = true;
                LabelRespondCSAUH.Visible = false;
            }
            else
            {
                RAISECSAUH.Visible = true;
                RAISECSAUH.ShowPopupWindow();
                QueryRaiseCSAUH.Visible = false;
                TextBoxRaiseCSAUH.Visible = false;
                PanelRaiseCSAUH.Visible = true;
                PanelRaiseCSAUH2.Visible = true;
                PanelRaiseCSAUH3.Visible = true;
                LabelRespondCSAUH.Visible = false;

            }
        }

    }
    protected void QueryRaiseCSAUH_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseCSAUH.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUH.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUH.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSAUH = '" + RadioButtonListCSAUH.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECSAUHMSG.ShowPopupWindow();
        RAISECSAUH.Visible = false;


    }
    #endregion
    #region QueryCSAUHYR
    private void SetImageQueryCSAUHYR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUHYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCSAUHYR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCSAUHYR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCSAUHYR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCSAUHYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCSAUHYR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCSAUHYR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUHYR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCSAUHYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR2.Visible = false;
                PanelRaiseCSAUHYR3.Visible = false;
                PanelHideCSAUHYR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCSAUHYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSAUHYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCSAUHYR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR2.Visible = true;
                PanelRaiseCSAUHYR3.Visible = true;
                PanelHideCSAUHYR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCSAUHYR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCSAUHYR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR2.Visible = true;
                PanelRaiseCSAUHYR3.Visible = false;
                PanelHideCSAUHYR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCSAUHYR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[IndicationDiagnosis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSAUHYR = '" + TextBoxCSAUHYR.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCSAUHYR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECSAUHYR.Visible = true;
                RAISECSAUHYR.ShowPopupWindow();
                QueryRaiseCSAUHYR.Visible = false;
                TextBoxRaiseCSAUHYR.Visible = false;
                PanelRaiseCSAUHYR.Visible = false;
                PanelRaiseCSAUHYR2.Visible = false;
                PanelRaiseCSAUHYR3.Visible = false;

                LabelRespondCSAUHYR.Visible = false;
            }

            else if ((ImageQueryCSAUHYR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSAUHYR.Visible = true;
                RAISECSAUHYR.ShowPopupWindow();
                QueryRaiseCSAUHYR.Visible = true;
                TextBoxRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR2.Visible = false;
                PanelRaiseCSAUHYR3.Visible = false;
                LabelRespondCSAUHYR.Visible = true;
            }

            else if ((ImageQueryCSAUHYR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSAUHYR.Visible = true;
                RAISECSAUHYR.ShowPopupWindow();
                QueryRaiseCSAUHYR.Visible = false;
                TextBoxRaiseCSAUHYR.Visible = false;
                PanelRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR2.Visible = true;
                PanelRaiseCSAUHYR3.Visible = false;
                LabelRespondCSAUHYR.Visible = false;
            }
            else if ((ImageQueryCSAUHYR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECSAUHYR.Visible = true;
                RAISECSAUHYR.ShowPopupWindow();
                QueryRaiseCSAUHYR.Visible = false;
                TextBoxRaiseCSAUHYR.Visible = false;
                PanelRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR2.Visible = true;
                PanelRaiseCSAUHYR3.Visible = true;
                LabelRespondCSAUHYR.Visible = false;
            }
            else
            {
                RAISECSAUHYR.Visible = true;
                RAISECSAUHYR.ShowPopupWindow();
                QueryRaiseCSAUHYR.Visible = false;
                TextBoxRaiseCSAUHYR.Visible = false;
                PanelRaiseCSAUHYR.Visible = true;
                PanelRaiseCSAUHYR2.Visible = true;
                PanelRaiseCSAUHYR3.Visible = true;
                LabelRespondCSAUHYR.Visible = false;

            }
        }

    }
    protected void QueryRaiseCSAUHYR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseCSAUHYR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUHYR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCSAUHYR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[IndicationDiagnosis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CSAUHYR = '" + TextBoxCSAUHYR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECSAUHYRMSG.ShowPopupWindow();
        RAISECSAUHYR.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListIDAOM.SelectedValue == "Yes")
        {
            hideIDAOMSPY.Visible = true;
            hideIDAOMYR.Visible = true;
        }
        else
        {
            hideIDAOMSPY.Visible = false;
            hideIDAOMYR.Visible = false;
        }

        if (RadioButtonListIDCT.SelectedValue == "Yes")
        {
            hideIDCTFIND.Visible = true;
        }
        else
        {
            hideIDCTFIND.Visible = false;
        }

        if (RadioButtonListIDXRAY.SelectedValue == "Yes")
        {
            hideIDXRAYFIND.Visible = true;
        }
        else
        {
            hideIDXRAYFIND.Visible = false;
        }

        if (RadioButtonListIDUSG.SelectedValue == "Yes")
        {
            hideIDUSGFIND.Visible = true;
        }
        else
        {
            hideIDUSGFIND.Visible = false;
        }

        if (RadioButtonListCSSH.SelectedValue == "Yes")
        {
            hideCSSHYR.Visible = true;
        }
        else
        {
            hideCSSHYR.Visible = false;
        }

        if (RadioButtonListCSAUH.SelectedValue == "Yes")
        {
            hideCSAUHYR.Visible = true;
        }
        else
        {
            hideCSAUHYR.Visible = false;
        }

        if (RadioButtonListIDDIA.SelectedValue == "CLL")
        {
            hideCSRSS.Visible = true;
            hideCSBSS.Visible = true;
        }
        else
        {
            hideCSRSS.Visible = false;
            hideCSBSS.Visible = false;
        }
    }
    protected void RadioButtonListIDAOM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListIDAOM.SelectedValue == "Yes")
        {
            hideIDAOMSPY.Visible = true;
            hideIDAOMYR.Visible = true;
        }
        else
        {
            hideIDAOMSPY.Visible = false;
            hideIDAOMYR.Visible = false;
            TextBoxIDAOMSPY.Text = string.Empty;
            TextBoxIDAOMYR.Text = string.Empty;
        }
    }

    protected void RadioButtonListIDCT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListIDCT.SelectedValue == "Yes")
        {
            hideIDCTFIND.Visible = true;
        }
        else
        {
            hideIDCTFIND.Visible = false;
            TextBoxIDCTFIND.Text = string.Empty;
        }
    }

    protected void RadioButtonListIDXRAY_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListIDXRAY.SelectedValue == "Yes")
        {
            hideIDXRAYFIND.Visible = true;
        }
        else
        {
            hideIDXRAYFIND.Visible = false;
            TextBoxIDXRAYFIND.Text = string.Empty;
        }
    }

    protected void RadioButtonListIDUSG_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListIDUSG.SelectedValue == "Yes")
        {
            hideIDUSGFIND.Visible = true;
        }
        else
        {
            hideIDUSGFIND.Visible = false;
            TextBoxIDUSGFIND.Text = string.Empty;
        }
    }

    protected void RadioButtonListCSSH_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListCSSH.SelectedValue == "Yes")
        {
            hideCSSHYR.Visible = true;
        }
        else
        {
            hideCSSHYR.Visible = false;
            TextBoxCSSHYR.Text = string.Empty;
        }
    }

    protected void RadioButtonListCSAUH_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListCSAUH.SelectedValue == "Yes")
        {
            hideCSAUHYR.Visible = true;
        }
        else
        {
            hideCSAUHYR.Visible = false;
            TextBoxCSAUHYR.Text = string.Empty;
        }
    }

    protected void RadioButtonListIDDIA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListIDDIA.SelectedValue== "CLL")
        {
            hideCSRSS.Visible = true;
            hideCSBSS.Visible = true;
        }
        else
        {
            hideCSRSS.Visible = false;
            hideCSBSS.Visible = false;
            RadioButtonListCSRSS.ClearSelection();
            RadioButtonListCSBSS.ClearSelection();
        }
    }
}