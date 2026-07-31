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

public partial class DataView_Visit1_MedicationHistory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd;
    DataTable dt = new DataTable();
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    SqlCommand cmd1;
    SqlConnection con2 = new SqlConnection
(ConfigurationManager.ConnectionStrings["constr"].ToString());
    SqlCommand cmd2;
    SqlDataAdapter da = new SqlDataAdapter();
    AuditLog objAuditLog = new AuditLog();

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
        SetImageAddNote();
        BindGridviewAddNote();
        SetImageAttach();
        BindGridViewADDAddAttachment();

        SetImageAttachPageHistory();
        BindGridViewADDAttachmentPageHistory();

        SetImageQueryMH1DURA();
        BindQueryDataMH1DURA();
        SetImageQueryMH2DURA();
        BindQueryDataMH2DURA();
        SetImageQueryMH3DURA();
        BindQueryDataMH3DURA();
        SetImageQueryMH4DURA();
        BindQueryDataMH4DURA();
        SetImageQueryMH5DURA();
        BindQueryDataMH5DURA();
        SetImageQueryMH6DURA();
        BindQueryDataMH6DURA();
        SetImageQueryMH7DURA();
        BindQueryDataMH7DURA();
        SetImageQueryMH8DURA();
        BindQueryDataMH8DURA();
        SetImageQueryMH9DURA();
        BindQueryDataMH9DURA();
        SetImageQueryMH10DURA();
        BindQueryDataMH10DURA();
    }
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
            ImgAddNote.ImageUrl = "~/DataView/Images/NoteADD.png";
        }
        else
        {
            ImgAddNote.ImageUrl = "~/DataView/Images/BlankNote.png";

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
            ImgAddAttachment.ImageUrl = "~/DataView/Images/AttachmentADD.png";
        }
        else
        {
            ImgAddAttachment.ImageUrl = "~/DataView/Images/BlankAttachment.png";

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
        con.Close();
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
            AttachmentPageHistory.ImageUrl = "~/DataView/Images/PageHistory.png";
        }
        else
        {
            AttachmentPageHistory.ImageUrl = "~/DataView/Images/PHistory.png";

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

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT MH1OPT ,MH1NAME ,MH1DOSE ,MH1FRQ ,MH1DURA ,MH2OPT ,MH2NAME ,MH2DOSE ,MH2FRQ ,MH2DURA ,MH3OPT ,MH3NAME ,MH3DOSE ,MH3FRQ ,MH3DURA ,MH4OPT ,MH4NAME ,MH4DOSE ,MH4FRQ ,MH4DURA ,MH5OPT ,MH5NAME ,MH5DOSE ,MH5FRQ ,MH5DURA ,MH6DRUG ,MH6NAME ,MH6DOSE ,MH6FRQ ,MH6DURA ,MH7DRUG ,MH7NAME ,MH7DOSE ,MH7FRQ ,MH7DURA ,MH8DRUG ,MH8NAME ,MH8DOSE ,MH8FRQ ,MH8DURA ,MH9DRUG ,MH9NAME ,MH9DOSE ,MH9FRQ ,MH9DURA ,MH10DRUG ,MH10NAME ,MH10DOSE ,MH10FRQ ,MH10DURA FROM [Visit1].[MedicalHistory] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListMH1OPT.SelectedValue = dt.Rows[0]["MH1OPT"].ToString();
            TextBoxMH1NAME.Text = dt.Rows[0]["MH1NAME"].ToString();
            TextBoxMH1DOSE.Text = dt.Rows[0]["MH1DOSE"].ToString();
            TextBoxMH1FRQ.Text = dt.Rows[0]["MH1FRQ"].ToString();
            TextBoxMH1DURA.Text = dt.Rows[0]["MH1DURA"].ToString();
            RadioButtonListMH2OPT.SelectedValue = dt.Rows[0]["MH2OPT"].ToString();
            TextBoxMH2NAME.Text = dt.Rows[0]["MH2NAME"].ToString();
            TextBoxMH2DOSE.Text = dt.Rows[0]["MH2DOSE"].ToString();
            TextBoxMH2FRQ.Text = dt.Rows[0]["MH2FRQ"].ToString();
            TextBoxMH2DURA.Text = dt.Rows[0]["MH2DURA"].ToString();
            RadioButtonListMH3OPT.SelectedValue = dt.Rows[0]["MH3OPT"].ToString();
            TextBoxMH3NAME.Text = dt.Rows[0]["MH3NAME"].ToString();
            TextBoxMH3DOSE.Text = dt.Rows[0]["MH3DOSE"].ToString();
            TextBoxMH3FRQ.Text = dt.Rows[0]["MH3FRQ"].ToString();
            TextBoxMH3DURA.Text = dt.Rows[0]["MH3DURA"].ToString();
            RadioButtonListMH4OPT.SelectedValue = dt.Rows[0]["MH4OPT"].ToString();
            TextBoxMH4NAME.Text = dt.Rows[0]["MH4NAME"].ToString();
            TextBoxMH4DOSE.Text = dt.Rows[0]["MH4DOSE"].ToString();
            TextBoxMH4FRQ.Text = dt.Rows[0]["MH4FRQ"].ToString();
            TextBoxMH4DURA.Text = dt.Rows[0]["MH4DURA"].ToString();
            RadioButtonListMH5OPT.SelectedValue = dt.Rows[0]["MH5OPT"].ToString();
            TextBoxMH5NAME.Text = dt.Rows[0]["MH5NAME"].ToString();
            TextBoxMH5DOSE.Text = dt.Rows[0]["MH5DOSE"].ToString();
            TextBoxMH5FRQ.Text = dt.Rows[0]["MH5FRQ"].ToString();
            TextBoxMH5DURA.Text = dt.Rows[0]["MH5DURA"].ToString();
            TextBoxMH6DRUG.Text = dt.Rows[0]["MH6DRUG"].ToString();
            TextBoxMH6NAME.Text = dt.Rows[0]["MH6NAME"].ToString();
            TextBoxMH6DOSE.Text = dt.Rows[0]["MH6DOSE"].ToString();
            TextBoxMH6FRQ.Text = dt.Rows[0]["MH6FRQ"].ToString();
            TextBoxMH6DURA.Text = dt.Rows[0]["MH6DURA"].ToString();
            TextBoxMH7DRUG.Text = dt.Rows[0]["MH7DRUG"].ToString();
            TextBoxMH7NAME.Text = dt.Rows[0]["MH7NAME"].ToString();
            TextBoxMH7DOSE.Text = dt.Rows[0]["MH7DOSE"].ToString();
            TextBoxMH7FRQ.Text = dt.Rows[0]["MH7FRQ"].ToString();
            TextBoxMH7DURA.Text = dt.Rows[0]["MH7DURA"].ToString();
            TextBoxMH8DRUG.Text = dt.Rows[0]["MH8DRUG"].ToString();
            TextBoxMH8NAME.Text = dt.Rows[0]["MH8NAME"].ToString();
            TextBoxMH8DOSE.Text = dt.Rows[0]["MH8DOSE"].ToString();
            TextBoxMH8FRQ.Text = dt.Rows[0]["MH8FRQ"].ToString();
            TextBoxMH8DURA.Text = dt.Rows[0]["MH8DURA"].ToString();
            TextBoxMH9DRUG.Text = dt.Rows[0]["MH9DRUG"].ToString();
            TextBoxMH9NAME.Text = dt.Rows[0]["MH9NAME"].ToString();
            TextBoxMH9DOSE.Text = dt.Rows[0]["MH9DOSE"].ToString();
            TextBoxMH9FRQ.Text = dt.Rows[0]["MH9FRQ"].ToString();
            TextBoxMH9DURA.Text = dt.Rows[0]["MH9DURA"].ToString();
            TextBoxMH10DRUG.Text = dt.Rows[0]["MH10DRUG"].ToString();
            TextBoxMH10NAME.Text = dt.Rows[0]["MH10NAME"].ToString();
            TextBoxMH10DOSE.Text = dt.Rows[0]["MH10DOSE"].ToString();
            TextBoxMH10FRQ.Text = dt.Rows[0]["MH10FRQ"].ToString();
            TextBoxMH10DURA.Text = dt.Rows[0]["MH10DURA"].ToString();

        }
        con.Close();

    }
    #endregion

    #region Query
    #region QueryMH1DURA
    private void SetImageQueryMH1DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH1DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH1DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH1DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH1DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH1DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH1DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH1DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH1DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH1DURA.Visible = true;
                PanelRaiseMH1DURA2.Visible = false;
                PanelRaiseMH1DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH1DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH1DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH1DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH1DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH1DURA.Visible = true;
                PanelRaiseMH1DURA2.Visible = true;
                PanelRaiseMH1DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH1DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH1DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH1DURA.Visible = true;
                PanelRaiseMH1DURA2.Visible = true;
                PanelRaiseMH1DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH1DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH1DURA = '" + TextBoxMH1DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH1DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH1DURA.Visible = true;
                RAISEMH1DURA.ShowPopupWindow();
                PanelRaiseMH1DURA.Visible = false;
                PanelRaiseMH1DURA2.Visible = false;
                PanelRaiseMH1DURA3.Visible = false;

            }

            else if ((ImageQueryMH1DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH1DURA.Visible = true;
                RAISEMH1DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH1DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH1DURA.Visible = true;
                RespondedMH1DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH1DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH1DURA.Visible = true;
                CloseMH1DURA.ShowPopupWindow();
            }
            else
            {
                LockMH1DURA.Visible = true;
                LockMH1DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH1DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH1DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH1DURA = '" + TextBoxMH1DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH1DURAMSG.ShowPopupWindow();
        RAISEMH1DURA.Visible = false;
    }

    protected void CloseQueryMH1DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH1DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH1DURA = '" + TextBoxMH1DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH1DURAMSG.ShowPopupWindow();
        RespondedMH1DURA.Visible = false;
    }

    protected void SubmitReRaiseMH1DURA_Click(object sender, EventArgs e)
    {
        CloseMH1DURA.Visible = false;

        RAISEMH1DURA.Visible = true;
        RAISEMH1DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH2DURA
    private void SetImageQueryMH2DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH2DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH2DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH2DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH2DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH2DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH2DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH2DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH2DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH2DURA.Visible = true;
                PanelRaiseMH2DURA2.Visible = false;
                PanelRaiseMH2DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH2DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH2DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH2DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH2DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH2DURA.Visible = true;
                PanelRaiseMH2DURA2.Visible = true;
                PanelRaiseMH2DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH2DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH2DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH2DURA.Visible = true;
                PanelRaiseMH2DURA2.Visible = true;
                PanelRaiseMH2DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH2DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH2DURA = '" + TextBoxMH2DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH2DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH2DURA.Visible = true;
                RAISEMH2DURA.ShowPopupWindow();
                PanelRaiseMH2DURA.Visible = false;
                PanelRaiseMH2DURA2.Visible = false;
                PanelRaiseMH2DURA3.Visible = false;

            }

            else if ((ImageQueryMH2DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH2DURA.Visible = true;
                RAISEMH2DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH2DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH2DURA.Visible = true;
                RespondedMH2DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH2DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH2DURA.Visible = true;
                CloseMH2DURA.ShowPopupWindow();
            }
            else
            {
                LockMH2DURA.Visible = true;
                LockMH2DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH2DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH2DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH2DURA = '" + TextBoxMH2DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH2DURAMSG.ShowPopupWindow();
        RAISEMH2DURA.Visible = false;
    }

    protected void CloseQueryMH2DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH2DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH2DURA = '" + TextBoxMH2DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH2DURAMSG.ShowPopupWindow();
        RespondedMH2DURA.Visible = false;
    }

    protected void SubmitReRaiseMH2DURA_Click(object sender, EventArgs e)
    {
        CloseMH2DURA.Visible = false;

        RAISEMH2DURA.Visible = true;
        RAISEMH2DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH3DURA
    private void SetImageQueryMH3DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH3DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH3DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH3DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH3DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH3DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH3DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH3DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH3DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH3DURA.Visible = true;
                PanelRaiseMH3DURA2.Visible = false;
                PanelRaiseMH3DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH3DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH3DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH3DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH3DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH3DURA.Visible = true;
                PanelRaiseMH3DURA2.Visible = true;
                PanelRaiseMH3DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH3DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH3DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH3DURA.Visible = true;
                PanelRaiseMH3DURA2.Visible = true;
                PanelRaiseMH3DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH3DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH3DURA = '" + TextBoxMH3DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH3DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH3DURA.Visible = true;
                RAISEMH3DURA.ShowPopupWindow();
                PanelRaiseMH3DURA.Visible = false;
                PanelRaiseMH3DURA2.Visible = false;
                PanelRaiseMH3DURA3.Visible = false;

            }

            else if ((ImageQueryMH3DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH3DURA.Visible = true;
                RAISEMH3DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH3DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH3DURA.Visible = true;
                RespondedMH3DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH3DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH3DURA.Visible = true;
                CloseMH3DURA.ShowPopupWindow();
            }
            else
            {
                LockMH3DURA.Visible = true;
                LockMH3DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH3DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH3DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH3DURA = '" + TextBoxMH3DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH3DURAMSG.ShowPopupWindow();
        RAISEMH3DURA.Visible = false;
    }

    protected void CloseQueryMH3DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH3DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH3DURA = '" + TextBoxMH3DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH3DURAMSG.ShowPopupWindow();
        RespondedMH3DURA.Visible = false;
    }

    protected void SubmitReRaiseMH3DURA_Click(object sender, EventArgs e)
    {
        CloseMH3DURA.Visible = false;

        RAISEMH3DURA.Visible = true;
        RAISEMH3DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH4DURA
    private void SetImageQueryMH4DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH4DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH4DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH4DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH4DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH4DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH4DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH4DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH4DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH4DURA.Visible = true;
                PanelRaiseMH4DURA2.Visible = false;
                PanelRaiseMH4DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH4DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH4DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH4DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH4DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH4DURA.Visible = true;
                PanelRaiseMH4DURA2.Visible = true;
                PanelRaiseMH4DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH4DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH4DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH4DURA.Visible = true;
                PanelRaiseMH4DURA2.Visible = true;
                PanelRaiseMH4DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH4DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH4DURA = '" + TextBoxMH4DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH4DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH4DURA.Visible = true;
                RAISEMH4DURA.ShowPopupWindow();
                PanelRaiseMH4DURA.Visible = false;
                PanelRaiseMH4DURA2.Visible = false;
                PanelRaiseMH4DURA3.Visible = false;

            }

            else if ((ImageQueryMH4DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH4DURA.Visible = true;
                RAISEMH4DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH4DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH4DURA.Visible = true;
                RespondedMH4DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH4DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH4DURA.Visible = true;
                CloseMH4DURA.ShowPopupWindow();
            }
            else
            {
                LockMH4DURA.Visible = true;
                LockMH4DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH4DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH4DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH4DURA = '" + TextBoxMH4DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH4DURAMSG.ShowPopupWindow();
        RAISEMH4DURA.Visible = false;
    }

    protected void CloseQueryMH4DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH4DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH4DURA = '" + TextBoxMH4DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH4DURAMSG.ShowPopupWindow();
        RespondedMH4DURA.Visible = false;
    }

    protected void SubmitReRaiseMH4DURA_Click(object sender, EventArgs e)
    {
        CloseMH4DURA.Visible = false;

        RAISEMH4DURA.Visible = true;
        RAISEMH4DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH5DURA
    private void SetImageQueryMH5DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH5DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH5DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH5DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH5DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH5DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH5DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH5DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH5DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH5DURA.Visible = true;
                PanelRaiseMH5DURA2.Visible = false;
                PanelRaiseMH5DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH5DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH5DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH5DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH5DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH5DURA.Visible = true;
                PanelRaiseMH5DURA2.Visible = true;
                PanelRaiseMH5DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH5DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH5DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH5DURA.Visible = true;
                PanelRaiseMH5DURA2.Visible = true;
                PanelRaiseMH5DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH5DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH5DURA = '" + TextBoxMH5DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH5DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH5DURA.Visible = true;
                RAISEMH5DURA.ShowPopupWindow();
                PanelRaiseMH5DURA.Visible = false;
                PanelRaiseMH5DURA2.Visible = false;
                PanelRaiseMH5DURA3.Visible = false;

            }

            else if ((ImageQueryMH5DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH5DURA.Visible = true;
                RAISEMH5DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH5DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH5DURA.Visible = true;
                RespondedMH5DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH5DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH5DURA.Visible = true;
                CloseMH5DURA.ShowPopupWindow();
            }
            else
            {
                LockMH5DURA.Visible = true;
                LockMH5DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH5DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH5DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH5DURA = '" + TextBoxMH5DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH5DURAMSG.ShowPopupWindow();
        RAISEMH5DURA.Visible = false;
    }

    protected void CloseQueryMH5DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH5DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH5DURA = '" + TextBoxMH5DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH5DURAMSG.ShowPopupWindow();
        RespondedMH5DURA.Visible = false;
    }

    protected void SubmitReRaiseMH5DURA_Click(object sender, EventArgs e)
    {
        CloseMH5DURA.Visible = false;

        RAISEMH5DURA.Visible = true;
        RAISEMH5DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH6DURA
    private void SetImageQueryMH6DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH6DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH6DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH6DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH6DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH6DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH6DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH6DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH6DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH6DURA.Visible = true;
                PanelRaiseMH6DURA2.Visible = false;
                PanelRaiseMH6DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH6DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH6DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH6DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH6DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH6DURA.Visible = true;
                PanelRaiseMH6DURA2.Visible = true;
                PanelRaiseMH6DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH6DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH6DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH6DURA.Visible = true;
                PanelRaiseMH6DURA2.Visible = true;
                PanelRaiseMH6DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH6DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH6DURA = '" + TextBoxMH6DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH6DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH6DURA.Visible = true;
                RAISEMH6DURA.ShowPopupWindow();
                PanelRaiseMH6DURA.Visible = false;
                PanelRaiseMH6DURA2.Visible = false;
                PanelRaiseMH6DURA3.Visible = false;

            }

            else if ((ImageQueryMH6DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH6DURA.Visible = true;
                RAISEMH6DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH6DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH6DURA.Visible = true;
                RespondedMH6DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH6DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH6DURA.Visible = true;
                CloseMH6DURA.ShowPopupWindow();
            }
            else
            {
                LockMH6DURA.Visible = true;
                LockMH6DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH6DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH6DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH6DURA = '" + TextBoxMH6DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH6DURAMSG.ShowPopupWindow();
        RAISEMH6DURA.Visible = false;
    }

    protected void CloseQueryMH6DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH6DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH6DURA = '" + TextBoxMH6DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH6DURAMSG.ShowPopupWindow();
        RespondedMH6DURA.Visible = false;
    }

    protected void SubmitReRaiseMH6DURA_Click(object sender, EventArgs e)
    {
        CloseMH6DURA.Visible = false;

        RAISEMH6DURA.Visible = true;
        RAISEMH6DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH7DURA
    private void SetImageQueryMH7DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH7DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH7DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH7DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH7DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH7DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH7DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH7DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH7DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH7DURA.Visible = true;
                PanelRaiseMH7DURA2.Visible = false;
                PanelRaiseMH7DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH7DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH7DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH7DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH7DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH7DURA.Visible = true;
                PanelRaiseMH7DURA2.Visible = true;
                PanelRaiseMH7DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH7DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH7DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH7DURA.Visible = true;
                PanelRaiseMH7DURA2.Visible = true;
                PanelRaiseMH7DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH7DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH7DURA = '" + TextBoxMH7DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH7DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH7DURA.Visible = true;
                RAISEMH7DURA.ShowPopupWindow();
                PanelRaiseMH7DURA.Visible = false;
                PanelRaiseMH7DURA2.Visible = false;
                PanelRaiseMH7DURA3.Visible = false;

            }

            else if ((ImageQueryMH7DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH7DURA.Visible = true;
                RAISEMH7DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH7DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH7DURA.Visible = true;
                RespondedMH7DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH7DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH7DURA.Visible = true;
                CloseMH7DURA.ShowPopupWindow();
            }
            else
            {
                LockMH7DURA.Visible = true;
                LockMH7DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH7DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH7DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH7DURA = '" + TextBoxMH7DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH7DURAMSG.ShowPopupWindow();
        RAISEMH7DURA.Visible = false;
    }

    protected void CloseQueryMH7DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH7DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH7DURA = '" + TextBoxMH7DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH7DURAMSG.ShowPopupWindow();
        RespondedMH7DURA.Visible = false;
    }

    protected void SubmitReRaiseMH7DURA_Click(object sender, EventArgs e)
    {
        CloseMH7DURA.Visible = false;

        RAISEMH7DURA.Visible = true;
        RAISEMH7DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH8DURA
    private void SetImageQueryMH8DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH8DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH8DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH8DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH8DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH8DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH8DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH8DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH8DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH8DURA.Visible = true;
                PanelRaiseMH8DURA2.Visible = false;
                PanelRaiseMH8DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH8DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH8DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH8DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH8DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH8DURA.Visible = true;
                PanelRaiseMH8DURA2.Visible = true;
                PanelRaiseMH8DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH8DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH8DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH8DURA.Visible = true;
                PanelRaiseMH8DURA2.Visible = true;
                PanelRaiseMH8DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH8DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH8DURA = '" + TextBoxMH8DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH8DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH8DURA.Visible = true;
                RAISEMH8DURA.ShowPopupWindow();
                PanelRaiseMH8DURA.Visible = false;
                PanelRaiseMH8DURA2.Visible = false;
                PanelRaiseMH8DURA3.Visible = false;

            }

            else if ((ImageQueryMH8DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH8DURA.Visible = true;
                RAISEMH8DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH8DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH8DURA.Visible = true;
                RespondedMH8DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH8DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH8DURA.Visible = true;
                CloseMH8DURA.ShowPopupWindow();
            }
            else
            {
                LockMH8DURA.Visible = true;
                LockMH8DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH8DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH8DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH8DURA = '" + TextBoxMH8DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH8DURAMSG.ShowPopupWindow();
        RAISEMH8DURA.Visible = false;
    }

    protected void CloseQueryMH8DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH8DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH8DURA = '" + TextBoxMH8DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH8DURAMSG.ShowPopupWindow();
        RespondedMH8DURA.Visible = false;
    }

    protected void SubmitReRaiseMH8DURA_Click(object sender, EventArgs e)
    {
        CloseMH8DURA.Visible = false;

        RAISEMH8DURA.Visible = true;
        RAISEMH8DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH9DURA
    private void SetImageQueryMH9DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH9DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH9DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH9DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH9DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH9DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH9DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH9DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH9DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH9DURA.Visible = true;
                PanelRaiseMH9DURA2.Visible = false;
                PanelRaiseMH9DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH9DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH9DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH9DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH9DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH9DURA.Visible = true;
                PanelRaiseMH9DURA2.Visible = true;
                PanelRaiseMH9DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH9DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH9DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH9DURA.Visible = true;
                PanelRaiseMH9DURA2.Visible = true;
                PanelRaiseMH9DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH9DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH9DURA = '" + TextBoxMH9DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH9DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH9DURA.Visible = true;
                RAISEMH9DURA.ShowPopupWindow();
                PanelRaiseMH9DURA.Visible = false;
                PanelRaiseMH9DURA2.Visible = false;
                PanelRaiseMH9DURA3.Visible = false;

            }

            else if ((ImageQueryMH9DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH9DURA.Visible = true;
                RAISEMH9DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH9DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH9DURA.Visible = true;
                RespondedMH9DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH9DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH9DURA.Visible = true;
                CloseMH9DURA.ShowPopupWindow();
            }
            else
            {
                LockMH9DURA.Visible = true;
                LockMH9DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH9DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH9DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH9DURA = '" + TextBoxMH9DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH9DURAMSG.ShowPopupWindow();
        RAISEMH9DURA.Visible = false;
    }

    protected void CloseQueryMH9DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH9DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH9DURA = '" + TextBoxMH9DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH9DURAMSG.ShowPopupWindow();
        RespondedMH9DURA.Visible = false;
    }

    protected void SubmitReRaiseMH9DURA_Click(object sender, EventArgs e)
    {
        CloseMH9DURA.Visible = false;

        RAISEMH9DURA.Visible = true;
        RAISEMH9DURA.ShowPopupWindow();
    }
    #endregion
    #region QueryMH10DURA
    private void SetImageQueryMH10DURA()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH10DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryMH10DURA.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMH10DURA.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMH10DURA.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryMH10DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryMH10DURA.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMH10DURA()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH10DURA.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMH10DURA.Visible = true;
                PanelRaiseMH10DURA2.Visible = false;
                PanelRaiseMH10DURA3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMH10DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMH10DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH10DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH10DURA3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMH10DURA.Visible = true;
                PanelRaiseMH10DURA2.Visible = true;
                PanelRaiseMH10DURA3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMH10DURA.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMH10DURA2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMH10DURA.Visible = true;
                PanelRaiseMH10DURA2.Visible = true;
                PanelRaiseMH10DURA3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryMH10DURA_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[MedicalHistory]  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH10DURA = '" + TextBoxMH10DURA.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryMH10DURA.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEMH10DURA.Visible = true;
                RAISEMH10DURA.ShowPopupWindow();
                PanelRaiseMH10DURA.Visible = false;
                PanelRaiseMH10DURA2.Visible = false;
                PanelRaiseMH10DURA3.Visible = false;

            }

            else if ((ImageQueryMH10DURA.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMH10DURA.Visible = true;
                RAISEMH10DURA.ShowPopupWindow();
            }

            else if ((ImageQueryMH10DURA.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMH10DURA.Visible = true;
                RespondedMH10DURA.ShowPopupWindow();
            }
            else if ((ImageQueryMH10DURA.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMH10DURA.Visible = true;
                CloseMH10DURA.ShowPopupWindow();
            }
            else
            {
                LockMH10DURA.Visible = true;
                LockMH10DURA.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseMH10DURA_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMH10DURA.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH10DURA = '" + TextBoxMH10DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMH10DURAMSG.ShowPopupWindow();
        RAISEMH10DURA.Visible = false;
    }

    protected void CloseQueryMH10DURA_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMH10DURA.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[MedicalHistory]  set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MH10DURA = '" + TextBoxMH10DURA.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMH10DURAMSG.ShowPopupWindow();
        RespondedMH10DURA.Visible = false;
    }

    protected void SubmitReRaiseMH10DURA_Click(object sender, EventArgs e)
    {
        CloseMH10DURA.Visible = false;

        RAISEMH10DURA.Visible = true;
        RAISEMH10DURA.ShowPopupWindow();
    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DataView/DataViewActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

}