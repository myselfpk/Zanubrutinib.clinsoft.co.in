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

public partial class Data_Entry_Visit1_Beta_2_Microglobulin : System.Web.UI.Page
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

        SetImageQueryBTAOPT();
        SetImageQueryBTA1OPT();
        SetImageQueryBTA2OPT();
        SetImageQueryBTA3OPT();
        SetImageQueryBTA4OPT();
        SetImageQueryBTA5OPT();
        SetImageQueryBTA6OPT();
        SetImageQueryBTA7OPT();
        SetImageQueryBTA8OPT();
        SetImageQueryBTA9OPT();
        SetImageQueryBTA10OPT();

        BindQueryDataBTAOPT();
        BindQueryDataBTA1OPT();
        BindQueryDataBTA2OPT();
        BindQueryDataBTA3OPT();
        BindQueryDataBTA4OPT();
        BindQueryDataBTA5OPT();
        BindQueryDataBTA6OPT();
        BindQueryDataBTA7OPT();
        BindQueryDataBTA8OPT();
        BindQueryDataBTA9OPT();
        BindQueryDataBTA10OPT();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select BTAOPT , BTA1OPT , BTA2OPT , BTA3OPT , BTA4OPT , BTA5OPT , BTA6OPT , BTA7OPT , BTA8OPT , BTA9NM , BTA9OPT , BTA10NM , BTA10OPT from [Visit1].[Beta_2_Microglobulin] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListBTAOPT.SelectedValue = dt.Rows[0]["BTAOPT"].ToString().Trim();
            RadioButtonListBTA1OPT.SelectedValue = dt.Rows[0]["BTA1OPT"].ToString().Trim();
            RadioButtonListBTA2OPT.SelectedValue = dt.Rows[0]["BTA2OPT"].ToString().Trim();
            RadioButtonListBTA3OPT.SelectedValue = dt.Rows[0]["BTA3OPT"].ToString().Trim();
            RadioButtonListBTA4OPT.SelectedValue = dt.Rows[0]["BTA4OPT"].ToString().Trim();
            RadioButtonListBTA5OPT.SelectedValue = dt.Rows[0]["BTA5OPT"].ToString().Trim();
            RadioButtonListBTA6OPT.SelectedValue = dt.Rows[0]["BTA6OPT"].ToString().Trim();
            RadioButtonListBTA7OPT.SelectedValue = dt.Rows[0]["BTA7OPT"].ToString().Trim();
            RadioButtonListBTA8OPT.SelectedValue = dt.Rows[0]["BTA8OPT"].ToString().Trim();
            TextBoxBTA9NM.Text = dt.Rows[0]["BTA9NM"].ToString().Trim();
            RadioButtonListBTA9OPT.SelectedValue = dt.Rows[0]["BTA9OPT"].ToString().Trim();
            TextBoxBTA10NM.Text = dt.Rows[0]["BTA10NM"].ToString().Trim();
            RadioButtonListBTA10OPT.SelectedValue = dt.Rows[0]["BTA10OPT"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListBTAOPT.SelectedValue;
            ViewState["txt2"] = RadioButtonListBTA1OPT.SelectedValue;
            ViewState["txt3"] = RadioButtonListBTA2OPT.SelectedValue;
            ViewState["txt4"] = RadioButtonListBTA3OPT.SelectedValue;
            ViewState["txt5"] = RadioButtonListBTA4OPT.SelectedValue;
            ViewState["txt6"] = RadioButtonListBTA5OPT.SelectedValue;
            ViewState["txt7"] = RadioButtonListBTA6OPT.SelectedValue;
            ViewState["txt8"] = RadioButtonListBTA7OPT.SelectedValue;
            ViewState["txt9"] = RadioButtonListBTA8OPT.SelectedValue;
            ViewState["txt10"] = TextBoxBTA9NM.Text;
            ViewState["txt11"] = RadioButtonListBTA9OPT.SelectedValue;
            ViewState["txt12"] = TextBoxBTA10NM.Text;
            ViewState["txt13"] = RadioButtonListBTA10OPT.SelectedValue;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[Beta_2_Microglobulin] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[Beta_2_Microglobulin] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_Beta_2_Microglobulin]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@BTAOPT", RadioButtonListBTAOPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA1OPT", RadioButtonListBTA1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA2OPT", RadioButtonListBTA2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA3OPT", RadioButtonListBTA3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA4OPT", RadioButtonListBTA4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA5OPT", RadioButtonListBTA5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA6OPT", RadioButtonListBTA6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA7OPT", RadioButtonListBTA7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA8OPT", RadioButtonListBTA8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA9NM", TextBoxBTA9NM.Text);
                    cmd.Parameters.AddWithValue("@BTA9OPT", RadioButtonListBTA9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA10NM", TextBoxBTA10NM.Text);
                    cmd.Parameters.AddWithValue("@BTA10OPT", RadioButtonListBTA10OPT.SelectedValue);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[Beta_2_Microglobulin] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListBTAOPT.SelectedValue || ViewState["txt2"].ToString() != RadioButtonListBTA1OPT.SelectedValue || ViewState["txt3"].ToString() != RadioButtonListBTA2OPT.SelectedValue || ViewState["txt4"].ToString() != RadioButtonListBTA3OPT.SelectedValue || ViewState["txt5"].ToString() != RadioButtonListBTA4OPT.SelectedValue || ViewState["txt6"].ToString() != RadioButtonListBTA5OPT.SelectedValue || ViewState["txt7"].ToString() != RadioButtonListBTA6OPT.SelectedValue || ViewState["txt8"].ToString() != RadioButtonListBTA7OPT.SelectedValue || ViewState["txt9"].ToString() != RadioButtonListBTA8OPT.SelectedValue || ViewState["txt10"].ToString() != TextBoxBTA9NM.Text || ViewState["txt11"].ToString() != RadioButtonListBTA9OPT.SelectedValue || ViewState["txt12"].ToString() != TextBoxBTA10NM.Text || ViewState["txt13"].ToString() != RadioButtonListBTA10OPT.SelectedValue)
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
                cmd = new SqlCommand("[Visit1].[sp_Beta_2_Microglobulin]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@BTAOPT", RadioButtonListBTAOPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA1OPT", RadioButtonListBTA1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA2OPT", RadioButtonListBTA2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA3OPT", RadioButtonListBTA3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA4OPT", RadioButtonListBTA4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA5OPT", RadioButtonListBTA5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA6OPT", RadioButtonListBTA6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA7OPT", RadioButtonListBTA7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA8OPT", RadioButtonListBTA8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA9NM", TextBoxBTA9NM.Text);
                cmd.Parameters.AddWithValue("@BTA9OPT", RadioButtonListBTA9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA10NM", TextBoxBTA10NM.Text);
                cmd.Parameters.AddWithValue("@BTA10OPT", RadioButtonListBTA10OPT.SelectedValue);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[Beta_2_Microglobulin] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_Beta_2_Microglobulin]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@BTAOPT", RadioButtonListBTAOPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA1OPT", RadioButtonListBTA1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA2OPT", RadioButtonListBTA2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA3OPT", RadioButtonListBTA3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA4OPT", RadioButtonListBTA4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA5OPT", RadioButtonListBTA5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA6OPT", RadioButtonListBTA6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA7OPT", RadioButtonListBTA7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA8OPT", RadioButtonListBTA8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA9NM", TextBoxBTA9NM.Text);
                    cmd.Parameters.AddWithValue("@BTA9OPT", RadioButtonListBTA9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@BTA10NM", TextBoxBTA10NM.Text);
                    cmd.Parameters.AddWithValue("@BTA10OPT", RadioButtonListBTA10OPT.SelectedValue);

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
                cmd = new SqlCommand("[Visit1].[sp_Beta_2_Microglobulin]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@BTAOPT", RadioButtonListBTAOPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA1OPT", RadioButtonListBTA1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA2OPT", RadioButtonListBTA2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA3OPT", RadioButtonListBTA3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA4OPT", RadioButtonListBTA4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA5OPT", RadioButtonListBTA5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA6OPT", RadioButtonListBTA6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA7OPT", RadioButtonListBTA7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA8OPT", RadioButtonListBTA8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA9NM", TextBoxBTA9NM.Text);
                cmd.Parameters.AddWithValue("@BTA9OPT", RadioButtonListBTA9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@BTA10NM", TextBoxBTA10NM.Text);
                cmd.Parameters.AddWithValue("@BTA10OPT", RadioButtonListBTA10OPT.SelectedValue);

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
        if (!string.IsNullOrEmpty(RadioButtonListBTAOPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA4OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA5OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA6OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA7OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListBTA8OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxBTA9NM.Text) || !string.IsNullOrEmpty(RadioButtonListBTA9OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxBTA10NM.Text) || !string.IsNullOrEmpty(RadioButtonListBTA10OPT.SelectedValue))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() !=  RadioButtonListBTAOPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTAOPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListBTAOPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() !=  RadioButtonListBTA1OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = RadioButtonListBTA1OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() !=  RadioButtonListBTA2OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = RadioButtonListBTA2OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() !=  RadioButtonListBTA3OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListBTA3OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() !=  RadioButtonListBTA4OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListBTA4OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() !=  RadioButtonListBTA5OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = RadioButtonListBTA5OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() !=  RadioButtonListBTA6OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListBTA6OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() !=  RadioButtonListBTA7OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA7OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListBTA7OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() !=  RadioButtonListBTA8OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA8OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListBTA8OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != TextBoxBTA9NM.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA9NM.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = TextBoxBTA9NM.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != RadioButtonListBTA9OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA9OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = RadioButtonListBTA9OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != TextBoxBTA10NM.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA10NM.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = TextBoxBTA10NM.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != RadioButtonListBTA10OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblBTA10OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = RadioButtonListBTA10OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_Beta_2_Microglobulin]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@BTAOPT", RadioButtonListBTAOPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA1OPT", RadioButtonListBTA1OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA2OPT", RadioButtonListBTA2OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA3OPT", RadioButtonListBTA3OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA4OPT", RadioButtonListBTA4OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA5OPT", RadioButtonListBTA5OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA6OPT", RadioButtonListBTA6OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA7OPT", RadioButtonListBTA7OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA8OPT", RadioButtonListBTA8OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA9NM", TextBoxBTA9NM.Text);
            cmd.Parameters.AddWithValue("@BTA9OPT", RadioButtonListBTA9OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@BTA10NM", TextBoxBTA10NM.Text);
            cmd.Parameters.AddWithValue("@BTA10OPT", RadioButtonListBTA10OPT.SelectedValue);

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
    #region QueryBTAOPT
    private void SetImageQueryBTAOPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTAOPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTAOPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTAOPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTAOPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTAOPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTAOPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTAOPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTAOPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTAOPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT2.Visible = false;
                PanelRaiseBTAOPT3.Visible = false;
                PanelHideBTAOPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTAOPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTAOPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTAOPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT2.Visible = true;
                PanelRaiseBTAOPT3.Visible = true;
                PanelHideBTAOPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTAOPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTAOPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT2.Visible = true;
                PanelRaiseBTAOPT3.Visible = false;
                PanelHideBTAOPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTAOPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTAOPT = '" + RadioButtonListBTAOPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTAOPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTAOPT.Visible = true;
                RAISEBTAOPT.ShowPopupWindow();
                QueryRaiseBTAOPT.Visible = false;
                TextBoxRaiseBTAOPT.Visible = false;
                PanelRaiseBTAOPT.Visible = false;
                PanelRaiseBTAOPT2.Visible = false;
                PanelRaiseBTAOPT3.Visible = false;

                LabelRespondBTAOPT.Visible = false;
            }

            else if ((ImageQueryBTAOPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTAOPT.Visible = true;
                RAISEBTAOPT.ShowPopupWindow();
                QueryRaiseBTAOPT.Visible = true;
                TextBoxRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT2.Visible = false;
                PanelRaiseBTAOPT3.Visible = false;
                LabelRespondBTAOPT.Visible = true;
            }

            else if ((ImageQueryBTAOPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTAOPT.Visible = true;
                RAISEBTAOPT.ShowPopupWindow();
                QueryRaiseBTAOPT.Visible = false;
                TextBoxRaiseBTAOPT.Visible = false;
                PanelRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT2.Visible = true;
                PanelRaiseBTAOPT3.Visible = false;
                LabelRespondBTAOPT.Visible = false;
            }
            else if ((ImageQueryBTAOPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTAOPT.Visible = true;
                RAISEBTAOPT.ShowPopupWindow();
                QueryRaiseBTAOPT.Visible = false;
                TextBoxRaiseBTAOPT.Visible = false;
                PanelRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT2.Visible = true;
                PanelRaiseBTAOPT3.Visible = true;
                LabelRespondBTAOPT.Visible = false;
            }
            else
            {
                RAISEBTAOPT.Visible = true;
                RAISEBTAOPT.ShowPopupWindow();
                QueryRaiseBTAOPT.Visible = false;
                TextBoxRaiseBTAOPT.Visible = false;
                PanelRaiseBTAOPT.Visible = true;
                PanelRaiseBTAOPT2.Visible = true;
                PanelRaiseBTAOPT3.Visible = true;
                LabelRespondBTAOPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTAOPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTAOPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTAOPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTAOPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTAOPT = '" + RadioButtonListBTAOPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTAOPTMSG.ShowPopupWindow();
        RAISEBTAOPT.Visible = false;


    }
    #endregion
    #region QueryBTA1OPT
    private void SetImageQueryBTA1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA1OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA1OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA1OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT2.Visible = false;
                PanelRaiseBTA1OPT3.Visible = false;
                PanelHideBTA1OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT2.Visible = true;
                PanelRaiseBTA1OPT3.Visible = true;
                PanelHideBTA1OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT2.Visible = true;
                PanelRaiseBTA1OPT3.Visible = false;
                PanelHideBTA1OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA1OPT = '" + RadioButtonListBTA1OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA1OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA1OPT.Visible = true;
                RAISEBTA1OPT.ShowPopupWindow();
                QueryRaiseBTA1OPT.Visible = false;
                TextBoxRaiseBTA1OPT.Visible = false;
                PanelRaiseBTA1OPT.Visible = false;
                PanelRaiseBTA1OPT2.Visible = false;
                PanelRaiseBTA1OPT3.Visible = false;

                LabelRespondBTA1OPT.Visible = false;
            }

            else if ((ImageQueryBTA1OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA1OPT.Visible = true;
                RAISEBTA1OPT.ShowPopupWindow();
                QueryRaiseBTA1OPT.Visible = true;
                TextBoxRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT2.Visible = false;
                PanelRaiseBTA1OPT3.Visible = false;
                LabelRespondBTA1OPT.Visible = true;
            }

            else if ((ImageQueryBTA1OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA1OPT.Visible = true;
                RAISEBTA1OPT.ShowPopupWindow();
                QueryRaiseBTA1OPT.Visible = false;
                TextBoxRaiseBTA1OPT.Visible = false;
                PanelRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT2.Visible = true;
                PanelRaiseBTA1OPT3.Visible = false;
                LabelRespondBTA1OPT.Visible = false;
            }
            else if ((ImageQueryBTA1OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA1OPT.Visible = true;
                RAISEBTA1OPT.ShowPopupWindow();
                QueryRaiseBTA1OPT.Visible = false;
                TextBoxRaiseBTA1OPT.Visible = false;
                PanelRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT2.Visible = true;
                PanelRaiseBTA1OPT3.Visible = true;
                LabelRespondBTA1OPT.Visible = false;
            }
            else
            {
                RAISEBTA1OPT.Visible = true;
                RAISEBTA1OPT.ShowPopupWindow();
                QueryRaiseBTA1OPT.Visible = false;
                TextBoxRaiseBTA1OPT.Visible = false;
                PanelRaiseBTA1OPT.Visible = true;
                PanelRaiseBTA1OPT2.Visible = true;
                PanelRaiseBTA1OPT3.Visible = true;
                LabelRespondBTA1OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA1OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA1OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA1OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA1OPT = '" + RadioButtonListBTA1OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA1OPTMSG.ShowPopupWindow();
        RAISEBTA1OPT.Visible = false;


    }
    #endregion
    #region QueryBTA2OPT
    private void SetImageQueryBTA2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA2OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA2OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA2OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT2.Visible = false;
                PanelRaiseBTA2OPT3.Visible = false;
                PanelHideBTA2OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT2.Visible = true;
                PanelRaiseBTA2OPT3.Visible = true;
                PanelHideBTA2OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT2.Visible = true;
                PanelRaiseBTA2OPT3.Visible = false;
                PanelHideBTA2OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA2OPT = '" + RadioButtonListBTA2OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA2OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA2OPT.Visible = true;
                RAISEBTA2OPT.ShowPopupWindow();
                QueryRaiseBTA2OPT.Visible = false;
                TextBoxRaiseBTA2OPT.Visible = false;
                PanelRaiseBTA2OPT.Visible = false;
                PanelRaiseBTA2OPT2.Visible = false;
                PanelRaiseBTA2OPT3.Visible = false;

                LabelRespondBTA2OPT.Visible = false;
            }

            else if ((ImageQueryBTA2OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA2OPT.Visible = true;
                RAISEBTA2OPT.ShowPopupWindow();
                QueryRaiseBTA2OPT.Visible = true;
                TextBoxRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT2.Visible = false;
                PanelRaiseBTA2OPT3.Visible = false;
                LabelRespondBTA2OPT.Visible = true;
            }

            else if ((ImageQueryBTA2OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA2OPT.Visible = true;
                RAISEBTA2OPT.ShowPopupWindow();
                QueryRaiseBTA2OPT.Visible = false;
                TextBoxRaiseBTA2OPT.Visible = false;
                PanelRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT2.Visible = true;
                PanelRaiseBTA2OPT3.Visible = false;
                LabelRespondBTA2OPT.Visible = false;
            }
            else if ((ImageQueryBTA2OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA2OPT.Visible = true;
                RAISEBTA2OPT.ShowPopupWindow();
                QueryRaiseBTA2OPT.Visible = false;
                TextBoxRaiseBTA2OPT.Visible = false;
                PanelRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT2.Visible = true;
                PanelRaiseBTA2OPT3.Visible = true;
                LabelRespondBTA2OPT.Visible = false;
            }
            else
            {
                RAISEBTA2OPT.Visible = true;
                RAISEBTA2OPT.ShowPopupWindow();
                QueryRaiseBTA2OPT.Visible = false;
                TextBoxRaiseBTA2OPT.Visible = false;
                PanelRaiseBTA2OPT.Visible = true;
                PanelRaiseBTA2OPT2.Visible = true;
                PanelRaiseBTA2OPT3.Visible = true;
                LabelRespondBTA2OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA2OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA2OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA2OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA2OPT = '" + RadioButtonListBTA2OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA2OPTMSG.ShowPopupWindow();
        RAISEBTA2OPT.Visible = false;


    }
    #endregion
    #region QueryBTA3OPT
    private void SetImageQueryBTA3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA3OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA3OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA3OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT2.Visible = false;
                PanelRaiseBTA3OPT3.Visible = false;
                PanelHideBTA3OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT2.Visible = true;
                PanelRaiseBTA3OPT3.Visible = true;
                PanelHideBTA3OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT2.Visible = true;
                PanelRaiseBTA3OPT3.Visible = false;
                PanelHideBTA3OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA3OPT = '" + RadioButtonListBTA3OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA3OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA3OPT.Visible = true;
                RAISEBTA3OPT.ShowPopupWindow();
                QueryRaiseBTA3OPT.Visible = false;
                TextBoxRaiseBTA3OPT.Visible = false;
                PanelRaiseBTA3OPT.Visible = false;
                PanelRaiseBTA3OPT2.Visible = false;
                PanelRaiseBTA3OPT3.Visible = false;

                LabelRespondBTA3OPT.Visible = false;
            }

            else if ((ImageQueryBTA3OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA3OPT.Visible = true;
                RAISEBTA3OPT.ShowPopupWindow();
                QueryRaiseBTA3OPT.Visible = true;
                TextBoxRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT2.Visible = false;
                PanelRaiseBTA3OPT3.Visible = false;
                LabelRespondBTA3OPT.Visible = true;
            }

            else if ((ImageQueryBTA3OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA3OPT.Visible = true;
                RAISEBTA3OPT.ShowPopupWindow();
                QueryRaiseBTA3OPT.Visible = false;
                TextBoxRaiseBTA3OPT.Visible = false;
                PanelRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT2.Visible = true;
                PanelRaiseBTA3OPT3.Visible = false;
                LabelRespondBTA3OPT.Visible = false;
            }
            else if ((ImageQueryBTA3OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA3OPT.Visible = true;
                RAISEBTA3OPT.ShowPopupWindow();
                QueryRaiseBTA3OPT.Visible = false;
                TextBoxRaiseBTA3OPT.Visible = false;
                PanelRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT2.Visible = true;
                PanelRaiseBTA3OPT3.Visible = true;
                LabelRespondBTA3OPT.Visible = false;
            }
            else
            {
                RAISEBTA3OPT.Visible = true;
                RAISEBTA3OPT.ShowPopupWindow();
                QueryRaiseBTA3OPT.Visible = false;
                TextBoxRaiseBTA3OPT.Visible = false;
                PanelRaiseBTA3OPT.Visible = true;
                PanelRaiseBTA3OPT2.Visible = true;
                PanelRaiseBTA3OPT3.Visible = true;
                LabelRespondBTA3OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA3OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA3OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA3OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA3OPT = '" + RadioButtonListBTA3OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA3OPTMSG.ShowPopupWindow();
        RAISEBTA3OPT.Visible = false;


    }
    #endregion
    #region QueryBTA4OPT
    private void SetImageQueryBTA4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA4OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA4OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA4OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT2.Visible = false;
                PanelRaiseBTA4OPT3.Visible = false;
                PanelHideBTA4OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT2.Visible = true;
                PanelRaiseBTA4OPT3.Visible = true;
                PanelHideBTA4OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT2.Visible = true;
                PanelRaiseBTA4OPT3.Visible = false;
                PanelHideBTA4OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA4OPT = '" + RadioButtonListBTA4OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA4OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA4OPT.Visible = true;
                RAISEBTA4OPT.ShowPopupWindow();
                QueryRaiseBTA4OPT.Visible = false;
                TextBoxRaiseBTA4OPT.Visible = false;
                PanelRaiseBTA4OPT.Visible = false;
                PanelRaiseBTA4OPT2.Visible = false;
                PanelRaiseBTA4OPT3.Visible = false;

                LabelRespondBTA4OPT.Visible = false;
            }

            else if ((ImageQueryBTA4OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA4OPT.Visible = true;
                RAISEBTA4OPT.ShowPopupWindow();
                QueryRaiseBTA4OPT.Visible = true;
                TextBoxRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT2.Visible = false;
                PanelRaiseBTA4OPT3.Visible = false;
                LabelRespondBTA4OPT.Visible = true;
            }

            else if ((ImageQueryBTA4OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA4OPT.Visible = true;
                RAISEBTA4OPT.ShowPopupWindow();
                QueryRaiseBTA4OPT.Visible = false;
                TextBoxRaiseBTA4OPT.Visible = false;
                PanelRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT2.Visible = true;
                PanelRaiseBTA4OPT3.Visible = false;
                LabelRespondBTA4OPT.Visible = false;
            }
            else if ((ImageQueryBTA4OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA4OPT.Visible = true;
                RAISEBTA4OPT.ShowPopupWindow();
                QueryRaiseBTA4OPT.Visible = false;
                TextBoxRaiseBTA4OPT.Visible = false;
                PanelRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT2.Visible = true;
                PanelRaiseBTA4OPT3.Visible = true;
                LabelRespondBTA4OPT.Visible = false;
            }
            else
            {
                RAISEBTA4OPT.Visible = true;
                RAISEBTA4OPT.ShowPopupWindow();
                QueryRaiseBTA4OPT.Visible = false;
                TextBoxRaiseBTA4OPT.Visible = false;
                PanelRaiseBTA4OPT.Visible = true;
                PanelRaiseBTA4OPT2.Visible = true;
                PanelRaiseBTA4OPT3.Visible = true;
                LabelRespondBTA4OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA4OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA4OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA4OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA4OPT = '" + RadioButtonListBTA4OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA4OPTMSG.ShowPopupWindow();
        RAISEBTA4OPT.Visible = false;


    }
    #endregion
    #region QueryBTA5OPT
    private void SetImageQueryBTA5OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA5OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA5OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA5OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA5OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT2.Visible = false;
                PanelRaiseBTA5OPT3.Visible = false;
                PanelHideBTA5OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT2.Visible = true;
                PanelRaiseBTA5OPT3.Visible = true;
                PanelHideBTA5OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT2.Visible = true;
                PanelRaiseBTA5OPT3.Visible = false;
                PanelHideBTA5OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA5OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA5OPT = '" + RadioButtonListBTA5OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA5OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA5OPT.Visible = true;
                RAISEBTA5OPT.ShowPopupWindow();
                QueryRaiseBTA5OPT.Visible = false;
                TextBoxRaiseBTA5OPT.Visible = false;
                PanelRaiseBTA5OPT.Visible = false;
                PanelRaiseBTA5OPT2.Visible = false;
                PanelRaiseBTA5OPT3.Visible = false;

                LabelRespondBTA5OPT.Visible = false;
            }

            else if ((ImageQueryBTA5OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA5OPT.Visible = true;
                RAISEBTA5OPT.ShowPopupWindow();
                QueryRaiseBTA5OPT.Visible = true;
                TextBoxRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT2.Visible = false;
                PanelRaiseBTA5OPT3.Visible = false;
                LabelRespondBTA5OPT.Visible = true;
            }

            else if ((ImageQueryBTA5OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA5OPT.Visible = true;
                RAISEBTA5OPT.ShowPopupWindow();
                QueryRaiseBTA5OPT.Visible = false;
                TextBoxRaiseBTA5OPT.Visible = false;
                PanelRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT2.Visible = true;
                PanelRaiseBTA5OPT3.Visible = false;
                LabelRespondBTA5OPT.Visible = false;
            }
            else if ((ImageQueryBTA5OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA5OPT.Visible = true;
                RAISEBTA5OPT.ShowPopupWindow();
                QueryRaiseBTA5OPT.Visible = false;
                TextBoxRaiseBTA5OPT.Visible = false;
                PanelRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT2.Visible = true;
                PanelRaiseBTA5OPT3.Visible = true;
                LabelRespondBTA5OPT.Visible = false;
            }
            else
            {
                RAISEBTA5OPT.Visible = true;
                RAISEBTA5OPT.ShowPopupWindow();
                QueryRaiseBTA5OPT.Visible = false;
                TextBoxRaiseBTA5OPT.Visible = false;
                PanelRaiseBTA5OPT.Visible = true;
                PanelRaiseBTA5OPT2.Visible = true;
                PanelRaiseBTA5OPT3.Visible = true;
                LabelRespondBTA5OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA5OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA5OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA5OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA5OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA5OPT = '" + RadioButtonListBTA5OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA5OPTMSG.ShowPopupWindow();
        RAISEBTA5OPT.Visible = false;


    }
    #endregion
    #region QueryBTA6OPT
    private void SetImageQueryBTA6OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA6OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA6OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA6OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA6OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT2.Visible = false;
                PanelRaiseBTA6OPT3.Visible = false;
                PanelHideBTA6OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT2.Visible = true;
                PanelRaiseBTA6OPT3.Visible = true;
                PanelHideBTA6OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT2.Visible = true;
                PanelRaiseBTA6OPT3.Visible = false;
                PanelHideBTA6OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA6OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA6OPT = '" + RadioButtonListBTA6OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA6OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA6OPT.Visible = true;
                RAISEBTA6OPT.ShowPopupWindow();
                QueryRaiseBTA6OPT.Visible = false;
                TextBoxRaiseBTA6OPT.Visible = false;
                PanelRaiseBTA6OPT.Visible = false;
                PanelRaiseBTA6OPT2.Visible = false;
                PanelRaiseBTA6OPT3.Visible = false;

                LabelRespondBTA6OPT.Visible = false;
            }

            else if ((ImageQueryBTA6OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA6OPT.Visible = true;
                RAISEBTA6OPT.ShowPopupWindow();
                QueryRaiseBTA6OPT.Visible = true;
                TextBoxRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT2.Visible = false;
                PanelRaiseBTA6OPT3.Visible = false;
                LabelRespondBTA6OPT.Visible = true;
            }

            else if ((ImageQueryBTA6OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA6OPT.Visible = true;
                RAISEBTA6OPT.ShowPopupWindow();
                QueryRaiseBTA6OPT.Visible = false;
                TextBoxRaiseBTA6OPT.Visible = false;
                PanelRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT2.Visible = true;
                PanelRaiseBTA6OPT3.Visible = false;
                LabelRespondBTA6OPT.Visible = false;
            }
            else if ((ImageQueryBTA6OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA6OPT.Visible = true;
                RAISEBTA6OPT.ShowPopupWindow();
                QueryRaiseBTA6OPT.Visible = false;
                TextBoxRaiseBTA6OPT.Visible = false;
                PanelRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT2.Visible = true;
                PanelRaiseBTA6OPT3.Visible = true;
                LabelRespondBTA6OPT.Visible = false;
            }
            else
            {
                RAISEBTA6OPT.Visible = true;
                RAISEBTA6OPT.ShowPopupWindow();
                QueryRaiseBTA6OPT.Visible = false;
                TextBoxRaiseBTA6OPT.Visible = false;
                PanelRaiseBTA6OPT.Visible = true;
                PanelRaiseBTA6OPT2.Visible = true;
                PanelRaiseBTA6OPT3.Visible = true;
                LabelRespondBTA6OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA6OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA6OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA6OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA6OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA6OPT = '" + RadioButtonListBTA6OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA6OPTMSG.ShowPopupWindow();
        RAISEBTA6OPT.Visible = false;


    }
    #endregion
    #region QueryBTA7OPT
    private void SetImageQueryBTA7OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA7OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA7OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA7OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA7OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT2.Visible = false;
                PanelRaiseBTA7OPT3.Visible = false;
                PanelHideBTA7OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT2.Visible = true;
                PanelRaiseBTA7OPT3.Visible = true;
                PanelHideBTA7OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT2.Visible = true;
                PanelRaiseBTA7OPT3.Visible = false;
                PanelHideBTA7OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA7OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA7OPT = '" + RadioButtonListBTA7OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA7OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA7OPT.Visible = true;
                RAISEBTA7OPT.ShowPopupWindow();
                QueryRaiseBTA7OPT.Visible = false;
                TextBoxRaiseBTA7OPT.Visible = false;
                PanelRaiseBTA7OPT.Visible = false;
                PanelRaiseBTA7OPT2.Visible = false;
                PanelRaiseBTA7OPT3.Visible = false;

                LabelRespondBTA7OPT.Visible = false;
            }

            else if ((ImageQueryBTA7OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA7OPT.Visible = true;
                RAISEBTA7OPT.ShowPopupWindow();
                QueryRaiseBTA7OPT.Visible = true;
                TextBoxRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT2.Visible = false;
                PanelRaiseBTA7OPT3.Visible = false;
                LabelRespondBTA7OPT.Visible = true;
            }

            else if ((ImageQueryBTA7OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA7OPT.Visible = true;
                RAISEBTA7OPT.ShowPopupWindow();
                QueryRaiseBTA7OPT.Visible = false;
                TextBoxRaiseBTA7OPT.Visible = false;
                PanelRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT2.Visible = true;
                PanelRaiseBTA7OPT3.Visible = false;
                LabelRespondBTA7OPT.Visible = false;
            }
            else if ((ImageQueryBTA7OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA7OPT.Visible = true;
                RAISEBTA7OPT.ShowPopupWindow();
                QueryRaiseBTA7OPT.Visible = false;
                TextBoxRaiseBTA7OPT.Visible = false;
                PanelRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT2.Visible = true;
                PanelRaiseBTA7OPT3.Visible = true;
                LabelRespondBTA7OPT.Visible = false;
            }
            else
            {
                RAISEBTA7OPT.Visible = true;
                RAISEBTA7OPT.ShowPopupWindow();
                QueryRaiseBTA7OPT.Visible = false;
                TextBoxRaiseBTA7OPT.Visible = false;
                PanelRaiseBTA7OPT.Visible = true;
                PanelRaiseBTA7OPT2.Visible = true;
                PanelRaiseBTA7OPT3.Visible = true;
                LabelRespondBTA7OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA7OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA7OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA7OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA7OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA7OPT = '" + RadioButtonListBTA7OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA7OPTMSG.ShowPopupWindow();
        RAISEBTA7OPT.Visible = false;


    }
    #endregion
    #region QueryBTA8OPT
    private void SetImageQueryBTA8OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA8OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA8OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA8OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA8OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT2.Visible = false;
                PanelRaiseBTA8OPT3.Visible = false;
                PanelHideBTA8OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT2.Visible = true;
                PanelRaiseBTA8OPT3.Visible = true;
                PanelHideBTA8OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT2.Visible = true;
                PanelRaiseBTA8OPT3.Visible = false;
                PanelHideBTA8OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA8OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA8OPT = '" + RadioButtonListBTA8OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA8OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA8OPT.Visible = true;
                RAISEBTA8OPT.ShowPopupWindow();
                QueryRaiseBTA8OPT.Visible = false;
                TextBoxRaiseBTA8OPT.Visible = false;
                PanelRaiseBTA8OPT.Visible = false;
                PanelRaiseBTA8OPT2.Visible = false;
                PanelRaiseBTA8OPT3.Visible = false;

                LabelRespondBTA8OPT.Visible = false;
            }

            else if ((ImageQueryBTA8OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA8OPT.Visible = true;
                RAISEBTA8OPT.ShowPopupWindow();
                QueryRaiseBTA8OPT.Visible = true;
                TextBoxRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT2.Visible = false;
                PanelRaiseBTA8OPT3.Visible = false;
                LabelRespondBTA8OPT.Visible = true;
            }

            else if ((ImageQueryBTA8OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA8OPT.Visible = true;
                RAISEBTA8OPT.ShowPopupWindow();
                QueryRaiseBTA8OPT.Visible = false;
                TextBoxRaiseBTA8OPT.Visible = false;
                PanelRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT2.Visible = true;
                PanelRaiseBTA8OPT3.Visible = false;
                LabelRespondBTA8OPT.Visible = false;
            }
            else if ((ImageQueryBTA8OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA8OPT.Visible = true;
                RAISEBTA8OPT.ShowPopupWindow();
                QueryRaiseBTA8OPT.Visible = false;
                TextBoxRaiseBTA8OPT.Visible = false;
                PanelRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT2.Visible = true;
                PanelRaiseBTA8OPT3.Visible = true;
                LabelRespondBTA8OPT.Visible = false;
            }
            else
            {
                RAISEBTA8OPT.Visible = true;
                RAISEBTA8OPT.ShowPopupWindow();
                QueryRaiseBTA8OPT.Visible = false;
                TextBoxRaiseBTA8OPT.Visible = false;
                PanelRaiseBTA8OPT.Visible = true;
                PanelRaiseBTA8OPT2.Visible = true;
                PanelRaiseBTA8OPT3.Visible = true;
                LabelRespondBTA8OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA8OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA8OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA8OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA8OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA8OPT = '" + RadioButtonListBTA8OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA8OPTMSG.ShowPopupWindow();
        RAISEBTA8OPT.Visible = false;


    }
    #endregion
    #region QueryBTA9OPT
    private void SetImageQueryBTA9OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA9OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA9OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA9OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA9OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT2.Visible = false;
                PanelRaiseBTA9OPT3.Visible = false;
                PanelHideBTA9OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT2.Visible = true;
                PanelRaiseBTA9OPT3.Visible = true;
                PanelHideBTA9OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT2.Visible = true;
                PanelRaiseBTA9OPT3.Visible = false;
                PanelHideBTA9OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA9OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA9OPT = '" + RadioButtonListBTA9OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA9OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA9OPT.Visible = true;
                RAISEBTA9OPT.ShowPopupWindow();
                QueryRaiseBTA9OPT.Visible = false;
                TextBoxRaiseBTA9OPT.Visible = false;
                PanelRaiseBTA9OPT.Visible = false;
                PanelRaiseBTA9OPT2.Visible = false;
                PanelRaiseBTA9OPT3.Visible = false;

                LabelRespondBTA9OPT.Visible = false;
            }

            else if ((ImageQueryBTA9OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA9OPT.Visible = true;
                RAISEBTA9OPT.ShowPopupWindow();
                QueryRaiseBTA9OPT.Visible = true;
                TextBoxRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT2.Visible = false;
                PanelRaiseBTA9OPT3.Visible = false;
                LabelRespondBTA9OPT.Visible = true;
            }

            else if ((ImageQueryBTA9OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA9OPT.Visible = true;
                RAISEBTA9OPT.ShowPopupWindow();
                QueryRaiseBTA9OPT.Visible = false;
                TextBoxRaiseBTA9OPT.Visible = false;
                PanelRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT2.Visible = true;
                PanelRaiseBTA9OPT3.Visible = false;
                LabelRespondBTA9OPT.Visible = false;
            }
            else if ((ImageQueryBTA9OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA9OPT.Visible = true;
                RAISEBTA9OPT.ShowPopupWindow();
                QueryRaiseBTA9OPT.Visible = false;
                TextBoxRaiseBTA9OPT.Visible = false;
                PanelRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT2.Visible = true;
                PanelRaiseBTA9OPT3.Visible = true;
                LabelRespondBTA9OPT.Visible = false;
            }
            else
            {
                RAISEBTA9OPT.Visible = true;
                RAISEBTA9OPT.ShowPopupWindow();
                QueryRaiseBTA9OPT.Visible = false;
                TextBoxRaiseBTA9OPT.Visible = false;
                PanelRaiseBTA9OPT.Visible = true;
                PanelRaiseBTA9OPT2.Visible = true;
                PanelRaiseBTA9OPT3.Visible = true;
                LabelRespondBTA9OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA9OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA9OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA9OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA9OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA9OPT = '" + RadioButtonListBTA9OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA9OPTMSG.ShowPopupWindow();
        RAISEBTA9OPT.Visible = false;


    }
    #endregion
    #region QueryBTA10OPT
    private void SetImageQueryBTA10OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryBTA10OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryBTA10OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryBTA10OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryBTA10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryBTA10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataBTA10OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseBTA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT2.Visible = false;
                PanelRaiseBTA10OPT3.Visible = false;
                PanelHideBTA10OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseBTA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseBTA10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT2.Visible = true;
                PanelRaiseBTA10OPT3.Visible = true;
                PanelHideBTA10OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseBTA10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseBTA10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT2.Visible = true;
                PanelRaiseBTA10OPT3.Visible = false;
                PanelHideBTA10OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryBTA10OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[Beta_2_Microglobulin] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA10OPT = '" + RadioButtonListBTA10OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryBTA10OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEBTA10OPT.Visible = true;
                RAISEBTA10OPT.ShowPopupWindow();
                QueryRaiseBTA10OPT.Visible = false;
                TextBoxRaiseBTA10OPT.Visible = false;
                PanelRaiseBTA10OPT.Visible = false;
                PanelRaiseBTA10OPT2.Visible = false;
                PanelRaiseBTA10OPT3.Visible = false;

                LabelRespondBTA10OPT.Visible = false;
            }

            else if ((ImageQueryBTA10OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA10OPT.Visible = true;
                RAISEBTA10OPT.ShowPopupWindow();
                QueryRaiseBTA10OPT.Visible = true;
                TextBoxRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT2.Visible = false;
                PanelRaiseBTA10OPT3.Visible = false;
                LabelRespondBTA10OPT.Visible = true;
            }

            else if ((ImageQueryBTA10OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA10OPT.Visible = true;
                RAISEBTA10OPT.ShowPopupWindow();
                QueryRaiseBTA10OPT.Visible = false;
                TextBoxRaiseBTA10OPT.Visible = false;
                PanelRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT2.Visible = true;
                PanelRaiseBTA10OPT3.Visible = false;
                LabelRespondBTA10OPT.Visible = false;
            }
            else if ((ImageQueryBTA10OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEBTA10OPT.Visible = true;
                RAISEBTA10OPT.ShowPopupWindow();
                QueryRaiseBTA10OPT.Visible = false;
                TextBoxRaiseBTA10OPT.Visible = false;
                PanelRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT2.Visible = true;
                PanelRaiseBTA10OPT3.Visible = true;
                LabelRespondBTA10OPT.Visible = false;
            }
            else
            {
                RAISEBTA10OPT.Visible = true;
                RAISEBTA10OPT.ShowPopupWindow();
                QueryRaiseBTA10OPT.Visible = false;
                TextBoxRaiseBTA10OPT.Visible = false;
                PanelRaiseBTA10OPT.Visible = true;
                PanelRaiseBTA10OPT2.Visible = true;
                PanelRaiseBTA10OPT3.Visible = true;
                LabelRespondBTA10OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseBTA10OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseBTA10OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA10OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblBTA10OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[Beta_2_Microglobulin] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and BTA10OPT = '" + RadioButtonListBTA10OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEBTA10OPTMSG.ShowPopupWindow();
        RAISEBTA10OPT.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }


}