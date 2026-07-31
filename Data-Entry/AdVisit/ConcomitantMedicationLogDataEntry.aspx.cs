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

public partial class Data_Entry_AdVisit_ConcomitantMedicationLogDataEntry : System.Web.UI.Page
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
        SetImageAddNote();
        BindGridviewAddNote();
        SetImageAttach();
        BindGridViewADDAddAttachment();

        SetImageAttachPageHistory();
        BindGridViewADDAttachmentPageHistory();
        AEAutoGNumber();
        TextBoxCMLSD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        TextBoxCMLED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        SetImageQueryCNSNO();
        SetImageQueryCMLMN();
        SetImageQueryCMLMT();
        SetImageQueryCMLMTO();
        SetImageQueryCMLIND();
        SetImageQueryCMLDS();
        SetImageQueryCMLUT();
        SetImageQueryCMLUTO();
        SetImageQueryCMLFRQ();
        SetImageQueryCMLFRQO();
        SetImageQueryCMLRT();
        SetImageQueryCMLRTO();
        SetImageQueryCMLSD();
        SetImageQueryCMLED();
        SetImageQueryCMLONGO();

        BindQueryDataCNSNO();
        BindQueryDataCMLMN();
        BindQueryDataCMLMT();
        BindQueryDataCMLMTO();
        BindQueryDataCMLIND();
        BindQueryDataCMLDS();
        BindQueryDataCMLUT();
        BindQueryDataCMLUTO();
        BindQueryDataCMLFRQ();
        BindQueryDataCMLFRQO();
        BindQueryDataCMLRT();
        BindQueryDataCMLRTO();
        BindQueryDataCMLSD();
        BindQueryDataCMLED();
        BindQueryDataCMLONGO();

        ShowHide();
    }
    #region Note Acttchment and PageHistory
    #region AddNote
    private void SetImageAddNote()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from ADDNOTE  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and Page = '" + lblPage.Text + "'", con);
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

        cmd = new SqlCommand("insert into ADDNOTE values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + AddNoteFiledTextBox.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','" + AddNoteTextBox.Text + "','" + TextBoxCNSNO.Text + "')", con);
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
            SqlCommand cmd = new SqlCommand("select * from ADDNOTE where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxCNSNO.Text + "'  and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
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
        SqlCommand cmd = new SqlCommand("Select * from ADDATTACHMENT  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxCNSNO.Text + "'", con);
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
                        cmd.Parameters.AddWithValue("@SNO", TextBoxCNSNO.Text);
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
                cmd.CommandText = "select ID,Site,ScreenID,SubInitial ,Visit,Page,Field,Username,Date,Title,Name ,ContentType,Data from ADDATTACHMENT where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxCNSNO.Text + "'";
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
        SqlCommand cmd = new SqlCommand("Select * from tblReasonForChange  where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'", con);
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
                cmd.CommandText = "SELECT ID, [QuestionText],[OldValue],[NewValue],[Reason],[PageName],[EUser],[EDate] FROM [dbo].[tblReasonForChange] where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'and SNO = '" + TextBoxCNSNO.Text + "'";
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
        SqlCommand sqlCmd = new SqlCommand("SELECT CNSNO ,CMLMN ,CMLMT ,CMLMTO ,CMLIND ,CMLDS ,CMLUT ,CMLUTO ,CMLFRQ ,CMLFRQO ,CMLRT ,CMLRTO ,CMLSD ,CMLED ,CMLONGO FROM [Add].[ConcomitantMedicationLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxCNSNO.Text = dt.Rows[0]["CNSNO"].ToString();
            TextBoxCMLMN.Text = dt.Rows[0]["CMLMN"].ToString();
            RadioButtonListCMLMT.SelectedValue = dt.Rows[0]["CMLMT"].ToString();
            TextBoxCMLMTO.Text = dt.Rows[0]["CMLMTO"].ToString();
            TextBoxCMLIND.Text = dt.Rows[0]["CMLIND"].ToString();
            TextBoxCMLDS.Text = dt.Rows[0]["CMLDS"].ToString();
            RadioButtonListCMLUT.SelectedValue = dt.Rows[0]["CMLUT"].ToString();
            TextBoxCMLUTO.Text = dt.Rows[0]["CMLUTO"].ToString();
            RadioButtonListCMLFRQ.SelectedValue = dt.Rows[0]["CMLFRQ"].ToString();
            TextBoxCMLFRQO.Text = dt.Rows[0]["CMLFRQO"].ToString();
            RadioButtonListCMLRT.SelectedValue = dt.Rows[0]["CMLRT"].ToString();
            TextBoxCMLRTO.Text = dt.Rows[0]["CMLRTO"].ToString();
            TextBoxCMLSD.Text = dt.Rows[0]["CMLSD"].ToString();
            TextBoxCMLED.Text = dt.Rows[0]["CMLED"].ToString();
            RadioButtonListCMLONGO.SelectedValue = dt.Rows[0]["CMLONGO"].ToString();

            ViewState["txt1"] = TextBoxCNSNO.Text;
            ViewState["txt2"] = TextBoxCMLMN.Text;
            ViewState["txt3"] = RadioButtonListCMLMT.SelectedValue;
            ViewState["txt4"] = TextBoxCMLMTO.Text;
            ViewState["txt5"] = TextBoxCMLIND.Text;
            ViewState["txt6"] = TextBoxCMLDS.Text;
            ViewState["txt7"] = RadioButtonListCMLUT.SelectedValue;
            ViewState["txt8"] = TextBoxCMLUTO.Text;
            ViewState["txt9"] = RadioButtonListCMLFRQ.SelectedValue;
            ViewState["txt10"] = TextBoxCMLFRQO.Text;
            ViewState["txt11"] = RadioButtonListCMLRT.SelectedValue;
            ViewState["txt12"] = TextBoxCMLRTO.Text;
            ViewState["txt13"] = TextBoxCMLSD.Text;
            ViewState["txt14"] = TextBoxCMLED.Text;
            ViewState["txt15"] = RadioButtonListCMLONGO.SelectedValue;
        }
        con.Close();

    }

    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Add].[ConcomitantMedicationLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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

        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            con.Close();
            cmd = new SqlCommand("[Add].[sp_ConcomitantMedicationLog]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@CNSNO", TextBoxCNSNO.Text);
            cmd.Parameters.AddWithValue("@CMLMN", TextBoxCMLMN.Text);
            cmd.Parameters.AddWithValue("@CMLMT", RadioButtonListCMLMT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLMTO", TextBoxCMLMTO.Text);
            cmd.Parameters.AddWithValue("@CMLIND", TextBoxCMLIND.Text);
            cmd.Parameters.AddWithValue("@CMLDS", TextBoxCMLDS.Text);
            cmd.Parameters.AddWithValue("@CMLUT", RadioButtonListCMLUT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLUTO", TextBoxCMLUTO.Text);
            cmd.Parameters.AddWithValue("@CMLFRQ", RadioButtonListCMLFRQ.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLFRQO", TextBoxCMLFRQO.Text);
            cmd.Parameters.AddWithValue("@CMLRT", RadioButtonListCMLRT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLRTO", TextBoxCMLRTO.Text);
            cmd.Parameters.AddWithValue("@CMLSD", TextBoxCMLSD.Text);
            cmd.Parameters.AddWithValue("@CMLED", TextBoxCMLED.Text);
            cmd.Parameters.AddWithValue("@CMLONGO", RadioButtonListCMLONGO.SelectedValue);

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
    public void OnConfirm1(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            con.Close();
            cmd = new SqlCommand("[Add].[sp_ConcomitantMedicationLog]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@CNSNO", TextBoxCNSNO.Text);
            cmd.Parameters.AddWithValue("@CMLMN", TextBoxCMLMN.Text);
            cmd.Parameters.AddWithValue("@CMLMT", RadioButtonListCMLMT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLMTO", TextBoxCMLMTO.Text);
            cmd.Parameters.AddWithValue("@CMLIND", TextBoxCMLIND.Text);
            cmd.Parameters.AddWithValue("@CMLDS", TextBoxCMLDS.Text);
            cmd.Parameters.AddWithValue("@CMLUT", RadioButtonListCMLUT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLUTO", TextBoxCMLUTO.Text);
            cmd.Parameters.AddWithValue("@CMLFRQ", RadioButtonListCMLFRQ.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLFRQO", TextBoxCMLFRQO.Text);
            cmd.Parameters.AddWithValue("@CMLRT", RadioButtonListCMLRT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLRTO", TextBoxCMLRTO.Text);
            cmd.Parameters.AddWithValue("@CMLSD", TextBoxCMLSD.Text);
            cmd.Parameters.AddWithValue("@CMLED", TextBoxCMLED.Text);
            cmd.Parameters.AddWithValue("@CMLONGO", RadioButtonListCMLONGO.SelectedValue);

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
        if (!string.IsNullOrEmpty(TextBoxCNSNO.Text) || !string.IsNullOrEmpty(TextBoxCMLMN.Text) || !string.IsNullOrEmpty(RadioButtonListCMLMT.SelectedValue) || !string.IsNullOrEmpty(TextBoxCMLMTO.Text) || !string.IsNullOrEmpty(TextBoxCMLIND.Text) || !string.IsNullOrEmpty(TextBoxCMLDS.Text) || !string.IsNullOrEmpty(RadioButtonListCMLUT.SelectedValue) || !string.IsNullOrEmpty(TextBoxCMLUTO.Text) || !string.IsNullOrEmpty(RadioButtonListCMLFRQ.SelectedValue) || !string.IsNullOrEmpty(TextBoxCMLFRQO.Text) || !string.IsNullOrEmpty(RadioButtonListCMLRT.SelectedValue) || !string.IsNullOrEmpty(TextBoxCMLRTO.Text) || !string.IsNullOrEmpty(TextBoxCMLSD.Text) || !string.IsNullOrEmpty(TextBoxCMLED.Text) || !string.IsNullOrEmpty(RadioButtonListCMLONGO.SelectedValue))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString().Trim() != TextBoxCNSNO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCNSNO.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = TextBoxCNSNO.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString().Trim() != TextBoxCMLMN.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLMN.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxCMLMN.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString().Trim() != RadioButtonListCMLMT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLMT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = RadioButtonListCMLMT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString().Trim() != TextBoxCMLMTO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLMTO.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxCMLMTO.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString().Trim() != TextBoxCMLIND.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLIND.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxCMLIND.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString().Trim() != TextBoxCMLDS.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLDS.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxCMLDS.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString().Trim() != RadioButtonListCMLUT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLUT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListCMLUT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString().Trim() != TextBoxCMLUTO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLUTO.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = TextBoxCMLUTO.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString().Trim() != RadioButtonListCMLFRQ.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLFRQ.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListCMLFRQ.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString().Trim() != TextBoxCMLFRQO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLFRQO.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = TextBoxCMLFRQO.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString().Trim() != RadioButtonListCMLRT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLRT.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = RadioButtonListCMLRT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString().Trim() != TextBoxCMLRTO.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLRTO.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = TextBoxCMLRTO.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString().Trim() != TextBoxCMLSD.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLSD.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = TextBoxCMLSD.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString().Trim() != TextBoxCMLED.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLED.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = TextBoxCMLED.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString().Trim() != RadioButtonListCMLONGO.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblCMLONGO.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = RadioButtonListCMLONGO.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Add].[sp_ConcomitantMedicationLog]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@CNSNO", TextBoxCNSNO.Text);
            cmd.Parameters.AddWithValue("@CMLMN", TextBoxCMLMN.Text);
            cmd.Parameters.AddWithValue("@CMLMT", RadioButtonListCMLMT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLMTO", TextBoxCMLMTO.Text);
            cmd.Parameters.AddWithValue("@CMLIND", TextBoxCMLIND.Text);
            cmd.Parameters.AddWithValue("@CMLDS", TextBoxCMLDS.Text);
            cmd.Parameters.AddWithValue("@CMLUT", RadioButtonListCMLUT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLUTO", TextBoxCMLUTO.Text);
            cmd.Parameters.AddWithValue("@CMLFRQ", RadioButtonListCMLFRQ.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLFRQO", TextBoxCMLFRQO.Text);
            cmd.Parameters.AddWithValue("@CMLRT", RadioButtonListCMLRT.SelectedValue);
            cmd.Parameters.AddWithValue("@CMLRTO", TextBoxCMLRTO.Text);
            cmd.Parameters.AddWithValue("@CMLSD", TextBoxCMLSD.Text);
            cmd.Parameters.AddWithValue("@CMLED", TextBoxCMLED.Text);
            cmd.Parameters.AddWithValue("@CMLONGO", RadioButtonListCMLONGO.SelectedValue);

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
            cmd.CommandText = "INSERT INTO tblReasonForChange (Site,  SubId,  Subini,  QuestionText,  OldValue,  NewValue,  Reason, PageName,  EUser,SNO) VALUES        (@Site,  @SubId,  @Subini,  @QuestionText,  @OldValue,  @NewValue,  @Reason, @PageName,  @EUser,@SNO)";
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
            cmd.Parameters.AddWithValue("@SNO", TextBoxCNSNO.Text);

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

  
    private void AEAutoGNumber()
    {
        con.Close();
        con.Open();
        DataTable dt1 = new DataTable();
        SqlCommand cmd = new SqlCommand("SELECT Count(CNSNO) as tot FROM [Add].[ConcomitantMedicationLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa1 = new SqlDataAdapter(cmd);
        sqlDa1.Fill(dt1);
        var value = dt1.Rows[0]["tot"].ToString();
        if (value == "0")
        {
            SqlCommand cmd1 = new SqlCommand("SELECT Count(CNSNO) as tot FROM [Add].[ConcomitantMedicationLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);

            SqlDataReader dr1;

            dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    int i = Convert.ToInt32(dr1["tot"]);

                    if (i > 0)
                    {
                        int j = i + 1;
                        TextBoxCNSNO.Text = j.ToString("000");

                    }
                    else
                    {
                        TextBoxCNSNO.Text = "001";
                    }

                }
            }
            else
            {
                TextBoxCNSNO.Text = "000";
            }
            con.Close();
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand("SELECT MAX(CNSNO) as tot FROM [Add].[ConcomitantMedicationLog] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);

            SqlDataReader dr1;

            dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    int i = Convert.ToInt32(dr1["tot"]);

                    if (i > 0)
                    {
                        int j = i + 1;
                        TextBoxCNSNO.Text = j.ToString("000");

                    }
                    else
                    {
                        TextBoxCNSNO.Text = "001";
                    }

                }
            }
            else
            {
                TextBoxCNSNO.Text = "000";
            }
            con.Close();
        }
    }

    #region Query
    #region QueryCNSNO
    private void SetImageQueryCNSNO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "'  and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCNSNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCNSNO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCNSNO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCNSNO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCNSNO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCNSNO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCNSNO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCNSNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCNSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO2.Visible = false;
                PanelRaiseCNSNO3.Visible = false;
                PanelHideCNSNO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCNSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCNSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCNSNO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO2.Visible = true;
                PanelRaiseCNSNO3.Visible = true;
                PanelHideCNSNO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCNSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCNSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO2.Visible = true;
                PanelRaiseCNSNO3.Visible = false;
                PanelHideCNSNO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCNSNO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CNSNO = '" + TextBoxCNSNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCNSNO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECNSNO.Visible = true;
                RAISECNSNO.ShowPopupWindow();
                QueryRaiseCNSNO.Visible = false;
                TextBoxRaiseCNSNO.Visible = false;
                PanelRaiseCNSNO.Visible = false;
                PanelRaiseCNSNO2.Visible = false;
                PanelRaiseCNSNO3.Visible = false;

                LabelRespondCNSNO.Visible = false;
            }

            else if ((ImageQueryCNSNO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECNSNO.Visible = true;
                RAISECNSNO.ShowPopupWindow();
                QueryRaiseCNSNO.Visible = true;
                TextBoxRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO2.Visible = false;
                PanelRaiseCNSNO3.Visible = false;
                LabelRespondCNSNO.Visible = true;
            }

            else if ((ImageQueryCNSNO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECNSNO.Visible = true;
                RAISECNSNO.ShowPopupWindow();
                QueryRaiseCNSNO.Visible = false;
                TextBoxRaiseCNSNO.Visible = false;
                PanelRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO2.Visible = true;
                PanelRaiseCNSNO3.Visible = false;
                LabelRespondCNSNO.Visible = false;
            }
            else if ((ImageQueryCNSNO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECNSNO.Visible = true;
                RAISECNSNO.ShowPopupWindow();
                QueryRaiseCNSNO.Visible = false;
                TextBoxRaiseCNSNO.Visible = false;
                PanelRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO2.Visible = true;
                PanelRaiseCNSNO3.Visible = true;
                LabelRespondCNSNO.Visible = false;
            }
            else
            {
                RAISECNSNO.Visible = true;
                RAISECNSNO.ShowPopupWindow();
                QueryRaiseCNSNO.Visible = false;
                TextBoxRaiseCNSNO.Visible = false;
                PanelRaiseCNSNO.Visible = true;
                PanelRaiseCNSNO2.Visible = true;
                PanelRaiseCNSNO3.Visible = true;
                LabelRespondCNSNO.Visible = false;

            }
        }

    }
    protected void QueryRaiseCNSNO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCNSNO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCNSNO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCNSNO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECNSNOMSG.ShowPopupWindow();
        RAISECNSNO.Visible = false;


    }
    #endregion
    #region QueryCMLMN
    private void SetImageQueryCMLMN()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLMN.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLMN.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLMN.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLMN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLMN.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLMN()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMN.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLMN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN2.Visible = false;
                PanelRaiseCMLMN3.Visible = false;
                PanelHideCMLMN.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLMN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLMN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLMN3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN2.Visible = true;
                PanelRaiseCMLMN3.Visible = true;
                PanelHideCMLMN.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLMN.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLMN2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN2.Visible = true;
                PanelRaiseCMLMN3.Visible = false;
                PanelHideCMLMN.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLMN_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLMN = '" + TextBoxCMLMN.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLMN.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLMN.Visible = true;
                RAISECMLMN.ShowPopupWindow();
                QueryRaiseCMLMN.Visible = false;
                TextBoxRaiseCMLMN.Visible = false;
                PanelRaiseCMLMN.Visible = false;
                PanelRaiseCMLMN2.Visible = false;
                PanelRaiseCMLMN3.Visible = false;

                LabelRespondCMLMN.Visible = false;
            }

            else if ((ImageQueryCMLMN.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMN.Visible = true;
                RAISECMLMN.ShowPopupWindow();
                QueryRaiseCMLMN.Visible = true;
                TextBoxRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN2.Visible = false;
                PanelRaiseCMLMN3.Visible = false;
                LabelRespondCMLMN.Visible = true;
            }

            else if ((ImageQueryCMLMN.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMN.Visible = true;
                RAISECMLMN.ShowPopupWindow();
                QueryRaiseCMLMN.Visible = false;
                TextBoxRaiseCMLMN.Visible = false;
                PanelRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN2.Visible = true;
                PanelRaiseCMLMN3.Visible = false;
                LabelRespondCMLMN.Visible = false;
            }
            else if ((ImageQueryCMLMN.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMN.Visible = true;
                RAISECMLMN.ShowPopupWindow();
                QueryRaiseCMLMN.Visible = false;
                TextBoxRaiseCMLMN.Visible = false;
                PanelRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN2.Visible = true;
                PanelRaiseCMLMN3.Visible = true;
                LabelRespondCMLMN.Visible = false;
            }
            else
            {
                RAISECMLMN.Visible = true;
                RAISECMLMN.ShowPopupWindow();
                QueryRaiseCMLMN.Visible = false;
                TextBoxRaiseCMLMN.Visible = false;
                PanelRaiseCMLMN.Visible = true;
                PanelRaiseCMLMN2.Visible = true;
                PanelRaiseCMLMN3.Visible = true;
                LabelRespondCMLMN.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLMN_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLMN.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLMN.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMN.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLMN = '" + TextBoxCMLMN.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLMNMSG.ShowPopupWindow();
        RAISECMLMN.Visible = false;


    }
    #endregion
    #region QueryCMLMTO
    private void SetImageQueryCMLMTO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMTO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLMTO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLMTO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLMTO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLMTO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLMTO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLMTO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMTO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLMTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO2.Visible = false;
                PanelRaiseCMLMTO3.Visible = false;
                PanelHideCMLMTO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLMTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLMTO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLMTO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO2.Visible = true;
                PanelRaiseCMLMTO3.Visible = true;
                PanelHideCMLMTO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLMTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLMTO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO2.Visible = true;
                PanelRaiseCMLMTO3.Visible = false;
                PanelHideCMLMTO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLMTO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLMTO = '" + TextBoxCMLMTO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLMTO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLMTO.Visible = true;
                RAISECMLMTO.ShowPopupWindow();
                QueryRaiseCMLMTO.Visible = false;
                TextBoxRaiseCMLMTO.Visible = false;
                PanelRaiseCMLMTO.Visible = false;
                PanelRaiseCMLMTO2.Visible = false;
                PanelRaiseCMLMTO3.Visible = false;

                LabelRespondCMLMTO.Visible = false;
            }

            else if ((ImageQueryCMLMTO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMTO.Visible = true;
                RAISECMLMTO.ShowPopupWindow();
                QueryRaiseCMLMTO.Visible = true;
                TextBoxRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO2.Visible = false;
                PanelRaiseCMLMTO3.Visible = false;
                LabelRespondCMLMTO.Visible = true;
            }

            else if ((ImageQueryCMLMTO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMTO.Visible = true;
                RAISECMLMTO.ShowPopupWindow();
                QueryRaiseCMLMTO.Visible = false;
                TextBoxRaiseCMLMTO.Visible = false;
                PanelRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO2.Visible = true;
                PanelRaiseCMLMTO3.Visible = false;
                LabelRespondCMLMTO.Visible = false;
            }
            else if ((ImageQueryCMLMTO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMTO.Visible = true;
                RAISECMLMTO.ShowPopupWindow();
                QueryRaiseCMLMTO.Visible = false;
                TextBoxRaiseCMLMTO.Visible = false;
                PanelRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO2.Visible = true;
                PanelRaiseCMLMTO3.Visible = true;
                LabelRespondCMLMTO.Visible = false;
            }
            else
            {
                RAISECMLMTO.Visible = true;
                RAISECMLMTO.ShowPopupWindow();
                QueryRaiseCMLMTO.Visible = false;
                TextBoxRaiseCMLMTO.Visible = false;
                PanelRaiseCMLMTO.Visible = true;
                PanelRaiseCMLMTO2.Visible = true;
                PanelRaiseCMLMTO3.Visible = true;
                LabelRespondCMLMTO.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLMTO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLMTO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLMTO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMTO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLMTO = '" + TextBoxCMLMTO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLMTOMSG.ShowPopupWindow();
        RAISECMLMTO.Visible = false;


    }
    #endregion
    #region QueryCMLIND
    private void SetImageQueryCMLIND()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLIND.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLIND.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLIND.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLIND.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLIND()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLIND.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND2.Visible = false;
                PanelRaiseCMLIND3.Visible = false;
                PanelHideCMLIND.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLIND3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND2.Visible = true;
                PanelRaiseCMLIND3.Visible = true;
                PanelHideCMLIND.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLIND.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLIND2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND2.Visible = true;
                PanelRaiseCMLIND3.Visible = false;
                PanelHideCMLIND.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLIND_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLIND = '" + TextBoxCMLIND.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLIND.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLIND.Visible = true;
                RAISECMLIND.ShowPopupWindow();
                QueryRaiseCMLIND.Visible = false;
                TextBoxRaiseCMLIND.Visible = false;
                PanelRaiseCMLIND.Visible = false;
                PanelRaiseCMLIND2.Visible = false;
                PanelRaiseCMLIND3.Visible = false;

                LabelRespondCMLIND.Visible = false;
            }

            else if ((ImageQueryCMLIND.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLIND.Visible = true;
                RAISECMLIND.ShowPopupWindow();
                QueryRaiseCMLIND.Visible = true;
                TextBoxRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND2.Visible = false;
                PanelRaiseCMLIND3.Visible = false;
                LabelRespondCMLIND.Visible = true;
            }

            else if ((ImageQueryCMLIND.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLIND.Visible = true;
                RAISECMLIND.ShowPopupWindow();
                QueryRaiseCMLIND.Visible = false;
                TextBoxRaiseCMLIND.Visible = false;
                PanelRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND2.Visible = true;
                PanelRaiseCMLIND3.Visible = false;
                LabelRespondCMLIND.Visible = false;
            }
            else if ((ImageQueryCMLIND.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLIND.Visible = true;
                RAISECMLIND.ShowPopupWindow();
                QueryRaiseCMLIND.Visible = false;
                TextBoxRaiseCMLIND.Visible = false;
                PanelRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND2.Visible = true;
                PanelRaiseCMLIND3.Visible = true;
                LabelRespondCMLIND.Visible = false;
            }
            else
            {
                RAISECMLIND.Visible = true;
                RAISECMLIND.ShowPopupWindow();
                QueryRaiseCMLIND.Visible = false;
                TextBoxRaiseCMLIND.Visible = false;
                PanelRaiseCMLIND.Visible = true;
                PanelRaiseCMLIND2.Visible = true;
                PanelRaiseCMLIND3.Visible = true;
                LabelRespondCMLIND.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLIND_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLIND.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLIND.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLIND.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLIND = '" + TextBoxCMLIND.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLINDMSG.ShowPopupWindow();
        RAISECMLIND.Visible = false;


    }
    #endregion
    #region QueryCMLDS
    private void SetImageQueryCMLDS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLDS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLDS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLDS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLDS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLDS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLDS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLDS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLDS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLDS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS2.Visible = false;
                PanelRaiseCMLDS3.Visible = false;
                PanelHideCMLDS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLDS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLDS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLDS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS2.Visible = true;
                PanelRaiseCMLDS3.Visible = true;
                PanelHideCMLDS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLDS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLDS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS2.Visible = true;
                PanelRaiseCMLDS3.Visible = false;
                PanelHideCMLDS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLDS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLDS = '" + TextBoxCMLDS.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLDS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLDS.Visible = true;
                RAISECMLDS.ShowPopupWindow();
                QueryRaiseCMLDS.Visible = false;
                TextBoxRaiseCMLDS.Visible = false;
                PanelRaiseCMLDS.Visible = false;
                PanelRaiseCMLDS2.Visible = false;
                PanelRaiseCMLDS3.Visible = false;

                LabelRespondCMLDS.Visible = false;
            }

            else if ((ImageQueryCMLDS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLDS.Visible = true;
                RAISECMLDS.ShowPopupWindow();
                QueryRaiseCMLDS.Visible = true;
                TextBoxRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS2.Visible = false;
                PanelRaiseCMLDS3.Visible = false;
                LabelRespondCMLDS.Visible = true;
            }

            else if ((ImageQueryCMLDS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLDS.Visible = true;
                RAISECMLDS.ShowPopupWindow();
                QueryRaiseCMLDS.Visible = false;
                TextBoxRaiseCMLDS.Visible = false;
                PanelRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS2.Visible = true;
                PanelRaiseCMLDS3.Visible = false;
                LabelRespondCMLDS.Visible = false;
            }
            else if ((ImageQueryCMLDS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLDS.Visible = true;
                RAISECMLDS.ShowPopupWindow();
                QueryRaiseCMLDS.Visible = false;
                TextBoxRaiseCMLDS.Visible = false;
                PanelRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS2.Visible = true;
                PanelRaiseCMLDS3.Visible = true;
                LabelRespondCMLDS.Visible = false;
            }
            else
            {
                RAISECMLDS.Visible = true;
                RAISECMLDS.ShowPopupWindow();
                QueryRaiseCMLDS.Visible = false;
                TextBoxRaiseCMLDS.Visible = false;
                PanelRaiseCMLDS.Visible = true;
                PanelRaiseCMLDS2.Visible = true;
                PanelRaiseCMLDS3.Visible = true;
                LabelRespondCMLDS.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLDS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLDS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLDS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLDS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLDS = '" + TextBoxCMLDS.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLDSMSG.ShowPopupWindow();
        RAISECMLDS.Visible = false;


    }
    #endregion
    #region QueryCMLUTO
    private void SetImageQueryCMLUTO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLUTO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLUTO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLUTO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLUTO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLUTO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLUTO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLUTO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLUTO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLUTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO2.Visible = false;
                PanelRaiseCMLUTO3.Visible = false;
                PanelHideCMLUTO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLUTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLUTO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLUTO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO2.Visible = true;
                PanelRaiseCMLUTO3.Visible = true;
                PanelHideCMLUTO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLUTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLUTO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO2.Visible = true;
                PanelRaiseCMLUTO3.Visible = false;
                PanelHideCMLUTO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLUTO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLUTO = '" + TextBoxCMLUTO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLUTO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLUTO.Visible = true;
                RAISECMLUTO.ShowPopupWindow();
                QueryRaiseCMLUTO.Visible = false;
                TextBoxRaiseCMLUTO.Visible = false;
                PanelRaiseCMLUTO.Visible = false;
                PanelRaiseCMLUTO2.Visible = false;
                PanelRaiseCMLUTO3.Visible = false;

                LabelRespondCMLUTO.Visible = false;
            }

            else if ((ImageQueryCMLUTO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLUTO.Visible = true;
                RAISECMLUTO.ShowPopupWindow();
                QueryRaiseCMLUTO.Visible = true;
                TextBoxRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO2.Visible = false;
                PanelRaiseCMLUTO3.Visible = false;
                LabelRespondCMLUTO.Visible = true;
            }

            else if ((ImageQueryCMLUTO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLUTO.Visible = true;
                RAISECMLUTO.ShowPopupWindow();
                QueryRaiseCMLUTO.Visible = false;
                TextBoxRaiseCMLUTO.Visible = false;
                PanelRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO2.Visible = true;
                PanelRaiseCMLUTO3.Visible = false;
                LabelRespondCMLUTO.Visible = false;
            }
            else if ((ImageQueryCMLUTO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLUTO.Visible = true;
                RAISECMLUTO.ShowPopupWindow();
                QueryRaiseCMLUTO.Visible = false;
                TextBoxRaiseCMLUTO.Visible = false;
                PanelRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO2.Visible = true;
                PanelRaiseCMLUTO3.Visible = true;
                LabelRespondCMLUTO.Visible = false;
            }
            else
            {
                RAISECMLUTO.Visible = true;
                RAISECMLUTO.ShowPopupWindow();
                QueryRaiseCMLUTO.Visible = false;
                TextBoxRaiseCMLUTO.Visible = false;
                PanelRaiseCMLUTO.Visible = true;
                PanelRaiseCMLUTO2.Visible = true;
                PanelRaiseCMLUTO3.Visible = true;
                LabelRespondCMLUTO.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLUTO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLUTO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLUTO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLUTO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLUTO = '" + TextBoxCMLUTO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLUTOMSG.ShowPopupWindow();
        RAISECMLUTO.Visible = false;


    }
    #endregion
    #region QueryCMLFRQO
    private void SetImageQueryCMLFRQO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLFRQO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLFRQO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLFRQO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLFRQO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLFRQO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLFRQO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLFRQO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLFRQO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLFRQO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO2.Visible = false;
                PanelRaiseCMLFRQO3.Visible = false;
                PanelHideCMLFRQO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLFRQO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLFRQO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLFRQO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO2.Visible = true;
                PanelRaiseCMLFRQO3.Visible = true;
                PanelHideCMLFRQO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLFRQO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLFRQO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO2.Visible = true;
                PanelRaiseCMLFRQO3.Visible = false;
                PanelHideCMLFRQO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLFRQO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLFRQO = '" + TextBoxCMLFRQO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLFRQO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLFRQO.Visible = true;
                RAISECMLFRQO.ShowPopupWindow();
                QueryRaiseCMLFRQO.Visible = false;
                TextBoxRaiseCMLFRQO.Visible = false;
                PanelRaiseCMLFRQO.Visible = false;
                PanelRaiseCMLFRQO2.Visible = false;
                PanelRaiseCMLFRQO3.Visible = false;

                LabelRespondCMLFRQO.Visible = false;
            }

            else if ((ImageQueryCMLFRQO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLFRQO.Visible = true;
                RAISECMLFRQO.ShowPopupWindow();
                QueryRaiseCMLFRQO.Visible = true;
                TextBoxRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO2.Visible = false;
                PanelRaiseCMLFRQO3.Visible = false;
                LabelRespondCMLFRQO.Visible = true;
            }

            else if ((ImageQueryCMLFRQO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLFRQO.Visible = true;
                RAISECMLFRQO.ShowPopupWindow();
                QueryRaiseCMLFRQO.Visible = false;
                TextBoxRaiseCMLFRQO.Visible = false;
                PanelRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO2.Visible = true;
                PanelRaiseCMLFRQO3.Visible = false;
                LabelRespondCMLFRQO.Visible = false;
            }
            else if ((ImageQueryCMLFRQO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLFRQO.Visible = true;
                RAISECMLFRQO.ShowPopupWindow();
                QueryRaiseCMLFRQO.Visible = false;
                TextBoxRaiseCMLFRQO.Visible = false;
                PanelRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO2.Visible = true;
                PanelRaiseCMLFRQO3.Visible = true;
                LabelRespondCMLFRQO.Visible = false;
            }
            else
            {
                RAISECMLFRQO.Visible = true;
                RAISECMLFRQO.ShowPopupWindow();
                QueryRaiseCMLFRQO.Visible = false;
                TextBoxRaiseCMLFRQO.Visible = false;
                PanelRaiseCMLFRQO.Visible = true;
                PanelRaiseCMLFRQO2.Visible = true;
                PanelRaiseCMLFRQO3.Visible = true;
                LabelRespondCMLFRQO.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLFRQO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLFRQO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLFRQO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLFRQO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLFRQO = '" + TextBoxCMLFRQO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLFRQOMSG.ShowPopupWindow();
        RAISECMLFRQO.Visible = false;


    }
    #endregion
    #region QueryCMLRTO
    private void SetImageQueryCMLRTO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLRTO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLRTO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLRTO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLRTO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLRTO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLRTO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLRTO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLRTO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLRTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO2.Visible = false;
                PanelRaiseCMLRTO3.Visible = false;
                PanelHideCMLRTO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLRTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLRTO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLRTO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO2.Visible = true;
                PanelRaiseCMLRTO3.Visible = true;
                PanelHideCMLRTO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLRTO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLRTO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO2.Visible = true;
                PanelRaiseCMLRTO3.Visible = false;
                PanelHideCMLRTO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLRTO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLRTO = '" + TextBoxCMLRTO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLRTO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLRTO.Visible = true;
                RAISECMLRTO.ShowPopupWindow();
                QueryRaiseCMLRTO.Visible = false;
                TextBoxRaiseCMLRTO.Visible = false;
                PanelRaiseCMLRTO.Visible = false;
                PanelRaiseCMLRTO2.Visible = false;
                PanelRaiseCMLRTO3.Visible = false;

                LabelRespondCMLRTO.Visible = false;
            }

            else if ((ImageQueryCMLRTO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLRTO.Visible = true;
                RAISECMLRTO.ShowPopupWindow();
                QueryRaiseCMLRTO.Visible = true;
                TextBoxRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO2.Visible = false;
                PanelRaiseCMLRTO3.Visible = false;
                LabelRespondCMLRTO.Visible = true;
            }

            else if ((ImageQueryCMLRTO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLRTO.Visible = true;
                RAISECMLRTO.ShowPopupWindow();
                QueryRaiseCMLRTO.Visible = false;
                TextBoxRaiseCMLRTO.Visible = false;
                PanelRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO2.Visible = true;
                PanelRaiseCMLRTO3.Visible = false;
                LabelRespondCMLRTO.Visible = false;
            }
            else if ((ImageQueryCMLRTO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLRTO.Visible = true;
                RAISECMLRTO.ShowPopupWindow();
                QueryRaiseCMLRTO.Visible = false;
                TextBoxRaiseCMLRTO.Visible = false;
                PanelRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO2.Visible = true;
                PanelRaiseCMLRTO3.Visible = true;
                LabelRespondCMLRTO.Visible = false;
            }
            else
            {
                RAISECMLRTO.Visible = true;
                RAISECMLRTO.ShowPopupWindow();
                QueryRaiseCMLRTO.Visible = false;
                TextBoxRaiseCMLRTO.Visible = false;
                PanelRaiseCMLRTO.Visible = true;
                PanelRaiseCMLRTO2.Visible = true;
                PanelRaiseCMLRTO3.Visible = true;
                LabelRespondCMLRTO.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLRTO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLRTO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLRTO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLRTO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLRTO = '" + TextBoxCMLRTO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLRTOMSG.ShowPopupWindow();
        RAISECMLRTO.Visible = false;


    }
    #endregion
    #region QueryCMLSD
    private void SetImageQueryCMLSD()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLSD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLSD.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLSD.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLSD.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLSD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLSD.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLSD()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLSD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD2.Visible = false;
                PanelRaiseCMLSD3.Visible = false;
                PanelHideCMLSD.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLSD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD2.Visible = true;
                PanelRaiseCMLSD3.Visible = true;
                PanelHideCMLSD.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD2.Visible = true;
                PanelRaiseCMLSD3.Visible = false;
                PanelHideCMLSD.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLSD_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLSD = '" + TextBoxCMLSD.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLSD.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLSD.Visible = true;
                RAISECMLSD.ShowPopupWindow();
                QueryRaiseCMLSD.Visible = false;
                TextBoxRaiseCMLSD.Visible = false;
                PanelRaiseCMLSD.Visible = false;
                PanelRaiseCMLSD2.Visible = false;
                PanelRaiseCMLSD3.Visible = false;

                LabelRespondCMLSD.Visible = false;
            }

            else if ((ImageQueryCMLSD.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLSD.Visible = true;
                RAISECMLSD.ShowPopupWindow();
                QueryRaiseCMLSD.Visible = true;
                TextBoxRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD2.Visible = false;
                PanelRaiseCMLSD3.Visible = false;
                LabelRespondCMLSD.Visible = true;
            }

            else if ((ImageQueryCMLSD.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLSD.Visible = true;
                RAISECMLSD.ShowPopupWindow();
                QueryRaiseCMLSD.Visible = false;
                TextBoxRaiseCMLSD.Visible = false;
                PanelRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD2.Visible = true;
                PanelRaiseCMLSD3.Visible = false;
                LabelRespondCMLSD.Visible = false;
            }
            else if ((ImageQueryCMLSD.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLSD.Visible = true;
                RAISECMLSD.ShowPopupWindow();
                QueryRaiseCMLSD.Visible = false;
                TextBoxRaiseCMLSD.Visible = false;
                PanelRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD2.Visible = true;
                PanelRaiseCMLSD3.Visible = true;
                LabelRespondCMLSD.Visible = false;
            }
            else
            {
                RAISECMLSD.Visible = true;
                RAISECMLSD.ShowPopupWindow();
                QueryRaiseCMLSD.Visible = false;
                TextBoxRaiseCMLSD.Visible = false;
                PanelRaiseCMLSD.Visible = true;
                PanelRaiseCMLSD2.Visible = true;
                PanelRaiseCMLSD3.Visible = true;
                LabelRespondCMLSD.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLSD_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLSD.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLSD.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLSD.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLSD = '" + TextBoxCMLSD.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLSDMSG.ShowPopupWindow();
        RAISECMLSD.Visible = false;


    }
    #endregion
    #region QueryCMLED
    private void SetImageQueryCMLED()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLED.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLED.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLED.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLED.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLED.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLED.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLED()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLED.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLED.Visible = true;
                PanelRaiseCMLED2.Visible = false;
                PanelRaiseCMLED3.Visible = false;
                PanelHideCMLED.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLED3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLED.Visible = true;
                PanelRaiseCMLED2.Visible = true;
                PanelRaiseCMLED3.Visible = true;
                PanelHideCMLED.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLED.Visible = true;
                PanelRaiseCMLED2.Visible = true;
                PanelRaiseCMLED3.Visible = false;
                PanelHideCMLED.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLED_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLED = '" + TextBoxCMLED.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLED.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLED.Visible = true;
                RAISECMLED.ShowPopupWindow();
                QueryRaiseCMLED.Visible = false;
                TextBoxRaiseCMLED.Visible = false;
                PanelRaiseCMLED.Visible = false;
                PanelRaiseCMLED2.Visible = false;
                PanelRaiseCMLED3.Visible = false;

                LabelRespondCMLED.Visible = false;
            }

            else if ((ImageQueryCMLED.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLED.Visible = true;
                RAISECMLED.ShowPopupWindow();
                QueryRaiseCMLED.Visible = true;
                TextBoxRaiseCMLED.Visible = true;
                PanelRaiseCMLED.Visible = true;
                PanelRaiseCMLED2.Visible = false;
                PanelRaiseCMLED3.Visible = false;
                LabelRespondCMLED.Visible = true;
            }

            else if ((ImageQueryCMLED.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLED.Visible = true;
                RAISECMLED.ShowPopupWindow();
                QueryRaiseCMLED.Visible = false;
                TextBoxRaiseCMLED.Visible = false;
                PanelRaiseCMLED.Visible = true;
                PanelRaiseCMLED2.Visible = true;
                PanelRaiseCMLED3.Visible = false;
                LabelRespondCMLED.Visible = false;
            }
            else if ((ImageQueryCMLED.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLED.Visible = true;
                RAISECMLED.ShowPopupWindow();
                QueryRaiseCMLED.Visible = false;
                TextBoxRaiseCMLED.Visible = false;
                PanelRaiseCMLED.Visible = true;
                PanelRaiseCMLED2.Visible = true;
                PanelRaiseCMLED3.Visible = true;
                LabelRespondCMLED.Visible = false;
            }
            else
            {
                RAISECMLED.Visible = true;
                RAISECMLED.ShowPopupWindow();
                QueryRaiseCMLED.Visible = false;
                TextBoxRaiseCMLED.Visible = false;
                PanelRaiseCMLED.Visible = true;
                PanelRaiseCMLED2.Visible = true;
                PanelRaiseCMLED3.Visible = true;
                LabelRespondCMLED.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLED_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLED.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLED.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLED.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLED = '" + TextBoxCMLED.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLEDMSG.ShowPopupWindow();
        RAISECMLED.Visible = false;


    }
    #endregion
    #region QueryCMLMT
    private void SetImageQueryCMLMT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLMT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLMT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLMT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLMT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLMT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLMT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLMT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT2.Visible = false;
                PanelRaiseCMLMT3.Visible = false;
                PanelHideCMLMT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLMT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLMT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLMT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT2.Visible = true;
                PanelRaiseCMLMT3.Visible = true;
                PanelHideCMLMT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLMT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLMT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT2.Visible = true;
                PanelRaiseCMLMT3.Visible = false;
                PanelHideCMLMT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLMT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLMT = '" + RadioButtonListCMLMT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLMT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLMT.Visible = true;
                RAISECMLMT.ShowPopupWindow();
                QueryRaiseCMLMT.Visible = false;
                TextBoxRaiseCMLMT.Visible = false;
                PanelRaiseCMLMT.Visible = false;
                PanelRaiseCMLMT2.Visible = false;
                PanelRaiseCMLMT3.Visible = false;

                LabelRespondCMLMT.Visible = false;
            }

            else if ((ImageQueryCMLMT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMT.Visible = true;
                RAISECMLMT.ShowPopupWindow();
                QueryRaiseCMLMT.Visible = true;
                TextBoxRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT2.Visible = false;
                PanelRaiseCMLMT3.Visible = false;
                LabelRespondCMLMT.Visible = true;
            }

            else if ((ImageQueryCMLMT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMT.Visible = true;
                RAISECMLMT.ShowPopupWindow();
                QueryRaiseCMLMT.Visible = false;
                TextBoxRaiseCMLMT.Visible = false;
                PanelRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT2.Visible = true;
                PanelRaiseCMLMT3.Visible = false;
                LabelRespondCMLMT.Visible = false;
            }
            else if ((ImageQueryCMLMT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLMT.Visible = true;
                RAISECMLMT.ShowPopupWindow();
                QueryRaiseCMLMT.Visible = false;
                TextBoxRaiseCMLMT.Visible = false;
                PanelRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT2.Visible = true;
                PanelRaiseCMLMT3.Visible = true;
                LabelRespondCMLMT.Visible = false;
            }
            else
            {
                RAISECMLMT.Visible = true;
                RAISECMLMT.ShowPopupWindow();
                QueryRaiseCMLMT.Visible = false;
                TextBoxRaiseCMLMT.Visible = false;
                PanelRaiseCMLMT.Visible = true;
                PanelRaiseCMLMT2.Visible = true;
                PanelRaiseCMLMT3.Visible = true;
                LabelRespondCMLMT.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLMT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLMT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLMT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLMT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLMT = '" + RadioButtonListCMLMT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLMTMSG.ShowPopupWindow();
        RAISECMLMT.Visible = false;


    }
    #endregion
    #region QueryCMLUT
    private void SetImageQueryCMLUT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLUT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLUT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLUT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLUT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLUT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLUT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLUT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLUT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLUT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT2.Visible = false;
                PanelRaiseCMLUT3.Visible = false;
                PanelHideCMLUT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLUT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLUT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLUT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT2.Visible = true;
                PanelRaiseCMLUT3.Visible = true;
                PanelHideCMLUT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLUT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLUT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT2.Visible = true;
                PanelRaiseCMLUT3.Visible = false;
                PanelHideCMLUT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLUT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLUT = '" + RadioButtonListCMLUT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLUT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLUT.Visible = true;
                RAISECMLUT.ShowPopupWindow();
                QueryRaiseCMLUT.Visible = false;
                TextBoxRaiseCMLUT.Visible = false;
                PanelRaiseCMLUT.Visible = false;
                PanelRaiseCMLUT2.Visible = false;
                PanelRaiseCMLUT3.Visible = false;

                LabelRespondCMLUT.Visible = false;
            }

            else if ((ImageQueryCMLUT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLUT.Visible = true;
                RAISECMLUT.ShowPopupWindow();
                QueryRaiseCMLUT.Visible = true;
                TextBoxRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT2.Visible = false;
                PanelRaiseCMLUT3.Visible = false;
                LabelRespondCMLUT.Visible = true;
            }

            else if ((ImageQueryCMLUT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLUT.Visible = true;
                RAISECMLUT.ShowPopupWindow();
                QueryRaiseCMLUT.Visible = false;
                TextBoxRaiseCMLUT.Visible = false;
                PanelRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT2.Visible = true;
                PanelRaiseCMLUT3.Visible = false;
                LabelRespondCMLUT.Visible = false;
            }
            else if ((ImageQueryCMLUT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLUT.Visible = true;
                RAISECMLUT.ShowPopupWindow();
                QueryRaiseCMLUT.Visible = false;
                TextBoxRaiseCMLUT.Visible = false;
                PanelRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT2.Visible = true;
                PanelRaiseCMLUT3.Visible = true;
                LabelRespondCMLUT.Visible = false;
            }
            else
            {
                RAISECMLUT.Visible = true;
                RAISECMLUT.ShowPopupWindow();
                QueryRaiseCMLUT.Visible = false;
                TextBoxRaiseCMLUT.Visible = false;
                PanelRaiseCMLUT.Visible = true;
                PanelRaiseCMLUT2.Visible = true;
                PanelRaiseCMLUT3.Visible = true;
                LabelRespondCMLUT.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLUT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLUT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLUT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLUT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLUT = '" + RadioButtonListCMLUT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLUTMSG.ShowPopupWindow();
        RAISECMLUT.Visible = false;


    }
    #endregion
    #region QueryCMLFRQ
    private void SetImageQueryCMLFRQ()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLFRQ.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLFRQ.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLFRQ.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLFRQ.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLFRQ.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLFRQ.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLFRQ()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLFRQ.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLFRQ.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ2.Visible = false;
                PanelRaiseCMLFRQ3.Visible = false;
                PanelHideCMLFRQ.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLFRQ.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLFRQ2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLFRQ3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ2.Visible = true;
                PanelRaiseCMLFRQ3.Visible = true;
                PanelHideCMLFRQ.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLFRQ.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLFRQ2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ2.Visible = true;
                PanelRaiseCMLFRQ3.Visible = false;
                PanelHideCMLFRQ.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLFRQ_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLFRQ = '" + RadioButtonListCMLFRQ.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLFRQ.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLFRQ.Visible = true;
                RAISECMLFRQ.ShowPopupWindow();
                QueryRaiseCMLFRQ.Visible = false;
                TextBoxRaiseCMLFRQ.Visible = false;
                PanelRaiseCMLFRQ.Visible = false;
                PanelRaiseCMLFRQ2.Visible = false;
                PanelRaiseCMLFRQ3.Visible = false;

                LabelRespondCMLFRQ.Visible = false;
            }

            else if ((ImageQueryCMLFRQ.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLFRQ.Visible = true;
                RAISECMLFRQ.ShowPopupWindow();
                QueryRaiseCMLFRQ.Visible = true;
                TextBoxRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ2.Visible = false;
                PanelRaiseCMLFRQ3.Visible = false;
                LabelRespondCMLFRQ.Visible = true;
            }

            else if ((ImageQueryCMLFRQ.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLFRQ.Visible = true;
                RAISECMLFRQ.ShowPopupWindow();
                QueryRaiseCMLFRQ.Visible = false;
                TextBoxRaiseCMLFRQ.Visible = false;
                PanelRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ2.Visible = true;
                PanelRaiseCMLFRQ3.Visible = false;
                LabelRespondCMLFRQ.Visible = false;
            }
            else if ((ImageQueryCMLFRQ.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLFRQ.Visible = true;
                RAISECMLFRQ.ShowPopupWindow();
                QueryRaiseCMLFRQ.Visible = false;
                TextBoxRaiseCMLFRQ.Visible = false;
                PanelRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ2.Visible = true;
                PanelRaiseCMLFRQ3.Visible = true;
                LabelRespondCMLFRQ.Visible = false;
            }
            else
            {
                RAISECMLFRQ.Visible = true;
                RAISECMLFRQ.ShowPopupWindow();
                QueryRaiseCMLFRQ.Visible = false;
                TextBoxRaiseCMLFRQ.Visible = false;
                PanelRaiseCMLFRQ.Visible = true;
                PanelRaiseCMLFRQ2.Visible = true;
                PanelRaiseCMLFRQ3.Visible = true;
                LabelRespondCMLFRQ.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLFRQ_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLFRQ.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLFRQ.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLFRQ.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLFRQ = '" + RadioButtonListCMLFRQ.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLFRQMSG.ShowPopupWindow();
        RAISECMLFRQ.Visible = false;


    }
    #endregion
    #region QueryCMLRT
    private void SetImageQueryCMLRT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLRT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLRT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLRT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLRT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLRT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLRT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLRT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLRT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLRT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT2.Visible = false;
                PanelRaiseCMLRT3.Visible = false;
                PanelHideCMLRT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLRT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLRT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLRT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT2.Visible = true;
                PanelRaiseCMLRT3.Visible = true;
                PanelHideCMLRT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLRT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLRT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT2.Visible = true;
                PanelRaiseCMLRT3.Visible = false;
                PanelHideCMLRT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLRT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLRT = '" + RadioButtonListCMLRT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLRT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLRT.Visible = true;
                RAISECMLRT.ShowPopupWindow();
                QueryRaiseCMLRT.Visible = false;
                TextBoxRaiseCMLRT.Visible = false;
                PanelRaiseCMLRT.Visible = false;
                PanelRaiseCMLRT2.Visible = false;
                PanelRaiseCMLRT3.Visible = false;

                LabelRespondCMLRT.Visible = false;
            }

            else if ((ImageQueryCMLRT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLRT.Visible = true;
                RAISECMLRT.ShowPopupWindow();
                QueryRaiseCMLRT.Visible = true;
                TextBoxRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT2.Visible = false;
                PanelRaiseCMLRT3.Visible = false;
                LabelRespondCMLRT.Visible = true;
            }

            else if ((ImageQueryCMLRT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLRT.Visible = true;
                RAISECMLRT.ShowPopupWindow();
                QueryRaiseCMLRT.Visible = false;
                TextBoxRaiseCMLRT.Visible = false;
                PanelRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT2.Visible = true;
                PanelRaiseCMLRT3.Visible = false;
                LabelRespondCMLRT.Visible = false;
            }
            else if ((ImageQueryCMLRT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLRT.Visible = true;
                RAISECMLRT.ShowPopupWindow();
                QueryRaiseCMLRT.Visible = false;
                TextBoxRaiseCMLRT.Visible = false;
                PanelRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT2.Visible = true;
                PanelRaiseCMLRT3.Visible = true;
                LabelRespondCMLRT.Visible = false;
            }
            else
            {
                RAISECMLRT.Visible = true;
                RAISECMLRT.ShowPopupWindow();
                QueryRaiseCMLRT.Visible = false;
                TextBoxRaiseCMLRT.Visible = false;
                PanelRaiseCMLRT.Visible = true;
                PanelRaiseCMLRT2.Visible = true;
                PanelRaiseCMLRT3.Visible = true;
                LabelRespondCMLRT.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLRT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLRT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLRT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLRT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLRT = '" + RadioButtonListCMLRT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLRTMSG.ShowPopupWindow();
        RAISECMLRT.Visible = false;


    }
    #endregion
    #region QueryCMLONGO
    private void SetImageQueryCMLONGO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLONGO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCMLONGO.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCMLONGO.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCMLONGO.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryCMLONGO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCMLONGO.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataCMLONGO()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLONGO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCMLONGO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO2.Visible = false;
                PanelRaiseCMLONGO3.Visible = false;
                PanelHideCMLONGO.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCMLONGO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLONGO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseCMLONGO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO2.Visible = true;
                PanelRaiseCMLONGO3.Visible = true;
                PanelHideCMLONGO.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCMLONGO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCMLONGO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO2.Visible = true;
                PanelRaiseCMLONGO3.Visible = false;
                PanelHideCMLONGO.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryCMLONGO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[ConcomitantMedicationLog]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLONGO = '" + RadioButtonListCMLONGO.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCMLONGO.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECMLONGO.Visible = true;
                RAISECMLONGO.ShowPopupWindow();
                QueryRaiseCMLONGO.Visible = false;
                TextBoxRaiseCMLONGO.Visible = false;
                PanelRaiseCMLONGO.Visible = false;
                PanelRaiseCMLONGO2.Visible = false;
                PanelRaiseCMLONGO3.Visible = false;

                LabelRespondCMLONGO.Visible = false;
            }

            else if ((ImageQueryCMLONGO.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLONGO.Visible = true;
                RAISECMLONGO.ShowPopupWindow();
                QueryRaiseCMLONGO.Visible = true;
                TextBoxRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO2.Visible = false;
                PanelRaiseCMLONGO3.Visible = false;
                LabelRespondCMLONGO.Visible = true;
            }

            else if ((ImageQueryCMLONGO.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLONGO.Visible = true;
                RAISECMLONGO.ShowPopupWindow();
                QueryRaiseCMLONGO.Visible = false;
                TextBoxRaiseCMLONGO.Visible = false;
                PanelRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO2.Visible = true;
                PanelRaiseCMLONGO3.Visible = false;
                LabelRespondCMLONGO.Visible = false;
            }
            else if ((ImageQueryCMLONGO.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECMLONGO.Visible = true;
                RAISECMLONGO.ShowPopupWindow();
                QueryRaiseCMLONGO.Visible = false;
                TextBoxRaiseCMLONGO.Visible = false;
                PanelRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO2.Visible = true;
                PanelRaiseCMLONGO3.Visible = true;
                LabelRespondCMLONGO.Visible = false;
            }
            else
            {
                RAISECMLONGO.Visible = true;
                RAISECMLONGO.ShowPopupWindow();
                QueryRaiseCMLONGO.Visible = false;
                TextBoxRaiseCMLONGO.Visible = false;
                PanelRaiseCMLONGO.Visible = true;
                PanelRaiseCMLONGO2.Visible = true;
                PanelRaiseCMLONGO3.Visible = true;
                LabelRespondCMLONGO.Visible = false;

            }
        }

    }
    protected void QueryRaiseCMLONGO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseCMLONGO.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and  SNO = '" + TextBoxCNSNO.Text + "' and Field = '" + lblCMLONGO.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "'and  SNO = '" + TextBoxCNSNO.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCMLONGO.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Add].[ConcomitantMedicationLog] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and CNSNO = '" + TextBoxCNSNO.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CMLONGO = '" + RadioButtonListCMLONGO.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECMLONGOMSG.ShowPopupWindow();
        RAISECMLONGO.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListCMLMT.SelectedValue == "Other")
        {
            hideCMLMTO.Visible = true;
        }
        else
        {
            hideCMLMTO.Visible = false;
        }

        if (RadioButtonListCMLUT.SelectedValue == "Other")
        {
            hideCMLUTO.Visible = true;
        }
        else
        {
            hideCMLUTO.Visible = false;
        }

        if (RadioButtonListCMLFRQ.SelectedValue == "Other")
        {
            hideCMLFRQO.Visible = true;
        }
        else
        {
            hideCMLFRQO.Visible = false;
        }

        if (RadioButtonListCMLRT.SelectedValue == "Other (specify)")
        {
            hideCMLRTO.Visible = true;
        }
        else
        {
            hideCMLRTO.Visible = false;
        }

        if (RadioButtonListCMLONGO.SelectedValue == "No")
        {
            hideCMLED.Visible = true;
        }
        else
        {
            hideCMLED.Visible = false;
        }
    }

    protected void RadioButtonListCMLMT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListCMLMT.SelectedValue == "Other")
        {
            hideCMLMTO.Visible = true;
        }
        else
        {
            hideCMLMTO.Visible = false;
            TextBoxCMLMTO.Text = string.Empty;
        }
    }

    protected void RadioButtonListCMLUT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListCMLUT.SelectedValue == "Other")
        {
            hideCMLUTO.Visible = true;
        }
        else
        {
            hideCMLUTO.Visible = false;
            TextBoxCMLUTO.Text = string.Empty;
        }
    }

    protected void RadioButtonListCMLFRQ_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListCMLFRQ.SelectedValue == "Other")
        {
            hideCMLFRQO.Visible = true;
        }
        else
        {
            hideCMLFRQO.Visible = false;
            TextBoxCMLFRQO.Text = string.Empty;
        }
    }

    protected void RadioButtonListCMLRT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListCMLRT.SelectedValue == "Other (specify)")
        {
            hideCMLRTO.Visible = true;
        }
        else
        {
            hideCMLRTO.Visible = false;
            TextBoxCMLRTO.Text = string.Empty;
        }
    }

    protected void RadioButtonListCMLONGO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListCMLONGO.SelectedValue == "No")
        {
            hideCMLED.Visible = true;
        }
        else
        {
            hideCMLED.Visible = false;
            TextBoxCMLED.Text = string.Empty;
        }
    }
}