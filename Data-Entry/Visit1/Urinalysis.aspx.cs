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

public partial class Data_Entry_Visit1_Urinalysis : System.Web.UI.Page
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
        SetImageQueryRSLT14OPT();
        SetImageQueryRSLT15OPT();
        SetImageQueryRSLT16OPT();
        SetImageQueryRSLT17OPT();
        SetImageQueryRSLT18OPT();
        SetImageQueryRSLT19OPT();
        SetImageQueryRSLT20OPT();
        SetImageQueryRSLT21OPT();
        SetImageQueryRSLT22OPT();

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
        BindQueryDataRSLT14OPT();
        BindQueryDataRSLT15OPT();
        BindQueryDataRSLT16OPT();
        BindQueryDataRSLT17OPT();
        BindQueryDataRSLT18OPT();
        BindQueryDataRSLT19OPT();
        BindQueryDataRSLT20OPT();
        BindQueryDataRSLT21OPT();
        BindQueryDataRSLT22OPT();
        ShowHide();
    }

    #region DataBinding
    private void BindPage()
    {
        con.Close();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select LABASS , RSLT1OPT , UN1OPT , NAB1OPT , ABN1OPT , RSLT2OPT , UN2OPT , NAB2OPT , ABN2OPT , RSLT3OPT , UN3OPT , NAB3OPT , ABN3OPT , RSLT4OPT , UN4OPT , NAB4OPT , ABN4OPT , RSLT5OPT , UN5OPT , NAB5OPT , ABN5OPT , RSLT6OPT , UN6OPT , NAB6OPT , ABN6OPT , RSLT7OPT , UN7OPT , NAB7OPT , ABN7OPT , RSLT8OPT , UN8OPT , NAB8OPT , ABN8OPT , RSLT9OPT , UN9OPT , NAB9OPT , ABN9OPT , RSLT10OPT , UN10OPT , NAB10OPT , ABN10OPT , RSLT11OPT , UN11OPT , NAB11OPT , ABN11OPT , RSLT12OPT , UN12OPT , NAB12OPT , ABN12OPT , RSLT13OPT , UN13OPT , NAB13OPT , ABN13OPT , RSLT14OPT , UN14OPT , NAB14OPT , ABN14OPT , RSLT15OPT , UN15OPT , NAB15OPT , ABN15OPT , RSLT16OPT , UN16OPT , NAB16OPT , ABN16OPT , RSLT17OPT , UN17OPT , NAB17OPT , ABN17OPT , RSLT18OPT , UN18OPT , NAB18OPT , ABN18OPT , RSLT19OPT , UN19OPT , NAB19OPT , ABN19OPT , RSLT20OPT , UN20OPT , NAB20OPT , ABN20OPT , RSLT21OPT , UN21OPT , NAB21OPT , ABN21OPT , RSLT22OPT , UN22OPT , NAB22OPT , ABN22OPT from [Visit1].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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

            TextBoxRSLT14OPT.Text = dt.Rows[0]["RSLT14OPT"].ToString().Trim();
            TextBoxUN14OPT.Text = dt.Rows[0]["UN14OPT"].ToString().Trim();
            RadioButtonListNAB14OPT.SelectedValue = dt.Rows[0]["NAB14OPT"].ToString().Trim();
            RadioButtonListABN14OPT.SelectedValue = dt.Rows[0]["ABN14OPT"].ToString().Trim();
            TextBoxRSLT15OPT.Text = dt.Rows[0]["RSLT15OPT"].ToString().Trim();
            TextBoxUN15OPT.Text = dt.Rows[0]["UN15OPT"].ToString().Trim();
            RadioButtonListNAB15OPT.SelectedValue = dt.Rows[0]["NAB15OPT"].ToString().Trim();
            RadioButtonListABN15OPT.SelectedValue = dt.Rows[0]["ABN15OPT"].ToString().Trim();
            TextBoxRSLT16OPT.Text = dt.Rows[0]["RSLT16OPT"].ToString().Trim();
            TextBoxUN16OPT.Text = dt.Rows[0]["UN16OPT"].ToString().Trim();
            RadioButtonListNAB16OPT.SelectedValue = dt.Rows[0]["NAB16OPT"].ToString().Trim();
            RadioButtonListABN16OPT.SelectedValue = dt.Rows[0]["ABN16OPT"].ToString().Trim();
            TextBoxRSLT17OPT.Text = dt.Rows[0]["RSLT17OPT"].ToString().Trim();
            TextBoxUN17OPT.Text = dt.Rows[0]["UN17OPT"].ToString().Trim();
            RadioButtonListNAB17OPT.SelectedValue = dt.Rows[0]["NAB17OPT"].ToString().Trim();
            RadioButtonListABN17OPT.SelectedValue = dt.Rows[0]["ABN17OPT"].ToString().Trim();

            TextBoxRSLT18OPT.Text = dt.Rows[0]["RSLT18OPT"].ToString().Trim();
            TextBoxUN18OPT.Text = dt.Rows[0]["UN18OPT"].ToString().Trim();
            RadioButtonListNAB18OPT.SelectedValue = dt.Rows[0]["NAB18OPT"].ToString().Trim();
            RadioButtonListABN18OPT.SelectedValue = dt.Rows[0]["ABN18OPT"].ToString().Trim();

            TextBoxRSLT19OPT.Text = dt.Rows[0]["RSLT19OPT"].ToString().Trim();
            TextBoxUN19OPT.Text = dt.Rows[0]["UN19OPT"].ToString().Trim();
            RadioButtonListNAB19OPT.SelectedValue = dt.Rows[0]["NAB19OPT"].ToString().Trim();
            RadioButtonListABN19OPT.SelectedValue = dt.Rows[0]["ABN19OPT"].ToString().Trim();

            TextBoxRSLT20OPT.Text = dt.Rows[0]["RSLT20OPT"].ToString().Trim();
            TextBoxUN20OPT.Text = dt.Rows[0]["UN20OPT"].ToString().Trim();
            RadioButtonListNAB20OPT.SelectedValue = dt.Rows[0]["NAB20OPT"].ToString().Trim();
            RadioButtonListABN20OPT.SelectedValue = dt.Rows[0]["ABN20OPT"].ToString().Trim();

            TextBoxRSLT21OPT.Text = dt.Rows[0]["RSLT21OPT"].ToString().Trim();
            TextBoxUN21OPT.Text = dt.Rows[0]["UN21OPT"].ToString().Trim();
            RadioButtonListNAB21OPT.SelectedValue = dt.Rows[0]["NAB21OPT"].ToString().Trim();
            RadioButtonListABN21OPT.SelectedValue = dt.Rows[0]["ABN21OPT"].ToString().Trim();

            TextBoxRSLT22OPT.Text = dt.Rows[0]["RSLT22OPT"].ToString().Trim();
            TextBoxUN22OPT.Text = dt.Rows[0]["UN22OPT"].ToString().Trim();
            RadioButtonListNAB22OPT.SelectedValue = dt.Rows[0]["NAB22OPT"].ToString().Trim();
            RadioButtonListABN22OPT.SelectedValue = dt.Rows[0]["ABN22OPT"].ToString().Trim();





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

            ViewState["txt54"] = TextBoxRSLT14OPT.Text;
            ViewState["txt55"] = TextBoxUN14OPT.Text;
            ViewState["txt56"] = RadioButtonListNAB14OPT.SelectedValue;
            ViewState["txt57"] = RadioButtonListABN14OPT.SelectedValue;
            ViewState["txt58"] = TextBoxRSLT15OPT.Text;
            ViewState["txt59"] = TextBoxUN15OPT.Text;
            ViewState["txt60"] = RadioButtonListNAB15OPT.SelectedValue;
            ViewState["txt61"] = RadioButtonListABN15OPT.SelectedValue;
            ViewState["txt62"] = TextBoxRSLT16OPT.Text;
            ViewState["txt63"] = TextBoxUN16OPT.Text;
            ViewState["txt64"] = RadioButtonListNAB16OPT.SelectedValue;
            ViewState["txt65"] = RadioButtonListABN16OPT.SelectedValue;
            ViewState["txt66"] = TextBoxRSLT17OPT.Text;
            ViewState["txt67"] = TextBoxUN17OPT.Text;
            ViewState["txt68"] = RadioButtonListNAB17OPT.SelectedValue;
            ViewState["txt69"] = RadioButtonListABN17OPT.SelectedValue;

            ViewState["txt70"] = TextBoxRSLT18OPT.Text;
            ViewState["txt71"] = TextBoxUN18OPT.Text;
            ViewState["txt72"] = RadioButtonListNAB18OPT.SelectedValue;
            ViewState["txt73"] = RadioButtonListABN18OPT.SelectedValue;
            ViewState["txt74"] = TextBoxRSLT19OPT.Text;
            ViewState["txt75"] = TextBoxUN19OPT.Text;
            ViewState["txt76"] = RadioButtonListNAB19OPT.SelectedValue;
            ViewState["txt77"] = RadioButtonListABN19OPT.SelectedValue;
            ViewState["txt78"] = TextBoxRSLT20OPT.Text;
            ViewState["txt79"] = TextBoxUN20OPT.Text;
            ViewState["txt80"] = RadioButtonListNAB20OPT.SelectedValue;
            ViewState["txt81"] = RadioButtonListABN20OPT.SelectedValue;
            ViewState["txt82"] = TextBoxRSLT21OPT.Text;
            ViewState["txt83"] = TextBoxUN21OPT.Text;
            ViewState["txt84"] = RadioButtonListNAB21OPT.SelectedValue;
            ViewState["txt85"] = RadioButtonListABN21OPT.SelectedValue;
            ViewState["txt86"] = TextBoxRSLT22OPT.Text;
            ViewState["txt87"] = TextBoxUN22OPT.Text;
            ViewState["txt88"] = RadioButtonListNAB22OPT.SelectedValue;
            ViewState["txt89"] = RadioButtonListABN22OPT.SelectedValue;


        }
        con.Close();

    }
    private void PageStatus()
    {
        con.Close();
        DataTable dt1 = new DataTable();
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus,LockStatus from [Visit1].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_LabUrinalysis]", con);
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

                    cmd.Parameters.AddWithValue("@RSLT14OPT", TextBoxRSLT14OPT.Text);
                    cmd.Parameters.AddWithValue("@UN14OPT", TextBoxUN14OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB14OPT", RadioButtonListNAB14OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN14OPT", RadioButtonListABN14OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT15OPT", TextBoxRSLT15OPT.Text);
                    cmd.Parameters.AddWithValue("@UN15OPT", TextBoxUN15OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB15OPT", RadioButtonListNAB15OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN15OPT", RadioButtonListABN15OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT16OPT", TextBoxRSLT16OPT.Text);
                    cmd.Parameters.AddWithValue("@UN16OPT", TextBoxUN16OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB16OPT", RadioButtonListNAB16OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN16OPT", RadioButtonListABN16OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT17OPT", TextBoxRSLT17OPT.Text);
                    cmd.Parameters.AddWithValue("@UN17OPT", TextBoxUN17OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB17OPT", RadioButtonListNAB17OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN17OPT", RadioButtonListABN17OPT.SelectedValue);

                    cmd.Parameters.AddWithValue("@RSLT18OPT", TextBoxRSLT18OPT.Text);
                    cmd.Parameters.AddWithValue("@UN18OPT", TextBoxUN18OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB18OPT", RadioButtonListNAB18OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN18OPT", RadioButtonListABN18OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT19OPT", TextBoxRSLT19OPT.Text);
                    cmd.Parameters.AddWithValue("@UN19OPT", TextBoxUN19OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB19OPT", RadioButtonListNAB19OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN19OPT", RadioButtonListABN19OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT20OPT", TextBoxRSLT20OPT.Text);
                    cmd.Parameters.AddWithValue("@UN20OPT", TextBoxUN20OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB20OPT", RadioButtonListNAB20OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN20OPT", RadioButtonListABN20OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT21OPT", TextBoxRSLT21OPT.Text);
                    cmd.Parameters.AddWithValue("@UN21OPT", TextBoxUN21OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB21OPT", RadioButtonListNAB21OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN21OPT", RadioButtonListABN21OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT22OPT", TextBoxRSLT22OPT.Text);
                    cmd.Parameters.AddWithValue("@UN22OPT", TextBoxUN22OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB22OPT", RadioButtonListNAB22OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN22OPT", RadioButtonListABN22OPT.SelectedValue);

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
                    sqlCmd = new SqlCommand("SELECT ActivefLag FROM [Visit1].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "' and (ActivefLag='0' or ActivefLag='1')", con);
                    sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt1.Rows[0]["ActivefLag"]) == true)
                        {
                            if (ViewState["txt1"].ToString() != RadioButtonListLABASS.SelectedValue || ViewState["txt2"].ToString() != TextBoxRSLT1OPT.Text || ViewState["txt3"].ToString() != TextBoxUN1OPT.Text || ViewState["txt4"].ToString() != RadioButtonListNAB1OPT.SelectedValue || ViewState["txt5"].ToString() != RadioButtonListABN1OPT.SelectedValue || ViewState["txt6"].ToString() != TextBoxRSLT2OPT.Text || ViewState["txt7"].ToString() != TextBoxUN2OPT.Text || ViewState["txt8"].ToString() != RadioButtonListNAB2OPT.SelectedValue || ViewState["txt9"].ToString() != RadioButtonListABN2OPT.SelectedValue || ViewState["txt10"].ToString() != TextBoxRSLT3OPT.Text || ViewState["txt11"].ToString() != TextBoxUN3OPT.Text || ViewState["txt12"].ToString() != RadioButtonListNAB3OPT.SelectedValue || ViewState["txt13"].ToString() != RadioButtonListABN3OPT.SelectedValue || ViewState["txt14"].ToString() != TextBoxRSLT4OPT.Text || ViewState["txt15"].ToString() != TextBoxUN4OPT.Text || ViewState["txt16"].ToString() != RadioButtonListNAB4OPT.SelectedValue || ViewState["txt17"].ToString() != RadioButtonListABN4OPT.SelectedValue || ViewState["txt18"].ToString() != TextBoxRSLT5OPT.Text || ViewState["txt19"].ToString() != TextBoxUN5OPT.Text || ViewState["txt20"].ToString() != RadioButtonListNAB5OPT.SelectedValue || ViewState["txt21"].ToString() != RadioButtonListABN5OPT.SelectedValue || ViewState["txt22"].ToString() != TextBoxRSLT6OPT.Text || ViewState["txt23"].ToString() != TextBoxUN6OPT.Text || ViewState["txt24"].ToString() != RadioButtonListNAB6OPT.SelectedValue || ViewState["txt25"].ToString() != RadioButtonListABN6OPT.SelectedValue || ViewState["txt26"].ToString() != TextBoxRSLT7OPT.Text || ViewState["txt27"].ToString() != TextBoxUN7OPT.Text || ViewState["txt28"].ToString() != RadioButtonListNAB7OPT.SelectedValue || ViewState["txt29"].ToString() != RadioButtonListABN7OPT.SelectedValue || ViewState["txt30"].ToString() != TextBoxRSLT8OPT.Text || ViewState["txt31"].ToString() != TextBoxUN8OPT.Text || ViewState["txt32"].ToString() != RadioButtonListNAB8OPT.SelectedValue || ViewState["txt33"].ToString() != RadioButtonListABN8OPT.SelectedValue || ViewState["txt34"].ToString() != TextBoxRSLT9OPT.Text || ViewState["txt35"].ToString() != TextBoxUN9OPT.Text || ViewState["txt36"].ToString() != RadioButtonListNAB9OPT.SelectedValue || ViewState["txt37"].ToString() != RadioButtonListABN9OPT.SelectedValue || ViewState["txt38"].ToString() != TextBoxRSLT10OPT.Text || ViewState["txt39"].ToString() != TextBoxUN10OPT.Text || ViewState["txt40"].ToString() != RadioButtonListNAB10OPT.SelectedValue || ViewState["txt41"].ToString() != RadioButtonListABN10OPT.SelectedValue || ViewState["txt42"].ToString() != TextBoxRSLT11OPT.Text || ViewState["txt43"].ToString() != TextBoxUN11OPT.Text || ViewState["txt44"].ToString() != RadioButtonListNAB11OPT.SelectedValue || ViewState["txt45"].ToString() != RadioButtonListABN11OPT.SelectedValue || ViewState["txt46"].ToString() != TextBoxRSLT12OPT.Text || ViewState["txt47"].ToString() != TextBoxUN12OPT.Text || ViewState["txt48"].ToString() != RadioButtonListNAB12OPT.SelectedValue || ViewState["txt49"].ToString() != RadioButtonListABN12OPT.SelectedValue || ViewState["txt50"].ToString() != TextBoxRSLT13OPT.Text || ViewState["txt51"].ToString() != TextBoxUN13OPT.Text || ViewState["txt52"].ToString() != RadioButtonListNAB13OPT.SelectedValue || ViewState["txt53"].ToString() != RadioButtonListABN13OPT.SelectedValue || ViewState["txt54"].ToString() != TextBoxRSLT14OPT.Text || ViewState["txt55"].ToString() != TextBoxUN14OPT.Text || ViewState["txt56"].ToString() != RadioButtonListNAB14OPT.SelectedValue || ViewState["txt57"].ToString() != RadioButtonListABN14OPT.SelectedValue || ViewState["txt58"].ToString() != TextBoxRSLT15OPT.Text || ViewState["txt59"].ToString() != TextBoxUN15OPT.Text || ViewState["txt60"].ToString() != RadioButtonListNAB15OPT.SelectedValue || ViewState["txt61"].ToString() != RadioButtonListABN15OPT.SelectedValue || ViewState["txt62"].ToString() != TextBoxRSLT16OPT.Text || ViewState["txt63"].ToString() != TextBoxUN16OPT.Text || ViewState["txt64"].ToString() != RadioButtonListNAB16OPT.SelectedValue || ViewState["txt65"].ToString() != RadioButtonListABN16OPT.SelectedValue || ViewState["txt66"].ToString() != TextBoxRSLT17OPT.Text || ViewState["txt67"].ToString() != TextBoxUN17OPT.Text || ViewState["txt68"].ToString() != RadioButtonListNAB17OPT.SelectedValue || ViewState["txt69"].ToString() != RadioButtonListABN17OPT.SelectedValue || ViewState["txt70"].ToString() != TextBoxRSLT18OPT.Text || ViewState["txt71"].ToString() != TextBoxUN18OPT.Text || ViewState["txt72"].ToString() != RadioButtonListNAB18OPT.SelectedValue || ViewState["txt73"].ToString() != RadioButtonListABN18OPT.SelectedValue || ViewState["txt74"].ToString() != TextBoxRSLT19OPT.Text || ViewState["txt75"].ToString() != TextBoxUN19OPT.Text || ViewState["txt76"].ToString() != RadioButtonListNAB19OPT.SelectedValue || ViewState["txt77"].ToString() != RadioButtonListABN19OPT.SelectedValue || ViewState["txt78"].ToString() != TextBoxRSLT20OPT.Text || ViewState["txt79"].ToString() != TextBoxUN20OPT.Text || ViewState["txt80"].ToString() != RadioButtonListNAB20OPT.SelectedValue || ViewState["txt81"].ToString() != RadioButtonListABN20OPT.SelectedValue || ViewState["txt82"].ToString() != TextBoxRSLT21OPT.Text || ViewState["txt83"].ToString() != TextBoxUN21OPT.Text || ViewState["txt84"].ToString() != RadioButtonListNAB21OPT.SelectedValue || ViewState["txt85"].ToString() != RadioButtonListABN21OPT.SelectedValue || ViewState["txt86"].ToString() != TextBoxRSLT22OPT.Text || ViewState["txt87"].ToString() != TextBoxUN22OPT.Text || ViewState["txt88"].ToString() != RadioButtonListNAB22OPT.SelectedValue || ViewState["txt89"].ToString() != RadioButtonListABN22OPT.SelectedValue)
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
                cmd = new SqlCommand("[Visit1].[sp_LabUrinalysis]", con);
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

                cmd.Parameters.AddWithValue("@RSLT14OPT", TextBoxRSLT14OPT.Text);
                cmd.Parameters.AddWithValue("@UN14OPT", TextBoxUN14OPT.Text);
                cmd.Parameters.AddWithValue("@NAB14OPT", RadioButtonListNAB14OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN14OPT", RadioButtonListABN14OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT15OPT", TextBoxRSLT15OPT.Text);
                cmd.Parameters.AddWithValue("@UN15OPT", TextBoxUN15OPT.Text);
                cmd.Parameters.AddWithValue("@NAB15OPT", RadioButtonListNAB15OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN15OPT", RadioButtonListABN15OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT16OPT", TextBoxRSLT16OPT.Text);
                cmd.Parameters.AddWithValue("@UN16OPT", TextBoxUN16OPT.Text);
                cmd.Parameters.AddWithValue("@NAB16OPT", RadioButtonListNAB16OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN16OPT", RadioButtonListABN16OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT17OPT", TextBoxRSLT17OPT.Text);
                cmd.Parameters.AddWithValue("@UN17OPT", TextBoxUN17OPT.Text);
                cmd.Parameters.AddWithValue("@NAB17OPT", RadioButtonListNAB17OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN17OPT", RadioButtonListABN17OPT.SelectedValue);

                cmd.Parameters.AddWithValue("@RSLT18OPT", TextBoxRSLT18OPT.Text);
                cmd.Parameters.AddWithValue("@UN18OPT", TextBoxUN18OPT.Text);
                cmd.Parameters.AddWithValue("@NAB18OPT", RadioButtonListNAB18OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN18OPT", RadioButtonListABN18OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT19OPT", TextBoxRSLT19OPT.Text);
                cmd.Parameters.AddWithValue("@UN19OPT", TextBoxUN19OPT.Text);
                cmd.Parameters.AddWithValue("@NAB19OPT", RadioButtonListNAB19OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN19OPT", RadioButtonListABN19OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT20OPT", TextBoxRSLT20OPT.Text);
                cmd.Parameters.AddWithValue("@UN20OPT", TextBoxUN20OPT.Text);
                cmd.Parameters.AddWithValue("@NAB20OPT", RadioButtonListNAB20OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN20OPT", RadioButtonListABN20OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT21OPT", TextBoxRSLT21OPT.Text);
                cmd.Parameters.AddWithValue("@UN21OPT", TextBoxUN21OPT.Text);
                cmd.Parameters.AddWithValue("@NAB21OPT", RadioButtonListNAB21OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN21OPT", RadioButtonListABN21OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT22OPT", TextBoxRSLT22OPT.Text);
                cmd.Parameters.AddWithValue("@UN22OPT", TextBoxUN22OPT.Text);
                cmd.Parameters.AddWithValue("@NAB22OPT", RadioButtonListNAB22OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN22OPT", RadioButtonListABN22OPT.SelectedValue);

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
        SqlCommand sqlCmd = new SqlCommand("Select EntryStatus from [Visit1].[LabUrinalysis] where [SITENUM] ='" + Request.QueryString["a"] + "' and [SUBNUM]='" + Request.QueryString["b"] + "'and [SUBINI]='" + Request.QueryString["c"] + "'", con);
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
                    cmd = new SqlCommand("[Visit1].[sp_LabUrinalysis]", con);
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

                    cmd.Parameters.AddWithValue("@RSLT14OPT", TextBoxRSLT14OPT.Text);
                    cmd.Parameters.AddWithValue("@UN14OPT", TextBoxUN14OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB14OPT", RadioButtonListNAB14OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN14OPT", RadioButtonListABN14OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT15OPT", TextBoxRSLT15OPT.Text);
                    cmd.Parameters.AddWithValue("@UN15OPT", TextBoxUN15OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB15OPT", RadioButtonListNAB15OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN15OPT", RadioButtonListABN15OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT16OPT", TextBoxRSLT16OPT.Text);
                    cmd.Parameters.AddWithValue("@UN16OPT", TextBoxUN16OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB16OPT", RadioButtonListNAB16OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN16OPT", RadioButtonListABN16OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT17OPT", TextBoxRSLT17OPT.Text);
                    cmd.Parameters.AddWithValue("@UN17OPT", TextBoxUN17OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB17OPT", RadioButtonListNAB17OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN17OPT", RadioButtonListABN17OPT.SelectedValue);

                    cmd.Parameters.AddWithValue("@RSLT18OPT", TextBoxRSLT18OPT.Text);
                    cmd.Parameters.AddWithValue("@UN18OPT", TextBoxUN18OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB18OPT", RadioButtonListNAB18OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN18OPT", RadioButtonListABN18OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT19OPT", TextBoxRSLT19OPT.Text);
                    cmd.Parameters.AddWithValue("@UN19OPT", TextBoxUN19OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB19OPT", RadioButtonListNAB19OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN19OPT", RadioButtonListABN19OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT20OPT", TextBoxRSLT20OPT.Text);
                    cmd.Parameters.AddWithValue("@UN20OPT", TextBoxUN20OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB20OPT", RadioButtonListNAB20OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN20OPT", RadioButtonListABN20OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT21OPT", TextBoxRSLT21OPT.Text);
                    cmd.Parameters.AddWithValue("@UN21OPT", TextBoxUN21OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB21OPT", RadioButtonListNAB21OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN21OPT", RadioButtonListABN21OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@RSLT22OPT", TextBoxRSLT22OPT.Text);
                    cmd.Parameters.AddWithValue("@UN22OPT", TextBoxUN22OPT.Text);
                    cmd.Parameters.AddWithValue("@NAB22OPT", RadioButtonListNAB22OPT.SelectedValue);
                    cmd.Parameters.AddWithValue("@ABN22OPT", RadioButtonListABN22OPT.SelectedValue);

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
                cmd = new SqlCommand("[Visit1].[sp_LabUrinalysis]", con);
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

                cmd.Parameters.AddWithValue("@RSLT14OPT", TextBoxRSLT14OPT.Text);
                cmd.Parameters.AddWithValue("@UN14OPT", TextBoxUN14OPT.Text);
                cmd.Parameters.AddWithValue("@NAB14OPT", RadioButtonListNAB14OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN14OPT", RadioButtonListABN14OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT15OPT", TextBoxRSLT15OPT.Text);
                cmd.Parameters.AddWithValue("@UN15OPT", TextBoxUN15OPT.Text);
                cmd.Parameters.AddWithValue("@NAB15OPT", RadioButtonListNAB15OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN15OPT", RadioButtonListABN15OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT16OPT", TextBoxRSLT16OPT.Text);
                cmd.Parameters.AddWithValue("@UN16OPT", TextBoxUN16OPT.Text);
                cmd.Parameters.AddWithValue("@NAB16OPT", RadioButtonListNAB16OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN16OPT", RadioButtonListABN16OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT17OPT", TextBoxRSLT17OPT.Text);
                cmd.Parameters.AddWithValue("@UN17OPT", TextBoxUN17OPT.Text);
                cmd.Parameters.AddWithValue("@NAB17OPT", RadioButtonListNAB17OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN17OPT", RadioButtonListABN17OPT.SelectedValue);

                cmd.Parameters.AddWithValue("@RSLT18OPT", TextBoxRSLT18OPT.Text);
                cmd.Parameters.AddWithValue("@UN18OPT", TextBoxUN18OPT.Text);
                cmd.Parameters.AddWithValue("@NAB18OPT", RadioButtonListNAB18OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN18OPT", RadioButtonListABN18OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT19OPT", TextBoxRSLT19OPT.Text);
                cmd.Parameters.AddWithValue("@UN19OPT", TextBoxUN19OPT.Text);
                cmd.Parameters.AddWithValue("@NAB19OPT", RadioButtonListNAB19OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN19OPT", RadioButtonListABN19OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT20OPT", TextBoxRSLT20OPT.Text);
                cmd.Parameters.AddWithValue("@UN20OPT", TextBoxUN20OPT.Text);
                cmd.Parameters.AddWithValue("@NAB20OPT", RadioButtonListNAB20OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN20OPT", RadioButtonListABN20OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT21OPT", TextBoxRSLT21OPT.Text);
                cmd.Parameters.AddWithValue("@UN21OPT", TextBoxUN21OPT.Text);
                cmd.Parameters.AddWithValue("@NAB21OPT", RadioButtonListNAB21OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN21OPT", RadioButtonListABN21OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@RSLT22OPT", TextBoxRSLT22OPT.Text);
                cmd.Parameters.AddWithValue("@UN22OPT", TextBoxUN22OPT.Text);
                cmd.Parameters.AddWithValue("@NAB22OPT", RadioButtonListNAB22OPT.SelectedValue);
                cmd.Parameters.AddWithValue("@ABN22OPT", RadioButtonListABN22OPT.SelectedValue);

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
        if (!string.IsNullOrEmpty(RadioButtonListLABASS.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT1OPT.Text) || !string.IsNullOrEmpty(TextBoxUN1OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB1OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN1OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT2OPT.Text) || !string.IsNullOrEmpty(TextBoxUN2OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB2OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN2OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT3OPT.Text) || !string.IsNullOrEmpty(TextBoxUN3OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB3OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN3OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT4OPT.Text) || !string.IsNullOrEmpty(TextBoxUN4OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB4OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN4OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT5OPT.Text) || !string.IsNullOrEmpty(TextBoxUN5OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB5OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN5OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT6OPT.Text) || !string.IsNullOrEmpty(TextBoxUN6OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB6OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN6OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT7OPT.Text) || !string.IsNullOrEmpty(TextBoxUN7OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB7OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN7OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT8OPT.Text) || !string.IsNullOrEmpty(TextBoxUN8OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB8OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN8OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT9OPT.Text) || !string.IsNullOrEmpty(TextBoxUN9OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB9OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN9OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT10OPT.Text) || !string.IsNullOrEmpty(TextBoxUN10OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB10OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN10OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT11OPT.Text) || !string.IsNullOrEmpty(TextBoxUN11OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB11OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN11OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT12OPT.Text) || !string.IsNullOrEmpty(TextBoxUN12OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB12OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN12OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT13OPT.Text) || !string.IsNullOrEmpty(TextBoxUN13OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB13OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN13OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT14OPT.Text) || !string.IsNullOrEmpty(TextBoxUN14OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB14OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN14OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT15OPT.Text) || !string.IsNullOrEmpty(TextBoxUN15OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB15OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN15OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT16OPT.Text) || !string.IsNullOrEmpty(TextBoxUN16OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB16OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN16OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT17OPT.Text) || !string.IsNullOrEmpty(TextBoxUN17OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB17OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN17OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT18OPT.Text) || !string.IsNullOrEmpty(TextBoxUN18OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB18OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN18OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT19OPT.Text) || !string.IsNullOrEmpty(TextBoxUN19OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB19OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN19OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT20OPT.Text) || !string.IsNullOrEmpty(TextBoxUN20OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB20OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN20OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT21OPT.Text) || !string.IsNullOrEmpty(TextBoxUN21OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB21OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN21OPT.SelectedValue) || !string.IsNullOrEmpty(TextBoxRSLT22OPT.Text) || !string.IsNullOrEmpty(TextBoxUN22OPT.Text) || !string.IsNullOrEmpty(RadioButtonListNAB22OPT.SelectedValue) || !string.IsNullOrEmpty(RadioButtonListABN22OPT.SelectedValue))
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
            if (ViewState["txt54"].ToString() != TextBoxRSLT14OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT14OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][53];
                dtrow["NewValue"] = TextBoxRSLT14OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt55"].ToString() != TextBoxUN14OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN14OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][54];
                dtrow["NewValue"] = TextBoxUN14OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt56"].ToString() != RadioButtonListNAB14OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB14OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][55];
                dtrow["NewValue"] = RadioButtonListNAB14OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt57"].ToString() != RadioButtonListABN14OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN14OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][56];
                dtrow["NewValue"] = RadioButtonListABN14OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt58"].ToString() != TextBoxRSLT15OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT15OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][57];
                dtrow["NewValue"] = TextBoxRSLT15OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt59"].ToString() != TextBoxUN15OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN15OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][58];
                dtrow["NewValue"] = TextBoxUN15OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt60"].ToString() != RadioButtonListNAB15OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB15OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][59];
                dtrow["NewValue"] = RadioButtonListNAB15OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt61"].ToString() != RadioButtonListABN15OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN15OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][60];
                dtrow["NewValue"] = RadioButtonListABN15OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt62"].ToString() != TextBoxRSLT16OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT16OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][61];
                dtrow["NewValue"] = TextBoxRSLT16OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt63"].ToString() != TextBoxUN16OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN16OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][62];
                dtrow["NewValue"] = TextBoxUN16OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt64"].ToString() != RadioButtonListNAB16OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB16OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][63];
                dtrow["NewValue"] = RadioButtonListNAB16OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt65"].ToString() != RadioButtonListABN16OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN16OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][64];
                dtrow["NewValue"] = RadioButtonListABN16OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt66"].ToString() != TextBoxRSLT17OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT17OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][65];
                dtrow["NewValue"] = TextBoxRSLT17OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt67"].ToString() != TextBoxUN17OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN17OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][66];
                dtrow["NewValue"] = TextBoxUN17OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt68"].ToString() != RadioButtonListNAB17OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB17OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][67];
                dtrow["NewValue"] = RadioButtonListNAB17OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt69"].ToString() != RadioButtonListABN17OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN17OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][68];
                dtrow["NewValue"] = RadioButtonListABN17OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt70"].ToString() != TextBoxRSLT18OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT18OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][69];
                dtrow["NewValue"] = TextBoxRSLT18OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt71"].ToString() != TextBoxUN18OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN18OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][70];
                dtrow["NewValue"] = TextBoxUN18OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt72"].ToString() != RadioButtonListNAB18OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB18OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][71];
                dtrow["NewValue"] = RadioButtonListNAB18OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt73"].ToString() != RadioButtonListABN18OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN18OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][72];
                dtrow["NewValue"] = RadioButtonListABN18OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt74"].ToString() != TextBoxRSLT19OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT19OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][73];
                dtrow["NewValue"] = TextBoxRSLT19OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt75"].ToString() != TextBoxUN19OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN19OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][74];
                dtrow["NewValue"] = TextBoxUN19OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt76"].ToString() != RadioButtonListNAB19OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB19OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][75];
                dtrow["NewValue"] = RadioButtonListNAB19OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt77"].ToString() != RadioButtonListABN19OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN19OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][76];
                dtrow["NewValue"] = RadioButtonListABN19OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt78"].ToString() != TextBoxRSLT20OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT20OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][77];
                dtrow["NewValue"] = TextBoxRSLT20OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt79"].ToString() != TextBoxUN20OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN20OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][78];
                dtrow["NewValue"] = TextBoxUN20OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt80"].ToString() != RadioButtonListNAB20OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB20OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][79];
                dtrow["NewValue"] = RadioButtonListNAB20OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt81"].ToString() != RadioButtonListABN20OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN20OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][80];
                dtrow["NewValue"] = RadioButtonListABN20OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt82"].ToString() != TextBoxRSLT21OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT21OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][81];
                dtrow["NewValue"] = TextBoxRSLT21OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt83"].ToString() != TextBoxUN21OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN21OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][82];
                dtrow["NewValue"] = TextBoxUN21OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt84"].ToString() != RadioButtonListNAB21OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB21OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][83];
                dtrow["NewValue"] = RadioButtonListNAB21OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt85"].ToString() != RadioButtonListABN21OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN21OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][84];
                dtrow["NewValue"] = RadioButtonListABN21OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt86"].ToString() != TextBoxRSLT22OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblRSLT22OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][85];
                dtrow["NewValue"] = TextBoxRSLT22OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt87"].ToString() != TextBoxUN22OPT.Text)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblUN22OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][86];
                dtrow["NewValue"] = TextBoxUN22OPT.Text;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt88"].ToString() != RadioButtonListNAB22OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblNAB22OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][87];
                dtrow["NewValue"] = RadioButtonListNAB22OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
            if (ViewState["txt89"].ToString() != RadioButtonListABN22OPT.SelectedValue)
            {
                DataRow dtrow = dtEmp.NewRow();
                dtrow["Column"] = lblABN22OPT.Text;
                dtrow["OldValue"] = dt1.Rows[0][88];
                dtrow["NewValue"] = RadioButtonListABN22OPT.SelectedValue;
                dtEmp.Rows.Add(dtrow);
            }
        }
        return dtEmp;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("[Visit1].[sp_LabUrinalysis]", con);
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

            cmd.Parameters.AddWithValue("@RSLT14OPT", TextBoxRSLT14OPT.Text);
            cmd.Parameters.AddWithValue("@UN14OPT", TextBoxUN14OPT.Text);
            cmd.Parameters.AddWithValue("@NAB14OPT", RadioButtonListNAB14OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN14OPT", RadioButtonListABN14OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT15OPT", TextBoxRSLT15OPT.Text);
            cmd.Parameters.AddWithValue("@UN15OPT", TextBoxUN15OPT.Text);
            cmd.Parameters.AddWithValue("@NAB15OPT", RadioButtonListNAB15OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN15OPT", RadioButtonListABN15OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT16OPT", TextBoxRSLT16OPT.Text);
            cmd.Parameters.AddWithValue("@UN16OPT", TextBoxUN16OPT.Text);
            cmd.Parameters.AddWithValue("@NAB16OPT", RadioButtonListNAB16OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN16OPT", RadioButtonListABN16OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT17OPT", TextBoxRSLT17OPT.Text);
            cmd.Parameters.AddWithValue("@UN17OPT", TextBoxUN17OPT.Text);
            cmd.Parameters.AddWithValue("@NAB17OPT", RadioButtonListNAB17OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN17OPT", RadioButtonListABN17OPT.SelectedValue);

            cmd.Parameters.AddWithValue("@RSLT18OPT", TextBoxRSLT18OPT.Text);
            cmd.Parameters.AddWithValue("@UN18OPT", TextBoxUN18OPT.Text);
            cmd.Parameters.AddWithValue("@NAB18OPT", RadioButtonListNAB18OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN18OPT", RadioButtonListABN18OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT19OPT", TextBoxRSLT19OPT.Text);
            cmd.Parameters.AddWithValue("@UN19OPT", TextBoxUN19OPT.Text);
            cmd.Parameters.AddWithValue("@NAB19OPT", RadioButtonListNAB19OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN19OPT", RadioButtonListABN19OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT20OPT", TextBoxRSLT20OPT.Text);
            cmd.Parameters.AddWithValue("@UN20OPT", TextBoxUN20OPT.Text);
            cmd.Parameters.AddWithValue("@NAB20OPT", RadioButtonListNAB20OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN20OPT", RadioButtonListABN20OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT21OPT", TextBoxRSLT21OPT.Text);
            cmd.Parameters.AddWithValue("@UN21OPT", TextBoxUN21OPT.Text);
            cmd.Parameters.AddWithValue("@NAB21OPT", RadioButtonListNAB21OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN21OPT", RadioButtonListABN21OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@RSLT22OPT", TextBoxRSLT22OPT.Text);
            cmd.Parameters.AddWithValue("@UN22OPT", TextBoxUN22OPT.Text);
            cmd.Parameters.AddWithValue("@NAB22OPT", RadioButtonListNAB22OPT.SelectedValue);
            cmd.Parameters.AddWithValue("@ABN22OPT", RadioButtonListABN22OPT.SelectedValue);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LABASS = '" + RadioButtonListLABASS.SelectedValue + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and LABASS = '" + RadioButtonListLABASS.SelectedValue + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT1OPT = '" + TextBoxRSLT1OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT1OPT = '" + TextBoxRSLT1OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT2OPT = '" + TextBoxRSLT2OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT2OPT = '" + TextBoxRSLT2OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT3OPT = '" + TextBoxRSLT3OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT3OPT = '" + TextBoxRSLT3OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT4OPT = '" + TextBoxRSLT4OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT4OPT = '" + TextBoxRSLT4OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT5OPT = '" + TextBoxRSLT5OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT5OPT = '" + TextBoxRSLT5OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT6OPT = '" + TextBoxRSLT6OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT6OPT = '" + TextBoxRSLT6OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT7OPT = '" + TextBoxRSLT7OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT7OPT = '" + TextBoxRSLT7OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT8OPT = '" + TextBoxRSLT8OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT8OPT = '" + TextBoxRSLT8OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT9OPT = '" + TextBoxRSLT9OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT9OPT = '" + TextBoxRSLT9OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT10OPT = '" + TextBoxRSLT10OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT10OPT = '" + TextBoxRSLT10OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT11OPT = '" + TextBoxRSLT11OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT11OPT = '" + TextBoxRSLT11OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT12OPT = '" + TextBoxRSLT12OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT12OPT = '" + TextBoxRSLT12OPT.Text + "'", con1);

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
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT13OPT = '" + TextBoxRSLT13OPT.Text + "'", con);
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

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT13OPT = '" + TextBoxRSLT13OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT13OPTMSG.ShowPopupWindow();
        RAISERSLT13OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT14OPT
    private void SetImageQueryRSLT14OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT14OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT14OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT14OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT14OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT14OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT14OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT14OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT14OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT2.Visible = false;
                PanelRaiseRSLT14OPT3.Visible = false;
                PanelHideRSLT14OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT14OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT2.Visible = true;
                PanelRaiseRSLT14OPT3.Visible = true;
                PanelHideRSLT14OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT14OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT14OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT2.Visible = true;
                PanelRaiseRSLT14OPT3.Visible = false;
                PanelHideRSLT14OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT14OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT14OPT = '" + TextBoxRSLT14OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT14OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT14OPT.Visible = true;
                RAISERSLT14OPT.ShowPopupWindow();
                QueryRaiseRSLT14OPT.Visible = false;
                TextBoxRaiseRSLT14OPT.Visible = false;
                PanelRaiseRSLT14OPT.Visible = false;
                PanelRaiseRSLT14OPT2.Visible = false;
                PanelRaiseRSLT14OPT3.Visible = false;

                LabelRespondRSLT14OPT.Visible = false;
            }

            else if ((ImageQueryRSLT14OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT14OPT.Visible = true;
                RAISERSLT14OPT.ShowPopupWindow();
                QueryRaiseRSLT14OPT.Visible = true;
                TextBoxRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT2.Visible = false;
                PanelRaiseRSLT14OPT3.Visible = false;
                LabelRespondRSLT14OPT.Visible = true;
            }

            else if ((ImageQueryRSLT14OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT14OPT.Visible = true;
                RAISERSLT14OPT.ShowPopupWindow();
                QueryRaiseRSLT14OPT.Visible = false;
                TextBoxRaiseRSLT14OPT.Visible = false;
                PanelRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT2.Visible = true;
                PanelRaiseRSLT14OPT3.Visible = false;
                LabelRespondRSLT14OPT.Visible = false;
            }
            else if ((ImageQueryRSLT14OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT14OPT.Visible = true;
                RAISERSLT14OPT.ShowPopupWindow();
                QueryRaiseRSLT14OPT.Visible = false;
                TextBoxRaiseRSLT14OPT.Visible = false;
                PanelRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT2.Visible = true;
                PanelRaiseRSLT14OPT3.Visible = true;
                LabelRespondRSLT14OPT.Visible = false;
            }
            else
            {
                RAISERSLT14OPT.Visible = true;
                RAISERSLT14OPT.ShowPopupWindow();
                QueryRaiseRSLT14OPT.Visible = false;
                TextBoxRaiseRSLT14OPT.Visible = false;
                PanelRaiseRSLT14OPT.Visible = true;
                PanelRaiseRSLT14OPT2.Visible = true;
                PanelRaiseRSLT14OPT3.Visible = true;
                LabelRespondRSLT14OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT14OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT14OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT14OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT14OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT14OPT = '" + TextBoxRSLT14OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT14OPTMSG.ShowPopupWindow();
        RAISERSLT14OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT15OPT
    private void SetImageQueryRSLT15OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT15OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT15OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT15OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT15OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT15OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT15OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT15OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT15OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT2.Visible = false;
                PanelRaiseRSLT15OPT3.Visible = false;
                PanelHideRSLT15OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT15OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT2.Visible = true;
                PanelRaiseRSLT15OPT3.Visible = true;
                PanelHideRSLT15OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT15OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT15OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT2.Visible = true;
                PanelRaiseRSLT15OPT3.Visible = false;
                PanelHideRSLT15OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT15OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT15OPT = '" + TextBoxRSLT15OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT15OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT15OPT.Visible = true;
                RAISERSLT15OPT.ShowPopupWindow();
                QueryRaiseRSLT15OPT.Visible = false;
                TextBoxRaiseRSLT15OPT.Visible = false;
                PanelRaiseRSLT15OPT.Visible = false;
                PanelRaiseRSLT15OPT2.Visible = false;
                PanelRaiseRSLT15OPT3.Visible = false;

                LabelRespondRSLT15OPT.Visible = false;
            }

            else if ((ImageQueryRSLT15OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT15OPT.Visible = true;
                RAISERSLT15OPT.ShowPopupWindow();
                QueryRaiseRSLT15OPT.Visible = true;
                TextBoxRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT2.Visible = false;
                PanelRaiseRSLT15OPT3.Visible = false;
                LabelRespondRSLT15OPT.Visible = true;
            }

            else if ((ImageQueryRSLT15OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT15OPT.Visible = true;
                RAISERSLT15OPT.ShowPopupWindow();
                QueryRaiseRSLT15OPT.Visible = false;
                TextBoxRaiseRSLT15OPT.Visible = false;
                PanelRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT2.Visible = true;
                PanelRaiseRSLT15OPT3.Visible = false;
                LabelRespondRSLT15OPT.Visible = false;
            }
            else if ((ImageQueryRSLT15OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT15OPT.Visible = true;
                RAISERSLT15OPT.ShowPopupWindow();
                QueryRaiseRSLT15OPT.Visible = false;
                TextBoxRaiseRSLT15OPT.Visible = false;
                PanelRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT2.Visible = true;
                PanelRaiseRSLT15OPT3.Visible = true;
                LabelRespondRSLT15OPT.Visible = false;
            }
            else
            {
                RAISERSLT15OPT.Visible = true;
                RAISERSLT15OPT.ShowPopupWindow();
                QueryRaiseRSLT15OPT.Visible = false;
                TextBoxRaiseRSLT15OPT.Visible = false;
                PanelRaiseRSLT15OPT.Visible = true;
                PanelRaiseRSLT15OPT2.Visible = true;
                PanelRaiseRSLT15OPT3.Visible = true;
                LabelRespondRSLT15OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT15OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT15OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT15OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT15OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT15OPT = '" + TextBoxRSLT15OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT15OPTMSG.ShowPopupWindow();
        RAISERSLT15OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT16OPT
    private void SetImageQueryRSLT16OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT16OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT16OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT16OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT16OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT16OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT16OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT16OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT16OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT2.Visible = false;
                PanelRaiseRSLT16OPT3.Visible = false;
                PanelHideRSLT16OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT16OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT2.Visible = true;
                PanelRaiseRSLT16OPT3.Visible = true;
                PanelHideRSLT16OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT16OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT16OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT2.Visible = true;
                PanelRaiseRSLT16OPT3.Visible = false;
                PanelHideRSLT16OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT16OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT16OPT = '" + TextBoxRSLT16OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT16OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT16OPT.Visible = true;
                RAISERSLT16OPT.ShowPopupWindow();
                QueryRaiseRSLT16OPT.Visible = false;
                TextBoxRaiseRSLT16OPT.Visible = false;
                PanelRaiseRSLT16OPT.Visible = false;
                PanelRaiseRSLT16OPT2.Visible = false;
                PanelRaiseRSLT16OPT3.Visible = false;

                LabelRespondRSLT16OPT.Visible = false;
            }

            else if ((ImageQueryRSLT16OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT16OPT.Visible = true;
                RAISERSLT16OPT.ShowPopupWindow();
                QueryRaiseRSLT16OPT.Visible = true;
                TextBoxRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT2.Visible = false;
                PanelRaiseRSLT16OPT3.Visible = false;
                LabelRespondRSLT16OPT.Visible = true;
            }

            else if ((ImageQueryRSLT16OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT16OPT.Visible = true;
                RAISERSLT16OPT.ShowPopupWindow();
                QueryRaiseRSLT16OPT.Visible = false;
                TextBoxRaiseRSLT16OPT.Visible = false;
                PanelRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT2.Visible = true;
                PanelRaiseRSLT16OPT3.Visible = false;
                LabelRespondRSLT16OPT.Visible = false;
            }
            else if ((ImageQueryRSLT16OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT16OPT.Visible = true;
                RAISERSLT16OPT.ShowPopupWindow();
                QueryRaiseRSLT16OPT.Visible = false;
                TextBoxRaiseRSLT16OPT.Visible = false;
                PanelRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT2.Visible = true;
                PanelRaiseRSLT16OPT3.Visible = true;
                LabelRespondRSLT16OPT.Visible = false;
            }
            else
            {
                RAISERSLT16OPT.Visible = true;
                RAISERSLT16OPT.ShowPopupWindow();
                QueryRaiseRSLT16OPT.Visible = false;
                TextBoxRaiseRSLT16OPT.Visible = false;
                PanelRaiseRSLT16OPT.Visible = true;
                PanelRaiseRSLT16OPT2.Visible = true;
                PanelRaiseRSLT16OPT3.Visible = true;
                LabelRespondRSLT16OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT16OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT16OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT16OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT16OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT16OPT = '" + TextBoxRSLT16OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT16OPTMSG.ShowPopupWindow();
        RAISERSLT16OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT17OPT
    private void SetImageQueryRSLT17OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT17OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT17OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT17OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT17OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT17OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT17OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT17OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT17OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT2.Visible = false;
                PanelRaiseRSLT17OPT3.Visible = false;
                PanelHideRSLT17OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT17OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT2.Visible = true;
                PanelRaiseRSLT17OPT3.Visible = true;
                PanelHideRSLT17OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT17OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT17OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT2.Visible = true;
                PanelRaiseRSLT17OPT3.Visible = false;
                PanelHideRSLT17OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT17OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT17OPT = '" + TextBoxRSLT17OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT17OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT17OPT.Visible = true;
                RAISERSLT17OPT.ShowPopupWindow();
                QueryRaiseRSLT17OPT.Visible = false;
                TextBoxRaiseRSLT17OPT.Visible = false;
                PanelRaiseRSLT17OPT.Visible = false;
                PanelRaiseRSLT17OPT2.Visible = false;
                PanelRaiseRSLT17OPT3.Visible = false;

                LabelRespondRSLT17OPT.Visible = false;
            }

            else if ((ImageQueryRSLT17OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT17OPT.Visible = true;
                RAISERSLT17OPT.ShowPopupWindow();
                QueryRaiseRSLT17OPT.Visible = true;
                TextBoxRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT2.Visible = false;
                PanelRaiseRSLT17OPT3.Visible = false;
                LabelRespondRSLT17OPT.Visible = true;
            }

            else if ((ImageQueryRSLT17OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT17OPT.Visible = true;
                RAISERSLT17OPT.ShowPopupWindow();
                QueryRaiseRSLT17OPT.Visible = false;
                TextBoxRaiseRSLT17OPT.Visible = false;
                PanelRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT2.Visible = true;
                PanelRaiseRSLT17OPT3.Visible = false;
                LabelRespondRSLT17OPT.Visible = false;
            }
            else if ((ImageQueryRSLT17OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT17OPT.Visible = true;
                RAISERSLT17OPT.ShowPopupWindow();
                QueryRaiseRSLT17OPT.Visible = false;
                TextBoxRaiseRSLT17OPT.Visible = false;
                PanelRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT2.Visible = true;
                PanelRaiseRSLT17OPT3.Visible = true;
                LabelRespondRSLT17OPT.Visible = false;
            }
            else
            {
                RAISERSLT17OPT.Visible = true;
                RAISERSLT17OPT.ShowPopupWindow();
                QueryRaiseRSLT17OPT.Visible = false;
                TextBoxRaiseRSLT17OPT.Visible = false;
                PanelRaiseRSLT17OPT.Visible = true;
                PanelRaiseRSLT17OPT2.Visible = true;
                PanelRaiseRSLT17OPT3.Visible = true;
                LabelRespondRSLT17OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT17OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT17OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT17OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT17OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT17OPT = '" + TextBoxRSLT17OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT17OPTMSG.ShowPopupWindow();
        RAISERSLT17OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT18OPT
    private void SetImageQueryRSLT18OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT18OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT18OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT18OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT18OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT18OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT18OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT18OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT18OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT2.Visible = false;
                PanelRaiseRSLT18OPT3.Visible = false;
                PanelHideRSLT18OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT18OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT2.Visible = true;
                PanelRaiseRSLT18OPT3.Visible = true;
                PanelHideRSLT18OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT18OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT18OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT2.Visible = true;
                PanelRaiseRSLT18OPT3.Visible = false;
                PanelHideRSLT18OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT18OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT18OPT = '" + TextBoxRSLT18OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT18OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT18OPT.Visible = true;
                RAISERSLT18OPT.ShowPopupWindow();
                QueryRaiseRSLT18OPT.Visible = false;
                TextBoxRaiseRSLT18OPT.Visible = false;
                PanelRaiseRSLT18OPT.Visible = false;
                PanelRaiseRSLT18OPT2.Visible = false;
                PanelRaiseRSLT18OPT3.Visible = false;

                LabelRespondRSLT18OPT.Visible = false;
            }

            else if ((ImageQueryRSLT18OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT18OPT.Visible = true;
                RAISERSLT18OPT.ShowPopupWindow();
                QueryRaiseRSLT18OPT.Visible = true;
                TextBoxRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT2.Visible = false;
                PanelRaiseRSLT18OPT3.Visible = false;
                LabelRespondRSLT18OPT.Visible = true;
            }

            else if ((ImageQueryRSLT18OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT18OPT.Visible = true;
                RAISERSLT18OPT.ShowPopupWindow();
                QueryRaiseRSLT18OPT.Visible = false;
                TextBoxRaiseRSLT18OPT.Visible = false;
                PanelRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT2.Visible = true;
                PanelRaiseRSLT18OPT3.Visible = false;
                LabelRespondRSLT18OPT.Visible = false;
            }
            else if ((ImageQueryRSLT18OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT18OPT.Visible = true;
                RAISERSLT18OPT.ShowPopupWindow();
                QueryRaiseRSLT18OPT.Visible = false;
                TextBoxRaiseRSLT18OPT.Visible = false;
                PanelRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT2.Visible = true;
                PanelRaiseRSLT18OPT3.Visible = true;
                LabelRespondRSLT18OPT.Visible = false;
            }
            else
            {
                RAISERSLT18OPT.Visible = true;
                RAISERSLT18OPT.ShowPopupWindow();
                QueryRaiseRSLT18OPT.Visible = false;
                TextBoxRaiseRSLT18OPT.Visible = false;
                PanelRaiseRSLT18OPT.Visible = true;
                PanelRaiseRSLT18OPT2.Visible = true;
                PanelRaiseRSLT18OPT3.Visible = true;
                LabelRespondRSLT18OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT18OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT18OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT18OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT18OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT18OPT = '" + TextBoxRSLT18OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT18OPTMSG.ShowPopupWindow();
        RAISERSLT18OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT19OPT
    private void SetImageQueryRSLT19OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT19OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT19OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT19OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT19OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT19OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT19OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT19OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT19OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT2.Visible = false;
                PanelRaiseRSLT19OPT3.Visible = false;
                PanelHideRSLT19OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT19OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT2.Visible = true;
                PanelRaiseRSLT19OPT3.Visible = true;
                PanelHideRSLT19OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT19OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT19OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT2.Visible = true;
                PanelRaiseRSLT19OPT3.Visible = false;
                PanelHideRSLT19OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT19OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT19OPT = '" + TextBoxRSLT19OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT19OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT19OPT.Visible = true;
                RAISERSLT19OPT.ShowPopupWindow();
                QueryRaiseRSLT19OPT.Visible = false;
                TextBoxRaiseRSLT19OPT.Visible = false;
                PanelRaiseRSLT19OPT.Visible = false;
                PanelRaiseRSLT19OPT2.Visible = false;
                PanelRaiseRSLT19OPT3.Visible = false;

                LabelRespondRSLT19OPT.Visible = false;
            }

            else if ((ImageQueryRSLT19OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT19OPT.Visible = true;
                RAISERSLT19OPT.ShowPopupWindow();
                QueryRaiseRSLT19OPT.Visible = true;
                TextBoxRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT2.Visible = false;
                PanelRaiseRSLT19OPT3.Visible = false;
                LabelRespondRSLT19OPT.Visible = true;
            }

            else if ((ImageQueryRSLT19OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT19OPT.Visible = true;
                RAISERSLT19OPT.ShowPopupWindow();
                QueryRaiseRSLT19OPT.Visible = false;
                TextBoxRaiseRSLT19OPT.Visible = false;
                PanelRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT2.Visible = true;
                PanelRaiseRSLT19OPT3.Visible = false;
                LabelRespondRSLT19OPT.Visible = false;
            }
            else if ((ImageQueryRSLT19OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT19OPT.Visible = true;
                RAISERSLT19OPT.ShowPopupWindow();
                QueryRaiseRSLT19OPT.Visible = false;
                TextBoxRaiseRSLT19OPT.Visible = false;
                PanelRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT2.Visible = true;
                PanelRaiseRSLT19OPT3.Visible = true;
                LabelRespondRSLT19OPT.Visible = false;
            }
            else
            {
                RAISERSLT19OPT.Visible = true;
                RAISERSLT19OPT.ShowPopupWindow();
                QueryRaiseRSLT19OPT.Visible = false;
                TextBoxRaiseRSLT19OPT.Visible = false;
                PanelRaiseRSLT19OPT.Visible = true;
                PanelRaiseRSLT19OPT2.Visible = true;
                PanelRaiseRSLT19OPT3.Visible = true;
                LabelRespondRSLT19OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT19OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT19OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT19OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT19OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT19OPT = '" + TextBoxRSLT19OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT19OPTMSG.ShowPopupWindow();
        RAISERSLT19OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT20OPT
    private void SetImageQueryRSLT20OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT20OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT20OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT20OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT20OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT20OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT20OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT20OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT20OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT2.Visible = false;
                PanelRaiseRSLT20OPT3.Visible = false;
                PanelHideRSLT20OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT20OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT2.Visible = true;
                PanelRaiseRSLT20OPT3.Visible = true;
                PanelHideRSLT20OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT20OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT20OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT2.Visible = true;
                PanelRaiseRSLT20OPT3.Visible = false;
                PanelHideRSLT20OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT20OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT20OPT = '" + TextBoxRSLT20OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT20OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT20OPT.Visible = true;
                RAISERSLT20OPT.ShowPopupWindow();
                QueryRaiseRSLT20OPT.Visible = false;
                TextBoxRaiseRSLT20OPT.Visible = false;
                PanelRaiseRSLT20OPT.Visible = false;
                PanelRaiseRSLT20OPT2.Visible = false;
                PanelRaiseRSLT20OPT3.Visible = false;

                LabelRespondRSLT20OPT.Visible = false;
            }

            else if ((ImageQueryRSLT20OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT20OPT.Visible = true;
                RAISERSLT20OPT.ShowPopupWindow();
                QueryRaiseRSLT20OPT.Visible = true;
                TextBoxRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT2.Visible = false;
                PanelRaiseRSLT20OPT3.Visible = false;
                LabelRespondRSLT20OPT.Visible = true;
            }

            else if ((ImageQueryRSLT20OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT20OPT.Visible = true;
                RAISERSLT20OPT.ShowPopupWindow();
                QueryRaiseRSLT20OPT.Visible = false;
                TextBoxRaiseRSLT20OPT.Visible = false;
                PanelRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT2.Visible = true;
                PanelRaiseRSLT20OPT3.Visible = false;
                LabelRespondRSLT20OPT.Visible = false;
            }
            else if ((ImageQueryRSLT20OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT20OPT.Visible = true;
                RAISERSLT20OPT.ShowPopupWindow();
                QueryRaiseRSLT20OPT.Visible = false;
                TextBoxRaiseRSLT20OPT.Visible = false;
                PanelRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT2.Visible = true;
                PanelRaiseRSLT20OPT3.Visible = true;
                LabelRespondRSLT20OPT.Visible = false;
            }
            else
            {
                RAISERSLT20OPT.Visible = true;
                RAISERSLT20OPT.ShowPopupWindow();
                QueryRaiseRSLT20OPT.Visible = false;
                TextBoxRaiseRSLT20OPT.Visible = false;
                PanelRaiseRSLT20OPT.Visible = true;
                PanelRaiseRSLT20OPT2.Visible = true;
                PanelRaiseRSLT20OPT3.Visible = true;
                LabelRespondRSLT20OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT20OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT20OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT20OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT20OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT20OPT = '" + TextBoxRSLT20OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT20OPTMSG.ShowPopupWindow();
        RAISERSLT20OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT21OPT
    private void SetImageQueryRSLT21OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT21OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT21OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT21OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT21OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT21OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT21OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT21OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT21OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT21OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT2.Visible = false;
                PanelRaiseRSLT21OPT3.Visible = false;
                PanelHideRSLT21OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT21OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT21OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT21OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT2.Visible = true;
                PanelRaiseRSLT21OPT3.Visible = true;
                PanelHideRSLT21OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT21OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT21OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT2.Visible = true;
                PanelRaiseRSLT21OPT3.Visible = false;
                PanelHideRSLT21OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT21OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT21OPT = '" + TextBoxRSLT21OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT21OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT21OPT.Visible = true;
                RAISERSLT21OPT.ShowPopupWindow();
                QueryRaiseRSLT21OPT.Visible = false;
                TextBoxRaiseRSLT21OPT.Visible = false;
                PanelRaiseRSLT21OPT.Visible = false;
                PanelRaiseRSLT21OPT2.Visible = false;
                PanelRaiseRSLT21OPT3.Visible = false;

                LabelRespondRSLT21OPT.Visible = false;
            }

            else if ((ImageQueryRSLT21OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT21OPT.Visible = true;
                RAISERSLT21OPT.ShowPopupWindow();
                QueryRaiseRSLT21OPT.Visible = true;
                TextBoxRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT2.Visible = false;
                PanelRaiseRSLT21OPT3.Visible = false;
                LabelRespondRSLT21OPT.Visible = true;
            }

            else if ((ImageQueryRSLT21OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT21OPT.Visible = true;
                RAISERSLT21OPT.ShowPopupWindow();
                QueryRaiseRSLT21OPT.Visible = false;
                TextBoxRaiseRSLT21OPT.Visible = false;
                PanelRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT2.Visible = true;
                PanelRaiseRSLT21OPT3.Visible = false;
                LabelRespondRSLT21OPT.Visible = false;
            }
            else if ((ImageQueryRSLT21OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT21OPT.Visible = true;
                RAISERSLT21OPT.ShowPopupWindow();
                QueryRaiseRSLT21OPT.Visible = false;
                TextBoxRaiseRSLT21OPT.Visible = false;
                PanelRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT2.Visible = true;
                PanelRaiseRSLT21OPT3.Visible = true;
                LabelRespondRSLT21OPT.Visible = false;
            }
            else
            {
                RAISERSLT21OPT.Visible = true;
                RAISERSLT21OPT.ShowPopupWindow();
                QueryRaiseRSLT21OPT.Visible = false;
                TextBoxRaiseRSLT21OPT.Visible = false;
                PanelRaiseRSLT21OPT.Visible = true;
                PanelRaiseRSLT21OPT2.Visible = true;
                PanelRaiseRSLT21OPT3.Visible = true;
                LabelRespondRSLT21OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT21OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT21OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT21OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT21OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT21OPT = '" + TextBoxRSLT21OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT21OPTMSG.ShowPopupWindow();
        RAISERSLT21OPT.Visible = false;


    }
    #endregion
    #region QueryRSLT22OPT
    private void SetImageQueryRSLT22OPT()
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT22OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                ImageQueryRSLT22OPT.ImageUrl = "~/Data-Entry/Images/red.png";



            }
            else if (dr["Status"].ToString() == "Close")
            {
                ImageQueryRSLT22OPT.ImageUrl = "~/Data-Entry/Images/close.png";

            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                ImageQueryRSLT22OPT.ImageUrl = "~/Data-Entry/Images/Yellow.png";

            }
            else
            {
                ImageQueryRSLT22OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

            }
        }
        else
        {
            ImageQueryRSLT22OPT.ImageUrl = "~/Data-Entry/Images/Blue.jpg";

        }
        dr.Close();

        con.Close();
    }
    private void BindQueryDataRSLT22OPT()
    {

        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 1 * from tblQuery where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT22OPT.Text + "' order by ID desc", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            if (dr["Status"].ToString() == "Open")
            {

                LabelRaiseRSLT22OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                PanelRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT2.Visible = false;
                PanelRaiseRSLT22OPT3.Visible = false;
                PanelHideRSLT22OPT.Visible = true;

            }
            else if (dr["Status"].ToString() == "Close")
            {
                LabelRaiseRSLT22OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT22OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                LabelRaiseRSLT22OPT3.Text = "<b>" + "Query closed by: " + "</b>" + dr["Username3"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Closed Remarks: " + "</b>" + dr["QueryResponse3"].ToString();
                PanelRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT2.Visible = true;
                PanelRaiseRSLT22OPT3.Visible = true;
                PanelHideRSLT22OPT.Visible = false;
            }
            else if (dr["Status"].ToString() == "Query Responded")
            {
                LabelRaiseRSLT22OPT.Text = "<b>" + "Query Raised by: " + "</b>" + dr["Username"].ToString() + "" + "<br />" + "<b>" + "<b>" + " Query Description: " + "</b>" + dr["Query"].ToString();
                LabelRaiseRSLT22OPT2.Text = "<b>" + "Query Resolved by: " + "</b>" + dr["Username2"].ToString() + "" + "<br />" + "<b>" + "<br />" + "<b>" + " Reply: " + "</b>" + dr["QueryResponse"].ToString() + "" + "<br />" + "<b>";
                PanelRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT2.Visible = true;
                PanelRaiseRSLT22OPT3.Visible = false;
                PanelHideRSLT22OPT.Visible = false;
            }
            else
            {

            }

        }
    }
    protected void ImageQueryRSLT22OPT_Click(object sender, ImageClickEventArgs e)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from [Visit1].[LabUrinalysis] where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT22OPT = '" + TextBoxRSLT22OPT.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            if ((ImageQueryRSLT22OPT.ImageUrl == "~/Data-Entry/Images/Blue.jpg") && (dr["LockStatus"].ToString() != "Locked"))
            {

                RAISERSLT22OPT.Visible = true;
                RAISERSLT22OPT.ShowPopupWindow();
                QueryRaiseRSLT22OPT.Visible = false;
                TextBoxRaiseRSLT22OPT.Visible = false;
                PanelRaiseRSLT22OPT.Visible = false;
                PanelRaiseRSLT22OPT2.Visible = false;
                PanelRaiseRSLT22OPT3.Visible = false;

                LabelRespondRSLT22OPT.Visible = false;
            }

            else if ((ImageQueryRSLT22OPT.ImageUrl == "~/Data-Entry/Images/red.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT22OPT.Visible = true;
                RAISERSLT22OPT.ShowPopupWindow();
                QueryRaiseRSLT22OPT.Visible = true;
                TextBoxRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT2.Visible = false;
                PanelRaiseRSLT22OPT3.Visible = false;
                LabelRespondRSLT22OPT.Visible = true;
            }

            else if ((ImageQueryRSLT22OPT.ImageUrl == "~/Data-Entry/Images/Yellow.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT22OPT.Visible = true;
                RAISERSLT22OPT.ShowPopupWindow();
                QueryRaiseRSLT22OPT.Visible = false;
                TextBoxRaiseRSLT22OPT.Visible = false;
                PanelRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT2.Visible = true;
                PanelRaiseRSLT22OPT3.Visible = false;
                LabelRespondRSLT22OPT.Visible = false;
            }
            else if ((ImageQueryRSLT22OPT.ImageUrl == "~/Data-Entry/Images/close.png") && (dr["LockStatus"].ToString() != "Locked"))
            {
                RAISERSLT22OPT.Visible = true;
                RAISERSLT22OPT.ShowPopupWindow();
                QueryRaiseRSLT22OPT.Visible = false;
                TextBoxRaiseRSLT22OPT.Visible = false;
                PanelRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT2.Visible = true;
                PanelRaiseRSLT22OPT3.Visible = true;
                LabelRespondRSLT22OPT.Visible = false;
            }
            else
            {
                RAISERSLT22OPT.Visible = true;
                RAISERSLT22OPT.ShowPopupWindow();
                QueryRaiseRSLT22OPT.Visible = false;
                TextBoxRaiseRSLT22OPT.Visible = false;
                PanelRaiseRSLT22OPT.Visible = true;
                PanelRaiseRSLT22OPT2.Visible = true;
                PanelRaiseRSLT22OPT3.Visible = true;
                LabelRespondRSLT22OPT.Visible = false;

            }
        }

    }
    protected void QueryRaiseRSLT22OPT_Click(object sender, EventArgs e)
    {
        con.Close();
        con.Open();
        con1.Open();

        cmd = new SqlCommand("Update tblQuery set QueryResponse = '" + TextBoxRaiseRSLT22OPT.Text + "', Status ='Query Responded', Username2 ='" + LabelUserName.Text + "', Date2 ='" + DateTime.Today.ToString("dd-MMM-yyyy") + "' where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT22OPT.Text + "' and QueryResponse IN (Select top 1 QueryResponse from tblQuery  where Site='" + lblCenterNumber.Text + "' and ScreenID = '" + lblScreeningNo.Text + "' and SubInitial = '" + lblSubjectInitial.Text + "' and Visit = '" + lblVisit.Text + "' and Page = '" + lblPage.Text + "'and Field = '" + lblRSLT22OPT.Text + "' order by ID desc)", con);

        cmd1 = new SqlCommand("Update [Visit1].[LabUrinalysis] set  QueryStatus = 'Query Responded'  where SITENUM='" + lblCenterNumber.Text + "' and SUBNUM = '" + lblScreeningNo.Text + "' and SUBINI = '" + lblSubjectInitial.Text + "'and RSLT22OPT = '" + TextBoxRSLT22OPT.Text + "'", con1);

        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        con.Close();
        con1.Close();

        RAISERSLT22OPTMSG.ShowPopupWindow();
        RAISERSLT22OPT.Visible = false;


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
            hideURI.Visible = true;
        }
        else
        {
            hideURI.Visible = false;
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

        if (RadioButtonListNAB14OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN14OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN14OPT.Visible = false;
        }

        if (RadioButtonListNAB15OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN15OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN15OPT.Visible = false;
        }

        if (RadioButtonListNAB16OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN16OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN16OPT.Visible = false;
        }

        if (RadioButtonListNAB17OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN17OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN17OPT.Visible = false;
        }

        if (RadioButtonListNAB18OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN18OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN18OPT.Visible = false;
        }

        if (RadioButtonListNAB19OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN19OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN19OPT.Visible = false;
        }

        if (RadioButtonListNAB20OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN20OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN20OPT.Visible = false;
        }

        if (RadioButtonListNAB21OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN21OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN21OPT.Visible = false;
        }

        if (RadioButtonListNAB22OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN22OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN22OPT.Visible = false;
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

    protected void RadioButtonListNAB14OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB14OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN14OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN14OPT.Visible = false;
            RadioButtonListABN14OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB15OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB15OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN15OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN15OPT.Visible = false;
            RadioButtonListABN15OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB16OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB16OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN16OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN16OPT.Visible = false;
            RadioButtonListABN16OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB17OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB17OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN17OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN17OPT.Visible = false;
            RadioButtonListABN17OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB18OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB18OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN18OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN18OPT.Visible = false;
            RadioButtonListABN18OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB19OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB19OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN19OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN19OPT.Visible = false;
            RadioButtonListABN19OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB20OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB20OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN20OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN20OPT.Visible = false;
            RadioButtonListABN20OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB21OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB21OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN21OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN21OPT.Visible = false;
            RadioButtonListABN21OPT.ClearSelection();
        }
    }

    protected void RadioButtonListNAB22OPT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListNAB22OPT.SelectedValue == "Abnormal")
        {
            RadioButtonListABN22OPT.Visible = true;
        }
        else
        {
            RadioButtonListABN22OPT.Visible = false;
            RadioButtonListABN22OPT.ClearSelection();
        }
    }

    protected void RadioButtonListLABASS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonListLABASS.SelectedValue == "Yes")
        {
            hideURI.Visible = true;
        }
        else
        {
            hideURI.Visible = false;

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

            TextBoxRSLT14OPT.Text = string.Empty;
            TextBoxUN14OPT.Text = string.Empty;
            RadioButtonListNAB14OPT.ClearSelection();
            RadioButtonListABN14OPT.ClearSelection();

            TextBoxRSLT15OPT.Text = string.Empty;
            TextBoxUN15OPT.Text = string.Empty;
            RadioButtonListNAB15OPT.ClearSelection();
            RadioButtonListABN15OPT.ClearSelection();

            TextBoxRSLT16OPT.Text = string.Empty;
            TextBoxUN16OPT.Text = string.Empty;
            RadioButtonListNAB16OPT.ClearSelection();
            RadioButtonListABN16OPT.ClearSelection();

            TextBoxRSLT17OPT.Text = string.Empty;
            TextBoxUN17OPT.Text = string.Empty;
            RadioButtonListNAB17OPT.ClearSelection();
            RadioButtonListABN17OPT.ClearSelection();

            TextBoxRSLT18OPT.Text = string.Empty;
            TextBoxUN18OPT.Text = string.Empty;
            RadioButtonListNAB18OPT.ClearSelection();
            RadioButtonListABN18OPT.ClearSelection();

            TextBoxRSLT19OPT.Text = string.Empty;
            TextBoxUN19OPT.Text = string.Empty;
            RadioButtonListNAB19OPT.ClearSelection();
            RadioButtonListABN19OPT.ClearSelection();

            TextBoxRSLT20OPT.Text = string.Empty;
            TextBoxUN20OPT.Text = string.Empty;
            RadioButtonListNAB20OPT.ClearSelection();
            RadioButtonListABN20OPT.ClearSelection();

            TextBoxRSLT21OPT.Text = string.Empty;
            TextBoxUN21OPT.Text = string.Empty;
            RadioButtonListNAB21OPT.ClearSelection();
            RadioButtonListABN21OPT.ClearSelection();

            TextBoxRSLT22OPT.Text = string.Empty;
            TextBoxUN22OPT.Text = string.Empty;
            RadioButtonListNAB22OPT.ClearSelection();
            RadioButtonListABN22OPT.ClearSelection();
        }
    }
}