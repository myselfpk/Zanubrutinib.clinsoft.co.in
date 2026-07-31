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

public partial class Data_Entry_Visit8_HRQoL_Questionnaire : System.Web.UI.Page
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

        SetImageQueryHRPER();
        SetImageQueryHR1OPT();
        SetImageQueryHR2OPT();
        SetImageQueryHR3OPT();
        SetImageQueryHR4OPT();
        SetImageQueryHR5OPT();
        SetImageQueryHR6OPT();
        SetImageQueryHR7OPT();
        SetImageQueryHR8OPT();
        SetImageQueryHR9OPT();
        SetImageQueryHR10OPT();
        SetImageQueryHR11OPT();
        SetImageQueryHR12OPT();
        SetImageQueryHR13OPT();
        SetImageQueryHR14OPT();
        SetImageQueryHR15OPT();
        SetImageQueryHR16OPT();
        SetImageQueryHR17OPT();
        SetImageQueryHR18OPT();
        SetImageQueryHR19OPT();
        SetImageQueryHR20OPT();
        SetImageQueryHR21OPT();
        SetImageQueryHR22OPT();
        SetImageQueryHR23OPT();
        SetImageQueryHR24OPT();
        SetImageQueryHR25OPT();
        SetImageQueryHR26OPT();
        SetImageQueryHR27OPT();
        SetImageQueryHR28OPT();
        SetImageQueryHR29OPT();
        SetImageQueryHR30OPT();

        BindQueryDataHRPER();
        BindQueryDataHR1OPT();
        BindQueryDataHR2OPT();
        BindQueryDataHR3OPT();
        BindQueryDataHR4OPT();
        BindQueryDataHR5OPT();
        BindQueryDataHR6OPT();
        BindQueryDataHR7OPT();
        BindQueryDataHR8OPT();
        BindQueryDataHR9OPT();
        BindQueryDataHR10OPT();
        BindQueryDataHR11OPT();
        BindQueryDataHR12OPT();
        BindQueryDataHR13OPT();
        BindQueryDataHR14OPT();
        BindQueryDataHR15OPT();
        BindQueryDataHR16OPT();
        BindQueryDataHR17OPT();
        BindQueryDataHR18OPT();
        BindQueryDataHR19OPT();
        BindQueryDataHR20OPT();
        BindQueryDataHR21OPT();
        BindQueryDataHR22OPT();
        BindQueryDataHR23OPT();
        BindQueryDataHR24OPT();
        BindQueryDataHR25OPT();
        BindQueryDataHR26OPT();
        BindQueryDataHR27OPT();
        BindQueryDataHR28OPT();
        BindQueryDataHR29OPT();
        BindQueryDataHR30OPT();

        ShowHide();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select HRPER , HR1OPT , HR2OPT , HR3OPT , HR4OPT , HR5OPT , HR6OPT , HR7OPT , HR8OPT , HR9OPT , HR10OPT , HR11OPT , HR12OPT , HR13OPT , HR14OPT , HR15OPT , HR16OPT , HR17OPT , HR18OPT , HR19OPT , HR20OPT , HR21OPT , HR22OPT , HR23OPT , HR24OPT , HR25OPT , HR26OPT , HR27OPT , HR28OPT , HR29OPT , HR30OPT from [Visit8].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListHRPER.SelectedValue = dt.Rows[0]["HRPER"].ToString().Trim();
            RadioButtonListHR1OPT.SelectedValue = dt.Rows[0]["HR1OPT"].ToString().Trim();
            RadioButtonListHR2OPT.SelectedValue = dt.Rows[0]["HR2OPT"].ToString().Trim();
            RadioButtonListHR3OPT.SelectedValue = dt.Rows[0]["HR3OPT"].ToString().Trim();
            RadioButtonListHR4OPT.SelectedValue = dt.Rows[0]["HR4OPT"].ToString().Trim();
            RadioButtonListHR5OPT.SelectedValue = dt.Rows[0]["HR5OPT"].ToString().Trim();
            RadioButtonListHR6OPT.SelectedValue = dt.Rows[0]["HR6OPT"].ToString().Trim();
            RadioButtonListHR7OPT.SelectedValue = dt.Rows[0]["HR7OPT"].ToString().Trim();
            RadioButtonListHR8OPT.SelectedValue = dt.Rows[0]["HR8OPT"].ToString().Trim();
            RadioButtonListHR9OPT.SelectedValue = dt.Rows[0]["HR9OPT"].ToString().Trim();
            RadioButtonListHR10OPT.SelectedValue = dt.Rows[0]["HR10OPT"].ToString().Trim();
            RadioButtonListHR11OPT.SelectedValue = dt.Rows[0]["HR11OPT"].ToString().Trim();
            RadioButtonListHR12OPT.SelectedValue = dt.Rows[0]["HR12OPT"].ToString().Trim();
            RadioButtonListHR13OPT.SelectedValue = dt.Rows[0]["HR13OPT"].ToString().Trim();
            RadioButtonListHR14OPT.SelectedValue = dt.Rows[0]["HR14OPT"].ToString().Trim();
            RadioButtonListHR15OPT.SelectedValue = dt.Rows[0]["HR15OPT"].ToString().Trim();
            RadioButtonListHR16OPT.SelectedValue = dt.Rows[0]["HR16OPT"].ToString().Trim();
            RadioButtonListHR17OPT.SelectedValue = dt.Rows[0]["HR17OPT"].ToString().Trim();
            RadioButtonListHR18OPT.SelectedValue = dt.Rows[0]["HR18OPT"].ToString().Trim();
            RadioButtonListHR19OPT.SelectedValue = dt.Rows[0]["HR19OPT"].ToString().Trim();
            RadioButtonListHR20OPT.SelectedValue = dt.Rows[0]["HR20OPT"].ToString().Trim();
            RadioButtonListHR21OPT.SelectedValue = dt.Rows[0]["HR21OPT"].ToString().Trim();
            RadioButtonListHR22OPT.SelectedValue = dt.Rows[0]["HR22OPT"].ToString().Trim();
            RadioButtonListHR23OPT.SelectedValue = dt.Rows[0]["HR23OPT"].ToString().Trim();
            RadioButtonListHR24OPT.SelectedValue = dt.Rows[0]["HR24OPT"].ToString().Trim();
            RadioButtonListHR25OPT.SelectedValue = dt.Rows[0]["HR25OPT"].ToString().Trim();
            RadioButtonListHR26OPT.SelectedValue = dt.Rows[0]["HR26OPT"].ToString().Trim();
            RadioButtonListHR27OPT.SelectedValue = dt.Rows[0]["HR27OPT"].ToString().Trim();
            RadioButtonListHR28OPT.SelectedValue = dt.Rows[0]["HR28OPT"].ToString().Trim();
            RadioButtonListHR29OPT.SelectedValue = dt.Rows[0]["HR29OPT"].ToString().Trim();
            RadioButtonListHR30OPT.SelectedValue = dt.Rows[0]["HR30OPT"].ToString().Trim();


            ViewState["txt1"] = RadioButtonListHRPER.SelectedValue;
            ViewState["txt2"] = RadioButtonListHR1OPT.SelectedValue;
            ViewState["txt3"] = RadioButtonListHR2OPT.SelectedValue;
            ViewState["txt4"] = RadioButtonListHR3OPT.SelectedValue;
            ViewState["txt5"] = RadioButtonListHR4OPT.SelectedValue;
            ViewState["txt6"] = RadioButtonListHR5OPT.SelectedValue;
            ViewState["txt7"] = RadioButtonListHR6OPT.SelectedValue;
            ViewState["txt8"] = RadioButtonListHR7OPT.SelectedValue;
            ViewState["txt9"] = RadioButtonListHR8OPT.SelectedValue;
            ViewState["txt10"] = RadioButtonListHR9OPT.SelectedValue;
            ViewState["txt11"] = RadioButtonListHR10OPT.SelectedValue;
            ViewState["txt12"] = RadioButtonListHR11OPT.SelectedValue;
            ViewState["txt13"] = RadioButtonListHR12OPT.SelectedValue;
            ViewState["txt14"] = RadioButtonListHR13OPT.SelectedValue;
            ViewState["txt15"] = RadioButtonListHR14OPT.SelectedValue;
            ViewState["txt16"] = RadioButtonListHR15OPT.SelectedValue;
            ViewState["txt17"] = RadioButtonListHR16OPT.SelectedValue;
            ViewState["txt18"] = RadioButtonListHR17OPT.SelectedValue;
            ViewState["txt19"] = RadioButtonListHR18OPT.SelectedValue;
            ViewState["txt20"] = RadioButtonListHR19OPT.SelectedValue;
            ViewState["txt21"] = RadioButtonListHR20OPT.SelectedValue;
            ViewState["txt22"] = RadioButtonListHR21OPT.SelectedValue;
            ViewState["txt23"] = RadioButtonListHR22OPT.SelectedValue;
            ViewState["txt24"] = RadioButtonListHR23OPT.SelectedValue;
            ViewState["txt25"] = RadioButtonListHR24OPT.SelectedValue;
            ViewState["txt26"] = RadioButtonListHR25OPT.SelectedValue;
            ViewState["txt27"] = RadioButtonListHR26OPT.SelectedValue;
            ViewState["txt28"] = RadioButtonListHR27OPT.SelectedValue;
            ViewState["txt29"] = RadioButtonListHR28OPT.SelectedValue;
            ViewState["txt30"] = RadioButtonListHR29OPT.SelectedValue;
            ViewState["txt31"] = RadioButtonListHR30OPT.SelectedValue;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit8].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit8].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit8].[sp_HRQoL_Questionnaire]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@HRPER", RadioButtonListHRPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR1OPT", RadioButtonListHR1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR2OPT", RadioButtonListHR2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR3OPT", RadioButtonListHR3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR4OPT", RadioButtonListHR4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR5OPT", RadioButtonListHR5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR6OPT", RadioButtonListHR6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR7OPT", RadioButtonListHR7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR8OPT", RadioButtonListHR8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR9OPT", RadioButtonListHR9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR10OPT", RadioButtonListHR10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR11OPT", RadioButtonListHR11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR12OPT", RadioButtonListHR12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR13OPT", RadioButtonListHR13OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR14OPT", RadioButtonListHR14OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR15OPT", RadioButtonListHR15OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR16OPT", RadioButtonListHR16OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR17OPT", RadioButtonListHR17OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR18OPT", RadioButtonListHR18OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR19OPT", RadioButtonListHR19OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR20OPT", RadioButtonListHR20OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR21OPT", RadioButtonListHR21OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR22OPT", RadioButtonListHR22OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR23OPT", RadioButtonListHR23OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR24OPT", RadioButtonListHR24OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR25OPT", RadioButtonListHR25OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR26OPT", RadioButtonListHR26OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR27OPT", RadioButtonListHR27OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR28OPT", RadioButtonListHR28OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR29OPT", RadioButtonListHR29OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR30OPT", RadioButtonListHR30OPT.SelectedValue);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit8].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListHRPER.SelectedValue || ViewState["txt2"].ToString() != RadioButtonListHR1OPT.SelectedValue || ViewState["txt3"].ToString() != RadioButtonListHR2OPT.SelectedValue || ViewState["txt4"].ToString() != RadioButtonListHR3OPT.SelectedValue || ViewState["txt5"].ToString() != RadioButtonListHR4OPT.SelectedValue || ViewState["txt6"].ToString() != RadioButtonListHR5OPT.SelectedValue || ViewState["txt7"].ToString() != RadioButtonListHR6OPT.SelectedValue || ViewState["txt8"].ToString() != RadioButtonListHR7OPT.SelectedValue || ViewState["txt9"].ToString() != RadioButtonListHR8OPT.SelectedValue || ViewState["txt10"].ToString() != RadioButtonListHR9OPT.SelectedValue || ViewState["txt11"].ToString() != RadioButtonListHR10OPT.SelectedValue || ViewState["txt12"].ToString() != RadioButtonListHR11OPT.SelectedValue || ViewState["txt13"].ToString() != RadioButtonListHR12OPT.SelectedValue || ViewState["txt14"].ToString() != RadioButtonListHR13OPT.SelectedValue || ViewState["txt15"].ToString() != RadioButtonListHR14OPT.SelectedValue || ViewState["txt16"].ToString() != RadioButtonListHR15OPT.SelectedValue || ViewState["txt17"].ToString() != RadioButtonListHR16OPT.SelectedValue || ViewState["txt18"].ToString() != RadioButtonListHR17OPT.SelectedValue || ViewState["txt19"].ToString() != RadioButtonListHR18OPT.SelectedValue || ViewState["txt20"].ToString() != RadioButtonListHR19OPT.SelectedValue || ViewState["txt21"].ToString() != RadioButtonListHR20OPT.SelectedValue || ViewState["txt22"].ToString() != RadioButtonListHR21OPT.SelectedValue || ViewState["txt23"].ToString() != RadioButtonListHR22OPT.SelectedValue || ViewState["txt24"].ToString() != RadioButtonListHR23OPT.SelectedValue || ViewState["txt25"].ToString() != RadioButtonListHR24OPT.SelectedValue || ViewState["txt26"].ToString() != RadioButtonListHR25OPT.SelectedValue || ViewState["txt27"].ToString() != RadioButtonListHR26OPT.SelectedValue || ViewState["txt28"].ToString() != RadioButtonListHR27OPT.SelectedValue || ViewState["txt29"].ToString() != RadioButtonListHR28OPT.SelectedValue || ViewState["txt30"].ToString() != RadioButtonListHR29OPT.SelectedValue || ViewState["txt31"].ToString() != RadioButtonListHR30OPT.SelectedValue)
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
                cmd = new SqlCommand("[Visit8].[sp_HRQoL_Questionnaire]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@HRPER", RadioButtonListHRPER.SelectedValue);
                cmd.Parameters.AddWithValue("@HR1OPT", RadioButtonListHR1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR2OPT", RadioButtonListHR2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR3OPT", RadioButtonListHR3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR4OPT", RadioButtonListHR4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR5OPT", RadioButtonListHR5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR6OPT", RadioButtonListHR6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR7OPT", RadioButtonListHR7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR8OPT", RadioButtonListHR8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR9OPT", RadioButtonListHR9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR10OPT", RadioButtonListHR10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR11OPT", RadioButtonListHR11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR12OPT", RadioButtonListHR12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR13OPT", RadioButtonListHR13OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR14OPT", RadioButtonListHR14OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR15OPT", RadioButtonListHR15OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR16OPT", RadioButtonListHR16OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR17OPT", RadioButtonListHR17OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR18OPT", RadioButtonListHR18OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR19OPT", RadioButtonListHR19OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR20OPT", RadioButtonListHR20OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR21OPT", RadioButtonListHR21OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR22OPT", RadioButtonListHR22OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR23OPT", RadioButtonListHR23OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR24OPT", RadioButtonListHR24OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR25OPT", RadioButtonListHR25OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR26OPT", RadioButtonListHR26OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR27OPT", RadioButtonListHR27OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR28OPT", RadioButtonListHR28OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR29OPT", RadioButtonListHR29OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR30OPT", RadioButtonListHR30OPT.SelectedValue);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit8].[HRQoL_Questionnaire] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit8].[sp_HRQoL_Questionnaire]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@HRPER", RadioButtonListHRPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR1OPT", RadioButtonListHR1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR2OPT", RadioButtonListHR2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR3OPT", RadioButtonListHR3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR4OPT", RadioButtonListHR4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR5OPT", RadioButtonListHR5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR6OPT", RadioButtonListHR6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR7OPT", RadioButtonListHR7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR8OPT", RadioButtonListHR8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR9OPT", RadioButtonListHR9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR10OPT", RadioButtonListHR10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR11OPT", RadioButtonListHR11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR12OPT", RadioButtonListHR12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR13OPT", RadioButtonListHR13OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR14OPT", RadioButtonListHR14OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR15OPT", RadioButtonListHR15OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR16OPT", RadioButtonListHR16OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR17OPT", RadioButtonListHR17OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR18OPT", RadioButtonListHR18OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR19OPT", RadioButtonListHR19OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR20OPT", RadioButtonListHR20OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR21OPT", RadioButtonListHR21OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR22OPT", RadioButtonListHR22OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR23OPT", RadioButtonListHR23OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR24OPT", RadioButtonListHR24OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR25OPT", RadioButtonListHR25OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR26OPT", RadioButtonListHR26OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR27OPT", RadioButtonListHR27OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR28OPT", RadioButtonListHR28OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR29OPT", RadioButtonListHR29OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@HR30OPT", RadioButtonListHR30OPT.SelectedValue);

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
                cmd = new SqlCommand("[Visit8].[sp_HRQoL_Questionnaire]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@HRPER", RadioButtonListHRPER.SelectedValue);
                cmd.Parameters.AddWithValue("@HR1OPT", RadioButtonListHR1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR2OPT", RadioButtonListHR2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR3OPT", RadioButtonListHR3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR4OPT", RadioButtonListHR4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR5OPT", RadioButtonListHR5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR6OPT", RadioButtonListHR6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR7OPT", RadioButtonListHR7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR8OPT", RadioButtonListHR8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR9OPT", RadioButtonListHR9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR10OPT", RadioButtonListHR10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR11OPT", RadioButtonListHR11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR12OPT", RadioButtonListHR12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR13OPT", RadioButtonListHR13OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR14OPT", RadioButtonListHR14OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR15OPT", RadioButtonListHR15OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR16OPT", RadioButtonListHR16OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR17OPT", RadioButtonListHR17OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR18OPT", RadioButtonListHR18OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR19OPT", RadioButtonListHR19OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR20OPT", RadioButtonListHR20OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR21OPT", RadioButtonListHR21OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR22OPT", RadioButtonListHR22OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR23OPT", RadioButtonListHR23OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR24OPT", RadioButtonListHR24OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR25OPT", RadioButtonListHR25OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR26OPT", RadioButtonListHR26OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR27OPT", RadioButtonListHR27OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR28OPT", RadioButtonListHR28OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR29OPT", RadioButtonListHR29OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@HR30OPT", RadioButtonListHR30OPT.SelectedValue);

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
        if (!string.IsNullOrEmpty(RadioButtonListHRPER.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR4OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR5OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR6OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR7OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR8OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR9OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR10OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR11OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR12OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR13OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR14OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR15OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR16OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR17OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR18OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR19OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR20OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR21OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR22OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR23OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR24OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR25OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR26OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR27OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR28OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR29OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListHR30OPT.SelectedValue))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListHRPER.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHRPER.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListHRPER.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() != RadioButtonListHR1OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = RadioButtonListHR1OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() != RadioButtonListHR2OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = RadioButtonListHR2OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() != RadioButtonListHR3OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListHR3OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() != RadioButtonListHR4OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListHR4OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() != RadioButtonListHR5OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = RadioButtonListHR5OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() != RadioButtonListHR6OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListHR6OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() != RadioButtonListHR7OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR7OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListHR7OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() != RadioButtonListHR8OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR8OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListHR8OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != RadioButtonListHR9OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR9OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = RadioButtonListHR9OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != RadioButtonListHR10OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR10OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = RadioButtonListHR10OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != RadioButtonListHR11OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR11OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = RadioButtonListHR11OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != RadioButtonListHR12OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR12OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = RadioButtonListHR12OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString() != RadioButtonListHR13OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR13OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = RadioButtonListHR13OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString() != RadioButtonListHR14OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR14OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = RadioButtonListHR14OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt16"].ToString() != RadioButtonListHR15OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR15OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][15];
                dtrow["NewValue"] = RadioButtonListHR15OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt17"].ToString() != RadioButtonListHR16OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR16OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][16];
                dtrow["NewValue"] = RadioButtonListHR16OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt18"].ToString() != RadioButtonListHR17OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR17OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][17];
                dtrow["NewValue"] = RadioButtonListHR17OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt19"].ToString() != RadioButtonListHR18OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR18OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][18];
                dtrow["NewValue"] = RadioButtonListHR18OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt20"].ToString() != RadioButtonListHR19OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR19OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][19];
                dtrow["NewValue"] = RadioButtonListHR19OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt21"].ToString() != RadioButtonListHR20OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR20OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][20];
                dtrow["NewValue"] = RadioButtonListHR20OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt22"].ToString() != RadioButtonListHR21OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR21OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][21];
                dtrow["NewValue"] = RadioButtonListHR21OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt23"].ToString() != RadioButtonListHR22OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR22OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][22];
                dtrow["NewValue"] = RadioButtonListHR22OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt24"].ToString() != RadioButtonListHR23OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR23OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][23];
                dtrow["NewValue"] = RadioButtonListHR23OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt25"].ToString() != RadioButtonListHR24OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR24OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][24];
                dtrow["NewValue"] = RadioButtonListHR24OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt26"].ToString() != RadioButtonListHR25OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR25OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][25];
                dtrow["NewValue"] = RadioButtonListHR25OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt27"].ToString() != RadioButtonListHR26OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR26OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][26];
                dtrow["NewValue"] = RadioButtonListHR26OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt28"].ToString() != RadioButtonListHR27OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR27OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][27];
                dtrow["NewValue"] = RadioButtonListHR27OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt29"].ToString() != RadioButtonListHR28OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR28OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][28];
                dtrow["NewValue"] = RadioButtonListHR28OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt30"].ToString() != RadioButtonListHR29OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR29OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][29];
                dtrow["NewValue"] = RadioButtonListHR29OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt31"].ToString() != RadioButtonListHR30OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblHR30OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][30];
                dtrow["NewValue"] = RadioButtonListHR30OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit8].[sp_HRQoL_Questionnaire]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@HRPER", RadioButtonListHRPER.SelectedValue);
            cmd.Parameters.AddWithValue("@HR1OPT", RadioButtonListHR1OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR2OPT", RadioButtonListHR2OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR3OPT", RadioButtonListHR3OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR4OPT", RadioButtonListHR4OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR5OPT", RadioButtonListHR5OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR6OPT", RadioButtonListHR6OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR7OPT", RadioButtonListHR7OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR8OPT", RadioButtonListHR8OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR9OPT", RadioButtonListHR9OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR10OPT", RadioButtonListHR10OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR11OPT", RadioButtonListHR11OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR12OPT", RadioButtonListHR12OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR13OPT", RadioButtonListHR13OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR14OPT", RadioButtonListHR14OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR15OPT", RadioButtonListHR15OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR16OPT", RadioButtonListHR16OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR17OPT", RadioButtonListHR17OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR18OPT", RadioButtonListHR18OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR19OPT", RadioButtonListHR19OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR20OPT", RadioButtonListHR20OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR21OPT", RadioButtonListHR21OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR22OPT", RadioButtonListHR22OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR23OPT", RadioButtonListHR23OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR24OPT", RadioButtonListHR24OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR25OPT", RadioButtonListHR25OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR26OPT", RadioButtonListHR26OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR27OPT", RadioButtonListHR27OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR28OPT", RadioButtonListHR28OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR29OPT", RadioButtonListHR29OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@HR30OPT", RadioButtonListHR30OPT.SelectedValue);

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
    #region QueryHRPER
    private void SetImageQueryHRPER()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHRPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHRPER.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHRPER.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHRPER.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHRPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHRPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHRPER()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHRPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHRPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHRPER.Visible = true;
                PanelRaiseHRPER2.Visible = false;
                PanelRaiseHRPER3.Visible = false;
                PanelHideHRPER.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHRPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHRPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHRPER3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHRPER.Visible = true;
                PanelRaiseHRPER2.Visible = true;
                PanelRaiseHRPER3.Visible = true;
                PanelHideHRPER.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHRPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHRPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHRPER.Visible = true;
                PanelRaiseHRPER2.Visible = true;
                PanelRaiseHRPER3.Visible = false;
                PanelHideHRPER.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHRPER_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HRPER = '" + RadioButtonListHRPER.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHRPER.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHRPER.Visible = true;
                RAISEHRPER.ShowPopupWindow();
                QueryRaiseHRPER.Visible = false;
                TextBoxRaiseHRPER.Visible = false;
                PanelRaiseHRPER.Visible = false;
                PanelRaiseHRPER2.Visible = false;
                PanelRaiseHRPER3.Visible = false;

                LabelRespondHRPER.Visible = false;
            }

            else if ((ImageQueryHRPER.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHRPER.Visible = true;
                RAISEHRPER.ShowPopupWindow();
                QueryRaiseHRPER.Visible = true;
                TextBoxRaiseHRPER.Visible = true;
                PanelRaiseHRPER.Visible = true;
                PanelRaiseHRPER2.Visible = false;
                PanelRaiseHRPER3.Visible = false;
                LabelRespondHRPER.Visible = true;
            }

            else if ((ImageQueryHRPER.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHRPER.Visible = true;
                RAISEHRPER.ShowPopupWindow();
                QueryRaiseHRPER.Visible = false;
                TextBoxRaiseHRPER.Visible = false;
                PanelRaiseHRPER.Visible = true;
                PanelRaiseHRPER2.Visible = true;
                PanelRaiseHRPER3.Visible = false;
                LabelRespondHRPER.Visible = false;
            }
            else if ((ImageQueryHRPER.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHRPER.Visible = true;
                RAISEHRPER.ShowPopupWindow();
                QueryRaiseHRPER.Visible = false;
                TextBoxRaiseHRPER.Visible = false;
                PanelRaiseHRPER.Visible = true;
                PanelRaiseHRPER2.Visible = true;
                PanelRaiseHRPER3.Visible = true;
                LabelRespondHRPER.Visible = false;
            }
            else
            {
                RAISEHRPER.Visible = true;
                RAISEHRPER.ShowPopupWindow();
                QueryRaiseHRPER.Visible = false;
                TextBoxRaiseHRPER.Visible = false;
                PanelRaiseHRPER.Visible = true;
                PanelRaiseHRPER2.Visible = true;
                PanelRaiseHRPER3.Visible = true;
                LabelRespondHRPER.Visible = false;

            }
        }

    }
    protected void QueryRaiseHRPER_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHRPER.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHRPER.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHRPER.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HRPER = '" + RadioButtonListHRPER.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHRPERMSG.ShowPopupWindow();
        RAISEHRPER.Visible = false;


    }
    #endregion
    #region QueryHR1OPT
    private void SetImageQueryHR1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR1OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR1OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR1OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT2.Visible = false;
                PanelRaiseHR1OPT3.Visible = false;
                PanelHideHR1OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT2.Visible = true;
                PanelRaiseHR1OPT3.Visible = true;
                PanelHideHR1OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT2.Visible = true;
                PanelRaiseHR1OPT3.Visible = false;
                PanelHideHR1OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR1OPT = '" + RadioButtonListHR1OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR1OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR1OPT.Visible = true;
                RAISEHR1OPT.ShowPopupWindow();
                QueryRaiseHR1OPT.Visible = false;
                TextBoxRaiseHR1OPT.Visible = false;
                PanelRaiseHR1OPT.Visible = false;
                PanelRaiseHR1OPT2.Visible = false;
                PanelRaiseHR1OPT3.Visible = false;

                LabelRespondHR1OPT.Visible = false;
            }

            else if ((ImageQueryHR1OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR1OPT.Visible = true;
                RAISEHR1OPT.ShowPopupWindow();
                QueryRaiseHR1OPT.Visible = true;
                TextBoxRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT2.Visible = false;
                PanelRaiseHR1OPT3.Visible = false;
                LabelRespondHR1OPT.Visible = true;
            }

            else if ((ImageQueryHR1OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR1OPT.Visible = true;
                RAISEHR1OPT.ShowPopupWindow();
                QueryRaiseHR1OPT.Visible = false;
                TextBoxRaiseHR1OPT.Visible = false;
                PanelRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT2.Visible = true;
                PanelRaiseHR1OPT3.Visible = false;
                LabelRespondHR1OPT.Visible = false;
            }
            else if ((ImageQueryHR1OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR1OPT.Visible = true;
                RAISEHR1OPT.ShowPopupWindow();
                QueryRaiseHR1OPT.Visible = false;
                TextBoxRaiseHR1OPT.Visible = false;
                PanelRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT2.Visible = true;
                PanelRaiseHR1OPT3.Visible = true;
                LabelRespondHR1OPT.Visible = false;
            }
            else
            {
                RAISEHR1OPT.Visible = true;
                RAISEHR1OPT.ShowPopupWindow();
                QueryRaiseHR1OPT.Visible = false;
                TextBoxRaiseHR1OPT.Visible = false;
                PanelRaiseHR1OPT.Visible = true;
                PanelRaiseHR1OPT2.Visible = true;
                PanelRaiseHR1OPT3.Visible = true;
                LabelRespondHR1OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR1OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR1OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR1OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR1OPT = '" + RadioButtonListHR1OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR1OPTMSG.ShowPopupWindow();
        RAISEHR1OPT.Visible = false;


    }
    #endregion
    #region QueryHR2OPT
    private void SetImageQueryHR2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR2OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR2OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR2OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT2.Visible = false;
                PanelRaiseHR2OPT3.Visible = false;
                PanelHideHR2OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT2.Visible = true;
                PanelRaiseHR2OPT3.Visible = true;
                PanelHideHR2OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT2.Visible = true;
                PanelRaiseHR2OPT3.Visible = false;
                PanelHideHR2OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR2OPT = '" + RadioButtonListHR2OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR2OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR2OPT.Visible = true;
                RAISEHR2OPT.ShowPopupWindow();
                QueryRaiseHR2OPT.Visible = false;
                TextBoxRaiseHR2OPT.Visible = false;
                PanelRaiseHR2OPT.Visible = false;
                PanelRaiseHR2OPT2.Visible = false;
                PanelRaiseHR2OPT3.Visible = false;

                LabelRespondHR2OPT.Visible = false;
            }

            else if ((ImageQueryHR2OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR2OPT.Visible = true;
                RAISEHR2OPT.ShowPopupWindow();
                QueryRaiseHR2OPT.Visible = true;
                TextBoxRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT2.Visible = false;
                PanelRaiseHR2OPT3.Visible = false;
                LabelRespondHR2OPT.Visible = true;
            }

            else if ((ImageQueryHR2OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR2OPT.Visible = true;
                RAISEHR2OPT.ShowPopupWindow();
                QueryRaiseHR2OPT.Visible = false;
                TextBoxRaiseHR2OPT.Visible = false;
                PanelRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT2.Visible = true;
                PanelRaiseHR2OPT3.Visible = false;
                LabelRespondHR2OPT.Visible = false;
            }
            else if ((ImageQueryHR2OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR2OPT.Visible = true;
                RAISEHR2OPT.ShowPopupWindow();
                QueryRaiseHR2OPT.Visible = false;
                TextBoxRaiseHR2OPT.Visible = false;
                PanelRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT2.Visible = true;
                PanelRaiseHR2OPT3.Visible = true;
                LabelRespondHR2OPT.Visible = false;
            }
            else
            {
                RAISEHR2OPT.Visible = true;
                RAISEHR2OPT.ShowPopupWindow();
                QueryRaiseHR2OPT.Visible = false;
                TextBoxRaiseHR2OPT.Visible = false;
                PanelRaiseHR2OPT.Visible = true;
                PanelRaiseHR2OPT2.Visible = true;
                PanelRaiseHR2OPT3.Visible = true;
                LabelRespondHR2OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR2OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR2OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR2OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR2OPT = '" + RadioButtonListHR2OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR2OPTMSG.ShowPopupWindow();
        RAISEHR2OPT.Visible = false;


    }
    #endregion
    #region QueryHR3OPT
    private void SetImageQueryHR3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR3OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR3OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR3OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT2.Visible = false;
                PanelRaiseHR3OPT3.Visible = false;
                PanelHideHR3OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT2.Visible = true;
                PanelRaiseHR3OPT3.Visible = true;
                PanelHideHR3OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT2.Visible = true;
                PanelRaiseHR3OPT3.Visible = false;
                PanelHideHR3OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR3OPT = '" + RadioButtonListHR3OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR3OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR3OPT.Visible = true;
                RAISEHR3OPT.ShowPopupWindow();
                QueryRaiseHR3OPT.Visible = false;
                TextBoxRaiseHR3OPT.Visible = false;
                PanelRaiseHR3OPT.Visible = false;
                PanelRaiseHR3OPT2.Visible = false;
                PanelRaiseHR3OPT3.Visible = false;

                LabelRespondHR3OPT.Visible = false;
            }

            else if ((ImageQueryHR3OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR3OPT.Visible = true;
                RAISEHR3OPT.ShowPopupWindow();
                QueryRaiseHR3OPT.Visible = true;
                TextBoxRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT2.Visible = false;
                PanelRaiseHR3OPT3.Visible = false;
                LabelRespondHR3OPT.Visible = true;
            }

            else if ((ImageQueryHR3OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR3OPT.Visible = true;
                RAISEHR3OPT.ShowPopupWindow();
                QueryRaiseHR3OPT.Visible = false;
                TextBoxRaiseHR3OPT.Visible = false;
                PanelRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT2.Visible = true;
                PanelRaiseHR3OPT3.Visible = false;
                LabelRespondHR3OPT.Visible = false;
            }
            else if ((ImageQueryHR3OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR3OPT.Visible = true;
                RAISEHR3OPT.ShowPopupWindow();
                QueryRaiseHR3OPT.Visible = false;
                TextBoxRaiseHR3OPT.Visible = false;
                PanelRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT2.Visible = true;
                PanelRaiseHR3OPT3.Visible = true;
                LabelRespondHR3OPT.Visible = false;
            }
            else
            {
                RAISEHR3OPT.Visible = true;
                RAISEHR3OPT.ShowPopupWindow();
                QueryRaiseHR3OPT.Visible = false;
                TextBoxRaiseHR3OPT.Visible = false;
                PanelRaiseHR3OPT.Visible = true;
                PanelRaiseHR3OPT2.Visible = true;
                PanelRaiseHR3OPT3.Visible = true;
                LabelRespondHR3OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR3OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR3OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR3OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR3OPT = '" + RadioButtonListHR3OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR3OPTMSG.ShowPopupWindow();
        RAISEHR3OPT.Visible = false;


    }
    #endregion
    #region QueryHR4OPT
    private void SetImageQueryHR4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR4OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR4OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR4OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT2.Visible = false;
                PanelRaiseHR4OPT3.Visible = false;
                PanelHideHR4OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT2.Visible = true;
                PanelRaiseHR4OPT3.Visible = true;
                PanelHideHR4OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT2.Visible = true;
                PanelRaiseHR4OPT3.Visible = false;
                PanelHideHR4OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR4OPT = '" + RadioButtonListHR4OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR4OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR4OPT.Visible = true;
                RAISEHR4OPT.ShowPopupWindow();
                QueryRaiseHR4OPT.Visible = false;
                TextBoxRaiseHR4OPT.Visible = false;
                PanelRaiseHR4OPT.Visible = false;
                PanelRaiseHR4OPT2.Visible = false;
                PanelRaiseHR4OPT3.Visible = false;

                LabelRespondHR4OPT.Visible = false;
            }

            else if ((ImageQueryHR4OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR4OPT.Visible = true;
                RAISEHR4OPT.ShowPopupWindow();
                QueryRaiseHR4OPT.Visible = true;
                TextBoxRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT2.Visible = false;
                PanelRaiseHR4OPT3.Visible = false;
                LabelRespondHR4OPT.Visible = true;
            }

            else if ((ImageQueryHR4OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR4OPT.Visible = true;
                RAISEHR4OPT.ShowPopupWindow();
                QueryRaiseHR4OPT.Visible = false;
                TextBoxRaiseHR4OPT.Visible = false;
                PanelRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT2.Visible = true;
                PanelRaiseHR4OPT3.Visible = false;
                LabelRespondHR4OPT.Visible = false;
            }
            else if ((ImageQueryHR4OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR4OPT.Visible = true;
                RAISEHR4OPT.ShowPopupWindow();
                QueryRaiseHR4OPT.Visible = false;
                TextBoxRaiseHR4OPT.Visible = false;
                PanelRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT2.Visible = true;
                PanelRaiseHR4OPT3.Visible = true;
                LabelRespondHR4OPT.Visible = false;
            }
            else
            {
                RAISEHR4OPT.Visible = true;
                RAISEHR4OPT.ShowPopupWindow();
                QueryRaiseHR4OPT.Visible = false;
                TextBoxRaiseHR4OPT.Visible = false;
                PanelRaiseHR4OPT.Visible = true;
                PanelRaiseHR4OPT2.Visible = true;
                PanelRaiseHR4OPT3.Visible = true;
                LabelRespondHR4OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR4OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR4OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR4OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR4OPT = '" + RadioButtonListHR4OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR4OPTMSG.ShowPopupWindow();
        RAISEHR4OPT.Visible = false;


    }
    #endregion
    #region QueryHR5OPT
    private void SetImageQueryHR5OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR5OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR5OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR5OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR5OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT2.Visible = false;
                PanelRaiseHR5OPT3.Visible = false;
                PanelHideHR5OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT2.Visible = true;
                PanelRaiseHR5OPT3.Visible = true;
                PanelHideHR5OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT2.Visible = true;
                PanelRaiseHR5OPT3.Visible = false;
                PanelHideHR5OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR5OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR5OPT = '" + RadioButtonListHR5OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR5OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR5OPT.Visible = true;
                RAISEHR5OPT.ShowPopupWindow();
                QueryRaiseHR5OPT.Visible = false;
                TextBoxRaiseHR5OPT.Visible = false;
                PanelRaiseHR5OPT.Visible = false;
                PanelRaiseHR5OPT2.Visible = false;
                PanelRaiseHR5OPT3.Visible = false;

                LabelRespondHR5OPT.Visible = false;
            }

            else if ((ImageQueryHR5OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR5OPT.Visible = true;
                RAISEHR5OPT.ShowPopupWindow();
                QueryRaiseHR5OPT.Visible = true;
                TextBoxRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT2.Visible = false;
                PanelRaiseHR5OPT3.Visible = false;
                LabelRespondHR5OPT.Visible = true;
            }

            else if ((ImageQueryHR5OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR5OPT.Visible = true;
                RAISEHR5OPT.ShowPopupWindow();
                QueryRaiseHR5OPT.Visible = false;
                TextBoxRaiseHR5OPT.Visible = false;
                PanelRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT2.Visible = true;
                PanelRaiseHR5OPT3.Visible = false;
                LabelRespondHR5OPT.Visible = false;
            }
            else if ((ImageQueryHR5OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR5OPT.Visible = true;
                RAISEHR5OPT.ShowPopupWindow();
                QueryRaiseHR5OPT.Visible = false;
                TextBoxRaiseHR5OPT.Visible = false;
                PanelRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT2.Visible = true;
                PanelRaiseHR5OPT3.Visible = true;
                LabelRespondHR5OPT.Visible = false;
            }
            else
            {
                RAISEHR5OPT.Visible = true;
                RAISEHR5OPT.ShowPopupWindow();
                QueryRaiseHR5OPT.Visible = false;
                TextBoxRaiseHR5OPT.Visible = false;
                PanelRaiseHR5OPT.Visible = true;
                PanelRaiseHR5OPT2.Visible = true;
                PanelRaiseHR5OPT3.Visible = true;
                LabelRespondHR5OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR5OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR5OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR5OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR5OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR5OPT = '" + RadioButtonListHR5OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR5OPTMSG.ShowPopupWindow();
        RAISEHR5OPT.Visible = false;


    }
    #endregion
    #region QueryHR6OPT
    private void SetImageQueryHR6OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR6OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR6OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR6OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR6OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT2.Visible = false;
                PanelRaiseHR6OPT3.Visible = false;
                PanelHideHR6OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT2.Visible = true;
                PanelRaiseHR6OPT3.Visible = true;
                PanelHideHR6OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT2.Visible = true;
                PanelRaiseHR6OPT3.Visible = false;
                PanelHideHR6OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR6OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR6OPT = '" + RadioButtonListHR6OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR6OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR6OPT.Visible = true;
                RAISEHR6OPT.ShowPopupWindow();
                QueryRaiseHR6OPT.Visible = false;
                TextBoxRaiseHR6OPT.Visible = false;
                PanelRaiseHR6OPT.Visible = false;
                PanelRaiseHR6OPT2.Visible = false;
                PanelRaiseHR6OPT3.Visible = false;

                LabelRespondHR6OPT.Visible = false;
            }

            else if ((ImageQueryHR6OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR6OPT.Visible = true;
                RAISEHR6OPT.ShowPopupWindow();
                QueryRaiseHR6OPT.Visible = true;
                TextBoxRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT2.Visible = false;
                PanelRaiseHR6OPT3.Visible = false;
                LabelRespondHR6OPT.Visible = true;
            }

            else if ((ImageQueryHR6OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR6OPT.Visible = true;
                RAISEHR6OPT.ShowPopupWindow();
                QueryRaiseHR6OPT.Visible = false;
                TextBoxRaiseHR6OPT.Visible = false;
                PanelRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT2.Visible = true;
                PanelRaiseHR6OPT3.Visible = false;
                LabelRespondHR6OPT.Visible = false;
            }
            else if ((ImageQueryHR6OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR6OPT.Visible = true;
                RAISEHR6OPT.ShowPopupWindow();
                QueryRaiseHR6OPT.Visible = false;
                TextBoxRaiseHR6OPT.Visible = false;
                PanelRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT2.Visible = true;
                PanelRaiseHR6OPT3.Visible = true;
                LabelRespondHR6OPT.Visible = false;
            }
            else
            {
                RAISEHR6OPT.Visible = true;
                RAISEHR6OPT.ShowPopupWindow();
                QueryRaiseHR6OPT.Visible = false;
                TextBoxRaiseHR6OPT.Visible = false;
                PanelRaiseHR6OPT.Visible = true;
                PanelRaiseHR6OPT2.Visible = true;
                PanelRaiseHR6OPT3.Visible = true;
                LabelRespondHR6OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR6OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR6OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR6OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR6OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR6OPT = '" + RadioButtonListHR6OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR6OPTMSG.ShowPopupWindow();
        RAISEHR6OPT.Visible = false;


    }
    #endregion
    #region QueryHR7OPT
    private void SetImageQueryHR7OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR7OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR7OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR7OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR7OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT2.Visible = false;
                PanelRaiseHR7OPT3.Visible = false;
                PanelHideHR7OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT2.Visible = true;
                PanelRaiseHR7OPT3.Visible = true;
                PanelHideHR7OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT2.Visible = true;
                PanelRaiseHR7OPT3.Visible = false;
                PanelHideHR7OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR7OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR7OPT = '" + RadioButtonListHR7OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR7OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR7OPT.Visible = true;
                RAISEHR7OPT.ShowPopupWindow();
                QueryRaiseHR7OPT.Visible = false;
                TextBoxRaiseHR7OPT.Visible = false;
                PanelRaiseHR7OPT.Visible = false;
                PanelRaiseHR7OPT2.Visible = false;
                PanelRaiseHR7OPT3.Visible = false;

                LabelRespondHR7OPT.Visible = false;
            }

            else if ((ImageQueryHR7OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR7OPT.Visible = true;
                RAISEHR7OPT.ShowPopupWindow();
                QueryRaiseHR7OPT.Visible = true;
                TextBoxRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT2.Visible = false;
                PanelRaiseHR7OPT3.Visible = false;
                LabelRespondHR7OPT.Visible = true;
            }

            else if ((ImageQueryHR7OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR7OPT.Visible = true;
                RAISEHR7OPT.ShowPopupWindow();
                QueryRaiseHR7OPT.Visible = false;
                TextBoxRaiseHR7OPT.Visible = false;
                PanelRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT2.Visible = true;
                PanelRaiseHR7OPT3.Visible = false;
                LabelRespondHR7OPT.Visible = false;
            }
            else if ((ImageQueryHR7OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR7OPT.Visible = true;
                RAISEHR7OPT.ShowPopupWindow();
                QueryRaiseHR7OPT.Visible = false;
                TextBoxRaiseHR7OPT.Visible = false;
                PanelRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT2.Visible = true;
                PanelRaiseHR7OPT3.Visible = true;
                LabelRespondHR7OPT.Visible = false;
            }
            else
            {
                RAISEHR7OPT.Visible = true;
                RAISEHR7OPT.ShowPopupWindow();
                QueryRaiseHR7OPT.Visible = false;
                TextBoxRaiseHR7OPT.Visible = false;
                PanelRaiseHR7OPT.Visible = true;
                PanelRaiseHR7OPT2.Visible = true;
                PanelRaiseHR7OPT3.Visible = true;
                LabelRespondHR7OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR7OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR7OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR7OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR7OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR7OPT = '" + RadioButtonListHR7OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR7OPTMSG.ShowPopupWindow();
        RAISEHR7OPT.Visible = false;


    }
    #endregion
    #region QueryHR8OPT
    private void SetImageQueryHR8OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR8OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR8OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR8OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR8OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT2.Visible = false;
                PanelRaiseHR8OPT3.Visible = false;
                PanelHideHR8OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT2.Visible = true;
                PanelRaiseHR8OPT3.Visible = true;
                PanelHideHR8OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT2.Visible = true;
                PanelRaiseHR8OPT3.Visible = false;
                PanelHideHR8OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR8OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR8OPT = '" + RadioButtonListHR8OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR8OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR8OPT.Visible = true;
                RAISEHR8OPT.ShowPopupWindow();
                QueryRaiseHR8OPT.Visible = false;
                TextBoxRaiseHR8OPT.Visible = false;
                PanelRaiseHR8OPT.Visible = false;
                PanelRaiseHR8OPT2.Visible = false;
                PanelRaiseHR8OPT3.Visible = false;

                LabelRespondHR8OPT.Visible = false;
            }

            else if ((ImageQueryHR8OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR8OPT.Visible = true;
                RAISEHR8OPT.ShowPopupWindow();
                QueryRaiseHR8OPT.Visible = true;
                TextBoxRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT2.Visible = false;
                PanelRaiseHR8OPT3.Visible = false;
                LabelRespondHR8OPT.Visible = true;
            }

            else if ((ImageQueryHR8OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR8OPT.Visible = true;
                RAISEHR8OPT.ShowPopupWindow();
                QueryRaiseHR8OPT.Visible = false;
                TextBoxRaiseHR8OPT.Visible = false;
                PanelRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT2.Visible = true;
                PanelRaiseHR8OPT3.Visible = false;
                LabelRespondHR8OPT.Visible = false;
            }
            else if ((ImageQueryHR8OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR8OPT.Visible = true;
                RAISEHR8OPT.ShowPopupWindow();
                QueryRaiseHR8OPT.Visible = false;
                TextBoxRaiseHR8OPT.Visible = false;
                PanelRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT2.Visible = true;
                PanelRaiseHR8OPT3.Visible = true;
                LabelRespondHR8OPT.Visible = false;
            }
            else
            {
                RAISEHR8OPT.Visible = true;
                RAISEHR8OPT.ShowPopupWindow();
                QueryRaiseHR8OPT.Visible = false;
                TextBoxRaiseHR8OPT.Visible = false;
                PanelRaiseHR8OPT.Visible = true;
                PanelRaiseHR8OPT2.Visible = true;
                PanelRaiseHR8OPT3.Visible = true;
                LabelRespondHR8OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR8OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR8OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR8OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR8OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR8OPT = '" + RadioButtonListHR8OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR8OPTMSG.ShowPopupWindow();
        RAISEHR8OPT.Visible = false;


    }
    #endregion
    #region QueryHR9OPT
    private void SetImageQueryHR9OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR9OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR9OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR9OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR9OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT2.Visible = false;
                PanelRaiseHR9OPT3.Visible = false;
                PanelHideHR9OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT2.Visible = true;
                PanelRaiseHR9OPT3.Visible = true;
                PanelHideHR9OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT2.Visible = true;
                PanelRaiseHR9OPT3.Visible = false;
                PanelHideHR9OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR9OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR9OPT = '" + RadioButtonListHR9OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR9OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR9OPT.Visible = true;
                RAISEHR9OPT.ShowPopupWindow();
                QueryRaiseHR9OPT.Visible = false;
                TextBoxRaiseHR9OPT.Visible = false;
                PanelRaiseHR9OPT.Visible = false;
                PanelRaiseHR9OPT2.Visible = false;
                PanelRaiseHR9OPT3.Visible = false;

                LabelRespondHR9OPT.Visible = false;
            }

            else if ((ImageQueryHR9OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR9OPT.Visible = true;
                RAISEHR9OPT.ShowPopupWindow();
                QueryRaiseHR9OPT.Visible = true;
                TextBoxRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT2.Visible = false;
                PanelRaiseHR9OPT3.Visible = false;
                LabelRespondHR9OPT.Visible = true;
            }

            else if ((ImageQueryHR9OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR9OPT.Visible = true;
                RAISEHR9OPT.ShowPopupWindow();
                QueryRaiseHR9OPT.Visible = false;
                TextBoxRaiseHR9OPT.Visible = false;
                PanelRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT2.Visible = true;
                PanelRaiseHR9OPT3.Visible = false;
                LabelRespondHR9OPT.Visible = false;
            }
            else if ((ImageQueryHR9OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR9OPT.Visible = true;
                RAISEHR9OPT.ShowPopupWindow();
                QueryRaiseHR9OPT.Visible = false;
                TextBoxRaiseHR9OPT.Visible = false;
                PanelRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT2.Visible = true;
                PanelRaiseHR9OPT3.Visible = true;
                LabelRespondHR9OPT.Visible = false;
            }
            else
            {
                RAISEHR9OPT.Visible = true;
                RAISEHR9OPT.ShowPopupWindow();
                QueryRaiseHR9OPT.Visible = false;
                TextBoxRaiseHR9OPT.Visible = false;
                PanelRaiseHR9OPT.Visible = true;
                PanelRaiseHR9OPT2.Visible = true;
                PanelRaiseHR9OPT3.Visible = true;
                LabelRespondHR9OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR9OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR9OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR9OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR9OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR9OPT = '" + RadioButtonListHR9OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR9OPTMSG.ShowPopupWindow();
        RAISEHR9OPT.Visible = false;


    }
    #endregion
    #region QueryHR10OPT
    private void SetImageQueryHR10OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR10OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR10OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR10OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR10OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT2.Visible = false;
                PanelRaiseHR10OPT3.Visible = false;
                PanelHideHR10OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT2.Visible = true;
                PanelRaiseHR10OPT3.Visible = true;
                PanelHideHR10OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT2.Visible = true;
                PanelRaiseHR10OPT3.Visible = false;
                PanelHideHR10OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR10OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR10OPT = '" + RadioButtonListHR10OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR10OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR10OPT.Visible = true;
                RAISEHR10OPT.ShowPopupWindow();
                QueryRaiseHR10OPT.Visible = false;
                TextBoxRaiseHR10OPT.Visible = false;
                PanelRaiseHR10OPT.Visible = false;
                PanelRaiseHR10OPT2.Visible = false;
                PanelRaiseHR10OPT3.Visible = false;

                LabelRespondHR10OPT.Visible = false;
            }

            else if ((ImageQueryHR10OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR10OPT.Visible = true;
                RAISEHR10OPT.ShowPopupWindow();
                QueryRaiseHR10OPT.Visible = true;
                TextBoxRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT2.Visible = false;
                PanelRaiseHR10OPT3.Visible = false;
                LabelRespondHR10OPT.Visible = true;
            }

            else if ((ImageQueryHR10OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR10OPT.Visible = true;
                RAISEHR10OPT.ShowPopupWindow();
                QueryRaiseHR10OPT.Visible = false;
                TextBoxRaiseHR10OPT.Visible = false;
                PanelRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT2.Visible = true;
                PanelRaiseHR10OPT3.Visible = false;
                LabelRespondHR10OPT.Visible = false;
            }
            else if ((ImageQueryHR10OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR10OPT.Visible = true;
                RAISEHR10OPT.ShowPopupWindow();
                QueryRaiseHR10OPT.Visible = false;
                TextBoxRaiseHR10OPT.Visible = false;
                PanelRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT2.Visible = true;
                PanelRaiseHR10OPT3.Visible = true;
                LabelRespondHR10OPT.Visible = false;
            }
            else
            {
                RAISEHR10OPT.Visible = true;
                RAISEHR10OPT.ShowPopupWindow();
                QueryRaiseHR10OPT.Visible = false;
                TextBoxRaiseHR10OPT.Visible = false;
                PanelRaiseHR10OPT.Visible = true;
                PanelRaiseHR10OPT2.Visible = true;
                PanelRaiseHR10OPT3.Visible = true;
                LabelRespondHR10OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR10OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR10OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR10OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR10OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR10OPT = '" + RadioButtonListHR10OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR10OPTMSG.ShowPopupWindow();
        RAISEHR10OPT.Visible = false;


    }
    #endregion
    #region QueryHR11OPT
    private void SetImageQueryHR11OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR11OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR11OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR11OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR11OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR11OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR11OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT2.Visible = false;
                PanelRaiseHR11OPT3.Visible = false;
                PanelHideHR11OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR11OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT2.Visible = true;
                PanelRaiseHR11OPT3.Visible = true;
                PanelHideHR11OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT2.Visible = true;
                PanelRaiseHR11OPT3.Visible = false;
                PanelHideHR11OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR11OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR11OPT = '" + RadioButtonListHR11OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR11OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR11OPT.Visible = true;
                RAISEHR11OPT.ShowPopupWindow();
                QueryRaiseHR11OPT.Visible = false;
                TextBoxRaiseHR11OPT.Visible = false;
                PanelRaiseHR11OPT.Visible = false;
                PanelRaiseHR11OPT2.Visible = false;
                PanelRaiseHR11OPT3.Visible = false;

                LabelRespondHR11OPT.Visible = false;
            }

            else if ((ImageQueryHR11OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR11OPT.Visible = true;
                RAISEHR11OPT.ShowPopupWindow();
                QueryRaiseHR11OPT.Visible = true;
                TextBoxRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT2.Visible = false;
                PanelRaiseHR11OPT3.Visible = false;
                LabelRespondHR11OPT.Visible = true;
            }

            else if ((ImageQueryHR11OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR11OPT.Visible = true;
                RAISEHR11OPT.ShowPopupWindow();
                QueryRaiseHR11OPT.Visible = false;
                TextBoxRaiseHR11OPT.Visible = false;
                PanelRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT2.Visible = true;
                PanelRaiseHR11OPT3.Visible = false;
                LabelRespondHR11OPT.Visible = false;
            }
            else if ((ImageQueryHR11OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR11OPT.Visible = true;
                RAISEHR11OPT.ShowPopupWindow();
                QueryRaiseHR11OPT.Visible = false;
                TextBoxRaiseHR11OPT.Visible = false;
                PanelRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT2.Visible = true;
                PanelRaiseHR11OPT3.Visible = true;
                LabelRespondHR11OPT.Visible = false;
            }
            else
            {
                RAISEHR11OPT.Visible = true;
                RAISEHR11OPT.ShowPopupWindow();
                QueryRaiseHR11OPT.Visible = false;
                TextBoxRaiseHR11OPT.Visible = false;
                PanelRaiseHR11OPT.Visible = true;
                PanelRaiseHR11OPT2.Visible = true;
                PanelRaiseHR11OPT3.Visible = true;
                LabelRespondHR11OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR11OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR11OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR11OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR11OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR11OPT = '" + RadioButtonListHR11OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR11OPTMSG.ShowPopupWindow();
        RAISEHR11OPT.Visible = false;


    }
    #endregion
    #region QueryHR12OPT
    private void SetImageQueryHR12OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR12OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR12OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR12OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR12OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR12OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR12OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT2.Visible = false;
                PanelRaiseHR12OPT3.Visible = false;
                PanelHideHR12OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR12OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT2.Visible = true;
                PanelRaiseHR12OPT3.Visible = true;
                PanelHideHR12OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT2.Visible = true;
                PanelRaiseHR12OPT3.Visible = false;
                PanelHideHR12OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR12OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR12OPT = '" + RadioButtonListHR12OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR12OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR12OPT.Visible = true;
                RAISEHR12OPT.ShowPopupWindow();
                QueryRaiseHR12OPT.Visible = false;
                TextBoxRaiseHR12OPT.Visible = false;
                PanelRaiseHR12OPT.Visible = false;
                PanelRaiseHR12OPT2.Visible = false;
                PanelRaiseHR12OPT3.Visible = false;

                LabelRespondHR12OPT.Visible = false;
            }

            else if ((ImageQueryHR12OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR12OPT.Visible = true;
                RAISEHR12OPT.ShowPopupWindow();
                QueryRaiseHR12OPT.Visible = true;
                TextBoxRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT2.Visible = false;
                PanelRaiseHR12OPT3.Visible = false;
                LabelRespondHR12OPT.Visible = true;
            }

            else if ((ImageQueryHR12OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR12OPT.Visible = true;
                RAISEHR12OPT.ShowPopupWindow();
                QueryRaiseHR12OPT.Visible = false;
                TextBoxRaiseHR12OPT.Visible = false;
                PanelRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT2.Visible = true;
                PanelRaiseHR12OPT3.Visible = false;
                LabelRespondHR12OPT.Visible = false;
            }
            else if ((ImageQueryHR12OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR12OPT.Visible = true;
                RAISEHR12OPT.ShowPopupWindow();
                QueryRaiseHR12OPT.Visible = false;
                TextBoxRaiseHR12OPT.Visible = false;
                PanelRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT2.Visible = true;
                PanelRaiseHR12OPT3.Visible = true;
                LabelRespondHR12OPT.Visible = false;
            }
            else
            {
                RAISEHR12OPT.Visible = true;
                RAISEHR12OPT.ShowPopupWindow();
                QueryRaiseHR12OPT.Visible = false;
                TextBoxRaiseHR12OPT.Visible = false;
                PanelRaiseHR12OPT.Visible = true;
                PanelRaiseHR12OPT2.Visible = true;
                PanelRaiseHR12OPT3.Visible = true;
                LabelRespondHR12OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR12OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR12OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR12OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR12OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR12OPT = '" + RadioButtonListHR12OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR12OPTMSG.ShowPopupWindow();
        RAISEHR12OPT.Visible = false;


    }
    #endregion
    #region QueryHR13OPT
    private void SetImageQueryHR13OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR13OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR13OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR13OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR13OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR13OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR13OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT2.Visible = false;
                PanelRaiseHR13OPT3.Visible = false;
                PanelHideHR13OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR13OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT2.Visible = true;
                PanelRaiseHR13OPT3.Visible = true;
                PanelHideHR13OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT2.Visible = true;
                PanelRaiseHR13OPT3.Visible = false;
                PanelHideHR13OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR13OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR13OPT = '" + RadioButtonListHR13OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR13OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR13OPT.Visible = true;
                RAISEHR13OPT.ShowPopupWindow();
                QueryRaiseHR13OPT.Visible = false;
                TextBoxRaiseHR13OPT.Visible = false;
                PanelRaiseHR13OPT.Visible = false;
                PanelRaiseHR13OPT2.Visible = false;
                PanelRaiseHR13OPT3.Visible = false;

                LabelRespondHR13OPT.Visible = false;
            }

            else if ((ImageQueryHR13OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR13OPT.Visible = true;
                RAISEHR13OPT.ShowPopupWindow();
                QueryRaiseHR13OPT.Visible = true;
                TextBoxRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT2.Visible = false;
                PanelRaiseHR13OPT3.Visible = false;
                LabelRespondHR13OPT.Visible = true;
            }

            else if ((ImageQueryHR13OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR13OPT.Visible = true;
                RAISEHR13OPT.ShowPopupWindow();
                QueryRaiseHR13OPT.Visible = false;
                TextBoxRaiseHR13OPT.Visible = false;
                PanelRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT2.Visible = true;
                PanelRaiseHR13OPT3.Visible = false;
                LabelRespondHR13OPT.Visible = false;
            }
            else if ((ImageQueryHR13OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR13OPT.Visible = true;
                RAISEHR13OPT.ShowPopupWindow();
                QueryRaiseHR13OPT.Visible = false;
                TextBoxRaiseHR13OPT.Visible = false;
                PanelRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT2.Visible = true;
                PanelRaiseHR13OPT3.Visible = true;
                LabelRespondHR13OPT.Visible = false;
            }
            else
            {
                RAISEHR13OPT.Visible = true;
                RAISEHR13OPT.ShowPopupWindow();
                QueryRaiseHR13OPT.Visible = false;
                TextBoxRaiseHR13OPT.Visible = false;
                PanelRaiseHR13OPT.Visible = true;
                PanelRaiseHR13OPT2.Visible = true;
                PanelRaiseHR13OPT3.Visible = true;
                LabelRespondHR13OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR13OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR13OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR13OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR13OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR13OPT = '" + RadioButtonListHR13OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR13OPTMSG.ShowPopupWindow();
        RAISEHR13OPT.Visible = false;


    }
    #endregion
    #region QueryHR14OPT
    private void SetImageQueryHR14OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR14OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR14OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR14OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR14OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR14OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR14OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR14OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR14OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT2.Visible = false;
                PanelRaiseHR14OPT3.Visible = false;
                PanelHideHR14OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR14OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT2.Visible = true;
                PanelRaiseHR14OPT3.Visible = true;
                PanelHideHR14OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT2.Visible = true;
                PanelRaiseHR14OPT3.Visible = false;
                PanelHideHR14OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR14OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR14OPT = '" + RadioButtonListHR14OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR14OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR14OPT.Visible = true;
                RAISEHR14OPT.ShowPopupWindow();
                QueryRaiseHR14OPT.Visible = false;
                TextBoxRaiseHR14OPT.Visible = false;
                PanelRaiseHR14OPT.Visible = false;
                PanelRaiseHR14OPT2.Visible = false;
                PanelRaiseHR14OPT3.Visible = false;

                LabelRespondHR14OPT.Visible = false;
            }

            else if ((ImageQueryHR14OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR14OPT.Visible = true;
                RAISEHR14OPT.ShowPopupWindow();
                QueryRaiseHR14OPT.Visible = true;
                TextBoxRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT2.Visible = false;
                PanelRaiseHR14OPT3.Visible = false;
                LabelRespondHR14OPT.Visible = true;
            }

            else if ((ImageQueryHR14OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR14OPT.Visible = true;
                RAISEHR14OPT.ShowPopupWindow();
                QueryRaiseHR14OPT.Visible = false;
                TextBoxRaiseHR14OPT.Visible = false;
                PanelRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT2.Visible = true;
                PanelRaiseHR14OPT3.Visible = false;
                LabelRespondHR14OPT.Visible = false;
            }
            else if ((ImageQueryHR14OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR14OPT.Visible = true;
                RAISEHR14OPT.ShowPopupWindow();
                QueryRaiseHR14OPT.Visible = false;
                TextBoxRaiseHR14OPT.Visible = false;
                PanelRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT2.Visible = true;
                PanelRaiseHR14OPT3.Visible = true;
                LabelRespondHR14OPT.Visible = false;
            }
            else
            {
                RAISEHR14OPT.Visible = true;
                RAISEHR14OPT.ShowPopupWindow();
                QueryRaiseHR14OPT.Visible = false;
                TextBoxRaiseHR14OPT.Visible = false;
                PanelRaiseHR14OPT.Visible = true;
                PanelRaiseHR14OPT2.Visible = true;
                PanelRaiseHR14OPT3.Visible = true;
                LabelRespondHR14OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR14OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR14OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR14OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR14OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR14OPT = '" + RadioButtonListHR14OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR14OPTMSG.ShowPopupWindow();
        RAISEHR14OPT.Visible = false;


    }
    #endregion
    #region QueryHR15OPT
    private void SetImageQueryHR15OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR15OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR15OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR15OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR15OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR15OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR15OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR15OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR15OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT2.Visible = false;
                PanelRaiseHR15OPT3.Visible = false;
                PanelHideHR15OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR15OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT2.Visible = true;
                PanelRaiseHR15OPT3.Visible = true;
                PanelHideHR15OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT2.Visible = true;
                PanelRaiseHR15OPT3.Visible = false;
                PanelHideHR15OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR15OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR15OPT = '" + RadioButtonListHR15OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR15OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR15OPT.Visible = true;
                RAISEHR15OPT.ShowPopupWindow();
                QueryRaiseHR15OPT.Visible = false;
                TextBoxRaiseHR15OPT.Visible = false;
                PanelRaiseHR15OPT.Visible = false;
                PanelRaiseHR15OPT2.Visible = false;
                PanelRaiseHR15OPT3.Visible = false;

                LabelRespondHR15OPT.Visible = false;
            }

            else if ((ImageQueryHR15OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR15OPT.Visible = true;
                RAISEHR15OPT.ShowPopupWindow();
                QueryRaiseHR15OPT.Visible = true;
                TextBoxRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT2.Visible = false;
                PanelRaiseHR15OPT3.Visible = false;
                LabelRespondHR15OPT.Visible = true;
            }

            else if ((ImageQueryHR15OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR15OPT.Visible = true;
                RAISEHR15OPT.ShowPopupWindow();
                QueryRaiseHR15OPT.Visible = false;
                TextBoxRaiseHR15OPT.Visible = false;
                PanelRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT2.Visible = true;
                PanelRaiseHR15OPT3.Visible = false;
                LabelRespondHR15OPT.Visible = false;
            }
            else if ((ImageQueryHR15OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR15OPT.Visible = true;
                RAISEHR15OPT.ShowPopupWindow();
                QueryRaiseHR15OPT.Visible = false;
                TextBoxRaiseHR15OPT.Visible = false;
                PanelRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT2.Visible = true;
                PanelRaiseHR15OPT3.Visible = true;
                LabelRespondHR15OPT.Visible = false;
            }
            else
            {
                RAISEHR15OPT.Visible = true;
                RAISEHR15OPT.ShowPopupWindow();
                QueryRaiseHR15OPT.Visible = false;
                TextBoxRaiseHR15OPT.Visible = false;
                PanelRaiseHR15OPT.Visible = true;
                PanelRaiseHR15OPT2.Visible = true;
                PanelRaiseHR15OPT3.Visible = true;
                LabelRespondHR15OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR15OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR15OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR15OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR15OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR15OPT = '" + RadioButtonListHR15OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR15OPTMSG.ShowPopupWindow();
        RAISEHR15OPT.Visible = false;


    }
    #endregion
    #region QueryHR16OPT
    private void SetImageQueryHR16OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR16OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR16OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR16OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR16OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR16OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR16OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR16OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR16OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT2.Visible = false;
                PanelRaiseHR16OPT3.Visible = false;
                PanelHideHR16OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR16OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT2.Visible = true;
                PanelRaiseHR16OPT3.Visible = true;
                PanelHideHR16OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT2.Visible = true;
                PanelRaiseHR16OPT3.Visible = false;
                PanelHideHR16OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR16OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR16OPT = '" + RadioButtonListHR16OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR16OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR16OPT.Visible = true;
                RAISEHR16OPT.ShowPopupWindow();
                QueryRaiseHR16OPT.Visible = false;
                TextBoxRaiseHR16OPT.Visible = false;
                PanelRaiseHR16OPT.Visible = false;
                PanelRaiseHR16OPT2.Visible = false;
                PanelRaiseHR16OPT3.Visible = false;

                LabelRespondHR16OPT.Visible = false;
            }

            else if ((ImageQueryHR16OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR16OPT.Visible = true;
                RAISEHR16OPT.ShowPopupWindow();
                QueryRaiseHR16OPT.Visible = true;
                TextBoxRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT2.Visible = false;
                PanelRaiseHR16OPT3.Visible = false;
                LabelRespondHR16OPT.Visible = true;
            }

            else if ((ImageQueryHR16OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR16OPT.Visible = true;
                RAISEHR16OPT.ShowPopupWindow();
                QueryRaiseHR16OPT.Visible = false;
                TextBoxRaiseHR16OPT.Visible = false;
                PanelRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT2.Visible = true;
                PanelRaiseHR16OPT3.Visible = false;
                LabelRespondHR16OPT.Visible = false;
            }
            else if ((ImageQueryHR16OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR16OPT.Visible = true;
                RAISEHR16OPT.ShowPopupWindow();
                QueryRaiseHR16OPT.Visible = false;
                TextBoxRaiseHR16OPT.Visible = false;
                PanelRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT2.Visible = true;
                PanelRaiseHR16OPT3.Visible = true;
                LabelRespondHR16OPT.Visible = false;
            }
            else
            {
                RAISEHR16OPT.Visible = true;
                RAISEHR16OPT.ShowPopupWindow();
                QueryRaiseHR16OPT.Visible = false;
                TextBoxRaiseHR16OPT.Visible = false;
                PanelRaiseHR16OPT.Visible = true;
                PanelRaiseHR16OPT2.Visible = true;
                PanelRaiseHR16OPT3.Visible = true;
                LabelRespondHR16OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR16OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR16OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR16OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR16OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR16OPT = '" + RadioButtonListHR16OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR16OPTMSG.ShowPopupWindow();
        RAISEHR16OPT.Visible = false;


    }
    #endregion
    #region QueryHR17OPT
    private void SetImageQueryHR17OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR17OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR17OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR17OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR17OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR17OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR17OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR17OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR17OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT2.Visible = false;
                PanelRaiseHR17OPT3.Visible = false;
                PanelHideHR17OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR17OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT2.Visible = true;
                PanelRaiseHR17OPT3.Visible = true;
                PanelHideHR17OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT2.Visible = true;
                PanelRaiseHR17OPT3.Visible = false;
                PanelHideHR17OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR17OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR17OPT = '" + RadioButtonListHR17OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR17OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR17OPT.Visible = true;
                RAISEHR17OPT.ShowPopupWindow();
                QueryRaiseHR17OPT.Visible = false;
                TextBoxRaiseHR17OPT.Visible = false;
                PanelRaiseHR17OPT.Visible = false;
                PanelRaiseHR17OPT2.Visible = false;
                PanelRaiseHR17OPT3.Visible = false;

                LabelRespondHR17OPT.Visible = false;
            }

            else if ((ImageQueryHR17OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR17OPT.Visible = true;
                RAISEHR17OPT.ShowPopupWindow();
                QueryRaiseHR17OPT.Visible = true;
                TextBoxRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT2.Visible = false;
                PanelRaiseHR17OPT3.Visible = false;
                LabelRespondHR17OPT.Visible = true;
            }

            else if ((ImageQueryHR17OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR17OPT.Visible = true;
                RAISEHR17OPT.ShowPopupWindow();
                QueryRaiseHR17OPT.Visible = false;
                TextBoxRaiseHR17OPT.Visible = false;
                PanelRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT2.Visible = true;
                PanelRaiseHR17OPT3.Visible = false;
                LabelRespondHR17OPT.Visible = false;
            }
            else if ((ImageQueryHR17OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR17OPT.Visible = true;
                RAISEHR17OPT.ShowPopupWindow();
                QueryRaiseHR17OPT.Visible = false;
                TextBoxRaiseHR17OPT.Visible = false;
                PanelRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT2.Visible = true;
                PanelRaiseHR17OPT3.Visible = true;
                LabelRespondHR17OPT.Visible = false;
            }
            else
            {
                RAISEHR17OPT.Visible = true;
                RAISEHR17OPT.ShowPopupWindow();
                QueryRaiseHR17OPT.Visible = false;
                TextBoxRaiseHR17OPT.Visible = false;
                PanelRaiseHR17OPT.Visible = true;
                PanelRaiseHR17OPT2.Visible = true;
                PanelRaiseHR17OPT3.Visible = true;
                LabelRespondHR17OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR17OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR17OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR17OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR17OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR17OPT = '" + RadioButtonListHR17OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR17OPTMSG.ShowPopupWindow();
        RAISEHR17OPT.Visible = false;


    }
    #endregion
    #region QueryHR18OPT
    private void SetImageQueryHR18OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR18OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR18OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR18OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR18OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR18OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR18OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR18OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR18OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT2.Visible = false;
                PanelRaiseHR18OPT3.Visible = false;
                PanelHideHR18OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR18OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT2.Visible = true;
                PanelRaiseHR18OPT3.Visible = true;
                PanelHideHR18OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT2.Visible = true;
                PanelRaiseHR18OPT3.Visible = false;
                PanelHideHR18OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR18OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR18OPT = '" + RadioButtonListHR18OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR18OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR18OPT.Visible = true;
                RAISEHR18OPT.ShowPopupWindow();
                QueryRaiseHR18OPT.Visible = false;
                TextBoxRaiseHR18OPT.Visible = false;
                PanelRaiseHR18OPT.Visible = false;
                PanelRaiseHR18OPT2.Visible = false;
                PanelRaiseHR18OPT3.Visible = false;

                LabelRespondHR18OPT.Visible = false;
            }

            else if ((ImageQueryHR18OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR18OPT.Visible = true;
                RAISEHR18OPT.ShowPopupWindow();
                QueryRaiseHR18OPT.Visible = true;
                TextBoxRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT2.Visible = false;
                PanelRaiseHR18OPT3.Visible = false;
                LabelRespondHR18OPT.Visible = true;
            }

            else if ((ImageQueryHR18OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR18OPT.Visible = true;
                RAISEHR18OPT.ShowPopupWindow();
                QueryRaiseHR18OPT.Visible = false;
                TextBoxRaiseHR18OPT.Visible = false;
                PanelRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT2.Visible = true;
                PanelRaiseHR18OPT3.Visible = false;
                LabelRespondHR18OPT.Visible = false;
            }
            else if ((ImageQueryHR18OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR18OPT.Visible = true;
                RAISEHR18OPT.ShowPopupWindow();
                QueryRaiseHR18OPT.Visible = false;
                TextBoxRaiseHR18OPT.Visible = false;
                PanelRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT2.Visible = true;
                PanelRaiseHR18OPT3.Visible = true;
                LabelRespondHR18OPT.Visible = false;
            }
            else
            {
                RAISEHR18OPT.Visible = true;
                RAISEHR18OPT.ShowPopupWindow();
                QueryRaiseHR18OPT.Visible = false;
                TextBoxRaiseHR18OPT.Visible = false;
                PanelRaiseHR18OPT.Visible = true;
                PanelRaiseHR18OPT2.Visible = true;
                PanelRaiseHR18OPT3.Visible = true;
                LabelRespondHR18OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR18OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR18OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR18OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR18OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR18OPT = '" + RadioButtonListHR18OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR18OPTMSG.ShowPopupWindow();
        RAISEHR18OPT.Visible = false;


    }
    #endregion
    #region QueryHR19OPT
    private void SetImageQueryHR19OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR19OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR19OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR19OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR19OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR19OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR19OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR19OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR19OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT2.Visible = false;
                PanelRaiseHR19OPT3.Visible = false;
                PanelHideHR19OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR19OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT2.Visible = true;
                PanelRaiseHR19OPT3.Visible = true;
                PanelHideHR19OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT2.Visible = true;
                PanelRaiseHR19OPT3.Visible = false;
                PanelHideHR19OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR19OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR19OPT = '" + RadioButtonListHR19OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR19OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR19OPT.Visible = true;
                RAISEHR19OPT.ShowPopupWindow();
                QueryRaiseHR19OPT.Visible = false;
                TextBoxRaiseHR19OPT.Visible = false;
                PanelRaiseHR19OPT.Visible = false;
                PanelRaiseHR19OPT2.Visible = false;
                PanelRaiseHR19OPT3.Visible = false;

                LabelRespondHR19OPT.Visible = false;
            }

            else if ((ImageQueryHR19OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR19OPT.Visible = true;
                RAISEHR19OPT.ShowPopupWindow();
                QueryRaiseHR19OPT.Visible = true;
                TextBoxRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT2.Visible = false;
                PanelRaiseHR19OPT3.Visible = false;
                LabelRespondHR19OPT.Visible = true;
            }

            else if ((ImageQueryHR19OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR19OPT.Visible = true;
                RAISEHR19OPT.ShowPopupWindow();
                QueryRaiseHR19OPT.Visible = false;
                TextBoxRaiseHR19OPT.Visible = false;
                PanelRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT2.Visible = true;
                PanelRaiseHR19OPT3.Visible = false;
                LabelRespondHR19OPT.Visible = false;
            }
            else if ((ImageQueryHR19OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR19OPT.Visible = true;
                RAISEHR19OPT.ShowPopupWindow();
                QueryRaiseHR19OPT.Visible = false;
                TextBoxRaiseHR19OPT.Visible = false;
                PanelRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT2.Visible = true;
                PanelRaiseHR19OPT3.Visible = true;
                LabelRespondHR19OPT.Visible = false;
            }
            else
            {
                RAISEHR19OPT.Visible = true;
                RAISEHR19OPT.ShowPopupWindow();
                QueryRaiseHR19OPT.Visible = false;
                TextBoxRaiseHR19OPT.Visible = false;
                PanelRaiseHR19OPT.Visible = true;
                PanelRaiseHR19OPT2.Visible = true;
                PanelRaiseHR19OPT3.Visible = true;
                LabelRespondHR19OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR19OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR19OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR19OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR19OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR19OPT = '" + RadioButtonListHR19OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR19OPTMSG.ShowPopupWindow();
        RAISEHR19OPT.Visible = false;


    }
    #endregion
    #region QueryHR20OPT
    private void SetImageQueryHR20OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR20OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR20OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR20OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR20OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR20OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR20OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR20OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR20OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT2.Visible = false;
                PanelRaiseHR20OPT3.Visible = false;
                PanelHideHR20OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR20OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT2.Visible = true;
                PanelRaiseHR20OPT3.Visible = true;
                PanelHideHR20OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT2.Visible = true;
                PanelRaiseHR20OPT3.Visible = false;
                PanelHideHR20OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR20OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR20OPT = '" + RadioButtonListHR20OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR20OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR20OPT.Visible = true;
                RAISEHR20OPT.ShowPopupWindow();
                QueryRaiseHR20OPT.Visible = false;
                TextBoxRaiseHR20OPT.Visible = false;
                PanelRaiseHR20OPT.Visible = false;
                PanelRaiseHR20OPT2.Visible = false;
                PanelRaiseHR20OPT3.Visible = false;

                LabelRespondHR20OPT.Visible = false;
            }

            else if ((ImageQueryHR20OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR20OPT.Visible = true;
                RAISEHR20OPT.ShowPopupWindow();
                QueryRaiseHR20OPT.Visible = true;
                TextBoxRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT2.Visible = false;
                PanelRaiseHR20OPT3.Visible = false;
                LabelRespondHR20OPT.Visible = true;
            }

            else if ((ImageQueryHR20OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR20OPT.Visible = true;
                RAISEHR20OPT.ShowPopupWindow();
                QueryRaiseHR20OPT.Visible = false;
                TextBoxRaiseHR20OPT.Visible = false;
                PanelRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT2.Visible = true;
                PanelRaiseHR20OPT3.Visible = false;
                LabelRespondHR20OPT.Visible = false;
            }
            else if ((ImageQueryHR20OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR20OPT.Visible = true;
                RAISEHR20OPT.ShowPopupWindow();
                QueryRaiseHR20OPT.Visible = false;
                TextBoxRaiseHR20OPT.Visible = false;
                PanelRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT2.Visible = true;
                PanelRaiseHR20OPT3.Visible = true;
                LabelRespondHR20OPT.Visible = false;
            }
            else
            {
                RAISEHR20OPT.Visible = true;
                RAISEHR20OPT.ShowPopupWindow();
                QueryRaiseHR20OPT.Visible = false;
                TextBoxRaiseHR20OPT.Visible = false;
                PanelRaiseHR20OPT.Visible = true;
                PanelRaiseHR20OPT2.Visible = true;
                PanelRaiseHR20OPT3.Visible = true;
                LabelRespondHR20OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR20OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR20OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR20OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR20OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR20OPT = '" + RadioButtonListHR20OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR20OPTMSG.ShowPopupWindow();
        RAISEHR20OPT.Visible = false;


    }
    #endregion
    #region QueryHR21OPT
    private void SetImageQueryHR21OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR21OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR21OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR21OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR21OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR21OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR21OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR21OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR21OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR21OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT2.Visible = false;
                PanelRaiseHR21OPT3.Visible = false;
                PanelHideHR21OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR21OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR21OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR21OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT2.Visible = true;
                PanelRaiseHR21OPT3.Visible = true;
                PanelHideHR21OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR21OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR21OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT2.Visible = true;
                PanelRaiseHR21OPT3.Visible = false;
                PanelHideHR21OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR21OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR21OPT = '" + RadioButtonListHR21OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR21OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR21OPT.Visible = true;
                RAISEHR21OPT.ShowPopupWindow();
                QueryRaiseHR21OPT.Visible = false;
                TextBoxRaiseHR21OPT.Visible = false;
                PanelRaiseHR21OPT.Visible = false;
                PanelRaiseHR21OPT2.Visible = false;
                PanelRaiseHR21OPT3.Visible = false;

                LabelRespondHR21OPT.Visible = false;
            }

            else if ((ImageQueryHR21OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR21OPT.Visible = true;
                RAISEHR21OPT.ShowPopupWindow();
                QueryRaiseHR21OPT.Visible = true;
                TextBoxRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT2.Visible = false;
                PanelRaiseHR21OPT3.Visible = false;
                LabelRespondHR21OPT.Visible = true;
            }

            else if ((ImageQueryHR21OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR21OPT.Visible = true;
                RAISEHR21OPT.ShowPopupWindow();
                QueryRaiseHR21OPT.Visible = false;
                TextBoxRaiseHR21OPT.Visible = false;
                PanelRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT2.Visible = true;
                PanelRaiseHR21OPT3.Visible = false;
                LabelRespondHR21OPT.Visible = false;
            }
            else if ((ImageQueryHR21OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR21OPT.Visible = true;
                RAISEHR21OPT.ShowPopupWindow();
                QueryRaiseHR21OPT.Visible = false;
                TextBoxRaiseHR21OPT.Visible = false;
                PanelRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT2.Visible = true;
                PanelRaiseHR21OPT3.Visible = true;
                LabelRespondHR21OPT.Visible = false;
            }
            else
            {
                RAISEHR21OPT.Visible = true;
                RAISEHR21OPT.ShowPopupWindow();
                QueryRaiseHR21OPT.Visible = false;
                TextBoxRaiseHR21OPT.Visible = false;
                PanelRaiseHR21OPT.Visible = true;
                PanelRaiseHR21OPT2.Visible = true;
                PanelRaiseHR21OPT3.Visible = true;
                LabelRespondHR21OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR21OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR21OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR21OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR21OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR21OPT = '" + RadioButtonListHR21OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR21OPTMSG.ShowPopupWindow();
        RAISEHR21OPT.Visible = false;


    }
    #endregion
    #region QueryHR22OPT
    private void SetImageQueryHR22OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR22OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR22OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR22OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR22OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR22OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR22OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR22OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR22OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR22OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT2.Visible = false;
                PanelRaiseHR22OPT3.Visible = false;
                PanelHideHR22OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR22OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR22OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR22OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT2.Visible = true;
                PanelRaiseHR22OPT3.Visible = true;
                PanelHideHR22OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR22OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR22OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT2.Visible = true;
                PanelRaiseHR22OPT3.Visible = false;
                PanelHideHR22OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR22OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR22OPT = '" + RadioButtonListHR22OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR22OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR22OPT.Visible = true;
                RAISEHR22OPT.ShowPopupWindow();
                QueryRaiseHR22OPT.Visible = false;
                TextBoxRaiseHR22OPT.Visible = false;
                PanelRaiseHR22OPT.Visible = false;
                PanelRaiseHR22OPT2.Visible = false;
                PanelRaiseHR22OPT3.Visible = false;

                LabelRespondHR22OPT.Visible = false;
            }

            else if ((ImageQueryHR22OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR22OPT.Visible = true;
                RAISEHR22OPT.ShowPopupWindow();
                QueryRaiseHR22OPT.Visible = true;
                TextBoxRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT2.Visible = false;
                PanelRaiseHR22OPT3.Visible = false;
                LabelRespondHR22OPT.Visible = true;
            }

            else if ((ImageQueryHR22OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR22OPT.Visible = true;
                RAISEHR22OPT.ShowPopupWindow();
                QueryRaiseHR22OPT.Visible = false;
                TextBoxRaiseHR22OPT.Visible = false;
                PanelRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT2.Visible = true;
                PanelRaiseHR22OPT3.Visible = false;
                LabelRespondHR22OPT.Visible = false;
            }
            else if ((ImageQueryHR22OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR22OPT.Visible = true;
                RAISEHR22OPT.ShowPopupWindow();
                QueryRaiseHR22OPT.Visible = false;
                TextBoxRaiseHR22OPT.Visible = false;
                PanelRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT2.Visible = true;
                PanelRaiseHR22OPT3.Visible = true;
                LabelRespondHR22OPT.Visible = false;
            }
            else
            {
                RAISEHR22OPT.Visible = true;
                RAISEHR22OPT.ShowPopupWindow();
                QueryRaiseHR22OPT.Visible = false;
                TextBoxRaiseHR22OPT.Visible = false;
                PanelRaiseHR22OPT.Visible = true;
                PanelRaiseHR22OPT2.Visible = true;
                PanelRaiseHR22OPT3.Visible = true;
                LabelRespondHR22OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR22OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR22OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR22OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR22OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR22OPT = '" + RadioButtonListHR22OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR22OPTMSG.ShowPopupWindow();
        RAISEHR22OPT.Visible = false;


    }
    #endregion
    #region QueryHR23OPT
    private void SetImageQueryHR23OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR23OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR23OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR23OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR23OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR23OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR23OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR23OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR23OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR23OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT2.Visible = false;
                PanelRaiseHR23OPT3.Visible = false;
                PanelHideHR23OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR23OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR23OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR23OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT2.Visible = true;
                PanelRaiseHR23OPT3.Visible = true;
                PanelHideHR23OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR23OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR23OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT2.Visible = true;
                PanelRaiseHR23OPT3.Visible = false;
                PanelHideHR23OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR23OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR23OPT = '" + RadioButtonListHR23OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR23OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR23OPT.Visible = true;
                RAISEHR23OPT.ShowPopupWindow();
                QueryRaiseHR23OPT.Visible = false;
                TextBoxRaiseHR23OPT.Visible = false;
                PanelRaiseHR23OPT.Visible = false;
                PanelRaiseHR23OPT2.Visible = false;
                PanelRaiseHR23OPT3.Visible = false;

                LabelRespondHR23OPT.Visible = false;
            }

            else if ((ImageQueryHR23OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR23OPT.Visible = true;
                RAISEHR23OPT.ShowPopupWindow();
                QueryRaiseHR23OPT.Visible = true;
                TextBoxRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT2.Visible = false;
                PanelRaiseHR23OPT3.Visible = false;
                LabelRespondHR23OPT.Visible = true;
            }

            else if ((ImageQueryHR23OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR23OPT.Visible = true;
                RAISEHR23OPT.ShowPopupWindow();
                QueryRaiseHR23OPT.Visible = false;
                TextBoxRaiseHR23OPT.Visible = false;
                PanelRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT2.Visible = true;
                PanelRaiseHR23OPT3.Visible = false;
                LabelRespondHR23OPT.Visible = false;
            }
            else if ((ImageQueryHR23OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR23OPT.Visible = true;
                RAISEHR23OPT.ShowPopupWindow();
                QueryRaiseHR23OPT.Visible = false;
                TextBoxRaiseHR23OPT.Visible = false;
                PanelRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT2.Visible = true;
                PanelRaiseHR23OPT3.Visible = true;
                LabelRespondHR23OPT.Visible = false;
            }
            else
            {
                RAISEHR23OPT.Visible = true;
                RAISEHR23OPT.ShowPopupWindow();
                QueryRaiseHR23OPT.Visible = false;
                TextBoxRaiseHR23OPT.Visible = false;
                PanelRaiseHR23OPT.Visible = true;
                PanelRaiseHR23OPT2.Visible = true;
                PanelRaiseHR23OPT3.Visible = true;
                LabelRespondHR23OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR23OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR23OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR23OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR23OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR23OPT = '" + RadioButtonListHR23OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR23OPTMSG.ShowPopupWindow();
        RAISEHR23OPT.Visible = false;


    }
    #endregion
    #region QueryHR24OPT
    private void SetImageQueryHR24OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR24OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR24OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR24OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR24OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR24OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR24OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR24OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR24OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR24OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT2.Visible = false;
                PanelRaiseHR24OPT3.Visible = false;
                PanelHideHR24OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR24OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR24OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR24OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT2.Visible = true;
                PanelRaiseHR24OPT3.Visible = true;
                PanelHideHR24OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR24OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR24OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT2.Visible = true;
                PanelRaiseHR24OPT3.Visible = false;
                PanelHideHR24OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR24OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR24OPT = '" + RadioButtonListHR24OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR24OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR24OPT.Visible = true;
                RAISEHR24OPT.ShowPopupWindow();
                QueryRaiseHR24OPT.Visible = false;
                TextBoxRaiseHR24OPT.Visible = false;
                PanelRaiseHR24OPT.Visible = false;
                PanelRaiseHR24OPT2.Visible = false;
                PanelRaiseHR24OPT3.Visible = false;

                LabelRespondHR24OPT.Visible = false;
            }

            else if ((ImageQueryHR24OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR24OPT.Visible = true;
                RAISEHR24OPT.ShowPopupWindow();
                QueryRaiseHR24OPT.Visible = true;
                TextBoxRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT2.Visible = false;
                PanelRaiseHR24OPT3.Visible = false;
                LabelRespondHR24OPT.Visible = true;
            }

            else if ((ImageQueryHR24OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR24OPT.Visible = true;
                RAISEHR24OPT.ShowPopupWindow();
                QueryRaiseHR24OPT.Visible = false;
                TextBoxRaiseHR24OPT.Visible = false;
                PanelRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT2.Visible = true;
                PanelRaiseHR24OPT3.Visible = false;
                LabelRespondHR24OPT.Visible = false;
            }
            else if ((ImageQueryHR24OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR24OPT.Visible = true;
                RAISEHR24OPT.ShowPopupWindow();
                QueryRaiseHR24OPT.Visible = false;
                TextBoxRaiseHR24OPT.Visible = false;
                PanelRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT2.Visible = true;
                PanelRaiseHR24OPT3.Visible = true;
                LabelRespondHR24OPT.Visible = false;
            }
            else
            {
                RAISEHR24OPT.Visible = true;
                RAISEHR24OPT.ShowPopupWindow();
                QueryRaiseHR24OPT.Visible = false;
                TextBoxRaiseHR24OPT.Visible = false;
                PanelRaiseHR24OPT.Visible = true;
                PanelRaiseHR24OPT2.Visible = true;
                PanelRaiseHR24OPT3.Visible = true;
                LabelRespondHR24OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR24OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR24OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR24OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR24OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR24OPT = '" + RadioButtonListHR24OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR24OPTMSG.ShowPopupWindow();
        RAISEHR24OPT.Visible = false;


    }
    #endregion
    #region QueryHR25OPT
    private void SetImageQueryHR25OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR25OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR25OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR25OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR25OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR25OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR25OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR25OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR25OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR25OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT2.Visible = false;
                PanelRaiseHR25OPT3.Visible = false;
                PanelHideHR25OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR25OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR25OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR25OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT2.Visible = true;
                PanelRaiseHR25OPT3.Visible = true;
                PanelHideHR25OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR25OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR25OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT2.Visible = true;
                PanelRaiseHR25OPT3.Visible = false;
                PanelHideHR25OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR25OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR25OPT = '" + RadioButtonListHR25OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR25OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR25OPT.Visible = true;
                RAISEHR25OPT.ShowPopupWindow();
                QueryRaiseHR25OPT.Visible = false;
                TextBoxRaiseHR25OPT.Visible = false;
                PanelRaiseHR25OPT.Visible = false;
                PanelRaiseHR25OPT2.Visible = false;
                PanelRaiseHR25OPT3.Visible = false;

                LabelRespondHR25OPT.Visible = false;
            }

            else if ((ImageQueryHR25OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR25OPT.Visible = true;
                RAISEHR25OPT.ShowPopupWindow();
                QueryRaiseHR25OPT.Visible = true;
                TextBoxRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT2.Visible = false;
                PanelRaiseHR25OPT3.Visible = false;
                LabelRespondHR25OPT.Visible = true;
            }

            else if ((ImageQueryHR25OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR25OPT.Visible = true;
                RAISEHR25OPT.ShowPopupWindow();
                QueryRaiseHR25OPT.Visible = false;
                TextBoxRaiseHR25OPT.Visible = false;
                PanelRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT2.Visible = true;
                PanelRaiseHR25OPT3.Visible = false;
                LabelRespondHR25OPT.Visible = false;
            }
            else if ((ImageQueryHR25OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR25OPT.Visible = true;
                RAISEHR25OPT.ShowPopupWindow();
                QueryRaiseHR25OPT.Visible = false;
                TextBoxRaiseHR25OPT.Visible = false;
                PanelRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT2.Visible = true;
                PanelRaiseHR25OPT3.Visible = true;
                LabelRespondHR25OPT.Visible = false;
            }
            else
            {
                RAISEHR25OPT.Visible = true;
                RAISEHR25OPT.ShowPopupWindow();
                QueryRaiseHR25OPT.Visible = false;
                TextBoxRaiseHR25OPT.Visible = false;
                PanelRaiseHR25OPT.Visible = true;
                PanelRaiseHR25OPT2.Visible = true;
                PanelRaiseHR25OPT3.Visible = true;
                LabelRespondHR25OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR25OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR25OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR25OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR25OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR25OPT = '" + RadioButtonListHR25OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR25OPTMSG.ShowPopupWindow();
        RAISEHR25OPT.Visible = false;


    }
    #endregion
    #region QueryHR26OPT
    private void SetImageQueryHR26OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR26OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR26OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR26OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR26OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR26OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR26OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR26OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR26OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR26OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT2.Visible = false;
                PanelRaiseHR26OPT3.Visible = false;
                PanelHideHR26OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR26OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR26OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR26OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT2.Visible = true;
                PanelRaiseHR26OPT3.Visible = true;
                PanelHideHR26OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR26OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR26OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT2.Visible = true;
                PanelRaiseHR26OPT3.Visible = false;
                PanelHideHR26OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR26OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR26OPT = '" + RadioButtonListHR26OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR26OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR26OPT.Visible = true;
                RAISEHR26OPT.ShowPopupWindow();
                QueryRaiseHR26OPT.Visible = false;
                TextBoxRaiseHR26OPT.Visible = false;
                PanelRaiseHR26OPT.Visible = false;
                PanelRaiseHR26OPT2.Visible = false;
                PanelRaiseHR26OPT3.Visible = false;

                LabelRespondHR26OPT.Visible = false;
            }

            else if ((ImageQueryHR26OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR26OPT.Visible = true;
                RAISEHR26OPT.ShowPopupWindow();
                QueryRaiseHR26OPT.Visible = true;
                TextBoxRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT2.Visible = false;
                PanelRaiseHR26OPT3.Visible = false;
                LabelRespondHR26OPT.Visible = true;
            }

            else if ((ImageQueryHR26OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR26OPT.Visible = true;
                RAISEHR26OPT.ShowPopupWindow();
                QueryRaiseHR26OPT.Visible = false;
                TextBoxRaiseHR26OPT.Visible = false;
                PanelRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT2.Visible = true;
                PanelRaiseHR26OPT3.Visible = false;
                LabelRespondHR26OPT.Visible = false;
            }
            else if ((ImageQueryHR26OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR26OPT.Visible = true;
                RAISEHR26OPT.ShowPopupWindow();
                QueryRaiseHR26OPT.Visible = false;
                TextBoxRaiseHR26OPT.Visible = false;
                PanelRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT2.Visible = true;
                PanelRaiseHR26OPT3.Visible = true;
                LabelRespondHR26OPT.Visible = false;
            }
            else
            {
                RAISEHR26OPT.Visible = true;
                RAISEHR26OPT.ShowPopupWindow();
                QueryRaiseHR26OPT.Visible = false;
                TextBoxRaiseHR26OPT.Visible = false;
                PanelRaiseHR26OPT.Visible = true;
                PanelRaiseHR26OPT2.Visible = true;
                PanelRaiseHR26OPT3.Visible = true;
                LabelRespondHR26OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR26OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR26OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR26OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR26OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR26OPT = '" + RadioButtonListHR26OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR26OPTMSG.ShowPopupWindow();
        RAISEHR26OPT.Visible = false;


    }
    #endregion
    #region QueryHR27OPT
    private void SetImageQueryHR27OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR27OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR27OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR27OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR27OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR27OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR27OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR27OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR27OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR27OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT2.Visible = false;
                PanelRaiseHR27OPT3.Visible = false;
                PanelHideHR27OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR27OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR27OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR27OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT2.Visible = true;
                PanelRaiseHR27OPT3.Visible = true;
                PanelHideHR27OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR27OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR27OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT2.Visible = true;
                PanelRaiseHR27OPT3.Visible = false;
                PanelHideHR27OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR27OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR27OPT = '" + RadioButtonListHR27OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR27OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR27OPT.Visible = true;
                RAISEHR27OPT.ShowPopupWindow();
                QueryRaiseHR27OPT.Visible = false;
                TextBoxRaiseHR27OPT.Visible = false;
                PanelRaiseHR27OPT.Visible = false;
                PanelRaiseHR27OPT2.Visible = false;
                PanelRaiseHR27OPT3.Visible = false;

                LabelRespondHR27OPT.Visible = false;
            }

            else if ((ImageQueryHR27OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR27OPT.Visible = true;
                RAISEHR27OPT.ShowPopupWindow();
                QueryRaiseHR27OPT.Visible = true;
                TextBoxRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT2.Visible = false;
                PanelRaiseHR27OPT3.Visible = false;
                LabelRespondHR27OPT.Visible = true;
            }

            else if ((ImageQueryHR27OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR27OPT.Visible = true;
                RAISEHR27OPT.ShowPopupWindow();
                QueryRaiseHR27OPT.Visible = false;
                TextBoxRaiseHR27OPT.Visible = false;
                PanelRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT2.Visible = true;
                PanelRaiseHR27OPT3.Visible = false;
                LabelRespondHR27OPT.Visible = false;
            }
            else if ((ImageQueryHR27OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR27OPT.Visible = true;
                RAISEHR27OPT.ShowPopupWindow();
                QueryRaiseHR27OPT.Visible = false;
                TextBoxRaiseHR27OPT.Visible = false;
                PanelRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT2.Visible = true;
                PanelRaiseHR27OPT3.Visible = true;
                LabelRespondHR27OPT.Visible = false;
            }
            else
            {
                RAISEHR27OPT.Visible = true;
                RAISEHR27OPT.ShowPopupWindow();
                QueryRaiseHR27OPT.Visible = false;
                TextBoxRaiseHR27OPT.Visible = false;
                PanelRaiseHR27OPT.Visible = true;
                PanelRaiseHR27OPT2.Visible = true;
                PanelRaiseHR27OPT3.Visible = true;
                LabelRespondHR27OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR27OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR27OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR27OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR27OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR27OPT = '" + RadioButtonListHR27OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR27OPTMSG.ShowPopupWindow();
        RAISEHR27OPT.Visible = false;


    }
    #endregion
    #region QueryHR28OPT
    private void SetImageQueryHR28OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR28OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR28OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR28OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR28OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR28OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR28OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR28OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR28OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR28OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT2.Visible = false;
                PanelRaiseHR28OPT3.Visible = false;
                PanelHideHR28OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR28OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR28OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR28OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT2.Visible = true;
                PanelRaiseHR28OPT3.Visible = true;
                PanelHideHR28OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR28OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR28OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT2.Visible = true;
                PanelRaiseHR28OPT3.Visible = false;
                PanelHideHR28OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR28OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR28OPT = '" + RadioButtonListHR28OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR28OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR28OPT.Visible = true;
                RAISEHR28OPT.ShowPopupWindow();
                QueryRaiseHR28OPT.Visible = false;
                TextBoxRaiseHR28OPT.Visible = false;
                PanelRaiseHR28OPT.Visible = false;
                PanelRaiseHR28OPT2.Visible = false;
                PanelRaiseHR28OPT3.Visible = false;

                LabelRespondHR28OPT.Visible = false;
            }

            else if ((ImageQueryHR28OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR28OPT.Visible = true;
                RAISEHR28OPT.ShowPopupWindow();
                QueryRaiseHR28OPT.Visible = true;
                TextBoxRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT2.Visible = false;
                PanelRaiseHR28OPT3.Visible = false;
                LabelRespondHR28OPT.Visible = true;
            }

            else if ((ImageQueryHR28OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR28OPT.Visible = true;
                RAISEHR28OPT.ShowPopupWindow();
                QueryRaiseHR28OPT.Visible = false;
                TextBoxRaiseHR28OPT.Visible = false;
                PanelRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT2.Visible = true;
                PanelRaiseHR28OPT3.Visible = false;
                LabelRespondHR28OPT.Visible = false;
            }
            else if ((ImageQueryHR28OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR28OPT.Visible = true;
                RAISEHR28OPT.ShowPopupWindow();
                QueryRaiseHR28OPT.Visible = false;
                TextBoxRaiseHR28OPT.Visible = false;
                PanelRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT2.Visible = true;
                PanelRaiseHR28OPT3.Visible = true;
                LabelRespondHR28OPT.Visible = false;
            }
            else
            {
                RAISEHR28OPT.Visible = true;
                RAISEHR28OPT.ShowPopupWindow();
                QueryRaiseHR28OPT.Visible = false;
                TextBoxRaiseHR28OPT.Visible = false;
                PanelRaiseHR28OPT.Visible = true;
                PanelRaiseHR28OPT2.Visible = true;
                PanelRaiseHR28OPT3.Visible = true;
                LabelRespondHR28OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR28OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR28OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR28OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR28OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR28OPT = '" + RadioButtonListHR28OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR28OPTMSG.ShowPopupWindow();
        RAISEHR28OPT.Visible = false;


    }
    #endregion
    #region QueryHR29OPT
    private void SetImageQueryHR29OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR29OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR29OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR29OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR29OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR29OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR29OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR29OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR29OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR29OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT2.Visible = false;
                PanelRaiseHR29OPT3.Visible = false;
                PanelHideHR29OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR29OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR29OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR29OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT2.Visible = true;
                PanelRaiseHR29OPT3.Visible = true;
                PanelHideHR29OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR29OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR29OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT2.Visible = true;
                PanelRaiseHR29OPT3.Visible = false;
                PanelHideHR29OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR29OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR29OPT = '" + RadioButtonListHR29OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR29OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR29OPT.Visible = true;
                RAISEHR29OPT.ShowPopupWindow();
                QueryRaiseHR29OPT.Visible = false;
                TextBoxRaiseHR29OPT.Visible = false;
                PanelRaiseHR29OPT.Visible = false;
                PanelRaiseHR29OPT2.Visible = false;
                PanelRaiseHR29OPT3.Visible = false;

                LabelRespondHR29OPT.Visible = false;
            }

            else if ((ImageQueryHR29OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR29OPT.Visible = true;
                RAISEHR29OPT.ShowPopupWindow();
                QueryRaiseHR29OPT.Visible = true;
                TextBoxRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT2.Visible = false;
                PanelRaiseHR29OPT3.Visible = false;
                LabelRespondHR29OPT.Visible = true;
            }

            else if ((ImageQueryHR29OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR29OPT.Visible = true;
                RAISEHR29OPT.ShowPopupWindow();
                QueryRaiseHR29OPT.Visible = false;
                TextBoxRaiseHR29OPT.Visible = false;
                PanelRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT2.Visible = true;
                PanelRaiseHR29OPT3.Visible = false;
                LabelRespondHR29OPT.Visible = false;
            }
            else if ((ImageQueryHR29OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR29OPT.Visible = true;
                RAISEHR29OPT.ShowPopupWindow();
                QueryRaiseHR29OPT.Visible = false;
                TextBoxRaiseHR29OPT.Visible = false;
                PanelRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT2.Visible = true;
                PanelRaiseHR29OPT3.Visible = true;
                LabelRespondHR29OPT.Visible = false;
            }
            else
            {
                RAISEHR29OPT.Visible = true;
                RAISEHR29OPT.ShowPopupWindow();
                QueryRaiseHR29OPT.Visible = false;
                TextBoxRaiseHR29OPT.Visible = false;
                PanelRaiseHR29OPT.Visible = true;
                PanelRaiseHR29OPT2.Visible = true;
                PanelRaiseHR29OPT3.Visible = true;
                LabelRespondHR29OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR29OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR29OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR29OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR29OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR29OPT = '" + RadioButtonListHR29OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR29OPTMSG.ShowPopupWindow();
        RAISEHR29OPT.Visible = false;


    }
    #endregion
    #region QueryHR30OPT
    private void SetImageQueryHR30OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR30OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryHR30OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryHR30OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryHR30OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryHR30OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryHR30OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataHR30OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR30OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseHR30OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT2.Visible = false;
                PanelRaiseHR30OPT3.Visible = false;
                PanelHideHR30OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseHR30OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR30OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseHR30OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT2.Visible = true;
                PanelRaiseHR30OPT3.Visible = true;
                PanelHideHR30OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseHR30OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseHR30OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT2.Visible = true;
                PanelRaiseHR30OPT3.Visible = false;
                PanelHideHR30OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryHR30OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[HRQoL_Questionnaire] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR30OPT = '" + RadioButtonListHR30OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryHR30OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEHR30OPT.Visible = true;
                RAISEHR30OPT.ShowPopupWindow();
                QueryRaiseHR30OPT.Visible = false;
                TextBoxRaiseHR30OPT.Visible = false;
                PanelRaiseHR30OPT.Visible = false;
                PanelRaiseHR30OPT2.Visible = false;
                PanelRaiseHR30OPT3.Visible = false;

                LabelRespondHR30OPT.Visible = false;
            }

            else if ((ImageQueryHR30OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR30OPT.Visible = true;
                RAISEHR30OPT.ShowPopupWindow();
                QueryRaiseHR30OPT.Visible = true;
                TextBoxRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT2.Visible = false;
                PanelRaiseHR30OPT3.Visible = false;
                LabelRespondHR30OPT.Visible = true;
            }

            else if ((ImageQueryHR30OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR30OPT.Visible = true;
                RAISEHR30OPT.ShowPopupWindow();
                QueryRaiseHR30OPT.Visible = false;
                TextBoxRaiseHR30OPT.Visible = false;
                PanelRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT2.Visible = true;
                PanelRaiseHR30OPT3.Visible = false;
                LabelRespondHR30OPT.Visible = false;
            }
            else if ((ImageQueryHR30OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEHR30OPT.Visible = true;
                RAISEHR30OPT.ShowPopupWindow();
                QueryRaiseHR30OPT.Visible = false;
                TextBoxRaiseHR30OPT.Visible = false;
                PanelRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT2.Visible = true;
                PanelRaiseHR30OPT3.Visible = true;
                LabelRespondHR30OPT.Visible = false;
            }
            else
            {
                RAISEHR30OPT.Visible = true;
                RAISEHR30OPT.ShowPopupWindow();
                QueryRaiseHR30OPT.Visible = false;
                TextBoxRaiseHR30OPT.Visible = false;
                PanelRaiseHR30OPT.Visible = true;
                PanelRaiseHR30OPT2.Visible = true;
                PanelRaiseHR30OPT3.Visible = true;
                LabelRespondHR30OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseHR30OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseHR30OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR30OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblHR30OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[HRQoL_Questionnaire] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and HR30OPT = '" + RadioButtonListHR30OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEHR30OPTMSG.ShowPopupWindow();
        RAISEHR30OPT.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListHRPER.SelectedValue == "Yes")
        {
            hideHRQOL.Visible = true;
        }
        else
        {
            hideHRQOL.Visible = false;
        }
    }

    protected void RadioButtonListHRPER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListHRPER.SelectedValue == "Yes")
        {
            hideHRQOL.Visible = true;
        }
        else
        {
            hideHRQOL.Visible = false;
            RadioButtonListHR1OPT.ClearSelection();
            RadioButtonListHR2OPT.ClearSelection();
            RadioButtonListHR3OPT.ClearSelection();
            RadioButtonListHR4OPT.ClearSelection();
            RadioButtonListHR5OPT.ClearSelection();
            RadioButtonListHR6OPT.ClearSelection();
            RadioButtonListHR7OPT.ClearSelection();
            RadioButtonListHR8OPT.ClearSelection();
            RadioButtonListHR9OPT.ClearSelection();
            RadioButtonListHR10OPT.ClearSelection();
            RadioButtonListHR11OPT.ClearSelection();
            RadioButtonListHR12OPT.ClearSelection();
            RadioButtonListHR13OPT.ClearSelection();
            RadioButtonListHR14OPT.ClearSelection();
            RadioButtonListHR15OPT.ClearSelection();
            RadioButtonListHR16OPT.ClearSelection();
            RadioButtonListHR17OPT.ClearSelection();
            RadioButtonListHR18OPT.ClearSelection();
            RadioButtonListHR19OPT.ClearSelection();
            RadioButtonListHR20OPT.ClearSelection();
            RadioButtonListHR21OPT.ClearSelection();
            RadioButtonListHR22OPT.ClearSelection();
            RadioButtonListHR23OPT.ClearSelection();
            RadioButtonListHR24OPT.ClearSelection();
            RadioButtonListHR25OPT.ClearSelection();
            RadioButtonListHR26OPT.ClearSelection();
            RadioButtonListHR27OPT.ClearSelection();
            RadioButtonListHR28OPT.ClearSelection();
            RadioButtonListHR29OPT.ClearSelection();
            RadioButtonListHR30OPT.ClearSelection();
        }
    }
}