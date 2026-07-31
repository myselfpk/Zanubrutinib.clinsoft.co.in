<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LaboratoryInvertigations.aspx.cs" Inherits="DataView_Visit2_LaboratoryInvertigations" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | DataView | Visit 2 | Laboratory Investigations</title>
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../../../css/main.css" />
    <link href="../../css/ButtonOption.css" rel="stylesheet" />
    <link href="../../css/calender.css" rel="stylesheet" />
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

        .lab-field {
            margin-bottom: 12px;
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
                        <asp:Label runat="server" ID="lblPage">Laboratory Investigations</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>DataView</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Visit 2</asp:LinkButton></li>

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
                                            <td class="text-center"><b>Parameter</b></td>
                                            <td class="text-center"><b>Result</b></td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB1PARA">Hb (g/dl)</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxLAB1RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB1RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB1RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB2PARA">HbA1c (%)</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB2RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB2RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB2RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB3PARA">Serum creatinine (mg/dl)</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB3RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB3RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB3RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB4PARA">eGFR</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB4RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB4RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB4RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB5PARA">Peak Trop-T (ng/L)</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB5RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB5RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB5RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB6PARA">Peak Trop-I (ng/L)</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB6RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="RadioButtonListLAB6PN" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Positive</asp:ListItem>
                                                    <asp:ListItem>Negative</asp:ListItem>
                                                </asp:DropDownList>
                                                 <br />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB6RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB6RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB7PARA">BNP (pg/ml)</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB7RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB7RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB7RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB8PARA">Hs-CRP</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB8RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB8RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB8RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB9PARA">Serum Na (mEq/L)</asp:Label>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB9RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB9RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB9RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB10PARA">Serum K (mEq/L)</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxLAB10RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB10RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB10RSLT_Click" />

                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="Label1">NT Pro BNP (pg/ml)</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxLAB11RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>
                                                <br />
                                                <br />

                                                <asp:TextBox ID="TextBoxLAB11DAT" runat="server" class="form-control" onkeydown="return false" Height="45px" Width="350px" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxLAB11DAT_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxLAB11DAT">
                                                </asp:CalendarExtender>
                                                <br />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB11RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB11RSLT_Click" />

                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>

                                            <col width="50%" />
                                            <col width="40%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr class="section-header">
                                            <td colspan="6">If any other Laboratory investigations are present, please provide details below:
                                            </td>
                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Parameter</b></td>
                                            <td class="text-center"><b>Result</b></td>
                                            <td></td>
                                        </tr>

                                        <tr class="auto-style2">

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB12PARA" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxLAB12RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB12RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB12RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB13PARA" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxLAB13RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB13RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB13RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB14PARA" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxLAB14RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB14RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB14RSLT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">

                                            <td>

                                                <asp:TextBox ID="TextBoxLAB15PARA" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxLAB15RSLT" runat="server" class="form-control" Height="45px" Width="350px" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLAB15RSLT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLAB15RSLT_Click" />

                                            </td>

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

    <asp:Label runat="server" ID="lblLAB1RSLT" Text="Hb Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB2RSLT" Text="HbA1c Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB3RSLT" Text="Serum creatinine Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB4RSLT" Text="eGFR Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB5RSLT" Text="Peak Trop-T Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB6RSLT" Text="Peak Trop-I Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB7RSLT" Text="BNP Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB8RSLT" Text="Hs-CRP Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB9RSLT" Text="Serum Na Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB10RSLT" Text="Serum K Result" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB11RSLT" Text="NT Pro BNP Result" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblLAB12RSLT" Text="Other Lab Result 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB13RSLT" Text="Other Lab Result 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB14RSLT" Text="Other Lab Result 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB15RSLT" Text="Other Lab Result 4" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblLAB12PARA" Text="Other Lab Parameter 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB13PARA" Text="Other Lab Parameter 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB14PARA" Text="Other Lab Parameter 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB15PARA" Text="Other Lab Parameter 4" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblLAB6PN" Text="Peak Trop-I Positive/Negative" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblLAB11DAT" Text="NT Pro BNP Date" Visible="false"></asp:Label>

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

        <!-- Query Hb-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Hb" ID="RAISELAB1RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB1RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB1RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB1RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB1RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB1RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB1RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB1RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hb" ID="RAISELAB1RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB1RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Hb Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hb" ID="RespondedLAB1RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB1RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB1RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB1RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB1RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB1RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB1RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB1RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hb" ID="CLOSELAB1RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB1RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB1RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Hb Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hb" ID="CloseLAB1RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB1RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB1RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB1RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB1RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB1RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB1RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB1RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hb" ID="LockLAB1RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB1RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB1RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB1RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB1RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB1RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB1RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB1RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB1RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query HbA1c-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: HbA1c" ID="RAISELAB2RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB2RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB2RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB2RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB2RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB2RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB2RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB2RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: HbA1c" ID="RAISELAB2RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB2RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the HbA1c Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: HbA1c" ID="RespondedLAB2RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB2RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB2RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB2RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB2RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB2RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB2RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB2RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: HbA1c" ID="CLOSELAB2RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB2RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB2RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the HbA1c Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: HbA1c" ID="CloseLAB2RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB2RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB2RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB2RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB2RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB2RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB2RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB2RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: HbA1c" ID="LockLAB2RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB2RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB2RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB2RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB2RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB2RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB2RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB2RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB2RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Serum creatinine-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Serum creatinine" ID="RAISELAB3RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB3RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB3RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB3RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB3RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB3RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB3RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB3RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum creatinine" ID="RAISELAB3RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB3RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Serum creatinine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Serum creatinine" ID="RespondedLAB3RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB3RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB3RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB3RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB3RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB3RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB3RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB3RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum creatinine" ID="CLOSELAB3RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB3RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB3RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Serum creatinine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Serum creatinine" ID="CloseLAB3RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB3RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB3RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB3RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB3RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB3RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB3RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB3RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum creatinine" ID="LockLAB3RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB3RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB3RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB3RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB3RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB3RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB3RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB3RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB3RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query eGFR-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: eGFR" ID="RAISELAB4RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB4RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB4RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB4RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB4RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB4RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB4RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB4RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: eGFR" ID="RAISELAB4RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB4RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the eGFR Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: eGFR" ID="RespondedLAB4RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB4RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB4RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB4RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB4RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB4RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB4RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB4RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: eGFR" ID="CLOSELAB4RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB4RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB4RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the eGFR Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: eGFR" ID="CloseLAB4RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB4RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB4RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB4RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB4RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB4RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB4RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB4RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: eGFR" ID="LockLAB4RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB4RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB4RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB4RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB4RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB4RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB4RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB4RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB4RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Peak Trop-T-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Peak Trop-T" ID="RAISELAB5RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB5RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB5RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB5RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB5RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB5RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB5RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB5RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-T" ID="RAISELAB5RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB5RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Peak Trop-T Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-T" ID="RespondedLAB5RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB5RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB5RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB5RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB5RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB5RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB5RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB5RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-T" ID="CLOSELAB5RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB5RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB5RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Peak Trop-T Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-T" ID="CloseLAB5RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB5RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB5RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB5RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB5RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB5RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB5RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB5RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-T" ID="LockLAB5RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB5RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB5RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB5RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB5RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB5RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB5RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB5RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB5RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Peak Trop-I-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Peak Trop-I" ID="RAISELAB6RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB6RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB6RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB6RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB6RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB6RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB6RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB6RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-I" ID="RAISELAB6RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB6RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Peak Trop-I Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-I" ID="RespondedLAB6RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB6RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB6RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB6RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB6RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB6RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB6RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB6RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-I" ID="CLOSELAB6RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB6RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB6RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Peak Trop-I Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-I" ID="CloseLAB6RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB6RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB6RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB6RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB6RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB6RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB6RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB6RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Peak Trop-I" ID="LockLAB6RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB6RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB6RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB6RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB6RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB6RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB6RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB6RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB6RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query BNP-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: BNP" ID="RAISELAB7RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB7RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB7RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB7RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB7RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB7RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB7RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB7RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: BNP" ID="RAISELAB7RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB7RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the BNP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: BNP" ID="RespondedLAB7RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB7RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB7RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB7RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB7RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB7RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB7RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB7RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: BNP" ID="CLOSELAB7RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB7RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB7RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the BNP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: BNP" ID="CloseLAB7RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB7RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB7RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB7RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB7RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB7RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB7RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB7RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: BNP" ID="LockLAB7RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB7RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB7RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB7RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB7RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB7RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB7RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB7RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB7RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Hs-CRP-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Hs-CRP" ID="RAISELAB8RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB8RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB8RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB8RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB8RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB8RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB8RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB8RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hs-CRP" ID="RAISELAB8RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB8RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Hs-CRP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hs-CRP" ID="RespondedLAB8RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB8RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB8RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB8RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB8RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB8RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB8RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB8RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hs-CRP" ID="CLOSELAB8RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB8RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB8RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Hs-CRP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Hs-CRP" ID="CloseLAB8RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB8RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB8RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB8RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB8RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB8RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB8RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB8RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Hs-CRP" ID="LockLAB8RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB8RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB8RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB8RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB8RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB8RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB8RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB8RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB8RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Serum Na-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Serum Na" ID="RAISELAB9RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB9RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB9RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB9RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB9RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB9RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB9RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB9RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum Na" ID="RAISELAB9RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB9RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Serum Na Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Serum Na" ID="RespondedLAB9RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB9RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB9RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB9RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB9RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB9RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB9RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB9RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum Na" ID="CLOSELAB9RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB9RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB9RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Serum Na Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Serum Na" ID="CloseLAB9RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB9RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB9RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB9RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB9RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB9RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB9RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB9RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum Na" ID="LockLAB9RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB9RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB9RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB9RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB9RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB9RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB9RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB9RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB9RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Serum K-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Serum K" ID="RAISELAB10RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB10RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB10RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB10RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB10RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB10RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB10RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB10RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum K" ID="RAISELAB10RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB10RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Serum K Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Serum K" ID="RespondedLAB10RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB10RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB10RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB10RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB10RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB10RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB10RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB10RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum K" ID="CLOSELAB10RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB10RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB10RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Serum K Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Serum K" ID="CloseLAB10RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB10RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB10RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB10RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB10RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB10RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB10RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB10RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Serum K" ID="LockLAB10RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB10RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB10RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB10RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB10RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB10RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB10RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB10RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB10RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query NT Pro BNP-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: NT Pro BNP" ID="RAISELAB11RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB11RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB11RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB11RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB11RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB11RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB11RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB11RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: NT Pro BNP" ID="RAISELAB11RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB11RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the NT Pro BNP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: NT Pro BNP" ID="RespondedLAB11RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB11RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB11RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB11RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB11RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB11RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB11RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB11RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: NT Pro BNP" ID="CLOSELAB11RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB11RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB11RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the NT Pro BNP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: NT Pro BNP" ID="CloseLAB11RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB11RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB11RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB11RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB11RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB11RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB11RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB11RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: NT Pro BNP" ID="LockLAB11RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB11RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB11RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB11RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB11RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB11RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB11RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB11RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB11RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Lab Parameter & Result 1-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Lab Parameter & Result 1" ID="RAISELAB12RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB12RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB12RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB12RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB12RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB12RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB12RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB12RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 1" ID="RAISELAB12RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB12RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Lab Parameter & Result 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 1" ID="RespondedLAB12RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB12RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB12RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB12RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB12RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB12RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB12RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB12RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 1" ID="CLOSELAB12RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB12RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB12RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Lab Parameter & Result 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 1" ID="CloseLAB12RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB12RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB12RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB12RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB12RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB12RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB12RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB12RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 1" ID="LockLAB12RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB12RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB12RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB12RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB12RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB12RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB12RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB12RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB12RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Lab Parameter & Result 2-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Lab Parameter & Result 2" ID="RAISELAB13RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB13RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB13RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB13RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB13RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB13RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB13RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB13RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 2" ID="RAISELAB13RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB13RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Lab Parameter & Result 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 2" ID="RespondedLAB13RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB13RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB13RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB13RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB13RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB13RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB13RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB13RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 2" ID="CLOSELAB13RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB13RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB13RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Lab Parameter & Result 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 2" ID="CloseLAB13RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB13RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB13RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB13RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB13RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB13RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB13RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB13RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 2" ID="LockLAB13RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB13RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB13RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB13RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB13RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB13RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB13RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB13RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB13RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Lab Parameter & Result 3-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Lab Parameter & Result 3" ID="RAISELAB14RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB14RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB14RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB14RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB14RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB14RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB14RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB14RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 3" ID="RAISELAB14RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB14RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Lab Parameter & Result 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 3" ID="RespondedLAB14RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB14RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB14RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB14RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB14RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB14RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB14RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB14RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 3" ID="CLOSELAB14RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB14RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB14RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Lab Parameter & Result 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 3" ID="CloseLAB14RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB14RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB14RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB14RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB14RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB14RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB14RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB14RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 3" ID="LockLAB14RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB14RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB14RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB14RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB14RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB14RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB14RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB14RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB14RSLTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Other Lab Parameter & Result 4-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Lab Parameter & Result 4" ID="RAISELAB15RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB15RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseLAB15RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseLAB15RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseLAB15RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseLAB15RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseLAB15RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseLAB15RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 4" ID="RAISELAB15RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELAB15RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Lab Parameter & Result 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 4" ID="RespondedLAB15RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedLAB15RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedLAB15RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedLAB15RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedLAB15RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedLAB15RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedLAB15RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedLAB15RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 4" ID="CLOSELAB15RSLTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSELAB15RSLTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSELAB15RSLTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Lab Parameter & Result 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 4" ID="CloseLAB15RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseLAB15RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseLAB15RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseLAB15RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseLAB15RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseLAB15RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseLAB15RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseLAB15RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Lab Parameter & Result 4" ID="LockLAB15RSLT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockLAB15RSLT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockLAB15RSLT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockLAB15RSLT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockLAB15RSLT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockLAB15RSLT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockLAB15RSLT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockLAB15RSLT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockLAB15RSLTText" runat="server" BorderStyle="Solid" >
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
