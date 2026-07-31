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

public partial class DataView_Visit2_CompositeOutcomes : System.Web.UI.Page
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

        SetImageQueryDTL1OPT();
        BindQueryDataDTL1OPT();
        SetImageQueryDTL2OPT();
        BindQueryDataDTL2OPT();
        SetImageQueryDTL3OPT();
        BindQueryDataDTL3OPT();
        SetImageQueryDTL4OPT();
        BindQueryDataDTL4OPT();
        SetImageQueryDTL5OPT();
        BindQueryDataDTL5OPT();
        SetImageQueryDTL6OPT();
        BindQueryDataDTL6OPT();
        SetImageQueryCODOC();
        BindQueryDataCODOC();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select STS1OPT ,DAT1OPT ,DTL1OPT ,STS2OPT ,DAT2OPT ,DTL2OPT ,STS3OPT ,DAT3OPT ,DTL3OPT ,STS4OPT ,DAT4OPT ,DTL4OPT ,STS5OPT ,DAT5OPT ,DTL5OPT ,STS6OPT ,DAT6OPT ,DTL6OPT ,CODOC from [Visit2].[CompositeOutcomes] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and [FUVSTNM]='"+ lblVisit .Text+ "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListSTS1OPT.SelectedValue = dt.Rows[0]["STS1OPT"].ToString().Trim();
            TextBoxDAT1OPT.Text = dt.Rows[0]["DAT1OPT"].ToString().Trim();
            TextBoxDTL1OPT.Text = dt.Rows[0]["DTL1OPT"].ToString().Trim();
            RadioButtonListSTS2OPT.SelectedValue = dt.Rows[0]["STS2OPT"].ToString().Trim();
            TextBoxDAT2OPT.Text = dt.Rows[0]["DAT2OPT"].ToString().Trim();
            TextBoxDTL2OPT.Text = dt.Rows[0]["DTL2OPT"].ToString().Trim();
            RadioButtonListSTS3OPT.SelectedValue = dt.Rows[0]["STS3OPT"].ToString().Trim();
            TextBoxDAT3OPT.Text = dt.Rows[0]["DAT3OPT"].ToString().Trim();
            TextBoxDTL3OPT.Text = dt.Rows[0]["DTL3OPT"].ToString().Trim();
            RadioButtonListSTS4OPT.SelectedValue = dt.Rows[0]["STS4OPT"].ToString().Trim();
            TextBoxDAT4OPT.Text = dt.Rows[0]["DAT4OPT"].ToString().Trim();
            TextBoxDTL4OPT.Text = dt.Rows[0]["DTL4OPT"].ToString().Trim();
            RadioButtonListSTS5OPT.SelectedValue = dt.Rows[0]["STS5OPT"].ToString().Trim();
            TextBoxDAT5OPT.Text = dt.Rows[0]["DAT5OPT"].ToString().Trim();
            TextBoxDTL5OPT.Text = dt.Rows[0]["DTL5OPT"].ToString().Trim();
            RadioButtonListSTS6OPT.SelectedValue = dt.Rows[0]["STS6OPT"].ToString().Trim();
            TextBoxDAT6OPT.Text = dt.Rows[0]["DAT6OPT"].ToString().Trim();
            TextBoxDTL6OPT.Text = dt.Rows[0]["DTL6OPT"].ToString().Trim();
            TextBoxCODOC.Text = dt.Rows[0]["CODOC"].ToString().Trim();

        }
        con.Close();

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

    #region Query
    #region QueryDTL1OPT
    private void SetImageQueryDTL1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDTL1OPT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDTL1OPT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDTL1OPT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryDTL1OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDTL1OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDTL1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDTL1OPT.Visible = true;
                PanelRaiseDTL1OPT2.Visible = false;
                PanelRaiseDTL1OPT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDTL1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDTL1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDTL1OPT.Visible = true;
                PanelRaiseDTL1OPT2.Visible = true;
                PanelRaiseDTL1OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDTL1OPT.Visible = true;
                PanelRaiseDTL1OPT2.Visible = true;
                PanelRaiseDTL1OPT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDTL1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[CompositeOutcomes] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL1OPT = '" + TextBoxDTL1OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDTL1OPT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDTL1OPT.Visible = true;
                RAISEDTL1OPT.ShowPopupWindow();
                PanelRaiseDTL1OPT.Visible = false;
                PanelRaiseDTL1OPT2.Visible = false;
                PanelRaiseDTL1OPT3.Visible = false;

            }

            else if ((ImageQueryDTL1OPT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDTL1OPT.Visible = true;
                RAISEDTL1OPT.ShowPopupWindow();
            }

            else if ((ImageQueryDTL1OPT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDTL1OPT.Visible = true;
                RespondedDTL1OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDTL1OPT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDTL1OPT.Visible = true;
                CloseDTL1OPT.ShowPopupWindow();
            }
            else
            {
                LockDTL1OPT.Visible = true;
                LockDTL1OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDTL1OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDTL1OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL1OPT = '" + TextBoxDTL1OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDTL1OPTMSG.ShowPopupWindow();
        RAISEDTL1OPT.Visible = false;
    }

    protected void CloseQueryDTL1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL1OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL1OPT = '" + TextBoxDTL1OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDTL1OPTMSG.ShowPopupWindow();
        RespondedDTL1OPT.Visible = false;
    }

    protected void SubmitReRaiseDTL1OPT_Click(object sender, EventArgs e)
    {
        CloseDTL1OPT.Visible = false;

        RAISEDTL1OPT.Visible = true;
        RAISEDTL1OPT.ShowPopupWindow();
    }
    #endregion
    #region QueryDTL2OPT
    private void SetImageQueryDTL2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDTL2OPT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDTL2OPT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDTL2OPT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryDTL2OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDTL2OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDTL2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDTL2OPT.Visible = true;
                PanelRaiseDTL2OPT2.Visible = false;
                PanelRaiseDTL2OPT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDTL2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDTL2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDTL2OPT.Visible = true;
                PanelRaiseDTL2OPT2.Visible = true;
                PanelRaiseDTL2OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDTL2OPT.Visible = true;
                PanelRaiseDTL2OPT2.Visible = true;
                PanelRaiseDTL2OPT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDTL2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[CompositeOutcomes] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL2OPT = '" + TextBoxDTL2OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDTL2OPT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDTL2OPT.Visible = true;
                RAISEDTL2OPT.ShowPopupWindow();
                PanelRaiseDTL2OPT.Visible = false;
                PanelRaiseDTL2OPT2.Visible = false;
                PanelRaiseDTL2OPT3.Visible = false;

            }

            else if ((ImageQueryDTL2OPT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDTL2OPT.Visible = true;
                RAISEDTL2OPT.ShowPopupWindow();
            }

            else if ((ImageQueryDTL2OPT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDTL2OPT.Visible = true;
                RespondedDTL2OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDTL2OPT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDTL2OPT.Visible = true;
                CloseDTL2OPT.ShowPopupWindow();
            }
            else
            {
                LockDTL2OPT.Visible = true;
                LockDTL2OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDTL2OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDTL2OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL2OPT = '" + TextBoxDTL2OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDTL2OPTMSG.ShowPopupWindow();
        RAISEDTL2OPT.Visible = false;
    }

    protected void CloseQueryDTL2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL2OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL2OPT = '" + TextBoxDTL2OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDTL2OPTMSG.ShowPopupWindow();
        RespondedDTL2OPT.Visible = false;
    }

    protected void SubmitReRaiseDTL2OPT_Click(object sender, EventArgs e)
    {
        CloseDTL2OPT.Visible = false;

        RAISEDTL2OPT.Visible = true;
        RAISEDTL2OPT.ShowPopupWindow();
    }
    #endregion
    #region QueryDTL3OPT
    private void SetImageQueryDTL3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDTL3OPT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDTL3OPT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDTL3OPT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryDTL3OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDTL3OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDTL3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDTL3OPT.Visible = true;
                PanelRaiseDTL3OPT2.Visible = false;
                PanelRaiseDTL3OPT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDTL3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDTL3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDTL3OPT.Visible = true;
                PanelRaiseDTL3OPT2.Visible = true;
                PanelRaiseDTL3OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDTL3OPT.Visible = true;
                PanelRaiseDTL3OPT2.Visible = true;
                PanelRaiseDTL3OPT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDTL3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[CompositeOutcomes] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL3OPT = '" + TextBoxDTL3OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDTL3OPT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDTL3OPT.Visible = true;
                RAISEDTL3OPT.ShowPopupWindow();
                PanelRaiseDTL3OPT.Visible = false;
                PanelRaiseDTL3OPT2.Visible = false;
                PanelRaiseDTL3OPT3.Visible = false;

            }

            else if ((ImageQueryDTL3OPT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDTL3OPT.Visible = true;
                RAISEDTL3OPT.ShowPopupWindow();
            }

            else if ((ImageQueryDTL3OPT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDTL3OPT.Visible = true;
                RespondedDTL3OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDTL3OPT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDTL3OPT.Visible = true;
                CloseDTL3OPT.ShowPopupWindow();
            }
            else
            {
                LockDTL3OPT.Visible = true;
                LockDTL3OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDTL3OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDTL3OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL3OPT = '" + TextBoxDTL3OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDTL3OPTMSG.ShowPopupWindow();
        RAISEDTL3OPT.Visible = false;
    }

    protected void CloseQueryDTL3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL3OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL3OPT = '" + TextBoxDTL3OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDTL3OPTMSG.ShowPopupWindow();
        RespondedDTL3OPT.Visible = false;
    }

    protected void SubmitReRaiseDTL3OPT_Click(object sender, EventArgs e)
    {
        CloseDTL3OPT.Visible = false;

        RAISEDTL3OPT.Visible = true;
        RAISEDTL3OPT.ShowPopupWindow();
    }
    #endregion
    #region QueryDTL4OPT
    private void SetImageQueryDTL4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDTL4OPT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDTL4OPT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDTL4OPT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryDTL4OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDTL4OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDTL4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDTL4OPT.Visible = true;
                PanelRaiseDTL4OPT2.Visible = false;
                PanelRaiseDTL4OPT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDTL4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDTL4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDTL4OPT.Visible = true;
                PanelRaiseDTL4OPT2.Visible = true;
                PanelRaiseDTL4OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDTL4OPT.Visible = true;
                PanelRaiseDTL4OPT2.Visible = true;
                PanelRaiseDTL4OPT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDTL4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[CompositeOutcomes] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL4OPT = '" + TextBoxDTL4OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDTL4OPT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDTL4OPT.Visible = true;
                RAISEDTL4OPT.ShowPopupWindow();
                PanelRaiseDTL4OPT.Visible = false;
                PanelRaiseDTL4OPT2.Visible = false;
                PanelRaiseDTL4OPT3.Visible = false;

            }

            else if ((ImageQueryDTL4OPT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDTL4OPT.Visible = true;
                RAISEDTL4OPT.ShowPopupWindow();
            }

            else if ((ImageQueryDTL4OPT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDTL4OPT.Visible = true;
                RespondedDTL4OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDTL4OPT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDTL4OPT.Visible = true;
                CloseDTL4OPT.ShowPopupWindow();
            }
            else
            {
                LockDTL4OPT.Visible = true;
                LockDTL4OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDTL4OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDTL4OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL4OPT = '" + TextBoxDTL4OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDTL4OPTMSG.ShowPopupWindow();
        RAISEDTL4OPT.Visible = false;
    }

    protected void CloseQueryDTL4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL4OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL4OPT = '" + TextBoxDTL4OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDTL4OPTMSG.ShowPopupWindow();
        RespondedDTL4OPT.Visible = false;
    }

    protected void SubmitReRaiseDTL4OPT_Click(object sender, EventArgs e)
    {
        CloseDTL4OPT.Visible = false;

        RAISEDTL4OPT.Visible = true;
        RAISEDTL4OPT.ShowPopupWindow();
    }
    #endregion
    #region QueryDTL5OPT
    private void SetImageQueryDTL5OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDTL5OPT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDTL5OPT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDTL5OPT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryDTL5OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDTL5OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDTL5OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDTL5OPT.Visible = true;
                PanelRaiseDTL5OPT2.Visible = false;
                PanelRaiseDTL5OPT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDTL5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDTL5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDTL5OPT.Visible = true;
                PanelRaiseDTL5OPT2.Visible = true;
                PanelRaiseDTL5OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDTL5OPT.Visible = true;
                PanelRaiseDTL5OPT2.Visible = true;
                PanelRaiseDTL5OPT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDTL5OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[CompositeOutcomes] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL5OPT = '" + TextBoxDTL5OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDTL5OPT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDTL5OPT.Visible = true;
                RAISEDTL5OPT.ShowPopupWindow();
                PanelRaiseDTL5OPT.Visible = false;
                PanelRaiseDTL5OPT2.Visible = false;
                PanelRaiseDTL5OPT3.Visible = false;

            }

            else if ((ImageQueryDTL5OPT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDTL5OPT.Visible = true;
                RAISEDTL5OPT.ShowPopupWindow();
            }

            else if ((ImageQueryDTL5OPT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDTL5OPT.Visible = true;
                RespondedDTL5OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDTL5OPT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDTL5OPT.Visible = true;
                CloseDTL5OPT.ShowPopupWindow();
            }
            else
            {
                LockDTL5OPT.Visible = true;
                LockDTL5OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDTL5OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDTL5OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL5OPT = '" + TextBoxDTL5OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDTL5OPTMSG.ShowPopupWindow();
        RAISEDTL5OPT.Visible = false;
    }

    protected void CloseQueryDTL5OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL5OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL5OPT = '" + TextBoxDTL5OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDTL5OPTMSG.ShowPopupWindow();
        RespondedDTL5OPT.Visible = false;
    }

    protected void SubmitReRaiseDTL5OPT_Click(object sender, EventArgs e)
    {
        CloseDTL5OPT.Visible = false;

        RAISEDTL5OPT.Visible = true;
        RAISEDTL5OPT.ShowPopupWindow();
    }
    #endregion
    #region QueryDTL6OPT
    private void SetImageQueryDTL6OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryDTL6OPT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryDTL6OPT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryDTL6OPT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryDTL6OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryDTL6OPT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataDTL6OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseDTL6OPT.Visible = true;
                PanelRaiseDTL6OPT2.Visible = false;
                PanelRaiseDTL6OPT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseDTL6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedDTL6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseDTL6OPT.Visible = true;
                PanelRaiseDTL6OPT2.Visible = true;
                PanelRaiseDTL6OPT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockDTL6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockDTL6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseDTL6OPT.Visible = true;
                PanelRaiseDTL6OPT2.Visible = true;
                PanelRaiseDTL6OPT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryDTL6OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[CompositeOutcomes] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL6OPT = '" + TextBoxDTL6OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryDTL6OPT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEDTL6OPT.Visible = true;
                RAISEDTL6OPT.ShowPopupWindow();
                PanelRaiseDTL6OPT.Visible = false;
                PanelRaiseDTL6OPT2.Visible = false;
                PanelRaiseDTL6OPT3.Visible = false;

            }

            else if ((ImageQueryDTL6OPT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEDTL6OPT.Visible = true;
                RAISEDTL6OPT.ShowPopupWindow();
            }

            else if ((ImageQueryDTL6OPT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedDTL6OPT.Visible = true;
                RespondedDTL6OPT.ShowPopupWindow();
            }
            else if ((ImageQueryDTL6OPT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseDTL6OPT.Visible = true;
                CloseDTL6OPT.ShowPopupWindow();
            }
            else
            {
                LockDTL6OPT.Visible = true;
                LockDTL6OPT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseDTL6OPT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblDTL6OPT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL6OPT = '" + TextBoxDTL6OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEDTL6OPTMSG.ShowPopupWindow();
        RAISEDTL6OPT.Visible = false;
    }

    protected void CloseQueryDTL6OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblDTL6OPT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and DTL6OPT = '" + TextBoxDTL6OPT.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEDTL6OPTMSG.ShowPopupWindow();
        RespondedDTL6OPT.Visible = false;
    }

    protected void SubmitReRaiseDTL6OPT_Click(object sender, EventArgs e)
    {
        CloseDTL6OPT.Visible = false;

        RAISEDTL6OPT.Visible = true;
        RAISEDTL6OPT.ShowPopupWindow();
    }
    #endregion
    #region QueryCODOC
    private void SetImageQueryCODOC()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCODOC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryCODOC.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryCODOC.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryCODOC.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryCODOC.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryCODOC.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataCODOC()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCODOC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseCODOC.Visible = true;
                PanelRaiseCODOC2.Visible = false;
                PanelRaiseCODOC3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseCODOC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedCODOC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseCODOC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockCODOC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseCODOC.Visible = true;
                PanelRaiseCODOC2.Visible = true;
                PanelRaiseCODOC3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockCODOC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockCODOC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseCODOC.Visible = true;
                PanelRaiseCODOC2.Visible = true;
                PanelRaiseCODOC3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryCODOC_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit2].[CompositeOutcomes] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CODOC = '" + TextBoxCODOC.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryCODOC.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISECODOC.Visible = true;
                RAISECODOC.ShowPopupWindow();
                PanelRaiseCODOC.Visible = false;
                PanelRaiseCODOC2.Visible = false;
                PanelRaiseCODOC3.Visible = false;

            }

            else if ((ImageQueryCODOC.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISECODOC.Visible = true;
                RAISECODOC.ShowPopupWindow();
            }

            else if ((ImageQueryCODOC.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedCODOC.Visible = true;
                RespondedCODOC.ShowPopupWindow();
            }
            else if ((ImageQueryCODOC.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseCODOC.Visible = true;
                CloseCODOC.ShowPopupWindow();
            }
            else
            {
                LockCODOC.Visible = true;
                LockCODOC.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseCODOC_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblCODOC.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CODOC = '" + TextBoxCODOC.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISECODOCMSG.ShowPopupWindow();
        RAISECODOC.Visible = false;
    }

    protected void CloseQueryCODOC_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblCODOC.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit2].[CompositeOutcomes] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and CODOC = '" + TextBoxCODOC.Text + "' and [FUVSTNM]='" + lblVisit.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSECODOCMSG.ShowPopupWindow();
        RespondedCODOC.Visible = false;
    }

    protected void SubmitReRaiseCODOC_Click(object sender, EventArgs e)
    {
        CloseCODOC.Visible = false;

        RAISECODOC.Visible = true;
        RAISECODOC.ShowPopupWindow();
    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DataView/DataViewActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }
}