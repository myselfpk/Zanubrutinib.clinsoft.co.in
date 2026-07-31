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

public partial class Data_Entry_Visit1_VirologicalTests : System.Web.UI.Page
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

        BindQueryDataLABASS();
        BindQueryDataRSLT1OPT();
        BindQueryDataRSLT2OPT();
        BindQueryDataRSLT3OPT();
        BindQueryDataRSLT4OPT();

        ShowHide();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select LABASS , RSLT1OPT , UN1OPT , NAB1OPT , ABN1OPT , RSLT2OPT , UN2OPT , NAB2OPT , ABN2OPT , RSLT3OPT , UN3OPT , NAB3OPT , ABN3OPT , RSLT4OPT , UN4OPT , NAB4OPT , ABN4OPT from [Visit1].[LabVirologicalTests] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[LabVirologicalTests] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[LabVirologicalTests] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_LabVirologicalTests]", con);
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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[LabVirologicalTests] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListLABASS.SelectedValue || ViewState["txt2"].ToString() != TextBoxRSLT1OPT.Text || ViewState["txt3"].ToString() != TextBoxUN1OPT.Text || ViewState["txt4"].ToString() != RadioButtonListNAB1OPT.SelectedValue || ViewState["txt5"].ToString() != RadioButtonListABN1OPT.SelectedValue || ViewState["txt6"].ToString() != TextBoxRSLT2OPT.Text || ViewState["txt7"].ToString() != TextBoxUN2OPT.Text || ViewState["txt8"].ToString() != RadioButtonListNAB2OPT.SelectedValue || ViewState["txt9"].ToString() != RadioButtonListABN2OPT.SelectedValue || ViewState["txt10"].ToString() != TextBoxRSLT3OPT.Text || ViewState["txt11"].ToString() != TextBoxUN3OPT.Text || ViewState["txt12"].ToString() != RadioButtonListNAB3OPT.SelectedValue || ViewState["txt13"].ToString() != RadioButtonListABN3OPT.SelectedValue || ViewState["txt14"].ToString() != TextBoxRSLT4OPT.Text || ViewState["txt15"].ToString() != TextBoxUN4OPT.Text || ViewState["txt16"].ToString() != RadioButtonListNAB4OPT.SelectedValue || ViewState["txt17"].ToString() != RadioButtonListABN4OPT.SelectedValue)
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
                cmd = new SqlCommand("[Visit1].[sp_LabVirologicalTests]", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[LabVirologicalTests] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_LabVirologicalTests]", con);
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
                cmd = new SqlCommand("[Visit1].[sp_LabVirologicalTests]", con);
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
        if (!string.IsNullOrEmpty(RadioButtonListLABASS.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT1OPT.Text) || !string.IsNullOrEmpty(TextBoxUN1OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN1OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT2OPT.Text) || !string.IsNullOrEmpty(TextBoxUN2OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN2OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT3OPT.Text) || !string.IsNullOrEmpty(TextBoxUN3OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN3OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT4OPT.Text) || !string.IsNullOrEmpty(TextBoxUN4OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB4OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN4OPT.SelectedValue))
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
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_LabVirologicalTests]", con);
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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabVirologicalTests] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LABASS = '" + RadioButtonListLABASS.SelectedValue + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabVirologicalTests] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LABASS = '" + RadioButtonListLABASS.SelectedValue + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabVirologicalTests] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT1OPT = '" + TextBoxRSLT1OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabVirologicalTests] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT1OPT = '" + TextBoxRSLT1OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabVirologicalTests] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT2OPT = '" + TextBoxRSLT2OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabVirologicalTests] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT2OPT = '" + TextBoxRSLT2OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabVirologicalTests] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT3OPT = '" + TextBoxRSLT3OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabVirologicalTests] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT3OPT = '" + TextBoxRSLT3OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabVirologicalTests] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT4OPT = '" + TextBoxRSLT4OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabVirologicalTests] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT4OPT = '" + TextBoxRSLT4OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT4OPTMSG.ShowPopupWindow();
        RAISERSLT4OPT.Visible = false;


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
            hideVIR.Visible = true;
        }
        else
        {
            hideVIR.Visible = false;
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
    }

    protected void RadioButtonListNAB1OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListNAB1OPT.SelectedValue == "Abnormal")
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

    protected void RadioButtonListLABASS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListLABASS.SelectedValue == "Yes")
        {
            hideVIR.Visible = true;
        }
        else
        {
            hideVIR.Visible = false;

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
        }
    }
}