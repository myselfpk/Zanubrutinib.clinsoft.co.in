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

public partial class DataView_Visit1_LaboratoryInvertigations : System.Web.UI.Page
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

        SetImageQueryLAB1RSLT();
        BindQueryDataLAB1RSLT();
        SetImageQueryLAB2RSLT();
        BindQueryDataLAB2RSLT();
        SetImageQueryLAB3RSLT();
        BindQueryDataLAB3RSLT();
        SetImageQueryLAB4RSLT();
        BindQueryDataLAB4RSLT();
        SetImageQueryLAB5RSLT();
        BindQueryDataLAB5RSLT();
        SetImageQueryLAB6RSLT();
        BindQueryDataLAB6RSLT();
        SetImageQueryLAB7RSLT();
        BindQueryDataLAB7RSLT();
        SetImageQueryLAB8RSLT();
        BindQueryDataLAB8RSLT();
        SetImageQueryLAB9RSLT();
        BindQueryDataLAB9RSLT();
        SetImageQueryLAB10RSLT();
        BindQueryDataLAB10RSLT();
        SetImageQueryLAB11RSLT();
        BindQueryDataLAB11RSLT();
        SetImageQueryLAB12RSLT();
        BindQueryDataLAB12RSLT();
        SetImageQueryLAB13RSLT();
        BindQueryDataLAB13RSLT();
        SetImageQueryLAB14RSLT();
        BindQueryDataLAB14RSLT();
        SetImageQueryLAB15RSLT();
        BindQueryDataLAB15RSLT();


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
        SqlCommand sqlCmd = new SqlCommand("SELECT  LAB1RSLT ,LAB2RSLT ,LAB3RSLT ,LAB4RSLT ,LAB5RSLT ,LAB6RSLT ,LAB6PN ,LAB7RSLT ,LAB8RSLT ,LAB9RSLT ,LAB10RSLT,LAB11PARA ,LAB11RSLT ,LAB12PARA ,LAB12RSLT ,LAB13PARA ,LAB13RSLT ,LAB14PARA ,LAB14RSLT ,LAB15PARA ,LAB15RSLT FROM [Visit1].[LaboratoryInvertigations] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxLAB1RSLT.Text = dt.Rows[0]["LAB1RSLT"].ToString();
            TextBoxLAB2RSLT.Text = dt.Rows[0]["LAB2RSLT"].ToString();
            TextBoxLAB3RSLT.Text = dt.Rows[0]["LAB3RSLT"].ToString();
            TextBoxLAB4RSLT.Text = dt.Rows[0]["LAB4RSLT"].ToString();
            TextBoxLAB5RSLT.Text = dt.Rows[0]["LAB5RSLT"].ToString();
            TextBoxLAB6RSLT.Text = dt.Rows[0]["LAB6RSLT"].ToString();
            RadioButtonListLAB6PN.SelectedValue = dt.Rows[0]["LAB6PN"].ToString();
            TextBoxLAB7RSLT.Text = dt.Rows[0]["LAB7RSLT"].ToString();
            TextBoxLAB8RSLT.Text = dt.Rows[0]["LAB8RSLT"].ToString();
            TextBoxLAB9RSLT.Text = dt.Rows[0]["LAB9RSLT"].ToString();
            TextBoxLAB10RSLT.Text = dt.Rows[0]["LAB10RSLT"].ToString();

            TextBoxLAB11PARA.Text = dt.Rows[0]["LAB11PARA"].ToString();
            TextBoxLAB11RSLT.Text = dt.Rows[0]["LAB11RSLT"].ToString();
            TextBoxLAB12PARA.Text = dt.Rows[0]["LAB12PARA"].ToString();
            TextBoxLAB12RSLT.Text = dt.Rows[0]["LAB12RSLT"].ToString();
            TextBoxLAB13PARA.Text = dt.Rows[0]["LAB13PARA"].ToString();
            TextBoxLAB13RSLT.Text = dt.Rows[0]["LAB13RSLT"].ToString();
            TextBoxLAB14PARA.Text = dt.Rows[0]["LAB14PARA"].ToString();
            TextBoxLAB14RSLT.Text = dt.Rows[0]["LAB14RSLT"].ToString();
            TextBoxLAB15PARA.Text = dt.Rows[0]["LAB15PARA"].ToString();
            TextBoxLAB15RSLT.Text = dt.Rows[0]["LAB15RSLT"].ToString();

        }
        con.Close();

    }
    #endregion

    #region Query
    #region QueryLAB1RSLT
    private void SetImageQueryLAB1RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB1RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB1RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB1RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB1RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB1RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB1RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB1RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB1RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB1RSLT.Visible = true;
                PanelRaiseLAB1RSLT2.Visible = false;
                PanelRaiseLAB1RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB1RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB1RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB1RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB1RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB1RSLT.Visible = true;
                PanelRaiseLAB1RSLT2.Visible = true;
                PanelRaiseLAB1RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB1RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB1RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB1RSLT.Visible = true;
                PanelRaiseLAB1RSLT2.Visible = true;
                PanelRaiseLAB1RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB1RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB1RSLT = '" + TextBoxLAB1RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB1RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB1RSLT.Visible = true;
                RAISELAB1RSLT.ShowPopupWindow();
                PanelRaiseLAB1RSLT.Visible = false;
                PanelRaiseLAB1RSLT2.Visible = false;
                PanelRaiseLAB1RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB1RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB1RSLT.Visible = true;
                RAISELAB1RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB1RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB1RSLT.Visible = true;
                RespondedLAB1RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB1RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB1RSLT.Visible = true;
                CloseLAB1RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB1RSLT.Visible = true;
                LockLAB1RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB1RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB1RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB1RSLT = '" + TextBoxLAB1RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB1RSLTMSG.ShowPopupWindow();
        RAISELAB1RSLT.Visible = false;
    }

    protected void CloseQueryLAB1RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB1RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB1RSLT = '" + TextBoxLAB1RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB1RSLTMSG.ShowPopupWindow();
        RespondedLAB1RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB1RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB1RSLT.Visible = false;

        RAISELAB1RSLT.Visible = true;
        RAISELAB1RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB2RSLT
    private void SetImageQueryLAB2RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB2RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB2RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB2RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB2RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB2RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB2RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB2RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB2RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB2RSLT.Visible = true;
                PanelRaiseLAB2RSLT2.Visible = false;
                PanelRaiseLAB2RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB2RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB2RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB2RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB2RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB2RSLT.Visible = true;
                PanelRaiseLAB2RSLT2.Visible = true;
                PanelRaiseLAB2RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB2RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB2RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB2RSLT.Visible = true;
                PanelRaiseLAB2RSLT2.Visible = true;
                PanelRaiseLAB2RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB2RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB2RSLT = '" + TextBoxLAB2RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB2RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB2RSLT.Visible = true;
                RAISELAB2RSLT.ShowPopupWindow();
                PanelRaiseLAB2RSLT.Visible = false;
                PanelRaiseLAB2RSLT2.Visible = false;
                PanelRaiseLAB2RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB2RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB2RSLT.Visible = true;
                RAISELAB2RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB2RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB2RSLT.Visible = true;
                RespondedLAB2RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB2RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB2RSLT.Visible = true;
                CloseLAB2RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB2RSLT.Visible = true;
                LockLAB2RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB2RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB2RSLT.Text + "',''" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB2RSLT = '" + TextBoxLAB2RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB2RSLTMSG.ShowPopupWindow();
        RAISELAB2RSLT.Visible = false;
    }

    protected void CloseQueryLAB2RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB2RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB2RSLT = '" + TextBoxLAB2RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB2RSLTMSG.ShowPopupWindow();
        RespondedLAB2RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB2RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB2RSLT.Visible = false;

        RAISELAB2RSLT.Visible = true;
        RAISELAB2RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB3RSLT
    private void SetImageQueryLAB3RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB3RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB3RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB3RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB3RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB3RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB3RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB3RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB3RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB3RSLT.Visible = true;
                PanelRaiseLAB3RSLT2.Visible = false;
                PanelRaiseLAB3RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB3RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB3RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB3RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB3RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB3RSLT.Visible = true;
                PanelRaiseLAB3RSLT2.Visible = true;
                PanelRaiseLAB3RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB3RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB3RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB3RSLT.Visible = true;
                PanelRaiseLAB3RSLT2.Visible = true;
                PanelRaiseLAB3RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB3RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB3RSLT = '" + TextBoxLAB3RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB3RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB3RSLT.Visible = true;
                RAISELAB3RSLT.ShowPopupWindow();
                PanelRaiseLAB3RSLT.Visible = false;
                PanelRaiseLAB3RSLT2.Visible = false;
                PanelRaiseLAB3RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB3RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB3RSLT.Visible = true;
                RAISELAB3RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB3RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB3RSLT.Visible = true;
                RespondedLAB3RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB3RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB3RSLT.Visible = true;
                CloseLAB3RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB3RSLT.Visible = true;
                LockLAB3RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB3RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB3RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB3RSLT = '" + TextBoxLAB3RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB3RSLTMSG.ShowPopupWindow();
        RAISELAB3RSLT.Visible = false;
    }

    protected void CloseQueryLAB3RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB3RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB3RSLT = '" + TextBoxLAB3RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB3RSLTMSG.ShowPopupWindow();
        RespondedLAB3RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB3RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB3RSLT.Visible = false;

        RAISELAB3RSLT.Visible = true;
        RAISELAB3RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB4RSLT
    private void SetImageQueryLAB4RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB4RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB4RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB4RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB4RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB4RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB4RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB4RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB4RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB4RSLT.Visible = true;
                PanelRaiseLAB4RSLT2.Visible = false;
                PanelRaiseLAB4RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB4RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB4RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB4RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB4RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB4RSLT.Visible = true;
                PanelRaiseLAB4RSLT2.Visible = true;
                PanelRaiseLAB4RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB4RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB4RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB4RSLT.Visible = true;
                PanelRaiseLAB4RSLT2.Visible = true;
                PanelRaiseLAB4RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB4RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB4RSLT = '" + TextBoxLAB4RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB4RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB4RSLT.Visible = true;
                RAISELAB4RSLT.ShowPopupWindow();
                PanelRaiseLAB4RSLT.Visible = false;
                PanelRaiseLAB4RSLT2.Visible = false;
                PanelRaiseLAB4RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB4RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB4RSLT.Visible = true;
                RAISELAB4RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB4RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB4RSLT.Visible = true;
                RespondedLAB4RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB4RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB4RSLT.Visible = true;
                CloseLAB4RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB4RSLT.Visible = true;
                LockLAB4RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB4RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB4RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB4RSLT = '" + TextBoxLAB4RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB4RSLTMSG.ShowPopupWindow();
        RAISELAB4RSLT.Visible = false;
    }

    protected void CloseQueryLAB4RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB4RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB4RSLT = '" + TextBoxLAB4RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB4RSLTMSG.ShowPopupWindow();
        RespondedLAB4RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB4RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB4RSLT.Visible = false;

        RAISELAB4RSLT.Visible = true;
        RAISELAB4RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB5RSLT
    private void SetImageQueryLAB5RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB5RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB5RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB5RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB5RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB5RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB5RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB5RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB5RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB5RSLT.Visible = true;
                PanelRaiseLAB5RSLT2.Visible = false;
                PanelRaiseLAB5RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB5RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB5RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB5RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB5RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB5RSLT.Visible = true;
                PanelRaiseLAB5RSLT2.Visible = true;
                PanelRaiseLAB5RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB5RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB5RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB5RSLT.Visible = true;
                PanelRaiseLAB5RSLT2.Visible = true;
                PanelRaiseLAB5RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB5RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB5RSLT = '" + TextBoxLAB5RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB5RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB5RSLT.Visible = true;
                RAISELAB5RSLT.ShowPopupWindow();
                PanelRaiseLAB5RSLT.Visible = false;
                PanelRaiseLAB5RSLT2.Visible = false;
                PanelRaiseLAB5RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB5RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB5RSLT.Visible = true;
                RAISELAB5RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB5RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB5RSLT.Visible = true;
                RespondedLAB5RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB5RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB5RSLT.Visible = true;
                CloseLAB5RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB5RSLT.Visible = true;
                LockLAB5RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB5RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB5RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB5RSLT = '" + TextBoxLAB5RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB5RSLTMSG.ShowPopupWindow();
        RAISELAB5RSLT.Visible = false;
    }

    protected void CloseQueryLAB5RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB5RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB5RSLT = '" + TextBoxLAB5RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB5RSLTMSG.ShowPopupWindow();
        RespondedLAB5RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB5RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB5RSLT.Visible = false;

        RAISELAB5RSLT.Visible = true;
        RAISELAB5RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB6RSLT
    private void SetImageQueryLAB6RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB6RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB6RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB6RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB6RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB6RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB6RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB6RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB6RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB6RSLT.Visible = true;
                PanelRaiseLAB6RSLT2.Visible = false;
                PanelRaiseLAB6RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB6RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB6RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB6RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB6RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB6RSLT.Visible = true;
                PanelRaiseLAB6RSLT2.Visible = true;
                PanelRaiseLAB6RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB6RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB6RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB6RSLT.Visible = true;
                PanelRaiseLAB6RSLT2.Visible = true;
                PanelRaiseLAB6RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB6RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB6RSLT = '" + TextBoxLAB6RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB6RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB6RSLT.Visible = true;
                RAISELAB6RSLT.ShowPopupWindow();
                PanelRaiseLAB6RSLT.Visible = false;
                PanelRaiseLAB6RSLT2.Visible = false;
                PanelRaiseLAB6RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB6RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB6RSLT.Visible = true;
                RAISELAB6RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB6RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB6RSLT.Visible = true;
                RespondedLAB6RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB6RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB6RSLT.Visible = true;
                CloseLAB6RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB6RSLT.Visible = true;
                LockLAB6RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB6RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB6RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB6RSLT = '" + TextBoxLAB6RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB6RSLTMSG.ShowPopupWindow();
        RAISELAB6RSLT.Visible = false;
    }

    protected void CloseQueryLAB6RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB6RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB6RSLT = '" + TextBoxLAB6RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB6RSLTMSG.ShowPopupWindow();
        RespondedLAB6RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB6RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB6RSLT.Visible = false;

        RAISELAB6RSLT.Visible = true;
        RAISELAB6RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB7RSLT
    private void SetImageQueryLAB7RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB7RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB7RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB7RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB7RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB7RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB7RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB7RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB7RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB7RSLT.Visible = true;
                PanelRaiseLAB7RSLT2.Visible = false;
                PanelRaiseLAB7RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB7RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB7RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB7RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB7RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB7RSLT.Visible = true;
                PanelRaiseLAB7RSLT2.Visible = true;
                PanelRaiseLAB7RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB7RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB7RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB7RSLT.Visible = true;
                PanelRaiseLAB7RSLT2.Visible = true;
                PanelRaiseLAB7RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB7RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB7RSLT = '" + TextBoxLAB7RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB7RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB7RSLT.Visible = true;
                RAISELAB7RSLT.ShowPopupWindow();
                PanelRaiseLAB7RSLT.Visible = false;
                PanelRaiseLAB7RSLT2.Visible = false;
                PanelRaiseLAB7RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB7RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB7RSLT.Visible = true;
                RAISELAB7RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB7RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB7RSLT.Visible = true;
                RespondedLAB7RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB7RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB7RSLT.Visible = true;
                CloseLAB7RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB7RSLT.Visible = true;
                LockLAB7RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB7RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB7RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB7RSLT = '" + TextBoxLAB7RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB7RSLTMSG.ShowPopupWindow();
        RAISELAB7RSLT.Visible = false;
    }

    protected void CloseQueryLAB7RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB7RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB7RSLT = '" + TextBoxLAB7RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB7RSLTMSG.ShowPopupWindow();
        RespondedLAB7RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB7RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB7RSLT.Visible = false;

        RAISELAB7RSLT.Visible = true;
        RAISELAB7RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB8RSLT
    private void SetImageQueryLAB8RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB8RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB8RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB8RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB8RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB8RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB8RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB8RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB8RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB8RSLT.Visible = true;
                PanelRaiseLAB8RSLT2.Visible = false;
                PanelRaiseLAB8RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB8RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB8RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB8RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB8RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB8RSLT.Visible = true;
                PanelRaiseLAB8RSLT2.Visible = true;
                PanelRaiseLAB8RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB8RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB8RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB8RSLT.Visible = true;
                PanelRaiseLAB8RSLT2.Visible = true;
                PanelRaiseLAB8RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB8RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB8RSLT = '" + TextBoxLAB8RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB8RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB8RSLT.Visible = true;
                RAISELAB8RSLT.ShowPopupWindow();
                PanelRaiseLAB8RSLT.Visible = false;
                PanelRaiseLAB8RSLT2.Visible = false;
                PanelRaiseLAB8RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB8RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB8RSLT.Visible = true;
                RAISELAB8RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB8RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB8RSLT.Visible = true;
                RespondedLAB8RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB8RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB8RSLT.Visible = true;
                CloseLAB8RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB8RSLT.Visible = true;
                LockLAB8RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB8RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB8RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB8RSLT = '" + TextBoxLAB8RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB8RSLTMSG.ShowPopupWindow();
        RAISELAB8RSLT.Visible = false;
    }

    protected void CloseQueryLAB8RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB8RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB8RSLT = '" + TextBoxLAB8RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB8RSLTMSG.ShowPopupWindow();
        RespondedLAB8RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB8RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB8RSLT.Visible = false;

        RAISELAB8RSLT.Visible = true;
        RAISELAB8RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB9RSLT
    private void SetImageQueryLAB9RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB9RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB9RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB9RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB9RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB9RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB9RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB9RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB9RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB9RSLT.Visible = true;
                PanelRaiseLAB9RSLT2.Visible = false;
                PanelRaiseLAB9RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB9RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB9RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB9RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB9RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB9RSLT.Visible = true;
                PanelRaiseLAB9RSLT2.Visible = true;
                PanelRaiseLAB9RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB9RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB9RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB9RSLT.Visible = true;
                PanelRaiseLAB9RSLT2.Visible = true;
                PanelRaiseLAB9RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB9RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB9RSLT = '" + TextBoxLAB9RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB9RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB9RSLT.Visible = true;
                RAISELAB9RSLT.ShowPopupWindow();
                PanelRaiseLAB9RSLT.Visible = false;
                PanelRaiseLAB9RSLT2.Visible = false;
                PanelRaiseLAB9RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB9RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB9RSLT.Visible = true;
                RAISELAB9RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB9RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB9RSLT.Visible = true;
                RespondedLAB9RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB9RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB9RSLT.Visible = true;
                CloseLAB9RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB9RSLT.Visible = true;
                LockLAB9RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB9RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB9RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB9RSLT = '" + TextBoxLAB9RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB9RSLTMSG.ShowPopupWindow();
        RAISELAB9RSLT.Visible = false;
    }

    protected void CloseQueryLAB9RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB9RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB9RSLT = '" + TextBoxLAB9RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB9RSLTMSG.ShowPopupWindow();
        RespondedLAB9RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB9RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB9RSLT.Visible = false;

        RAISELAB9RSLT.Visible = true;
        RAISELAB9RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB10RSLT
    private void SetImageQueryLAB10RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB10RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB10RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB10RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB10RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB10RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB10RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB10RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB10RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB10RSLT.Visible = true;
                PanelRaiseLAB10RSLT2.Visible = false;
                PanelRaiseLAB10RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB10RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB10RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB10RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB10RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB10RSLT.Visible = true;
                PanelRaiseLAB10RSLT2.Visible = true;
                PanelRaiseLAB10RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB10RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB10RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB10RSLT.Visible = true;
                PanelRaiseLAB10RSLT2.Visible = true;
                PanelRaiseLAB10RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB10RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB10RSLT = '" + TextBoxLAB10RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB10RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB10RSLT.Visible = true;
                RAISELAB10RSLT.ShowPopupWindow();
                PanelRaiseLAB10RSLT.Visible = false;
                PanelRaiseLAB10RSLT2.Visible = false;
                PanelRaiseLAB10RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB10RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB10RSLT.Visible = true;
                RAISELAB10RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB10RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB10RSLT.Visible = true;
                RespondedLAB10RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB10RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB10RSLT.Visible = true;
                CloseLAB10RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB10RSLT.Visible = true;
                LockLAB10RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB10RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB10RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB10RSLT = '" + TextBoxLAB10RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB10RSLTMSG.ShowPopupWindow();
        RAISELAB10RSLT.Visible = false;
    }

    protected void CloseQueryLAB10RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB10RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB10RSLT = '" + TextBoxLAB10RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB10RSLTMSG.ShowPopupWindow();
        RespondedLAB10RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB10RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB10RSLT.Visible = false;

        RAISELAB10RSLT.Visible = true;
        RAISELAB10RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB11RSLT
    private void SetImageQueryLAB11RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB11RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB11RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB11RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB11RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB11RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB11RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB11RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB11RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB11RSLT.Visible = true;
                PanelRaiseLAB11RSLT2.Visible = false;
                PanelRaiseLAB11RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB11RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB11RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB11RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB11RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB11RSLT.Visible = true;
                PanelRaiseLAB11RSLT2.Visible = true;
                PanelRaiseLAB11RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB11RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB11RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB11RSLT.Visible = true;
                PanelRaiseLAB11RSLT2.Visible = true;
                PanelRaiseLAB11RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB11RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB11RSLT = '" + TextBoxLAB11RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB11RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB11RSLT.Visible = true;
                RAISELAB11RSLT.ShowPopupWindow();
                PanelRaiseLAB11RSLT.Visible = false;
                PanelRaiseLAB11RSLT2.Visible = false;
                PanelRaiseLAB11RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB11RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB11RSLT.Visible = true;
                RAISELAB11RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB11RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB11RSLT.Visible = true;
                RespondedLAB11RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB11RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB11RSLT.Visible = true;
                CloseLAB11RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB11RSLT.Visible = true;
                LockLAB11RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB11RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB11RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB11RSLT = '" + TextBoxLAB11RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB11RSLTMSG.ShowPopupWindow();
        RAISELAB11RSLT.Visible = false;
    }

    protected void CloseQueryLAB11RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB11RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB11RSLT = '" + TextBoxLAB11RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB11RSLTMSG.ShowPopupWindow();
        RespondedLAB11RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB11RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB11RSLT.Visible = false;

        RAISELAB11RSLT.Visible = true;
        RAISELAB11RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB12RSLT
    private void SetImageQueryLAB12RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB12RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB12RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB12RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB12RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB12RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB12RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB12RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB12RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB12RSLT.Visible = true;
                PanelRaiseLAB12RSLT2.Visible = false;
                PanelRaiseLAB12RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB12RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB12RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB12RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB12RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB12RSLT.Visible = true;
                PanelRaiseLAB12RSLT2.Visible = true;
                PanelRaiseLAB12RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB12RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB12RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB12RSLT.Visible = true;
                PanelRaiseLAB12RSLT2.Visible = true;
                PanelRaiseLAB12RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB12RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB12RSLT = '" + TextBoxLAB12RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB12RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB12RSLT.Visible = true;
                RAISELAB12RSLT.ShowPopupWindow();
                PanelRaiseLAB12RSLT.Visible = false;
                PanelRaiseLAB12RSLT2.Visible = false;
                PanelRaiseLAB12RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB12RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB12RSLT.Visible = true;
                RAISELAB12RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB12RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB12RSLT.Visible = true;
                RespondedLAB12RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB12RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB12RSLT.Visible = true;
                CloseLAB12RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB12RSLT.Visible = true;
                LockLAB12RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB12RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB12RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB12RSLT = '" + TextBoxLAB12RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB12RSLTMSG.ShowPopupWindow();
        RAISELAB12RSLT.Visible = false;
    }

    protected void CloseQueryLAB12RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB12RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB12RSLT = '" + TextBoxLAB12RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB12RSLTMSG.ShowPopupWindow();
        RespondedLAB12RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB12RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB12RSLT.Visible = false;

        RAISELAB12RSLT.Visible = true;
        RAISELAB12RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB13RSLT
    private void SetImageQueryLAB13RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB13RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB13RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB13RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB13RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB13RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB13RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB13RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB13RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB13RSLT.Visible = true;
                PanelRaiseLAB13RSLT2.Visible = false;
                PanelRaiseLAB13RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB13RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB13RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB13RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB13RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB13RSLT.Visible = true;
                PanelRaiseLAB13RSLT2.Visible = true;
                PanelRaiseLAB13RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB13RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB13RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB13RSLT.Visible = true;
                PanelRaiseLAB13RSLT2.Visible = true;
                PanelRaiseLAB13RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB13RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB13RSLT = '" + TextBoxLAB13RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB13RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB13RSLT.Visible = true;
                RAISELAB13RSLT.ShowPopupWindow();
                PanelRaiseLAB13RSLT.Visible = false;
                PanelRaiseLAB13RSLT2.Visible = false;
                PanelRaiseLAB13RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB13RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB13RSLT.Visible = true;
                RAISELAB13RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB13RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB13RSLT.Visible = true;
                RespondedLAB13RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB13RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB13RSLT.Visible = true;
                CloseLAB13RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB13RSLT.Visible = true;
                LockLAB13RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB13RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB13RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB13RSLT = '" + TextBoxLAB13RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB13RSLTMSG.ShowPopupWindow();
        RAISELAB13RSLT.Visible = false;
    }

    protected void CloseQueryLAB13RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB13RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB13RSLT = '" + TextBoxLAB13RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB13RSLTMSG.ShowPopupWindow();
        RespondedLAB13RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB13RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB13RSLT.Visible = false;

        RAISELAB13RSLT.Visible = true;
        RAISELAB13RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB14RSLT
    private void SetImageQueryLAB14RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB14RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB14RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB14RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB14RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB14RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB14RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB14RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB14RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB14RSLT.Visible = true;
                PanelRaiseLAB14RSLT2.Visible = false;
                PanelRaiseLAB14RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB14RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB14RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB14RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB14RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB14RSLT.Visible = true;
                PanelRaiseLAB14RSLT2.Visible = true;
                PanelRaiseLAB14RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB14RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB14RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB14RSLT.Visible = true;
                PanelRaiseLAB14RSLT2.Visible = true;
                PanelRaiseLAB14RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB14RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB14RSLT = '" + TextBoxLAB14RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB14RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB14RSLT.Visible = true;
                RAISELAB14RSLT.ShowPopupWindow();
                PanelRaiseLAB14RSLT.Visible = false;
                PanelRaiseLAB14RSLT2.Visible = false;
                PanelRaiseLAB14RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB14RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB14RSLT.Visible = true;
                RAISELAB14RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB14RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB14RSLT.Visible = true;
                RespondedLAB14RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB14RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB14RSLT.Visible = true;
                CloseLAB14RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB14RSLT.Visible = true;
                LockLAB14RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB14RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB14RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB14RSLT = '" + TextBoxLAB14RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB14RSLTMSG.ShowPopupWindow();
        RAISELAB14RSLT.Visible = false;
    }

    protected void CloseQueryLAB14RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB14RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB14RSLT = '" + TextBoxLAB14RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB14RSLTMSG.ShowPopupWindow();
        RespondedLAB14RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB14RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB14RSLT.Visible = false;

        RAISELAB14RSLT.Visible = true;
        RAISELAB14RSLT.ShowPopupWindow();
    }
    #endregion
    #region QueryLAB15RSLT
    private void SetImageQueryLAB15RSLT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB15RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryLAB15RSLT.ImageUrl = "~/DataView/Images/red.png";


            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryLAB15RSLT.ImageUrl = "~/DataView/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryLAB15RSLT.ImageUrl = "~/DataView/Images/Yellow.png";

            }
            else
            {
                ImageQueryLAB15RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryLAB15RSLT.ImageUrl = "~/DataView/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataLAB15RSLT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB15RSLT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseLAB15RSLT.Visible = true;
                PanelRaiseLAB15RSLT2.Visible = false;
                PanelRaiseLAB15RSLT3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseLAB15RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedLAB15RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB15RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB15RSLT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseLAB15RSLT.Visible = true;
                PanelRaiseLAB15RSLT2.Visible = true;
                PanelRaiseLAB15RSLT3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockLAB15RSLT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockLAB15RSLT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseLAB15RSLT.Visible = true;
                PanelRaiseLAB15RSLT2.Visible = true;
                PanelRaiseLAB15RSLT3.Visible = false;
                
            }
            else
            {
            }

        }
    }
    protected void ImageQueryLAB15RSLT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LaboratoryInvertigations] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB15RSLT = '" + TextBoxLAB15RSLT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryLAB15RSLT.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISELAB15RSLT.Visible = true;
                RAISELAB15RSLT.ShowPopupWindow();
                PanelRaiseLAB15RSLT.Visible = false;
                PanelRaiseLAB15RSLT2.Visible = false;
                PanelRaiseLAB15RSLT3.Visible = false;

            }

            else if ((ImageQueryLAB15RSLT.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISELAB15RSLT.Visible = true;
                RAISELAB15RSLT.ShowPopupWindow();
            }

            else if ((ImageQueryLAB15RSLT.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedLAB15RSLT.Visible = true;
                RespondedLAB15RSLT.ShowPopupWindow();
            }
            else if ((ImageQueryLAB15RSLT.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseLAB15RSLT.Visible = true;
                CloseLAB15RSLT.ShowPopupWindow();
            }
            else
            {
                LockLAB15RSLT.Visible = true;
                LockLAB15RSLT.ShowPopupWindow();

            }
        }

    }
    protected void QueryRaiseLAB15RSLT_Click(object sender, EventArgs e)
    {

        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblLAB15RSLT.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','')", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB15RSLT = '" + TextBoxLAB15RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISELAB15RSLTMSG.ShowPopupWindow();
        RAISELAB15RSLT.Visible = false;
    }

    protected void CloseQueryLAB15RSLT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand(" Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblLAB15RSLT.Text + "'", con);
        cmd1 = new SqlCommand("Update [Visit1].[LaboratoryInvertigations] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LAB15RSLT = '" + TextBoxLAB15RSLT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSELAB15RSLTMSG.ShowPopupWindow();
        RespondedLAB15RSLT.Visible = false;
    }

    protected void SubmitReRaiseLAB15RSLT_Click(object sender, EventArgs e)
    {
        CloseLAB15RSLT.Visible = false;

        RAISELAB15RSLT.Visible = true;
        RAISELAB15RSLT.ShowPopupWindow();
    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DataView/DataViewActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

}