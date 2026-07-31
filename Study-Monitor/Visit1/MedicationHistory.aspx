<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MedicationHistory.aspx.cs" Inherits="Study_Monitor_Visit1_MedicationHistory" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Study Monitor | Visit 1 | Medication History</title>
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
       function Confirm() {
           var validated = Page_ClientValidate('IC');
           if (validated) {
               var confirm_value = document.createElement("INPUT");

               confirm_value.type = "hidden";
               confirm_value.name = "confirm_value";
               if (confirm("Do you want to Lock Medication History page?")) {
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
            if (confirm("Do you want to SDV Medication History page?")) {

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
            if (confirm("Do you want to Unlocked Medication History page?")) {

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
                        <asp:Label runat="server" ID="lblPage">Medication History</asp:Label></h1>

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
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>

                                            <col width="20%" />
                                            <col width="10%" />
                                            <col width="30%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                        </colgroup>

                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Drug Class</b></td>
                                            <td class="text-center"><b>Yes/No</b></td>
                                            <td class="text-center"><b>Drug Name</b></td>
                                            <td class="text-center"><b>Dose</b></td>
                                            <td class="text-center"><b>Frequency</b></td>
                                            <td class="text-center"><b>Duration (in Months)</b></td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMH1DRUG">Diuretics</asp:Label>
                                            </td>
                                            <td>

                                                <asp:DropDownList ID="RadioButtonListMH1OPT" class="form-control" Height="45px" Width="300px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH1NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH1DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH1FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH1DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH1DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH1DURA_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMH2DRUG">ACEI/ARB</asp:Label>
                                            </td>
                                            <td>

                                                <asp:DropDownList ID="RadioButtonListMH2OPT" class="form-control" Height="45px" Width="300px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH2NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH2DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH2FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH2DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH2DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH2DURA_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMH3DRUG">MRA</asp:Label>
                                            </td>
                                            <td>

                                                <asp:DropDownList ID="RadioButtonListMH3OPT" class="form-control" Height="45px" Width="300px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH3NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH3DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH3FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH3DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH3DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH3DURA_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMH4DRUG">SGLT2i</asp:Label>
                                            </td>
                                            <td>

                                                <asp:DropDownList ID="RadioButtonListMH4OPT" class="form-control" Height="45px" Width="300px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH4NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH4DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH4FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH4DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH4DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH4DURA_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMH5DRUG">Beta-blocker</asp:Label>
                                            </td>
                                            <td>

                                                <asp:DropDownList ID="RadioButtonListMH5OPT" class="form-control" Height="45px" Width="300px" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH5NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH5DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH5FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH5DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH5DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH5DURA_Click" /></td>

                                        </tr>
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>

                                            <col width="30%" />
                                            <col width="30%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                        </colgroup>
                                          <tr class="section-header">
      <td colspan="6">If any other Medication History are present, please provide details below:
      </td>
  </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Drug Class</b></td>
                                            <td class="text-center"><b>Drug Name</b></td>
                                            <td class="text-center"><b>Dose</b></td>
                                            <td class="text-center"><b>Frequency</b></td>
                                            <td class="text-center"><b>Duration (in Months)</b></td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>

                                                <asp:TextBox ID="TextBoxMH6DRUG" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH6NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH6DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH6FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH6DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH6DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH6DURA_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>

                                                <asp:TextBox ID="TextBoxMH7DRUG" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH7NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH7DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH7FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH7DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH7DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH7DURA_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>

                                                <asp:TextBox ID="TextBoxMH8DRUG" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH8NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH8DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH8FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH8DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH8DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH8DURA_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>

                                                <asp:TextBox ID="TextBoxMH9DRUG" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH9NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH9DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH9FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH9DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH9DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH9DURA_Click" /></td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>

                                                <asp:TextBox ID="TextBoxMH10DRUG" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH10NAME" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH10DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH10FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMH10DURA" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMH10DURA" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMH10DURA_Click" /></td>

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

    <asp:Label runat="server" ID="lblMH1DURA" Text="Diuretics" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH2DURA" Text="ACEI/ARB" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH3DURA" Text="MRA" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH4DURA" Text="SGLT2i" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH5DURA" Text="Beta-blocker" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH6DURA" Text="Other Medication History No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH7DURA" Text="Other Medication History No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH8DURA" Text="Other Medication History No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH9DURA" Text="Other Medication History No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMH10DURA" Text="Other Medication History No 5" Visible="false"></asp:Label>

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

        <!-- Query Diuretics Duration-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Diuretics Duration" ID="RAISEMH1DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH1DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH1DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH1DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH1DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH1DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH1DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH1DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH1DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH1DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH1DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretics Duration" ID="RAISEMH1DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH1DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Diuretics Duration Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretics Duration" ID="RespondedMH1DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH1DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH1DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH1DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH1DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH1DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH1DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH1DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH1DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH1DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretics Duration" ID="CLOSEMH1DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH1DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH1DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Diuretics Duration Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretics Duration" ID="CloseMH1DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH1DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH1DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH1DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH1DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH1DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH1DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH1DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH1DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH1DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretics Duration" ID="LockMH1DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH1DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH1DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH1DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH1DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH1DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH1DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH1DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH1DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query ACEI/ARB-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: ACEI/ARB" ID="RAISEMH2DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH2DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH2DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH2DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH2DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH2DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH2DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH2DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH2DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH2DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH2DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI/ARB" ID="RAISEMH2DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH2DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the ACEI/ARB Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ACEI/ARB" ID="RespondedMH2DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH2DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH2DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH2DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH2DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH2DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH2DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH2DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH2DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH2DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI/ARB" ID="CLOSEMH2DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH2DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH2DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the ACEI/ARB Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ACEI/ARB" ID="CloseMH2DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH2DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH2DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH2DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH2DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH2DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH2DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH2DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH2DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH2DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI/ARB" ID="LockMH2DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH2DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH2DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH2DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH2DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH2DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH2DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH2DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH2DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query MRA-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: MRA" ID="RAISEMH3DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH3DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH3DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH3DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH3DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH3DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH3DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH3DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH3DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH3DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH3DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="RAISEMH3DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH3DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the MRA Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="RespondedMH3DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH3DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH3DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH3DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH3DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH3DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH3DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH3DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH3DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH3DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="CLOSEMH3DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH3DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH3DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the MRA Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="CloseMH3DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH3DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH3DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH3DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH3DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH3DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH3DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH3DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH3DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH3DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="LockMH3DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH3DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH3DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH3DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH3DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH3DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH3DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH3DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH3DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query SGLT2i-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: SGLT2i" ID="RAISEMH4DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH4DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH4DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH4DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH4DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH4DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH4DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH4DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH4DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH4DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH4DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="RAISEMH4DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH4DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the SGLT2i Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="RespondedMH4DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH4DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH4DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH4DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH4DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH4DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH4DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH4DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH4DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH4DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="CLOSEMH4DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH4DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH4DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the SGLT2i Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="CloseMH4DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH4DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH4DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH4DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH4DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH4DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH4DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH4DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH4DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH4DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="LockMH4DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH4DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH4DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH4DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH4DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH4DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH4DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH4DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH4DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Beta-blocker-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Beta-blocker" ID="RAISEMH5DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH5DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH5DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH5DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH5DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH5DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH5DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH5DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH5DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH5DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH5DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="RAISEMH5DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH5DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Beta-blocker Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="RespondedMH5DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH5DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH5DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH5DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH5DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH5DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH5DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH5DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH5DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH5DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="CLOSEMH5DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH5DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH5DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Beta-blocker Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="CloseMH5DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH5DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH5DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH5DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH5DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH5DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH5DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH5DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH5DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH5DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="LockMH5DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH5DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH5DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH5DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH5DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH5DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH5DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH5DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH5DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Medication History No 1-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Medication History No 1" ID="RAISEMH6DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH6DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH6DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH6DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH6DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH6DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH6DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH6DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH6DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH6DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH6DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 1" ID="RAISEMH6DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH6DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Medication History No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 1" ID="RespondedMH6DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH6DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH6DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH6DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH6DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH6DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH6DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH6DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH6DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH6DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 1" ID="CLOSEMH6DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH6DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH6DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Medication History No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 1" ID="CloseMH6DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH6DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH6DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH6DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH6DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH6DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH6DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH6DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH6DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH6DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 1" ID="LockMH6DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH6DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH6DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH6DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH6DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH6DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH6DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH6DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH6DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Medication History No 2-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Medication History No 2" ID="RAISEMH7DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH7DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH7DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH7DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH7DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH7DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH7DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH7DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH7DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH7DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH7DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 2" ID="RAISEMH7DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH7DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Medication History No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 2" ID="RespondedMH7DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH7DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH7DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH7DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH7DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH7DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH7DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH7DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH7DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH7DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 2" ID="CLOSEMH7DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH7DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH7DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Medication History No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 2" ID="CloseMH7DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH7DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH7DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH7DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH7DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH7DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH7DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH7DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH7DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH7DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 2" ID="LockMH7DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH7DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH7DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH7DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH7DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH7DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH7DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH7DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH7DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Medication History No 3-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Medication History No 3" ID="RAISEMH8DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH8DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH8DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH8DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH8DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH8DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH8DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH8DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH8DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH8DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH8DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 3" ID="RAISEMH8DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH8DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Medication History No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 3" ID="RespondedMH8DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH8DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH8DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH8DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH8DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH8DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH8DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH8DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH8DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH8DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 3" ID="CLOSEMH8DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH8DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH8DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Medication History No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 3" ID="CloseMH8DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH8DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH8DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH8DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH8DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH8DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH8DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH8DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH8DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH8DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 3" ID="LockMH8DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH8DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH8DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH8DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH8DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH8DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH8DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH8DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH8DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Medication History No 4-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Medication History No 4" ID="RAISEMH9DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH9DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH9DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH9DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH9DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH9DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH9DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH9DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH9DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH9DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH9DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 4" ID="RAISEMH9DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH9DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Medication History No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 4" ID="RespondedMH9DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH9DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH9DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH9DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH9DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH9DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH9DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH9DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH9DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH9DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 4" ID="CLOSEMH9DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH9DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH9DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Medication History No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 4" ID="CloseMH9DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH9DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH9DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH9DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH9DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH9DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH9DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH9DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH9DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH9DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 4" ID="LockMH9DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH9DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH9DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH9DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH9DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH9DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH9DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH9DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH9DURAText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other Medication History No 5-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other Medication History No 5" ID="RAISEMH10DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH10DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMH10DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMH10DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMH10DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMH10DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMH10DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMH10DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMH10DURA"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMH10DURA" runat="server" Text="Raise Query" OnClick="QueryRaiseMH10DURA_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 5" ID="RAISEMH10DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMH10DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other Medication History No 5 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 5" ID="RespondedMH10DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMH10DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMH10DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMH10DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMH10DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMH10DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMH10DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMH10DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMH10DURAClose" runat="server" Text="Close Query"   OnClick="CloseQueryMH10DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 5" ID="CLOSEMH10DURAMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMH10DURAMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMH10DURAMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other Medication History No 5 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 5" ID="CloseMH10DURA" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMH10DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMH10DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMH10DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMH10DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMH10DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMH10DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMH10DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMH10DURA" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMH10DURA_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other Medication History No 5" ID="LockMH10DURA" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMH10DURA" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMH10DURA" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMH10DURA" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMH10DURA2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMH10DURA2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMH10DURA3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMH10DURA3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMH10DURAText" runat="server" BorderStyle="Solid" >
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
