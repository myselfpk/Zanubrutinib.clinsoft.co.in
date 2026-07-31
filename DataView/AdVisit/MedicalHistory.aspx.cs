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

public partial class DataView_AdVisit_MedicalHistory : System.Web.UI.Page
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
        TextBoxMSHSD_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        TextBoxMSHED_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

        SetImageQueryMSHSNO();
        BindQueryDataMSHSNO();


        SetImageQueryMSHDESC();
        BindQueryDataMSHDESC();


        SetImageQueryMSHSD();
        BindQueryDataMSHSD();

        SetImageQueryMSHOG();
        BindQueryDataMSHOG();

        SetImageQueryMSHED();
        BindQueryDataMSHED();

        SetImageQueryMSHTM();
        BindQueryDataMSHTM();

        showHide();
    }
    #region Note Acttchment and PageHistory
    #region AddNote
    private void SetImageAddNote()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from ADDNOTE  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and SNO = '" + TextBoxMSHSNO.Text + "' and Page = '" + lblPage.Text + "'", con);
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

        cmd = new SqlCommand("insert into ADDNOTE values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + AddNoteFiledTextBox.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','" + AddNoteTextBox.Text + "','" + TextBoxMSHSNO.Text + "')", con);
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
            SqlCommand cmd = new SqlCommand("select * from ADDNOTE where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxMSHSNO.Text + "'  and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'", con);
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
        SqlCommand cmd = new SqlCommand("Select * from ADDATTACHMENT  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxMSHSNO.Text + "'", con);
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
                        cmd.Parameters.AddWithValue("@Visit", lblVisit.Text);
                        cmd.Parameters.AddWithValue("@Page", lblPage.Text);
                        cmd.Parameters.AddWithValue("@Field", AddAttachmentFiledTextBox.Text);
                        cmd.Parameters.AddWithValue("@Username", LabelUserName.Text);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today.ToString("dd-MMM-yyyy"));
                        cmd.Parameters.AddWithValue("@Title", TextBoxADDAddAttachment.Text);
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Parameters.AddWithValue("@SNO", TextBoxMSHSNO.Text);
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
                cmd.CommandText = "select ID,Site,ScreenID,SubInitial ,Visit,Page,Field,Username,Date,Title,Name ,ContentType,Data from ADDATTACHMENT where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "' and SNO = '" + TextBoxMSHSNO.Text + "'";
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
        SqlCommand cmd = new SqlCommand("Select * from tblReasonForChange  where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and SNO = '" + TextBoxMSHSNO.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'", con);
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
                cmd.CommandText = "SELECT ID, [QuestionText],[OldValue],[NewValue],[Reason],[PageName],[EUser],[EDate] FROM [dbo].[tblReasonForChange] where Site='" + lblCenterNumber.Text + "' and SubId = '" + lblScreeningNo.Text + "' and Subini = '" + lblSubjectInitial.Text + "' and PageName = '" + lblVisit.Text + "-" + lblPage.Text + "'and SNO = '" + TextBoxMSHSNO.Text + "'";
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
        SqlCommand sqlCmd = new SqlCommand("SELECT MSHSNO ,MSHDESC ,MSHSD ,MSHOG ,MSHED ,MSHTM FROM [Add].[MedicalHistoryRecord] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'and [MSHSNO]='" + Request.QueryString["f"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            TextBoxMSHSNO.Text = dt.Rows[0]["MSHSNO"].ToString();
            TextBoxMSHDESC.Text = dt.Rows[0]["MSHDESC"].ToString();
            TextBoxMSHSD.Text = dt.Rows[0]["MSHSD"].ToString();
            RadioButtonListMSHOG.SelectedValue = dt.Rows[0]["MSHOG"].ToString();
            TextBoxMSHED.Text = dt.Rows[0]["MSHED"].ToString();
            RadioButtonListMSHTM.SelectedValue = dt.Rows[0]["MSHTM"].ToString();

        }
        con.Close();

    }
    #endregion

    #region QueryMSHSNO
    private void SetImageQueryMSHSNO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHSNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                ImageQueryMSHSNO.ImageUrl = "~/DataView/Images/red.png";
            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMSHSNO.ImageUrl = "~/DataView/Images/close.png";
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMSHSNO.ImageUrl = "~/DataView/Images/Yellow.png";
            }
            else
            {
                ImageQueryMSHSNO.ImageUrl = "~/DataView/Images/Blue.jpg";
            }
        }
        else
        {
            ImageQueryMSHSNO.ImageUrl = "~/DataView/Images/Blue.jpg";
        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMSHSNO()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHSNO.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                LabelRaiseMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMSHSNO.Visible = true;
                PanelRaiseMSHSNO2.Visible = false;
                PanelRaiseMSHSNO3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMSHSNO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMSHSNO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHSNO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHSNO3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMSHSNO.Visible = true;
                PanelRaiseMSHSNO2.Visible = true;
                PanelRaiseMSHSNO3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHSNO.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHSNO2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMSHSNO.Visible = true;
                PanelRaiseMSHSNO2.Visible = true;
                PanelRaiseMSHSNO3.Visible = false;
                
            }
            else
            {
            }
        }
    }
    protected void ImageQueryMSHSNO_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[MedicalHistoryRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHSNO = '" + TextBoxMSHSNO.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if ((ImageQueryMSHSNO.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHSNO.Visible = true;
                RAISEMSHSNO.ShowPopupWindow();
                PanelRaiseMSHSNO.Visible = false;
                PanelRaiseMSHSNO2.Visible = false;
                PanelRaiseMSHSNO3.Visible = false;
            }

            else if ((ImageQueryMSHSNO.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHSNO.Visible = true;
                RAISEMSHSNO.ShowPopupWindow();
            }

            else if ((ImageQueryMSHSNO.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMSHSNO.Visible = true;
                RespondedMSHSNO.ShowPopupWindow();
            }
            else if ((ImageQueryMSHSNO.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMSHSNO.Visible = true;
                CloseMSHSNO.ShowPopupWindow();
            }
            else
            {
                LockMSHSNO.Visible = true;
                LockMSHSNO.ShowPopupWindow();
            }
        }
    }
    protected void QueryRaiseMSHSNO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMSHSNO.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','" + TextBoxMSHSNO.Text + "')", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHSNO = '" + TextBoxMSHSNO.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMSHSNOMSG.ShowPopupWindow();
        RAISEMSHSNO.Visible = false;
    }

    protected void CloseQueryMSHSNO_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand("Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHSNO.Text + "' and SNO='" + TextBoxMSHSNO.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHSNO = '" + TextBoxMSHSNO.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMSHSNOMSG.ShowPopupWindow();
        RespondedMSHSNO.Visible = false;
    }

    protected void SubmitReRaiseMSHSNO_Click(object sender, EventArgs e)
    {
        CloseMSHSNO.Visible = false;
        RAISEMSHSNO.Visible = true;
        RAISEMSHSNO.ShowPopupWindow();
    }
    #endregion
    #region QueryMSHOG
    private void SetImageQueryMSHOG()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHOG.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                ImageQueryMSHOG.ImageUrl = "~/DataView/Images/red.png";
            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMSHOG.ImageUrl = "~/DataView/Images/close.png";
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMSHOG.ImageUrl = "~/DataView/Images/Yellow.png";
            }
            else
            {
                ImageQueryMSHOG.ImageUrl = "~/DataView/Images/Blue.jpg";
            }
        }
        else
        {
            ImageQueryMSHOG.ImageUrl = "~/DataView/Images/Blue.jpg";
        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMSHOG()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHOG.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                LabelRaiseMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMSHOG.Visible = true;
                PanelRaiseMSHOG2.Visible = false;
                PanelRaiseMSHOG3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMSHOG3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMSHOG3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHOG3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHOG3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMSHOG.Visible = true;
                PanelRaiseMSHOG2.Visible = true;
                PanelRaiseMSHOG3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHOG.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHOG2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMSHOG.Visible = true;
                PanelRaiseMSHOG2.Visible = true;
                PanelRaiseMSHOG3.Visible = false;
                
            }
            else
            {
            }
        }
    }
    protected void ImageQueryMSHOG_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[MedicalHistoryRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHOG = '" + RadioButtonListMSHOG.SelectedValue + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if ((ImageQueryMSHOG.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHOG.Visible = true;
                RAISEMSHOG.ShowPopupWindow();
                PanelRaiseMSHOG.Visible = false;
                PanelRaiseMSHOG2.Visible = false;
                PanelRaiseMSHOG3.Visible = false;
            }

            else if ((ImageQueryMSHOG.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHOG.Visible = true;
                RAISEMSHOG.ShowPopupWindow();
            }

            else if ((ImageQueryMSHOG.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMSHOG.Visible = true;
                RespondedMSHOG.ShowPopupWindow();
            }
            else if ((ImageQueryMSHOG.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMSHOG.Visible = true;
                CloseMSHOG.ShowPopupWindow();
            }
            else
            {
                LockMSHOG.Visible = true;
                LockMSHOG.ShowPopupWindow();
            }
        }
    }
    protected void QueryRaiseMSHOG_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMSHOG.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','" + TextBoxMSHSNO.Text + "')", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHOG = '" + RadioButtonListMSHOG.SelectedValue + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMSHOGMSG.ShowPopupWindow();
        RAISEMSHOG.Visible = false;
    }

    protected void CloseQueryMSHOG_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand("Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHOG.Text + "' and SNO='" + TextBoxMSHSNO.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHOG = '" + RadioButtonListMSHOG.SelectedValue + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMSHOGMSG.ShowPopupWindow();
        RespondedMSHOG.Visible = false;
    }

    protected void SubmitReRaiseMSHOG_Click(object sender, EventArgs e)
    {
        CloseMSHOG.Visible = false;
        RAISEMSHOG.Visible = true;
        RAISEMSHOG.ShowPopupWindow();
    }
    #endregion
    #region QueryMSHDESC
    private void SetImageQueryMSHDESC()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHDESC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                ImageQueryMSHDESC.ImageUrl = "~/DataView/Images/red.png";
            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMSHDESC.ImageUrl = "~/DataView/Images/close.png";
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMSHDESC.ImageUrl = "~/DataView/Images/Yellow.png";
            }
            else
            {
                ImageQueryMSHDESC.ImageUrl = "~/DataView/Images/Blue.jpg";
            }
        }
        else
        {
            ImageQueryMSHDESC.ImageUrl = "~/DataView/Images/Blue.jpg";
        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMSHDESC()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHDESC.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                LabelRaiseMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMSHDESC.Visible = true;
                PanelRaiseMSHDESC2.Visible = false;
                PanelRaiseMSHDESC3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMSHDESC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMSHDESC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHDESC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHDESC3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMSHDESC.Visible = true;
                PanelRaiseMSHDESC2.Visible = true;
                PanelRaiseMSHDESC3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHDESC.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHDESC2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMSHDESC.Visible = true;
                PanelRaiseMSHDESC2.Visible = true;
                PanelRaiseMSHDESC3.Visible = false;
                
            }
            else
            {
            }
        }
    }
    protected void ImageQueryMSHDESC_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[MedicalHistoryRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHDESC = '" + TextBoxMSHDESC.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if ((ImageQueryMSHDESC.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHDESC.Visible = true;
                RAISEMSHDESC.ShowPopupWindow();
                PanelRaiseMSHDESC.Visible = false;
                PanelRaiseMSHDESC2.Visible = false;
                PanelRaiseMSHDESC3.Visible = false;
            }

            else if ((ImageQueryMSHDESC.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHDESC.Visible = true;
                RAISEMSHDESC.ShowPopupWindow();
            }

            else if ((ImageQueryMSHDESC.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMSHDESC.Visible = true;
                RespondedMSHDESC.ShowPopupWindow();
            }
            else if ((ImageQueryMSHDESC.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMSHDESC.Visible = true;
                CloseMSHDESC.ShowPopupWindow();
            }
            else
            {
                LockMSHDESC.Visible = true;
                LockMSHDESC.ShowPopupWindow();
            }
        }
    }
    protected void QueryRaiseMSHDESC_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMSHDESC.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','" + TextBoxMSHSNO.Text + "')", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHDESC = '" + TextBoxMSHDESC.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMSHDESCMSG.ShowPopupWindow();
        RAISEMSHDESC.Visible = false;
    }

    protected void CloseQueryMSHDESC_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand("Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHDESC.Text + "' and SNO='" + TextBoxMSHSNO.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHDESC = '" + TextBoxMSHDESC.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMSHDESCMSG.ShowPopupWindow();
        RespondedMSHDESC.Visible = false;
    }

    protected void SubmitReRaiseMSHDESC_Click(object sender, EventArgs e)
    {
        CloseMSHDESC.Visible = false;
        RAISEMSHDESC.Visible = true;
        RAISEMSHDESC.ShowPopupWindow();
    }
    #endregion
    #region QueryMSHSD
    private void SetImageQueryMSHSD()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHSD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                ImageQueryMSHSD.ImageUrl = "~/DataView/Images/red.png";
            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMSHSD.ImageUrl = "~/DataView/Images/close.png";
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMSHSD.ImageUrl = "~/DataView/Images/Yellow.png";
            }
            else
            {
                ImageQueryMSHSD.ImageUrl = "~/DataView/Images/Blue.jpg";
            }
        }
        else
        {
            ImageQueryMSHSD.ImageUrl = "~/DataView/Images/Blue.jpg";
        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMSHSD()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHSD.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                LabelRaiseMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMSHSD.Visible = true;
                PanelRaiseMSHSD2.Visible = false;
                PanelRaiseMSHSD3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMSHSD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMSHSD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHSD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHSD3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMSHSD.Visible = true;
                PanelRaiseMSHSD2.Visible = true;
                PanelRaiseMSHSD3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHSD.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHSD2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMSHSD.Visible = true;
                PanelRaiseMSHSD2.Visible = true;
                PanelRaiseMSHSD3.Visible = false;
                
            }
            else
            {
            }
        }
    }
    protected void ImageQueryMSHSD_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[MedicalHistoryRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHSD = '" + TextBoxMSHSD.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if ((ImageQueryMSHSD.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHSD.Visible = true;
                RAISEMSHSD.ShowPopupWindow();
                PanelRaiseMSHSD.Visible = false;
                PanelRaiseMSHSD2.Visible = false;
                PanelRaiseMSHSD3.Visible = false;
            }

            else if ((ImageQueryMSHSD.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHSD.Visible = true;
                RAISEMSHSD.ShowPopupWindow();
            }

            else if ((ImageQueryMSHSD.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMSHSD.Visible = true;
                RespondedMSHSD.ShowPopupWindow();
            }
            else if ((ImageQueryMSHSD.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMSHSD.Visible = true;
                CloseMSHSD.ShowPopupWindow();
            }
            else
            {
                LockMSHSD.Visible = true;
                LockMSHSD.ShowPopupWindow();
            }
        }
    }
    protected void QueryRaiseMSHSD_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMSHSD.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','" + TextBoxMSHSNO.Text + "')", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHSD = '" + TextBoxMSHSD.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMSHSDMSG.ShowPopupWindow();
        RAISEMSHSD.Visible = false;
    }

    protected void CloseQueryMSHSD_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand("Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHSD.Text + "' and SNO='" + TextBoxMSHSNO.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHSD = '" + TextBoxMSHSD.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMSHSDMSG.ShowPopupWindow();
        RespondedMSHSD.Visible = false;
    }

    protected void SubmitReRaiseMSHSD_Click(object sender, EventArgs e)
    {
        CloseMSHSD.Visible = false;
        RAISEMSHSD.Visible = true;
        RAISEMSHSD.ShowPopupWindow();
    }
    #endregion
    #region QueryMSHED
    private void SetImageQueryMSHED()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHED.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                ImageQueryMSHED.ImageUrl = "~/DataView/Images/red.png";
            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMSHED.ImageUrl = "~/DataView/Images/close.png";
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMSHED.ImageUrl = "~/DataView/Images/Yellow.png";
            }
            else
            {
                ImageQueryMSHED.ImageUrl = "~/DataView/Images/Blue.jpg";
            }
        }
        else
        {
            ImageQueryMSHED.ImageUrl = "~/DataView/Images/Blue.jpg";
        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMSHED()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHED.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                LabelRaiseMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMSHED.Visible = true;
                PanelRaiseMSHED2.Visible = false;
                PanelRaiseMSHED3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMSHED3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMSHED3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHED3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHED3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMSHED.Visible = true;
                PanelRaiseMSHED2.Visible = true;
                PanelRaiseMSHED3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHED.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHED2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMSHED.Visible = true;
                PanelRaiseMSHED2.Visible = true;
                PanelRaiseMSHED3.Visible = false;
                
            }
            else
            {
            }
        }
    }
    protected void ImageQueryMSHED_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[MedicalHistoryRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHED = '" + TextBoxMSHED.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if ((ImageQueryMSHED.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHED.Visible = true;
                RAISEMSHED.ShowPopupWindow();
                PanelRaiseMSHED.Visible = false;
                PanelRaiseMSHED2.Visible = false;
                PanelRaiseMSHED3.Visible = false;
            }

            else if ((ImageQueryMSHED.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHED.Visible = true;
                RAISEMSHED.ShowPopupWindow();
            }

            else if ((ImageQueryMSHED.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMSHED.Visible = true;
                RespondedMSHED.ShowPopupWindow();
            }
            else if ((ImageQueryMSHED.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMSHED.Visible = true;
                CloseMSHED.ShowPopupWindow();
            }
            else
            {
                LockMSHED.Visible = true;
                LockMSHED.ShowPopupWindow();
            }
        }
    }
    protected void QueryRaiseMSHED_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMSHED.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','" + TextBoxMSHSNO.Text + "')", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHED = '" + TextBoxMSHED.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMSHEDMSG.ShowPopupWindow();
        RAISEMSHED.Visible = false;
    }

    protected void CloseQueryMSHED_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand("Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHED.Text + "' and SNO='" + TextBoxMSHSNO.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHED = '" + TextBoxMSHED.Text + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMSHEDMSG.ShowPopupWindow();
        RespondedMSHED.Visible = false;
    }

    protected void SubmitReRaiseMSHED_Click(object sender, EventArgs e)
    {
        CloseMSHED.Visible = false;
        RAISEMSHED.Visible = true;
        RAISEMSHED.ShowPopupWindow();
    }
    #endregion
    #region QueryMSHTM
    private void SetImageQueryMSHTM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHTM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                ImageQueryMSHTM.ImageUrl = "~/DataView/Images/red.png";
            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryMSHTM.ImageUrl = "~/DataView/Images/close.png";
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryMSHTM.ImageUrl = "~/DataView/Images/Yellow.png";
            }
            else
            {
                ImageQueryMSHTM.ImageUrl = "~/DataView/Images/Blue.jpg";
            }
        }
        else
        {
            ImageQueryMSHTM.ImageUrl = "~/DataView/Images/Blue.jpg";
        }
        dr.Close();

        con.Close();
    }

    private void BindQueryDataMSHTM()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and SNO='" + TextBoxMSHSNO.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHTM.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {
                LabelRaiseMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseMSHTM.Visible = true;
                PanelRaiseMSHTM2.Visible = false;
                PanelRaiseMSHTM3.Visible = false;
                
            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRaiseMSHTM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelRespondedMSHTM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelCloseMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHTM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                LabelLockMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHTM3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseMSHTM.Visible = true;
                PanelRaiseMSHTM2.Visible = true;
                PanelRaiseMSHTM3.Visible = true;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRespondedMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelRespondedMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelCloseMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelCloseMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                LabelLockMSHTM.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelLockMSHTM2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />";
                PanelRaiseMSHTM.Visible = true;
                PanelRaiseMSHTM2.Visible = true;
                PanelRaiseMSHTM3.Visible = false;
                
            }
            else
            {
            }
        }
    }
    protected void ImageQueryMSHTM_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Add].[MedicalHistoryRecord] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHTM = '" + RadioButtonListMSHTM.SelectedValue + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if ((ImageQueryMSHTM.ImageUrl == "~/DataView/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHTM.Visible = true;
                RAISEMSHTM.ShowPopupWindow();
                PanelRaiseMSHTM.Visible = false;
                PanelRaiseMSHTM2.Visible = false;
                PanelRaiseMSHTM3.Visible = false;
            }

            else if ((ImageQueryMSHTM.ImageUrl == "~/DataView/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEMSHTM.Visible = true;
                RAISEMSHTM.ShowPopupWindow();
            }

            else if ((ImageQueryMSHTM.ImageUrl == "~/DataView/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RespondedMSHTM.Visible = true;
                RespondedMSHTM.ShowPopupWindow();
            }
            else if ((ImageQueryMSHTM.ImageUrl == "~/DataView/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                CloseMSHTM.Visible = true;
                CloseMSHTM.ShowPopupWindow();
            }
            else
            {
                LockMSHTM.Visible = true;
                LockMSHTM.ShowPopupWindow();
            }
        }
    }
    protected void QueryRaiseMSHTM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand(" insert into tblQuery values('" + lblCenterNumber.Text + "','" + lblScreeningNo.Text + "','" + lblSubjectInitial.Text + "','" + lblVisit.Text + "','" + lblPage.Text + "','" + lblMSHTM.Text + "','" + LabelUserName.Text + "','" + DateTime.Today.ToString("dd-MMM-yyyy") + "','','','','Open','','','','','" + TextBoxMSHSNO.Text + "')", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Open' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHTM = '" + RadioButtonListMSHTM.SelectedValue + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEMSHTMMSG.ShowPopupWindow();
        RAISEMSHTM.Visible = false;
    }

    protected void CloseQueryMSHTM_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();
        cmd = new SqlCommand("Update tblQuery set  QueryResponse3 = 'Query Closed',  Status = 'Close', Username3 ='" + LabelUserName.Text + "', Date3 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblMSHTM.Text + "' and SNO='" + TextBoxMSHSNO.Text + "'", con);
        cmd1 = new SqlCommand("Update [Add].[MedicalHistoryRecord] set  QueryStatus = 'Query Closed' where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and MSHTM = '" + RadioButtonListMSHTM.SelectedValue + "'and MSHSNO ='" + TextBoxMSHSNO.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();


        CLOSEMSHTMMSG.ShowPopupWindow();
        RespondedMSHTM.Visible = false;
    }

    protected void SubmitReRaiseMSHTM_Click(object sender, EventArgs e)
    {
        CloseMSHTM.Visible = false;
        RAISEMSHTM.Visible = true;
        RAISEMSHTM.ShowPopupWindow();
    }
    #endregion
    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DataView/DataViewActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void showHide()
    {
        if (RadioButtonListMSHOG.SelectedValue == "No")
        {
            panelHide.Visible = true;
        }
        else
        {
            panelHide.Visible = false;
            TextBoxMSHED.Text = String.Empty;
        }
    }

    protected void TextBoxMSHSD_TextChanged(object sender, EventArgs e)
    {
        TextBoxMSHED.Text = String.Empty;
        TextBoxMSHED_CalendarExtender.StartDate = (Convert.ToDateTime(TextBoxMSHSD.Text)).AddDays(1);
    }

    protected void RadioButtonListMSHOG_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListMSHOG.SelectedValue == "No")
        {
            panelHide.Visible = true;
        }
        else
        {
            panelHide.Visible = false;
            TextBoxMSHED.Text = String.Empty;
        }
    }

}