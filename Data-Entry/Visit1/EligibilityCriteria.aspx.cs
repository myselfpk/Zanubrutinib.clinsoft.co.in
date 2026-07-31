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

public partial class Data_Entry_Visit1_EligibilityCriteria : System.Web.UI.Page
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

        SetImageQueryIC1OPT();
        SetImageQueryIC2OPT();
        SetImageQueryIC3OPT();
        SetImageQueryEC1OPT();
        SetImageQueryEC2OPT();
        SetImageQueryEC3OPT();
        SetImageQueryEC4OPT();
        SetImageQueryEC5OPT();
        SetImageQueryEC6OPT();
        SetImageQueryELIGL();
        SetImageQueryREMRK();

        BindQueryDataIC1OPT();
        BindQueryDataIC2OPT();
        BindQueryDataIC3OPT();
        BindQueryDataEC1OPT();
        BindQueryDataEC2OPT();
        BindQueryDataEC3OPT();
        BindQueryDataEC4OPT();
        BindQueryDataEC5OPT();
        BindQueryDataEC6OPT();
        BindQueryDataELIGL();
        BindQueryDataREMRK();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select IC1OPT, IC2OPT, IC3OPT, EC1OPT, EC2OPT, EC3OPT, EC4OPT, EC5OPT, EC6OPT, ELIGL, REMRK from [Visit1].[EligibilityCriteria] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListIC1OPT.SelectedValue = dt.Rows[0]["IC1OPT"].ToString().Trim();
            RadioButtonListIC2OPT.SelectedValue = dt.Rows[0]["IC2OPT"].ToString().Trim();
            RadioButtonListIC3OPT.SelectedValue = dt.Rows[0]["IC3OPT"].ToString().Trim();
            RadioButtonListEC1OPT.SelectedValue = dt.Rows[0]["EC1OPT"].ToString().Trim();
            RadioButtonListEC2OPT.SelectedValue = dt.Rows[0]["EC2OPT"].ToString().Trim();
            RadioButtonListEC3OPT.SelectedValue = dt.Rows[0]["EC3OPT"].ToString().Trim();
            RadioButtonListEC4OPT.SelectedValue = dt.Rows[0]["EC4OPT"].ToString().Trim();
            RadioButtonListEC5OPT.SelectedValue = dt.Rows[0]["EC5OPT"].ToString().Trim();
            RadioButtonListEC6OPT.SelectedValue = dt.Rows[0]["EC6OPT"].ToString().Trim();
            RadioButtonListELIGL.SelectedValue = dt.Rows[0]["ELIGL"].ToString().Trim();
            TextBoxREMRK.Text = dt.Rows[0]["REMRK"].ToString().Trim();


            ViewState["txt1"] = RadioButtonListIC1OPT.SelectedValue;
            ViewState["txt2"] = RadioButtonListIC2OPT.SelectedValue;
            ViewState["txt3"] = RadioButtonListIC3OPT.SelectedValue;
            ViewState["txt4"] = RadioButtonListEC1OPT.SelectedValue;
            ViewState["txt5"] = RadioButtonListEC2OPT.SelectedValue;
            ViewState["txt6"] = RadioButtonListEC3OPT.SelectedValue;
            ViewState["txt7"] = RadioButtonListEC4OPT.SelectedValue;
            ViewState["txt8"] = RadioButtonListEC5OPT.SelectedValue;
            ViewState["txt9"] = RadioButtonListEC6OPT.SelectedValue;
            ViewState["txt10"] = RadioButtonListELIGL.SelectedValue;
            ViewState["txt11"] = TextBoxREMRK.Text;

        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[EligibilityCriteria] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[EligibilityCriteria] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_EligibilityCriteria]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                    cmd.Parameters.AddWithValue("@IC1OPT", RadioButtonListIC1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IC2OPT", RadioButtonListIC2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IC3OPT", RadioButtonListIC3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC1OPT", RadioButtonListEC1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC2OPT", RadioButtonListEC2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC3OPT", RadioButtonListEC3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC4OPT", RadioButtonListEC4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC5OPT", RadioButtonListEC5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC6OPT", RadioButtonListEC6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ELIGL", RadioButtonListELIGL.SelectedValue);
                    cmd.Parameters.AddWithValue("@REMRK", TextBoxREMRK.Text);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[EligibilityCriteria] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListIC1OPT.SelectedValue || ViewState["txt2"].ToString() != RadioButtonListIC2OPT.SelectedValue || ViewState["txt3"].ToString() != RadioButtonListIC3OPT.SelectedValue || ViewState["txt4"].ToString() != RadioButtonListEC1OPT.SelectedValue || ViewState["txt5"].ToString() != RadioButtonListEC2OPT.SelectedValue || ViewState["txt6"].ToString() != RadioButtonListEC3OPT.SelectedValue || ViewState["txt7"].ToString() != RadioButtonListEC4OPT.SelectedValue || ViewState["txt8"].ToString() != RadioButtonListEC5OPT.SelectedValue || ViewState["txt9"].ToString() != RadioButtonListEC6OPT.SelectedValue || ViewState["txt10"].ToString() != RadioButtonListELIGL.SelectedValue || ViewState["txt11"].ToString() != TextBoxREMRK.Text)
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
                cmd = new SqlCommand("[Visit1].[sp_EligibilityCriteria]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@IC1OPT", RadioButtonListIC1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@IC2OPT", RadioButtonListIC2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@IC3OPT", RadioButtonListIC3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC1OPT", RadioButtonListEC1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC2OPT", RadioButtonListEC2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC3OPT", RadioButtonListEC3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC4OPT", RadioButtonListEC4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC5OPT", RadioButtonListEC5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC6OPT", RadioButtonListEC6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ELIGL", RadioButtonListELIGL.SelectedValue);
                cmd.Parameters.AddWithValue("@REMRK", TextBoxREMRK.Text);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[EligibilityCriteria] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_EligibilityCriteria]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@IC1OPT", RadioButtonListIC1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IC2OPT", RadioButtonListIC2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@IC3OPT", RadioButtonListIC3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC1OPT", RadioButtonListEC1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC2OPT", RadioButtonListEC2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC3OPT", RadioButtonListEC3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC4OPT", RadioButtonListEC4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC5OPT", RadioButtonListEC5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@EC6OPT", RadioButtonListEC6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ELIGL", RadioButtonListELIGL.SelectedValue);
                    cmd.Parameters.AddWithValue("@REMRK", TextBoxREMRK.Text);

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
                cmd = new SqlCommand("[Visit1].[sp_EligibilityCriteria]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@IC1OPT", RadioButtonListIC1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@IC2OPT", RadioButtonListIC2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@IC3OPT", RadioButtonListIC3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC1OPT", RadioButtonListEC1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC2OPT", RadioButtonListEC2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC3OPT", RadioButtonListEC3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC4OPT", RadioButtonListEC4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC5OPT", RadioButtonListEC5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@EC6OPT", RadioButtonListEC6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ELIGL", RadioButtonListELIGL.SelectedValue);
                cmd.Parameters.AddWithValue("@REMRK", TextBoxREMRK.Text);

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
        if (!string.IsNullOrEmpty(RadioButtonListIC1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListIC2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListIC3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListEC1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListEC2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListEC3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListEC4OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListEC5OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListEC6OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListELIGL.SelectedValue) || !string.IsNullOrEmpty(TextBoxREMRK.Text))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListIC1OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIC1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListIC1OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() != RadioButtonListIC2OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIC2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = RadioButtonListIC2OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() != RadioButtonListIC3OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblIC3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = RadioButtonListIC3OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() != RadioButtonListEC1OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEC1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListEC1OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() != RadioButtonListEC2OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEC2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListEC2OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() != RadioButtonListEC3OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEC3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = RadioButtonListEC3OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() != RadioButtonListEC4OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEC4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListEC4OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() != RadioButtonListEC5OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEC5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListEC5OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() != RadioButtonListEC6OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblEC6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListEC6OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != RadioButtonListELIGL.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblELIGL.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = RadioButtonListELIGL.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != TextBoxREMRK.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblREMRK.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = TextBoxREMRK.Text;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_EligibilityCriteria]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@IC1OPT", RadioButtonListIC1OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@IC2OPT", RadioButtonListIC2OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@IC3OPT", RadioButtonListIC3OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@EC1OPT", RadioButtonListEC1OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@EC2OPT", RadioButtonListEC2OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@EC3OPT", RadioButtonListEC3OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@EC4OPT", RadioButtonListEC4OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@EC5OPT", RadioButtonListEC5OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@EC6OPT", RadioButtonListEC6OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ELIGL", RadioButtonListELIGL.SelectedValue);
            cmd.Parameters.AddWithValue("@REMRK", TextBoxREMRK.Text);

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
    #region QueryIC1OPT
    private void SetImageQueryIC1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIC1OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIC1OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIC1OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIC1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIC1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIC1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIC1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT2.Visible = false;
                PanelRaiseIC1OPT3.Visible = false;
                PanelHideIC1OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIC1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIC1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIC1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT2.Visible = true;
                PanelRaiseIC1OPT3.Visible = true;
                PanelHideIC1OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIC1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIC1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT2.Visible = true;
                PanelRaiseIC1OPT3.Visible = false;
                PanelHideIC1OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIC1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IC1OPT = '" + RadioButtonListIC1OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIC1OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIC1OPT.Visible = true;
                RAISEIC1OPT.ShowPopupWindow();
                QueryRaiseIC1OPT.Visible = false;
                TextBoxRaiseIC1OPT.Visible = false;
                PanelRaiseIC1OPT.Visible = false;
                PanelRaiseIC1OPT2.Visible = false;
                PanelRaiseIC1OPT3.Visible = false;

                LabelRespondIC1OPT.Visible = false;
            }

            else if ((ImageQueryIC1OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC1OPT.Visible = true;
                RAISEIC1OPT.ShowPopupWindow();
                QueryRaiseIC1OPT.Visible = true;
                TextBoxRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT2.Visible = false;
                PanelRaiseIC1OPT3.Visible = false;
                LabelRespondIC1OPT.Visible = true;
            }

            else if ((ImageQueryIC1OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC1OPT.Visible = true;
                RAISEIC1OPT.ShowPopupWindow();
                QueryRaiseIC1OPT.Visible = false;
                TextBoxRaiseIC1OPT.Visible = false;
                PanelRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT2.Visible = true;
                PanelRaiseIC1OPT3.Visible = false;
                LabelRespondIC1OPT.Visible = false;
            }
            else if ((ImageQueryIC1OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC1OPT.Visible = true;
                RAISEIC1OPT.ShowPopupWindow();
                QueryRaiseIC1OPT.Visible = false;
                TextBoxRaiseIC1OPT.Visible = false;
                PanelRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT2.Visible = true;
                PanelRaiseIC1OPT3.Visible = true;
                LabelRespondIC1OPT.Visible = false;
            }
            else
            {
                RAISEIC1OPT.Visible = true;
                RAISEIC1OPT.ShowPopupWindow();
                QueryRaiseIC1OPT.Visible = false;
                TextBoxRaiseIC1OPT.Visible = false;
                PanelRaiseIC1OPT.Visible = true;
                PanelRaiseIC1OPT2.Visible = true;
                PanelRaiseIC1OPT3.Visible = true;
                LabelRespondIC1OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseIC1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIC1OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC1OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC1OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IC1OPT = '" + RadioButtonListIC1OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIC1OPTMSG.ShowPopupWindow();
        RAISEIC1OPT.Visible = false;


    }
    #endregion
    #region QueryIC2OPT
    private void SetImageQueryIC2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIC2OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIC2OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIC2OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIC2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIC2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIC2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIC2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT2.Visible = false;
                PanelRaiseIC2OPT3.Visible = false;
                PanelHideIC2OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIC2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIC2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIC2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT2.Visible = true;
                PanelRaiseIC2OPT3.Visible = true;
                PanelHideIC2OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIC2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIC2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT2.Visible = true;
                PanelRaiseIC2OPT3.Visible = false;
                PanelHideIC2OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIC2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IC2OPT = '" + RadioButtonListIC2OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIC2OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIC2OPT.Visible = true;
                RAISEIC2OPT.ShowPopupWindow();
                QueryRaiseIC2OPT.Visible = false;
                TextBoxRaiseIC2OPT.Visible = false;
                PanelRaiseIC2OPT.Visible = false;
                PanelRaiseIC2OPT2.Visible = false;
                PanelRaiseIC2OPT3.Visible = false;

                LabelRespondIC2OPT.Visible = false;
            }

            else if ((ImageQueryIC2OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC2OPT.Visible = true;
                RAISEIC2OPT.ShowPopupWindow();
                QueryRaiseIC2OPT.Visible = true;
                TextBoxRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT2.Visible = false;
                PanelRaiseIC2OPT3.Visible = false;
                LabelRespondIC2OPT.Visible = true;
            }

            else if ((ImageQueryIC2OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC2OPT.Visible = true;
                RAISEIC2OPT.ShowPopupWindow();
                QueryRaiseIC2OPT.Visible = false;
                TextBoxRaiseIC2OPT.Visible = false;
                PanelRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT2.Visible = true;
                PanelRaiseIC2OPT3.Visible = false;
                LabelRespondIC2OPT.Visible = false;
            }
            else if ((ImageQueryIC2OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC2OPT.Visible = true;
                RAISEIC2OPT.ShowPopupWindow();
                QueryRaiseIC2OPT.Visible = false;
                TextBoxRaiseIC2OPT.Visible = false;
                PanelRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT2.Visible = true;
                PanelRaiseIC2OPT3.Visible = true;
                LabelRespondIC2OPT.Visible = false;
            }
            else
            {
                RAISEIC2OPT.Visible = true;
                RAISEIC2OPT.ShowPopupWindow();
                QueryRaiseIC2OPT.Visible = false;
                TextBoxRaiseIC2OPT.Visible = false;
                PanelRaiseIC2OPT.Visible = true;
                PanelRaiseIC2OPT2.Visible = true;
                PanelRaiseIC2OPT3.Visible = true;
                LabelRespondIC2OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseIC2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIC2OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC2OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC2OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IC2OPT = '" + RadioButtonListIC2OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIC2OPTMSG.ShowPopupWindow();
        RAISEIC2OPT.Visible = false;


    }
    #endregion
    #region QueryIC3OPT
    private void SetImageQueryIC3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryIC3OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryIC3OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryIC3OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryIC3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryIC3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataIC3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseIC3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT2.Visible = false;
                PanelRaiseIC3OPT3.Visible = false;
                PanelHideIC3OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseIC3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIC3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseIC3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT2.Visible = true;
                PanelRaiseIC3OPT3.Visible = true;
                PanelHideIC3OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseIC3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseIC3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT2.Visible = true;
                PanelRaiseIC3OPT3.Visible = false;
                PanelHideIC3OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryIC3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IC3OPT = '" + RadioButtonListIC3OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryIC3OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEIC3OPT.Visible = true;
                RAISEIC3OPT.ShowPopupWindow();
                QueryRaiseIC3OPT.Visible = false;
                TextBoxRaiseIC3OPT.Visible = false;
                PanelRaiseIC3OPT.Visible = false;
                PanelRaiseIC3OPT2.Visible = false;
                PanelRaiseIC3OPT3.Visible = false;

                LabelRespondIC3OPT.Visible = false;
            }

            else if ((ImageQueryIC3OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC3OPT.Visible = true;
                RAISEIC3OPT.ShowPopupWindow();
                QueryRaiseIC3OPT.Visible = true;
                TextBoxRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT2.Visible = false;
                PanelRaiseIC3OPT3.Visible = false;
                LabelRespondIC3OPT.Visible = true;
            }

            else if ((ImageQueryIC3OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC3OPT.Visible = true;
                RAISEIC3OPT.ShowPopupWindow();
                QueryRaiseIC3OPT.Visible = false;
                TextBoxRaiseIC3OPT.Visible = false;
                PanelRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT2.Visible = true;
                PanelRaiseIC3OPT3.Visible = false;
                LabelRespondIC3OPT.Visible = false;
            }
            else if ((ImageQueryIC3OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEIC3OPT.Visible = true;
                RAISEIC3OPT.ShowPopupWindow();
                QueryRaiseIC3OPT.Visible = false;
                TextBoxRaiseIC3OPT.Visible = false;
                PanelRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT2.Visible = true;
                PanelRaiseIC3OPT3.Visible = true;
                LabelRespondIC3OPT.Visible = false;
            }
            else
            {
                RAISEIC3OPT.Visible = true;
                RAISEIC3OPT.ShowPopupWindow();
                QueryRaiseIC3OPT.Visible = false;
                TextBoxRaiseIC3OPT.Visible = false;
                PanelRaiseIC3OPT.Visible = true;
                PanelRaiseIC3OPT2.Visible = true;
                PanelRaiseIC3OPT3.Visible = true;
                LabelRespondIC3OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseIC3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseIC3OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC3OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblIC3OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and IC3OPT = '" + RadioButtonListIC3OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEIC3OPTMSG.ShowPopupWindow();
        RAISEIC3OPT.Visible = false;


    }
    #endregion
    #region QueryEC1OPT
    private void SetImageQueryEC1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEC1OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEC1OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEC1OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEC1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEC1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEC1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEC1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT2.Visible = false;
                PanelRaiseEC1OPT3.Visible = false;
                PanelHideEC1OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEC1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEC1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT2.Visible = true;
                PanelRaiseEC1OPT3.Visible = true;
                PanelHideEC1OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEC1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT2.Visible = true;
                PanelRaiseEC1OPT3.Visible = false;
                PanelHideEC1OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEC1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC1OPT = '" + RadioButtonListEC1OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEC1OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEC1OPT.Visible = true;
                RAISEEC1OPT.ShowPopupWindow();
                QueryRaiseEC1OPT.Visible = false;
                TextBoxRaiseEC1OPT.Visible = false;
                PanelRaiseEC1OPT.Visible = false;
                PanelRaiseEC1OPT2.Visible = false;
                PanelRaiseEC1OPT3.Visible = false;

                LabelRespondEC1OPT.Visible = false;
            }

            else if ((ImageQueryEC1OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC1OPT.Visible = true;
                RAISEEC1OPT.ShowPopupWindow();
                QueryRaiseEC1OPT.Visible = true;
                TextBoxRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT2.Visible = false;
                PanelRaiseEC1OPT3.Visible = false;
                LabelRespondEC1OPT.Visible = true;
            }

            else if ((ImageQueryEC1OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC1OPT.Visible = true;
                RAISEEC1OPT.ShowPopupWindow();
                QueryRaiseEC1OPT.Visible = false;
                TextBoxRaiseEC1OPT.Visible = false;
                PanelRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT2.Visible = true;
                PanelRaiseEC1OPT3.Visible = false;
                LabelRespondEC1OPT.Visible = false;
            }
            else if ((ImageQueryEC1OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC1OPT.Visible = true;
                RAISEEC1OPT.ShowPopupWindow();
                QueryRaiseEC1OPT.Visible = false;
                TextBoxRaiseEC1OPT.Visible = false;
                PanelRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT2.Visible = true;
                PanelRaiseEC1OPT3.Visible = true;
                LabelRespondEC1OPT.Visible = false;
            }
            else
            {
                RAISEEC1OPT.Visible = true;
                RAISEEC1OPT.ShowPopupWindow();
                QueryRaiseEC1OPT.Visible = false;
                TextBoxRaiseEC1OPT.Visible = false;
                PanelRaiseEC1OPT.Visible = true;
                PanelRaiseEC1OPT2.Visible = true;
                PanelRaiseEC1OPT3.Visible = true;
                LabelRespondEC1OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseEC1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseEC1OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC1OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC1OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC1OPT = '" + RadioButtonListEC1OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEC1OPTMSG.ShowPopupWindow();
        RAISEEC1OPT.Visible = false;


    }
    #endregion
    #region QueryEC2OPT
    private void SetImageQueryEC2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEC2OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEC2OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEC2OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEC2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEC2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEC2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEC2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT2.Visible = false;
                PanelRaiseEC2OPT3.Visible = false;
                PanelHideEC2OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEC2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEC2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT2.Visible = true;
                PanelRaiseEC2OPT3.Visible = true;
                PanelHideEC2OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEC2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT2.Visible = true;
                PanelRaiseEC2OPT3.Visible = false;
                PanelHideEC2OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEC2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC2OPT = '" + RadioButtonListEC2OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEC2OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEC2OPT.Visible = true;
                RAISEEC2OPT.ShowPopupWindow();
                QueryRaiseEC2OPT.Visible = false;
                TextBoxRaiseEC2OPT.Visible = false;
                PanelRaiseEC2OPT.Visible = false;
                PanelRaiseEC2OPT2.Visible = false;
                PanelRaiseEC2OPT3.Visible = false;

                LabelRespondEC2OPT.Visible = false;
            }

            else if ((ImageQueryEC2OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC2OPT.Visible = true;
                RAISEEC2OPT.ShowPopupWindow();
                QueryRaiseEC2OPT.Visible = true;
                TextBoxRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT2.Visible = false;
                PanelRaiseEC2OPT3.Visible = false;
                LabelRespondEC2OPT.Visible = true;
            }

            else if ((ImageQueryEC2OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC2OPT.Visible = true;
                RAISEEC2OPT.ShowPopupWindow();
                QueryRaiseEC2OPT.Visible = false;
                TextBoxRaiseEC2OPT.Visible = false;
                PanelRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT2.Visible = true;
                PanelRaiseEC2OPT3.Visible = false;
                LabelRespondEC2OPT.Visible = false;
            }
            else if ((ImageQueryEC2OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC2OPT.Visible = true;
                RAISEEC2OPT.ShowPopupWindow();
                QueryRaiseEC2OPT.Visible = false;
                TextBoxRaiseEC2OPT.Visible = false;
                PanelRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT2.Visible = true;
                PanelRaiseEC2OPT3.Visible = true;
                LabelRespondEC2OPT.Visible = false;
            }
            else
            {
                RAISEEC2OPT.Visible = true;
                RAISEEC2OPT.ShowPopupWindow();
                QueryRaiseEC2OPT.Visible = false;
                TextBoxRaiseEC2OPT.Visible = false;
                PanelRaiseEC2OPT.Visible = true;
                PanelRaiseEC2OPT2.Visible = true;
                PanelRaiseEC2OPT3.Visible = true;
                LabelRespondEC2OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseEC2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseEC2OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC2OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC2OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC2OPT = '" + RadioButtonListEC2OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEC2OPTMSG.ShowPopupWindow();
        RAISEEC2OPT.Visible = false;


    }
    #endregion
    #region QueryEC3OPT
    private void SetImageQueryEC3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEC3OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEC3OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEC3OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEC3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEC3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEC3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEC3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT2.Visible = false;
                PanelRaiseEC3OPT3.Visible = false;
                PanelHideEC3OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEC3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEC3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT2.Visible = true;
                PanelRaiseEC3OPT3.Visible = true;
                PanelHideEC3OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEC3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT2.Visible = true;
                PanelRaiseEC3OPT3.Visible = false;
                PanelHideEC3OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEC3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC3OPT = '" + RadioButtonListEC3OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEC3OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEC3OPT.Visible = true;
                RAISEEC3OPT.ShowPopupWindow();
                QueryRaiseEC3OPT.Visible = false;
                TextBoxRaiseEC3OPT.Visible = false;
                PanelRaiseEC3OPT.Visible = false;
                PanelRaiseEC3OPT2.Visible = false;
                PanelRaiseEC3OPT3.Visible = false;

                LabelRespondEC3OPT.Visible = false;
            }

            else if ((ImageQueryEC3OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC3OPT.Visible = true;
                RAISEEC3OPT.ShowPopupWindow();
                QueryRaiseEC3OPT.Visible = true;
                TextBoxRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT2.Visible = false;
                PanelRaiseEC3OPT3.Visible = false;
                LabelRespondEC3OPT.Visible = true;
            }

            else if ((ImageQueryEC3OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC3OPT.Visible = true;
                RAISEEC3OPT.ShowPopupWindow();
                QueryRaiseEC3OPT.Visible = false;
                TextBoxRaiseEC3OPT.Visible = false;
                PanelRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT2.Visible = true;
                PanelRaiseEC3OPT3.Visible = false;
                LabelRespondEC3OPT.Visible = false;
            }
            else if ((ImageQueryEC3OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC3OPT.Visible = true;
                RAISEEC3OPT.ShowPopupWindow();
                QueryRaiseEC3OPT.Visible = false;
                TextBoxRaiseEC3OPT.Visible = false;
                PanelRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT2.Visible = true;
                PanelRaiseEC3OPT3.Visible = true;
                LabelRespondEC3OPT.Visible = false;
            }
            else
            {
                RAISEEC3OPT.Visible = true;
                RAISEEC3OPT.ShowPopupWindow();
                QueryRaiseEC3OPT.Visible = false;
                TextBoxRaiseEC3OPT.Visible = false;
                PanelRaiseEC3OPT.Visible = true;
                PanelRaiseEC3OPT2.Visible = true;
                PanelRaiseEC3OPT3.Visible = true;
                LabelRespondEC3OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseEC3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseEC3OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC3OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC3OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC3OPT = '" + RadioButtonListEC3OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEC3OPTMSG.ShowPopupWindow();
        RAISEEC3OPT.Visible = false;


    }
    #endregion
    #region QueryEC4OPT
    private void SetImageQueryEC4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEC4OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEC4OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEC4OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEC4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEC4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEC4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEC4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT2.Visible = false;
                PanelRaiseEC4OPT3.Visible = false;
                PanelHideEC4OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEC4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEC4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT2.Visible = true;
                PanelRaiseEC4OPT3.Visible = true;
                PanelHideEC4OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEC4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT2.Visible = true;
                PanelRaiseEC4OPT3.Visible = false;
                PanelHideEC4OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEC4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC4OPT = '" + RadioButtonListEC4OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEC4OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEC4OPT.Visible = true;
                RAISEEC4OPT.ShowPopupWindow();
                QueryRaiseEC4OPT.Visible = false;
                TextBoxRaiseEC4OPT.Visible = false;
                PanelRaiseEC4OPT.Visible = false;
                PanelRaiseEC4OPT2.Visible = false;
                PanelRaiseEC4OPT3.Visible = false;

                LabelRespondEC4OPT.Visible = false;
            }

            else if ((ImageQueryEC4OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC4OPT.Visible = true;
                RAISEEC4OPT.ShowPopupWindow();
                QueryRaiseEC4OPT.Visible = true;
                TextBoxRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT2.Visible = false;
                PanelRaiseEC4OPT3.Visible = false;
                LabelRespondEC4OPT.Visible = true;
            }

            else if ((ImageQueryEC4OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC4OPT.Visible = true;
                RAISEEC4OPT.ShowPopupWindow();
                QueryRaiseEC4OPT.Visible = false;
                TextBoxRaiseEC4OPT.Visible = false;
                PanelRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT2.Visible = true;
                PanelRaiseEC4OPT3.Visible = false;
                LabelRespondEC4OPT.Visible = false;
            }
            else if ((ImageQueryEC4OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC4OPT.Visible = true;
                RAISEEC4OPT.ShowPopupWindow();
                QueryRaiseEC4OPT.Visible = false;
                TextBoxRaiseEC4OPT.Visible = false;
                PanelRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT2.Visible = true;
                PanelRaiseEC4OPT3.Visible = true;
                LabelRespondEC4OPT.Visible = false;
            }
            else
            {
                RAISEEC4OPT.Visible = true;
                RAISEEC4OPT.ShowPopupWindow();
                QueryRaiseEC4OPT.Visible = false;
                TextBoxRaiseEC4OPT.Visible = false;
                PanelRaiseEC4OPT.Visible = true;
                PanelRaiseEC4OPT2.Visible = true;
                PanelRaiseEC4OPT3.Visible = true;
                LabelRespondEC4OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseEC4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseEC4OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC4OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC4OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC4OPT = '" + RadioButtonListEC4OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEC4OPTMSG.ShowPopupWindow();
        RAISEEC4OPT.Visible = false;


    }
    #endregion
    #region QueryEC5OPT
    private void SetImageQueryEC5OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEC5OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEC5OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEC5OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEC5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEC5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEC5OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEC5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT2.Visible = false;
                PanelRaiseEC5OPT3.Visible = false;
                PanelHideEC5OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEC5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEC5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT2.Visible = true;
                PanelRaiseEC5OPT3.Visible = true;
                PanelHideEC5OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEC5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT2.Visible = true;
                PanelRaiseEC5OPT3.Visible = false;
                PanelHideEC5OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEC5OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC5OPT = '" + RadioButtonListEC5OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEC5OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEC5OPT.Visible = true;
                RAISEEC5OPT.ShowPopupWindow();
                QueryRaiseEC5OPT.Visible = false;
                TextBoxRaiseEC5OPT.Visible = false;
                PanelRaiseEC5OPT.Visible = false;
                PanelRaiseEC5OPT2.Visible = false;
                PanelRaiseEC5OPT3.Visible = false;

                LabelRespondEC5OPT.Visible = false;
            }

            else if ((ImageQueryEC5OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC5OPT.Visible = true;
                RAISEEC5OPT.ShowPopupWindow();
                QueryRaiseEC5OPT.Visible = true;
                TextBoxRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT2.Visible = false;
                PanelRaiseEC5OPT3.Visible = false;
                LabelRespondEC5OPT.Visible = true;
            }

            else if ((ImageQueryEC5OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC5OPT.Visible = true;
                RAISEEC5OPT.ShowPopupWindow();
                QueryRaiseEC5OPT.Visible = false;
                TextBoxRaiseEC5OPT.Visible = false;
                PanelRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT2.Visible = true;
                PanelRaiseEC5OPT3.Visible = false;
                LabelRespondEC5OPT.Visible = false;
            }
            else if ((ImageQueryEC5OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC5OPT.Visible = true;
                RAISEEC5OPT.ShowPopupWindow();
                QueryRaiseEC5OPT.Visible = false;
                TextBoxRaiseEC5OPT.Visible = false;
                PanelRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT2.Visible = true;
                PanelRaiseEC5OPT3.Visible = true;
                LabelRespondEC5OPT.Visible = false;
            }
            else
            {
                RAISEEC5OPT.Visible = true;
                RAISEEC5OPT.ShowPopupWindow();
                QueryRaiseEC5OPT.Visible = false;
                TextBoxRaiseEC5OPT.Visible = false;
                PanelRaiseEC5OPT.Visible = true;
                PanelRaiseEC5OPT2.Visible = true;
                PanelRaiseEC5OPT3.Visible = true;
                LabelRespondEC5OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseEC5OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseEC5OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC5OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC5OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC5OPT = '" + RadioButtonListEC5OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEC5OPTMSG.ShowPopupWindow();
        RAISEEC5OPT.Visible = false;


    }
    #endregion
    #region QueryEC6OPT
    private void SetImageQueryEC6OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryEC6OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryEC6OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryEC6OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryEC6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryEC6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataEC6OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseEC6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT2.Visible = false;
                PanelRaiseEC6OPT3.Visible = false;
                PanelHideEC6OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseEC6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseEC6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT2.Visible = true;
                PanelRaiseEC6OPT3.Visible = true;
                PanelHideEC6OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseEC6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseEC6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT2.Visible = true;
                PanelRaiseEC6OPT3.Visible = false;
                PanelHideEC6OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryEC6OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC6OPT = '" + RadioButtonListEC6OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryEC6OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEEC6OPT.Visible = true;
                RAISEEC6OPT.ShowPopupWindow();
                QueryRaiseEC6OPT.Visible = false;
                TextBoxRaiseEC6OPT.Visible = false;
                PanelRaiseEC6OPT.Visible = false;
                PanelRaiseEC6OPT2.Visible = false;
                PanelRaiseEC6OPT3.Visible = false;

                LabelRespondEC6OPT.Visible = false;
            }

            else if ((ImageQueryEC6OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC6OPT.Visible = true;
                RAISEEC6OPT.ShowPopupWindow();
                QueryRaiseEC6OPT.Visible = true;
                TextBoxRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT2.Visible = false;
                PanelRaiseEC6OPT3.Visible = false;
                LabelRespondEC6OPT.Visible = true;
            }

            else if ((ImageQueryEC6OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC6OPT.Visible = true;
                RAISEEC6OPT.ShowPopupWindow();
                QueryRaiseEC6OPT.Visible = false;
                TextBoxRaiseEC6OPT.Visible = false;
                PanelRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT2.Visible = true;
                PanelRaiseEC6OPT3.Visible = false;
                LabelRespondEC6OPT.Visible = false;
            }
            else if ((ImageQueryEC6OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEEC6OPT.Visible = true;
                RAISEEC6OPT.ShowPopupWindow();
                QueryRaiseEC6OPT.Visible = false;
                TextBoxRaiseEC6OPT.Visible = false;
                PanelRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT2.Visible = true;
                PanelRaiseEC6OPT3.Visible = true;
                LabelRespondEC6OPT.Visible = false;
            }
            else
            {
                RAISEEC6OPT.Visible = true;
                RAISEEC6OPT.ShowPopupWindow();
                QueryRaiseEC6OPT.Visible = false;
                TextBoxRaiseEC6OPT.Visible = false;
                PanelRaiseEC6OPT.Visible = true;
                PanelRaiseEC6OPT2.Visible = true;
                PanelRaiseEC6OPT3.Visible = true;
                LabelRespondEC6OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseEC6OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseEC6OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC6OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblEC6OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and EC6OPT = '" + RadioButtonListEC6OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEEC6OPTMSG.ShowPopupWindow();
        RAISEEC6OPT.Visible = false;


    }
    #endregion
    #region QueryELIGL
    private void SetImageQueryELIGL()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblELIGL.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryELIGL.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryELIGL.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryELIGL.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryELIGL.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryELIGL.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataELIGL()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblELIGL.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseELIGL.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseELIGL.Visible = true;
                PanelRaiseELIGL2.Visible = false;
                PanelRaiseELIGL3.Visible = false;
                PanelHideELIGL.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseELIGL.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseELIGL2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseELIGL3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseELIGL.Visible = true;
                PanelRaiseELIGL2.Visible = true;
                PanelRaiseELIGL3.Visible = true;
                PanelHideELIGL.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseELIGL.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseELIGL2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseELIGL.Visible = true;
                PanelRaiseELIGL2.Visible = true;
                PanelRaiseELIGL3.Visible = false;
                PanelHideELIGL.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryELIGL_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ELIGL = '" + RadioButtonListELIGL.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryELIGL.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEELIGL.Visible = true;
                RAISEELIGL.ShowPopupWindow();
                QueryRaiseELIGL.Visible = false;
                TextBoxRaiseELIGL.Visible = false;
                PanelRaiseELIGL.Visible = false;
                PanelRaiseELIGL2.Visible = false;
                PanelRaiseELIGL3.Visible = false;

                LabelRespondELIGL.Visible = false;
            }

            else if ((ImageQueryELIGL.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEELIGL.Visible = true;
                RAISEELIGL.ShowPopupWindow();
                QueryRaiseELIGL.Visible = true;
                TextBoxRaiseELIGL.Visible = true;
                PanelRaiseELIGL.Visible = true;
                PanelRaiseELIGL2.Visible = false;
                PanelRaiseELIGL3.Visible = false;
                LabelRespondELIGL.Visible = true;
            }

            else if ((ImageQueryELIGL.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEELIGL.Visible = true;
                RAISEELIGL.ShowPopupWindow();
                QueryRaiseELIGL.Visible = false;
                TextBoxRaiseELIGL.Visible = false;
                PanelRaiseELIGL.Visible = true;
                PanelRaiseELIGL2.Visible = true;
                PanelRaiseELIGL3.Visible = false;
                LabelRespondELIGL.Visible = false;
            }
            else if ((ImageQueryELIGL.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEELIGL.Visible = true;
                RAISEELIGL.ShowPopupWindow();
                QueryRaiseELIGL.Visible = false;
                TextBoxRaiseELIGL.Visible = false;
                PanelRaiseELIGL.Visible = true;
                PanelRaiseELIGL2.Visible = true;
                PanelRaiseELIGL3.Visible = true;
                LabelRespondELIGL.Visible = false;
            }
            else
            {
                RAISEELIGL.Visible = true;
                RAISEELIGL.ShowPopupWindow();
                QueryRaiseELIGL.Visible = false;
                TextBoxRaiseELIGL.Visible = false;
                PanelRaiseELIGL.Visible = true;
                PanelRaiseELIGL2.Visible = true;
                PanelRaiseELIGL3.Visible = true;
                LabelRespondELIGL.Visible = false;

            }
        }

    }
    protected void QueryRaiseELIGL_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseELIGL.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblELIGL.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblELIGL.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and ELIGL = '" + RadioButtonListELIGL.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEELIGLMSG.ShowPopupWindow();
        RAISEELIGL.Visible = false;


    }
    #endregion
    #region QueryREMRK
    private void SetImageQueryREMRK()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblREMRK.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryREMRK.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryREMRK.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryREMRK.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryREMRK.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryREMRK.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataREMRK()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblREMRK.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseREMRK.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseREMRK.Visible = true;
                PanelRaiseREMRK2.Visible = false;
                PanelRaiseREMRK3.Visible = false;
                PanelHideREMRK.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseREMRK.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseREMRK2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseREMRK3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseREMRK.Visible = true;
                PanelRaiseREMRK2.Visible = true;
                PanelRaiseREMRK3.Visible = true;
                PanelHideREMRK.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseREMRK.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseREMRK2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseREMRK.Visible = true;
                PanelRaiseREMRK2.Visible = true;
                PanelRaiseREMRK3.Visible = false;
                PanelHideREMRK.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryREMRK_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[EligibilityCriteria] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and REMRK = '" + TextBoxREMRK.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryREMRK.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEREMRK.Visible = true;
                RAISEREMRK.ShowPopupWindow();
                QueryRaiseREMRK.Visible = false;
                TextBoxRaiseREMRK.Visible = false;
                PanelRaiseREMRK.Visible = false;
                PanelRaiseREMRK2.Visible = false;
                PanelRaiseREMRK3.Visible = false;

                LabelRespondREMRK.Visible = false;
            }

            else if ((ImageQueryREMRK.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEREMRK.Visible = true;
                RAISEREMRK.ShowPopupWindow();
                QueryRaiseREMRK.Visible = true;
                TextBoxRaiseREMRK.Visible = true;
                PanelRaiseREMRK.Visible = true;
                PanelRaiseREMRK2.Visible = false;
                PanelRaiseREMRK3.Visible = false;
                LabelRespondREMRK.Visible = true;
            }

            else if ((ImageQueryREMRK.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEREMRK.Visible = true;
                RAISEREMRK.ShowPopupWindow();
                QueryRaiseREMRK.Visible = false;
                TextBoxRaiseREMRK.Visible = false;
                PanelRaiseREMRK.Visible = true;
                PanelRaiseREMRK2.Visible = true;
                PanelRaiseREMRK3.Visible = false;
                LabelRespondREMRK.Visible = false;
            }
            else if ((ImageQueryREMRK.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEREMRK.Visible = true;
                RAISEREMRK.ShowPopupWindow();
                QueryRaiseREMRK.Visible = false;
                TextBoxRaiseREMRK.Visible = false;
                PanelRaiseREMRK.Visible = true;
                PanelRaiseREMRK2.Visible = true;
                PanelRaiseREMRK3.Visible = true;
                LabelRespondREMRK.Visible = false;
            }
            else
            {
                RAISEREMRK.Visible = true;
                RAISEREMRK.ShowPopupWindow();
                QueryRaiseREMRK.Visible = false;
                TextBoxRaiseREMRK.Visible = false;
                PanelRaiseREMRK.Visible = true;
                PanelRaiseREMRK2.Visible = true;
                PanelRaiseREMRK3.Visible = true;
                LabelRespondREMRK.Visible = false;

            }
        }

    }
    protected void QueryRaiseREMRK_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseREMRK.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblREMRK.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblREMRK.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[EligibilityCriteria] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and REMRK = '" + TextBoxREMRK.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEREMRKMSG.ShowPopupWindow();
        RAISEREMRK.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }


}