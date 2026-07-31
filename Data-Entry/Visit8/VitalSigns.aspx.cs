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

public partial class Data_Entry_Visit8_VitalSigns : System.Web.UI.Page
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

        SetImageQueryVSPER();
        SetImageQueryVSDRV();
        SetImageQueryVSTRV();
        SetImageQueryVSSBP();
        SetImageQueryVSDBP();
        SetImageQueryVSPR();
        SetImageQueryVSRR();
        SetImageQueryVSTMP();

        BindQueryDataVSPER();
        BindQueryDataVSDRV();
        BindQueryDataVSTRV();
        BindQueryDataVSSBP();
        BindQueryDataVSDBP();
        BindQueryDataVSPR();
        BindQueryDataVSRR();
        BindQueryDataVSTMP();

        ShowHide();

        TextBoxVSDRV_CalendarExtender.EndDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select VSPER , VSDRV , VSTRV , VSSBP , VSSBPU , VSSBPI , VSSBPCS , VSDBP , VSDBPU , VSDBPI , VSDBPCS , VSPR , VSPRU , VSPRI , VSPRCS , VSRR , VSRRU , VSRRI , VSRRCS , VSTMP , VSTMPU , VSTMPI , VSTMPCS from [Visit8].[VitalSigns] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            RadioButtonListVSPER.SelectedValue = dt.Rows[0]["VSPER"].ToString().Trim();
            TextBoxVSDRV.Text = dt.Rows[0]["VSDRV"].ToString().Trim();
            TextBoxVSTRV.Text = dt.Rows[0]["VSTRV"].ToString().Trim();
            TextBoxVSSBP.Text = dt.Rows[0]["VSSBP"].ToString().Trim();
            TextBoxVSSBPU.Text = dt.Rows[0]["VSSBPU"].ToString().Trim();
            RadioButtonListVSSBPI.SelectedValue = dt.Rows[0]["VSSBPI"].ToString().Trim();
            RadioButtonListVSSBPCS.SelectedValue = dt.Rows[0]["VSSBPCS"].ToString().Trim();
            TextBoxVSDBP.Text = dt.Rows[0]["VSDBP"].ToString().Trim();
            TextBoxVSDBPU.Text = dt.Rows[0]["VSDBPU"].ToString().Trim();
            RadioButtonListVSDBPI.SelectedValue = dt.Rows[0]["VSDBPI"].ToString().Trim();
            RadioButtonListVSDBPCS.SelectedValue = dt.Rows[0]["VSDBPC"].ToString().Trim();
            TextBoxVSPR.Text = dt.Rows[0]["VSPR"].ToString().Trim();
            TextBoxVSPRU.Text = dt.Rows[0]["VSPRU"].ToString().Trim();
            RadioButtonListVSPRI.SelectedValue = dt.Rows[0]["VSPRI"].ToString().Trim();
            RadioButtonListVSPRCS.SelectedValue = dt.Rows[0]["VSPRCS"].ToString().Trim();
            TextBoxVSRR.Text = dt.Rows[0]["VSRR"].ToString().Trim();
            TextBoxVSRRU.Text = dt.Rows[0]["VSRRU"].ToString().Trim();
            RadioButtonListVSRRI.SelectedValue = dt.Rows[0]["VSRRI"].ToString().Trim();
            RadioButtonListVSRRCS.SelectedValue = dt.Rows[0]["VSRRCS"].ToString().Trim();
            TextBoxVSTMP.Text = dt.Rows[0]["VSTMP"].ToString().Trim();
            TextBoxVSTMPU.Text = dt.Rows[0]["VSTMPU"].ToString().Trim();
            RadioButtonListVSTMPI.SelectedValue = dt.Rows[0]["VSTMPI"].ToString().Trim();
            RadioButtonListVSTMPCS.SelectedValue = dt.Rows[0]["VSTMPCS"].ToString().Trim();

            ViewState["txt1"] = RadioButtonListVSPER.SelectedValue;
            ViewState["txt2"] = TextBoxVSDRV.Text;
            ViewState["txt3"] = TextBoxVSTRV.Text;
            ViewState["txt4"] = TextBoxVSSBP.Text;
            ViewState["txt5"] = TextBoxVSSBPU.Text;
            ViewState["txt6"] = RadioButtonListVSSBPI.SelectedValue;
            ViewState["txt7"] = RadioButtonListVSSBPCS.SelectedValue;
            ViewState["txt8"] = TextBoxVSDBP.Text;
            ViewState["txt9"] = TextBoxVSDBPU.Text;
            ViewState["txt10"] = RadioButtonListVSDBPI.SelectedValue;
            ViewState["txt11"] = RadioButtonListVSDBPCS.SelectedValue;
            ViewState["txt12"] = TextBoxVSPR.Text;
            ViewState["txt13"] = TextBoxVSPRU.Text;
            ViewState["txt14"] = RadioButtonListVSPRI.SelectedValue;
            ViewState["txt15"] = RadioButtonListVSPRCS.SelectedValue;
            ViewState["txt16"] = TextBoxVSRR.Text;
            ViewState["txt17"] = TextBoxVSRRU.Text;
            ViewState["txt18"] = RadioButtonListVSRRI.SelectedValue;
            ViewState["txt19"] = RadioButtonListVSRRCS.SelectedValue;
            ViewState["txt20"] = TextBoxVSTMP.Text;
            ViewState["txt21"] = TextBoxVSTMPU.Text;
            ViewState["txt22"] = RadioButtonListVSTMPI.SelectedValue;
            ViewState["txt23"] = RadioButtonListVSTMPCS.SelectedValue;
        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit8].[VitalSigns] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit8].[VitalSigns] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit8].[sp_VitalSigns]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@VSPER", RadioButtonListVSPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSDRV", TextBoxVSDRV.Text);
                    cmd.Parameters.AddWithValue("@VSTRV", TextBoxVSTRV.Text);
                    cmd.Parameters.AddWithValue("@VSSBP", TextBoxVSSBP.Text);
                    cmd.Parameters.AddWithValue("@VSSBPU", TextBoxVSSBPU.Text);
                    cmd.Parameters.AddWithValue("@VSSBPI", RadioButtonListVSSBPI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSSBPCS", RadioButtonListVSSBPCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSDBP", TextBoxVSDBP.Text);
                    cmd.Parameters.AddWithValue("@VSDBPU", TextBoxVSDBPU.Text);
                    cmd.Parameters.AddWithValue("@VSDBPI", RadioButtonListVSDBPI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSDBPCS", RadioButtonListVSDBPCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSPR", TextBoxVSPR.Text);
                    cmd.Parameters.AddWithValue("@VSPRU", TextBoxVSPRU.Text);
                    cmd.Parameters.AddWithValue("@VSPRI", RadioButtonListVSPRI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSPRCS", RadioButtonListVSPRCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSRR", TextBoxVSRR.Text);
                    cmd.Parameters.AddWithValue("@VSRRU", TextBoxVSRRU.Text);
                    cmd.Parameters.AddWithValue("@VSRRI", RadioButtonListVSRRI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSRRCS", RadioButtonListVSRRCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSTMP", TextBoxVSTMP.Text);
                    cmd.Parameters.AddWithValue("@VSTMPU", TextBoxVSTMPU.Text);
                    cmd.Parameters.AddWithValue("@VSTMPI", RadioButtonListVSTMPI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSTMPCS", RadioButtonListVSTMPCS.SelectedValue);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit8].[VitalSigns] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListVSPER.SelectedValue || ViewState["txt2"].ToString() != TextBoxVSDRV.Text || ViewState["txt3"].ToString() != TextBoxVSTRV.Text || ViewState["txt4"].ToString() != TextBoxVSSBP.Text || ViewState["txt5"].ToString() != TextBoxVSSBPU.Text || ViewState["txt6"].ToString() != RadioButtonListVSSBPI.SelectedValue || ViewState["txt7"].ToString() != RadioButtonListVSSBPCS.SelectedValue || ViewState["txt8"].ToString() != TextBoxVSDBP.Text || ViewState["txt9"].ToString() != TextBoxVSDBPU.Text || ViewState["txt10"].ToString() != RadioButtonListVSDBPI.SelectedValue || ViewState["txt11"].ToString() != RadioButtonListVSDBPCS.SelectedValue || ViewState["txt12"].ToString() != TextBoxVSPR.Text || ViewState["txt13"].ToString() != TextBoxVSPRU.Text || ViewState["txt14"].ToString() != RadioButtonListVSPRI.SelectedValue || ViewState["txt15"].ToString() != RadioButtonListVSPRCS.SelectedValue || ViewState["txt16"].ToString() != TextBoxVSRR.Text || ViewState["txt17"].ToString() != TextBoxVSRRU.Text || ViewState["txt18"].ToString() != RadioButtonListVSRRI.SelectedValue || ViewState["txt19"].ToString() != RadioButtonListVSRRCS.SelectedValue || ViewState["txt20"].ToString() != TextBoxVSTMP.Text || ViewState["txt21"].ToString() != TextBoxVSTMPU.Text || ViewState["txt22"].ToString() != RadioButtonListVSTMPI.SelectedValue || ViewState["txt23"].ToString() != RadioButtonListVSTMPCS.SelectedValue)
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
                cmd = new SqlCommand("[Visit8].[sp_VitalSigns]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@VSPER", RadioButtonListVSPER.SelectedValue);
                cmd.Parameters.AddWithValue("@VSDRV", TextBoxVSDRV.Text);
                cmd.Parameters.AddWithValue("@VSTRV", TextBoxVSTRV.Text);
                cmd.Parameters.AddWithValue("@VSSBP", TextBoxVSSBP.Text);
                cmd.Parameters.AddWithValue("@VSSBPU", TextBoxVSSBPU.Text);
                cmd.Parameters.AddWithValue("@VSSBPI", RadioButtonListVSSBPI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSSBPCS", RadioButtonListVSSBPCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSDBP", TextBoxVSDBP.Text);
                cmd.Parameters.AddWithValue("@VSDBPU", TextBoxVSDBPU.Text);
                cmd.Parameters.AddWithValue("@VSDBPI", RadioButtonListVSDBPI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSDBPCS", RadioButtonListVSDBPCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSPR", TextBoxVSPR.Text);
                cmd.Parameters.AddWithValue("@VSPRU", TextBoxVSPRU.Text);
                cmd.Parameters.AddWithValue("@VSPRI", RadioButtonListVSPRI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSPRCS", RadioButtonListVSPRCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSRR", TextBoxVSRR.Text);
                cmd.Parameters.AddWithValue("@VSRRU", TextBoxVSRRU.Text);
                cmd.Parameters.AddWithValue("@VSRRI", RadioButtonListVSRRI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSRRCS", RadioButtonListVSRRCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSTMP", TextBoxVSTMP.Text);
                cmd.Parameters.AddWithValue("@VSTMPU", TextBoxVSTMPU.Text);
                cmd.Parameters.AddWithValue("@VSTMPI", RadioButtonListVSTMPI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSTMPCS", RadioButtonListVSTMPCS.SelectedValue);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit8].[VitalSigns] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit8].[sp_VitalSigns]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                    cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                    cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                    cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                    cmd.Parameters.AddWithValue("@VSPER", RadioButtonListVSPER.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSDRV", TextBoxVSDRV.Text);
                    cmd.Parameters.AddWithValue("@VSTRV", TextBoxVSTRV.Text);
                    cmd.Parameters.AddWithValue("@VSSBP", TextBoxVSSBP.Text);
                    cmd.Parameters.AddWithValue("@VSSBPU", TextBoxVSSBPU.Text);
                    cmd.Parameters.AddWithValue("@VSSBPI", RadioButtonListVSSBPI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSSBPCS", RadioButtonListVSSBPCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSDBP", TextBoxVSDBP.Text);
                    cmd.Parameters.AddWithValue("@VSDBPU", TextBoxVSDBPU.Text);
                    cmd.Parameters.AddWithValue("@VSDBPI", RadioButtonListVSDBPI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSDBPCS", RadioButtonListVSDBPCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSPR", TextBoxVSPR.Text);
                    cmd.Parameters.AddWithValue("@VSPRU", TextBoxVSPRU.Text);
                    cmd.Parameters.AddWithValue("@VSPRI", RadioButtonListVSPRI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSPRCS", RadioButtonListVSPRCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSRR", TextBoxVSRR.Text);
                    cmd.Parameters.AddWithValue("@VSRRU", TextBoxVSRRU.Text);
                    cmd.Parameters.AddWithValue("@VSRRI", RadioButtonListVSRRI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSRRCS", RadioButtonListVSRRCS.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSTMP", TextBoxVSTMP.Text);
                    cmd.Parameters.AddWithValue("@VSTMPU", TextBoxVSTMPU.Text);
                    cmd.Parameters.AddWithValue("@VSTMPI", RadioButtonListVSTMPI.SelectedValue);
                    cmd.Parameters.AddWithValue("@VSTMPCS", RadioButtonListVSTMPCS.SelectedValue);

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
                cmd = new SqlCommand("[Visit8].[sp_VitalSigns]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
                cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
                cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
                cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

                cmd.Parameters.AddWithValue("@VSPER", RadioButtonListVSPER.SelectedValue);
                cmd.Parameters.AddWithValue("@VSDRV", TextBoxVSDRV.Text);
                cmd.Parameters.AddWithValue("@VSTRV", TextBoxVSTRV.Text);
                cmd.Parameters.AddWithValue("@VSSBP", TextBoxVSSBP.Text);
                cmd.Parameters.AddWithValue("@VSSBPU", TextBoxVSSBPU.Text);
                cmd.Parameters.AddWithValue("@VSSBPI", RadioButtonListVSSBPI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSSBPCS", RadioButtonListVSSBPCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSDBP", TextBoxVSDBP.Text);
                cmd.Parameters.AddWithValue("@VSDBPU", TextBoxVSDBPU.Text);
                cmd.Parameters.AddWithValue("@VSDBPI", RadioButtonListVSDBPI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSDBPCS", RadioButtonListVSDBPCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSPR", TextBoxVSPR.Text);
                cmd.Parameters.AddWithValue("@VSPRU", TextBoxVSPRU.Text);
                cmd.Parameters.AddWithValue("@VSPRI", RadioButtonListVSPRI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSPRCS", RadioButtonListVSPRCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSRR", TextBoxVSRR.Text);
                cmd.Parameters.AddWithValue("@VSRRU", TextBoxVSRRU.Text);
                cmd.Parameters.AddWithValue("@VSRRI", RadioButtonListVSRRI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSRRCS", RadioButtonListVSRRCS.SelectedValue);
                cmd.Parameters.AddWithValue("@VSTMP", TextBoxVSTMP.Text);
                cmd.Parameters.AddWithValue("@VSTMPU", TextBoxVSTMPU.Text);
                cmd.Parameters.AddWithValue("@VSTMPI", RadioButtonListVSTMPI.SelectedValue);
                cmd.Parameters.AddWithValue("@VSTMPCS", RadioButtonListVSTMPCS.SelectedValue);

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
        if (!string.IsNullOrEmpty(RadioButtonListVSPER.SelectedValue) || !string.IsNullOrEmpty(TextBoxVSDRV.Text) || !string.IsNullOrEmpty(TextBoxVSTRV.Text) || !string.IsNullOrEmpty(TextBoxVSSBP.Text) || !string.IsNullOrEmpty(TextBoxVSSBPU.Text) || !string.IsNullOrEmpty(RadioButtonListVSSBPI.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListVSSBPCS.SelectedValue) || !string.IsNullOrEmpty(TextBoxVSDBP.Text) || !string.IsNullOrEmpty(TextBoxVSDBPU.Text) || !string.IsNullOrEmpty(RadioButtonListVSDBPI.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListVSDBPCS.SelectedValue) || !string.IsNullOrEmpty(TextBoxVSPR.Text) || !string.IsNullOrEmpty(TextBoxVSPRU.Text) || !string.IsNullOrEmpty(RadioButtonListVSPRI.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListVSPRCS.SelectedValue) || !string.IsNullOrEmpty(TextBoxVSRR.Text) || !string.IsNullOrEmpty(TextBoxVSRRU.Text) || !string.IsNullOrEmpty(RadioButtonListVSRRI.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListVSRRCS.SelectedValue) || !string.IsNullOrEmpty(TextBoxVSTMP.Text) || !string.IsNullOrEmpty(TextBoxVSTMPU.Text) || !string.IsNullOrEmpty(RadioButtonListVSTMPI.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListVSTMPCS.SelectedValue))
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["oldData"];
            if (ViewState["txt1"].ToString() != RadioButtonListVSPER.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSPER.Text;
                dtrow["OldValue"] = dt1.Rows[0][0];
                dtrow["NewValue"] = RadioButtonListVSPER.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt2"].ToString() !=  TextBoxVSDRV.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSDRV.Text;
                dtrow["OldValue"] = dt1.Rows[0][1];
                dtrow["NewValue"] = TextBoxVSDRV.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt3"].ToString() !=  TextBoxVSTRV.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSTRV.Text;
                dtrow["OldValue"] = dt1.Rows[0][2];
                dtrow["NewValue"] = TextBoxVSTRV.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt4"].ToString() !=  TextBoxVSSBP.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSSBP.Text;
                dtrow["OldValue"] = dt1.Rows[0][3];
                dtrow["NewValue"] = TextBoxVSSBP.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt5"].ToString() !=  TextBoxVSSBPU.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSSBPU.Text;
                dtrow["OldValue"] = dt1.Rows[0][4];
                dtrow["NewValue"] = TextBoxVSSBPU.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt6"].ToString() !=  RadioButtonListVSSBPI.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSSBPI.Text;
                dtrow["OldValue"] = dt1.Rows[0][5];
                dtrow["NewValue"] = RadioButtonListVSSBPI.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt7"].ToString() !=  RadioButtonListVSSBPCS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSSBPCS.Text;
                dtrow["OldValue"] = dt1.Rows[0][6];
                dtrow["NewValue"] = RadioButtonListVSSBPCS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt8"].ToString() !=  TextBoxVSDBP.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSDBP.Text;
                dtrow["OldValue"] = dt1.Rows[0][7];
                dtrow["NewValue"] = TextBoxVSDBP.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt9"].ToString() !=  TextBoxVSDBPU.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSDBPU.Text;
                dtrow["OldValue"] = dt1.Rows[0][8];
                dtrow["NewValue"] = TextBoxVSDBPU.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt10"].ToString() !=  RadioButtonListVSDBPI.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSDBPI.Text;
                dtrow["OldValue"] = dt1.Rows[0][9];
                dtrow["NewValue"] = RadioButtonListVSDBPI.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt11"].ToString() != RadioButtonListVSDBPCS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSDBPCS.Text;
                dtrow["OldValue"] = dt1.Rows[0][10];
                dtrow["NewValue"] = RadioButtonListVSDBPCS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt12"].ToString() != TextBoxVSPR.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSPR.Text;
                dtrow["OldValue"] = dt1.Rows[0][11];
                dtrow["NewValue"] = TextBoxVSPR.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt13"].ToString() != TextBoxVSPRU.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSPRU.Text;
                dtrow["OldValue"] = dt1.Rows[0][12];
                dtrow["NewValue"] = TextBoxVSPRU.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt14"].ToString() != RadioButtonListVSPRI.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSPRI.Text;
                dtrow["OldValue"] = dt1.Rows[0][13];
                dtrow["NewValue"] = RadioButtonListVSPRI.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt15"].ToString() != RadioButtonListVSPRCS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSPRCS.Text;
                dtrow["OldValue"] = dt1.Rows[0][14];
                dtrow["NewValue"] = RadioButtonListVSPRCS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt16"].ToString() != TextBoxVSRR.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSRR.Text;
                dtrow["OldValue"] = dt1.Rows[0][15];
                dtrow["NewValue"] = TextBoxVSRR.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt17"].ToString() != TextBoxVSRRU.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSRRU.Text;
                dtrow["OldValue"] = dt1.Rows[0][16];
                dtrow["NewValue"] = TextBoxVSRRU.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt18"].ToString() != RadioButtonListVSRRI.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSRRI.Text;
                dtrow["OldValue"] = dt1.Rows[0][17];
                dtrow["NewValue"] = RadioButtonListVSRRI.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt19"].ToString() != RadioButtonListVSRRCS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSRRCS.Text;
                dtrow["OldValue"] = dt1.Rows[0][18];
                dtrow["NewValue"] = RadioButtonListVSRRCS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt20"].ToString() != TextBoxVSTMP.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSTMP.Text;
                dtrow["OldValue"] = dt1.Rows[0][19];
                dtrow["NewValue"] = TextBoxVSTMP.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt21"].ToString() != TextBoxVSTMPU.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSTMPU.Text;
                dtrow["OldValue"] = dt1.Rows[0][20];
                dtrow["NewValue"] = TextBoxVSTMPU.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt22"].ToString() != RadioButtonListVSTMPI.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow(); 
                dtrow["Column"] = lblVSTMPI.Text;
                dtrow["OldValue"] = dt1.Rows[0][21];
                dtrow["NewValue"] = RadioButtonListVSTMPI.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt23"].ToString() != RadioButtonListVSTMPCS.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblVSTMPCS.Text;
                dtrow["OldValue"] = dt1.Rows[0][22];
                dtrow["NewValue"] = RadioButtonListVSTMPCS.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit8].[sp_VitalSigns]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROTNUM", lblProtocolNumber.Text);
            cmd.Parameters.AddWithValue("@SITENUM", Request.QueryString["a"]);
            cmd.Parameters.AddWithValue("@SUBNUM", Request.QueryString["b"]);
            cmd.Parameters.AddWithValue("@SUBINI", Request.QueryString["c"]);

            cmd.Parameters.AddWithValue("@VSPER", RadioButtonListVSPER.SelectedValue);
            cmd.Parameters.AddWithValue("@VSDRV", TextBoxVSDRV.Text);
            cmd.Parameters.AddWithValue("@VSTRV", TextBoxVSTRV.Text);
            cmd.Parameters.AddWithValue("@VSSBP", TextBoxVSSBP.Text);
            cmd.Parameters.AddWithValue("@VSSBPU", TextBoxVSSBPU.Text);
            cmd.Parameters.AddWithValue("@VSSBPI", RadioButtonListVSSBPI.SelectedValue);
            cmd.Parameters.AddWithValue("@VSSBPCS", RadioButtonListVSSBPCS.SelectedValue);
            cmd.Parameters.AddWithValue("@VSDBP", TextBoxVSDBP.Text);
            cmd.Parameters.AddWithValue("@VSDBPU", TextBoxVSDBPU.Text);
            cmd.Parameters.AddWithValue("@VSDBPI", RadioButtonListVSDBPI.SelectedValue);
            cmd.Parameters.AddWithValue("@VSDBPCS", RadioButtonListVSDBPCS.SelectedValue);
            cmd.Parameters.AddWithValue("@VSPR", TextBoxVSPR.Text);
            cmd.Parameters.AddWithValue("@VSPRU", TextBoxVSPRU.Text);
            cmd.Parameters.AddWithValue("@VSPRI", RadioButtonListVSPRI.SelectedValue);
            cmd.Parameters.AddWithValue("@VSPRCS", RadioButtonListVSPRCS.SelectedValue);
            cmd.Parameters.AddWithValue("@VSRR", TextBoxVSRR.Text);
            cmd.Parameters.AddWithValue("@VSRRU", TextBoxVSRRU.Text);
            cmd.Parameters.AddWithValue("@VSRRI", RadioButtonListVSRRI.SelectedValue);
            cmd.Parameters.AddWithValue("@VSRRCS", RadioButtonListVSRRCS.SelectedValue);
            cmd.Parameters.AddWithValue("@VSTMP", TextBoxVSTMP.Text);
            cmd.Parameters.AddWithValue("@VSTMPU", TextBoxVSTMPU.Text);
            cmd.Parameters.AddWithValue("@VSTMPI", RadioButtonListVSTMPI.SelectedValue);
            cmd.Parameters.AddWithValue("@VSTMPCS", RadioButtonListVSTMPCS.SelectedValue);

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
    #region QueryVSPER
    private void SetImageQueryVSPER()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSPER.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSPER.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSPER.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSPER.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSPER()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPER.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSPER.Visible = true;
                PanelRaiseVSPER2.Visible = false;
                PanelRaiseVSPER3.Visible = false;
                PanelHideVSPER.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSPER3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSPER.Visible = true;
                PanelRaiseVSPER2.Visible = true;
                PanelRaiseVSPER3.Visible = true;
                PanelHideVSPER.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSPER.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSPER2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSPER.Visible = true;
                PanelRaiseVSPER2.Visible = true;
                PanelRaiseVSPER3.Visible = false;
                PanelHideVSPER.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSPER_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSPER = '" + RadioButtonListVSPER.SelectedValue + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSPER.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSPER.Visible = true;
                RAISEVSPER.ShowPopupWindow();
                QueryRaiseVSPER.Visible = false;
                TextBoxRaiseVSPER.Visible = false;
                PanelRaiseVSPER.Visible = false;
                PanelRaiseVSPER2.Visible = false;
                PanelRaiseVSPER3.Visible = false;

                LabelRespondVSPER.Visible = false;
            }

            else if ((ImageQueryVSPER.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSPER.Visible = true;
                RAISEVSPER.ShowPopupWindow();
                QueryRaiseVSPER.Visible = true;
                TextBoxRaiseVSPER.Visible = true;
                PanelRaiseVSPER.Visible = true;
                PanelRaiseVSPER2.Visible = false;
                PanelRaiseVSPER3.Visible = false;
                LabelRespondVSPER.Visible = true;
            }

            else if ((ImageQueryVSPER.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSPER.Visible = true;
                RAISEVSPER.ShowPopupWindow();
                QueryRaiseVSPER.Visible = false;
                TextBoxRaiseVSPER.Visible = false;
                PanelRaiseVSPER.Visible = true;
                PanelRaiseVSPER2.Visible = true;
                PanelRaiseVSPER3.Visible = false;
                LabelRespondVSPER.Visible = false;
            }
            else if ((ImageQueryVSPER.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSPER.Visible = true;
                RAISEVSPER.ShowPopupWindow();
                QueryRaiseVSPER.Visible = false;
                TextBoxRaiseVSPER.Visible = false;
                PanelRaiseVSPER.Visible = true;
                PanelRaiseVSPER2.Visible = true;
                PanelRaiseVSPER3.Visible = true;
                LabelRespondVSPER.Visible = false;
            }
            else
            {
                RAISEVSPER.Visible = true;
                RAISEVSPER.ShowPopupWindow();
                QueryRaiseVSPER.Visible = false;
                TextBoxRaiseVSPER.Visible = false;
                PanelRaiseVSPER.Visible = true;
                PanelRaiseVSPER2.Visible = true;
                PanelRaiseVSPER3.Visible = true;
                LabelRespondVSPER.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSPER_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set  QueryResponse = '" + TextBoxRaiseVSPER.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPER.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPER.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSPER = '" + RadioButtonListVSPER.SelectedValue + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSPERMSG.ShowPopupWindow();
        RAISEVSPER.Visible = false;


    }
    #endregion
    #region QueryVSDRV
    private void SetImageQueryVSDRV()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDRV.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSDRV.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSDRV.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSDRV.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSDRV.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSDRV.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSDRV()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDRV.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSDRV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV2.Visible = false;
                PanelRaiseVSDRV3.Visible = false;
                PanelHideVSDRV.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSDRV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSDRV2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSDRV3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV2.Visible = true;
                PanelRaiseVSDRV3.Visible = true;
                PanelHideVSDRV.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSDRV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSDRV2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV2.Visible = true;
                PanelRaiseVSDRV3.Visible = false;
                PanelHideVSDRV.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSDRV_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSDRV = '" + TextBoxVSDRV.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSDRV.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSDRV.Visible = true;
                RAISEVSDRV.ShowPopupWindow();
                QueryRaiseVSDRV.Visible = false;
                TextBoxRaiseVSDRV.Visible = false;
                PanelRaiseVSDRV.Visible = false;
                PanelRaiseVSDRV2.Visible = false;
                PanelRaiseVSDRV3.Visible = false;

                LabelRespondVSDRV.Visible = false;
            }

            else if ((ImageQueryVSDRV.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDRV.Visible = true;
                RAISEVSDRV.ShowPopupWindow();
                QueryRaiseVSDRV.Visible = true;
                TextBoxRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV2.Visible = false;
                PanelRaiseVSDRV3.Visible = false;
                LabelRespondVSDRV.Visible = true;
            }

            else if ((ImageQueryVSDRV.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDRV.Visible = true;
                RAISEVSDRV.ShowPopupWindow();
                QueryRaiseVSDRV.Visible = false;
                TextBoxRaiseVSDRV.Visible = false;
                PanelRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV2.Visible = true;
                PanelRaiseVSDRV3.Visible = false;
                LabelRespondVSDRV.Visible = false;
            }
            else if ((ImageQueryVSDRV.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDRV.Visible = true;
                RAISEVSDRV.ShowPopupWindow();
                QueryRaiseVSDRV.Visible = false;
                TextBoxRaiseVSDRV.Visible = false;
                PanelRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV2.Visible = true;
                PanelRaiseVSDRV3.Visible = true;
                LabelRespondVSDRV.Visible = false;
            }
            else
            {
                RAISEVSDRV.Visible = true;
                RAISEVSDRV.ShowPopupWindow();
                QueryRaiseVSDRV.Visible = false;
                TextBoxRaiseVSDRV.Visible = false;
                PanelRaiseVSDRV.Visible = true;
                PanelRaiseVSDRV2.Visible = true;
                PanelRaiseVSDRV3.Visible = true;
                LabelRespondVSDRV.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSDRV_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseVSDRV.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDRV.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDRV.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSDRV = '" + TextBoxVSDRV.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSDRVMSG.ShowPopupWindow();
        RAISEVSDRV.Visible = false;


    }
    #endregion
    #region QueryVSTRV
    private void SetImageQueryVSTRV()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTRV.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSTRV.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSTRV.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSTRV.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSTRV.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSTRV.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSTRV()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTRV.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSTRV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV2.Visible = false;
                PanelRaiseVSTRV3.Visible = false;
                PanelHideVSTRV.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSTRV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSTRV2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSTRV3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV2.Visible = true;
                PanelRaiseVSTRV3.Visible = true;
                PanelHideVSTRV.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSTRV.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSTRV2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV2.Visible = true;
                PanelRaiseVSTRV3.Visible = false;
                PanelHideVSTRV.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSTRV_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSTRV = '" + TextBoxVSTRV.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSTRV.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSTRV.Visible = true;
                RAISEVSTRV.ShowPopupWindow();
                QueryRaiseVSTRV.Visible = false;
                TextBoxRaiseVSTRV.Visible = false;
                PanelRaiseVSTRV.Visible = false;
                PanelRaiseVSTRV2.Visible = false;
                PanelRaiseVSTRV3.Visible = false;

                LabelRespondVSTRV.Visible = false;
            }

            else if ((ImageQueryVSTRV.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSTRV.Visible = true;
                RAISEVSTRV.ShowPopupWindow();
                QueryRaiseVSTRV.Visible = true;
                TextBoxRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV2.Visible = false;
                PanelRaiseVSTRV3.Visible = false;
                LabelRespondVSTRV.Visible = true;
            }

            else if ((ImageQueryVSTRV.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSTRV.Visible = true;
                RAISEVSTRV.ShowPopupWindow();
                QueryRaiseVSTRV.Visible = false;
                TextBoxRaiseVSTRV.Visible = false;
                PanelRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV2.Visible = true;
                PanelRaiseVSTRV3.Visible = false;
                LabelRespondVSTRV.Visible = false;
            }
            else if ((ImageQueryVSTRV.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSTRV.Visible = true;
                RAISEVSTRV.ShowPopupWindow();
                QueryRaiseVSTRV.Visible = false;
                TextBoxRaiseVSTRV.Visible = false;
                PanelRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV2.Visible = true;
                PanelRaiseVSTRV3.Visible = true;
                LabelRespondVSTRV.Visible = false;
            }
            else
            {
                RAISEVSTRV.Visible = true;
                RAISEVSTRV.ShowPopupWindow();
                QueryRaiseVSTRV.Visible = false;
                TextBoxRaiseVSTRV.Visible = false;
                PanelRaiseVSTRV.Visible = true;
                PanelRaiseVSTRV2.Visible = true;
                PanelRaiseVSTRV3.Visible = true;
                LabelRespondVSTRV.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSTRV_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseVSTRV.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTRV.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTRV.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSTRV = '" + TextBoxVSTRV.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSTRVMSG.ShowPopupWindow();
        RAISEVSTRV.Visible = false;


    }
    #endregion
    #region QueryVSSBP
    private void SetImageQueryVSSBP()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSSBP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSSBP.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSSBP.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSSBP.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSSBP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSSBP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSSBP()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSSBP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSSBP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP2.Visible = false;
                PanelRaiseVSSBP3.Visible = false;
                PanelHideVSSBP.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSSBP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSSBP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSSBP3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP2.Visible = true;
                PanelRaiseVSSBP3.Visible = true;
                PanelHideVSSBP.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSSBP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSSBP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP2.Visible = true;
                PanelRaiseVSSBP3.Visible = false;
                PanelHideVSSBP.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSSBP_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSSBP = '" + TextBoxVSSBP.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSSBP.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSSBP.Visible = true;
                RAISEVSSBP.ShowPopupWindow();
                QueryRaiseVSSBP.Visible = false;
                TextBoxRaiseVSSBP.Visible = false;
                PanelRaiseVSSBP.Visible = false;
                PanelRaiseVSSBP2.Visible = false;
                PanelRaiseVSSBP3.Visible = false;

                LabelRespondVSSBP.Visible = false;
            }

            else if ((ImageQueryVSSBP.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSSBP.Visible = true;
                RAISEVSSBP.ShowPopupWindow();
                QueryRaiseVSSBP.Visible = true;
                TextBoxRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP2.Visible = false;
                PanelRaiseVSSBP3.Visible = false;
                LabelRespondVSSBP.Visible = true;
            }

            else if ((ImageQueryVSSBP.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSSBP.Visible = true;
                RAISEVSSBP.ShowPopupWindow();
                QueryRaiseVSSBP.Visible = false;
                TextBoxRaiseVSSBP.Visible = false;
                PanelRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP2.Visible = true;
                PanelRaiseVSSBP3.Visible = false;
                LabelRespondVSSBP.Visible = false;
            }
            else if ((ImageQueryVSSBP.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSSBP.Visible = true;
                RAISEVSSBP.ShowPopupWindow();
                QueryRaiseVSSBP.Visible = false;
                TextBoxRaiseVSSBP.Visible = false;
                PanelRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP2.Visible = true;
                PanelRaiseVSSBP3.Visible = true;
                LabelRespondVSSBP.Visible = false;
            }
            else
            {
                RAISEVSSBP.Visible = true;
                RAISEVSSBP.ShowPopupWindow();
                QueryRaiseVSSBP.Visible = false;
                TextBoxRaiseVSSBP.Visible = false;
                PanelRaiseVSSBP.Visible = true;
                PanelRaiseVSSBP2.Visible = true;
                PanelRaiseVSSBP3.Visible = true;
                LabelRespondVSSBP.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSSBP_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseVSSBP.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSSBP.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSSBP.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSSBP = '" + TextBoxVSSBP.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSSBPMSG.ShowPopupWindow();
        RAISEVSSBP.Visible = false;


    }
    #endregion
    #region QueryVSDBP
    private void SetImageQueryVSDBP()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDBP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSDBP.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSDBP.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSDBP.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSDBP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSDBP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSDBP()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDBP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSDBP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP2.Visible = false;
                PanelRaiseVSDBP3.Visible = false;
                PanelHideVSDBP.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSDBP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSDBP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSDBP3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP2.Visible = true;
                PanelRaiseVSDBP3.Visible = true;
                PanelHideVSDBP.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSDBP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSDBP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP2.Visible = true;
                PanelRaiseVSDBP3.Visible = false;
                PanelHideVSDBP.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSDBP_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSDBP = '" + TextBoxVSDBP.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSDBP.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSDBP.Visible = true;
                RAISEVSDBP.ShowPopupWindow();
                QueryRaiseVSDBP.Visible = false;
                TextBoxRaiseVSDBP.Visible = false;
                PanelRaiseVSDBP.Visible = false;
                PanelRaiseVSDBP2.Visible = false;
                PanelRaiseVSDBP3.Visible = false;

                LabelRespondVSDBP.Visible = false;
            }

            else if ((ImageQueryVSDBP.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDBP.Visible = true;
                RAISEVSDBP.ShowPopupWindow();
                QueryRaiseVSDBP.Visible = true;
                TextBoxRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP2.Visible = false;
                PanelRaiseVSDBP3.Visible = false;
                LabelRespondVSDBP.Visible = true;
            }

            else if ((ImageQueryVSDBP.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDBP.Visible = true;
                RAISEVSDBP.ShowPopupWindow();
                QueryRaiseVSDBP.Visible = false;
                TextBoxRaiseVSDBP.Visible = false;
                PanelRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP2.Visible = true;
                PanelRaiseVSDBP3.Visible = false;
                LabelRespondVSDBP.Visible = false;
            }
            else if ((ImageQueryVSDBP.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSDBP.Visible = true;
                RAISEVSDBP.ShowPopupWindow();
                QueryRaiseVSDBP.Visible = false;
                TextBoxRaiseVSDBP.Visible = false;
                PanelRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP2.Visible = true;
                PanelRaiseVSDBP3.Visible = true;
                LabelRespondVSDBP.Visible = false;
            }
            else
            {
                RAISEVSDBP.Visible = true;
                RAISEVSDBP.ShowPopupWindow();
                QueryRaiseVSDBP.Visible = false;
                TextBoxRaiseVSDBP.Visible = false;
                PanelRaiseVSDBP.Visible = true;
                PanelRaiseVSDBP2.Visible = true;
                PanelRaiseVSDBP3.Visible = true;
                LabelRespondVSDBP.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSDBP_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseVSDBP.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDBP.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSDBP.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSDBP = '" + TextBoxVSDBP.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSDBPMSG.ShowPopupWindow();
        RAISEVSDBP.Visible = false;


    }
    #endregion
    #region QueryVSPR
    private void SetImageQueryVSPR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSPR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSPR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSPR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSPR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSPR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSPR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSPR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSPR.Visible = true;
                PanelRaiseVSPR2.Visible = false;
                PanelRaiseVSPR3.Visible = false;
                PanelHideVSPR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSPR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSPR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSPR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSPR.Visible = true;
                PanelRaiseVSPR2.Visible = true;
                PanelRaiseVSPR3.Visible = true;
                PanelHideVSPR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSPR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSPR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSPR.Visible = true;
                PanelRaiseVSPR2.Visible = true;
                PanelRaiseVSPR3.Visible = false;
                PanelHideVSPR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSPR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSPR = '" + TextBoxVSPR.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSPR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSPR.Visible = true;
                RAISEVSPR.ShowPopupWindow();
                QueryRaiseVSPR.Visible = false;
                TextBoxRaiseVSPR.Visible = false;
                PanelRaiseVSPR.Visible = false;
                PanelRaiseVSPR2.Visible = false;
                PanelRaiseVSPR3.Visible = false;

                LabelRespondVSPR.Visible = false;
            }

            else if ((ImageQueryVSPR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSPR.Visible = true;
                RAISEVSPR.ShowPopupWindow();
                QueryRaiseVSPR.Visible = true;
                TextBoxRaiseVSPR.Visible = true;
                PanelRaiseVSPR.Visible = true;
                PanelRaiseVSPR2.Visible = false;
                PanelRaiseVSPR3.Visible = false;
                LabelRespondVSPR.Visible = true;
            }

            else if ((ImageQueryVSPR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSPR.Visible = true;
                RAISEVSPR.ShowPopupWindow();
                QueryRaiseVSPR.Visible = false;
                TextBoxRaiseVSPR.Visible = false;
                PanelRaiseVSPR.Visible = true;
                PanelRaiseVSPR2.Visible = true;
                PanelRaiseVSPR3.Visible = false;
                LabelRespondVSPR.Visible = false;
            }
            else if ((ImageQueryVSPR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSPR.Visible = true;
                RAISEVSPR.ShowPopupWindow();
                QueryRaiseVSPR.Visible = false;
                TextBoxRaiseVSPR.Visible = false;
                PanelRaiseVSPR.Visible = true;
                PanelRaiseVSPR2.Visible = true;
                PanelRaiseVSPR3.Visible = true;
                LabelRespondVSPR.Visible = false;
            }
            else
            {
                RAISEVSPR.Visible = true;
                RAISEVSPR.ShowPopupWindow();
                QueryRaiseVSPR.Visible = false;
                TextBoxRaiseVSPR.Visible = false;
                PanelRaiseVSPR.Visible = true;
                PanelRaiseVSPR2.Visible = true;
                PanelRaiseVSPR3.Visible = true;
                LabelRespondVSPR.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSPR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseVSPR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSPR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSPR = '" + TextBoxVSPR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSPRMSG.ShowPopupWindow();
        RAISEVSPR.Visible = false;


    }
    #endregion
    #region QueryVSRR
    private void SetImageQueryVSRR()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSRR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSRR.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSRR.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSRR.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSRR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSRR.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSRR()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSRR.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSRR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSRR.Visible = true;
                PanelRaiseVSRR2.Visible = false;
                PanelRaiseVSRR3.Visible = false;
                PanelHideVSRR.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSRR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSRR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSRR3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSRR.Visible = true;
                PanelRaiseVSRR2.Visible = true;
                PanelRaiseVSRR3.Visible = true;
                PanelHideVSRR.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSRR.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSRR2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSRR.Visible = true;
                PanelRaiseVSRR2.Visible = true;
                PanelRaiseVSRR3.Visible = false;
                PanelHideVSRR.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSRR_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSRR = '" + TextBoxVSRR.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSRR.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSRR.Visible = true;
                RAISEVSRR.ShowPopupWindow();
                QueryRaiseVSRR.Visible = false;
                TextBoxRaiseVSRR.Visible = false;
                PanelRaiseVSRR.Visible = false;
                PanelRaiseVSRR2.Visible = false;
                PanelRaiseVSRR3.Visible = false;

                LabelRespondVSRR.Visible = false;
            }

            else if ((ImageQueryVSRR.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSRR.Visible = true;
                RAISEVSRR.ShowPopupWindow();
                QueryRaiseVSRR.Visible = true;
                TextBoxRaiseVSRR.Visible = true;
                PanelRaiseVSRR.Visible = true;
                PanelRaiseVSRR2.Visible = false;
                PanelRaiseVSRR3.Visible = false;
                LabelRespondVSRR.Visible = true;
            }

            else if ((ImageQueryVSRR.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSRR.Visible = true;
                RAISEVSRR.ShowPopupWindow();
                QueryRaiseVSRR.Visible = false;
                TextBoxRaiseVSRR.Visible = false;
                PanelRaiseVSRR.Visible = true;
                PanelRaiseVSRR2.Visible = true;
                PanelRaiseVSRR3.Visible = false;
                LabelRespondVSRR.Visible = false;
            }
            else if ((ImageQueryVSRR.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSRR.Visible = true;
                RAISEVSRR.ShowPopupWindow();
                QueryRaiseVSRR.Visible = false;
                TextBoxRaiseVSRR.Visible = false;
                PanelRaiseVSRR.Visible = true;
                PanelRaiseVSRR2.Visible = true;
                PanelRaiseVSRR3.Visible = true;
                LabelRespondVSRR.Visible = false;
            }
            else
            {
                RAISEVSRR.Visible = true;
                RAISEVSRR.ShowPopupWindow();
                QueryRaiseVSRR.Visible = false;
                TextBoxRaiseVSRR.Visible = false;
                PanelRaiseVSRR.Visible = true;
                PanelRaiseVSRR2.Visible = true;
                PanelRaiseVSRR3.Visible = true;
                LabelRespondVSRR.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSRR_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseVSRR.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSRR.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSRR.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSRR = '" + TextBoxVSRR.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSRRMSG.ShowPopupWindow();
        RAISEVSRR.Visible = false;


    }
    #endregion
    #region QueryVSTMP
    private void SetImageQueryVSTMP()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTMP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryVSTMP.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryVSTMP.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryVSTMP.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryVSTMP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryVSTMP.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataVSTMP()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTMP.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseVSTMP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP2.Visible = false;
                PanelRaiseVSTMP3.Visible = false;
                PanelHideVSTMP.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseVSTMP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSTMP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseVSTMP3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP2.Visible = true;
                PanelRaiseVSTMP3.Visible = true;
                PanelHideVSTMP.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseVSTMP.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseVSTMP2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP2.Visible = true;
                PanelRaiseVSTMP3.Visible = false;
                PanelHideVSTMP.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryVSTMP_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit8].[VitalSigns] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSTMP = '" + TextBoxVSTMP.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryVSTMP.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISEVSTMP.Visible = true;
                RAISEVSTMP.ShowPopupWindow();
                QueryRaiseVSTMP.Visible = false;
                TextBoxRaiseVSTMP.Visible = false;
                PanelRaiseVSTMP.Visible = false;
                PanelRaiseVSTMP2.Visible = false;
                PanelRaiseVSTMP3.Visible = false;

                LabelRespondVSTMP.Visible = false;
            }

            else if ((ImageQueryVSTMP.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSTMP.Visible = true;
                RAISEVSTMP.ShowPopupWindow();
                QueryRaiseVSTMP.Visible = true;
                TextBoxRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP2.Visible = false;
                PanelRaiseVSTMP3.Visible = false;
                LabelRespondVSTMP.Visible = true;
            }

            else if ((ImageQueryVSTMP.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSTMP.Visible = true;
                RAISEVSTMP.ShowPopupWindow();
                QueryRaiseVSTMP.Visible = false;
                TextBoxRaiseVSTMP.Visible = false;
                PanelRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP2.Visible = true;
                PanelRaiseVSTMP3.Visible = false;
                LabelRespondVSTMP.Visible = false;
            }
            else if ((ImageQueryVSTMP.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISEVSTMP.Visible = true;
                RAISEVSTMP.ShowPopupWindow();
                QueryRaiseVSTMP.Visible = false;
                TextBoxRaiseVSTMP.Visible = false;
                PanelRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP2.Visible = true;
                PanelRaiseVSTMP3.Visible = true;
                LabelRespondVSTMP.Visible = false;
            }
            else
            {
                RAISEVSTMP.Visible = true;
                RAISEVSTMP.ShowPopupWindow();
                QueryRaiseVSTMP.Visible = false;
                TextBoxRaiseVSTMP.Visible = false;
                PanelRaiseVSTMP.Visible = true;
                PanelRaiseVSTMP2.Visible = true;
                PanelRaiseVSTMP3.Visible = true;
                LabelRespondVSTMP.Visible = false;

            }
        }

    }
    protected void QueryRaiseVSTMP_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseVSTMP.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTMP.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblVSTMP.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit8].[VitalSigns] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and VSTMP = '" + TextBoxVSTMP.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISEVSTMPMSG.ShowPopupWindow();
        RAISEVSTMP.Visible = false;


    }
    #endregion
    #endregion

    protected void lblVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Data-Entry/DataEntryActivityListTab.aspx?a=" + Server.UrlEncode(lblCenterNumber.Text) + "&b=" + Server.UrlEncode(lblScreeningNo.Text) + "&c=" + Server.UrlEncode(lblSubjectInitial.Text.Trim()) + "&d=" + lblVisit.Text);
    }

    protected void ShowHide()
    {
        if (RadioButtonListVSSBPI.SelectedValue == "Normal")
        {
            TextBoxVSSBP.Visible = true;
            TextBoxVSSBPU.Visible = true;
            TextBoxVSSBPU.Text = "mmHg";
            RadioButtonListVSSBPCS.Visible = false;
        }
        else if (RadioButtonListVSSBPI.SelectedValue == "Abnormal")
        {
            TextBoxVSSBP.Visible = true;
            TextBoxVSSBPU.Visible = true;
            TextBoxVSSBPU.Text = "mmHg";
            RadioButtonListVSSBPCS.Visible = true;
        }
        else if (RadioButtonListVSSBPI.SelectedValue == "Not Done")
        {
            TextBoxVSSBP.Visible = false;
            TextBoxVSSBPU.Visible = false;
            RadioButtonListVSSBPCS.Visible = false;
        }
        else
        {
            RadioButtonListVSSBPCS.Visible = false;
        }

        if (RadioButtonListVSDBPI.SelectedValue == "Normal")
        {
            TextBoxVSDBP.Visible = true;
            TextBoxVSDBPU.Visible = true;
            TextBoxVSDBPU.Text = "mmHg";
            RadioButtonListVSDBPCS.Visible = false;
        }
        else if (RadioButtonListVSDBPI.SelectedValue == "Abnormal")
        {
            TextBoxVSDBP.Visible = true;
            TextBoxVSDBPU.Visible = true;
            TextBoxVSDBPU.Text = "mmHg";
            RadioButtonListVSDBPCS.Visible = true;
        }
        else if (RadioButtonListVSDBPI.SelectedValue == "Not Done")
        {
            TextBoxVSDBP.Visible = false;
            TextBoxVSDBPU.Visible = false;
            RadioButtonListVSDBPCS.Visible = false;
        }
        else
        {
            RadioButtonListVSDBPCS.Visible = false;
        }

        if (RadioButtonListVSPRI.SelectedValue == "Normal")
        {
            TextBoxVSPR.Visible = true;
            TextBoxVSPRU.Visible = true;
            TextBoxVSPRU.Text = "beats/min";
            RadioButtonListVSPRCS.Visible = false;
        }
        else if (RadioButtonListVSPRI.SelectedValue == "Abnormal")
        {
            TextBoxVSPR.Visible = true;
            TextBoxVSPRU.Visible = true;
            TextBoxVSPRU.Text = "beats/min";
            RadioButtonListVSPRCS.Visible = true;
        }
        else if (RadioButtonListVSPRI.SelectedValue == "Not Done")
        {
            TextBoxVSPR.Visible = false;
            TextBoxVSPRU.Visible = false;
            RadioButtonListVSPRCS.Visible = false;
        }
        else
        {
            RadioButtonListVSPRCS.Visible = false;
        }

        if (RadioButtonListVSRRI.SelectedValue == "Normal")
        {
            TextBoxVSRR.Visible = true;
            TextBoxVSRRU.Visible = true;
            TextBoxVSRRU.Text = "breaths/min";
            RadioButtonListVSRRCS.Visible = false;
        }
        else if (RadioButtonListVSRRI.SelectedValue == "Abnormal")
        {
            TextBoxVSRR.Visible = true;
            TextBoxVSRRU.Visible = true;
            TextBoxVSRRU.Text = "breaths/min";
            RadioButtonListVSRRCS.Visible = true;
        }
        else if (RadioButtonListVSRRI.SelectedValue == "Not Done")
        {
            TextBoxVSRR.Visible = false;
            TextBoxVSRRU.Visible = false;
            RadioButtonListVSRRCS.Visible = false;
        }
        else
        {
            RadioButtonListVSRRCS.Visible = false;
        }

        if (RadioButtonListVSTMPI.SelectedValue == "Normal")
        {
            TextBoxVSTMP.Visible = true;
            TextBoxVSTMPU.Visible = true;
            TextBoxVSTMPU.Text = "°F";
            RadioButtonListVSTMPCS.Visible = false;
        }
        else if (RadioButtonListVSTMPI.SelectedValue == "Abnormal")
        {
            TextBoxVSTMP.Visible = true;
            TextBoxVSTMPU.Visible = true;
            TextBoxVSTMPU.Text = "°F";
            RadioButtonListVSTMPCS.Visible = true;
        }
        else if (RadioButtonListVSTMPI.SelectedValue == "Not Done")
        {
            TextBoxVSTMP.Visible = false;
            TextBoxVSTMPU.Visible = false;
            RadioButtonListVSTMPCS.Visible = false;
        }
        else
        {
            RadioButtonListVSTMPCS.Visible = false;
        }

        if (RadioButtonListVSPER.SelectedValue == "Yes")
        {
            hideVSDRV.Visible = true;
            hideVSTRV.Visible = true;
            hideVTL.Visible = true;

            TextBoxVSSBPU.Text = "mmHg";
            TextBoxVSDBPU.Text = "mmHg";
            TextBoxVSPRU.Text = "beats/min";
            TextBoxVSRRU.Text = "breaths/min";
            TextBoxVSTMPU.Text = "°F";
        }
        else if (RadioButtonListVSPER.SelectedValue == "No")
        {
            hideVSDRV.Visible = false;
            hideVSTRV.Visible = false;
            hideVTL.Visible = false;
        }
        else
        {
            hideVSDRV.Visible = false;
            hideVSTRV.Visible = false;
            hideVTL.Visible = false;
        }
    }

    protected void RadioButtonListVSSBPI_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListVSSBPI.SelectedValue == "Normal")
        {
            TextBoxVSSBP.Visible = true;
            TextBoxVSSBPU.Visible = true;
            TextBoxVSSBPU.Text = "mmHg";
            RadioButtonListVSSBPCS.Visible = false;
            RadioButtonListVSSBPCS.ClearSelection();
        }
        else if (RadioButtonListVSSBPI.SelectedValue == "Abnormal")
        {
            TextBoxVSSBP.Visible = true;
            TextBoxVSSBPU.Visible = true;
            TextBoxVSSBPU.Text = "mmHg";
            RadioButtonListVSSBPCS.Visible = true;
        }
        else if (RadioButtonListVSSBPI.SelectedValue == "Not Done")
        {
            TextBoxVSSBP.Visible = false;
            TextBoxVSSBPU.Visible = false;
            TextBoxVSSBPU.Text = string.Empty;
            RadioButtonListVSSBPCS.Visible = false;
            RadioButtonListVSSBPCS.ClearSelection();
        }
        else
        {
            RadioButtonListVSSBPCS.Visible = false;
            RadioButtonListVSSBPCS.ClearSelection();
        }
    }

    protected void RadioButtonListVSDBPI_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListVSDBPI.SelectedValue == "Normal")
        {
            TextBoxVSDBP.Visible = true;
            TextBoxVSDBPU.Visible = true;
            TextBoxVSDBPU.Text = "mmHg";
            RadioButtonListVSDBPCS.Visible = false;
            RadioButtonListVSDBPCS.ClearSelection();
        }
        else if (RadioButtonListVSDBPI.SelectedValue == "Abnormal")
        {
            TextBoxVSDBP.Visible = true;
            TextBoxVSDBPU.Visible = true;
            TextBoxVSDBPU.Text = "mmHg";
            RadioButtonListVSDBPCS.Visible = true;
        }
        else if (RadioButtonListVSDBPI.SelectedValue == "Not Done")
        {
            TextBoxVSDBP.Visible = false;
            TextBoxVSDBPU.Visible = false;
            TextBoxVSDBPU.Text = string.Empty;
            RadioButtonListVSDBPCS.Visible = false;
            RadioButtonListVSDBPCS.ClearSelection();
        }
        else
        {
            RadioButtonListVSDBPCS.Visible = false;
            RadioButtonListVSDBPCS.ClearSelection();
        }
    }

    protected void RadioButtonListVSPRI_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListVSPRI.SelectedValue == "Normal")
        {
            TextBoxVSPR.Visible = true;
            TextBoxVSPRU.Visible = true;
            TextBoxVSPRU.Text = "beats/min";
            RadioButtonListVSPRCS.Visible = false;
            RadioButtonListVSPRCS.ClearSelection();
        }
        else if (RadioButtonListVSPRI.SelectedValue == "Abnormal")
        {
            TextBoxVSPR.Visible = true;
            TextBoxVSPRU.Visible = true;
            TextBoxVSPRU.Text = "beats/min";
            RadioButtonListVSPRCS.Visible = true;
        }
        else if (RadioButtonListVSPRI.SelectedValue == "Not Done")
        {
            TextBoxVSPR.Visible = false;
            TextBoxVSPRU.Visible = false;
            TextBoxVSPRU.Text = string.Empty;
            RadioButtonListVSPRCS.Visible = false;
            RadioButtonListVSPRCS.ClearSelection();
        }
        else
        {
            RadioButtonListVSPRCS.Visible = false;
            RadioButtonListVSPRCS.ClearSelection();
        }
    }

    protected void RadioButtonListVSRRI_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListVSRRI.SelectedValue == "Normal")
        {
            TextBoxVSRR.Visible = true;
            TextBoxVSRRU.Visible = true;
            TextBoxVSRRU.Text = "breaths/min";
            RadioButtonListVSRRCS.Visible = false;
            RadioButtonListVSRRCS.ClearSelection();
        }
        else if (RadioButtonListVSRRI.SelectedValue == "Abnormal")
        {
            TextBoxVSRR.Visible = true;
            TextBoxVSRRU.Visible = true;
            TextBoxVSRRU.Text = "breaths/min";
            RadioButtonListVSRRCS.Visible = true;
        }
        else if (RadioButtonListVSRRI.SelectedValue == "Not Done")
        {
            TextBoxVSRR.Visible = false;
            TextBoxVSRRU.Visible = false;
            TextBoxVSRRU.Text = string.Empty;
            RadioButtonListVSRRCS.Visible = false;
            RadioButtonListVSRRCS.ClearSelection();
        }
        else
        {
            RadioButtonListVSRRCS.Visible = false;
            RadioButtonListVSRRCS.ClearSelection();
        }
    }

    protected void RadioButtonListVSTMPI_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListVSTMPI.SelectedValue == "Normal")
        {
            TextBoxVSTMP.Visible = true;
            TextBoxVSTMPU.Visible = true;
            TextBoxVSTMPU.Text = "°F";
            RadioButtonListVSTMPCS.Visible = false;
            RadioButtonListVSTMPCS.ClearSelection();
        }
        else if (RadioButtonListVSTMPI.SelectedValue == "Abnormal")
        {
            TextBoxVSTMP.Visible = true;
            TextBoxVSTMPU.Visible = true;
            TextBoxVSTMPU.Text = "°F";
            RadioButtonListVSTMPCS.Visible = true;
        }
        else if (RadioButtonListVSTMPI.SelectedValue == "Not Done")
        {
            TextBoxVSTMP.Visible = false;
            TextBoxVSTMPU.Visible = false;
            TextBoxVSTMPU.Text = string.Empty;
            RadioButtonListVSTMPCS.Visible = false;
            RadioButtonListVSTMPCS.ClearSelection();
        }
        else
        {
            RadioButtonListVSTMPCS.Visible = false;
            RadioButtonListVSTMPCS.ClearSelection();
        }
    }

    protected void RadioButtonListVSPER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListVSPER.SelectedValue == "Yes")
        {
            hideVSDRV.Visible = true;
            hideVSTRV.Visible = true;
            hideVTL.Visible = true;

            TextBoxVSSBPU.Text = "mmHg";
            TextBoxVSDBPU.Text = "mmHg";
            TextBoxVSPRU.Text = "beats/min";
            TextBoxVSRRU.Text = "breaths/min";
            TextBoxVSTMPU.Text = "°F";
        }
        else if (RadioButtonListVSPER.SelectedValue == "No")
        {
            hideVSDRV.Visible = false;
            hideVSTRV.Visible = false;
            hideVTL.Visible = false;

            TextBoxVSSBP.Text = string.Empty;
            TextBoxVSSBPU.Text = string.Empty;
            RadioButtonListVSSBPI.ClearSelection();
            RadioButtonListVSSBPCS.ClearSelection();

            TextBoxVSDBP.Text = string.Empty;
            TextBoxVSDBPU.Text = string.Empty;
            RadioButtonListVSDBPI.ClearSelection();
            RadioButtonListVSDBPCS.ClearSelection();

            TextBoxVSPR.Text = string.Empty;
            TextBoxVSPRU.Text = string.Empty;
            RadioButtonListVSPRI.ClearSelection();
            RadioButtonListVSPRCS.ClearSelection();

            TextBoxVSRR.Text = string.Empty;
            TextBoxVSRRU.Text = string.Empty;
            RadioButtonListVSRRI.ClearSelection();
            RadioButtonListVSRRCS.ClearSelection();

            TextBoxVSTMP.Text = string.Empty;
            TextBoxVSTMPU.Text = string.Empty;
            RadioButtonListVSTMPI.ClearSelection();
            RadioButtonListVSTMPCS.ClearSelection();
        }
        else
        {
            hideVSDRV.Visible = false;
            hideVSTRV.Visible = false;
            hideVTL.Visible = false;

            TextBoxVSSBP.Text = string.Empty;
            TextBoxVSSBPU.Text = string.Empty;
            RadioButtonListVSSBPI.ClearSelection();
            RadioButtonListVSSBPCS.ClearSelection();

            TextBoxVSDBP.Text = string.Empty;
            TextBoxVSDBPU.Text = string.Empty;
            RadioButtonListVSDBPI.ClearSelection();
            RadioButtonListVSDBPCS.ClearSelection();

            TextBoxVSPR.Text = string.Empty;
            TextBoxVSPRU.Text = string.Empty;
            RadioButtonListVSPRI.ClearSelection();
            RadioButtonListVSPRCS.ClearSelection();

            TextBoxVSRR.Text = string.Empty;
            TextBoxVSRRU.Text = string.Empty;
            RadioButtonListVSRRI.ClearSelection();
            RadioButtonListVSRRCS.ClearSelection();

            TextBoxVSTMP.Text = string.Empty;
            TextBoxVSTMPU.Text = string.Empty;
            RadioButtonListVSTMPI.ClearSelection();
            RadioButtonListVSTMPCS.ClearSelection();
        }
    }
}