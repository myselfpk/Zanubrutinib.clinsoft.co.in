<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VitalSignAndPhysicalExamination.aspx.cs" Inherits="Study_Monitor_Visit1_VitalSignAndPhysicalExamination" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Study Monitor | Visit 1 | Vital Sign And Physical Examination</title>
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
    </style>
   <script type="text/javascript">
       function Confirm() {
           var validated = Page_ClientValidate('IC');
           if (validated) {
               var confirm_value = document.createElement("INPUT");

               confirm_value.type = "hidden";
               confirm_value.name = "confirm_value";
               if (confirm("Do you want to Lock Vital Sign And Physical Examination page?")) {
                   confirm_value.value = "Yes";
               } else {
                   confirm_value.value = "No";
               }
               document.forms[0].appendChild(confirm_value);
           }
           else {

           }
       }
   </script>
    <script type="text/javascript">
        function Confirm1() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to SDV Vital Sign And Physical Examination page?")) {

                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">
        function Confirm2() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Unlocked Vital Sign And Physical Examination page?")) {

                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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
                        <asp:Label runat="server" ID="lblPage">Vital Sign And Physical Examination</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Study Monitor</li>
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
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td colspan="3"><b>Physical Examination</b></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPEHEIGHT">Height</asp:Label><span> (Cms)</span>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Height (Cms)." ControlToValidate="TextBoxPEHEIGHT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxPEHEIGHT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="[__][__][__].[__][__]Cms" ValidationGroup="IC" onkeypress="return isNumberKey(event)" AutoPostBack="True" MaxLength="6" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPEHEIGHT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPEHEIGHT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPEWEIGHT">Weight</asp:Label><span> (Kgs)</span>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Weight (Kgs)." ControlToValidate="TextBoxPEWEIGHT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxPEWEIGHT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="[__][__][__].[__][__]Kgs" ValidationGroup="IC" onkeypress="return isNumberKey(event)" AutoPostBack="True" MaxLength="6" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPEWEIGHT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPEWEIGHT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblPEBMI">BMI</asp:Label><span> (kg/m²)</span>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention BMI (kg/m²)." ControlToValidate="TextBoxPEBMI"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxPEBMI" runat="server" class="form-control" Height="45px" Width="350px" placeholder="[__][__].[__][__]kg/m²" ValidationGroup="IC" onkeypress="return isNumberKey(event)" ReadOnly="true" AutoPostBack="True" MaxLength="6" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryPEBMI" Height="25px" Width="25px" runat="server" OnClick="ImageQueryPEBMI_Click" /></td>

                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td colspan="3"><b>Vital Signs</b></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblVSSBP">SBP</asp:Label><span> (mmHg)</span>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention SBP (mmHg)." ControlToValidate="TextBoxVSSBP"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxVSSBP" runat="server" class="form-control" Height="45px" Width="350px" placeholder="[__][__][__]mmHg" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryVSSBP" Height="25px" Width="25px" runat="server" OnClick="ImageQueryVSSBP_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblVSDBP">DBP</asp:Label><span> (mmHg)</span>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention DBP (mmHg)." ControlToValidate="TextBoxVSDBP"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxVSDBP" runat="server" class="form-control" Height="45px" Width="350px" placeholder="[__][__][__]mmHg" ValidationGroup="IC" onkeypress="return isNumberKey(event)" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryVSDBP" Height="25px" Width="25px" runat="server" OnClick="ImageQueryVSDBP_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblVSPR">Pulse rate</asp:Label><span> (/min)</span>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Pulse rate (/min)." ControlToValidate="TextBoxVSPR"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxVSPR" runat="server" class="form-control" Height="45px" Width="350px" placeholder="[__][__]/min" ValidationGroup="IC" onkeypress="return isNumberKey(event)" AutoPostBack="True" MaxLength="3" TextMode="SingleLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryVSPR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryVSPR_Click" /></td>

                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td colspan="3"><b>Cardiovascular System</b></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblST1OPT">Cardiovascular system Status</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorST1OPT" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Cardiovascular system Status"
                                                    ControlToValidate="RadioButtonListST1OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListST1OPT" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>


                                            </td>


                                            <td>
                                                <asp:ImageButton ID="ImageQueryST1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryST1OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblFIND1OPT">Cardiovascular system Findings</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Cardiovascular system Findings" ControlToValidate="TextBoxFIND1OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxFIND1OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Cardiovascular system Findings" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryFIND1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryFIND1OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblJVPEVAL">JVP</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorJVPEVAL" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention JVP"
                                                    ControlToValidate="RadioButtonListJVPEVAL"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListJVPEVAL" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Elevated</asp:ListItem>
                                                    <asp:ListItem>Not Elevate</asp:ListItem>
                                                </asp:DropDownList>


                                            </td>


                                            <td>
                                                <asp:ImageButton ID="ImageQueryJVPEVAL" Height="25px" Width="25px" runat="server" OnClick="ImageQueryJVPEVAL_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblVTVF">Any Ventricular arrhythmia (VT/VF)</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorVTVF" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Any Ventricular arrhythmia (VT/VF)"
                                                    ControlToValidate="RadioButtonListVTVF"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListVTVF" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>


                                            </td>


                                            <td>
                                                <asp:ImageButton ID="ImageQueryVTVF" Height="25px" Width="25px" runat="server" OnClick="ImageQueryVTVF_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td colspan="3"><b>Respiratory</b></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblST2OPT">Respiratory Status</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorST2OPT" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Respiratory Status"
                                                    ControlToValidate="RadioButtonListST2OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:DropDownList ID="RadioButtonListST2OPT" class="form-control" Height="45px" Width="350px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>


                                            </td>


                                            <td>
                                                <asp:ImageButton ID="ImageQueryST2OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryST2OPT_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblFINE1OPT">Respiratory Findings</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Respiratory Findings" ControlToValidate="TextBoxFINE1OPT"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxFINE1OPT" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Respiratory Findings" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryFINE1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryFINE1OPT_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblOTRFIND">Any other findings?</asp:Label>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="Please mention Any other findings?" ControlToValidate="TextBoxOTRFIND"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>

                                            <td>

                                                <asp:TextBox ID="TextBoxOTRFIND" runat="server" class="form-control" Height="45px" Width="350px" placeholder="Any other findings?" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryOTRFIND" Height="25px" Width="25px" runat="server" OnClick="ImageQueryOTRFIND_Click" /></td>

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
                                  <div class="card-footer">
                                    <div class="row">
                                        <div class="col-md-5 col-md-offset-3">
                                            <asp:ValidationSummary runat="server" ShowMessageBox="true" ValidationGroup="IC" ShowSummary="false" />
                                            <asp:Button ID="Lock" class="btn btn-danger icon-btn" OnClick="OnConfirm" OnClientClick="Confirm()" ValidationGroup="IC" runat="server" Text="Lock Page" Visible="False" />                                      
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Unlocked" class="btn btn-primary icon-btn" ValidationGroup="IC" runat="server" Text="Unlock Page" OnClick="OnConfirm2" OnClientClick="Confirm2()" Visible="False" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                 <asp:Button ID="btnSDV" class="btn btn-warning icon-btn" OnClick="OnConfirm1" OnClientClick="Confirm1()" runat="server" Text="SDV" Visible="False" />

                                        </div>
                                    </div>
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

        <!-- Query Height (cms)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Height (cms)" ID="RAISEPEHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPEHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePEHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePEHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePEHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePEHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePEHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePEHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaisePEHEIGHT"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaisePEHEIGHT" runat="server" Text="Raise Query" OnClick="QueryRaisePEHEIGHT_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Height (cms)" ID="RAISEPEHEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPEHEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Height (cms) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Height (cms)" ID="RespondedPEHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPEHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPEHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPEHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPEHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPEHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPEHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPEHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedPEHEIGHTClose" runat="server" Text="Close Query"   OnClick="CloseQueryPEHEIGHT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Height (cms)" ID="CLOSEPEHEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPEHEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPEHEIGHTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Height (cms) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Height (cms)" ID="ClosePEHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePEHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePEHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePEHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePEHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePEHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePEHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePEHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonClosePEHEIGHT" runat="server" Text="Reraise Query"   OnClick="SubmitReRaisePEHEIGHT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Height (cms)" ID="LockPEHEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPEHEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPEHEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPEHEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPEHEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPEHEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPEHEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPEHEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPEHEIGHTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Weight (kgs)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Weight (kgs)" ID="RAISEPEWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPEWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePEWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePEWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePEWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePEWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePEWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePEWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaisePEWEIGHT"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaisePEWEIGHT" runat="server" Text="Raise Query" OnClick="QueryRaisePEWEIGHT_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Weight (kgs)" ID="RAISEPEWEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPEWEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Weight (kgs) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Weight (kgs)" ID="RespondedPEWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPEWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPEWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPEWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPEWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPEWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPEWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPEWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedPEWEIGHTClose" runat="server" Text="Close Query"   OnClick="CloseQueryPEWEIGHT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Weight (kgs)" ID="CLOSEPEWEIGHTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPEWEIGHTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPEWEIGHTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Weight (kgs) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Weight (kgs)" ID="ClosePEWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePEWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePEWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePEWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePEWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePEWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePEWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePEWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonClosePEWEIGHT" runat="server" Text="Reraise Query"   OnClick="SubmitReRaisePEWEIGHT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Weight (kgs)" ID="LockPEWEIGHT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPEWEIGHT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPEWEIGHT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPEWEIGHT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPEWEIGHT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPEWEIGHT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPEWEIGHT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPEWEIGHT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPEWEIGHTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query BMI (kg/m²)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: BMI (kg/m²)" ID="RAISEPEBMI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPEBMI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaisePEBMI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaisePEBMI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaisePEBMI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaisePEBMI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaisePEBMI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaisePEBMI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaisePEBMI"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaisePEBMI" runat="server" Text="Raise Query" OnClick="QueryRaisePEBMI_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: BMI (kg/m²)" ID="RAISEPEBMIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEPEBMIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the BMI (kg/m²) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: BMI (kg/m²)" ID="RespondedPEBMI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedPEBMI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedPEBMI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedPEBMI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedPEBMI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedPEBMI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedPEBMI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedPEBMI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedPEBMIClose" runat="server" Text="Close Query"   OnClick="CloseQueryPEBMI_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: BMI (kg/m²)" ID="CLOSEPEBMIMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEPEBMIMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEPEBMIMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the BMI (kg/m²) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: BMI (kg/m²)" ID="ClosePEBMI" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowClosePEBMI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelClosePEBMI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelClosePEBMI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelClosePEBMI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelClosePEBMI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelClosePEBMI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelClosePEBMI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonClosePEBMI" runat="server" Text="Reraise Query"   OnClick="SubmitReRaisePEBMI_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: BMI (kg/m²)" ID="LockPEBMI" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockPEBMI" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockPEBMI" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockPEBMI" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockPEBMI2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockPEBMI2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockPEBMI3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockPEBMI3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockPEBMIText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query SBP (mmHg)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: SBP (mmHg)" ID="RAISEVSSBP" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVSSBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseVSSBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseVSSBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseVSSBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseVSSBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseVSSBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseVSSBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseVSSBP"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseVSSBP" runat="server" Text="Raise Query" OnClick="QueryRaiseVSSBP_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SBP (mmHg)" ID="RAISEVSSBPMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVSSBPMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the SBP (mmHg) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: SBP (mmHg)" ID="RespondedVSSBP" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedVSSBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedVSSBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedVSSBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedVSSBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedVSSBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedVSSBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedVSSBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedVSSBPClose" runat="server" Text="Close Query"   OnClick="CloseQueryVSSBP_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SBP (mmHg)" ID="CLOSEVSSBPMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEVSSBPMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEVSSBPMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the SBP (mmHg) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: SBP (mmHg)" ID="CloseVSSBP" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseVSSBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseVSSBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseVSSBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseVSSBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseVSSBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseVSSBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseVSSBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseVSSBP" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseVSSBP_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SBP (mmHg)" ID="LockVSSBP" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockVSSBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockVSSBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockVSSBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockVSSBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockVSSBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockVSSBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockVSSBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockVSSBPText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query DBP (mmHg)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: DBP (mmHg)" ID="RAISEVSDBP" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVSDBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseVSDBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseVSDBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseVSDBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseVSDBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseVSDBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseVSDBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseVSDBP"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseVSDBP" runat="server" Text="Raise Query" OnClick="QueryRaiseVSDBP_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: DBP (mmHg)" ID="RAISEVSDBPMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVSDBPMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the DBP (mmHg) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: DBP (mmHg)" ID="RespondedVSDBP" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedVSDBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedVSDBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedVSDBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedVSDBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedVSDBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedVSDBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedVSDBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedVSDBPClose" runat="server" Text="Close Query"   OnClick="CloseQueryVSDBP_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: DBP (mmHg)" ID="CLOSEVSDBPMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEVSDBPMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEVSDBPMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the DBP (mmHg) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: DBP (mmHg)" ID="CloseVSDBP" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseVSDBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseVSDBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseVSDBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseVSDBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseVSDBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseVSDBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseVSDBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseVSDBP" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseVSDBP_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: DBP (mmHg)" ID="LockVSDBP" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockVSDBP" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockVSDBP" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockVSDBP" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockVSDBP2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockVSDBP2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockVSDBP3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockVSDBP3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockVSDBPText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Pulse rate (/min)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Pulse rate (/min)" ID="RAISEVSPR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVSPR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseVSPR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseVSPR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseVSPR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseVSPR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseVSPR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseVSPR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseVSPR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseVSPR" runat="server" Text="Raise Query" OnClick="QueryRaiseVSPR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Pulse rate (/min)" ID="RAISEVSPRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVSPRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Pulse rate (/min) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Pulse rate (/min)" ID="RespondedVSPR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedVSPR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedVSPR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedVSPR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedVSPR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedVSPR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedVSPR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedVSPR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedVSPRClose" runat="server" Text="Close Query"   OnClick="CloseQueryVSPR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Pulse rate (/min)" ID="CLOSEVSPRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEVSPRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEVSPRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Pulse rate (/min) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Pulse rate (/min)" ID="CloseVSPR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseVSPR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseVSPR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseVSPR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseVSPR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseVSPR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseVSPR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseVSPR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseVSPR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseVSPR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Pulse rate (/min)" ID="LockVSPR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockVSPR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockVSPR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockVSPR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockVSPR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockVSPR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockVSPR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockVSPR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockVSPRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

         <!-- Query Cardiovascular system Status-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Cardiovascular system Status" ID="RAISEST1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEST1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseST1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseST1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseST1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseST1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseST1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseST1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseST1OPT"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseST1OPT" runat="server" Text="Raise Query" OnClick="QueryRaiseST1OPT_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Status" ID="RAISEST1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEST1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Cardiovascular system Status Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Status" ID="RespondedST1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedST1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedST1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedST1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedST1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedST1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedST1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedST1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedST1OPTClose" runat="server" Text="Close Query"   OnClick="CloseQueryST1OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Status" ID="CLOSEST1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEST1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEST1OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Cardiovascular system Status Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Status" ID="CloseST1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseST1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseST1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseST1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseST1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseST1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseST1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseST1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseST1OPT" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseST1OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Status" ID="LockST1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockST1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockST1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockST1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockST1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockST1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockST1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockST1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockST1OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Cardiovascular system Findings-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Cardiovascular system Findings" ID="RAISEFIND1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEFIND1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseFIND1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseFIND1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseFIND1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseFIND1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseFIND1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseFIND1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseFIND1OPT"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseFIND1OPT" runat="server" Text="Raise Query" OnClick="QueryRaiseFIND1OPT_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Findings" ID="RAISEFIND1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEFIND1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Cardiovascular system Findings Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Findings" ID="RespondedFIND1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedFIND1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedFIND1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedFIND1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedFIND1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedFIND1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedFIND1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedFIND1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedFIND1OPTClose" runat="server" Text="Close Query"   OnClick="CloseQueryFIND1OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Findings" ID="CLOSEFIND1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEFIND1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEFIND1OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Cardiovascular system Findings Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Findings" ID="CloseFIND1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseFIND1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseFIND1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseFIND1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseFIND1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseFIND1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseFIND1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseFIND1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseFIND1OPT" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseFIND1OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Cardiovascular system Findings" ID="LockFIND1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockFIND1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockFIND1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockFIND1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockFIND1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockFIND1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockFIND1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockFIND1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockFIND1OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query JVP-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: JVP" ID="RAISEJVPEVAL" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEJVPEVAL" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseJVPEVAL" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseJVPEVAL" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseJVPEVAL2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseJVPEVAL2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseJVPEVAL3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseJVPEVAL3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseJVPEVAL"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseJVPEVAL" runat="server" Text="Raise Query" OnClick="QueryRaiseJVPEVAL_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: JVP" ID="RAISEJVPEVALMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEJVPEVALMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the JVP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: JVP" ID="RespondedJVPEVAL" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedJVPEVAL" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedJVPEVAL" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedJVPEVAL" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedJVPEVAL2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedJVPEVAL2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedJVPEVAL3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedJVPEVAL3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedJVPEVALClose" runat="server" Text="Close Query"   OnClick="CloseQueryJVPEVAL_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: JVP" ID="CLOSEJVPEVALMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEJVPEVALMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEJVPEVALMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the JVP Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: JVP" ID="CloseJVPEVAL" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseJVPEVAL" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseJVPEVAL" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseJVPEVAL" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseJVPEVAL2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseJVPEVAL2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseJVPEVAL3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseJVPEVAL3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseJVPEVAL" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseJVPEVAL_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: JVP" ID="LockJVPEVAL" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockJVPEVAL" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockJVPEVAL" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockJVPEVAL" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockJVPEVAL2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockJVPEVAL2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockJVPEVAL3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockJVPEVAL3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockJVPEVALText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Any Ventricular arrhythmia (VT/VF)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Any Ventricular arrhythmia (VT/VF)" ID="RAISEVTVF" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVTVF" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseVTVF" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseVTVF" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseVTVF2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseVTVF2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseVTVF3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseVTVF3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseVTVF"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseVTVF" runat="server" Text="Raise Query" OnClick="QueryRaiseVTVF_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Any Ventricular arrhythmia (VT/VF)" ID="RAISEVTVFMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEVTVFMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Any Ventricular arrhythmia (VT/VF) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Any Ventricular arrhythmia (VT/VF)" ID="RespondedVTVF" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedVTVF" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedVTVF" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedVTVF" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedVTVF2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedVTVF2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedVTVF3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedVTVF3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedVTVFClose" runat="server" Text="Close Query"   OnClick="CloseQueryVTVF_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Any Ventricular arrhythmia (VT/VF)" ID="CLOSEVTVFMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEVTVFMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEVTVFMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Any Ventricular arrhythmia (VT/VF) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Any Ventricular arrhythmia (VT/VF)" ID="CloseVTVF" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseVTVF" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseVTVF" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseVTVF" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseVTVF2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseVTVF2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseVTVF3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseVTVF3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseVTVF" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseVTVF_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Any Ventricular arrhythmia (VT/VF)" ID="LockVTVF" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockVTVF" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockVTVF" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockVTVF" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockVTVF2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockVTVF2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockVTVF3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockVTVF3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockVTVFText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Respiratory Status-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Respiratory Status" ID="RAISEST2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEST2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseST2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseST2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseST2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseST2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseST2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseST2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseST2OPT"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseST2OPT" runat="server" Text="Raise Query" OnClick="QueryRaiseST2OPT_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Status" ID="RAISEST2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEST2OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Respiratory Status Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Status" ID="RespondedST2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedST2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedST2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedST2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedST2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedST2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedST2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedST2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedST2OPTClose" runat="server" Text="Close Query"   OnClick="CloseQueryST2OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Status" ID="CLOSEST2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEST2OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEST2OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Respiratory Status Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Status" ID="CloseST2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseST2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseST2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseST2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseST2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseST2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseST2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseST2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseST2OPT" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseST2OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Status" ID="LockST2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockST2OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockST2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockST2OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockST2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockST2OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockST2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockST2OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockST2OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Respiratory Findings-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Respiratory Findings" ID="RAISEFINE1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEFINE1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseFINE1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseFINE1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseFINE1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseFINE1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseFINE1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseFINE1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseFINE1OPT"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseFINE1OPT" runat="server" Text="Raise Query" OnClick="QueryRaiseFINE1OPT_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Findings" ID="RAISEFINE1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEFINE1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Respiratory Findings Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Findings" ID="RespondedFINE1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedFINE1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedFINE1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedFINE1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedFINE1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedFINE1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedFINE1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedFINE1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedFINE1OPTClose" runat="server" Text="Close Query"   OnClick="CloseQueryFINE1OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Findings" ID="CLOSEFINE1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEFINE1OPTMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEFINE1OPTMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Respiratory Findings Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Findings" ID="CloseFINE1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseFINE1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseFINE1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseFINE1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseFINE1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseFINE1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseFINE1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseFINE1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseFINE1OPT" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseFINE1OPT_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Respiratory Findings" ID="LockFINE1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockFINE1OPT" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockFINE1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockFINE1OPT" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockFINE1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockFINE1OPT2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockFINE1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockFINE1OPT3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockFINE1OPTText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Any other findings?-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Any other findings?" ID="RAISEOTRFIND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOTRFIND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseOTRFIND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseOTRFIND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseOTRFIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseOTRFIND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseOTRFIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseOTRFIND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseOTRFIND"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseOTRFIND" runat="server" Text="Raise Query" OnClick="QueryRaiseOTRFIND_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Any other findings?" ID="RAISEOTRFINDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEOTRFINDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Any other findings? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Any other findings?" ID="RespondedOTRFIND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedOTRFIND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedOTRFIND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedOTRFIND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedOTRFIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedOTRFIND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedOTRFIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedOTRFIND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedOTRFINDClose" runat="server" Text="Close Query"   OnClick="CloseQueryOTRFIND_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Any other findings?" ID="CLOSEOTRFINDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEOTRFINDMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEOTRFINDMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Any other findings? Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Any other findings?" ID="CloseOTRFIND" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseOTRFIND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseOTRFIND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseOTRFIND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseOTRFIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseOTRFIND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseOTRFIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseOTRFIND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseOTRFIND" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseOTRFIND_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Any other findings?" ID="LockOTRFIND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockOTRFIND" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockOTRFIND" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockOTRFIND" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockOTRFIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockOTRFIND2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockOTRFIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockOTRFIND3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockOTRFINDText" runat="server" BorderStyle="Solid" >
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
