<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdverseEventRecord.aspx.cs" Inherits="DataView_AdVisit_AdverseEventRecord" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | DataView | Adverse Event | Adverse Event Record</title>
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../../../css/main.css" />
    <link href="../../css/calender.css" rel="stylesheet" />
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

        .auto-style6 {
            height: 40px;
            text-align: left;
            font-weight: normal;
        }

        .auto-style8 {
            height: 35px;
            text-align: left;
            font-weight: normal;
            padding-left: 10px;
            padding-right: 10px;
            background-color: aliceblue;
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
                        <asp:Label runat="server" ID="lblPage">Adverse Event Record</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>DataView</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Adverse Event</asp:LinkButton></li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <asp:Panel ID="MainPanel" runat="server">
                            <div class="row">
                                <div class="text-center">

                                    <table style="" cellpadding="5px" cellspacing="0" class="CSSTableGenerator" border="solid" width="100%">
                                        <colgroup>
                                            <col width="45%" />
                                            <col width="45%" />
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

                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAEOCCUR">Is any adverse event serious in nature?</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Is any adverse event serious in nature?" ControlToValidate="RadioButtonListAEOCCUR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListAEOCCUR" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAEOCCUR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAEOCCUR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAEAEN">Adverse Event Number</asp:Label><br />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Adverse Event Number" ControlToValidate="TextBoxAEAEN"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxAEAEN" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" ReadOnly="true"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAEAEN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAEAEN_Click" />
                                            </td>
                                        </tr>
                                        <tr class="section-header">
                                            <td colspan="6">Adverse Event (AE) Form
                                            </td>
                                        </tr>

                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAEWT">What is the AE?</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention What is the AE?" ControlToValidate="TextBoxAEWT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxAEWT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAEWT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAEWT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAEDTOS">Date of onset</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of onset" ControlToValidate="TextBoxAEDTOS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxAEDTOS" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxAEDTOS_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxAEDTOS">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAEDTOS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAEDTOS_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAESVR">Severity</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Severity" ControlToValidate="RadioButtonListAESVR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListAESVR" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem Value="Mild"></asp:ListItem>
                                                    <asp:ListItem Value="Moderate"></asp:ListItem>
                                                    <asp:ListItem Value="Severe"></asp:ListItem>
                                                </asp:DropDownList>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAESVR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAESVR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="section-header">
                                            <td colspan="6">Action taken
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblAE1AT">Treatment given</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkAE1AT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAE1AT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAE1AT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblAE2AT">Withdrawn</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkAE2AT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAE2AT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAE2AT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblAE3AT">No action taken</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkAE3AT" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAE3AT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAE3AT_Click" />
                                            </td>
                                        </tr>

                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAETG">If treatment is given, please provide details</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention If treatment is given, please provide details" ControlToValidate="TextBoxAETG"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxAETG" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAETG" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAETG_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAEOAED">Outcome of the AE to date</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Outcome of the AE to date" ControlToValidate="RadioButtonListAEOAED"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListAEOAED" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem Value="Recovered"></asp:ListItem>
                                                    <asp:ListItem Value="Recovering"></asp:ListItem>
                                                    <asp:ListItem Value="Not recovered"></asp:ListItem>
                                                    <asp:ListItem Value="Recovered with sequelae"></asp:ListItem>
                                                    <asp:ListItem Value="Fatal"></asp:ListItem>
                                                    <asp:ListItem Value="Unknown"></asp:ListItem>
                                                </asp:DropDownList>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAEOAED" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAEOAED_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAESRMDR">If the subject has recovered, please mention the date of resolution of AE</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention If the subject has recovered, please mention the date of resolution of AE" ControlToValidate="TextBoxAESRMDR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxAESRMDR" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxAESRMDR_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxAESRMDR">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAESRMDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAESRMDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblAECAUS">Causality: Is the AE related to the study treatment?</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Causality: Is the AE related to the study treatment?" ControlToValidate="RadioButtonListAECAUS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListAECAUS" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem Value="Certain"></asp:ListItem>
                                                    <asp:ListItem Value="Probable/Likely"></asp:ListItem>
                                                    <asp:ListItem Value="Possible"></asp:ListItem>
                                                    <asp:ListItem Value="Unlikely"></asp:ListItem>
                                                    <asp:ListItem Value="Conditional /Unclassified"></asp:ListItem>
                                                    <asp:ListItem Value="Unassessable/Unclassifiable"></asp:ListItem>
                                                    <asp:ListItem Value="Not Related"></asp:ListItem>
                                                </asp:DropDownList>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryAECAUS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryAECAUS_Click" />
                                            </td>
                                        </tr>

                                        <tr class="section-header">
                                            <td colspan="6">Serious Adverse Event (SAE) Form
                                            </td>
                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3">
                                                <b>1. Patient Details
                                                </b>
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEPDINI">Initials & other relevant identifier (hospital/OPD record number, etc.)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Initials & other relevant identifier (hospital/OPD record number, etc.)" ControlToValidate="TextBoxSAEPDINI"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAEPDINI" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEPDINI" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEPDINI_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEPDGNDR">Gender</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Gender" ControlToValidate="RadioButtonListSAEPDGNDR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListSAEPDGNDR" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem Value="Male"></asp:ListItem>
                                                    <asp:ListItem Value="Female"></asp:ListItem>
                                                </asp:DropDownList>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEPDGNDR" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEPDGNDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEPDDOB">Date of Birth</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of Birth" ControlToValidate="TextBoxSAEPDDOB"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAEPDDOB" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxSAEPDDOB_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxSAEPDDOB">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEPDDOB" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEPDDOB_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEPDAGE">Age (Years)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Age (Years)" ControlToValidate="TextBoxSAEPDAGE"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAEPDAGE" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEPDAGE" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEPDAGE_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEPDHEIGHT">Weight (Kgs)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Weight (Kgs)" ControlToValidate="TextBoxSAEPDHEIGHT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAEPDHEIGHT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEPDHEIGHT" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEPDHEIGHT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEPDWEIGHT">Height (Cms)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Height (Cms)" ControlToValidate="TextBoxSAEPDWEIGHT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAEPDWEIGHT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEPDWEIGHT" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEPDWEIGHT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3">
                                                <b>2. Suspected Drug/Procedure(s)
                                                </b>
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSDGND">Generic name of the drug/procedure</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Generic name of the drug/procedure" ControlToValidate="TextBoxSDGND"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSDGND" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDGND" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDGND_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSCINDI">Indication(s) for which the suspect drug/procedure was prescribed or tested</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Indication(s) for which the suspect drug/procedure was prescribed or tested" ControlToValidate="TextBoxSCINDI"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSCINDI" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySCINDI" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySCINDI_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSDDFS">Dosage form and strength</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Dosage form and strength" ControlToValidate="TextBoxSDDFS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSDDFS" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDDFS" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDDFS_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSDDDR">Daily dose and regimen (specify units - e.g., mg, ml, mg/kg)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Daily dose and regimen (specify units - e.g., mg, ml, mg/kg)" ControlToValidate="TextBoxSDDDR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSDDDR" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDDDR" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDDDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSDROA">Route of administration</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Route of administration" ControlToValidate="TextBoxSDROA"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSDROA" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDROA" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDROA_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSDSTD">Start Date</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Start Date" ControlToValidate="TextBoxSDSTD"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSDSTD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxSDSTD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxSDSTD">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDSTD" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDSTD_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblSDSTT">Start Time</asp:Label><br />

                                                <asp:MaskedEditExtender ID="MaskedEditExtender3" TargetControlID="TextBoxSDSTT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxSDSTT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDSTT" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDSTT_Click" />
                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSDSPD">Stop Date</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Stop Date" ControlToValidate="TextBoxSDSPD"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSDSPD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxSDSPD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxSDSPD">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDSPD" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDSPD_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblSDSPT">Stop Time</asp:Label><br />

                                                <asp:MaskedEditExtender ID="MaskedEditExtender4" TargetControlID="TextBoxSDSPT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxSDSPT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySDSPT" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySDSPT_Click" />
                                            </td>

                                        </tr>


                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3">
                                                <b>3. Other Treatment(s)
                                                </b>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                        </colgroup>

                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Generic name of the drug/procedure</b></td>
                                            <td class="text-center"><b>Indication(s) for which the suspect drug/procedure was prescribed or tested</b></td>
                                            <td class="text-center"><b>Dosage form and strength</b></td>
                                            <td class="text-center">Daily dose and regimen<b></b></td>
                                            <td class="text-center"><b>Route of administration</b></td>
                                            <td class="text-center"><b>Start Date</b></td>
                                            <td class="text-center"><b>Start Time</b></td>
                                            <td class="text-center"><b>Stop Date</b></td>
                                            <td class="text-center"><b>Stop Time</b></td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1GND" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxOT1INDI" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1DFS" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1DDR" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1ROA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1STD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxOT1STD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxOT1STD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1STT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="TextBoxOT1STT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1SPD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxOT1SPD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxOT1SPD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT1SPT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="TextBoxOT1SPT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryOT1SPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryOT1SPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2GND" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxOT2INDI" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2DFS" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2DDR" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2ROA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2STD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxOT2STD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxOT2STD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2STT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender7" TargetControlID="TextBoxOT2STT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2SPD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxOT2SPD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxOT2SPD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT2SPT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender8" TargetControlID="TextBoxOT2SPT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryOT2SPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryOT2SPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3GND" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxOT3INDI" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3DFS" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3DDR" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3ROA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3STD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxOT3STD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxOT3STD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3STT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender9" TargetControlID="TextBoxOT3STT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3SPD" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>
                                                <asp:CalendarExtender ID="TextBoxOT3SPD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxOT3SPD">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxOT3SPT" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender10" TargetControlID="TextBoxOT3SPT"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryOT3SPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryOT3SPT_Click" />

                                            </td>

                                        </tr>
                                    </table>
                                    <table style="" cellpadding="5px" cellspacing="0" class="CSSTableGenerator" border="solid" width="100%">
                                        <colgroup>
                                            <col width="45%" />
                                            <col width="45%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3">
                                                <b>4. Details of Serious Adverse Event(s)
                                                </b>
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEFDR">Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction" ControlToValidate="TextBoxSAEFDR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxSAEFDR" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEFDR" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEFDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAESDTR">Start Date of onset of reaction</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Start Date of onset of reaction" ControlToValidate="TextBoxSAESDTR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAESDTR" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxSAESDTR_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxSAESDTR">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAESDTR" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAESDTR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblSAESDTTR">Start Time of onset of reaction</asp:Label><br />

                                                <asp:MaskedEditExtender ID="MaskedEditExtender5" TargetControlID="TextBoxSAESDTTR"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxSAESDTTR" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAESDTTR" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAESDTTR_Click" />
                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAESSPDR">Stop Date</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Stop Date" ControlToValidate="TextBoxSAESSPDR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAESSPDR" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxSAESSPDR_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxSAESSPDR">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAESSPDR" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAESSPDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblSAESSOTR">Stop Time</asp:Label><br />

                                                <asp:MaskedEditExtender ID="MaskedEditExtender6" TargetControlID="TextBoxSAESSOTR"
                                                    Mask="99:99"
                                                    MaskType="Time"
                                                    CultureName="en-us"
                                                    MessageValidatorTip="true"
                                                    AcceptAMPM="false"
                                                    runat="server">
                                                </asp:MaskedEditExtender>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:TextBox ID="TextBoxSAESSOTR" runat="server" class="form-control" Height="45px" Width="90%" placeholder="[HH]:[MM]" ValidationGroup="IC" MaxLength="5"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAESSOTR" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAESSOTR_Click" />
                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEDARI">Dechallenge and rechallenge information</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Dechallenge and rechallenge information" ControlToValidate="TextBoxSAEDARI"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxSAEDARI" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEDARI" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEDARI_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAESTG">Setting</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Setting" ControlToValidate="TextBoxSAESTG"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxSAESTG" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAESTG" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAESTG_Click" />
                                            </td>
                                        </tr>

                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3">
                                                <b>5. Outcome
                                                </b>
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEIRAS">Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted" ControlToValidate="TextBoxSAEIRAS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxSAEIRAS" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEIRAS" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEIRAS_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEIFFO">For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings" ControlToValidate="TextBoxSAEIFFO"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxSAEIFFO" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEIFFO" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEIFFO_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAEOI">Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc" ControlToValidate="TextBoxSAEOI"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxSAEOI" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAEOI" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAEOI_Click" />
                                            </td>
                                        </tr>

                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3">
                                                <b>6. Causality (Related/Unrelated) by study physician
                                                </b>
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblSAECAURU">Causality (Related/Unrelated) by study physician</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Causality (Related/Unrelated) by study physician" ControlToValidate="TextBoxSAECAURU"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxSAECAURU" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQuerySAECAURU" Height="25px" Width="25px" runat="server" OnClick="ImageQuerySAECAURU_Click" />
                                            </td>
                                        </tr>

                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3">
                                                <b>7. Details about the Investigator
                                                </b>
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPINAME">Name</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Name" ControlToValidate="TextBoxPINAME"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxPINAME" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPINAME" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPINAME_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPIADDRESS">Address</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Address" ControlToValidate="TextBoxPIADDRESS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxPIADDRESS" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPIADDRESS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPIADDRESS_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPINUMBER">Telephone number</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Telephone number" ControlToValidate="TextBoxPINUMBER"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxPINUMBER" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPINUMBER" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPINUMBER_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPTPROFESSION">Profession (specialty)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Profession (specialty)" ControlToValidate="TextBoxPTPROFESSION"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>


                                                <asp:TextBox ID="TextBoxPTPROFESSION" runat="server" class="form-control" Height="45px" Width="90%" placeholder="" ValidationGroup="IC"></asp:TextBox>


                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPTPROFESSION" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPTPROFESSION_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPIDRELA">Date of reporting the event to the Licensing Authority</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of reporting the event to the Licensing Authority" ControlToValidate="TextBoxPIDRELA"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxPIDRELA" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxPIDRELA_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxPIDRELA">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPIDRELA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPIDRELA_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPIDREECOS">Date of reporting the event to the Ethics Committee overseeing the site</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Date of reporting the event to the Ethics Committee overseeing the site" ControlToValidate="TextBoxPIDREECOS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxPIDREECOS" runat="server" class="form-control" Height="45px" Width="90%" placeholder="DD-MMM-YYYY" ValidationGroup="IC" MaxLength="11" onkeydown="return false"></asp:TextBox>

                                                <asp:CalendarExtender ID="TextBoxPIDREECOS_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                    TargetControlID="TextBoxPIDREECOS">
                                                </asp:CalendarExtender>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPIDREECOS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPIDREECOS_Click" />
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

    <asp:Label runat="server" ID="lblOT1GND" Text="Other treatment 1 Generic name of the drug/procedure" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1INDI" Text="Other treatment 1 Indication(s) for which the suspect drug/procedure was prescribed or tested" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1DFS" Text="Other treatment 1 Dosage form and strength" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1DDR" Text="Other treatment 1 Daily dose and regimen" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1ROA" Text="Route of administration" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1STD" Text="Other treatment 1 Start Date" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1STT" Text="Other treatment 1 Start Time" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1SPD" Text="Other treatment 1 Stop Date" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT1SPT" Text="Other treatment 1 Stop Time" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblOT2GND" Text="Other treatment 2 Generic name of the drug/procedure" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2INDI" Text="Other treatment 2 Indication(s) for which the suspect drug/procedure was prescribed or tested" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2DFS" Text="Other treatment 2 Dosage form and strength" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2DDR" Text="Other treatment 2 Daily dose and regimen" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2ROA" Text="Route of administration" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2STD" Text="Other treatment 2 Start Date" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2STT" Text="Other treatment 2 Start Time" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2SPD" Text="Other treatment 2 Stop Date" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT2SPT" Text="Other treatment 2 Stop Time" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblOT3GND" Text="Other treatment 3 Generic name of the drug/procedure" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3INDI" Text="Other treatment 3 Indication(s) for which the suspect drug/procedure was prescribed or tested" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3DFS" Text="Other treatment 3 Dosage form and strength" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3DDR" Text="Other treatment 3 Daily dose and regimen" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3ROA" Text="Route of administration" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3STD" Text="Other treatment 3 Start Date" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3STT" Text="Other treatment 3 Start Time" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3SPD" Text="Other treatment 3 Stop Date" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblOT3SPT" Text="Other treatment 3 Stop Time" Visible="false"></asp:Label>

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


     <!-- Query Adverse Event Number-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Adverse Event Number" ID="RAISEAEAEN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEAEN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAEAEN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAEAEN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAEAEN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAEAEN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAEAEN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAEAEN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Adverse Event Number" ID="RAISEAEAENMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEAENMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Adverse Event Number Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Adverse Event Number" ID="RespondedAEAEN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAEAEN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAEAEN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAEAEN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAEAEN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAEAEN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAEAEN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAEAEN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                         
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Adverse Event Number" ID="CLOSEAEAENMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAEAENMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAEAENMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Adverse Event Number Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Adverse Event Number" ID="CloseAEAEN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAEAEN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAEAEN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAEAEN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAEAEN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAEAEN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAEAEN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAEAEN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Adverse Event Number" ID="LockAEAEN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAEAEN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAEAEN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAEAEN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAEAEN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAEAEN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAEAEN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAEAEN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAEAENText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query any adverse event serious in nature?-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: any adverse event serious in nature?" ID="RAISEAEOCCUR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEOCCUR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAEOCCUR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAEOCCUR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAEOCCUR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAEOCCUR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAEOCCUR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAEOCCUR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: any adverse event serious in nature?" ID="RAISEAEOCCURMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEOCCURMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the any adverse event serious in nature? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: any adverse event serious in nature?" ID="RespondedAEOCCUR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAEOCCUR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAEOCCUR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAEOCCUR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAEOCCUR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAEOCCUR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAEOCCUR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAEOCCUR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: any adverse event serious in nature?" ID="CLOSEAEOCCURMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAEOCCURMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAEOCCURMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the any adverse event serious in nature? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: any adverse event serious in nature?" ID="CloseAEOCCUR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAEOCCUR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAEOCCUR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAEOCCUR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAEOCCUR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAEOCCUR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAEOCCUR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAEOCCUR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: any adverse event serious in nature?" ID="LockAEOCCUR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAEOCCUR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAEOCCUR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAEOCCUR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAEOCCUR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAEOCCUR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAEOCCUR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAEOCCUR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAEOCCURText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query What is the AE?-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: What is the AE?" ID="RAISEAEWT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEWT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAEWT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAEWT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAEWT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAEWT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAEWT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAEWT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: What is the AE?" ID="RAISEAEWTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEWTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the What is the AE? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: What is the AE?" ID="RespondedAEWT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAEWT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAEWT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAEWT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAEWT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAEWT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAEWT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAEWT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: What is the AE?" ID="CLOSEAEWTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAEWTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAEWTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the What is the AE? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: What is the AE?" ID="CloseAEWT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAEWT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAEWT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAEWT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAEWT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAEWT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAEWT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAEWT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: What is the AE?" ID="LockAEWT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAEWT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAEWT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAEWT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAEWT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAEWT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAEWT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAEWT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAEWTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Date of onset-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Date of onset" ID="RAISEAEDTOS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEDTOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAEDTOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAEDTOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAEDTOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAEDTOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAEDTOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAEDTOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of onset" ID="RAISEAEDTOSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEDTOSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Date of onset Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of onset" ID="RespondedAEDTOS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAEDTOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAEDTOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAEDTOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAEDTOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAEDTOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAEDTOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAEDTOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of onset" ID="CLOSEAEDTOSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAEDTOSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAEDTOSMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Date of onset Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of onset" ID="CloseAEDTOS" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAEDTOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAEDTOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAEDTOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAEDTOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAEDTOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAEDTOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAEDTOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of onset" ID="LockAEDTOS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAEDTOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAEDTOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAEDTOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAEDTOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAEDTOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAEDTOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAEDTOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAEDTOSText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Severity-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Severity" ID="RAISEAESVR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAESVR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAESVR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAESVR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAESVR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAESVR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAESVR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAESVR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Severity" ID="RAISEAESVRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAESVRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Severity Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Severity" ID="RespondedAESVR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAESVR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAESVR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAESVR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAESVR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAESVR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAESVR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAESVR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Severity" ID="CLOSEAESVRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAESVRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAESVRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Severity Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Severity" ID="CloseAESVR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAESVR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAESVR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAESVR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAESVR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAESVR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAESVR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAESVR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Severity" ID="LockAESVR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAESVR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAESVR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAESVR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAESVR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAESVR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAESVR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAESVR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAESVRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Treatment given-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Treatment given" ID="RAISEAE1AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAE1AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAE1AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAE1AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAE1AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAE1AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAE1AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAE1AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Treatment given" ID="RAISEAE1ATMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAE1ATMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Treatment given Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Treatment given" ID="RespondedAE1AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAE1AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAE1AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAE1AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAE1AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAE1AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAE1AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAE1AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Treatment given" ID="CLOSEAE1ATMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAE1ATMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAE1ATMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Treatment given Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Treatment given" ID="CloseAE1AT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAE1AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAE1AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAE1AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAE1AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAE1AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAE1AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAE1AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Treatment given" ID="LockAE1AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAE1AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAE1AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAE1AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAE1AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAE1AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAE1AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAE1AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAE1ATText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Withdrawn-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Withdrawn" ID="RAISEAE2AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAE2AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAE2AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAE2AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAE2AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAE2AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAE2AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAE2AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Withdrawn" ID="RAISEAE2ATMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAE2ATMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Withdrawn Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Withdrawn" ID="RespondedAE2AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAE2AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAE2AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAE2AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAE2AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAE2AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAE2AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAE2AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Withdrawn" ID="CLOSEAE2ATMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAE2ATMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAE2ATMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Withdrawn Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Withdrawn" ID="CloseAE2AT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAE2AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAE2AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAE2AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAE2AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAE2AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAE2AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAE2AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Withdrawn" ID="LockAE2AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAE2AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAE2AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAE2AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAE2AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAE2AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAE2AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAE2AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAE2ATText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query No action taken-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: No action taken" ID="RAISEAE3AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAE3AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAE3AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAE3AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAE3AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAE3AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAE3AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAE3AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: No action taken" ID="RAISEAE3ATMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAE3ATMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the No action taken Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: No action taken" ID="RespondedAE3AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAE3AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAE3AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAE3AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAE3AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAE3AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAE3AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAE3AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: No action taken" ID="CLOSEAE3ATMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAE3ATMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAE3ATMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the No action taken Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: No action taken" ID="CloseAE3AT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAE3AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAE3AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAE3AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAE3AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAE3AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAE3AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAE3AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: No action taken" ID="LockAE3AT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAE3AT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAE3AT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAE3AT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAE3AT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAE3AT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAE3AT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAE3AT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAE3ATText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query If treatment is given, please provide details-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: If treatment is given, please provide details" ID="RAISEAETG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAETG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAETG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAETG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAETG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAETG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAETG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAETG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: If treatment is given, please provide details" ID="RAISEAETGMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAETGMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the If treatment is given, please provide details Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: If treatment is given, please provide details" ID="RespondedAETG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAETG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAETG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAETG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAETG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAETG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAETG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAETG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: If treatment is given, please provide details" ID="CLOSEAETGMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAETGMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAETGMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the If treatment is given, please provide details Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: If treatment is given, please provide details" ID="CloseAETG" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAETG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAETG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAETG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAETG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAETG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAETG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAETG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: If treatment is given, please provide details" ID="LockAETG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAETG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAETG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAETG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAETG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAETG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAETG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAETG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAETGText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Outcome of the AE to date-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Outcome of the AE to date" ID="RAISEAEOAED" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEOAED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAEOAED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAEOAED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAEOAED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAEOAED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAEOAED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAEOAED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Outcome of the AE to date" ID="RAISEAEOAEDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAEOAEDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Outcome of the AE to date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Outcome of the AE to date" ID="RespondedAEOAED" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAEOAED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAEOAED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAEOAED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAEOAED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAEOAED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAEOAED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAEOAED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Outcome of the AE to date" ID="CLOSEAEOAEDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAEOAEDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAEOAEDMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Outcome of the AE to date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Outcome of the AE to date" ID="CloseAEOAED" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAEOAED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAEOAED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAEOAED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAEOAED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAEOAED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAEOAED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAEOAED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Outcome of the AE to date" ID="LockAEOAED" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAEOAED" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAEOAED" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAEOAED" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAEOAED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAEOAED2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAEOAED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAEOAED3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAEOAEDText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query If the subject has recovered, please mention the date of resolution of AE-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: If the subject has recovered, please mention the date of resolution of AE" ID="RAISEAESRMDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAESRMDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAESRMDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAESRMDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAESRMDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAESRMDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAESRMDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAESRMDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: If the subject has recovered, please mention the date of resolution of AE" ID="RAISEAESRMDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAESRMDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the If the subject has recovered, please mention the date of resolution of AE Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: If the subject has recovered, please mention the date of resolution of AE" ID="RespondedAESRMDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAESRMDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAESRMDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAESRMDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAESRMDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAESRMDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAESRMDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAESRMDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: If the subject has recovered, please mention the date of resolution of AE" ID="CLOSEAESRMDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAESRMDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAESRMDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the If the subject has recovered, please mention the date of resolution of AE Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: If the subject has recovered, please mention the date of resolution of AE" ID="CloseAESRMDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAESRMDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAESRMDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAESRMDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAESRMDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAESRMDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAESRMDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAESRMDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: If the subject has recovered, please mention the date of resolution of AE" ID="LockAESRMDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAESRMDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAESRMDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAESRMDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAESRMDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAESRMDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAESRMDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAESRMDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAESRMDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Causality: Is the AE related to the study treatment?-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Causality: Is the AE related to the study treatment?" ID="RAISEAECAUS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAECAUS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseAECAUS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseAECAUS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseAECAUS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseAECAUS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseAECAUS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseAECAUS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality: Is the AE related to the study treatment?" ID="RAISEAECAUSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEAECAUSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Causality: Is the AE related to the study treatment? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Causality: Is the AE related to the study treatment?" ID="RespondedAECAUS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedAECAUS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedAECAUS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedAECAUS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedAECAUS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedAECAUS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedAECAUS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedAECAUS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality: Is the AE related to the study treatment?" ID="CLOSEAECAUSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEAECAUSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEAECAUSMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Causality: Is the AE related to the study treatment? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Causality: Is the AE related to the study treatment?" ID="CloseAECAUS" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseAECAUS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseAECAUS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseAECAUS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseAECAUS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseAECAUS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseAECAUS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseAECAUS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality: Is the AE related to the study treatment?" ID="LockAECAUS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockAECAUS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockAECAUS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockAECAUS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockAECAUS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockAECAUS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockAECAUS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockAECAUS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockAECAUSText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Causality: Initials & other relevant identifier-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Causality: Initials & other relevant identifier" ID="RAISESAEPDINI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDINI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEPDINI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEPDINI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEPDINI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEPDINI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEPDINI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEPDINI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality: Initials & other relevant identifier" ID="RAISESAEPDINIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDINIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Causality: Initials & other relevant identifier Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Causality: Initials & other relevant identifier" ID="RespondedSAEPDINI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEPDINI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEPDINI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEPDINI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEPDINI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEPDINI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEPDINI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEPDINI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality: Initials & other relevant identifier" ID="CLOSESAEPDINIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEPDINIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEPDINIMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Causality: Initials & other relevant identifier Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Causality: Initials & other relevant identifier" ID="CloseSAEPDINI" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEPDINI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEPDINI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEPDINI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEPDINI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEPDINI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEPDINI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEPDINI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality: Initials & other relevant identifier" ID="LockSAEPDINI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEPDINI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEPDINI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEPDINI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEPDINI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEPDINI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEPDINI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEPDINI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEPDINIText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Gender-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Gender" ID="RAISESAEPDGNDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDGNDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEPDGNDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEPDGNDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEPDGNDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEPDGNDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEPDGNDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEPDGNDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Gender" ID="RAISESAEPDGNDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDGNDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Gender Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Gender" ID="RespondedSAEPDGNDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEPDGNDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEPDGNDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEPDGNDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEPDGNDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEPDGNDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEPDGNDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEPDGNDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Gender" ID="CLOSESAEPDGNDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEPDGNDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEPDGNDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Gender Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Gender" ID="CloseSAEPDGNDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEPDGNDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEPDGNDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEPDGNDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEPDGNDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEPDGNDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEPDGNDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEPDGNDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Gender" ID="LockSAEPDGNDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEPDGNDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEPDGNDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEPDGNDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEPDGNDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEPDGNDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEPDGNDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEPDGNDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEPDGNDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Date of Birth-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Date of Birth" ID="RAISESAEPDDOB" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDDOB" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEPDDOB" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEPDDOB" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEPDDOB2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEPDDOB2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEPDDOB3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEPDDOB3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of Birth" ID="RAISESAEPDDOBMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDDOBMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Date of Birth Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of Birth" ID="RespondedSAEPDDOB" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEPDDOB" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEPDDOB" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEPDDOB" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEPDDOB2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEPDDOB2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEPDDOB3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEPDDOB3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of Birth" ID="CLOSESAEPDDOBMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEPDDOBMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEPDDOBMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Date of Birth Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of Birth" ID="CloseSAEPDDOB" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEPDDOB" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEPDDOB" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEPDDOB" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEPDDOB2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEPDDOB2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEPDDOB3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEPDDOB3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of Birth" ID="LockSAEPDDOB" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEPDDOB" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEPDDOB" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEPDDOB" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEPDDOB2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEPDDOB2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEPDDOB3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEPDDOB3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEPDDOBText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Age (Years)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Age (Years)" ID="RAISESAEPDAGE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDAGE" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEPDAGE" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEPDAGE" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEPDAGE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEPDAGE2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEPDAGE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEPDAGE3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Age (Years)" ID="RAISESAEPDAGEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDAGEMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel16" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Age (Years) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Age (Years)" ID="RespondedSAEPDAGE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEPDAGE" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEPDAGE" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEPDAGE" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEPDAGE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEPDAGE2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEPDAGE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEPDAGE3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Age (Years)" ID="CLOSESAEPDAGEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEPDAGEMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEPDAGEMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Age (Years) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Age (Years)" ID="CloseSAEPDAGE" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEPDAGE" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEPDAGE" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEPDAGE" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEPDAGE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEPDAGE2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEPDAGE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEPDAGE3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Age (Years)" ID="LockSAEPDAGE" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEPDAGE" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEPDAGE" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEPDAGE" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEPDAGE2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEPDAGE2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEPDAGE3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEPDAGE3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEPDAGEText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Weight (Kgs)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Weight (Kgs)" ID="RAISESAEPDHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEPDHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEPDHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEPDHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEPDHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEPDHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEPDHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Weight (Kgs)" ID="RAISESAEPDHEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDHEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel17" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Weight (Kgs) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Weight (Kgs)" ID="RespondedSAEPDHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEPDHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEPDHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEPDHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEPDHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEPDHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEPDHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEPDHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Weight (Kgs)" ID="CLOSESAEPDHEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEPDHEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEPDHEIGHTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Weight (Kgs) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Weight (Kgs)" ID="CloseSAEPDHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEPDHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEPDHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEPDHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEPDHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEPDHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEPDHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEPDHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Weight (Kgs)" ID="LockSAEPDHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEPDHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEPDHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEPDHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEPDHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEPDHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEPDHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEPDHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEPDHEIGHTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Height (Cms)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Height (Cms)" ID="RAISESAEPDWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEPDWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEPDWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEPDWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEPDWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEPDWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEPDWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Height (Cms)" ID="RAISESAEPDWEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEPDWEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel18" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Height (Cms) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Height (Cms)" ID="RespondedSAEPDWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEPDWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEPDWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEPDWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEPDWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEPDWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEPDWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEPDWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Height (Cms)" ID="CLOSESAEPDWEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEPDWEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEPDWEIGHTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Height (Cms) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Height (Cms)" ID="CloseSAEPDWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEPDWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEPDWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEPDWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEPDWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEPDWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEPDWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEPDWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Height (Cms)" ID="LockSAEPDWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEPDWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEPDWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEPDWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEPDWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEPDWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEPDWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEPDWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEPDWEIGHTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Generic name of the drug/procedure-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Generic name of the drug/procedure" ID="RAISESDGND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDGND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDGND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDGND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDGND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDGND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDGND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDGND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug/procedure" ID="RAISESDGNDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDGNDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel19" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Generic name of the drug/procedure Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug/procedure" ID="RespondedSDGND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDGND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDGND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDGND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDGND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDGND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDGND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDGND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug/procedure" ID="CLOSESDGNDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDGNDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDGNDMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Generic name of the drug/procedure Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug/procedure" ID="CloseSDGND" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDGND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDGND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDGND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDGND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDGND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDGND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDGND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Generic name of the drug/procedure" ID="LockSDGND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDGND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDGND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDGND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDGND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDGND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDGND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDGND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDGNDText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Indication(s) for which the suspect drug/procedure was prescribed or tested-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Indication(s) for which the suspect drug/procedure was prescribed or tested" ID="RAISESCINDI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESCINDI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSCINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSCINDI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSCINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSCINDI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSCINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSCINDI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Indication(s) for which the suspect drug/procedure was prescribed or tested" ID="RAISESCINDIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESCINDIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel20" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Indication(s) for which the suspect drug/procedure was prescribed or tested Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Indication(s) for which the suspect drug/procedure was prescribed or tested" ID="RespondedSCINDI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSCINDI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSCINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSCINDI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSCINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSCINDI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSCINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSCINDI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Indication(s) for which the suspect drug/procedure was prescribed or tested" ID="CLOSESCINDIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESCINDIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESCINDIMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Indication(s) for which the suspect drug/procedure was prescribed or tested Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Indication(s) for which the suspect drug/procedure was prescribed or tested" ID="CloseSCINDI" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSCINDI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSCINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSCINDI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSCINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSCINDI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSCINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSCINDI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Indication(s) for which the suspect drug/procedure was prescribed or tested" ID="LockSCINDI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSCINDI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSCINDI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSCINDI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSCINDI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSCINDI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSCINDI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSCINDI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSCINDIText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Dosage form and strength-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Dosage form and strength" ID="RAISESDDFS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDDFS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDDFS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDDFS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDDFS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDDFS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDDFS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDDFS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dosage form and strength" ID="RAISESDDFSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDDFSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel21" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Dosage form and strength Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dosage form and strength" ID="RespondedSDDFS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDDFS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDDFS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDDFS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDDFS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDDFS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDDFS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDDFS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                         
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dosage form and strength" ID="CLOSESDDFSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDDFSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDDFSMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Dosage form and strength Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dosage form and strength" ID="CloseSDDFS" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDDFS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDDFS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDDFS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDDFS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDDFS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDDFS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDDFS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dosage form and strength" ID="LockSDDFS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDDFS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDDFS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDDFS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDDFS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDDFS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDDFS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDDFS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDDFSText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Daily dose and regimen-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Daily dose and regimen" ID="RAISESDDDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDDDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDDDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDDDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDDDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDDDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDDDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDDDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Daily dose and regimen" ID="RAISESDDDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDDDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel22" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Daily dose and regimen Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Daily dose and regimen" ID="RespondedSDDDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDDDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDDDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDDDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDDDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDDDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDDDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDDDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Daily dose and regimen" ID="CLOSESDDDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDDDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDDDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Daily dose and regimen Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Daily dose and regimen" ID="CloseSDDDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDDDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDDDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDDDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDDDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDDDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDDDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDDDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Daily dose and regimen" ID="LockSDDDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDDDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDDDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDDDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDDDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDDDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDDDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDDDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDDDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Route of administration-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Route of administration" ID="RAISESDROA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDROA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDROA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDROA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDROA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDROA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDROA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDROA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Route of administration" ID="RAISESDROAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDROAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel23" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Route of administration Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Route of administration" ID="RespondedSDROA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDROA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDROA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDROA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDROA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDROA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDROA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDROA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Route of administration" ID="CLOSESDROAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDROAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDROAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Route of administration Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Route of administration" ID="CloseSDROA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDROA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDROA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDROA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDROA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDROA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDROA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDROA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Route of administration" ID="LockSDROA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDROA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDROA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDROA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDROA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDROA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDROA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDROA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDROAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Start Date-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Start Date" ID="RAISESDSTD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSTD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDSTD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDSTD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDSTD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDSTD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDSTD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDSTD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="RAISESDSTDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSTDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel24" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Start Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="RespondedSDSTD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDSTD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDSTD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDSTD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDSTD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDSTD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDSTD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDSTD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="CLOSESDSTDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDSTDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDSTDMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Start Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="CloseSDSTD" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDSTD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDSTD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDSTD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDSTD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDSTD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDSTD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDSTD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Date" ID="LockSDSTD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDSTD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDSTD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDSTD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDSTD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDSTD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDSTD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDSTD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDSTDText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Start Time-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Start Time" ID="RAISESDSTT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSTT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDSTT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDSTT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDSTT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDSTT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDSTT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDSTT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Time" ID="RAISESDSTTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSTTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel25" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Start Time Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Time" ID="RespondedSDSTT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDSTT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDSTT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDSTT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDSTT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDSTT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDSTT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDSTT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Time" ID="CLOSESDSTTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDSTTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDSTTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Start Time Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Time" ID="CloseSDSTT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDSTT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDSTT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDSTT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDSTT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDSTT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDSTT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDSTT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Time" ID="LockSDSTT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDSTT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDSTT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDSTT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDSTT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDSTT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDSTT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDSTT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDSTTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Stop Date-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Stop Date" ID="RAISESDSPD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSPD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDSPD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDSPD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDSPD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDSPD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDSPD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDSPD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="RAISESDSPDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSPDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel26" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Stop Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="RespondedSDSPD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDSPD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDSPD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDSPD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDSPD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDSPD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDSPD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDSPD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="CLOSESDSPDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDSPDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDSPDMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Stop Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="CloseSDSPD" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDSPD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDSPD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDSPD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDSPD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDSPD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDSPD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDSPD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="LockSDSPD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDSPD" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDSPD" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDSPD" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDSPD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDSPD2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDSPD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDSPD3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDSPDText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Stop Time-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Stop Time" ID="RAISESDSPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSDSPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSDSPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSDSPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSDSPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSDSPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSDSPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="RAISESDSPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESDSPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel27" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Stop Time Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="RespondedSDSPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSDSPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSDSPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSDSPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSDSPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSDSPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSDSPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSDSPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="CLOSESDSPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESDSPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESDSPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Stop Time Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="CloseSDSPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSDSPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSDSPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSDSPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSDSPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSDSPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSDSPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSDSPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="LockSDSPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSDSPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSDSPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSDSPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSDSPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSDSPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSDSPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSDSPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSDSPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Other Treatment Row 1-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Treatment Row 1" ID="RAISEOT1SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOT1SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseOT1SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseOT1SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseOT1SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseOT1SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseOT1SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseOT1SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 1" ID="RAISEOT1SPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOT1SPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel28" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Treatment Row 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 1" ID="RespondedOT1SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedOT1SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedOT1SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedOT1SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedOT1SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedOT1SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedOT1SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedOT1SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 1" ID="CLOSEOT1SPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEOT1SPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEOT1SPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Treatment Row 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 1" ID="CloseOT1SPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseOT1SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseOT1SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseOT1SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseOT1SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseOT1SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseOT1SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseOT1SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 1" ID="LockOT1SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockOT1SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockOT1SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockOT1SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockOT1SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockOT1SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockOT1SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockOT1SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockOT1SPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Other Treatment Row 2-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Treatment Row 2" ID="RAISEOT2SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOT2SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseOT2SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseOT2SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseOT2SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseOT2SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseOT2SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseOT2SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 2" ID="RAISEOT2SPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOT2SPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel29" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Treatment Row 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 2" ID="RespondedOT2SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedOT2SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedOT2SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedOT2SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedOT2SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedOT2SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedOT2SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedOT2SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                         
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 2" ID="CLOSEOT2SPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEOT2SPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEOT2SPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Treatment Row 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 2" ID="CloseOT2SPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseOT2SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseOT2SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseOT2SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseOT2SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseOT2SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseOT2SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseOT2SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 2" ID="LockOT2SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockOT2SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockOT2SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockOT2SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockOT2SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockOT2SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockOT2SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockOT2SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockOT2SPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query Other Treatment Row 3-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Treatment Row 3" ID="RAISEOT3SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOT3SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseOT3SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseOT3SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseOT3SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseOT3SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseOT3SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseOT3SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 3" ID="RAISEOT3SPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOT3SPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel30" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Treatment Row 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 3" ID="RespondedOT3SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedOT3SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedOT3SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedOT3SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedOT3SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedOT3SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedOT3SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedOT3SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 3" ID="CLOSEOT3SPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEOT3SPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEOT3SPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Treatment Row 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 3" ID="CloseOT3SPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseOT3SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseOT3SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseOT3SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseOT3SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseOT3SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseOT3SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseOT3SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Treatment Row 3" ID="LockOT3SPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockOT3SPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockOT3SPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockOT3SPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockOT3SPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockOT3SPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockOT3SPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockOT3SPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockOT3SPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction" ID="RAISESAEFDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEFDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEFDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEFDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEFDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEFDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEFDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEFDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction" ID="RAISESAEFDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEFDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel31" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction" ID="RespondedSAEFDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEFDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEFDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEFDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEFDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEFDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEFDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEFDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction" ID="CLOSESAEFDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEFDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEFDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction" ID="CloseSAEFDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEFDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEFDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEFDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEFDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEFDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEFDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEFDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Full description of reaction(s) including body site and severity, as well as the criterion (or criteria) for regarding the report as serious. In addition to a description of the reported signs and symptoms, whenever possible, describe a specific diagnosis for the reaction" ID="LockSAEFDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEFDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEFDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEFDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEFDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEFDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEFDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEFDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEFDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Start Date of onset of reaction-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Start Date of onset of reaction" ID="RAISESAESDTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESDTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAESDTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAESDTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAESDTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAESDTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAESDTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAESDTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Date of onset of reaction" ID="RAISESAESDTRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESDTRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel32" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Start Date of onset of reaction Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Date of onset of reaction" ID="RespondedSAESDTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAESDTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAESDTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAESDTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAESDTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAESDTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAESDTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAESDTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Date of onset of reaction" ID="CLOSESAESDTRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAESDTRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAESDTRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Start Date of onset of reaction Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Date of onset of reaction" ID="CloseSAESDTR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAESDTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAESDTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAESDTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAESDTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAESDTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAESDTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAESDTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Date of onset of reaction" ID="LockSAESDTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAESDTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAESDTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAESDTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAESDTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAESDTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAESDTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAESDTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAESDTRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Start Time of onset of reaction-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Start Time of onset of reaction" ID="RAISESAESDTTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESDTTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAESDTTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAESDTTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAESDTTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAESDTTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAESDTTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAESDTTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Time of onset of reaction" ID="RAISESAESDTTRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESDTTRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel33" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Start Time of onset of reaction Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Time of onset of reaction" ID="RespondedSAESDTTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAESDTTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAESDTTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAESDTTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAESDTTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAESDTTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAESDTTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAESDTTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Time of onset of reaction" ID="CLOSESAESDTTRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAESDTTRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAESDTTRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Start Time of onset of reaction Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Start Time of onset of reaction" ID="CloseSAESDTTR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAESDTTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAESDTTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAESDTTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAESDTTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAESDTTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAESDTTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAESDTTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Start Time of onset of reaction" ID="LockSAESDTTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAESDTTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAESDTTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAESDTTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAESDTTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAESDTTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAESDTTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAESDTTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAESDTTRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Stop Date-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Stop Date" ID="RAISESAESSPDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESSPDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAESSPDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAESSPDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAESSPDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAESSPDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAESSPDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAESSPDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="RAISESAESSPDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESSPDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel34" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Stop Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="RespondedSAESSPDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAESSPDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAESSPDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAESSPDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAESSPDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAESSPDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAESSPDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAESSPDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="CLOSESAESSPDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAESSPDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAESSPDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Stop Date Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="CloseSAESSPDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAESSPDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAESSPDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAESSPDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAESSPDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAESSPDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAESSPDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAESSPDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Date" ID="LockSAESSPDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAESSPDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAESSPDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAESSPDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAESSPDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAESSPDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAESSPDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAESSPDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAESSPDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Stop Time-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Stop Time" ID="RAISESAESSOTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESSOTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAESSOTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAESSOTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAESSOTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAESSOTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAESSOTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAESSOTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="RAISESAESSOTRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESSOTRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel35" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Stop Time Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="RespondedSAESSOTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAESSOTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAESSOTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAESSOTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAESSOTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAESSOTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAESSOTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAESSOTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="CLOSESAESSOTRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAESSOTRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAESSOTRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Stop Time Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="CloseSAESSOTR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAESSOTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAESSOTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAESSOTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAESSOTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAESSOTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAESSOTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAESSOTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Stop Time" ID="LockSAESSOTR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAESSOTR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAESSOTR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAESSOTR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAESSOTR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAESSOTR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAESSOTR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAESSOTR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAESSOTRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Dechallenge and rechallenge information-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Dechallenge and rechallenge information" ID="RAISESAEDARI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEDARI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEDARI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEDARI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEDARI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEDARI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEDARI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEDARI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dechallenge and rechallenge information" ID="RAISESAEDARIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEDARIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel36" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Dechallenge and rechallenge information Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dechallenge and rechallenge information" ID="RespondedSAEDARI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEDARI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEDARI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEDARI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEDARI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEDARI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEDARI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEDARI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dechallenge and rechallenge information" ID="CLOSESAEDARIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEDARIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEDARIMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Dechallenge and rechallenge information Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dechallenge and rechallenge information" ID="CloseSAEDARI" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEDARI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEDARI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEDARI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEDARI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEDARI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEDARI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEDARI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dechallenge and rechallenge information" ID="LockSAEDARI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEDARI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEDARI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEDARI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEDARI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEDARI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEDARI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEDARI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEDARIText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Setting-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Setting" ID="RAISESAESTG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESTG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAESTG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAESTG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAESTG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAESTG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAESTG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAESTG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Setting" ID="RAISESAESTGMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAESTGMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel37" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Setting Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Setting" ID="RespondedSAESTG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAESTG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAESTG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAESTG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAESTG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAESTG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAESTG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAESTG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Setting" ID="CLOSESAESTGMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAESTGMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAESTGMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Setting Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Setting" ID="CloseSAESTG" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAESTG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAESTG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAESTG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAESTG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAESTG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAESTG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAESTG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Setting" ID="LockSAESTG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAESTG" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAESTG" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAESTG" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAESTG2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAESTG2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAESTG3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAESTG3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAESTGText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!-- Query Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted" ID="RAISESAEIRAS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEIRAS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEIRAS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEIRAS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEIRAS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEIRAS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEIRAS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEIRAS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted" ID="RAISESAEIRASMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEIRASMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel38" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted" ID="RespondedSAEIRAS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEIRAS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEIRAS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEIRAS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEIRAS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEIRAS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEIRAS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEIRAS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted" ID="CLOSESAEIRASMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEIRASMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEIRASMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted" ID="CloseSAEIRAS" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEIRAS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEIRAS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEIRAS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEIRAS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEIRAS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEIRAS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEIRAS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                 
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Information on recovery and any sequelae; results of specific tests and/or treatment that may have been conducted" ID="LockSAEIRAS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEIRAS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEIRAS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEIRAS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEIRAS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEIRAS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEIRAS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEIRAS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEIRASText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings" ID="RAISESAEIFFO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEIFFO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEIFFO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEIFFO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEIFFO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEIFFO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEIFFO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEIFFO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings" ID="RAISESAEIFFOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEIFFOMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel39" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings" ID="RespondedSAEIFFO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEIFFO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEIFFO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEIFFO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEIFFO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEIFFO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEIFFO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEIFFO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings" ID="CLOSESAEIFFOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEIFFOMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEIFFOMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings" ID="CloseSAEIFFO" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEIFFO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEIFFO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEIFFO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEIFFO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEIFFO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEIFFO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEIFFO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: For a fatal outcome, cause of death, and a comment on its possible relationship to the suspected reaction, any post-mortem findings" ID="LockSAEIFFO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEIFFO" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEIFFO" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEIFFO" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEIFFO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEIFFO2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEIFFO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEIFFO3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEIFFOText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc" ID="RAISESAEOI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEOI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAEOI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAEOI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAEOI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAEOI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAEOI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAEOI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                 
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc" ID="RAISESAEOIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAEOIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel40" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc" ID="RespondedSAEOI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAEOI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAEOI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAEOI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAEOI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAEOI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAEOI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAEOI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc" ID="CLOSESAEOIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAEOIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAEOIMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc" ID="CloseSAEOI" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAEOI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAEOI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAEOI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAEOI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAEOI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAEOI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAEOI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other information: anything relevant to facilitate assessment of the case, such as medical history including allergy, drug/procedure or alcohol abuse; family history; findings from special investigations, etc" ID="LockSAEOI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAEOI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAEOI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAEOI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAEOI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAEOI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAEOI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAEOI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAEOIText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Causality (Related/Unrelated) by study physician-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Causality (Related/Unrelated) by study physician" ID="RAISESAECAURU" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAECAURU" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseSAECAURU" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseSAECAURU" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseSAECAURU2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseSAECAURU2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseSAECAURU3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseSAECAURU3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality (Related/Unrelated) by study physician" ID="RAISESAECAURUMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISESAECAURUMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel41" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Causality (Related/Unrelated) by study physician Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Causality (Related/Unrelated) by study physician" ID="RespondedSAECAURU" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedSAECAURU" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedSAECAURU" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedSAECAURU" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedSAECAURU2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedSAECAURU2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedSAECAURU3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedSAECAURU3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality (Related/Unrelated) by study physician" ID="CLOSESAECAURUMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSESAECAURUMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSESAECAURUMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Causality (Related/Unrelated) by study physician Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Causality (Related/Unrelated) by study physician" ID="CloseSAECAURU" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseSAECAURU" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseSAECAURU" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseSAECAURU" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseSAECAURU2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseSAECAURU2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseSAECAURU3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseSAECAURU3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Causality (Related/Unrelated) by study physician" ID="LockSAECAURU" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockSAECAURU" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockSAECAURU" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockSAECAURU" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockSAECAURU2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockSAECAURU2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockSAECAURU3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockSAECAURU3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockSAECAURUText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Name-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Name" ID="RAISEPINAME" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPINAME" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePINAME" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePINAME" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePINAME2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePINAME2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePINAME3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePINAME3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Name" ID="RAISEPINAMEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPINAMEMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel42" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Name Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Name" ID="RespondedPINAME" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPINAME" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPINAME" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPINAME" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPINAME2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPINAME2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPINAME3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPINAME3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Name" ID="CLOSEPINAMEMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPINAMEMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPINAMEMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Name Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Name" ID="ClosePINAME" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePINAME" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePINAME" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePINAME" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePINAME2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePINAME2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePINAME3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePINAME3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Name" ID="LockPINAME" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPINAME" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPINAME" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPINAME" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPINAME2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPINAME2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPINAME3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPINAME3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPINAMEText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Address-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Address" ID="RAISEPIADDRESS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPIADDRESS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePIADDRESS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePIADDRESS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePIADDRESS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePIADDRESS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePIADDRESS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePIADDRESS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Address" ID="RAISEPIADDRESSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPIADDRESSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel43" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Address Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Address" ID="RespondedPIADDRESS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPIADDRESS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPIADDRESS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPIADDRESS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPIADDRESS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPIADDRESS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPIADDRESS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPIADDRESS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Address" ID="CLOSEPIADDRESSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPIADDRESSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPIADDRESSMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Address Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Address" ID="ClosePIADDRESS" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePIADDRESS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePIADDRESS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePIADDRESS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePIADDRESS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePIADDRESS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePIADDRESS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePIADDRESS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Address" ID="LockPIADDRESS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPIADDRESS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPIADDRESS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPIADDRESS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPIADDRESS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPIADDRESS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPIADDRESS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPIADDRESS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPIADDRESSText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Telephone number-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Telephone number" ID="RAISEPINUMBER" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPINUMBER" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePINUMBER" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePINUMBER" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePINUMBER2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePINUMBER2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePINUMBER3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePINUMBER3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Telephone number" ID="RAISEPINUMBERMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPINUMBERMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel44" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Telephone number Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Telephone number" ID="RespondedPINUMBER" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPINUMBER" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPINUMBER" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPINUMBER" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPINUMBER2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPINUMBER2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPINUMBER3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPINUMBER3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Telephone number" ID="CLOSEPINUMBERMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPINUMBERMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPINUMBERMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Telephone number Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Telephone number" ID="ClosePINUMBER" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePINUMBER" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePINUMBER" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePINUMBER" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePINUMBER2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePINUMBER2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePINUMBER3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePINUMBER3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Telephone number" ID="LockPINUMBER" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPINUMBER" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPINUMBER" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPINUMBER" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPINUMBER2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPINUMBER2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPINUMBER3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPINUMBER3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPINUMBERText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Profession (specialty)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Profession (specialty)" ID="RAISEPTPROFESSION" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPTPROFESSION" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePTPROFESSION" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePTPROFESSION" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePTPROFESSION2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePTPROFESSION2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePTPROFESSION3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePTPROFESSION3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Profession (specialty)" ID="RAISEPTPROFESSIONMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPTPROFESSIONMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel45" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Profession (specialty) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Profession (specialty)" ID="RespondedPTPROFESSION" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPTPROFESSION" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPTPROFESSION" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPTPROFESSION" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPTPROFESSION2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPTPROFESSION2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPTPROFESSION3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPTPROFESSION3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Profession (specialty)" ID="CLOSEPTPROFESSIONMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPTPROFESSIONMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPTPROFESSIONMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Profession (specialty) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Profession (specialty)" ID="ClosePTPROFESSION" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePTPROFESSION" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePTPROFESSION" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePTPROFESSION" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePTPROFESSION2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePTPROFESSION2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePTPROFESSION3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePTPROFESSION3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Profession (specialty)" ID="LockPTPROFESSION" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPTPROFESSION" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPTPROFESSION" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPTPROFESSION" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPTPROFESSION2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPTPROFESSION2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPTPROFESSION3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPTPROFESSION3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPTPROFESSIONText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Date of reporting the event to the Licensing Authority-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Date of reporting the event to the Licensing Authority" ID="RAISEPIDRELA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPIDRELA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePIDRELA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePIDRELA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePIDRELA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePIDRELA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePIDRELA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePIDRELA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Licensing Authority" ID="RAISEPIDRELAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPIDRELAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel46" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Date of reporting the event to the Licensing Authority Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Licensing Authority" ID="RespondedPIDRELA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPIDRELA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPIDRELA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPIDRELA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPIDRELA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPIDRELA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPIDRELA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPIDRELA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Licensing Authority" ID="CLOSEPIDRELAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPIDRELAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPIDRELAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Date of reporting the event to the Licensing Authority Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Licensing Authority" ID="ClosePIDRELA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePIDRELA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePIDRELA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePIDRELA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePIDRELA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePIDRELA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePIDRELA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePIDRELA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Licensing Authority" ID="LockPIDRELA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPIDRELA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPIDRELA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPIDRELA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPIDRELA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPIDRELA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPIDRELA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPIDRELA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPIDRELAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

     <!-- Query Date of reporting the event to the Ethics Committee overseeing the site-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Date of reporting the event to the Ethics Committee overseeing the site" ID="RAISEPIDREECOS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPIDREECOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePIDREECOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePIDREECOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePIDREECOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePIDREECOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePIDREECOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePIDREECOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Ethics Committee overseeing the site" ID="RAISEPIDREECOSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPIDREECOSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel47" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Date of reporting the event to the Ethics Committee overseeing the site Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Ethics Committee overseeing the site" ID="RespondedPIDREECOS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPIDREECOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPIDREECOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPIDREECOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPIDREECOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPIDREECOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPIDREECOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPIDREECOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Ethics Committee overseeing the site" ID="CLOSEPIDREECOSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPIDREECOSMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPIDREECOSMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Date of reporting the event to the Ethics Committee overseeing the site Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Ethics Committee overseeing the site" ID="ClosePIDREECOS" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePIDREECOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePIDREECOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePIDREECOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePIDREECOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePIDREECOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePIDREECOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePIDREECOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Date of reporting the event to the Ethics Committee overseeing the site" ID="LockPIDREECOS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPIDREECOS" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPIDREECOS" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPIDREECOS" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPIDREECOS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPIDREECOS2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPIDREECOS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPIDREECOS3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPIDREECOSText" runat="server" BorderStyle="Solid" >
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
