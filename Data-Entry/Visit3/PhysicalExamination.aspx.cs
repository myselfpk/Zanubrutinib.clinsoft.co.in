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

public partial class Data_Entry_Visit3_PhysicalExamination : System.Web.UI.Page
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

        SetImageQueryPEPER();
        SetImageQueryPE1OPT();
        SetImageQueryPE2OPT();
        SetImageQueryPE3OPT();
        SetImageQueryPE4OPT();
        SetImageQueryPE5OPT();
        SetImageQueryPE6OPT();
        SetImageQueryPE7OPT();
        SetImageQueryPE8OPT();
        SetImageQueryPE9OPT();
        SetImageQueryPE10OPT();
        SetImageQueryPE11OPT();
        SetImageQueryPE12OPT();
        SetImageQueryPE13OPT();

        BindQueryDataPEPER();
        BindQueryDataPE1OPT();
        BindQueryDataPE2OPT();
        BindQueryDataPE3OPT();
        BindQueryDataPE4OPT();
        BindQueryDataPE5OPT();
        BindQueryDataPE6OPT();
        BindQueryDataPE7OPT();
        BindQueryDataPE8OPT();
        BindQueryDataPE9OPT();
        BindQueryDataPE10OPT();
        BindQueryDataPE11OPT();
        BindQueryDataPE12OPT();
        BindQueryDataPE13OPT();

        ShowHide();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select PEPER , PE1OPT , PE2OPT , PE3OPT , PE4OPT , PE5OPT , PE6OPT , PE7OPT , PE8OPT , PE9OPT , PE10OPT, PE11NM , PE11OPT, PE12NM , PE12OPT, PE13NM , PE13OPT from [Visit3].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListPEPER.SelectedValue = dt.Rows[0]["PEPER"].ToString().Trim();
            RadioButtonListPE1OPT.SelectedValue = dt.Rows[0]["PE1OPT"].ToString().Trim();
            RadioButtonListPE2OPT.SelectedValue = dt.Rows[0]["PE2OPT"].ToString().Trim();
            RadioButtonListPE3OPT.SelectedValue = dt.Rows[0]["PE3OPT"].ToString().Trim();
            RadioButtonListPE4OPT.SelectedValue = dt.Rows[0]["PE4OPT"].ToString().Trim();
            RadioButtonListPE5OPT.SelectedValue = dt.Rows[0]["PE5OPT"].ToString().Trim();
            RadioButtonListPE6OPT.SelectedValue = dt.Rows[0]["PE6OPT"].ToString().Trim();
            RadioButtonListPE7OPT.SelectedValue = dt.Rows[0]["PE7OPT"].ToString().Trim();
            RadioButtonListPE8OPT.SelectedValue = dt.Rows[0]["PE8OPT"].ToString().Trim();
            RadioButtonListPE9OPT.SelectedValue = dt.Rows[0]["PE9OPT"].ToString().Trim();
            RadioButtonListPE10OPT.SelectedValue = dt.Rows[0]["PE10OPT"].ToString().Trim();
            TextBoxPE11NM.Text = dt.Rows[0]["PE11NM"].ToString().Trim();
            RadioButtonListPE11OPT.SelectedValue = dt.Rows[0]["PE11OPT"].ToString().Trim();
            TextBoxPE12NM.Text = dt.Rows[0]["PE12NM"].ToString().Trim();
            RadioButtonListPE12OPT.SelectedValue = dt.Rows[0]["PE12OPT"].ToString().Trim();
            TextBoxPE13NM.Text = dt.Rows[0]["PE13NM"].ToString().Trim();
            RadioButtonListPE13OPT.SelectedValue = dt.Rows[0]["PE13OPT"].ToString().Trim();


            ViewState["txt1"] = RadioButtonListPEPER.SelectedValue;
            ViewState["txt2"] = RadioButtonListPE1OPT.SelectedValue;
            ViewState["txt3"] = RadioButtonListPE2OPT.SelectedValue;
            ViewState["txt4"] = RadioButtonListPE3OPT.SelectedValue;
            ViewState["txt5"] = RadioButtonListPE4OPT.SelectedValue;
            ViewState["txt6"] = RadioButtonListPE5OPT.SelectedValue;
            ViewState["txt7"] = RadioButtonListPE6OPT.SelectedValue;
            ViewState["txt8"] = RadioButtonListPE7OPT.SelectedValue;
            ViewState["txt9"] = RadioButtonListPE8OPT.SelectedValue;
            ViewState["txt10"] = RadioButtonListPE9OPT.SelectedValue;
            ViewState["txt11"] = RadioButtonListPE10OPT.SelectedValue;
            ViewState["txt12"] = TextBoxPE11NM.Text;
            ViewState["txt13"] = RadioButtonListPE11OPT.SelectedValue;
            ViewState["txt14"] = TextBoxPE12NM.Text;
            ViewState["txt15"] = RadioButtonListPE12OPT.SelectedValue;
            ViewState["txt16"] = TextBoxPE13NM.Text;
            ViewState["txt17"] = RadioButtonListPE13OPT.SelectedValue;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit3].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit3].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit3].[sp_PhysicalExamination]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                    cmd.Parameters.AddWithValue("@PEPER", RadioButtonListPEPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE1OPT", RadioButtonListPE1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE2OPT", RadioButtonListPE2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE3OPT", RadioButtonListPE3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE4OPT", RadioButtonListPE4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE5OPT", RadioButtonListPE5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE6OPT", RadioButtonListPE6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE7OPT", RadioButtonListPE7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE8OPT", RadioButtonListPE8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE9OPT", RadioButtonListPE9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE10OPT", RadioButtonListPE10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE11NM", TextBoxPE11NM.Text);
                    cmd.Parameters.AddWithValue("@PE11OPT", RadioButtonListPE11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE12NM", TextBoxPE12NM.Text);
                    cmd.Parameters.AddWithValue("@PE12OPT", RadioButtonListPE12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE13NM", TextBoxPE13NM.Text);
                    cmd.Parameters.AddWithValue("@PE13OPT", RadioButtonListPE13OPT.SelectedValue);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit3].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListPEPER.SelectedValue || ViewState["txt2"].ToString() != RadioButtonListPE1OPT.SelectedValue || ViewState["txt3"].ToString() != RadioButtonListPE2OPT.SelectedValue || ViewState["txt4"].ToString() != RadioButtonListPE3OPT.SelectedValue || ViewState["txt5"].ToString() != RadioButtonListPE4OPT.SelectedValue || ViewState["txt6"].ToString() != RadioButtonListPE5OPT.SelectedValue || ViewState["txt7"].ToString() != RadioButtonListPE6OPT.SelectedValue || ViewState["txt8"].ToString() != RadioButtonListPE7OPT.SelectedValue || ViewState["txt9"].ToString() != RadioButtonListPE8OPT.SelectedValue || ViewState["txt10"].ToString() != RadioButtonListPE9OPT.SelectedValue || ViewState["txt11"].ToString() != RadioButtonListPE10OPT.SelectedValue || ViewState["txt12"].ToString() != TextBoxPE11NM.Text || ViewState["txt13"].ToString() != RadioButtonListPE11OPT.SelectedValue || ViewState["txt14"].ToString() != TextBoxPE12NM.Text || ViewState["txt15"].ToString() != RadioButtonListPE12OPT.SelectedValue || ViewState["txt16"].ToString() != TextBoxPE13NM.Text || ViewState["txt17"].ToString() != RadioButtonListPE13OPT.SelectedValue)
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
                cmd = new SqlCommand("[Visit3].[sp_PhysicalExamination]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@PEPER", RadioButtonListPEPER.SelectedValue);
                cmd.Parameters.AddWithValue("@PE1OPT", RadioButtonListPE1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE2OPT", RadioButtonListPE2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE3OPT", RadioButtonListPE3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE4OPT", RadioButtonListPE4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE5OPT", RadioButtonListPE5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE6OPT", RadioButtonListPE6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE7OPT", RadioButtonListPE7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE8OPT", RadioButtonListPE8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE9OPT", RadioButtonListPE9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE10OPT", RadioButtonListPE10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE11NM", TextBoxPE11NM.Text);
                cmd.Parameters.AddWithValue("@PE11OPT", RadioButtonListPE11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE12NM", TextBoxPE12NM.Text);
                cmd.Parameters.AddWithValue("@PE12OPT", RadioButtonListPE12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE13NM", TextBoxPE13NM.Text);
                cmd.Parameters.AddWithValue("@PE13OPT", RadioButtonListPE13OPT.SelectedValue);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit3].[PhysicalExamination] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit3].[sp_PhysicalExamination]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@PEPER", RadioButtonListPEPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE1OPT", RadioButtonListPE1OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE2OPT", RadioButtonListPE2OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE3OPT", RadioButtonListPE3OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE4OPT", RadioButtonListPE4OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE5OPT", RadioButtonListPE5OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE6OPT", RadioButtonListPE6OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE7OPT", RadioButtonListPE7OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE8OPT", RadioButtonListPE8OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE9OPT", RadioButtonListPE9OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE10OPT", RadioButtonListPE10OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE11NM", TextBoxPE11NM.Text);
                    cmd.Parameters.AddWithValue("@PE11OPT", RadioButtonListPE11OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE12NM", TextBoxPE12NM.Text);
                    cmd.Parameters.AddWithValue("@PE12OPT", RadioButtonListPE12OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@PE13NM", TextBoxPE13NM.Text);
                    cmd.Parameters.AddWithValue("@PE13OPT", RadioButtonListPE13OPT.SelectedValue);

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
                cmd = new SqlCommand("[Visit3].[sp_PhysicalExamination]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);


                cmd.Parameters.AddWithValue("@PEPER", RadioButtonListPEPER.SelectedValue);
                cmd.Parameters.AddWithValue("@PE1OPT", RadioButtonListPE1OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE2OPT", RadioButtonListPE2OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE3OPT", RadioButtonListPE3OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE4OPT", RadioButtonListPE4OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE5OPT", RadioButtonListPE5OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE6OPT", RadioButtonListPE6OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE7OPT", RadioButtonListPE7OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE8OPT", RadioButtonListPE8OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE9OPT", RadioButtonListPE9OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE10OPT", RadioButtonListPE10OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE11NM", TextBoxPE11NM.Text);
                cmd.Parameters.AddWithValue("@PE11OPT", RadioButtonListPE11OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE12NM", TextBoxPE12NM.Text);
                cmd.Parameters.AddWithValue("@PE12OPT", RadioButtonListPE12OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@PE13NM", TextBoxPE13NM.Text);
                cmd.Parameters.AddWithValue("@PE13OPT", RadioButtonListPE13OPT.SelectedValue);

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
        if (!string.IsNullOrEmpty(RadioButtonListPEPER.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE4OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE5OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE6OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE7OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE8OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE9OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListPE10OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxPE11NM.Text) || !string.IsNullOrEmpty(RadioButtonListPE11OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxPE12NM.Text) || !string.IsNullOrEmpty(RadioButtonListPE12OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxPE13NM.Text) || !string.IsNullOrEmpty(RadioButtonListPE13OPT.SelectedValue))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() !=  RadioButtonListPEPER.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPEPER.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListPEPER.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() !=  RadioButtonListPE1OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE1OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = RadioButtonListPE1OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() !=  RadioButtonListPE2OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE2OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = RadioButtonListPE2OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() !=  RadioButtonListPE3OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE3OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = RadioButtonListPE3OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() !=  RadioButtonListPE4OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE4OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = RadioButtonListPE4OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() !=  RadioButtonListPE5OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE5OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = RadioButtonListPE5OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() !=  RadioButtonListPE6OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE6OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListPE6OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() !=  RadioButtonListPE7OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE7OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = RadioButtonListPE7OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() !=  RadioButtonListPE8OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE8OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = RadioButtonListPE8OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() != RadioButtonListPE9OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE9OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = RadioButtonListPE9OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != RadioButtonListPE10OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE10OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = RadioButtonListPE10OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != TextBoxPE11NM.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE11NM.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = TextBoxPE11NM.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != RadioButtonListPE11OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE11OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = RadioButtonListPE11OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString() != TextBoxPE12NM.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE12NM.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = TextBoxPE12NM.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString() != RadioButtonListPE12OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE12OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = RadioButtonListPE12OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt16"].ToString() != TextBoxPE13NM.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE13NM.Text;
                dtrow["OldValue"] = dt1.Rows[0][15];
                dtrow["NewValue"] = TextBoxPE13NM.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt17"].ToString() != RadioButtonListPE13OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblPE13OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][16];
                dtrow["NewValue"] = RadioButtonListPE13OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit3].[sp_PhysicalExamination]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@PEPER", RadioButtonListPEPER.SelectedValue);
            cmd.Parameters.AddWithValue("@PE1OPT", RadioButtonListPE1OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE2OPT", RadioButtonListPE2OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE3OPT", RadioButtonListPE3OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE4OPT", RadioButtonListPE4OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE5OPT", RadioButtonListPE5OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE6OPT", RadioButtonListPE6OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE7OPT", RadioButtonListPE7OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE8OPT", RadioButtonListPE8OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE9OPT", RadioButtonListPE9OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE10OPT", RadioButtonListPE10OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE11NM", TextBoxPE11NM.Text);
            cmd.Parameters.AddWithValue("@PE11OPT", RadioButtonListPE11OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE12NM", TextBoxPE12NM.Text);
            cmd.Parameters.AddWithValue("@PE12OPT", RadioButtonListPE12OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@PE13NM", TextBoxPE13NM.Text);
            cmd.Parameters.AddWithValue("@PE13OPT", RadioButtonListPE13OPT.SelectedValue);

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
    #region QueryPEPER
    private void SetImageQueryPEPER()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPEPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPEPER.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPEPER.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPEPER.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPEPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPEPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPEPER()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPEPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePEPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePEPER.Visible = true;
                PanelRaisePEPER2.Visible = false;
                PanelRaisePEPER3.Visible = false;
                PanelHidePEPER.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePEPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePEPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePEPER3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePEPER.Visible = true;
                PanelRaisePEPER2.Visible = true;
                PanelRaisePEPER3.Visible = true;
                PanelHidePEPER.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePEPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePEPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePEPER.Visible = true;
                PanelRaisePEPER2.Visible = true;
                PanelRaisePEPER3.Visible = false;
                PanelHidePEPER.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPEPER_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PEPER = '" + RadioButtonListPEPER.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPEPER.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPEPER.Visible = true;
                RAISEPEPER.ShowPopupWindow();
                QueryRaisePEPER.Visible = false;
                TextBoxRaisePEPER.Visible = false;
                PanelRaisePEPER.Visible = false;
                PanelRaisePEPER2.Visible = false;
                PanelRaisePEPER3.Visible = false;

                LabelRespondPEPER.Visible = false;
            }

            else if ((ImageQueryPEPER.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPEPER.Visible = true;
                RAISEPEPER.ShowPopupWindow();
                QueryRaisePEPER.Visible = true;
                TextBoxRaisePEPER.Visible = true;
                PanelRaisePEPER.Visible = true;
                PanelRaisePEPER2.Visible = false;
                PanelRaisePEPER3.Visible = false;
                LabelRespondPEPER.Visible = true;
            }

            else if ((ImageQueryPEPER.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPEPER.Visible = true;
                RAISEPEPER.ShowPopupWindow();
                QueryRaisePEPER.Visible = false;
                TextBoxRaisePEPER.Visible = false;
                PanelRaisePEPER.Visible = true;
                PanelRaisePEPER2.Visible = true;
                PanelRaisePEPER3.Visible = false;
                LabelRespondPEPER.Visible = false;
            }
            else if ((ImageQueryPEPER.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPEPER.Visible = true;
                RAISEPEPER.ShowPopupWindow();
                QueryRaisePEPER.Visible = false;
                TextBoxRaisePEPER.Visible = false;
                PanelRaisePEPER.Visible = true;
                PanelRaisePEPER2.Visible = true;
                PanelRaisePEPER3.Visible = true;
                LabelRespondPEPER.Visible = false;
            }
            else
            {
                RAISEPEPER.Visible = true;
                RAISEPEPER.ShowPopupWindow();
                QueryRaisePEPER.Visible = false;
                TextBoxRaisePEPER.Visible = false;
                PanelRaisePEPER.Visible = true;
                PanelRaisePEPER2.Visible = true;
                PanelRaisePEPER3.Visible = true;
                LabelRespondPEPER.Visible = false;

            }
        }

    }
    protected void QueryRaisePEPER_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePEPER.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPEPER.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPEPER.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PEPER = '" + RadioButtonListPEPER.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPEPERMSG.ShowPopupWindow();
        RAISEPEPER.Visible = false;


    }
    #endregion
    #region QueryPE1OPT
    private void SetImageQueryPE1OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE1OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE1OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE1OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE1OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE1OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE1OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT2.Visible = false;
                PanelRaisePE1OPT3.Visible = false;
                PanelHidePE1OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE1OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT2.Visible = true;
                PanelRaisePE1OPT3.Visible = true;
                PanelHidePE1OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE1OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE1OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT2.Visible = true;
                PanelRaisePE1OPT3.Visible = false;
                PanelHidePE1OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE1OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE1OPT = '" + RadioButtonListPE1OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE1OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE1OPT.Visible = true;
                RAISEPE1OPT.ShowPopupWindow();
                QueryRaisePE1OPT.Visible = false;
                TextBoxRaisePE1OPT.Visible = false;
                PanelRaisePE1OPT.Visible = false;
                PanelRaisePE1OPT2.Visible = false;
                PanelRaisePE1OPT3.Visible = false;

                LabelRespondPE1OPT.Visible = false;
            }

            else if ((ImageQueryPE1OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE1OPT.Visible = true;
                RAISEPE1OPT.ShowPopupWindow();
                QueryRaisePE1OPT.Visible = true;
                TextBoxRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT2.Visible = false;
                PanelRaisePE1OPT3.Visible = false;
                LabelRespondPE1OPT.Visible = true;
            }

            else if ((ImageQueryPE1OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE1OPT.Visible = true;
                RAISEPE1OPT.ShowPopupWindow();
                QueryRaisePE1OPT.Visible = false;
                TextBoxRaisePE1OPT.Visible = false;
                PanelRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT2.Visible = true;
                PanelRaisePE1OPT3.Visible = false;
                LabelRespondPE1OPT.Visible = false;
            }
            else if ((ImageQueryPE1OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE1OPT.Visible = true;
                RAISEPE1OPT.ShowPopupWindow();
                QueryRaisePE1OPT.Visible = false;
                TextBoxRaisePE1OPT.Visible = false;
                PanelRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT2.Visible = true;
                PanelRaisePE1OPT3.Visible = true;
                LabelRespondPE1OPT.Visible = false;
            }
            else
            {
                RAISEPE1OPT.Visible = true;
                RAISEPE1OPT.ShowPopupWindow();
                QueryRaisePE1OPT.Visible = false;
                TextBoxRaisePE1OPT.Visible = false;
                PanelRaisePE1OPT.Visible = true;
                PanelRaisePE1OPT2.Visible = true;
                PanelRaisePE1OPT3.Visible = true;
                LabelRespondPE1OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE1OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE1OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE1OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE1OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE1OPT = '" + RadioButtonListPE1OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE1OPTMSG.ShowPopupWindow();
        RAISEPE1OPT.Visible = false;


    }
    #endregion
    #region QueryPE2OPT
    private void SetImageQueryPE2OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE2OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE2OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE2OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE2OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE2OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE2OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT2.Visible = false;
                PanelRaisePE2OPT3.Visible = false;
                PanelHidePE2OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE2OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT2.Visible = true;
                PanelRaisePE2OPT3.Visible = true;
                PanelHidePE2OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE2OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE2OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT2.Visible = true;
                PanelRaisePE2OPT3.Visible = false;
                PanelHidePE2OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE2OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE2OPT = '" + RadioButtonListPE2OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE2OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE2OPT.Visible = true;
                RAISEPE2OPT.ShowPopupWindow();
                QueryRaisePE2OPT.Visible = false;
                TextBoxRaisePE2OPT.Visible = false;
                PanelRaisePE2OPT.Visible = false;
                PanelRaisePE2OPT2.Visible = false;
                PanelRaisePE2OPT3.Visible = false;

                LabelRespondPE2OPT.Visible = false;
            }

            else if ((ImageQueryPE2OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE2OPT.Visible = true;
                RAISEPE2OPT.ShowPopupWindow();
                QueryRaisePE2OPT.Visible = true;
                TextBoxRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT2.Visible = false;
                PanelRaisePE2OPT3.Visible = false;
                LabelRespondPE2OPT.Visible = true;
            }

            else if ((ImageQueryPE2OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE2OPT.Visible = true;
                RAISEPE2OPT.ShowPopupWindow();
                QueryRaisePE2OPT.Visible = false;
                TextBoxRaisePE2OPT.Visible = false;
                PanelRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT2.Visible = true;
                PanelRaisePE2OPT3.Visible = false;
                LabelRespondPE2OPT.Visible = false;
            }
            else if ((ImageQueryPE2OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE2OPT.Visible = true;
                RAISEPE2OPT.ShowPopupWindow();
                QueryRaisePE2OPT.Visible = false;
                TextBoxRaisePE2OPT.Visible = false;
                PanelRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT2.Visible = true;
                PanelRaisePE2OPT3.Visible = true;
                LabelRespondPE2OPT.Visible = false;
            }
            else
            {
                RAISEPE2OPT.Visible = true;
                RAISEPE2OPT.ShowPopupWindow();
                QueryRaisePE2OPT.Visible = false;
                TextBoxRaisePE2OPT.Visible = false;
                PanelRaisePE2OPT.Visible = true;
                PanelRaisePE2OPT2.Visible = true;
                PanelRaisePE2OPT3.Visible = true;
                LabelRespondPE2OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE2OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE2OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE2OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE2OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE2OPT = '" + RadioButtonListPE2OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE2OPTMSG.ShowPopupWindow();
        RAISEPE2OPT.Visible = false;


    }
    #endregion
    #region QueryPE3OPT
    private void SetImageQueryPE3OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE3OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE3OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE3OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE3OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE3OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE3OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT2.Visible = false;
                PanelRaisePE3OPT3.Visible = false;
                PanelHidePE3OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE3OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT2.Visible = true;
                PanelRaisePE3OPT3.Visible = true;
                PanelHidePE3OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE3OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE3OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT2.Visible = true;
                PanelRaisePE3OPT3.Visible = false;
                PanelHidePE3OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE3OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE3OPT = '" + RadioButtonListPE3OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE3OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE3OPT.Visible = true;
                RAISEPE3OPT.ShowPopupWindow();
                QueryRaisePE3OPT.Visible = false;
                TextBoxRaisePE3OPT.Visible = false;
                PanelRaisePE3OPT.Visible = false;
                PanelRaisePE3OPT2.Visible = false;
                PanelRaisePE3OPT3.Visible = false;

                LabelRespondPE3OPT.Visible = false;
            }

            else if ((ImageQueryPE3OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE3OPT.Visible = true;
                RAISEPE3OPT.ShowPopupWindow();
                QueryRaisePE3OPT.Visible = true;
                TextBoxRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT2.Visible = false;
                PanelRaisePE3OPT3.Visible = false;
                LabelRespondPE3OPT.Visible = true;
            }

            else if ((ImageQueryPE3OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE3OPT.Visible = true;
                RAISEPE3OPT.ShowPopupWindow();
                QueryRaisePE3OPT.Visible = false;
                TextBoxRaisePE3OPT.Visible = false;
                PanelRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT2.Visible = true;
                PanelRaisePE3OPT3.Visible = false;
                LabelRespondPE3OPT.Visible = false;
            }
            else if ((ImageQueryPE3OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE3OPT.Visible = true;
                RAISEPE3OPT.ShowPopupWindow();
                QueryRaisePE3OPT.Visible = false;
                TextBoxRaisePE3OPT.Visible = false;
                PanelRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT2.Visible = true;
                PanelRaisePE3OPT3.Visible = true;
                LabelRespondPE3OPT.Visible = false;
            }
            else
            {
                RAISEPE3OPT.Visible = true;
                RAISEPE3OPT.ShowPopupWindow();
                QueryRaisePE3OPT.Visible = false;
                TextBoxRaisePE3OPT.Visible = false;
                PanelRaisePE3OPT.Visible = true;
                PanelRaisePE3OPT2.Visible = true;
                PanelRaisePE3OPT3.Visible = true;
                LabelRespondPE3OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE3OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE3OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE3OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE3OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE3OPT = '" + RadioButtonListPE3OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE3OPTMSG.ShowPopupWindow();
        RAISEPE3OPT.Visible = false;


    }
    #endregion
    #region QueryPE4OPT
    private void SetImageQueryPE4OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE4OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE4OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE4OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE4OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE4OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE4OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT2.Visible = false;
                PanelRaisePE4OPT3.Visible = false;
                PanelHidePE4OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE4OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT2.Visible = true;
                PanelRaisePE4OPT3.Visible = true;
                PanelHidePE4OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE4OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE4OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT2.Visible = true;
                PanelRaisePE4OPT3.Visible = false;
                PanelHidePE4OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE4OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE4OPT = '" + RadioButtonListPE4OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE4OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE4OPT.Visible = true;
                RAISEPE4OPT.ShowPopupWindow();
                QueryRaisePE4OPT.Visible = false;
                TextBoxRaisePE4OPT.Visible = false;
                PanelRaisePE4OPT.Visible = false;
                PanelRaisePE4OPT2.Visible = false;
                PanelRaisePE4OPT3.Visible = false;

                LabelRespondPE4OPT.Visible = false;
            }

            else if ((ImageQueryPE4OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE4OPT.Visible = true;
                RAISEPE4OPT.ShowPopupWindow();
                QueryRaisePE4OPT.Visible = true;
                TextBoxRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT2.Visible = false;
                PanelRaisePE4OPT3.Visible = false;
                LabelRespondPE4OPT.Visible = true;
            }

            else if ((ImageQueryPE4OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE4OPT.Visible = true;
                RAISEPE4OPT.ShowPopupWindow();
                QueryRaisePE4OPT.Visible = false;
                TextBoxRaisePE4OPT.Visible = false;
                PanelRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT2.Visible = true;
                PanelRaisePE4OPT3.Visible = false;
                LabelRespondPE4OPT.Visible = false;
            }
            else if ((ImageQueryPE4OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE4OPT.Visible = true;
                RAISEPE4OPT.ShowPopupWindow();
                QueryRaisePE4OPT.Visible = false;
                TextBoxRaisePE4OPT.Visible = false;
                PanelRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT2.Visible = true;
                PanelRaisePE4OPT3.Visible = true;
                LabelRespondPE4OPT.Visible = false;
            }
            else
            {
                RAISEPE4OPT.Visible = true;
                RAISEPE4OPT.ShowPopupWindow();
                QueryRaisePE4OPT.Visible = false;
                TextBoxRaisePE4OPT.Visible = false;
                PanelRaisePE4OPT.Visible = true;
                PanelRaisePE4OPT2.Visible = true;
                PanelRaisePE4OPT3.Visible = true;
                LabelRespondPE4OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE4OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE4OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE4OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE4OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE4OPT = '" + RadioButtonListPE4OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE4OPTMSG.ShowPopupWindow();
        RAISEPE4OPT.Visible = false;


    }
    #endregion
    #region QueryPE5OPT
    private void SetImageQueryPE5OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE5OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE5OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE5OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE5OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE5OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE5OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT2.Visible = false;
                PanelRaisePE5OPT3.Visible = false;
                PanelHidePE5OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE5OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT2.Visible = true;
                PanelRaisePE5OPT3.Visible = true;
                PanelHidePE5OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE5OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE5OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT2.Visible = true;
                PanelRaisePE5OPT3.Visible = false;
                PanelHidePE5OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE5OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE5OPT = '" + RadioButtonListPE5OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE5OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE5OPT.Visible = true;
                RAISEPE5OPT.ShowPopupWindow();
                QueryRaisePE5OPT.Visible = false;
                TextBoxRaisePE5OPT.Visible = false;
                PanelRaisePE5OPT.Visible = false;
                PanelRaisePE5OPT2.Visible = false;
                PanelRaisePE5OPT3.Visible = false;

                LabelRespondPE5OPT.Visible = false;
            }

            else if ((ImageQueryPE5OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE5OPT.Visible = true;
                RAISEPE5OPT.ShowPopupWindow();
                QueryRaisePE5OPT.Visible = true;
                TextBoxRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT2.Visible = false;
                PanelRaisePE5OPT3.Visible = false;
                LabelRespondPE5OPT.Visible = true;
            }

            else if ((ImageQueryPE5OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE5OPT.Visible = true;
                RAISEPE5OPT.ShowPopupWindow();
                QueryRaisePE5OPT.Visible = false;
                TextBoxRaisePE5OPT.Visible = false;
                PanelRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT2.Visible = true;
                PanelRaisePE5OPT3.Visible = false;
                LabelRespondPE5OPT.Visible = false;
            }
            else if ((ImageQueryPE5OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE5OPT.Visible = true;
                RAISEPE5OPT.ShowPopupWindow();
                QueryRaisePE5OPT.Visible = false;
                TextBoxRaisePE5OPT.Visible = false;
                PanelRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT2.Visible = true;
                PanelRaisePE5OPT3.Visible = true;
                LabelRespondPE5OPT.Visible = false;
            }
            else
            {
                RAISEPE5OPT.Visible = true;
                RAISEPE5OPT.ShowPopupWindow();
                QueryRaisePE5OPT.Visible = false;
                TextBoxRaisePE5OPT.Visible = false;
                PanelRaisePE5OPT.Visible = true;
                PanelRaisePE5OPT2.Visible = true;
                PanelRaisePE5OPT3.Visible = true;
                LabelRespondPE5OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE5OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE5OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE5OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE5OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE5OPT = '" + RadioButtonListPE5OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE5OPTMSG.ShowPopupWindow();
        RAISEPE5OPT.Visible = false;


    }
    #endregion
    #region QueryPE6OPT
    private void SetImageQueryPE6OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE6OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE6OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE6OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE6OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE6OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE6OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT2.Visible = false;
                PanelRaisePE6OPT3.Visible = false;
                PanelHidePE6OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE6OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT2.Visible = true;
                PanelRaisePE6OPT3.Visible = true;
                PanelHidePE6OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE6OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE6OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT2.Visible = true;
                PanelRaisePE6OPT3.Visible = false;
                PanelHidePE6OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE6OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE6OPT = '" + RadioButtonListPE6OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE6OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE6OPT.Visible = true;
                RAISEPE6OPT.ShowPopupWindow();
                QueryRaisePE6OPT.Visible = false;
                TextBoxRaisePE6OPT.Visible = false;
                PanelRaisePE6OPT.Visible = false;
                PanelRaisePE6OPT2.Visible = false;
                PanelRaisePE6OPT3.Visible = false;

                LabelRespondPE6OPT.Visible = false;
            }

            else if ((ImageQueryPE6OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE6OPT.Visible = true;
                RAISEPE6OPT.ShowPopupWindow();
                QueryRaisePE6OPT.Visible = true;
                TextBoxRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT2.Visible = false;
                PanelRaisePE6OPT3.Visible = false;
                LabelRespondPE6OPT.Visible = true;
            }

            else if ((ImageQueryPE6OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE6OPT.Visible = true;
                RAISEPE6OPT.ShowPopupWindow();
                QueryRaisePE6OPT.Visible = false;
                TextBoxRaisePE6OPT.Visible = false;
                PanelRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT2.Visible = true;
                PanelRaisePE6OPT3.Visible = false;
                LabelRespondPE6OPT.Visible = false;
            }
            else if ((ImageQueryPE6OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE6OPT.Visible = true;
                RAISEPE6OPT.ShowPopupWindow();
                QueryRaisePE6OPT.Visible = false;
                TextBoxRaisePE6OPT.Visible = false;
                PanelRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT2.Visible = true;
                PanelRaisePE6OPT3.Visible = true;
                LabelRespondPE6OPT.Visible = false;
            }
            else
            {
                RAISEPE6OPT.Visible = true;
                RAISEPE6OPT.ShowPopupWindow();
                QueryRaisePE6OPT.Visible = false;
                TextBoxRaisePE6OPT.Visible = false;
                PanelRaisePE6OPT.Visible = true;
                PanelRaisePE6OPT2.Visible = true;
                PanelRaisePE6OPT3.Visible = true;
                LabelRespondPE6OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE6OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE6OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE6OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE6OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE6OPT = '" + RadioButtonListPE6OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE6OPTMSG.ShowPopupWindow();
        RAISEPE6OPT.Visible = false;


    }
    #endregion
    #region QueryPE7OPT
    private void SetImageQueryPE7OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE7OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE7OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE7OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE7OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE7OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE7OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT2.Visible = false;
                PanelRaisePE7OPT3.Visible = false;
                PanelHidePE7OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE7OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT2.Visible = true;
                PanelRaisePE7OPT3.Visible = true;
                PanelHidePE7OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE7OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE7OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT2.Visible = true;
                PanelRaisePE7OPT3.Visible = false;
                PanelHidePE7OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE7OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE7OPT = '" + RadioButtonListPE7OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE7OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE7OPT.Visible = true;
                RAISEPE7OPT.ShowPopupWindow();
                QueryRaisePE7OPT.Visible = false;
                TextBoxRaisePE7OPT.Visible = false;
                PanelRaisePE7OPT.Visible = false;
                PanelRaisePE7OPT2.Visible = false;
                PanelRaisePE7OPT3.Visible = false;

                LabelRespondPE7OPT.Visible = false;
            }

            else if ((ImageQueryPE7OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE7OPT.Visible = true;
                RAISEPE7OPT.ShowPopupWindow();
                QueryRaisePE7OPT.Visible = true;
                TextBoxRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT2.Visible = false;
                PanelRaisePE7OPT3.Visible = false;
                LabelRespondPE7OPT.Visible = true;
            }

            else if ((ImageQueryPE7OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE7OPT.Visible = true;
                RAISEPE7OPT.ShowPopupWindow();
                QueryRaisePE7OPT.Visible = false;
                TextBoxRaisePE7OPT.Visible = false;
                PanelRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT2.Visible = true;
                PanelRaisePE7OPT3.Visible = false;
                LabelRespondPE7OPT.Visible = false;
            }
            else if ((ImageQueryPE7OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE7OPT.Visible = true;
                RAISEPE7OPT.ShowPopupWindow();
                QueryRaisePE7OPT.Visible = false;
                TextBoxRaisePE7OPT.Visible = false;
                PanelRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT2.Visible = true;
                PanelRaisePE7OPT3.Visible = true;
                LabelRespondPE7OPT.Visible = false;
            }
            else
            {
                RAISEPE7OPT.Visible = true;
                RAISEPE7OPT.ShowPopupWindow();
                QueryRaisePE7OPT.Visible = false;
                TextBoxRaisePE7OPT.Visible = false;
                PanelRaisePE7OPT.Visible = true;
                PanelRaisePE7OPT2.Visible = true;
                PanelRaisePE7OPT3.Visible = true;
                LabelRespondPE7OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE7OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE7OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE7OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE7OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE7OPT = '" + RadioButtonListPE7OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE7OPTMSG.ShowPopupWindow();
        RAISEPE7OPT.Visible = false;


    }
    #endregion
    #region QueryPE8OPT
    private void SetImageQueryPE8OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE8OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE8OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE8OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE8OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE8OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE8OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT2.Visible = false;
                PanelRaisePE8OPT3.Visible = false;
                PanelHidePE8OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE8OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT2.Visible = true;
                PanelRaisePE8OPT3.Visible = true;
                PanelHidePE8OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE8OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE8OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT2.Visible = true;
                PanelRaisePE8OPT3.Visible = false;
                PanelHidePE8OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE8OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE8OPT = '" + RadioButtonListPE8OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE8OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE8OPT.Visible = true;
                RAISEPE8OPT.ShowPopupWindow();
                QueryRaisePE8OPT.Visible = false;
                TextBoxRaisePE8OPT.Visible = false;
                PanelRaisePE8OPT.Visible = false;
                PanelRaisePE8OPT2.Visible = false;
                PanelRaisePE8OPT3.Visible = false;

                LabelRespondPE8OPT.Visible = false;
            }

            else if ((ImageQueryPE8OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE8OPT.Visible = true;
                RAISEPE8OPT.ShowPopupWindow();
                QueryRaisePE8OPT.Visible = true;
                TextBoxRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT2.Visible = false;
                PanelRaisePE8OPT3.Visible = false;
                LabelRespondPE8OPT.Visible = true;
            }

            else if ((ImageQueryPE8OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE8OPT.Visible = true;
                RAISEPE8OPT.ShowPopupWindow();
                QueryRaisePE8OPT.Visible = false;
                TextBoxRaisePE8OPT.Visible = false;
                PanelRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT2.Visible = true;
                PanelRaisePE8OPT3.Visible = false;
                LabelRespondPE8OPT.Visible = false;
            }
            else if ((ImageQueryPE8OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE8OPT.Visible = true;
                RAISEPE8OPT.ShowPopupWindow();
                QueryRaisePE8OPT.Visible = false;
                TextBoxRaisePE8OPT.Visible = false;
                PanelRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT2.Visible = true;
                PanelRaisePE8OPT3.Visible = true;
                LabelRespondPE8OPT.Visible = false;
            }
            else
            {
                RAISEPE8OPT.Visible = true;
                RAISEPE8OPT.ShowPopupWindow();
                QueryRaisePE8OPT.Visible = false;
                TextBoxRaisePE8OPT.Visible = false;
                PanelRaisePE8OPT.Visible = true;
                PanelRaisePE8OPT2.Visible = true;
                PanelRaisePE8OPT3.Visible = true;
                LabelRespondPE8OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE8OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE8OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE8OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE8OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE8OPT = '" + RadioButtonListPE8OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE8OPTMSG.ShowPopupWindow();
        RAISEPE8OPT.Visible = false;


    }
    #endregion
    #region QueryPE9OPT
    private void SetImageQueryPE9OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE9OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE9OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE9OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE9OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE9OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE9OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT2.Visible = false;
                PanelRaisePE9OPT3.Visible = false;
                PanelHidePE9OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE9OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT2.Visible = true;
                PanelRaisePE9OPT3.Visible = true;
                PanelHidePE9OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE9OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE9OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT2.Visible = true;
                PanelRaisePE9OPT3.Visible = false;
                PanelHidePE9OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE9OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE9OPT = '" + RadioButtonListPE9OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE9OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE9OPT.Visible = true;
                RAISEPE9OPT.ShowPopupWindow();
                QueryRaisePE9OPT.Visible = false;
                TextBoxRaisePE9OPT.Visible = false;
                PanelRaisePE9OPT.Visible = false;
                PanelRaisePE9OPT2.Visible = false;
                PanelRaisePE9OPT3.Visible = false;

                LabelRespondPE9OPT.Visible = false;
            }

            else if ((ImageQueryPE9OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE9OPT.Visible = true;
                RAISEPE9OPT.ShowPopupWindow();
                QueryRaisePE9OPT.Visible = true;
                TextBoxRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT2.Visible = false;
                PanelRaisePE9OPT3.Visible = false;
                LabelRespondPE9OPT.Visible = true;
            }

            else if ((ImageQueryPE9OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE9OPT.Visible = true;
                RAISEPE9OPT.ShowPopupWindow();
                QueryRaisePE9OPT.Visible = false;
                TextBoxRaisePE9OPT.Visible = false;
                PanelRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT2.Visible = true;
                PanelRaisePE9OPT3.Visible = false;
                LabelRespondPE9OPT.Visible = false;
            }
            else if ((ImageQueryPE9OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE9OPT.Visible = true;
                RAISEPE9OPT.ShowPopupWindow();
                QueryRaisePE9OPT.Visible = false;
                TextBoxRaisePE9OPT.Visible = false;
                PanelRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT2.Visible = true;
                PanelRaisePE9OPT3.Visible = true;
                LabelRespondPE9OPT.Visible = false;
            }
            else
            {
                RAISEPE9OPT.Visible = true;
                RAISEPE9OPT.ShowPopupWindow();
                QueryRaisePE9OPT.Visible = false;
                TextBoxRaisePE9OPT.Visible = false;
                PanelRaisePE9OPT.Visible = true;
                PanelRaisePE9OPT2.Visible = true;
                PanelRaisePE9OPT3.Visible = true;
                LabelRespondPE9OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE9OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE9OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE9OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE9OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE9OPT = '" + RadioButtonListPE9OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE9OPTMSG.ShowPopupWindow();
        RAISEPE9OPT.Visible = false;


    }
    #endregion
    #region QueryPE10OPT
    private void SetImageQueryPE10OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE10OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE10OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE10OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE10OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE10OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE10OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT2.Visible = false;
                PanelRaisePE10OPT3.Visible = false;
                PanelHidePE10OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE10OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT2.Visible = true;
                PanelRaisePE10OPT3.Visible = true;
                PanelHidePE10OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE10OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE10OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT2.Visible = true;
                PanelRaisePE10OPT3.Visible = false;
                PanelHidePE10OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE10OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE10OPT = '" + RadioButtonListPE10OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE10OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE10OPT.Visible = true;
                RAISEPE10OPT.ShowPopupWindow();
                QueryRaisePE10OPT.Visible = false;
                TextBoxRaisePE10OPT.Visible = false;
                PanelRaisePE10OPT.Visible = false;
                PanelRaisePE10OPT2.Visible = false;
                PanelRaisePE10OPT3.Visible = false;

                LabelRespondPE10OPT.Visible = false;
            }

            else if ((ImageQueryPE10OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE10OPT.Visible = true;
                RAISEPE10OPT.ShowPopupWindow();
                QueryRaisePE10OPT.Visible = true;
                TextBoxRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT2.Visible = false;
                PanelRaisePE10OPT3.Visible = false;
                LabelRespondPE10OPT.Visible = true;
            }

            else if ((ImageQueryPE10OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE10OPT.Visible = true;
                RAISEPE10OPT.ShowPopupWindow();
                QueryRaisePE10OPT.Visible = false;
                TextBoxRaisePE10OPT.Visible = false;
                PanelRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT2.Visible = true;
                PanelRaisePE10OPT3.Visible = false;
                LabelRespondPE10OPT.Visible = false;
            }
            else if ((ImageQueryPE10OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE10OPT.Visible = true;
                RAISEPE10OPT.ShowPopupWindow();
                QueryRaisePE10OPT.Visible = false;
                TextBoxRaisePE10OPT.Visible = false;
                PanelRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT2.Visible = true;
                PanelRaisePE10OPT3.Visible = true;
                LabelRespondPE10OPT.Visible = false;
            }
            else
            {
                RAISEPE10OPT.Visible = true;
                RAISEPE10OPT.ShowPopupWindow();
                QueryRaisePE10OPT.Visible = false;
                TextBoxRaisePE10OPT.Visible = false;
                PanelRaisePE10OPT.Visible = true;
                PanelRaisePE10OPT2.Visible = true;
                PanelRaisePE10OPT3.Visible = true;
                LabelRespondPE10OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE10OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE10OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE10OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE10OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE10OPT = '" + RadioButtonListPE10OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE10OPTMSG.ShowPopupWindow();
        RAISEPE10OPT.Visible = false;


    }
    #endregion
    #region QueryPE11OPT
    private void SetImageQueryPE11OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE11OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE11OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE11OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE11OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE11OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE11OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE11OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT2.Visible = false;
                PanelRaisePE11OPT3.Visible = false;
                PanelHidePE11OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE11OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT2.Visible = true;
                PanelRaisePE11OPT3.Visible = true;
                PanelHidePE11OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE11OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE11OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT2.Visible = true;
                PanelRaisePE11OPT3.Visible = false;
                PanelHidePE11OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE11OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE11OPT = '" + RadioButtonListPE11OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE11OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE11OPT.Visible = true;
                RAISEPE11OPT.ShowPopupWindow();
                QueryRaisePE11OPT.Visible = false;
                TextBoxRaisePE11OPT.Visible = false;
                PanelRaisePE11OPT.Visible = false;
                PanelRaisePE11OPT2.Visible = false;
                PanelRaisePE11OPT3.Visible = false;

                LabelRespondPE11OPT.Visible = false;
            }

            else if ((ImageQueryPE11OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE11OPT.Visible = true;
                RAISEPE11OPT.ShowPopupWindow();
                QueryRaisePE11OPT.Visible = true;
                TextBoxRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT2.Visible = false;
                PanelRaisePE11OPT3.Visible = false;
                LabelRespondPE11OPT.Visible = true;
            }

            else if ((ImageQueryPE11OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE11OPT.Visible = true;
                RAISEPE11OPT.ShowPopupWindow();
                QueryRaisePE11OPT.Visible = false;
                TextBoxRaisePE11OPT.Visible = false;
                PanelRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT2.Visible = true;
                PanelRaisePE11OPT3.Visible = false;
                LabelRespondPE11OPT.Visible = false;
            }
            else if ((ImageQueryPE11OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE11OPT.Visible = true;
                RAISEPE11OPT.ShowPopupWindow();
                QueryRaisePE11OPT.Visible = false;
                TextBoxRaisePE11OPT.Visible = false;
                PanelRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT2.Visible = true;
                PanelRaisePE11OPT3.Visible = true;
                LabelRespondPE11OPT.Visible = false;
            }
            else
            {
                RAISEPE11OPT.Visible = true;
                RAISEPE11OPT.ShowPopupWindow();
                QueryRaisePE11OPT.Visible = false;
                TextBoxRaisePE11OPT.Visible = false;
                PanelRaisePE11OPT.Visible = true;
                PanelRaisePE11OPT2.Visible = true;
                PanelRaisePE11OPT3.Visible = true;
                LabelRespondPE11OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE11OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE11OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE11OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE11OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE11OPT = '" + RadioButtonListPE11OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE11OPTMSG.ShowPopupWindow();
        RAISEPE11OPT.Visible = false;


    }
    #endregion
    #region QueryPE12OPT
    private void SetImageQueryPE12OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE12OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE12OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE12OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE12OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE12OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE12OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE12OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT2.Visible = false;
                PanelRaisePE12OPT3.Visible = false;
                PanelHidePE12OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE12OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT2.Visible = true;
                PanelRaisePE12OPT3.Visible = true;
                PanelHidePE12OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE12OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE12OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT2.Visible = true;
                PanelRaisePE12OPT3.Visible = false;
                PanelHidePE12OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE12OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE12OPT = '" + RadioButtonListPE12OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE12OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE12OPT.Visible = true;
                RAISEPE12OPT.ShowPopupWindow();
                QueryRaisePE12OPT.Visible = false;
                TextBoxRaisePE12OPT.Visible = false;
                PanelRaisePE12OPT.Visible = false;
                PanelRaisePE12OPT2.Visible = false;
                PanelRaisePE12OPT3.Visible = false;

                LabelRespondPE12OPT.Visible = false;
            }

            else if ((ImageQueryPE12OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE12OPT.Visible = true;
                RAISEPE12OPT.ShowPopupWindow();
                QueryRaisePE12OPT.Visible = true;
                TextBoxRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT2.Visible = false;
                PanelRaisePE12OPT3.Visible = false;
                LabelRespondPE12OPT.Visible = true;
            }

            else if ((ImageQueryPE12OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE12OPT.Visible = true;
                RAISEPE12OPT.ShowPopupWindow();
                QueryRaisePE12OPT.Visible = false;
                TextBoxRaisePE12OPT.Visible = false;
                PanelRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT2.Visible = true;
                PanelRaisePE12OPT3.Visible = false;
                LabelRespondPE12OPT.Visible = false;
            }
            else if ((ImageQueryPE12OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE12OPT.Visible = true;
                RAISEPE12OPT.ShowPopupWindow();
                QueryRaisePE12OPT.Visible = false;
                TextBoxRaisePE12OPT.Visible = false;
                PanelRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT2.Visible = true;
                PanelRaisePE12OPT3.Visible = true;
                LabelRespondPE12OPT.Visible = false;
            }
            else
            {
                RAISEPE12OPT.Visible = true;
                RAISEPE12OPT.ShowPopupWindow();
                QueryRaisePE12OPT.Visible = false;
                TextBoxRaisePE12OPT.Visible = false;
                PanelRaisePE12OPT.Visible = true;
                PanelRaisePE12OPT2.Visible = true;
                PanelRaisePE12OPT3.Visible = true;
                LabelRespondPE12OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE12OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE12OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE12OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE12OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE12OPT = '" + RadioButtonListPE12OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE12OPTMSG.ShowPopupWindow();
        RAISEPE12OPT.Visible = false;


    }
    #endregion
    #region QueryPE13OPT
    private void SetImageQueryPE13OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryPE13OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryPE13OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryPE13OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryPE13OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryPE13OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataPE13OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE13OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaisePE13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT2.Visible = false;
                PanelRaisePE13OPT3.Visible = false;
                PanelHidePE13OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaisePE13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaisePE13OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT2.Visible = true;
                PanelRaisePE13OPT3.Visible = true;
                PanelHidePE13OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaisePE13OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaisePE13OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT2.Visible = true;
                PanelRaisePE13OPT3.Visible = false;
                PanelHidePE13OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryPE13OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit3].[PhysicalExamination] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE13OPT = '" + RadioButtonListPE13OPT.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryPE13OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEPE13OPT.Visible = true;
                RAISEPE13OPT.ShowPopupWindow();
                QueryRaisePE13OPT.Visible = false;
                TextBoxRaisePE13OPT.Visible = false;
                PanelRaisePE13OPT.Visible = false;
                PanelRaisePE13OPT2.Visible = false;
                PanelRaisePE13OPT3.Visible = false;

                LabelRespondPE13OPT.Visible = false;
            }

            else if ((ImageQueryPE13OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE13OPT.Visible = true;
                RAISEPE13OPT.ShowPopupWindow();
                QueryRaisePE13OPT.Visible = true;
                TextBoxRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT2.Visible = false;
                PanelRaisePE13OPT3.Visible = false;
                LabelRespondPE13OPT.Visible = true;
            }

            else if ((ImageQueryPE13OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE13OPT.Visible = true;
                RAISEPE13OPT.ShowPopupWindow();
                QueryRaisePE13OPT.Visible = false;
                TextBoxRaisePE13OPT.Visible = false;
                PanelRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT2.Visible = true;
                PanelRaisePE13OPT3.Visible = false;
                LabelRespondPE13OPT.Visible = false;
            }
            else if ((ImageQueryPE13OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEPE13OPT.Visible = true;
                RAISEPE13OPT.ShowPopupWindow();
                QueryRaisePE13OPT.Visible = false;
                TextBoxRaisePE13OPT.Visible = false;
                PanelRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT2.Visible = true;
                PanelRaisePE13OPT3.Visible = true;
                LabelRespondPE13OPT.Visible = false;
            }
            else
            {
                RAISEPE13OPT.Visible = true;
                RAISEPE13OPT.ShowPopupWindow();
                QueryRaisePE13OPT.Visible = false;
                TextBoxRaisePE13OPT.Visible = false;
                PanelRaisePE13OPT.Visible = true;
                PanelRaisePE13OPT2.Visible = true;
                PanelRaisePE13OPT3.Visible = true;
                LabelRespondPE13OPT.Visible = false;

            }
        }

    }
    protected void QueryRaisePE13OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaisePE13OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE13OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblPE13OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit3].[PhysicalExamination] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and PE13OPT = '" + RadioButtonListPE13OPT.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEPE13OPTMSG.ShowPopupWindow();
        RAISEPE13OPT.Visible = false;


    }
    #endregion
    


    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListPEPER.SelectedValue == "Yes")
        {
            hidePE.Visible = true;
        }
        else
        {
            hidePE.Visible = false;
        }
    }

    protected void RadioButtonListPEPER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListPEPER.SelectedValue == "Yes")
        {
            hidePE.Visible = true;
        }
        else
        {
            hidePE.Visible = false;
            RadioButtonListPE1OPT.ClearSelection();
            RadioButtonListPE2OPT.ClearSelection();
            RadioButtonListPE3OPT.ClearSelection();
            RadioButtonListPE4OPT.ClearSelection();
            RadioButtonListPE5OPT.ClearSelection();
            RadioButtonListPE6OPT.ClearSelection();
            RadioButtonListPE7OPT.ClearSelection();
            RadioButtonListPE8OPT.ClearSelection();
            RadioButtonListPE9OPT.ClearSelection();
            RadioButtonListPE10OPT.ClearSelection();

            TextBoxPE11NM.Text = string.Empty;
            TextBoxPE12NM.Text = string.Empty;
            TextBoxPE13NM.Text = string.Empty;

            RadioButtonListPE11OPT.ClearSelection();
            RadioButtonListPE12OPT.ClearSelection();
            RadioButtonListPE13OPT.ClearSelection();
        }
    }

}