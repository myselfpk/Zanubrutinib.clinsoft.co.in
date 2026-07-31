<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Medication.aspx.cs" Inherits="Study_Monitor_Visit1_Medication" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Study Monitor | Visit 1 | Medication</title>
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
        .auto-style2 {
            height: 55px;
            text-align: center;
            font-weight: normal;
        }

        .auto-style3 {
            height: 35px;
            text-align: center;
            background-color: #CCCCCC;
        }

        .auto-style4 {
            height: 40px;
            text-align: center;
            font-weight: normal;
        }

        .auto-style5 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 23%;
            left: 302px;
            top: -4px;
            padding-left: 15px;
            padding-right: 15px;
            height: 25px;
        }

        .auto-style6 {
            height: 40px;
            text-align: left;
            font-weight: normal;
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
              if (confirm("Do you want to Lock Medication page?")) {
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
            if (confirm("Do you want to SDV Medication page?")) {

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
            if (confirm("Do you want to Unlocked Medication page?")) {

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">



    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

    <div class="wrapper">

        <div class="content-wrapper">
            <div class="page-title">
                <div>
                    <h1><i class="fa fa-edit"></i>
                        <asp:Label runat="server" ID="lblPage">Medication</asp:Label></h1>

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
                                        <%--  <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center" colspan="3"><b>ECG – Rhythm</b></td>
                                        </tr>--%>
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="20%" />
                                            <col width="15%" />
                                            <col width="15%" />
                                            <col width="15%" />
                                            <col width="15%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Drugs</b></td>
                                            <td class="text-center"><b>Generic Name</b></td>
                                            <td>Dose</td>
                                            <td>Frequency</td>
                                            <td>Specify reason for not prescribing 1,2,3,4,5</td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI1OPT">1. Beta-blocker</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI1SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI1DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI1FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI1SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI1SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI1SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI2OPT">2. ACEI / ARB</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI2SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI2DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI2FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI2SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI2SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI2SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI3OPT">3. ARNI</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI3SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI3DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI3FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI3SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI3SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI3SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI4OPT">4. MRA</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI4SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI4DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI4FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI4SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI4SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI4SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI5OPT">5. SGLT2i</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI5SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI5DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI5FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI5SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" TextMode="MultiLine"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI5SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI5SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI6OPT">Diuretic</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI6SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI6DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI6FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI6SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI6SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI6SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI7OPT">Vericiguat</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI7SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI7DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI7FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI7SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI7SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI7SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI8OPT">Non-steroidal MRA (Finerenone)</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI8SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI8DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI8FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI8SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI8SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI8SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI9OPT">Ivabradine</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI9SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI9DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI9FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI9SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI9SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI9SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI10OPT">Digoxin</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI10SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI10DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI10FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI10SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI10SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI10SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI11OPT">Nitrates</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI11SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI11DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI11FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI11SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI11SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI11SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI12OPT">Other vasodilator</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI12SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI12DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI12FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI12SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI12SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI12SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI13OPT">Ca2+ channel blocker</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI13SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI13DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI13FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI13SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI13SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI13SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI14OPT">Heparin/ LMWH</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI14SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI14DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI14FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI14SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI14SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI14SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI15OPT">Oral anticoagulants</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI15SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI15DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI15FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI15SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI15SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI15SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI16OPT">Pulmonary vasodilator</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI16SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI16DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI16FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI16SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI16SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI16SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI17OPT">Antiplatelet</asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI17SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI17DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI17FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI17SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC" Visible="false"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI17SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI17SPRSN_Click" />

                                            </td>

                                        </tr>
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="20%" />
                                            <col width="15%" />
                                            <col width="15%" />
                                            <col width="15%" />
                                            <col width="15%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr class="section-header">
                                            <td colspan="6">If any other Medication are present, please provide details below:
                                            </td>
                                        </tr>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Drugs</b></td>
                                            <td class="text-center"><b>Generic Name</b></td>
                                            <td>Dose</td>
                                            <td>Frequency</td>
                                            <td>Specify Indication</td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI18OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI18SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI18DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI18FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI18SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI18SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI18SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI19OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI19SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI19DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI19FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI19SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI19SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI19SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI20OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI20SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI20DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI20FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI20SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI20SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI20SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI21OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI21SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI21DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI21FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI21SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI21SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI21SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI22OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI22SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI22DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI22FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI22SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI22SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI22SPRSN_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI23OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI23SPY" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI23DOSE" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI23FRQ" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TextBoxMEDI23SPRSN" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI23SPRSN" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI23SPRSN_Click" />

                                            </td>

                                        </tr>
                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="45%" />
                                            <col width="45%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr class="section-header">
    <td colspan="3">Intravenous drugs (Tick more than one if needed) (At baseline):
    </td>
</tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI1INDR">Epinephrine</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI1INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI1INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI1INDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI2INDR">Norepinephrine</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI2INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI2INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI2INDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI3INDR">Dopamine</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI3INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI3INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI3INDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI4INDR">Dobutamine</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI4INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI4INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI4INDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI5INDR">Milrinone</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI5INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI5INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI5INDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI6INDR">Levosimendan</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI6INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI6INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI6INDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI7INDR">NTG</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI7INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI7INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI7INDR_Click" />
                                            </td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td align="center" class="auto-style2">
                                                <asp:Label runat="server" ID="lblMEDI8INDR">Diuretic</asp:Label>

                                            </td>

                                            <td align="center" class="auto-style2">

                                                <asp:CheckBox ID="chkMEDI8INDR" class="form-control" runat="server"></asp:CheckBox>

                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryMEDI8INDR" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI8INDR_Click" />
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

    <asp:Label runat="server" ID="lblMEDI1SPY" Text="Beta-blocker generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI2SPY" Text="ACEI / ARB generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI3SPY" Text="ARNI generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI4SPY" Text="MRA generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI5SPY" Text="SGLT2i generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI6SPY" Text="Diuretic generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI7SPY" Text="Vericiguat generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI8SPY" Text="Non-steroidal MRA (Finerenone) generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI9SPY" Text="Ivabradine generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI10SPY" Text="Digoxin generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI11SPY" Text="Nitrates generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI12SPY" Text="Other vasodilator generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI13SPY" Text="Ca2+ channel blocker generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI14SPY" Text="Heparin/ LMWH generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI15SPY" Text="Oral anticoagulants generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI16SPY" Text="Pulmonary vasodilator generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI17SPY" Text="Antiplatelet generic name" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI1DOSE" Text="Beta-blocker Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI2DOSE" Text="ACEI / ARB Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI3DOSE" Text="ARNI Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI4DOSE" Text="MRA Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI5DOSE" Text="SGLT2i Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI6DOSE" Text="Diuretic Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI7DOSE" Text="Vericiguat Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI8DOSE" Text="Non-steroidal MRA (Finerenone) Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI9DOSE" Text="Ivabradine Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI10DOSE" Text="Digoxin Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI11DOSE" Text="Nitrates Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI12DOSE" Text="Other vasodilator Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI13DOSE" Text="Ca2+ channel blocker Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI14DOSE" Text="Heparin/ LMWH Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI15DOSE" Text="Oral anticoagulants Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI16DOSE" Text="Pulmonary vasodilator Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI17DOSE" Text="Antiplatelet Dose" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI1FRQ" Text="Beta-blocker Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI2FRQ" Text="ACEI / ARB Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI3FRQ" Text="ARNI Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI4FRQ" Text="MRA Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI5FRQ" Text="SGLT2i Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI6FRQ" Text="Diuretic Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI7FRQ" Text="Vericiguat Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI8FRQ" Text="Non-steroidal MRA (Finerenone) Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI9FRQ" Text="Ivabradine Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI10FRQ" Text="Digoxin Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI11FRQ" Text="Nitrates Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI12FRQ" Text="Other vasodilator Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI13FRQ" Text="Ca2+ channel blocker Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI14FRQ" Text="Heparin/ LMWH Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI15FRQ" Text="Oral anticoagulants Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI16FRQ" Text="Pulmonary vasodilator Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI17FRQ" Text="Antiplatelet Frequency" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI1SPRSN" Text="Beta-blocker" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI2SPRSN" Text="ACEI / ARB" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI3SPRSN" Text="ARNI" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI4SPRSN" Text="MRA" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI5SPRSN" Text="SGLT2i" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI6SPRSN" Text="Diuretic" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI7SPRSN" Text="Vericiguat" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI8SPRSN" Text="Non-steroidal MRA (Finerenone)" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI9SPRSN" Text="Ivabradine" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI10SPRSN" Text="Digoxin" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI11SPRSN" Text="Nitrates" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI12SPRSN" Text="Other vasodilator" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI13SPRSN" Text="Ca2+ channel blocker" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI14SPRSN" Text="Heparin/ LMWH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI15SPRSN" Text="Oral anticoagulants" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI16SPRSN" Text="Pulmonary vasodilator" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI17SPRSN" Text="Antiplatelet" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI18OPT" Text="Other Drugs No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI18SPY" Text="Other Generaic Name No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI18DOSE" Text="Other Dose No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI18FRQ" Text="Other Frequency No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI18SPRSN" Text="Other Specify Indication No 1" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI19OPT" Text="Other Drugs No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI19SPY" Text="Other Generaic Name No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI19DOSE" Text="Other Dose No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI19FRQ" Text="Other Frequency No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI19SPRSN" Text="Other Specify Indication No 2" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI20OPT" Text="Other Drugs No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI20SPY" Text="Other Generaic Name No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI20DOSE" Text="Other Dose No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI20FRQ" Text="Other Frequency No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI20SPRSN" Text="Other Specify Indication No 3" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI21OPT" Text="Other Drugs No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI21SPY" Text="Other Generaic Name No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI21DOSE" Text="Other Dose No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI21FRQ" Text="Other Frequency No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI21SPRSN" Text="Other Specify Indication No 4" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI22OPT" Text="Other Drugs No 5" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI22SPY" Text="Other Generaic Name No 5" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI22DOSE" Text="Other Dose No 5" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI22FRQ" Text="Other Frequency No 5" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI22SPRSN" Text="Other Specify Indication No 5" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI23OPT" Text="Other Drugs No 6" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI23SPY" Text="Other Generaic Name No 6" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI23DOSE" Text="Other Dose No 6" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI23FRQ" Text="Other Frequency No 6" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI23SPRSN" Text="Other Specify Indication No 6" Visible="false"></asp:Label>

    <!-- Note And Attachment :-->
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
                                        <asp:FileUpload ID="FileUploadADDAddAttachment" runat="server" ValidationGroup="AddAttachment" Height="40px" Width="450px" CssClass="paddingFile" /></td>


                                </tr>
                                <tr>
                                    <td align="center" colspan="2" class="auto-style2">
                                        <div align="center">
                                            <asp:Button ID="ADDAddAttachment" runat="server" Text="Add" Width="250px" ValidationGroup="AddAttachment" OnClick="ADDAddAttachment_Click" CssClass="btn btn-sm btn-success" />

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

        <!-- Query Beta-blocker-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Beta-blocker" ID="RAISEMEDI1SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI1SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI1SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI1SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI1SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI1SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI1SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI1SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI1SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI1SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI1SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="RAISEMEDI1SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI1SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Beta-blocker Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="RespondedMEDI1SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI1SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI1SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI1SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI1SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI1SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI1SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI1SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI1SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI1SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="CLOSEMEDI1SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI1SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI1SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Beta-blocker Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="CloseMEDI1SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI1SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI1SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI1SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI1SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI1SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI1SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI1SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI1SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI1SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="LockMEDI1SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI1SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI1SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI1SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI1SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI1SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI1SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI1SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI1SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query ACEI / ARB-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: ACEI / ARB" ID="RAISEMEDI2SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI2SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI2SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI2SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI2SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI2SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI2SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI2SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI2SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI2SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI2SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="RAISEMEDI2SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI2SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the ACEI / ARB Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="RespondedMEDI2SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI2SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI2SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI2SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI2SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI2SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI2SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI2SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI2SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI2SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="CLOSEMEDI2SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI2SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI2SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the ACEI / ARB Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="CloseMEDI2SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI2SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI2SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI2SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI2SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI2SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI2SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI2SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI2SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI2SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="LockMEDI2SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI2SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI2SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI2SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI2SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI2SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI2SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI2SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI2SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query ARNI-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: ARNI" ID="RAISEMEDI3SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI3SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI3SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI3SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI3SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI3SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI3SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI3SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI3SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI3SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI3SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="RAISEMEDI3SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI3SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the ARNI Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="RespondedMEDI3SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI3SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI3SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI3SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI3SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI3SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI3SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI3SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI3SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI3SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="CLOSEMEDI3SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI3SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI3SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the ARNI Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="CloseMEDI3SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI3SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI3SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI3SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI3SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI3SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI3SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI3SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI3SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI3SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="LockMEDI3SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI3SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI3SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI3SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI3SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI3SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI3SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI3SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI3SPRSNText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: MRA" ID="RAISEMEDI4SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI4SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI4SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI4SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI4SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI4SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI4SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI4SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI4SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI4SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI4SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="RAISEMEDI4SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI4SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the MRA Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="RespondedMEDI4SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI4SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI4SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI4SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI4SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI4SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI4SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI4SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI4SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI4SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="CLOSEMEDI4SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI4SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI4SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the MRA Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="CloseMEDI4SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI4SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI4SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI4SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI4SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI4SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI4SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI4SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI4SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI4SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="LockMEDI4SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI4SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI4SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI4SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI4SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI4SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI4SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI4SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI4SPRSNText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: SGLT2i" ID="RAISEMEDI5SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI5SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI5SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI5SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI5SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI5SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI5SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI5SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI5SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI5SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI5SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="RAISEMEDI5SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI5SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the SGLT2i Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="RespondedMEDI5SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI5SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI5SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI5SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI5SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI5SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI5SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI5SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI5SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI5SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="CLOSEMEDI5SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI5SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI5SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the SGLT2i Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="CloseMEDI5SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI5SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI5SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI5SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI5SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI5SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI5SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI5SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI5SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI5SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: SGLT2i" ID="LockMEDI5SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI5SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI5SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI5SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI5SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI5SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI5SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI5SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI5SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Diuretic-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Diuretic" ID="RAISEMEDI6SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI6SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI6SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI6SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI6SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI6SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI6SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI6SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI6SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI6SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI6SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="RAISEMEDI6SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI6SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Diuretic Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="RespondedMEDI6SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI6SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI6SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI6SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI6SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI6SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI6SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI6SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI6SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI6SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="CLOSEMEDI6SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI6SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI6SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Diuretic Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="CloseMEDI6SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI6SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI6SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI6SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI6SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI6SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI6SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI6SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI6SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI6SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="LockMEDI6SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI6SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI6SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI6SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI6SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI6SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI6SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI6SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI6SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Vericiguat-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Vericiguat" ID="RAISEMEDI7SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI7SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI7SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI7SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI7SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI7SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI7SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI7SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI7SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI7SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI7SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="RAISEMEDI7SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI7SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Vericiguat Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="RespondedMEDI7SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI7SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI7SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI7SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI7SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI7SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI7SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI7SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI7SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI7SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="CLOSEMEDI7SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI7SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI7SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Vericiguat Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="CloseMEDI7SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI7SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI7SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI7SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI7SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI7SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI7SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI7SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI7SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI7SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="LockMEDI7SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI7SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI7SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI7SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI7SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI7SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI7SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI7SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI7SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Non-steroidal MRA (Finerenone)-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="RAISEMEDI8SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI8SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI8SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI8SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI8SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI8SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI8SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI8SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI8SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI8SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI8SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="RAISEMEDI8SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI8SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Non-steroidal MRA (Finerenone) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="RespondedMEDI8SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI8SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI8SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI8SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI8SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI8SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI8SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI8SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI8SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI8SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="CLOSEMEDI8SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI8SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI8SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Non-steroidal MRA (Finerenone) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="CloseMEDI8SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI8SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI8SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI8SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI8SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI8SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI8SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI8SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI8SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI8SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="LockMEDI8SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI8SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI8SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI8SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI8SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI8SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI8SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI8SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI8SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Ivabradine-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Ivabradine" ID="RAISEMEDI9SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI9SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI9SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI9SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI9SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI9SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI9SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI9SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI9SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI9SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI9SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="RAISEMEDI9SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI9SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Ivabradine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="RespondedMEDI9SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI9SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI9SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI9SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI9SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI9SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI9SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI9SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI9SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI9SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="CLOSEMEDI9SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI9SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI9SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Ivabradine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="CloseMEDI9SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI9SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI9SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI9SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI9SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI9SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI9SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI9SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI9SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI9SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="LockMEDI9SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI9SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI9SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI9SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI9SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI9SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI9SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI9SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI9SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Digoxin-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Digoxin" ID="RAISEMEDI10SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI10SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI10SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI10SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI10SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI10SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI10SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI10SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI10SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI10SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI10SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Digoxin" ID="RAISEMEDI10SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI10SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Digoxin Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Digoxin" ID="RespondedMEDI10SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI10SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI10SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI10SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI10SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI10SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI10SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI10SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI10SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI10SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Digoxin" ID="CLOSEMEDI10SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI10SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI10SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Digoxin Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Digoxin" ID="CloseMEDI10SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI10SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI10SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI10SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI10SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI10SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI10SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI10SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI10SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI10SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Digoxin" ID="LockMEDI10SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI10SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI10SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI10SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI10SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI10SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI10SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI10SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI10SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Nitrates-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Nitrates" ID="RAISEMEDI11SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI11SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI11SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI11SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI11SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI11SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI11SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI11SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI11SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI11SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI11SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Nitrates" ID="RAISEMEDI11SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI11SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Nitrates Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Nitrates" ID="RespondedMEDI11SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI11SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI11SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI11SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI11SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI11SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI11SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI11SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI11SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI11SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Nitrates" ID="CLOSEMEDI11SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI11SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI11SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Nitrates Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Nitrates" ID="CloseMEDI11SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI11SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI11SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI11SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI11SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI11SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI11SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI11SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI11SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI11SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Nitrates" ID="LockMEDI11SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI11SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI11SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI11SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI11SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI11SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI11SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI11SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI11SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Other vasodilator-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Other vasodilator" ID="RAISEMEDI12SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI12SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI12SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI12SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI12SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI12SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI12SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI12SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI12SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI12SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI12SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other vasodilator" ID="RAISEMEDI12SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI12SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Other vasodilator Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other vasodilator" ID="RespondedMEDI12SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI12SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI12SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI12SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI12SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI12SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI12SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI12SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI12SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI12SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other vasodilator" ID="CLOSEMEDI12SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI12SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI12SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Other vasodilator Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Other vasodilator" ID="CloseMEDI12SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI12SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI12SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI12SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI12SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI12SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI12SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI12SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI12SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI12SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Other vasodilator" ID="LockMEDI12SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI12SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI12SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI12SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI12SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI12SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI12SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI12SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI12SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Ca2+ channel blocker-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Ca2+ channel blocker" ID="RAISEMEDI13SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI13SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI13SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI13SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI13SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI13SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI13SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI13SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI13SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI13SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI13SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ca2+ channel blocker" ID="RAISEMEDI13SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI13SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Ca2+ channel blocker Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Ca2+ channel blocker" ID="RespondedMEDI13SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI13SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI13SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI13SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI13SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI13SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI13SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI13SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI13SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI13SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ca2+ channel blocker" ID="CLOSEMEDI13SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI13SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI13SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Ca2+ channel blocker Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Ca2+ channel blocker" ID="CloseMEDI13SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI13SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI13SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI13SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI13SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI13SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI13SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI13SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI13SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI13SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ca2+ channel blocker" ID="LockMEDI13SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI13SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI13SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI13SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI13SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI13SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI13SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI13SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI13SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Heparin/ LMWH-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Heparin/ LMWH" ID="RAISEMEDI14SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI14SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI14SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI14SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI14SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI14SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI14SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI14SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI14SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI14SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI14SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Heparin/ LMWH" ID="RAISEMEDI14SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI14SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Heparin/ LMWH Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Heparin/ LMWH" ID="RespondedMEDI14SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI14SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI14SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI14SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI14SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI14SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI14SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI14SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI14SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI14SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Heparin/ LMWH" ID="CLOSEMEDI14SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI14SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI14SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Heparin/ LMWH Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Heparin/ LMWH" ID="CloseMEDI14SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI14SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI14SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI14SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI14SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI14SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI14SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI14SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI14SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI14SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Heparin/ LMWH" ID="LockMEDI14SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI14SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI14SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI14SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI14SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI14SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI14SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI14SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI14SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Oral anticoagulants-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Oral anticoagulants" ID="RAISEMEDI15SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI15SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI15SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI15SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI15SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI15SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI15SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI15SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI15SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI15SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI15SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Oral anticoagulants" ID="RAISEMEDI15SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI15SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Oral anticoagulants Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Oral anticoagulants" ID="RespondedMEDI15SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI15SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI15SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI15SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI15SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI15SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI15SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI15SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI15SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI15SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Oral anticoagulants" ID="CLOSEMEDI15SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI15SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI15SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Oral anticoagulants Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Oral anticoagulants" ID="CloseMEDI15SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI15SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI15SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI15SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI15SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI15SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI15SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI15SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI15SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI15SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Oral anticoagulants" ID="LockMEDI15SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI15SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI15SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI15SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI15SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI15SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI15SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI15SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI15SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

       <!-- Query Pulmonary vasodilator-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Pulmonary vasodilator" ID="RAISEMEDI16SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI16SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI16SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI16SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI16SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI16SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI16SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI16SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI16SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI16SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI16SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Pulmonary vasodilator" ID="RAISEMEDI16SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI16SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel16" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Pulmonary vasodilator Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Pulmonary vasodilator" ID="RespondedMEDI16SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI16SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI16SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI16SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI16SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI16SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI16SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI16SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI16SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI16SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Pulmonary vasodilator" ID="CLOSEMEDI16SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI16SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI16SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Pulmonary vasodilator Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Pulmonary vasodilator" ID="CloseMEDI16SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI16SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI16SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI16SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI16SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI16SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI16SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI16SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI16SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI16SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Pulmonary vasodilator" ID="LockMEDI16SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI16SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI16SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI16SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI16SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI16SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI16SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI16SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI16SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Antiplatelet-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Antiplatelet" ID="RAISEMEDI17SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI17SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI17SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI17SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI17SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI17SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI17SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI17SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI17SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI17SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI17SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Antiplatelet" ID="RAISEMEDI17SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI17SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel17" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Antiplatelet Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Antiplatelet" ID="RespondedMEDI17SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI17SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI17SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI17SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI17SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI17SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI17SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI17SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI17SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI17SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Antiplatelet" ID="CLOSEMEDI17SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI17SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI17SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Antiplatelet Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Antiplatelet" ID="CloseMEDI17SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI17SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI17SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI17SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI17SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI17SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI17SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI17SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI17SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI17SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Antiplatelet" ID="LockMEDI17SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI17SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI17SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI17SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI17SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI17SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI17SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI17SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI17SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Details of Other Drugs No 1-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 1" ID="RAISEMEDI18SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI18SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI18SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI18SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI18SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI18SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI18SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI18SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI18SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI18SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI18SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="RAISEMEDI18SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI18SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel18" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="RespondedMEDI18SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI18SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI18SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI18SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI18SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI18SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI18SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI18SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI18SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI18SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="CLOSEMEDI18SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI18SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI18SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="CloseMEDI18SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI18SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI18SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI18SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI18SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI18SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI18SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI18SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI18SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI18SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="LockMEDI18SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI18SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI18SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI18SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI18SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI18SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI18SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI18SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI18SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Details of Other Drugs No 2-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 2" ID="RAISEMEDI19SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI19SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI19SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI19SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI19SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI19SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI19SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI19SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI19SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI19SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI19SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="RAISEMEDI19SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI19SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel19" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="RespondedMEDI19SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI19SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI19SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI19SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI19SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI19SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI19SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI19SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI19SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI19SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="CLOSEMEDI19SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI19SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI19SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="CloseMEDI19SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI19SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI19SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI19SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI19SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI19SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI19SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI19SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI19SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI19SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="LockMEDI19SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI19SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI19SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI19SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI19SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI19SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI19SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI19SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI19SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Details of Other Drugs No 3-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 3" ID="RAISEMEDI20SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI20SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI20SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI20SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI20SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI20SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI20SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI20SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI20SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI20SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI20SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="RAISEMEDI20SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI20SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel20" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="RespondedMEDI20SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI20SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI20SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI20SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI20SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI20SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI20SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI20SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI20SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI20SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="CLOSEMEDI20SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI20SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI20SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="CloseMEDI20SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI20SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI20SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI20SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI20SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI20SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI20SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI20SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI20SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI20SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="LockMEDI20SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI20SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI20SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI20SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI20SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI20SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI20SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI20SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI20SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Details of Other Drugs No 4-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 4" ID="RAISEMEDI21SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI21SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI21SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI21SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI21SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI21SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI21SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI21SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI21SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI21SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI21SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="RAISEMEDI21SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI21SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel21" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="RespondedMEDI21SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI21SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI21SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI21SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI21SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI21SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI21SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI21SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI21SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI21SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="CLOSEMEDI21SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI21SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI21SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="CloseMEDI21SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI21SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI21SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI21SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI21SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI21SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI21SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI21SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI21SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI21SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="LockMEDI21SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI21SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI21SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI21SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI21SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI21SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI21SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI21SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI21SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Details of Other Drugs No 5-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 5" ID="RAISEMEDI22SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI22SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI22SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI22SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI22SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI22SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI22SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI22SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI22SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI22SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI22SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="RAISEMEDI22SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI22SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel22" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 5 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="RespondedMEDI22SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI22SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI22SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI22SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI22SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI22SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI22SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI22SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI22SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI22SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="CLOSEMEDI22SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI22SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI22SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 5 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="CloseMEDI22SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI22SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI22SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI22SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI22SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI22SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI22SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI22SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI22SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI22SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="LockMEDI22SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI22SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI22SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI22SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI22SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI22SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI22SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI22SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI22SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Details of Other Drugs No 6-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 6" ID="RAISEMEDI23SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI23SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI23SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI23SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI23SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI23SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI23SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI23SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI23SPRSN"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI23SPRSN" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI23SPRSN_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 6" ID="RAISEMEDI23SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI23SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel23" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 6 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 6" ID="RespondedMEDI23SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI23SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI23SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI23SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI23SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI23SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI23SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI23SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI23SPRSNClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI23SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 6" ID="CLOSEMEDI23SPRSNMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI23SPRSNMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI23SPRSNMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 6 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 6" ID="CloseMEDI23SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI23SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI23SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI23SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI23SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI23SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI23SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI23SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI23SPRSN" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI23SPRSN_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 6" ID="LockMEDI23SPRSN" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI23SPRSN" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI23SPRSN" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI23SPRSN" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI23SPRSN2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI23SPRSN2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI23SPRSN3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI23SPRSN3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI23SPRSNText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Epinephrine-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Epinephrine" ID="RAISEMEDI1INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI1INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI1INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI1INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI1INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI1INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI1INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI1INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI1INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI1INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI1INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Epinephrine" ID="RAISEMEDI1INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI1INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel24" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Epinephrine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Epinephrine" ID="RespondedMEDI1INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI1INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI1INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI1INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI1INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI1INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI1INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI1INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI1INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI1INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Epinephrine" ID="CLOSEMEDI1INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI1INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI1INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Epinephrine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Epinephrine" ID="CloseMEDI1INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI1INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI1INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI1INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI1INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI1INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI1INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI1INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI1INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI1INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Epinephrine" ID="LockMEDI1INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI1INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI1INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI1INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI1INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI1INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI1INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI1INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI1INDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Norepinephrine-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Norepinephrine" ID="RAISEMEDI2INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI2INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI2INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI2INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI2INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI2INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI2INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI2INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI2INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI2INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI2INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Norepinephrine" ID="RAISEMEDI2INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI2INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel25" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Norepinephrine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Norepinephrine" ID="RespondedMEDI2INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI2INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI2INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI2INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI2INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI2INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI2INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI2INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI2INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI2INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Norepinephrine" ID="CLOSEMEDI2INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI2INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI2INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Norepinephrine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Norepinephrine" ID="CloseMEDI2INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI2INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI2INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI2INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI2INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI2INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI2INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI2INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI2INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI2INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Norepinephrine" ID="LockMEDI2INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI2INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI2INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI2INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI2INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI2INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI2INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI2INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI2INDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Dopamine-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Dopamine" ID="RAISEMEDI3INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI3INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI3INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI3INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI3INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI3INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI3INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI3INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI3INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI3INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI3INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dopamine" ID="RAISEMEDI3INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI3INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel26" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Dopamine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dopamine" ID="RespondedMEDI3INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI3INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI3INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI3INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI3INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI3INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI3INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI3INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI3INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI3INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dopamine" ID="CLOSEMEDI3INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI3INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI3INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Dopamine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dopamine" ID="CloseMEDI3INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI3INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI3INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI3INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI3INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI3INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI3INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI3INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI3INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI3INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dopamine" ID="LockMEDI3INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI3INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI3INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI3INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI3INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI3INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI3INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI3INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI3INDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Dobutamine-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Dobutamine" ID="RAISEMEDI4INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI4INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI4INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI4INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI4INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI4INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI4INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI4INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI4INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI4INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI4INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dobutamine" ID="RAISEMEDI4INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI4INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel27" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Dobutamine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dobutamine" ID="RespondedMEDI4INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI4INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI4INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI4INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI4INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI4INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI4INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI4INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI4INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI4INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dobutamine" ID="CLOSEMEDI4INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI4INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI4INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Dobutamine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Dobutamine" ID="CloseMEDI4INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI4INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI4INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI4INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI4INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI4INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI4INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI4INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI4INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI4INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Dobutamine" ID="LockMEDI4INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI4INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI4INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI4INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI4INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI4INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI4INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI4INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI4INDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Milrinone-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Milrinone" ID="RAISEMEDI5INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI5INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI5INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI5INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI5INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI5INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI5INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI5INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI5INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI5INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI5INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Milrinone" ID="RAISEMEDI5INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI5INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel28" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Milrinone Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Milrinone" ID="RespondedMEDI5INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI5INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI5INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI5INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI5INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI5INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI5INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI5INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI5INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI5INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Milrinone" ID="CLOSEMEDI5INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI5INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI5INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Milrinone Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Milrinone" ID="CloseMEDI5INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI5INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI5INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI5INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI5INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI5INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI5INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI5INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI5INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI5INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Milrinone" ID="LockMEDI5INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI5INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI5INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI5INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI5INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI5INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI5INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI5INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI5INDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Levosimendan-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Levosimendan" ID="RAISEMEDI6INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI6INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI6INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI6INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI6INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI6INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI6INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI6INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI6INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI6INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI6INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Levosimendan" ID="RAISEMEDI6INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI6INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel29" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Levosimendan Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Levosimendan" ID="RespondedMEDI6INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI6INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI6INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI6INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI6INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI6INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI6INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI6INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI6INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI6INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Levosimendan" ID="CLOSEMEDI6INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI6INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI6INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Levosimendan Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Levosimendan" ID="CloseMEDI6INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI6INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI6INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI6INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI6INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI6INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI6INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI6INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI6INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI6INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Levosimendan" ID="LockMEDI6INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI6INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI6INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI6INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI6INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI6INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI6INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI6INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI6INDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query NTG-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: NTG" ID="RAISEMEDI7INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI7INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI7INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI7INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI7INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI7INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI7INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI7INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI7INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI7INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI7INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: NTG" ID="RAISEMEDI7INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI7INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel30" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the NTG Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: NTG" ID="RespondedMEDI7INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI7INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI7INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI7INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI7INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI7INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI7INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI7INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI7INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI7INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: NTG" ID="CLOSEMEDI7INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI7INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI7INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the NTG Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: NTG" ID="CloseMEDI7INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI7INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI7INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI7INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI7INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI7INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI7INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI7INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI7INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI7INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: NTG" ID="LockMEDI7INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI7INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI7INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI7INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI7INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI7INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI7INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI7INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI7INDRText" runat="server" BorderStyle="Solid" >
                      Query Cannot be Raised as Page is Locked
                            </asp:Panel>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>

        <!-- Query Diuretic-->
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel  HeaderText="Raise Query: Diuretic" ID="RAISEMEDI8INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI8INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI8INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI8INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI8INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI8INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI8INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI8INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        <br />
                       &nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxRaiseMEDI8INDR"  runat="server" Height="50" Width="200" TextMode="MultiLine"></asp:TextBox>
                       
                         <br />
                         <div style="margin-top: 10px">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="QueryRaiseMEDI8INDR" runat="server" Text="Raise Query" OnClick="QueryRaiseMEDI8INDR_Click"/>
                       </div>
                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="RAISEMEDI8INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI8INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel31" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Diuretic Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="RespondedMEDI8INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI8INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI8INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI8INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI8INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI8INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI8INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI8INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                          <br />
                        
                         <div style="margin-top: 10px">
                        <asp:Button ID="RespondedMEDI8INDRClose" runat="server" Text="Close Query"   OnClick="CloseQueryMEDI8INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="CLOSEMEDI8INDRMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI8INDRMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI8INDRMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Diuretic Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="CloseMEDI8INDR" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI8INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI8INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI8INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI8INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI8INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI8INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI8INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        
                         <div style="margin-top: 10px">
                       
                              <asp:Button ID="ButtonCloseMEDI8INDR" runat="server" Text="Reraise Query"   OnClick="SubmitReRaiseMEDI8INDR_Click" />
                       </div>

                    </div>
                     <br />
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="LockMEDI8INDR" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI8INDR" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI8INDR" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI8INDR" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI8INDR2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI8INDR2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI8INDR3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI8INDR3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI8INDRText" runat="server" BorderStyle="Solid" >
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
