<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConcomitantMedicationLog.aspx.cs" Inherits="Data_Entry_AdVisit_ConcomitantMedicationLog" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Data Entry | Concomitant Medication | Concomitant Medication Log</title>
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

        .INST-Text {
            background-color: darkseagreen;
            color: black;
        }

        .INST-Text2 {
            padding-left: 12px;
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
            var validated = Page_ClientValidate('Demography');
            if (validated) {
                var confirm_value = document.createElement("INPUT");

                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to Submit Concomitant Medication Log  Page?")) {
                    confirm_value.value = "Yes";
                } else {
                    confirm_value.value = "No";
                }
                document.forms[0].appendChild(confirm_value);
            }
            else {

            }
        }
    </script >
            <script type="text/javascript">
                function Confirm1() {
            var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to Save Concomitant Medication Log Page?")) {
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

        .rbl {
            height: 20px;
        }

        .auto-style3 {
            height: 50px;
            text-align: center;
            background-color: #CCCCCC;
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
                        <asp:Label runat="server" ID="lblPage">Concomitant Medication Log</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Concomitant Medication</asp:LinkButton></li>
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

                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCNSNO" runat="server">ConMed Serial No.</asp:Label>
                                          </td>

                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCNSNO" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" ReadOnly="True"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Event No not correct" ControlToValidate="TextBoxCNSNO"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>

                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCNSNO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCNSNO_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLMN" runat="server">Medication Name</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLMN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Medication Name" ControlToValidate="TextBoxCMLMN"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCMLMN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLMN_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLMT" runat="server">Medication Taken For</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:DropDownList ID="RadioButtonListCMLMT" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListCMLMT_SelectedIndexChanged">
                                                  <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                  <asp:ListItem>AE</asp:ListItem>
                                                  <asp:ListItem>SAE</asp:ListItem>
                                                  <asp:ListItem>Medical History</asp:ListItem>
                                                  <asp:ListItem>Other</asp:ListItem>
                                              </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Please mention Medication Taken For"
                                                  CssClass="Validators" Display="None" ControlToValidate="RadioButtonListCMLMT"
                                                  ValidationGroup="IC" ForeColor="Red"></asp:RequiredFieldValidator>

                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImageQueryCMLMT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLMT_Click" />
                                          </td>
                                      </tr>
                                      <tr id="hideCMLMTO" runat="server" visible="false">
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLMTO" runat="server">Other Medication Taken For</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLMTO" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Other Medication Taken For" ControlToValidate="TextBoxCMLMTO"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCMLMTO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLMTO_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLIND" runat="server">Indication</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLIND" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Indication" ControlToValidate="TextBoxCMLIND"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCMLIND" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLIND_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLDS" runat="server">Dose</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLDS" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Dose" ControlToValidate="TextBoxCMLDS"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCMLDS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLDS_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLUT" runat="server">Unit</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:DropDownList ID="RadioButtonListCMLUT" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListCMLUT_SelectedIndexChanged">
                                                  <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                  <asp:ListItem>gm</asp:ListItem>
                                                  <asp:ListItem>mg</asp:ListItem>
                                                  <asp:ListItem>app</asp:ListItem>
                                                  <asp:ListItem>μg</asp:ListItem>
                                                  <asp:ListItem>Ml</asp:ListItem>
                                                  <asp:ListItem>IU</asp:ListItem>
                                                  <asp:ListItem>Units</asp:ListItem>
                                                  <asp:ListItem>L</asp:ListItem>
                                                  <asp:ListItem>Other</asp:ListItem>
                                              </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Please mention Unit"
                                                  CssClass="Validators" Display="None" ControlToValidate="RadioButtonListCMLUT"
                                                  ValidationGroup="IC" ForeColor="Red"></asp:RequiredFieldValidator>

                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImageQueryCMLUT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLUT_Click" />
                                          </td>
                                      </tr>
                                      <tr id="hideCMLUTO" runat="server" visible="false">
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLUTO" runat="server">Other Unit</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLUTO" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Other Unit" ControlToValidate="TextBoxCMLUTO"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCMLUTO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLUTO_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLFRQ" runat="server">Frequency</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:DropDownList ID="RadioButtonListCMLFRQ" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListCMLFRQ_SelectedIndexChanged">
                                                  <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                  <asp:ListItem>PRN</asp:ListItem>
                                                  <asp:ListItem>Every Day (QD)</asp:ListItem>
                                                  <asp:ListItem>Twice a Day (BID)</asp:ListItem>
                                                  <asp:ListItem>3 Times a Day (TID)</asp:ListItem>
                                                  <asp:ListItem>Every Other Day (QOD)</asp:ListItem>
                                                  <asp:ListItem>Every Hour (QH)</asp:ListItem>
                                                  <asp:ListItem>Every 4 Hours (Q4H)</asp:ListItem>
                                                  <asp:ListItem>Once Weekly (OW)</asp:ListItem>
                                                  <asp:ListItem>Twice Weekly (TIW)</asp:ListItem>
                                                  <asp:ListItem>Other</asp:ListItem>
                                              </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Please mention Frequency"
                                                  CssClass="Validators" Display="None" ControlToValidate="RadioButtonListCMLFRQ"
                                                  ValidationGroup="IC" ForeColor="Red"></asp:RequiredFieldValidator>

                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImageQueryCMLFRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLFRQ_Click" />
                                          </td>
                                      </tr>
                                      <tr id="hideCMLFRQO" runat="server" visible="false">
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLFRQO" runat="server">Other Frequency</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLFRQO" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Other Frequency" ControlToValidate="TextBoxCMLFRQO"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCMLFRQO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLFRQO_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLRT" runat="server">Route</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:DropDownList ID="RadioButtonListCMLRT" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListCMLRT_SelectedIndexChanged">
                                                  <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                  <asp:ListItem>Per Oral (PO)</asp:ListItem>
                                                  <asp:ListItem>Sublingual (SL)</asp:ListItem>
                                                  <asp:ListItem>Subcutaneous (SC)</asp:ListItem>
                                                  <asp:ListItem>Inhaled (IH)</asp:ListItem>
                                                  <asp:ListItem>Intramuscular (IM)</asp:ListItem>
                                                  <asp:ListItem>Topical (TOP)</asp:ListItem>
                                                  <asp:ListItem>Intravenous (IV)</asp:ListItem>
                                                  <asp:ListItem>Nasal (N)</asp:ListItem>
                                                  <asp:ListItem>Per Rectal (PR)</asp:ListItem>
                                                  <asp:ListItem>Intrauterine (IU)</asp:ListItem>
                                                  <asp:ListItem>Other (specify)</asp:ListItem>
                                              </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="Please mention Route"
                                                  CssClass="Validators" Display="None" ControlToValidate="RadioButtonListCMLRT"
                                                  ValidationGroup="IC" ForeColor="Red"></asp:RequiredFieldValidator>

                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImageQueryCMLRT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLRT_Click" />
                                          </td>
                                      </tr>
                                      <tr id="hideCMLRTO" runat="server" visible="false">
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLRTO" runat="server">Other Route</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLRTO" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Other Route" ControlToValidate="TextBoxCMLRTO"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:ImageButton ID="ImageQueryCMLRTO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLRTO_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLSD" runat="server">Start Date</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLSD" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" placeholder="DD-MMM-YYYY" onkeydown="return false"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Start Date" ControlToValidate="TextBoxCMLSD"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                              <asp:CalendarExtender ID="TextBoxCMLSD_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                  TargetControlID="TextBoxCMLSD">
                                              </asp:CalendarExtender>
                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImageQueryCMLSD" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLSD_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLONGO" runat="server">Ongoing</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">
                                              <asp:DropDownList ID="RadioButtonListCMLONGO" class="form-control" Height="45px" Width="90%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListCMLONGO_SelectedIndexChanged">
                                                  <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                  <asp:ListItem>Yes</asp:ListItem>
                                                  <asp:ListItem>No</asp:ListItem>
                                              </asp:DropDownList>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="Please mention Ongoing"
                                                  CssClass="Validators" Display="None" ControlToValidate="RadioButtonListCMLONGO"
                                                  ValidationGroup="IC" ForeColor="Red"></asp:RequiredFieldValidator>

                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImageQueryCMLONGO" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLONGO_Click" />
                                          </td>
                                      </tr>
                                      <tr id="hideCMLED" runat="server" visible="false">
                                          <td align="center" class="auto-style2">
                                              <asp:Label ID="lblCMLED" runat="server">Stop Date</asp:Label>
                                          </td>
                                          <td align="center" class="auto-style2">

                                              <asp:TextBox ID="TextBoxCMLED" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" placeholder="DD-MMM-YYYY" onkeydown="return false"></asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"
                                                  CssClass="Validators" Display="None" ErrorMessage="Please fill Stop Date" ControlToValidate="TextBoxCMLED"
                                                  ValidationGroup="IC"></asp:RequiredFieldValidator>
                                              <asp:CalendarExtender ID="TextBoxCMLED_CalendarExtender" runat="server" CssClass="black" Enabled="True" Format="dd-MMM-yyyy"
                                                  TargetControlID="TextBoxCMLED">
                                              </asp:CalendarExtender>
                                          </td>
                                          <td>
                                              <asp:ImageButton ID="ImageQueryCMLED" Height="25px" Width="25px" runat="server" OnClick="ImageQueryCMLED_Click" />
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
                                    <div class="card-footer">
                                        <div class="row">
                                            <div class="col-md-5 col-md-offset-3">
                                                <asp:ValidationSummary runat="server" ShowMessageBox="true" ValidationGroup="IC" ShowSummary="false" />

                                                <asp:Button ID="Save" class="btn btn-info icon-btn" runat="server" Text="Save" OnClick="OnConfirm1" OnClientClick="Confirm1()" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Submit" class="btn btn-success icon-btn" OnClick="OnConfirm" OnClientClick="Confirm()" ValidationGroup="IC" runat="server" Text="Submit" />

                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PanelChangedata" runat="server" Visible="false">
                            <table width="100%" cellpadding="5px;" cellspacing="0" border="1">
                                <colgroup>
                                    <col width="70%" />
                                </colgroup>
                                <tr>
                                    <td>
                                        <asp:GridView Width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False"
                                            HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Groove" BorderWidth="1px" CellPadding="3" CssClass="table table-bordered table-responsive table-hover">
                                            <HeaderStyle VerticalAlign="Middle" BorderStyle="None" Height="40" HorizontalAlign="Center" Wrap="true" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Question Text" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="30%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbColumn" runat="server" Text='<%#Eval("Column") %>' Font-Bold="true" ForeColor="#003300"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Old Data" HeaderStyle-Width="21%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbOldValue" runat="server" Text='<%#Eval("OldValue") %>' Font-Bold="True"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="New Data" HeaderStyle-Width="21%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbNewValue" runat="server" Text='<%#Eval("NewValue") %>' Font-Bold="True"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reason for Change" HeaderStyle-Width="28%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtComment" CssClass="textClass" TextMode="MultiLine" Height="40px" Width="300px" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ForeColor="Red" Font-Size="Larger" ValidationGroup="gridview" ControlToValidate="txtComment" Display="Dynamic"
                                                            ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Font-Bold="True" />
                                            <RowStyle ForeColor="#000066" Font-Bold="True" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                    </td>

                                </tr>

                            </table>
                            <div class="card-footer">
                                <div class="row">
                                    <div class="col-md-12 col-md-offset-5">
                                        <asp:Button ID="Button3" class="btn btn-success icon-btn" ValidationGroup="gridview" runat="server" Text="Submit" OnClick="Button3_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button4" class="btn btn-default icon-btn" runat="server" Text="Cancel" OnClick="Button4_Click" />
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

    <!--Query ConMed Serial No. -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: ConMed Serial No." ID="RAISECNSNO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECNSNO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCNSNO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCNSNO" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCNSNO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCNSNO2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCNSNO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCNSNO3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCNSNO" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCNSNO" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCNSNO" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCNSNO" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCNSNO" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCNSNO_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: ConMed Serial No." ID="RAISECNSNOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECNSNOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Responded of the ConMed Serial No. Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

    <!--Query Medication Name -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Medication Name" ID="RAISECMLMN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLMN" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLMN" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLMN" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLMN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLMN2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLMN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLMN3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLMN" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLMN" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLMN" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLMN" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLMN" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLMN_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Medication Name" ID="RAISECMLMNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLMNMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Medication Name Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Medication Taken For -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Medication Taken For" ID="RAISECMLMT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLMT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLMT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLMT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLMT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLMT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLMT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLMT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLMT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLMT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLMT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLMT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLMT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLMT_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Medication Taken For" ID="RAISECMLMTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLMTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Medication Taken For Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Other Medication Taken For -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Medication Taken For" ID="RAISECMLMTO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLMTO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLMTO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLMTO" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLMTO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLMTO2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLMTO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLMTO3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLMTO" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLMTO" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLMTO" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLMTO" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLMTO" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLMTO_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Medication Taken For" ID="RAISECMLMTOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLMTOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Other Medication Taken For Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Indication -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Indication" ID="RAISECMLIND" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLIND" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLIND" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLIND" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLIND2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLIND2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLIND3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLIND3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLIND" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLIND" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLIND" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLIND" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLIND" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLIND_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Indication" ID="RAISECMLINDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLINDMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Indication Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Dose -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Dose" ID="RAISECMLDS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLDS" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLDS" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLDS" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLDS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLDS2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLDS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLDS3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLDS" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLDS" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLDS" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLDS" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLDS" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLDS_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Dose" ID="RAISECMLDSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLDSMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Dose Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Unit -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Unit" ID="RAISECMLUT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLUT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLUT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLUT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLUT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLUT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLUT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLUT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLUT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLUT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLUT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLUT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLUT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLUT_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Unit" ID="RAISECMLUTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLUTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Unit Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Other Unit -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Unit" ID="RAISECMLUTO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLUTO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLUTO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLUTO" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLUTO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLUTO2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLUTO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLUTO3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLUTO" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLUTO" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLUTO" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLUTO" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLUTO" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLUTO_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Unit" ID="RAISECMLUTOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLUTOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Other Unit Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Frequency -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Frequency" ID="RAISECMLFRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLFRQ" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLFRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLFRQ" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLFRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLFRQ2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLFRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLFRQ3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLFRQ" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLFRQ" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLFRQ" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLFRQ" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLFRQ" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLFRQ_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Frequency" ID="RAISECMLFRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLFRQMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Frequency Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Other Frequency -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Frequency" ID="RAISECMLFRQO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLFRQO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLFRQO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLFRQO" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLFRQO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLFRQO2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLFRQO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLFRQO3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLFRQO" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLFRQO" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLFRQO" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLFRQO" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLFRQO" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLFRQO_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Frequency" ID="RAISECMLFRQOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLFRQOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Other Frequency Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Route -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Route" ID="RAISECMLRT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLRT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLRT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLRT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLRT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLRT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLRT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLRT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLRT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLRT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLRT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLRT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLRT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLRT_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Route" ID="RAISECMLRTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLRTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Route Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Other Route -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Route" ID="RAISECMLRTO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLRTO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLRTO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLRTO" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLRTO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLRTO2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLRTO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLRTO3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLRTO" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLRTO" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLRTO" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLRTO" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLRTO" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLRTO_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Other Route" ID="RAISECMLRTOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLRTOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Other Route Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Start Date -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Start Date" ID="RAISECMLSD" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLSD" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLSD" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLSD" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLSD2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLSD2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLSD3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLSD3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLSD" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLSD" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLSD" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLSD" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLSD" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLSD_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Start Date" ID="RAISECMLSDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLSDMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Start Date Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Stop Date -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Stop Date" ID="RAISECMLED" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLED" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLED" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLED" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLED2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLED2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLED3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLED3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLED" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLED" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLED" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLED" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLED" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLED_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Stop Date" ID="RAISECMLEDMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLEDMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Stop Date Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!--Query Ongoing -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Ongoing" ID="RAISECMLONGO" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLONGO" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseCMLONGO" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseCMLONGO" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLONGO2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseCMLONGO2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseCMLONGO3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseCMLONGO3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideCMLONGO" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondCMLONGO" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>

                                        <asp:TextBox ID="TextBoxRaiseCMLONGO" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                            TextMode="MultiLine">
                                        </asp:TextBox>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseCMLONGO" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">

                                        <asp:Button ID="QueryRaiseCMLONGO" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                            OnClick="QueryRaiseCMLONGO_Click" />


                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Ongoing" ID="RAISECMLONGOMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISECMLONGOMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Ongoing Field
                        </asp:Panel>
                    </div>
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
