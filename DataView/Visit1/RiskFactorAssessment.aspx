<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RiskFactorAssessment.aspx.cs" Inherits="DataView_Visit1_RiskFactorAssessment" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | DataView | Visit 1 | Risk Factor Assessment</title>
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../../../css/main.css" />
    <link href="../../css/ButtonOption.css" rel="stylesheet" />
    <style type="text/css">
        .GridviewDivAddNote {
            font-size: 100%;
            font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }

        .headerstyle {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }

        GridviewDivADDAddAttachment {
            font-size: 100%;
            font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }

        .headerstyle {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
    <style type="text/css">
        .rbl input[type="radio"] {
            margin-left: 10px;
            margin-right: 1px;
        }

        .messagealert {
            border: 0 !important;
            max-width: 450px;
            color: #fff;
            display: inline-block;
            margin: 0px auto;
            position: fixed;
            transition: all 0.5s ease-in-out;
            z-index: 1031;
            top: 20px;
            left: 0px;
            right: 0px;
            animation-iteration-count: 1;
        }
    </style>
    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_container {
            background-color: #DEF1F4;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_header {
            background-color: #ffffff;
            margin-bottom: 4px;
        }

        .cal_Theme1 .ajax__calendar_title,
        .cal_Theme1 .ajax__calendar_next,
        .cal_Theme1 .ajax__calendar_prev {
            color: #004080;
            padding-top: 3px;
        }

        .cal_Theme1 .ajax__calendar_body {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
            width: auto;
        }

        .cal_Theme1 .ajax__calendar_dayname {
            text-align: center;
            font-weight: bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
        }

        .cal_Theme1 .ajax__calendar_day {
            color: #004080;
            text-align: center;
        }




        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year,
        .cal_Theme1 .ajax__calendar_active {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
        }

        .cal_Theme1 .ajax__calendar_today {
            font-weight: bold;
        }

        .cal_Theme1 .ajax__calendar_other,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title {
            color: #bbbbbb;
        }
    </style>
    <style type="text/css">
        .auto-style2 {
            height: 55px;
            text-align: center;
            font-weight: normal;
        }

        .padding-Text {
            padding-left: 8px;
            padding-right: 8px;
            text-align: left;
        }

        .auto-style3 {
            height: 40px;
            text-align: center;
            background-color: #CCCCCC;
        }

        .INST-Text {
            background-color: antiquewhite;
            color: darkblue;
        }

        .INST-Text2 {
            padding-left: 8px;
            padding-right: 8px;
            text-align: left;
        }

        .auto-style8 {
            height: 35px;
            text-align: left;
            font-weight: normal;
            padding-left: 10px;
            padding-right: 10px;
            background-color: aliceblue;
        }

        .section-header {
            height: 35px;
            background-color: beige;
            color: red;
            text-align: left;
            font-weight: bold;
            vertical-align: middle;
        }

            .section-header td {
                padding-left: 30px;
            }
    </style>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode == 46) {
                var inputValue = $("#inputfield").val()
                if (inputValue.indexOf('.') < 1) {
                    return true;
                }
                return false;
            }
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        .ErrorControl {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">



    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>


    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-edit"></i>
                        <asp:Label runat="server" ID="lblPage">Risk Factor Assessment</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>DataView</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Visit 1</asp:LinkButton></li>

                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <asp:Panel ID="MainPanel" runat="server">
                            <div class="row">
                                <div class="text-center">

                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="50%" />
                                            <col width="40%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr>
                                            <td align="center" colspan="2" class="auto-style2">
                                                <div class="header1">
                                                    <asp:Table ID="Table1" runat="server" Width="100%" BorderStyle="Solid" GridLines="Both">
                                                        <asp:TableRow Height="30px">
                                                            <asp:TableCell Width="20%">Protocol Number</asp:TableCell><asp:TableCell Width="10%">
                                                                <asp:Label ID="lblProtocolNumber" runat="server" Text="GPL ZANU-401"></asp:Label>
                                                            </asp:TableCell>

                                                            <asp:TableCell Width="20%">Site Number</asp:TableCell><asp:TableCell Width="10%">
                                                                <asp:Label ID="lblCenterNumber" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow Height="30px">
                                                            <asp:TableCell>Subject Number</asp:TableCell><asp:TableCell>
                                                                <asp:Label ID="lblScreeningNo" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell>Subject Initial</asp:TableCell><asp:TableCell>
                                                                <asp:Label ID="lblSubjectInitial" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table>
                                                </div>

                                            </td>
                                            <td align="center" class="auto-style2">
                                                <asp:ImageButton ID="ImgAddNote" Height="25px" Width="25px" runat="server" OnClick="ImgAddNote_Click" ToolTip="Add Note" />
                                                &nbsp;&nbsp;&nbsp;
         <asp:ImageButton ID="ImgAddAttachment" Height="25px" Width="25px" runat="server" OnClick="ImgAddAttachment_Click" ToolTip="Add Attachment" />
                                                &nbsp;&nbsp;&nbsp;
         <asp:ImageButton ID="AttachmentPageHistory" Height="25px" Width="25px" runat="server" OnClick="AttachmentPageHistory_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>

                                            <col width="50%" />
                                            <col width="40%" />
                                            <col width="10%" />

                                        </colgroup>

                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td><b>Risk Factor</b></td>
                                            <td class="text-center" colspan="2"><b>Duration (Months)</b></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA1OPT">Hypertension</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Hypertension Duration (Months)." ControlToValidate="TextBoxDURA1OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA1OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA1OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA2OPT">Type 2 Diabetes mellitus Duration</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Type 2 Diabetes mellitus Duration Duration (Months)." ControlToValidate="TextBoxDURA2OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA2OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA2OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA2OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA3OPT">Type 1 Diabetes Duration</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Type 1 Diabetes Duration Duration (Months)." ControlToValidate="TextBoxDURA3OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA3OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA3OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA3OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA4OPT">H/o CAD Duration</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention H/o CAD Duration Duration (Months)." ControlToValidate="TextBoxDURA4OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA4OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA4OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA4OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA5OPT">H/o Stroke/ TIA</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention H/o Stroke/ TIA Duration (Months)." ControlToValidate="TextBoxDURA5OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA5OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA5OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA5OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA6OPT">CKD Duration</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention CKD Duration Duration (Months)." ControlToValidate="TextBoxDURA6OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA6OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA6OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA6OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA7OPT">Atrial Arrhythmia</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Atrial Arrhythmia Duration (Months)." ControlToValidate="TextBoxDURA7OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA7OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA7OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA7OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA8OPT">COPD</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention COPD Duration (Months)." ControlToValidate="TextBoxDURA8OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA8OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA8OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA8OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA9OPT">Obesity / OSA</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Obesity / OSA Duration (Months)." ControlToValidate="TextBoxDURA9OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA9OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA9OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA9OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA10OPT">Cardiomyopathy</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Cardiomyopathy Duration (Months)." ControlToValidate="TextBoxDURA10OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA10OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA10OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA10OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA11OPT">Hypothyroidism</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Hypothyroidism Duration (Months)." ControlToValidate="TextBoxDURA11OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA11OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA11OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA11OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA12OPT">Hyperthyroidism</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Hyperthyroidism Duration (Months)." ControlToValidate="TextBoxDURA12OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA12OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA12OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA12OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA13OPT">Alcohol use (current or past)</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Alcohol use (current or past) Duration (Months)." ControlToValidate="TextBoxDURA13OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA13OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA13OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA13OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA14OPT">Tobacco use (current or past)</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Tobacco use (current or past) Duration (Months)." ControlToValidate="TextBoxDURA14OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA14OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA14OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA14OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA15OPT">Anaemia</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Anaemia Duration (Months)." ControlToValidate="TextBoxDURA15OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA15OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA15OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA15OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblDURA16OPT">Chemotherapy / Drugs / radiation</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Chemotherapy / Drugs / radiation Duration (Months)." ControlToValidate="TextBoxDURA16OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA16OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA16OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA16OPT_Click" /></td>

                                        </tr>

                                        <tr class="section-header">
                                            <td colspan="6">If any other Risk Factor are present, please provide details below:
                                            </td>
                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
    <td><b>Other Risk Factor</b></td>
    <td class="text-center" colspan="2"><b>Duration (Months)</b></td>
</tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxRFA17OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Other Risk Factors" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA17OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA17OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA17OPT_Click" /></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxRFA18OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Other Risk Factors" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA18OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA18OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA18OPT_Click" /></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxRFA19OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Other Risk Factors" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA19OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA19OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA19OPT_Click" /></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxRFA20OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Other Risk Factors" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxDURA20OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Duration (Months)" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryDURA20OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryDURA20OPT_Click" /></td>
                                        </tr>
                                    </table>

                                    <div class="text-center">
                                        <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="text-center">
                                        <asp:Label ID="LabelWarningDate" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="text-center">
                                        <asp:Label ID="LabelWarningAV" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                   
                                </div>

                            </div>
                        </asp:Panel>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label runat="server" ID="LabelUserName" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="LabelDateTime" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblRFA17OPT" Text="Other Risk Factor No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRFA18OPT" Text="Other Risk Factor No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRFA19OPT" Text="Other Risk Factor No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRFA20OPT" Text="Other Risk Factor No 4" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblDURA17OPT" Text="Other Risk Factor Duration (Months) No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblDURA18OPT" Text="Other Risk Factor Duration (Months) No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblDURA19OPT" Text="Other Risk Factor Duration (Months) No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblDURA20OPT" Text="Other Risk Factor Duration (Months) No 4" Visible="false"></asp:Label>

    <!-- Note And Attachment Date of Consent :-->
    <div id="ct100_PopupWindow">
        <ASPP:PopupPanel HeaderText="ADD Notes:" ID="AddNote" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowAddNote" runat="server">
                    <div align="left" style="width: 700px">
                        <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                            <colgroup>
                                <col width="30%" />
                                <col width="70%" />

                            </colgroup>
                            <tr>
                                <td align="center" class="auto-style2">Field Name:
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddNoteFiledTextBox" runat="server" ValidationGroup="AddNote" ErrorMessage="Please enter field name" ControlToValidate="AddNoteFiledTextBox" BackColor="Red"></asp:RequiredFieldValidator></td>
                                <td align="center" class="auto-style2">
                                    <asp:TextBox ID="AddNoteFiledTextBox" runat="server" class="form-control" ValidationGroup="AddNote" Height="35px" Width="450px"></asp:TextBox>

                                </td>

                            </tr>
                            <tr>
                                <td align="center" class="auto-style2">ADD Notes:
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddNoteTextBox" runat="server" ValidationGroup="AddNote" ErrorMessage="Please enter notes" ControlToValidate="AddNoteTextBox" BackColor="Red"></asp:RequiredFieldValidator>

                                </td>
                                <td align="center" class="auto-style2">
                                    <asp:TextBox ID="AddNoteTextBox" runat="server" class="form-control" ValidationGroup="AddNote" TextMode="MultiLine" Height="50px" Width="450px"></asp:TextBox>

                                </td>

                            </tr>
                            <tr>
                                <td align="center" colspan="2" class="auto-style2">

                                    <asp:Button ID="AddNotebuttonDOV" runat="server" Text="Add Notes" ValidationGroup="AddNote" OnClick="ADDAddNote_Click" CssClass="btn btn-sm btn-success" />

                                </td>

                            </tr>


                        </table>

                    </div>

                    <asp:Panel ID="AddAddNoteGridview" runat="server" BorderStyle="Solid">
                        <div class="GridviewDivAddNote">
                            <asp:GridView runat="server" ID="GridviewAddNote" AllowPaging="true" PageSize="10" RowStyle-Wrap="true" DataKeyNames="ID"
                                AutoGenerateColumns="false" Width="100%" OnPageIndexChanging="GridviewAddNote_PageIndexChanging" OnRowDeleting="GridviewAddNote_RowDeleting" CssClass="table table-responsive table-bordered table-hover">
                                <HeaderStyle CssClass="headerstyle" Wrap="true" />
                                <Columns>
                                    <asp:BoundField DataField="Username" HeaderText="Note Added By" />
                                    <asp:BoundField DataField="Date" HeaderText="Date of note added" />
                                    <asp:BoundField DataField="Field" HeaderText="Field Name" />
                                    <asp:BoundField DataField="Notes" HeaderText="Notes" />
                                    <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </asp:Panel>

                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="ADD Notes:" ID="NoteAddedDov" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowNoteAddedDoV" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="NoteAddedPanelDOV" runat="server" BorderStyle="Solid">
                            Note added successfully.
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow2">
        <ASPP:PopupPanel HeaderText="ADD Attachment:" ID="AddAttachment" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowAddAttachment" runat="server">
                    <div align="left" style="width: 700px">

                        <asp:Panel ID="PanelADDAddAttachment" runat="server">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>
                                    <col width="30%" />
                                    <col width="70%" />

                                </colgroup>
                                <tr>
                                    <td align="center" class="auto-style2">Field Name:
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddAttachmentFiledTextBox" runat="server" ValidationGroup="AddAttachment" ErrorMessage="Please enter field name" ControlToValidate="AddAttachmentFiledTextBox" BackColor="Red"></asp:RequiredFieldValidator></td>
                                    <td align="center" class="auto-style2">
                                        <asp:TextBox ID="AddAttachmentFiledTextBox" runat="server" class="form-control" ValidationGroup="AddAttachment" Height="35px" Width="450px"></asp:TextBox>

                                    </td>

                                </tr>
                                <tr>
                                    <td align="center" class="auto-style2">Title: 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxADDAddAttachment" ValidationGroup="AddAttachment" runat="server" BackColor="Red" ErrorMessage="Please Enter Title" ControlToValidate="TextBoxADDAddAttachment"></asp:RequiredFieldValidator>

                                    </td>
                                    <td align="center" class="auto-style2">
                                        <asp:TextBox ID="TextBoxADDAddAttachment" class="form-control" ValidationGroup="AddAttachment" runat="server" Height="35px" Width="450px"></asp:TextBox></td>


                                </tr>

                                <tr>
                                    <td align="center" class="auto-style2">Upload:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFileUploadADDAddAttachment" runat="server" ErrorMessage="Please Choose file" ValidationGroup="AddAttachment" BackColor="Red" ControlToValidate="FileUploadADDAddAttachment"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="center" class="auto-style2">
                                        <asp:FileUpload ID="FileUploadADDAddAttachment" runat="server" ValidationGroup="AddAttachment" Height="30px" Width="450px" CssClass="paddingFile" /></td>


                                </tr>
                                <tr>
                                    <td align="center" colspan="2" class="auto-style2">
                                        <div align="center">
                                            <asp:Button ID="ADDAddAttachment" runat="server" Text="Add" Width="200px" ValidationGroup="AddAttachment" OnClick="ADDAddAttachment_Click" CssClass="btn btn-sm btn-success" />

                                        </div>
                                    </td>

                                </tr>


                            </table>



                        </asp:Panel>

                    </div>

                    <asp:Panel ID="ADDAddAttachmentGridview" runat="server" BorderStyle="Solid">
                        <div class="GridviewDivADDAddAttachment">
                            <asp:GridView ID="GridViewADDAddAttachment" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" DataKeyNames="ID"
                                RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" Width="100%" AlternatingRowStyle-ForeColor="#000" OnRowDeleting="GridViewADDAddAttachment_RowDeleting"
                                AutoGenerateColumns="false" CssClass="table table-responsive table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="Username" HeaderText="File Added By" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                    <asp:BoundField DataField="Field" HeaderText="Field Name" />
                                    <asp:BoundField DataField="Title" HeaderText="Title" />
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDownloadAddAttachment" runat="server" Text="Download" OnClick="DownloadFileAddAttachment"
                                                CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </asp:Panel>

                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow3">
        <ASPP:PopupPanel HeaderText="ADD Attachment:" ID="AttachmentAddedDov" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowAttachmentAddedDoV" runat="server">
                    <div align="center" style="width: 300px; height: 200px">

                        <asp:Panel ID="AttachmentAddedPanelDOV" runat="server" BorderStyle="Solid">
                            Attachment added successfully.
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow2">
        <ASPP:PopupPanel HeaderText="Page History:" ID="PageHistory" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowAttachmentPageHistory" runat="server">
                    <div align="left" style="min-width: 900px; min-height: 200px">
                        <asp:Panel ID="ADDAttachmentPageHistoryGridview" runat="server" BorderStyle="Solid">
                            <div class="GridviewDivADDAttachmentPageHistory">
                                <asp:GridView ID="GridViewADDAttachmentPageHistory" runat="server" HeaderStyle-BackColor="Teal" HeaderStyle-ForeColor="White" DataKeyNames="ID"
                                    RowStyle-BackColor="#e5e5e5" AlternatingRowStyle-BackColor="White" Width="900px" AlternatingRowStyle-ForeColor="#000"
                                    AutoGenerateColumns="false" CssClass="table table-responsive table-bordered table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="QuestionText" HeaderText="Field Name" />
                                        <asp:BoundField DataField="OldValue" HeaderText="Old Data" />
                                        <asp:BoundField DataField="NewValue" HeaderText="New Data" />

                                        <asp:BoundField DataField="Reason" HeaderText="Reason for Change" />

                                        <asp:BoundField DataField="PageName" HeaderText="Page Name" />
                                        <asp:BoundField DataField="EUser" HeaderText="User" />
                                        <asp:BoundField DataField="EDate" HeaderText="Date Time" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>

                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Hypertension Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Hypertension Duration (Months)" ID="RAISEDURA1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hypertension Duration (Months)" ID="RAISEDURA1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Hypertension Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hypertension Duration (Months)" ID="RespondedDURA1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hypertension Duration (Months)" ID="CLOSEDURA1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA1OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Hypertension Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hypertension Duration (Months)" ID="CloseDURA1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hypertension Duration (Months)" ID="LockDURA1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA1OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Type 2 Diabetes mellitus Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Type 2 Diabetes mellitus Duration (Months)" ID="RAISEDURA2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Type 2 Diabetes mellitus Duration (Months)" ID="RAISEDURA2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA2OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Type 2 Diabetes mellitus Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Type 2 Diabetes mellitus Duration (Months)" ID="RespondedDURA2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Type 2 Diabetes mellitus Duration (Months)" ID="CLOSEDURA2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA2OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA2OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Type 2 Diabetes mellitus Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Type 2 Diabetes mellitus Duration (Months)" ID="CloseDURA2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Type 2 Diabetes mellitus Duration (Months)" ID="LockDURA2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA2OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Type 1 Diabetes Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Type 1 Diabetes Duration (Months)" ID="RAISEDURA3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA3OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA3OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA3OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA3OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Type 1 Diabetes Duration (Months)" ID="RAISEDURA3OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA3OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Type 1 Diabetes Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Type 1 Diabetes Duration (Months)" ID="RespondedDURA3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA3OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA3OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA3OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA3OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Type 1 Diabetes Duration (Months)" ID="CLOSEDURA3OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA3OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA3OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Type 1 Diabetes Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Type 1 Diabetes Duration (Months)" ID="CloseDURA3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA3OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA3OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA3OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA3OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Type 1 Diabetes Duration (Months)" ID="LockDURA3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA3OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA3OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA3OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA3OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA3OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query H/o CAD Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: H/o CAD Duration (Months)" ID="RAISEDURA4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA4OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA4OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA4OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA4OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: H/o CAD Duration (Months)" ID="RAISEDURA4OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA4OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the H/o CAD Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: H/o CAD Duration (Months)" ID="RespondedDURA4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA4OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA4OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA4OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA4OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: H/o CAD Duration (Months)" ID="CLOSEDURA4OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA4OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA4OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the H/o CAD Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: H/o CAD Duration (Months)" ID="CloseDURA4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA4OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA4OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA4OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA4OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: H/o CAD Duration (Months)" ID="LockDURA4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA4OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA4OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA4OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA4OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA4OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query H/o Stroke/ TIA Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: H/o Stroke/ TIA Duration (Months)" ID="RAISEDURA5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA5OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA5OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA5OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA5OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: H/o Stroke/ TIA Duration (Months)" ID="RAISEDURA5OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA5OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the H/o Stroke/ TIA Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: H/o Stroke/ TIA Duration (Months)" ID="RespondedDURA5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA5OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA5OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA5OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA5OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: H/o Stroke/ TIA Duration (Months)" ID="CLOSEDURA5OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA5OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA5OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the H/o Stroke/ TIA Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: H/o Stroke/ TIA Duration (Months)" ID="CloseDURA5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA5OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA5OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA5OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA5OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: H/o Stroke/ TIA Duration (Months)" ID="LockDURA5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA5OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA5OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA5OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA5OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA5OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query CKD Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: CKD Duration (Months)" ID="RAISEDURA6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA6OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA6OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA6OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA6OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: CKD Duration (Months)" ID="RAISEDURA6OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA6OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the CKD Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: CKD Duration (Months)" ID="RespondedDURA6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA6OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA6OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA6OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA6OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: CKD Duration (Months)" ID="CLOSEDURA6OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA6OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA6OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the CKD Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: CKD Duration (Months)" ID="CloseDURA6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA6OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA6OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA6OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA6OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: CKD Duration (Months)" ID="LockDURA6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA6OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA6OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA6OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA6OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA6OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Atrial Arrhythmia Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Atrial Arrhythmia Duration (Months)" ID="RAISEDURA7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA7OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA7OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA7OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA7OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Atrial Arrhythmia Duration (Months)" ID="RAISEDURA7OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA7OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Atrial Arrhythmia Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Atrial Arrhythmia Duration (Months)" ID="RespondedDURA7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA7OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA7OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA7OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA7OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Atrial Arrhythmia Duration (Months)" ID="CLOSEDURA7OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA7OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA7OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Atrial Arrhythmia Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Atrial Arrhythmia Duration (Months)" ID="CloseDURA7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA7OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA7OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA7OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA7OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Atrial Arrhythmia Duration (Months)" ID="LockDURA7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA7OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA7OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA7OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA7OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA7OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query COPD Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: COPD Duration (Months)" ID="RAISEDURA8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA8OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA8OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA8OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA8OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: COPD Duration (Months)" ID="RAISEDURA8OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA8OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the COPD Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: COPD Duration (Months)" ID="RespondedDURA8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA8OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA8OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA8OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA8OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: COPD Duration (Months)" ID="CLOSEDURA8OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA8OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA8OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the COPD Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: COPD Duration (Months)" ID="CloseDURA8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA8OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA8OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA8OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA8OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: COPD Duration (Months)" ID="LockDURA8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA8OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA8OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA8OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA8OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA8OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Obesity / OSA Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Obesity / OSA Duration (Months)" ID="RAISEDURA9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA9OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA9OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA9OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA9OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Obesity / OSA Duration (Months)" ID="RAISEDURA9OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA9OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Obesity / OSA Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Obesity / OSA Duration (Months)" ID="RespondedDURA9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA9OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA9OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA9OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA9OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Obesity / OSA Duration (Months)" ID="CLOSEDURA9OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA9OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA9OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Obesity / OSA Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Obesity / OSA Duration (Months)" ID="CloseDURA9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA9OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA9OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA9OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA9OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Obesity / OSA Duration (Months)" ID="LockDURA9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA9OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA9OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA9OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA9OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA9OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Cardiomyopathy Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Cardiomyopathy Duration (Months)" ID="RAISEDURA10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA10OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA10OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA10OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA10OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiomyopathy Duration (Months)" ID="RAISEDURA10OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA10OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Cardiomyopathy Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Cardiomyopathy Duration (Months)" ID="RespondedDURA10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA10OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA10OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA10OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA10OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiomyopathy Duration (Months)" ID="CLOSEDURA10OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA10OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA10OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Cardiomyopathy Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Cardiomyopathy Duration (Months)" ID="CloseDURA10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA10OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA10OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA10OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA10OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiomyopathy Duration (Months)" ID="LockDURA10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA10OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA10OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA10OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA10OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA10OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Hypothyroidism Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Hypothyroidism Duration (Months)" ID="RAISEDURA11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA11OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA11OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA11OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA11OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hypothyroidism Duration (Months)" ID="RAISEDURA11OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA11OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Hypothyroidism Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hypothyroidism Duration (Months)" ID="RespondedDURA11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA11OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA11OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA11OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA11OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hypothyroidism Duration (Months)" ID="CLOSEDURA11OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA11OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA11OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Hypothyroidism Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hypothyroidism Duration (Months)" ID="CloseDURA11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA11OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA11OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA11OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA11OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hypothyroidism Duration (Months)" ID="LockDURA11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA11OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA11OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA11OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA11OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA11OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Hyperthyroidism Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Hyperthyroidism Duration (Months)" ID="RAISEDURA12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA12OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA12OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA12OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA12OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hyperthyroidism Duration (Months)" ID="RAISEDURA12OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA12OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Hyperthyroidism Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hyperthyroidism Duration (Months)" ID="RespondedDURA12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA12OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA12OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA12OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA12OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hyperthyroidism Duration (Months)" ID="CLOSEDURA12OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA12OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA12OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Hyperthyroidism Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hyperthyroidism Duration (Months)" ID="CloseDURA12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA12OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA12OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA12OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA12OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hyperthyroidism Duration (Months)" ID="LockDURA12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA12OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA12OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA12OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA12OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA12OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Alcohol use (current or past) Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Alcohol use (current or past) Duration (Months)" ID="RAISEDURA13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA13OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA13OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA13OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA13OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Alcohol use (current or past) Duration (Months)" ID="RAISEDURA13OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA13OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Alcohol use (current or past) Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Alcohol use (current or past) Duration (Months)" ID="RespondedDURA13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA13OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA13OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA13OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA13OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Alcohol use (current or past) Duration (Months)" ID="CLOSEDURA13OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA13OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA13OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Alcohol use (current or past) Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Alcohol use (current or past) Duration (Months)" ID="CloseDURA13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA13OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA13OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA13OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA13OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Alcohol use (current or past) Duration (Months)" ID="LockDURA13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA13OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA13OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA13OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA13OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA13OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Tobacco use (current or past) Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Tobacco use (current or past) Duration (Months)" ID="RAISEDURA14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA14OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA14OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA14OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA14OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Tobacco use (current or past) Duration (Months)" ID="RAISEDURA14OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA14OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Tobacco use (current or past) Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Tobacco use (current or past) Duration (Months)" ID="RespondedDURA14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA14OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA14OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA14OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA14OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Tobacco use (current or past) Duration (Months)" ID="CLOSEDURA14OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA14OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA14OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Tobacco use (current or past) Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Tobacco use (current or past) Duration (Months)" ID="CloseDURA14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA14OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA14OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA14OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA14OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Tobacco use (current or past) Duration (Months)" ID="LockDURA14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA14OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA14OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA14OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA14OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA14OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Anaemia Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Anaemia Duration (Months)" ID="RAISEDURA15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA15OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA15OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA15OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA15OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Anaemia Duration (Months)" ID="RAISEDURA15OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA15OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Anaemia Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Anaemia Duration (Months)" ID="RespondedDURA15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA15OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA15OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA15OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA15OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Anaemia Duration (Months)" ID="CLOSEDURA15OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA15OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA15OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Anaemia Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Anaemia Duration (Months)" ID="CloseDURA15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA15OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA15OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA15OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA15OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Anaemia Duration (Months)" ID="LockDURA15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA15OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA15OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA15OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA15OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA15OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Chemotherapy / Drugs / radiation Duration (Months)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Chemotherapy / Drugs / radiation Duration (Months)" ID="RAISEDURA16OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA16OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA16OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA16OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA16OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA16OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA16OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA16OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Chemotherapy / Drugs / radiation Duration (Months)" ID="RAISEDURA16OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA16OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel16" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Chemotherapy / Drugs / radiation Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Chemotherapy / Drugs / radiation Duration (Months)" ID="RespondedDURA16OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA16OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA16OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA16OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA16OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA16OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA16OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA16OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Chemotherapy / Drugs / radiation Duration (Months)" ID="CLOSEDURA16OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA16OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA16OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Chemotherapy / Drugs / radiation Duration (Months) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Chemotherapy / Drugs / radiation Duration (Months)" ID="CloseDURA16OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA16OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA16OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA16OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA16OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA16OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA16OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA16OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Chemotherapy / Drugs / radiation Duration (Months)" ID="LockDURA16OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA16OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA16OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA16OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA16OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA16OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA16OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA16OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA16OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Risk Factor No 1-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Risk Factor No 1" ID="RAISEDURA17OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA17OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA17OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA17OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA17OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA17OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA17OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA17OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 1" ID="RAISEDURA17OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA17OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel17" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Risk Factor No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 1" ID="RespondedDURA17OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA17OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA17OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA17OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA17OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA17OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA17OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA17OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 1" ID="CLOSEDURA17OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA17OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA17OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Risk Factor No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 1" ID="CloseDURA17OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA17OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA17OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA17OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA17OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA17OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA17OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA17OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 1" ID="LockDURA17OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA17OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA17OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA17OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA17OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA17OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA17OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA17OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA17OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Other Risk Factor No 2-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Risk Factor No 2" ID="RAISEDURA18OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA18OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA18OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA18OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA18OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA18OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA18OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA18OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 2" ID="RAISEDURA18OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA18OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel18" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Risk Factor No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 2" ID="RespondedDURA18OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA18OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA18OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA18OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA18OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA18OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA18OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA18OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 2" ID="CLOSEDURA18OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA18OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA18OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Risk Factor No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 2" ID="CloseDURA18OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA18OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA18OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA18OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA18OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA18OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA18OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA18OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 2" ID="LockDURA18OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA18OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA18OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA18OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA18OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA18OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA18OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA18OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA18OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Risk Factor No 3-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Risk Factor No 3" ID="RAISEDURA19OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA19OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA19OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA19OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA19OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA19OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA19OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA19OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 3" ID="RAISEDURA19OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA19OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel19" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Risk Factor No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 3" ID="RespondedDURA19OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA19OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA19OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA19OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA19OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA19OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA19OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA19OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 3" ID="CLOSEDURA19OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA19OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA19OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Risk Factor No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 3" ID="CloseDURA19OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA19OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA19OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA19OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA19OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA19OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA19OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA19OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 3" ID="LockDURA19OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA19OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA19OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA19OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA19OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA19OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA19OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA19OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA19OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Risk Factor No 4-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Risk Factor No 4" ID="RAISEDURA20OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA20OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseDURA20OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseDURA20OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseDURA20OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseDURA20OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseDURA20OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseDURA20OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 4" ID="RAISEDURA20OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEDURA20OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel20" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Risk Factor No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 4" ID="RespondedDURA20OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedDURA20OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedDURA20OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedDURA20OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedDURA20OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedDURA20OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedDURA20OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedDURA20OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 4" ID="CLOSEDURA20OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEDURA20OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEDURA20OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Risk Factor No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 4" ID="CloseDURA20OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseDURA20OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseDURA20OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseDURA20OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseDURA20OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseDURA20OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseDURA20OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseDURA20OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Risk Factor No 4" ID="LockDURA20OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockDURA20OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockDURA20OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockDURA20OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockDURA20OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockDURA20OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockDURA20OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockDURA20OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockDURA20OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Javascripts-->
    <script src="../../../js/jquery-2.1.4.min.js"></script>
    <script src="../../../js/essential-plugins.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>
    <script src="../../../js/main.js"></script>
    <script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>


</asp:Content>
