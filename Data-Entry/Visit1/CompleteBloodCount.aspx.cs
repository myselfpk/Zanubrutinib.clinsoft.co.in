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

public partial class Data_Entry_Visit1_CompleteBloodCount : System.Web.UI.Page
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

        SetImageQueryLABASS();
        SetImageQueryRSLT1OPT();
        SetImageQueryRSLT2OPT();
        SetImageQueryRSLT3OPT();
        SetImageQueryRSLT4OPT();
        SetImageQueryRSLT5OPT();
        SetImageQueryRSLT6OPT();
        SetImageQueryRSLT7OPT();
        SetImageQueryRSLT8OPT();
        SetImageQueryRSLT9OPT();
        SetImageQueryRSLT10OPT();
        SetImageQueryRSLT11OPT();
        SetImageQueryRSLT12OPT();
        SetImageQueryRSLT13OPT();
        
        BindQueryDataLABASS();
        BindQueryDataRSLT1OPT();
        BindQueryDataRSLT2OPT();
        BindQueryDataRSLT3OPT();
        BindQueryDataRSLT4OPT();
        BindQueryDataRSLT5OPT();
        BindQueryDataRSLT6OPT();
        BindQueryDataRSLT7OPT();
        BindQueryDataRSLT8OPT();
        BindQueryDataRSLT9OPT();
        BindQueryDataRSLT10OPT();
        BindQueryDataRSLT11OPT();
        BindQueryDataRSLT12OPT();
        BindQueryDataRSLT13OPT();

        ShowHide();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select LABASS , RSLT1OPT , UN1OPT , NAB1OPT , ABN1OPT , RSLT2OPT , UN2OPT , NAB2OPT , ABN2OPT , RSLT3OPT , UN3OPT , NAB3OPT , ABN3OPT , RSLT4OPT , UN4OPT , NAB4OPT , ABN4OPT , RSLT5OPT , UN5OPT , NAB5OPT , ABN5OPT , RSLT6OPT , UN6OPT , NAB6OPT , ABN6OPT , RSLT7OPT , UN7OPT , NAB7OPT , ABN7OPT , RSLT8OPT , UN8OPT , NAB8OPT , ABN8OPT , RSLT9OPT , UN9OPT , NAB9OPT , ABN9OPT , RSLT10OPT , UN10OPT , NAB10OPT , ABN10OPT , RSLT11OPT , UN11OPT , NAB11OPT , ABN11OPT , RSLT12OPT , UN12OPT , NAB12OPT , ABN12OPT , RSLT13OPT , UN13OPT , NAB13OPT , ABN13OPT from [Visit1].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListLABASS.SelectedValue = dt.Rows[0]["LABASS"].ToString().Trim();
            TextBoxRSLT1OPT.Text = dt.Rows[0]["RSLT1OPT"].ToString().Trim();
            TextBoxUN1OPT.Text = dt.Rows[0]["UN1OPT"].ToString().Trim();
            RadioButtonListNAB1OPT.SelectedValue = dt.Rows[0]["NAB1OPT"].ToString().Trim();
            RadioButtonListABN1OPT.SelectedValue = dt.Rows[0]["ABN1OPT"].ToString().Trim();
            TextBoxRSLT2OPT.Text = dt.Rows[0]["RSLT2OPT"].ToString().Trim();
            TextBoxUN2OPT.Text = dt.Rows[0]["UN2OPT"].ToString().Trim();
            RadioButtonListNAB2OPT.SelectedValue = dt.Rows[0]["NAB2OPT"].ToString().Trim();
            RadioButtonListABN2OPT.SelectedValue = dt.Rows[0]["ABN2OPT"].ToString().Trim();
            TextBoxRSLT3OPT.Text = dt.Rows[0]["RSLT3OPT"].ToString().Trim();
            TextBoxUN3OPT.Text = dt.Rows[0]["UN3OPT"].ToString().Trim();
            RadioButtonListNAB3OPT.SelectedValue = dt.Rows[0]["NAB3OPT"].ToString().Trim();
            RadioButtonListABN3OPT.SelectedValue = dt.Rows[0]["ABN3OPT"].ToString().Trim();
            TextBoxRSLT4OPT.Text = dt.Rows[0]["RSLT4OPT"].ToString().Trim();
            TextBoxUN4OPT.Text = dt.Rows[0]["UN4OPT"].ToString().Trim();
            RadioButtonListNAB4OPT.SelectedValue = dt.Rows[0]["NAB4OPT"].ToString().Trim();
            RadioButtonListABN4OPT.SelectedValue = dt.Rows[0]["ABN4OPT"].ToString().Trim();
            TextBoxRSLT5OPT.Text = dt.Rows[0]["RSLT5OPT"].ToString().Trim();
            TextBoxUN5OPT.Text = dt.Rows[0]["UN5OPT"].ToString().Trim();
            RadioButtonListNAB5OPT.SelectedValue = dt.Rows[0]["NAB5OPT"].ToString().Trim();
            RadioButtonListABN5OPT.SelectedValue = dt.Rows[0]["ABN5OPT"].ToString().Trim();
            TextBoxRSLT6OPT.Text = dt.Rows[0]["RSLT6OPT"].ToString().Trim();
            TextBoxUN6OPT.Text = dt.Rows[0]["UN6OPT"].ToString().Trim();
            RadioButtonListNAB6OPT.SelectedValue = dt.Rows[0]["NAB6OPT"].ToString().Trim();
            RadioButtonListABN6OPT.SelectedValue = dt.Rows[0]["ABN6OPT"].ToString().Trim();
            TextBoxRSLT7OPT.Text = dt.Rows[0]["RSLT7OPT"].ToString().Trim();
            TextBoxUN7OPT.Text = dt.Rows[0]["UN7OPT"].ToString().Trim();
            RadioButtonListNAB7OPT.SelectedValue = dt.Rows[0]["NAB7OPT"].ToString().Trim();
            RadioButtonListABN7OPT.SelectedValue = dt.Rows[0]["ABN7OPT"].ToString().Trim();
            TextBoxRSLT8OPT.Text = dt.Rows[0]["RSLT8OPT"].ToString().Trim();
            TextBoxUN8OPT.Text = dt.Rows[0]["UN8OPT"].ToString().Trim();
            RadioButtonListNAB8OPT.SelectedValue = dt.Rows[0]["NAB8OPT"].ToString().Trim();
            RadioButtonListABN8OPT.SelectedValue = dt.Rows[0]["ABN8OPT"].ToString().Trim();
            TextBoxRSLT9OPT.Text = dt.Rows[0]["RSLT9OPT"].ToString().Trim();
            TextBoxUN9OPT.Text = dt.Rows[0]["UN9OPT"].ToString().Trim();
            RadioButtonListNAB9OPT.SelectedValue = dt.Rows[0]["NAB9OPT"].ToString().Trim();
            RadioButtonListABN9OPT.SelectedValue = dt.Rows[0]["ABN9OPT"].ToString().Trim();
            TextBoxRSLT10OPT.Text = dt.Rows[0]["RSLT10OPT"].ToString().Trim();
            TextBoxUN10OPT.Text = dt.Rows[0]["UN10OPT"].ToString().Trim();
            RadioButtonListNAB10OPT.SelectedValue = dt.Rows[0]["NAB10OPT"].ToString().Trim();
            RadioButtonListABN10OPT.SelectedValue = dt.Rows[0]["ABN10OPT"].ToString().Trim();
            TextBoxRSLT11OPT.Text = dt.Rows[0]["RSLT11OPT"].ToString().Trim();
            TextBoxUN11OPT.Text = dt.Rows[0]["UN11OPT"].ToString().Trim();
            RadioButtonListNAB11OPT.SelectedValue = dt.Rows[0]["NAB11OPT"].ToString().Trim();
            RadioButtonListABN11OPT.SelectedValue = dt.Rows[0]["ABN11OPT"].ToString().Trim();
            TextBoxRSLT12OPT.Text = dt.Rows[0]["RSLT12OPT"].ToString().Trim();
            TextBoxUN12OPT.Text = dt.Rows[0]["UN12OPT"].ToString().Trim();
            RadioButtonListNAB12OPT.SelectedValue = dt.Rows[0]["NAB12OPT"].ToString().Trim();
            RadioButtonListABN12OPT.SelectedValue = dt.Rows[0]["ABN12OPT"].ToString().Trim();
            TextBoxRSLT13OPT.Text = dt.Rows[0]["RSLT13OPT"].ToString().Trim();
            TextBoxUN13OPT.Text = dt.Rows[0]["UN13OPT"].ToString().Trim();
            RadioButtonListNAB13OPT.SelectedValue = dt.Rows[0]["NAB13OPT"].ToString().Trim();
            RadioButtonListABN13OPT.SelectedValue = dt.Rows[0]["ABN13OPT"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListLABASS.SelectedValue;
            ViewState["txt2"] = TextBoxRSLT1OPT.Text;
            ViewState["txt3"] = TextBoxUN1OPT.Text;
            ViewState["txt4"] = RadioButtonListNAB1OPT.SelectedValue;
            ViewState["txt5"] = RadioButtonListABN1OPT.SelectedValue;
            ViewState["txt6"] = TextBoxRSLT2OPT.Text;
            ViewState["txt7"] = TextBoxUN2OPT.Text;
            ViewState["txt8"] = RadioButtonListNAB2OPT.SelectedValue;
            ViewState["txt9"] = RadioButtonListABN2OPT.SelectedValue;
            ViewState["txt10"] = TextBoxRSLT3OPT.Text;
            ViewState["txt11"] = TextBoxUN3OPT.Text;
            ViewState["txt12"] = RadioButtonListNAB3OPT.SelectedValue;
            ViewState["txt13"] = RadioButtonListABN3OPT.SelectedValue;
            ViewState["txt14"] = TextBoxRSLT4OPT.Text;
            ViewState["txt15"] = TextBoxUN4OPT.Text;
            ViewState["txt16"] = RadioButtonListNAB4OPT.SelectedValue;
            ViewState["txt17"] = RadioButtonListABN4OPT.SelectedValue;
            ViewState["txt18"] = TextBoxRSLT5OPT.Text;
            ViewState["txt19"] = TextBoxUN5OPT.Text;
            ViewState["txt20"] = RadioButtonListNAB5OPT.SelectedValue;
            ViewState["txt21"] = RadioButtonListABN5OPT.SelectedValue;
            ViewState["txt22"] = TextBoxRSLT6OPT.Text;
            ViewState["txt23"] = TextBoxUN6OPT.Text;
            ViewState["txt24"] = RadioButtonListNAB6OPT.SelectedValue;
            ViewState["txt25"] = RadioButtonListABN6OPT.SelectedValue;
            ViewState["txt26"] = TextBoxRSLT7OPT.Text;
            ViewState["txt27"] = TextBoxUN7OPT.Text;
            ViewState["txt28"] = RadioButtonListNAB7OPT.SelectedValue;
            ViewState["txt29"] = RadioButtonListABN7OPT.SelectedValue;
            ViewState["txt30"] = TextBoxRSLT8OPT.Text;
            ViewState["txt31"] = TextBoxUN8OPT.Text;
            ViewState["txt32"] = RadioButtonListNAB8OPT.SelectedValue;
            ViewState["txt33"] = RadioButtonListABN8OPT.SelectedValue;
            ViewState["txt34"] = TextBoxRSLT9OPT.Text;
            ViewState["txt35"] = TextBoxUN9OPT.Text;
            ViewState["txt36"] = RadioButtonListNAB9OPT.SelectedValue;
            ViewState["txt37"] = RadioButtonListABN9OPT.SelectedValue;
            ViewState["txt38"] = TextBoxRSLT10OPT.Text;
            ViewState["txt39"] = TextBoxUN10OPT.Text;
            ViewState["txt40"] = RadioButtonListNAB10OPT.SelectedValue;
            ViewState["txt41"] = RadioButtonListABN10OPT.SelectedValue;
            ViewState["txt42"] = TextBoxRSLT11OPT.Text;
            ViewState["txt43"] = TextBoxUN11OPT.Text;
            ViewState["txt44"] = RadioButtonListNAB11OPT.SelectedValue;
            ViewState["txt45"] = RadioButtonListABN11OPT.SelectedValue;
            ViewState["txt46"] = TextBoxRSLT12OPT.Text;
            ViewState["txt47"] = TextBoxUN12OPT.Text;
            ViewState["txt48"] = RadioButtonListNAB12OPT.SelectedValue;
            ViewState["txt49"] = RadioButtonListABN12OPT.SelectedValue;
            ViewState["txt50"] = TextBoxRSLT13OPT.Text;
            ViewState["txt51"] = TextBoxUN13OPT.Text;
            ViewState["txt52"] = RadioButtonListNAB13OPT.SelectedValue;
            ViewState["txt53"] = RadioButtonListABN13OPT.SelectedValue;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_LabCompleteBloodCount]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@LABASS", RadioButtonListLABASS.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT1OPT", TextBoxRSLT1OPT.Text);
                    cmd.Parameters.AddWithValue("@UN1OPT", TextBoxUN1OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB1OPT", RadioButtonListNAB1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN1OPT", RadioButtonListABN1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT2OPT", TextBoxRSLT2OPT.Text);
                    cmd.Parameters.AddWithValue("@UN2OPT", TextBoxUN2OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB2OPT", RadioButtonListNAB2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN2OPT", RadioButtonListABN2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT3OPT", TextBoxRSLT3OPT.Text);
                    cmd.Parameters.AddWithValue("@UN3OPT", TextBoxUN3OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB3OPT", RadioButtonListNAB3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN3OPT", RadioButtonListABN3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT4OPT", TextBoxRSLT4OPT.Text);
                    cmd.Parameters.AddWithValue("@UN4OPT", TextBoxUN4OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB4OPT", RadioButtonListNAB4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN4OPT", RadioButtonListABN4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT5OPT", TextBoxRSLT5OPT.Text);
                    cmd.Parameters.AddWithValue("@UN5OPT", TextBoxUN5OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB5OPT", RadioButtonListNAB5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN5OPT", RadioButtonListABN5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT6OPT", TextBoxRSLT6OPT.Text);
                    cmd.Parameters.AddWithValue("@UN6OPT", TextBoxUN6OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB6OPT", RadioButtonListNAB6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN6OPT", RadioButtonListABN6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT7OPT", TextBoxRSLT7OPT.Text);
                    cmd.Parameters.AddWithValue("@UN7OPT", TextBoxUN7OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB7OPT", RadioButtonListNAB7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN7OPT", RadioButtonListABN7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT8OPT", TextBoxRSLT8OPT.Text);
                    cmd.Parameters.AddWithValue("@UN8OPT", TextBoxUN8OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB8OPT", RadioButtonListNAB8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN8OPT", RadioButtonListABN8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT9OPT", TextBoxRSLT9OPT.Text);
                    cmd.Parameters.AddWithValue("@UN9OPT", TextBoxUN9OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB9OPT", RadioButtonListNAB9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN9OPT", RadioButtonListABN9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT10OPT", TextBoxRSLT10OPT.Text);
                    cmd.Parameters.AddWithValue("@UN10OPT", TextBoxUN10OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB10OPT", RadioButtonListNAB10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN10OPT", RadioButtonListABN10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT11OPT", TextBoxRSLT11OPT.Text);
                    cmd.Parameters.AddWithValue("@UN11OPT", TextBoxUN11OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB11OPT", RadioButtonListNAB11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN11OPT", RadioButtonListABN11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT12OPT", TextBoxRSLT12OPT.Text);
                    cmd.Parameters.AddWithValue("@UN12OPT", TextBoxUN12OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB12OPT", RadioButtonListNAB12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN12OPT", RadioButtonListABN12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT13OPT", TextBoxRSLT13OPT.Text);
                    cmd.Parameters.AddWithValue("@UN13OPT", TextBoxUN13OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB13OPT", RadioButtonListNAB13OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN13OPT", RadioButtonListABN13OPT.SelectedValue);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListLABASS.SelectedValue || ViewState["txt2"].ToString() != TextBoxRSLT1OPT.Text || ViewState["txt3"].ToString() != TextBoxUN1OPT.Text || ViewState["txt4"].ToString() != RadioButtonListNAB1OPT.SelectedValue || ViewState["txt5"].ToString() != RadioButtonListABN1OPT.SelectedValue || ViewState["txt6"].ToString() != TextBoxRSLT2OPT.Text || ViewState["txt7"].ToString() != TextBoxUN2OPT.Text || ViewState["txt8"].ToString() != RadioButtonListNAB2OPT.SelectedValue || ViewState["txt9"].ToString() != RadioButtonListABN2OPT.SelectedValue || ViewState["txt10"].ToString() != TextBoxRSLT3OPT.Text || ViewState["txt11"].ToString() != TextBoxUN3OPT.Text || ViewState["txt12"].ToString() != RadioButtonListNAB3OPT.SelectedValue || ViewState["txt13"].ToString() != RadioButtonListABN3OPT.SelectedValue || ViewState["txt14"].ToString() != TextBoxRSLT4OPT.Text || ViewState["txt15"].ToString() != TextBoxUN4OPT.Text || ViewState["txt16"].ToString() != RadioButtonListNAB4OPT.SelectedValue || ViewState["txt17"].ToString() != RadioButtonListABN4OPT.SelectedValue || ViewState["txt18"].ToString() != TextBoxRSLT5OPT.Text || ViewState["txt19"].ToString() != TextBoxUN5OPT.Text || ViewState["txt20"].ToString() != RadioButtonListNAB5OPT.SelectedValue || ViewState["txt21"].ToString() != RadioButtonListABN5OPT.SelectedValue || ViewState["txt22"].ToString() != TextBoxRSLT6OPT.Text || ViewState["txt23"].ToString() != TextBoxUN6OPT.Text || ViewState["txt24"].ToString() != RadioButtonListNAB6OPT.SelectedValue || ViewState["txt25"].ToString() != RadioButtonListABN6OPT.SelectedValue || ViewState["txt26"].ToString() != TextBoxRSLT7OPT.Text || ViewState["txt27"].ToString() != TextBoxUN7OPT.Text || ViewState["txt28"].ToString() != RadioButtonListNAB7OPT.SelectedValue || ViewState["txt29"].ToString() != RadioButtonListABN7OPT.SelectedValue || ViewState["txt30"].ToString() != TextBoxRSLT8OPT.Text || ViewState["txt31"].ToString() != TextBoxUN8OPT.Text || ViewState["txt32"].ToString() != RadioButtonListNAB8OPT.SelectedValue || ViewState["txt33"].ToString() != RadioButtonListABN8OPT.SelectedValue || ViewState["txt34"].ToString() != TextBoxRSLT9OPT.Text || ViewState["txt35"].ToString() != TextBoxUN9OPT.Text || ViewState["txt36"].ToString() != RadioButtonListNAB9OPT.SelectedValue || ViewState["txt37"].ToString() != RadioButtonListABN9OPT.SelectedValue || ViewState["txt38"].ToString() != TextBoxRSLT10OPT.Text || ViewState["txt39"].ToString() != TextBoxUN10OPT.Text || ViewState["txt40"].ToString() != RadioButtonListNAB10OPT.SelectedValue || ViewState["txt41"].ToString() != RadioButtonListABN10OPT.SelectedValue || ViewState["txt42"].ToString() != TextBoxRSLT11OPT.Text || ViewState["txt43"].ToString() != TextBoxUN11OPT.Text || ViewState["txt44"].ToString() != RadioButtonListNAB11OPT.SelectedValue || ViewState["txt45"].ToString() != RadioButtonListABN11OPT.SelectedValue || ViewState["txt46"].ToString() != TextBoxRSLT12OPT.Text || ViewState["txt47"].ToString() != TextBoxUN12OPT.Text || ViewState["txt48"].ToString() != RadioButtonListNAB12OPT.SelectedValue || ViewState["txt49"].ToString() != RadioButtonListABN12OPT.SelectedValue || ViewState["txt50"].ToString() != TextBoxRSLT13OPT.Text || ViewState["txt51"].ToString() != TextBoxUN13OPT.Text || ViewState["txt52"].ToString() != RadioButtonListNAB13OPT.SelectedValue || ViewState["txt53"].ToString() != RadioButtonListABN13OPT.SelectedValue)
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
                cmd = new SqlCommand("[Visit1].[sp_LabCompleteBloodCount]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@LABASS", RadioButtonListLABASS.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT1OPT", TextBoxRSLT1OPT.Text);
                cmd.Parameters.AddWithValue("@UN1OPT", TextBoxUN1OPT.Text);
                cmd.Parameters.AddWithValue("@NAB1OPT", RadioButtonListNAB1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN1OPT", RadioButtonListABN1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT2OPT", TextBoxRSLT2OPT.Text);
                cmd.Parameters.AddWithValue("@UN2OPT", TextBoxUN2OPT.Text);
                cmd.Parameters.AddWithValue("@NAB2OPT", RadioButtonListNAB2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN2OPT", RadioButtonListABN2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT3OPT", TextBoxRSLT3OPT.Text);
                cmd.Parameters.AddWithValue("@UN3OPT", TextBoxUN3OPT.Text);
                cmd.Parameters.AddWithValue("@NAB3OPT", RadioButtonListNAB3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN3OPT", RadioButtonListABN3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT4OPT", TextBoxRSLT4OPT.Text);
                cmd.Parameters.AddWithValue("@UN4OPT", TextBoxUN4OPT.Text);
                cmd.Parameters.AddWithValue("@NAB4OPT", RadioButtonListNAB4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN4OPT", RadioButtonListABN4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT5OPT", TextBoxRSLT5OPT.Text);
                cmd.Parameters.AddWithValue("@UN5OPT", TextBoxUN5OPT.Text);
                cmd.Parameters.AddWithValue("@NAB5OPT", RadioButtonListNAB5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN5OPT", RadioButtonListABN5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT6OPT", TextBoxRSLT6OPT.Text);
                cmd.Parameters.AddWithValue("@UN6OPT", TextBoxUN6OPT.Text);
                cmd.Parameters.AddWithValue("@NAB6OPT", RadioButtonListNAB6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN6OPT", RadioButtonListABN6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT7OPT", TextBoxRSLT7OPT.Text);
                cmd.Parameters.AddWithValue("@UN7OPT", TextBoxUN7OPT.Text);
                cmd.Parameters.AddWithValue("@NAB7OPT", RadioButtonListNAB7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN7OPT", RadioButtonListABN7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT8OPT", TextBoxRSLT8OPT.Text);
                cmd.Parameters.AddWithValue("@UN8OPT", TextBoxUN8OPT.Text);
                cmd.Parameters.AddWithValue("@NAB8OPT", RadioButtonListNAB8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN8OPT", RadioButtonListABN8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT9OPT", TextBoxRSLT9OPT.Text);
                cmd.Parameters.AddWithValue("@UN9OPT", TextBoxUN9OPT.Text);
                cmd.Parameters.AddWithValue("@NAB9OPT", RadioButtonListNAB9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN9OPT", RadioButtonListABN9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT10OPT", TextBoxRSLT10OPT.Text);
                cmd.Parameters.AddWithValue("@UN10OPT", TextBoxUN10OPT.Text);
                cmd.Parameters.AddWithValue("@NAB10OPT", RadioButtonListNAB10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN10OPT", RadioButtonListABN10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT11OPT", TextBoxRSLT11OPT.Text);
                cmd.Parameters.AddWithValue("@UN11OPT", TextBoxUN11OPT.Text);
                cmd.Parameters.AddWithValue("@NAB11OPT", RadioButtonListNAB11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN11OPT", RadioButtonListABN11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT12OPT", TextBoxRSLT12OPT.Text);
                cmd.Parameters.AddWithValue("@UN12OPT", TextBoxUN12OPT.Text);
                cmd.Parameters.AddWithValue("@NAB12OPT", RadioButtonListNAB12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN12OPT", RadioButtonListABN12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT13OPT", TextBoxRSLT13OPT.Text);
                cmd.Parameters.AddWithValue("@UN13OPT", TextBoxUN13OPT.Text);
                cmd.Parameters.AddWithValue("@NAB13OPT", RadioButtonListNAB13OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN13OPT", RadioButtonListABN13OPT.SelectedValue);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[LabCompleteBloodCount] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_LabCompleteBloodCount]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@LABASS", RadioButtonListLABASS.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT1OPT", TextBoxRSLT1OPT.Text);
                    cmd.Parameters.AddWithValue("@UN1OPT", TextBoxUN1OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB1OP", RadioButtonListNAB1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN1OP", RadioButtonListABN1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT2OP", TextBoxRSLT2OPT.Text);
                    cmd.Parameters.AddWithValue("@UN2OPT", TextBoxUN2OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB2OPT", RadioButtonListNAB2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN2OPT", RadioButtonListABN2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT3OPT", TextBoxRSLT3OPT.Text);
                    cmd.Parameters.AddWithValue("@UN3OPT", TextBoxUN3OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB3OPT", RadioButtonListNAB3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN3OPT", RadioButtonListABN3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT4OPT", TextBoxRSLT4OPT.Text);
                    cmd.Parameters.AddWithValue("@UN4OPT", TextBoxUN4OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB4OPT", RadioButtonListNAB4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN4OPT", RadioButtonListABN4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT5OPT", TextBoxRSLT5OPT.Text);
                    cmd.Parameters.AddWithValue("@UN5OPT", TextBoxUN5OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB5OPT", RadioButtonListNAB5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN5OPT", RadioButtonListABN5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT6OPT", TextBoxRSLT6OPT.Text);
                    cmd.Parameters.AddWithValue("@UN6OPT", TextBoxUN6OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB6OPT", RadioButtonListNAB6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN6OPT", RadioButtonListABN6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT7OPT", TextBoxRSLT7OPT.Text);
                    cmd.Parameters.AddWithValue("@UN7OPT", TextBoxUN7OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB7OPT", RadioButtonListNAB7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN7OPT", RadioButtonListABN7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT8OPT", TextBoxRSLT8OPT.Text);
                    cmd.Parameters.AddWithValue("@UN8OPT", TextBoxUN8OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB8OPT", RadioButtonListNAB8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN8OPT", RadioButtonListABN8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT9OPT", TextBoxRSLT9OPT.Text);
                    cmd.Parameters.AddWithValue("@UN9OPT", TextBoxUN9OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB9OPT", RadioButtonListNAB9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN9OPT", RadioButtonListABN9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT10OPT", TextBoxRSLT10OPT.Text);
                    cmd.Parameters.AddWithValue("@UN10OPT", TextBoxUN10OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB10OPT", RadioButtonListNAB10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN10OPT", RadioButtonListABN10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT11OPT", TextBoxRSLT11OPT.Text);
                    cmd.Parameters.AddWithValue("@UN11OPT", TextBoxUN11OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB11OPT", RadioButtonListNAB11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN11OPT", RadioButtonListABN11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT12OPT", TextBoxRSLT12OPT.Text);
                    cmd.Parameters.AddWithValue("@UN12OPT", TextBoxUN12OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB12OPT", RadioButtonListNAB12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN12OPT", RadioButtonListABN12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT13OPT", TextBoxRSLT13OPT.Text);
                    cmd.Parameters.AddWithValue("@UN13OPT", TextBoxUN13OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB13OPT", RadioButtonListNAB13OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN13OPT", RadioButtonListABN13OPT.SelectedValue);

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
                cmd = new SqlCommand("[Visit1].[sp_LabCompleteBloodCount]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@LABASS", RadioButtonListLABASS.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT1OPT", TextBoxRSLT1OPT.Text);
                cmd.Parameters.AddWithValue("@UN1OPT", TextBoxUN1OPT.Text);
                cmd.Parameters.AddWithValue("@NAB1OP", RadioButtonListNAB1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN1OP", RadioButtonListABN1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT2OP", TextBoxRSLT2OPT.Text);
                cmd.Parameters.AddWithValue("@UN2OPT", TextBoxUN2OPT.Text);
                cmd.Parameters.AddWithValue("@NAB2OPT", RadioButtonListNAB2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN2OPT", RadioButtonListABN2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT3OPT", TextBoxRSLT3OPT.Text);
                cmd.Parameters.AddWithValue("@UN3OPT", TextBoxUN3OPT.Text);
                cmd.Parameters.AddWithValue("@NAB3OPT", RadioButtonListNAB3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN3OPT", RadioButtonListABN3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT4OPT", TextBoxRSLT4OPT.Text);
                cmd.Parameters.AddWithValue("@UN4OPT", TextBoxUN4OPT.Text);
                cmd.Parameters.AddWithValue("@NAB4OPT", RadioButtonListNAB4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN4OPT", RadioButtonListABN4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT5OPT", TextBoxRSLT5OPT.Text);
                cmd.Parameters.AddWithValue("@UN5OPT", TextBoxUN5OPT.Text);
                cmd.Parameters.AddWithValue("@NAB5OPT", RadioButtonListNAB5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN5OPT", RadioButtonListABN5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT6OPT", TextBoxRSLT6OPT.Text);
                cmd.Parameters.AddWithValue("@UN6OPT", TextBoxUN6OPT.Text);
                cmd.Parameters.AddWithValue("@NAB6OPT", RadioButtonListNAB6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN6OPT", RadioButtonListABN6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT7OPT", TextBoxRSLT7OPT.Text);
                cmd.Parameters.AddWithValue("@UN7OPT", TextBoxUN7OPT.Text);
                cmd.Parameters.AddWithValue("@NAB7OPT", RadioButtonListNAB7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN7OPT", RadioButtonListABN7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT8OPT", TextBoxRSLT8OPT.Text);
                cmd.Parameters.AddWithValue("@UN8OPT", TextBoxUN8OPT.Text);
                cmd.Parameters.AddWithValue("@NAB8OPT", RadioButtonListNAB8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN8OPT", RadioButtonListABN8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT9OPT", TextBoxRSLT9OPT.Text);
                cmd.Parameters.AddWithValue("@UN9OPT", TextBoxUN9OPT.Text);
                cmd.Parameters.AddWithValue("@NAB9OPT", RadioButtonListNAB9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN9OPT", RadioButtonListABN9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT10OPT", TextBoxRSLT10OPT.Text);
                cmd.Parameters.AddWithValue("@UN10OPT", TextBoxUN10OPT.Text);
                cmd.Parameters.AddWithValue("@NAB10OPT", RadioButtonListNAB10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN10OPT", RadioButtonListABN10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT11OPT", TextBoxRSLT11OPT.Text);
                cmd.Parameters.AddWithValue("@UN11OPT", TextBoxUN11OPT.Text);
                cmd.Parameters.AddWithValue("@NAB11OPT", RadioButtonListNAB11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN11OPT", RadioButtonListABN11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT12OPT", TextBoxRSLT12OPT.Text);
                cmd.Parameters.AddWithValue("@UN12OPT", TextBoxUN12OPT.Text);
                cmd.Parameters.AddWithValue("@NAB12OPT", RadioButtonListNAB12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN12OPT", RadioButtonListABN12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT13OPT", TextBoxRSLT13OPT.Text);
                cmd.Parameters.AddWithValue("@UN13OPT", TextBoxUN13OPT.Text);
                cmd.Parameters.AddWithValue("@NAB13OPT", RadioButtonListNAB13OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN13OPT", RadioButtonListABN13OPT.SelectedValue);

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
        if (!string.IsNullOrEmpty(RadioButtonListLABASS.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT1OPT.Text) || !string.IsNullOrEmpty(TextBoxUN1OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN1OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT2OPT.Text) || !string.IsNullOrEmpty(TextBoxUN2OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN2OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT3OPT.Text) || !string.IsNullOrEmpty(TextBoxUN3OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN3OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT4OPT.Text) || !string.IsNullOrEmpty(TextBoxUN4OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB4OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN4OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT5OPT.Text) || !string.IsNullOrEmpty(TextBoxUN5OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB5OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN5OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT6OPT.Text) || !string.IsNullOrEmpty(TextBoxUN6OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB6OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN6OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT7OPT.Text) || !string.IsNullOrEmpty(TextBoxUN7OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB7OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN7OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT8OPT.Text) || !string.IsNullOrEmpty(TextBoxUN8OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB8OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN8OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT9OPT.Text) || !string.IsNullOrEmpty(TextBoxUN9OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB9OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN9OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT10OPT.Text) || !string.IsNullOrEmpty(TextBoxUN10OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB10OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN10OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT11OPT.Text) || !string.IsNullOrEmpty(TextBoxUN11OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB11OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN11OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT12OPT.Text) || !string.IsNullOrEmpty(TextBoxUN12OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB12OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN12OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT13OPT.Text) || !string.IsNullOrEmpty(TextBoxUN13OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB13OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN13OPT.SelectedValue))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListLABASS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblLABASS.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListLABASS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() != TextBoxRSLT1OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxRSLT1OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() != TextBoxUN1OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxUN1OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() != RadioButtonListNAB1OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListNAB1OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() != RadioButtonListABN1OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListABN1OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() != TextBoxRSLT2OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = TextBoxRSLT2OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() != TextBoxUN2OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = TextBoxUN2OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() != RadioButtonListNAB2OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListNAB2OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() != RadioButtonListABN2OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListABN2OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != TextBoxRSLT3OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = TextBoxRSLT3OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != TextBoxUN3OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = TextBoxUN3OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != RadioButtonListNAB3OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = RadioButtonListNAB3OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != RadioButtonListABN3OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = RadioButtonListABN3OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString() != TextBoxRSLT4OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = TextBoxRSLT4OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString() != TextBoxUN4OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = TextBoxUN4OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt16"].ToString() != RadioButtonListNAB4OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][15];
                dtrow["NewValue"] = RadioButtonListNAB4OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt17"].ToString() != RadioButtonListABN4OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][16];
                dtrow["NewValue"] = RadioButtonListABN4OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt18"].ToString() != TextBoxRSLT5OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][17];
                dtrow["NewValue"] = TextBoxRSLT5OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt19"].ToString() != TextBoxUN5OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][18];
                dtrow["NewValue"] = TextBoxUN5OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt20"].ToString() != RadioButtonListNAB5OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][19];
                dtrow["NewValue"] = RadioButtonListNAB5OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt21"].ToString() != RadioButtonListABN5OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][20];
                dtrow["NewValue"] = RadioButtonListABN5OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt22"].ToString() != TextBoxRSLT6OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][21];
                dtrow["NewValue"] = TextBoxRSLT6OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt23"].ToString() != TextBoxUN6OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][22];
                dtrow["NewValue"] = TextBoxUN6OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt24"].ToString() != RadioButtonListNAB6OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][23];
                dtrow["NewValue"] = RadioButtonListNAB6OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt25"].ToString() != RadioButtonListABN6OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][24];
                dtrow["NewValue"] = RadioButtonListABN6OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt26"].ToString() != TextBoxRSLT7OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT7OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][25];
                dtrow["NewValue"] = TextBoxRSLT7OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt27"].ToString() != TextBoxUN7OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN7OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][26];
                dtrow["NewValue"] = TextBoxUN7OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt28"].ToString() != RadioButtonListNAB7OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB7OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][27];
                dtrow["NewValue"] = RadioButtonListNAB7OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt29"].ToString() != RadioButtonListABN7OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN7OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][28];
                dtrow["NewValue"] = RadioButtonListABN7OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt30"].ToString() != TextBoxRSLT8OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT8OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][29];
                dtrow["NewValue"] = TextBoxRSLT8OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt31"].ToString() != TextBoxUN8OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN8OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][30];
                dtrow["NewValue"] = TextBoxUN8OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt32"].ToString() != RadioButtonListNAB8OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB8OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][31];
                dtrow["NewValue"] = RadioButtonListNAB8OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt33"].ToString() != RadioButtonListABN8OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN8OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][32];
                dtrow["NewValue"] = RadioButtonListABN8OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt34"].ToString() != TextBoxRSLT9OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT9OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][33];
                dtrow["NewValue"] = TextBoxRSLT9OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt35"].ToString() != TextBoxUN9OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN9OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][34];
                dtrow["NewValue"] = TextBoxUN9OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt36"].ToString() != RadioButtonListNAB9OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB9OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][35];
                dtrow["NewValue"] = RadioButtonListNAB9OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt37"].ToString() != RadioButtonListABN9OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN9OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][36];
                dtrow["NewValue"] = RadioButtonListABN9OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt38"].ToString() != TextBoxRSLT10OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT10OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][37];
                dtrow["NewValue"] = TextBoxRSLT10OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt39"].ToString() != TextBoxUN10OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN10OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][38];
                dtrow["NewValue"] = TextBoxUN10OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt40"].ToString() != RadioButtonListNAB10OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB10OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][39];
                dtrow["NewValue"] = RadioButtonListNAB10OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt41"].ToString() != RadioButtonListABN10OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN10OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][40];
                dtrow["NewValue"] = RadioButtonListABN10OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt42"].ToString() != TextBoxRSLT11OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT11OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][41];
                dtrow["NewValue"] = TextBoxRSLT11OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt43"].ToString() != TextBoxUN11OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN11OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][42];
                dtrow["NewValue"] = TextBoxUN11OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt44"].ToString() != RadioButtonListNAB11OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB11OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][43];
                dtrow["NewValue"] = RadioButtonListNAB11OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt45"].ToString() != RadioButtonListABN11OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN11OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][44];
                dtrow["NewValue"] = RadioButtonListABN11OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt46"].ToString() != TextBoxRSLT12OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT12OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][45];
                dtrow["NewValue"] = TextBoxRSLT12OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt47"].ToString() != TextBoxUN12OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN12OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][46];
                dtrow["NewValue"] = TextBoxUN12OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt48"].ToString() != RadioButtonListNAB12OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB12OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][47];
                dtrow["NewValue"] = RadioButtonListNAB12OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt49"].ToString() != RadioButtonListABN12OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN12OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][48];
                dtrow["NewValue"] = RadioButtonListABN12OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt50"].ToString() != TextBoxRSLT13OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT13OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][49];
                dtrow["NewValue"] = TextBoxRSLT13OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt51"].ToString() != TextBoxUN13OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN13OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][50];
                dtrow["NewValue"] = TextBoxUN13OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt52"].ToString() != RadioButtonListNAB13OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB13OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][51];
                dtrow["NewValue"] = RadioButtonListNAB13OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt53"].ToString() != RadioButtonListABN13OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN13OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][52];
                dtrow["NewValue"] = RadioButtonListABN13OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_LabCompleteBloodCount]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@LABASS", RadioButtonListLABASS.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT1OPT", TextBoxRSLT1OPT.Text);
            cmd.Parameters.AddWithValue("@UN1OPT", TextBoxUN1OPT.Text);
            cmd.Parameters.AddWithValue("@NAB1OP", RadioButtonListNAB1OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN1OP", RadioButtonListABN1OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT2OP", TextBoxRSLT2OPT.Text);
            cmd.Parameters.AddWithValue("@UN2OPT", TextBoxUN2OPT.Text);
            cmd.Parameters.AddWithValue("@NAB2OPT", RadioButtonListNAB2OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN2OPT", RadioButtonListABN2OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT3OPT", TextBoxRSLT3OPT.Text);
            cmd.Parameters.AddWithValue("@UN3OPT", TextBoxUN3OPT.Text);
            cmd.Parameters.AddWithValue("@NAB3OPT", RadioButtonListNAB3OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN3OPT", RadioButtonListABN3OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT4OPT", TextBoxRSLT4OPT.Text);
            cmd.Parameters.AddWithValue("@UN4OPT", TextBoxUN4OPT.Text);
            cmd.Parameters.AddWithValue("@NAB4OPT", RadioButtonListNAB4OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN4OPT", RadioButtonListABN4OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT5OPT", TextBoxRSLT5OPT.Text);
            cmd.Parameters.AddWithValue("@UN5OPT", TextBoxUN5OPT.Text);
            cmd.Parameters.AddWithValue("@NAB5OPT", RadioButtonListNAB5OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN5OPT", RadioButtonListABN5OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT6OPT", TextBoxRSLT6OPT.Text);
            cmd.Parameters.AddWithValue("@UN6OPT", TextBoxUN6OPT.Text);
            cmd.Parameters.AddWithValue("@NAB6OPT", RadioButtonListNAB6OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN6OPT", RadioButtonListABN6OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT7OPT", TextBoxRSLT7OPT.Text);
            cmd.Parameters.AddWithValue("@UN7OPT", TextBoxUN7OPT.Text);
            cmd.Parameters.AddWithValue("@NAB7OPT", RadioButtonListNAB7OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN7OPT", RadioButtonListABN7OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT8OPT", TextBoxRSLT8OPT.Text);
            cmd.Parameters.AddWithValue("@UN8OPT", TextBoxUN8OPT.Text);
            cmd.Parameters.AddWithValue("@NAB8OPT", RadioButtonListNAB8OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN8OPT", RadioButtonListABN8OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT9OPT", TextBoxRSLT9OPT.Text);
            cmd.Parameters.AddWithValue("@UN9OPT", TextBoxUN9OPT.Text);
            cmd.Parameters.AddWithValue("@NAB9OPT", RadioButtonListNAB9OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN9OPT", RadioButtonListABN9OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT10OPT", TextBoxRSLT10OPT.Text);
            cmd.Parameters.AddWithValue("@UN10OPT", TextBoxUN10OPT.Text);
            cmd.Parameters.AddWithValue("@NAB10OPT", RadioButtonListNAB10OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN10OPT", RadioButtonListABN10OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT11OPT", TextBoxRSLT11OPT.Text);
            cmd.Parameters.AddWithValue("@UN11OPT", TextBoxUN11OPT.Text);
            cmd.Parameters.AddWithValue("@NAB11OPT", RadioButtonListNAB11OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN11OPT", RadioButtonListABN11OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT12OPT", TextBoxRSLT12OPT.Text);
            cmd.Parameters.AddWithValue("@UN12OPT", TextBoxUN12OPT.Text);
            cmd.Parameters.AddWithValue("@NAB12OPT", RadioButtonListNAB12OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN12OPT", RadioButtonListABN12OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT13OPT", TextBoxRSLT13OPT.Text);
            cmd.Parameters.AddWithValue("@UN13OPT", TextBoxUN13OPT.Text);
            cmd.Parameters.AddWithValue("@NAB13OPT", RadioButtonListNAB13OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN13OPT", RadioButtonListABN13OPT.SelectedValue);

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
    #region QueryLABASS
    private void SetImageQueryLABASS()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLABASS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLABASS.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLABASS.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLABASS.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryLABASS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLABASS.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataLABASS()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLABASS.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLABASS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLABASS.Visible = true;
                PanelRaiseLABASS2.Visible = false;
                PanelRaiseLABASS3.Visible = false;
                PanelHideLABASS.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLABASS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLABASS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseLABASS3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLABASS.Visible = true;
                PanelRaiseLABASS2.Visible = true;
                PanelRaiseLABASS3.Visible = true;
                PanelHideLABASS.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLABASS.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLABASS2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseLABASS.Visible = true;
                PanelRaiseLABASS2.Visible = true;
                PanelRaiseLABASS3.Visible = false;
                PanelHideLABASS.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryLABASS_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LABASS = '" + RadioButtonListLABASS.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLABASS.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELABASS.Visible = true;
                RAISELABASS.ShowPopupWindow();
                QueryRaiseLABASS.Visible = false;
                TextBoxRaiseLABASS.Visible = false;
                PanelRaiseLABASS.Visible = false;
                PanelRaiseLABASS2.Visible = false;
                PanelRaiseLABASS3.Visible = false;

                LabelRespondLABASS.Visible = false;
            }

            else if ((ImageQueryLABASS.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELABASS.Visible = true;
                RAISELABASS.ShowPopupWindow();
                QueryRaiseLABASS.Visible = true;
                TextBoxRaiseLABASS.Visible = true;
                PanelRaiseLABASS.Visible = true;
                PanelRaiseLABASS2.Visible = false;
                PanelRaiseLABASS3.Visible = false;
                LabelRespondLABASS.Visible = true;
            }

            else if ((ImageQueryLABASS.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELABASS.Visible = true;
                RAISELABASS.ShowPopupWindow();
                QueryRaiseLABASS.Visible = false;
                TextBoxRaiseLABASS.Visible = false;
                PanelRaiseLABASS.Visible = true;
                PanelRaiseLABASS2.Visible = true;
                PanelRaiseLABASS3.Visible = false;
                LabelRespondLABASS.Visible = false;
            }
            else if ((ImageQueryLABASS.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELABASS.Visible = true;
                RAISELABASS.ShowPopupWindow();
                QueryRaiseLABASS.Visible = false;
                TextBoxRaiseLABASS.Visible = false;
                PanelRaiseLABASS.Visible = true;
                PanelRaiseLABASS2.Visible = true;
                PanelRaiseLABASS3.Visible = true;
                LabelRespondLABASS.Visible = false;
            }
            else
            {
                RAISELABASS.Visible = true;
                RAISELABASS.ShowPopupWindow();
                QueryRaiseLABASS.Visible = false;
                TextBoxRaiseLABASS.Visible = false;
                PanelRaiseLABASS.Visible = true;
                PanelRaiseLABASS2.Visible = true;
                PanelRaiseLABASS3.Visible = true;
                LabelRespondLABASS.Visible = false;

            }
        }

    }
    protected void QueryRaiseLABASS_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseLABASS.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLABASS.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLABASS.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LABASS = '" + RadioButtonListLABASS.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELABASSMSG.ShowPopupWindow();
        RAISELABASS.Visible = false;


    }
    #endregion
    #region QueryRSLT1OPT
    private void SetImageQueryRSLT1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT1OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT1OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT1OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT2.Visible = false;
                PanelRaiseRSLT1OPT3.Visible = false;
                PanelHideRSLT1OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT2.Visible = true;
                PanelRaiseRSLT1OPT3.Visible = true;
                PanelHideRSLT1OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT2.Visible = true;
                PanelRaiseRSLT1OPT3.Visible = false;
                PanelHideRSLT1OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT1OPT = '" + TextBoxRSLT1OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT1OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT1OPT.Visible = true;
                RAISERSLT1OPT.ShowPopupWindow();
                QueryRaiseRSLT1OPT.Visible = false;
                TextBoxRaiseRSLT1OPT.Visible = false;
                PanelRaiseRSLT1OPT.Visible = false;
                PanelRaiseRSLT1OPT2.Visible = false;
                PanelRaiseRSLT1OPT3.Visible = false;

                LabelRespondRSLT1OPT.Visible = false;
            }

            else if ((ImageQueryRSLT1OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT1OPT.Visible = true;
                RAISERSLT1OPT.ShowPopupWindow();
                QueryRaiseRSLT1OPT.Visible = true;
                TextBoxRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT2.Visible = false;
                PanelRaiseRSLT1OPT3.Visible = false;
                LabelRespondRSLT1OPT.Visible = true;
            }

            else if ((ImageQueryRSLT1OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT1OPT.Visible = true;
                RAISERSLT1OPT.ShowPopupWindow();
                QueryRaiseRSLT1OPT.Visible = false;
                TextBoxRaiseRSLT1OPT.Visible = false;
                PanelRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT2.Visible = true;
                PanelRaiseRSLT1OPT3.Visible = false;
                LabelRespondRSLT1OPT.Visible = false;
            }
            else if ((ImageQueryRSLT1OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT1OPT.Visible = true;
                RAISERSLT1OPT.ShowPopupWindow();
                QueryRaiseRSLT1OPT.Visible = false;
                TextBoxRaiseRSLT1OPT.Visible = false;
                PanelRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT2.Visible = true;
                PanelRaiseRSLT1OPT3.Visible = true;
                LabelRespondRSLT1OPT.Visible = false;
            }
            else
            {
                RAISERSLT1OPT.Visible = true;
                RAISERSLT1OPT.ShowPopupWindow();
                QueryRaiseRSLT1OPT.Visible = false;
                TextBoxRaiseRSLT1OPT.Visible = false;
                PanelRaiseRSLT1OPT.Visible = true;
                PanelRaiseRSLT1OPT2.Visible = true;
                PanelRaiseRSLT1OPT3.Visible = true;
                LabelRespondRSLT1OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT1OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT1OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT1OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT1OPT = '" + TextBoxRSLT1OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT1OPTMSG.ShowPopupWindow();
        RAISERSLT1OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT2OPT
    private void SetImageQueryRSLT2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT2OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT2OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT2OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT2.Visible = false;
                PanelRaiseRSLT2OPT3.Visible = false;
                PanelHideRSLT2OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT2.Visible = true;
                PanelRaiseRSLT2OPT3.Visible = true;
                PanelHideRSLT2OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT2.Visible = true;
                PanelRaiseRSLT2OPT3.Visible = false;
                PanelHideRSLT2OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT2OPT = '" + TextBoxRSLT2OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT2OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT2OPT.Visible = true;
                RAISERSLT2OPT.ShowPopupWindow();
                QueryRaiseRSLT2OPT.Visible = false;
                TextBoxRaiseRSLT2OPT.Visible = false;
                PanelRaiseRSLT2OPT.Visible = false;
                PanelRaiseRSLT2OPT2.Visible = false;
                PanelRaiseRSLT2OPT3.Visible = false;

                LabelRespondRSLT2OPT.Visible = false;
            }

            else if ((ImageQueryRSLT2OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT2OPT.Visible = true;
                RAISERSLT2OPT.ShowPopupWindow();
                QueryRaiseRSLT2OPT.Visible = true;
                TextBoxRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT2.Visible = false;
                PanelRaiseRSLT2OPT3.Visible = false;
                LabelRespondRSLT2OPT.Visible = true;
            }

            else if ((ImageQueryRSLT2OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT2OPT.Visible = true;
                RAISERSLT2OPT.ShowPopupWindow();
                QueryRaiseRSLT2OPT.Visible = false;
                TextBoxRaiseRSLT2OPT.Visible = false;
                PanelRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT2.Visible = true;
                PanelRaiseRSLT2OPT3.Visible = false;
                LabelRespondRSLT2OPT.Visible = false;
            }
            else if ((ImageQueryRSLT2OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT2OPT.Visible = true;
                RAISERSLT2OPT.ShowPopupWindow();
                QueryRaiseRSLT2OPT.Visible = false;
                TextBoxRaiseRSLT2OPT.Visible = false;
                PanelRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT2.Visible = true;
                PanelRaiseRSLT2OPT3.Visible = true;
                LabelRespondRSLT2OPT.Visible = false;
            }
            else
            {
                RAISERSLT2OPT.Visible = true;
                RAISERSLT2OPT.ShowPopupWindow();
                QueryRaiseRSLT2OPT.Visible = false;
                TextBoxRaiseRSLT2OPT.Visible = false;
                PanelRaiseRSLT2OPT.Visible = true;
                PanelRaiseRSLT2OPT2.Visible = true;
                PanelRaiseRSLT2OPT3.Visible = true;
                LabelRespondRSLT2OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT2OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT2OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT2OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT2OPT = '" + TextBoxRSLT2OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT2OPTMSG.ShowPopupWindow();
        RAISERSLT2OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT3OPT
    private void SetImageQueryRSLT3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT3OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT3OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT3OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT2.Visible = false;
                PanelRaiseRSLT3OPT3.Visible = false;
                PanelHideRSLT3OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT2.Visible = true;
                PanelRaiseRSLT3OPT3.Visible = true;
                PanelHideRSLT3OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT2.Visible = true;
                PanelRaiseRSLT3OPT3.Visible = false;
                PanelHideRSLT3OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT3OPT = '" + TextBoxRSLT3OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT3OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT3OPT.Visible = true;
                RAISERSLT3OPT.ShowPopupWindow();
                QueryRaiseRSLT3OPT.Visible = false;
                TextBoxRaiseRSLT3OPT.Visible = false;
                PanelRaiseRSLT3OPT.Visible = false;
                PanelRaiseRSLT3OPT2.Visible = false;
                PanelRaiseRSLT3OPT3.Visible = false;

                LabelRespondRSLT3OPT.Visible = false;
            }

            else if ((ImageQueryRSLT3OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT3OPT.Visible = true;
                RAISERSLT3OPT.ShowPopupWindow();
                QueryRaiseRSLT3OPT.Visible = true;
                TextBoxRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT2.Visible = false;
                PanelRaiseRSLT3OPT3.Visible = false;
                LabelRespondRSLT3OPT.Visible = true;
            }

            else if ((ImageQueryRSLT3OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT3OPT.Visible = true;
                RAISERSLT3OPT.ShowPopupWindow();
                QueryRaiseRSLT3OPT.Visible = false;
                TextBoxRaiseRSLT3OPT.Visible = false;
                PanelRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT2.Visible = true;
                PanelRaiseRSLT3OPT3.Visible = false;
                LabelRespondRSLT3OPT.Visible = false;
            }
            else if ((ImageQueryRSLT3OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT3OPT.Visible = true;
                RAISERSLT3OPT.ShowPopupWindow();
                QueryRaiseRSLT3OPT.Visible = false;
                TextBoxRaiseRSLT3OPT.Visible = false;
                PanelRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT2.Visible = true;
                PanelRaiseRSLT3OPT3.Visible = true;
                LabelRespondRSLT3OPT.Visible = false;
            }
            else
            {
                RAISERSLT3OPT.Visible = true;
                RAISERSLT3OPT.ShowPopupWindow();
                QueryRaiseRSLT3OPT.Visible = false;
                TextBoxRaiseRSLT3OPT.Visible = false;
                PanelRaiseRSLT3OPT.Visible = true;
                PanelRaiseRSLT3OPT2.Visible = true;
                PanelRaiseRSLT3OPT3.Visible = true;
                LabelRespondRSLT3OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT3OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT3OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT3OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT3OPT = '" + TextBoxRSLT3OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT3OPTMSG.ShowPopupWindow();
        RAISERSLT3OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT4OPT
    private void SetImageQueryRSLT4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT4OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT4OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT4OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT2.Visible = false;
                PanelRaiseRSLT4OPT3.Visible = false;
                PanelHideRSLT4OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT2.Visible = true;
                PanelRaiseRSLT4OPT3.Visible = true;
                PanelHideRSLT4OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT2.Visible = true;
                PanelRaiseRSLT4OPT3.Visible = false;
                PanelHideRSLT4OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT4OPT = '" + TextBoxRSLT4OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT4OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT4OPT.Visible = true;
                RAISERSLT4OPT.ShowPopupWindow();
                QueryRaiseRSLT4OPT.Visible = false;
                TextBoxRaiseRSLT4OPT.Visible = false;
                PanelRaiseRSLT4OPT.Visible = false;
                PanelRaiseRSLT4OPT2.Visible = false;
                PanelRaiseRSLT4OPT3.Visible = false;

                LabelRespondRSLT4OPT.Visible = false;
            }

            else if ((ImageQueryRSLT4OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT4OPT.Visible = true;
                RAISERSLT4OPT.ShowPopupWindow();
                QueryRaiseRSLT4OPT.Visible = true;
                TextBoxRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT2.Visible = false;
                PanelRaiseRSLT4OPT3.Visible = false;
                LabelRespondRSLT4OPT.Visible = true;
            }

            else if ((ImageQueryRSLT4OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT4OPT.Visible = true;
                RAISERSLT4OPT.ShowPopupWindow();
                QueryRaiseRSLT4OPT.Visible = false;
                TextBoxRaiseRSLT4OPT.Visible = false;
                PanelRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT2.Visible = true;
                PanelRaiseRSLT4OPT3.Visible = false;
                LabelRespondRSLT4OPT.Visible = false;
            }
            else if ((ImageQueryRSLT4OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT4OPT.Visible = true;
                RAISERSLT4OPT.ShowPopupWindow();
                QueryRaiseRSLT4OPT.Visible = false;
                TextBoxRaiseRSLT4OPT.Visible = false;
                PanelRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT2.Visible = true;
                PanelRaiseRSLT4OPT3.Visible = true;
                LabelRespondRSLT4OPT.Visible = false;
            }
            else
            {
                RAISERSLT4OPT.Visible = true;
                RAISERSLT4OPT.ShowPopupWindow();
                QueryRaiseRSLT4OPT.Visible = false;
                TextBoxRaiseRSLT4OPT.Visible = false;
                PanelRaiseRSLT4OPT.Visible = true;
                PanelRaiseRSLT4OPT2.Visible = true;
                PanelRaiseRSLT4OPT3.Visible = true;
                LabelRespondRSLT4OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT4OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT4OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT4OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT4OPT = '" + TextBoxRSLT4OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT4OPTMSG.ShowPopupWindow();
        RAISERSLT4OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT5OPT
    private void SetImageQueryRSLT5OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT5OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT5OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT5OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT5OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT2.Visible = false;
                PanelRaiseRSLT5OPT3.Visible = false;
                PanelHideRSLT5OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT2.Visible = true;
                PanelRaiseRSLT5OPT3.Visible = true;
                PanelHideRSLT5OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT2.Visible = true;
                PanelRaiseRSLT5OPT3.Visible = false;
                PanelHideRSLT5OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT5OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT5OPT = '" + TextBoxRSLT5OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT5OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT5OPT.Visible = true;
                RAISERSLT5OPT.ShowPopupWindow();
                QueryRaiseRSLT5OPT.Visible = false;
                TextBoxRaiseRSLT5OPT.Visible = false;
                PanelRaiseRSLT5OPT.Visible = false;
                PanelRaiseRSLT5OPT2.Visible = false;
                PanelRaiseRSLT5OPT3.Visible = false;

                LabelRespondRSLT5OPT.Visible = false;
            }

            else if ((ImageQueryRSLT5OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT5OPT.Visible = true;
                RAISERSLT5OPT.ShowPopupWindow();
                QueryRaiseRSLT5OPT.Visible = true;
                TextBoxRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT2.Visible = false;
                PanelRaiseRSLT5OPT3.Visible = false;
                LabelRespondRSLT5OPT.Visible = true;
            }

            else if ((ImageQueryRSLT5OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT5OPT.Visible = true;
                RAISERSLT5OPT.ShowPopupWindow();
                QueryRaiseRSLT5OPT.Visible = false;
                TextBoxRaiseRSLT5OPT.Visible = false;
                PanelRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT2.Visible = true;
                PanelRaiseRSLT5OPT3.Visible = false;
                LabelRespondRSLT5OPT.Visible = false;
            }
            else if ((ImageQueryRSLT5OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT5OPT.Visible = true;
                RAISERSLT5OPT.ShowPopupWindow();
                QueryRaiseRSLT5OPT.Visible = false;
                TextBoxRaiseRSLT5OPT.Visible = false;
                PanelRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT2.Visible = true;
                PanelRaiseRSLT5OPT3.Visible = true;
                LabelRespondRSLT5OPT.Visible = false;
            }
            else
            {
                RAISERSLT5OPT.Visible = true;
                RAISERSLT5OPT.ShowPopupWindow();
                QueryRaiseRSLT5OPT.Visible = false;
                TextBoxRaiseRSLT5OPT.Visible = false;
                PanelRaiseRSLT5OPT.Visible = true;
                PanelRaiseRSLT5OPT2.Visible = true;
                PanelRaiseRSLT5OPT3.Visible = true;
                LabelRespondRSLT5OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT5OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT5OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT5OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT5OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT5OPT = '" + TextBoxRSLT5OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT5OPTMSG.ShowPopupWindow();
        RAISERSLT5OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT6OPT
    private void SetImageQueryRSLT6OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT6OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT6OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT6OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT6OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT2.Visible = false;
                PanelRaiseRSLT6OPT3.Visible = false;
                PanelHideRSLT6OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT2.Visible = true;
                PanelRaiseRSLT6OPT3.Visible = true;
                PanelHideRSLT6OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT2.Visible = true;
                PanelRaiseRSLT6OPT3.Visible = false;
                PanelHideRSLT6OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT6OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT6OPT = '" + TextBoxRSLT6OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT6OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT6OPT.Visible = true;
                RAISERSLT6OPT.ShowPopupWindow();
                QueryRaiseRSLT6OPT.Visible = false;
                TextBoxRaiseRSLT6OPT.Visible = false;
                PanelRaiseRSLT6OPT.Visible = false;
                PanelRaiseRSLT6OPT2.Visible = false;
                PanelRaiseRSLT6OPT3.Visible = false;

                LabelRespondRSLT6OPT.Visible = false;
            }

            else if ((ImageQueryRSLT6OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT6OPT.Visible = true;
                RAISERSLT6OPT.ShowPopupWindow();
                QueryRaiseRSLT6OPT.Visible = true;
                TextBoxRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT2.Visible = false;
                PanelRaiseRSLT6OPT3.Visible = false;
                LabelRespondRSLT6OPT.Visible = true;
            }

            else if ((ImageQueryRSLT6OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT6OPT.Visible = true;
                RAISERSLT6OPT.ShowPopupWindow();
                QueryRaiseRSLT6OPT.Visible = false;
                TextBoxRaiseRSLT6OPT.Visible = false;
                PanelRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT2.Visible = true;
                PanelRaiseRSLT6OPT3.Visible = false;
                LabelRespondRSLT6OPT.Visible = false;
            }
            else if ((ImageQueryRSLT6OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT6OPT.Visible = true;
                RAISERSLT6OPT.ShowPopupWindow();
                QueryRaiseRSLT6OPT.Visible = false;
                TextBoxRaiseRSLT6OPT.Visible = false;
                PanelRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT2.Visible = true;
                PanelRaiseRSLT6OPT3.Visible = true;
                LabelRespondRSLT6OPT.Visible = false;
            }
            else
            {
                RAISERSLT6OPT.Visible = true;
                RAISERSLT6OPT.ShowPopupWindow();
                QueryRaiseRSLT6OPT.Visible = false;
                TextBoxRaiseRSLT6OPT.Visible = false;
                PanelRaiseRSLT6OPT.Visible = true;
                PanelRaiseRSLT6OPT2.Visible = true;
                PanelRaiseRSLT6OPT3.Visible = true;
                LabelRespondRSLT6OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT6OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT6OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT6OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT6OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT6OPT = '" + TextBoxRSLT6OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT6OPTMSG.ShowPopupWindow();
        RAISERSLT6OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT7OPT
    private void SetImageQueryRSLT7OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT7OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT7OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT7OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT7OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT2.Visible = false;
                PanelRaiseRSLT7OPT3.Visible = false;
                PanelHideRSLT7OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT2.Visible = true;
                PanelRaiseRSLT7OPT3.Visible = true;
                PanelHideRSLT7OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT2.Visible = true;
                PanelRaiseRSLT7OPT3.Visible = false;
                PanelHideRSLT7OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT7OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT7OPT = '" + TextBoxRSLT7OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT7OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT7OPT.Visible = true;
                RAISERSLT7OPT.ShowPopupWindow();
                QueryRaiseRSLT7OPT.Visible = false;
                TextBoxRaiseRSLT7OPT.Visible = false;
                PanelRaiseRSLT7OPT.Visible = false;
                PanelRaiseRSLT7OPT2.Visible = false;
                PanelRaiseRSLT7OPT3.Visible = false;

                LabelRespondRSLT7OPT.Visible = false;
            }

            else if ((ImageQueryRSLT7OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT7OPT.Visible = true;
                RAISERSLT7OPT.ShowPopupWindow();
                QueryRaiseRSLT7OPT.Visible = true;
                TextBoxRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT2.Visible = false;
                PanelRaiseRSLT7OPT3.Visible = false;
                LabelRespondRSLT7OPT.Visible = true;
            }

            else if ((ImageQueryRSLT7OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT7OPT.Visible = true;
                RAISERSLT7OPT.ShowPopupWindow();
                QueryRaiseRSLT7OPT.Visible = false;
                TextBoxRaiseRSLT7OPT.Visible = false;
                PanelRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT2.Visible = true;
                PanelRaiseRSLT7OPT3.Visible = false;
                LabelRespondRSLT7OPT.Visible = false;
            }
            else if ((ImageQueryRSLT7OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT7OPT.Visible = true;
                RAISERSLT7OPT.ShowPopupWindow();
                QueryRaiseRSLT7OPT.Visible = false;
                TextBoxRaiseRSLT7OPT.Visible = false;
                PanelRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT2.Visible = true;
                PanelRaiseRSLT7OPT3.Visible = true;
                LabelRespondRSLT7OPT.Visible = false;
            }
            else
            {
                RAISERSLT7OPT.Visible = true;
                RAISERSLT7OPT.ShowPopupWindow();
                QueryRaiseRSLT7OPT.Visible = false;
                TextBoxRaiseRSLT7OPT.Visible = false;
                PanelRaiseRSLT7OPT.Visible = true;
                PanelRaiseRSLT7OPT2.Visible = true;
                PanelRaiseRSLT7OPT3.Visible = true;
                LabelRespondRSLT7OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT7OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT7OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT7OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT7OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT7OPT = '" + TextBoxRSLT7OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT7OPTMSG.ShowPopupWindow();
        RAISERSLT7OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT8OPT
    private void SetImageQueryRSLT8OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT8OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT8OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT8OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT8OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT2.Visible = false;
                PanelRaiseRSLT8OPT3.Visible = false;
                PanelHideRSLT8OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT2.Visible = true;
                PanelRaiseRSLT8OPT3.Visible = true;
                PanelHideRSLT8OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT2.Visible = true;
                PanelRaiseRSLT8OPT3.Visible = false;
                PanelHideRSLT8OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT8OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT8OPT = '" + TextBoxRSLT8OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT8OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT8OPT.Visible = true;
                RAISERSLT8OPT.ShowPopupWindow();
                QueryRaiseRSLT8OPT.Visible = false;
                TextBoxRaiseRSLT8OPT.Visible = false;
                PanelRaiseRSLT8OPT.Visible = false;
                PanelRaiseRSLT8OPT2.Visible = false;
                PanelRaiseRSLT8OPT3.Visible = false;

                LabelRespondRSLT8OPT.Visible = false;
            }

            else if ((ImageQueryRSLT8OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT8OPT.Visible = true;
                RAISERSLT8OPT.ShowPopupWindow();
                QueryRaiseRSLT8OPT.Visible = true;
                TextBoxRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT2.Visible = false;
                PanelRaiseRSLT8OPT3.Visible = false;
                LabelRespondRSLT8OPT.Visible = true;
            }

            else if ((ImageQueryRSLT8OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT8OPT.Visible = true;
                RAISERSLT8OPT.ShowPopupWindow();
                QueryRaiseRSLT8OPT.Visible = false;
                TextBoxRaiseRSLT8OPT.Visible = false;
                PanelRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT2.Visible = true;
                PanelRaiseRSLT8OPT3.Visible = false;
                LabelRespondRSLT8OPT.Visible = false;
            }
            else if ((ImageQueryRSLT8OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT8OPT.Visible = true;
                RAISERSLT8OPT.ShowPopupWindow();
                QueryRaiseRSLT8OPT.Visible = false;
                TextBoxRaiseRSLT8OPT.Visible = false;
                PanelRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT2.Visible = true;
                PanelRaiseRSLT8OPT3.Visible = true;
                LabelRespondRSLT8OPT.Visible = false;
            }
            else
            {
                RAISERSLT8OPT.Visible = true;
                RAISERSLT8OPT.ShowPopupWindow();
                QueryRaiseRSLT8OPT.Visible = false;
                TextBoxRaiseRSLT8OPT.Visible = false;
                PanelRaiseRSLT8OPT.Visible = true;
                PanelRaiseRSLT8OPT2.Visible = true;
                PanelRaiseRSLT8OPT3.Visible = true;
                LabelRespondRSLT8OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT8OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT8OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT8OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT8OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT8OPT = '" + TextBoxRSLT8OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT8OPTMSG.ShowPopupWindow();
        RAISERSLT8OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT9OPT
    private void SetImageQueryRSLT9OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT9OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT9OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT9OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT9OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT2.Visible = false;
                PanelRaiseRSLT9OPT3.Visible = false;
                PanelHideRSLT9OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT2.Visible = true;
                PanelRaiseRSLT9OPT3.Visible = true;
                PanelHideRSLT9OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT2.Visible = true;
                PanelRaiseRSLT9OPT3.Visible = false;
                PanelHideRSLT9OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT9OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT9OPT = '" + TextBoxRSLT9OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT9OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT9OPT.Visible = true;
                RAISERSLT9OPT.ShowPopupWindow();
                QueryRaiseRSLT9OPT.Visible = false;
                TextBoxRaiseRSLT9OPT.Visible = false;
                PanelRaiseRSLT9OPT.Visible = false;
                PanelRaiseRSLT9OPT2.Visible = false;
                PanelRaiseRSLT9OPT3.Visible = false;

                LabelRespondRSLT9OPT.Visible = false;
            }

            else if ((ImageQueryRSLT9OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT9OPT.Visible = true;
                RAISERSLT9OPT.ShowPopupWindow();
                QueryRaiseRSLT9OPT.Visible = true;
                TextBoxRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT2.Visible = false;
                PanelRaiseRSLT9OPT3.Visible = false;
                LabelRespondRSLT9OPT.Visible = true;
            }

            else if ((ImageQueryRSLT9OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT9OPT.Visible = true;
                RAISERSLT9OPT.ShowPopupWindow();
                QueryRaiseRSLT9OPT.Visible = false;
                TextBoxRaiseRSLT9OPT.Visible = false;
                PanelRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT2.Visible = true;
                PanelRaiseRSLT9OPT3.Visible = false;
                LabelRespondRSLT9OPT.Visible = false;
            }
            else if ((ImageQueryRSLT9OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT9OPT.Visible = true;
                RAISERSLT9OPT.ShowPopupWindow();
                QueryRaiseRSLT9OPT.Visible = false;
                TextBoxRaiseRSLT9OPT.Visible = false;
                PanelRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT2.Visible = true;
                PanelRaiseRSLT9OPT3.Visible = true;
                LabelRespondRSLT9OPT.Visible = false;
            }
            else
            {
                RAISERSLT9OPT.Visible = true;
                RAISERSLT9OPT.ShowPopupWindow();
                QueryRaiseRSLT9OPT.Visible = false;
                TextBoxRaiseRSLT9OPT.Visible = false;
                PanelRaiseRSLT9OPT.Visible = true;
                PanelRaiseRSLT9OPT2.Visible = true;
                PanelRaiseRSLT9OPT3.Visible = true;
                LabelRespondRSLT9OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT9OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT9OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT9OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT9OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT9OPT = '" + TextBoxRSLT9OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT9OPTMSG.ShowPopupWindow();
        RAISERSLT9OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT10OPT
    private void SetImageQueryRSLT10OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT10OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT10OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT10OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT10OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT2.Visible = false;
                PanelRaiseRSLT10OPT3.Visible = false;
                PanelHideRSLT10OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT2.Visible = true;
                PanelRaiseRSLT10OPT3.Visible = true;
                PanelHideRSLT10OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT2.Visible = true;
                PanelRaiseRSLT10OPT3.Visible = false;
                PanelHideRSLT10OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT10OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT10OPT = '" + TextBoxRSLT10OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT10OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT10OPT.Visible = true;
                RAISERSLT10OPT.ShowPopupWindow();
                QueryRaiseRSLT10OPT.Visible = false;
                TextBoxRaiseRSLT10OPT.Visible = false;
                PanelRaiseRSLT10OPT.Visible = false;
                PanelRaiseRSLT10OPT2.Visible = false;
                PanelRaiseRSLT10OPT3.Visible = false;

                LabelRespondRSLT10OPT.Visible = false;
            }

            else if ((ImageQueryRSLT10OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT10OPT.Visible = true;
                RAISERSLT10OPT.ShowPopupWindow();
                QueryRaiseRSLT10OPT.Visible = true;
                TextBoxRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT2.Visible = false;
                PanelRaiseRSLT10OPT3.Visible = false;
                LabelRespondRSLT10OPT.Visible = true;
            }

            else if ((ImageQueryRSLT10OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT10OPT.Visible = true;
                RAISERSLT10OPT.ShowPopupWindow();
                QueryRaiseRSLT10OPT.Visible = false;
                TextBoxRaiseRSLT10OPT.Visible = false;
                PanelRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT2.Visible = true;
                PanelRaiseRSLT10OPT3.Visible = false;
                LabelRespondRSLT10OPT.Visible = false;
            }
            else if ((ImageQueryRSLT10OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT10OPT.Visible = true;
                RAISERSLT10OPT.ShowPopupWindow();
                QueryRaiseRSLT10OPT.Visible = false;
                TextBoxRaiseRSLT10OPT.Visible = false;
                PanelRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT2.Visible = true;
                PanelRaiseRSLT10OPT3.Visible = true;
                LabelRespondRSLT10OPT.Visible = false;
            }
            else
            {
                RAISERSLT10OPT.Visible = true;
                RAISERSLT10OPT.ShowPopupWindow();
                QueryRaiseRSLT10OPT.Visible = false;
                TextBoxRaiseRSLT10OPT.Visible = false;
                PanelRaiseRSLT10OPT.Visible = true;
                PanelRaiseRSLT10OPT2.Visible = true;
                PanelRaiseRSLT10OPT3.Visible = true;
                LabelRespondRSLT10OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT10OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT10OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT10OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT10OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT10OPT = '" + TextBoxRSLT10OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT10OPTMSG.ShowPopupWindow();
        RAISERSLT10OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT11OPT
    private void SetImageQueryRSLT11OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT11OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT11OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT11OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT11OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT11OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT11OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT2.Visible = false;
                PanelRaiseRSLT11OPT3.Visible = false;
                PanelHideRSLT11OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT11OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT2.Visible = true;
                PanelRaiseRSLT11OPT3.Visible = true;
                PanelHideRSLT11OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT2.Visible = true;
                PanelRaiseRSLT11OPT3.Visible = false;
                PanelHideRSLT11OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT11OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT11OPT = '" + TextBoxRSLT11OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT11OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT11OPT.Visible = true;
                RAISERSLT11OPT.ShowPopupWindow();
                QueryRaiseRSLT11OPT.Visible = false;
                TextBoxRaiseRSLT11OPT.Visible = false;
                PanelRaiseRSLT11OPT.Visible = false;
                PanelRaiseRSLT11OPT2.Visible = false;
                PanelRaiseRSLT11OPT3.Visible = false;

                LabelRespondRSLT11OPT.Visible = false;
            }

            else if ((ImageQueryRSLT11OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT11OPT.Visible = true;
                RAISERSLT11OPT.ShowPopupWindow();
                QueryRaiseRSLT11OPT.Visible = true;
                TextBoxRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT2.Visible = false;
                PanelRaiseRSLT11OPT3.Visible = false;
                LabelRespondRSLT11OPT.Visible = true;
            }

            else if ((ImageQueryRSLT11OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT11OPT.Visible = true;
                RAISERSLT11OPT.ShowPopupWindow();
                QueryRaiseRSLT11OPT.Visible = false;
                TextBoxRaiseRSLT11OPT.Visible = false;
                PanelRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT2.Visible = true;
                PanelRaiseRSLT11OPT3.Visible = false;
                LabelRespondRSLT11OPT.Visible = false;
            }
            else if ((ImageQueryRSLT11OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT11OPT.Visible = true;
                RAISERSLT11OPT.ShowPopupWindow();
                QueryRaiseRSLT11OPT.Visible = false;
                TextBoxRaiseRSLT11OPT.Visible = false;
                PanelRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT2.Visible = true;
                PanelRaiseRSLT11OPT3.Visible = true;
                LabelRespondRSLT11OPT.Visible = false;
            }
            else
            {
                RAISERSLT11OPT.Visible = true;
                RAISERSLT11OPT.ShowPopupWindow();
                QueryRaiseRSLT11OPT.Visible = false;
                TextBoxRaiseRSLT11OPT.Visible = false;
                PanelRaiseRSLT11OPT.Visible = true;
                PanelRaiseRSLT11OPT2.Visible = true;
                PanelRaiseRSLT11OPT3.Visible = true;
                LabelRespondRSLT11OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT11OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT11OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT11OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT11OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT11OPT = '" + TextBoxRSLT11OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT11OPTMSG.ShowPopupWindow();
        RAISERSLT11OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT12OPT
    private void SetImageQueryRSLT12OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT12OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT12OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT12OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT12OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT12OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT12OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT2.Visible = false;
                PanelRaiseRSLT12OPT3.Visible = false;
                PanelHideRSLT12OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT12OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT2.Visible = true;
                PanelRaiseRSLT12OPT3.Visible = true;
                PanelHideRSLT12OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT2.Visible = true;
                PanelRaiseRSLT12OPT3.Visible = false;
                PanelHideRSLT12OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT12OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT12OPT = '" + TextBoxRSLT12OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT12OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT12OPT.Visible = true;
                RAISERSLT12OPT.ShowPopupWindow();
                QueryRaiseRSLT12OPT.Visible = false;
                TextBoxRaiseRSLT12OPT.Visible = false;
                PanelRaiseRSLT12OPT.Visible = false;
                PanelRaiseRSLT12OPT2.Visible = false;
                PanelRaiseRSLT12OPT3.Visible = false;

                LabelRespondRSLT12OPT.Visible = false;
            }

            else if ((ImageQueryRSLT12OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT12OPT.Visible = true;
                RAISERSLT12OPT.ShowPopupWindow();
                QueryRaiseRSLT12OPT.Visible = true;
                TextBoxRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT2.Visible = false;
                PanelRaiseRSLT12OPT3.Visible = false;
                LabelRespondRSLT12OPT.Visible = true;
            }

            else if ((ImageQueryRSLT12OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT12OPT.Visible = true;
                RAISERSLT12OPT.ShowPopupWindow();
                QueryRaiseRSLT12OPT.Visible = false;
                TextBoxRaiseRSLT12OPT.Visible = false;
                PanelRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT2.Visible = true;
                PanelRaiseRSLT12OPT3.Visible = false;
                LabelRespondRSLT12OPT.Visible = false;
            }
            else if ((ImageQueryRSLT12OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT12OPT.Visible = true;
                RAISERSLT12OPT.ShowPopupWindow();
                QueryRaiseRSLT12OPT.Visible = false;
                TextBoxRaiseRSLT12OPT.Visible = false;
                PanelRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT2.Visible = true;
                PanelRaiseRSLT12OPT3.Visible = true;
                LabelRespondRSLT12OPT.Visible = false;
            }
            else
            {
                RAISERSLT12OPT.Visible = true;
                RAISERSLT12OPT.ShowPopupWindow();
                QueryRaiseRSLT12OPT.Visible = false;
                TextBoxRaiseRSLT12OPT.Visible = false;
                PanelRaiseRSLT12OPT.Visible = true;
                PanelRaiseRSLT12OPT2.Visible = true;
                PanelRaiseRSLT12OPT3.Visible = true;
                LabelRespondRSLT12OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT12OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT12OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT12OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT12OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT12OPT = '" + TextBoxRSLT12OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT12OPTMSG.ShowPopupWindow();
        RAISERSLT12OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT13OPT
    private void SetImageQueryRSLT13OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT13OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT13OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT13OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT13OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT13OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT13OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT2.Visible = false;
                PanelRaiseRSLT13OPT3.Visible = false;
                PanelHideRSLT13OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT13OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT2.Visible = true;
                PanelRaiseRSLT13OPT3.Visible = true;
                PanelHideRSLT13OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT2.Visible = true;
                PanelRaiseRSLT13OPT3.Visible = false;
                PanelHideRSLT13OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT13OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabCompleteBloodCount] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT13OPT = '" + TextBoxRSLT13OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT13OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT13OPT.Visible = true;
                RAISERSLT13OPT.ShowPopupWindow();
                QueryRaiseRSLT13OPT.Visible = false;
                TextBoxRaiseRSLT13OPT.Visible = false;
                PanelRaiseRSLT13OPT.Visible = false;
                PanelRaiseRSLT13OPT2.Visible = false;
                PanelRaiseRSLT13OPT3.Visible = false;

                LabelRespondRSLT13OPT.Visible = false;
            }

            else if ((ImageQueryRSLT13OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT13OPT.Visible = true;
                RAISERSLT13OPT.ShowPopupWindow();
                QueryRaiseRSLT13OPT.Visible = true;
                TextBoxRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT2.Visible = false;
                PanelRaiseRSLT13OPT3.Visible = false;
                LabelRespondRSLT13OPT.Visible = true;
            }

            else if ((ImageQueryRSLT13OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT13OPT.Visible = true;
                RAISERSLT13OPT.ShowPopupWindow();
                QueryRaiseRSLT13OPT.Visible = false;
                TextBoxRaiseRSLT13OPT.Visible = false;
                PanelRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT2.Visible = true;
                PanelRaiseRSLT13OPT3.Visible = false;
                LabelRespondRSLT13OPT.Visible = false;
            }
            else if ((ImageQueryRSLT13OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT13OPT.Visible = true;
                RAISERSLT13OPT.ShowPopupWindow();
                QueryRaiseRSLT13OPT.Visible = false;
                TextBoxRaiseRSLT13OPT.Visible = false;
                PanelRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT2.Visible = true;
                PanelRaiseRSLT13OPT3.Visible = true;
                LabelRespondRSLT13OPT.Visible = false;
            }
            else
            {
                RAISERSLT13OPT.Visible = true;
                RAISERSLT13OPT.ShowPopupWindow();
                QueryRaiseRSLT13OPT.Visible = false;
                TextBoxRaiseRSLT13OPT.Visible = false;
                PanelRaiseRSLT13OPT.Visible = true;
                PanelRaiseRSLT13OPT2.Visible = true;
                PanelRaiseRSLT13OPT3.Visible = true;
                LabelRespondRSLT13OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT13OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT13OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT13OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT13OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabCompleteBloodCount] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT13OPT = '" + TextBoxRSLT13OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT13OPTMSG.ShowPopupWindow();
        RAISERSLT13OPT.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListLABASS.SelectedValue == "Yes")
        {
            hideCBC.Visible = true;
        }
        else
        {
            hideCBC.Visible = false;
        }

        if (RadioButtonListNAB1OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN1OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN1OPT.Visible = false;
        }

        if (RadioButtonListNAB2OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN2OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN2OPT.Visible = false;
        }

        if (RadioButtonListNAB3OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN3OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN3OPT.Visible = false;
        }

        if (RadioButtonListNAB4OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN4OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN4OPT.Visible = false;
        }

        if (RadioButtonListNAB5OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN5OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN5OPT.Visible = false;
        }

        if (RadioButtonListNAB6OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN6OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN6OPT.Visible = false;
        }

        if (RadioButtonListNAB7OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN7OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN7OPT.Visible = false;
        }

        if (RadioButtonListNAB8OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN8OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN8OPT.Visible = false;
        }

        if (RadioButtonListNAB9OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN9OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN9OPT.Visible = false;
        }

        if (RadioButtonListNAB10OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN10OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN10OPT.Visible = false;
        }

        if (RadioButtonListNAB11OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN11OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN11OPT.Visible = false;
        }

        if (RadioButtonListNAB12OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN12OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN12OPT.Visible = false;
        }

        if (RadioButtonListNAB13OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN13OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN13OPT.Visible = false;
        }


    }

    protected void RadioButtonListNAB1OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB1OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN1OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN1OPT.Visible = false;
            RadioButtonListABN1OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB2OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB2OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN2OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN2OPT.Visible = false;
            RadioButtonListABN2OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB3OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB3OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN3OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN3OPT.Visible = false;
            RadioButtonListABN3OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB4OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB4OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN4OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN4OPT.Visible = false;
            RadioButtonListABN4OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB5OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB5OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN5OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN5OPT.Visible = false;
            RadioButtonListABN5OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB6OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB6OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN6OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN6OPT.Visible = false;
            RadioButtonListABN6OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB7OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB7OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN7OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN7OPT.Visible = false;
            RadioButtonListABN7OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB8OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB8OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN8OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN8OPT.Visible = false;
            RadioButtonListABN8OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB9OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB9OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN9OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN9OPT.Visible = false;
            RadioButtonListABN9OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB10OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB10OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN10OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN10OPT.Visible = false;
            RadioButtonListABN10OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB11OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB11OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN11OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN11OPT.Visible = false;
            RadioButtonListABN11OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB12OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB12OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN12OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN12OPT.Visible = false;
            RadioButtonListABN12OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB13OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB13OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN13OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN13OPT.Visible = false;
            RadioButtonListABN13OPT.ClearSelection();
        }
    }

    protected void RadioButtonListLABASS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListLABASS.SelectedValue == "Yes")
        {
            hideCBC.Visible = true;
        }
        else
        {
            hideCBC.Visible = false;

            TextBoxRSLT1OPT.Text = string.Empty;
            TextBoxUN1OPT.Text = string.Empty;
            RadioButtonListNAB1OPT.ClearSelection();
            RadioButtonListABN1OPT.ClearSelection();

            TextBoxRSLT2OPT.Text = string.Empty;
            TextBoxUN2OPT.Text = string.Empty;
            RadioButtonListNAB2OPT.ClearSelection();
            RadioButtonListABN2OPT.ClearSelection();

            TextBoxRSLT3OPT.Text = string.Empty;
            TextBoxUN3OPT.Text = string.Empty;
            RadioButtonListNAB3OPT.ClearSelection();
            RadioButtonListABN3OPT.ClearSelection();

            TextBoxRSLT4OPT.Text = string.Empty;
            TextBoxUN4OPT.Text = string.Empty;
            RadioButtonListNAB4OPT.ClearSelection();
            RadioButtonListABN4OPT.ClearSelection();

            TextBoxRSLT5OPT.Text = string.Empty;
            TextBoxUN5OPT.Text = string.Empty;
            RadioButtonListNAB5OPT.ClearSelection();
            RadioButtonListABN5OPT.ClearSelection();

            TextBoxRSLT6OPT.Text = string.Empty;
            TextBoxUN6OPT.Text = string.Empty;
            RadioButtonListNAB6OPT.ClearSelection();
            RadioButtonListABN6OPT.ClearSelection();

            TextBoxRSLT7OPT.Text = string.Empty;
            TextBoxUN7OPT.Text = string.Empty;
            RadioButtonListNAB7OPT.ClearSelection();
            RadioButtonListABN7OPT.ClearSelection();

            TextBoxRSLT8OPT.Text = string.Empty;
            TextBoxUN8OPT.Text = string.Empty;
            RadioButtonListNAB8OPT.ClearSelection();
            RadioButtonListABN8OPT.ClearSelection();

            TextBoxRSLT9OPT.Text = string.Empty;
            TextBoxUN9OPT.Text = string.Empty;
            RadioButtonListNAB9OPT.ClearSelection();
            RadioButtonListABN9OPT.ClearSelection();

            TextBoxRSLT10OPT.Text = string.Empty;
            TextBoxUN10OPT.Text = string.Empty;
            RadioButtonListNAB10OPT.ClearSelection();
            RadioButtonListABN10OPT.ClearSelection();

            TextBoxRSLT11OPT.Text = string.Empty;
            TextBoxUN11OPT.Text = string.Empty;
            RadioButtonListNAB11OPT.ClearSelection();
            RadioButtonListABN11OPT.ClearSelection();

            TextBoxRSLT12OPT.Text = string.Empty;
            TextBoxUN12OPT.Text = string.Empty;
            RadioButtonListNAB12OPT.ClearSelection();
            RadioButtonListABN12OPT.ClearSelection();

            TextBoxRSLT13OPT.Text = string.Empty;
            TextBoxUN13OPT.Text = string.Empty;
            RadioButtonListNAB13OPT.ClearSelection();
            RadioButtonListABN13OPT.ClearSelection();
        }
    }
}