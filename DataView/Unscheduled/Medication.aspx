<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Medication.aspx.cs" Inherits="DataView_Unscheduled_Medication" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | DataView | Visit Unscheduled | Medication</title>
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
                        <li>DataView</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Visit Unscheduled</asp:LinkButton></li>
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
                                            <col width="20%" />
                                            <col width="20%" />
                                            <col width="20%" />
                                            <col width="10%" />
                                        </colgroup>
                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Drugs</b></td>
                                            <td class="text-center"><b>Generic Name</b></td>
                                            <td>Dose</td>
                                            <td>Frequency</td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI1OPT">Beta-blocker</asp:Label>
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
                                                <asp:ImageButton ID="ImageQueryMEDI1FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI1FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI2OPT">ACEI / ARB</asp:Label>
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
                                                <asp:ImageButton ID="ImageQueryMEDI2FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI2FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI3OPT">ARNI</asp:Label>
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
                                                <asp:ImageButton ID="ImageQueryMEDI3FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI3FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI4OPT">MRA</asp:Label>
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
                                                <asp:ImageButton ID="ImageQueryMEDI4FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI4FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI5OPT">Diuretic</asp:Label>
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
                                                <asp:ImageButton ID="ImageQueryMEDI5FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI5FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI6OPT">Non-steroidal MRA (Finerenone)</asp:Label>
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
                                                <asp:ImageButton ID="ImageQueryMEDI6FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI6FRQ_Click" />

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
                                                <asp:ImageButton ID="ImageQueryMEDI7FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI7FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblMEDI8OPT">Ivabradine</asp:Label>
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
                                                <asp:ImageButton ID="ImageQueryMEDI8FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI8FRQ_Click" />

                                            </td>

                                        </tr>

                                    </table>
                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>
                                            <col width="20%" />
                                            <col width="20%" />
                                            <col width="20%" />
                                            <col width="20%" />
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
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI9OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
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
                                                <asp:ImageButton ID="ImageQueryMEDI9FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI9FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI10OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
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
                                                <asp:ImageButton ID="ImageQueryMEDI10FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI10FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI11OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
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
                                                <asp:ImageButton ID="ImageQueryMEDI11FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI11FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI12OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
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
                                                <asp:ImageButton ID="ImageQueryMEDI12FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI12FRQ_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:TextBox ID="TextBoxMEDI13OPT" runat="server" class="form-control" Height="45px" Width="90%" ValidationGroup="IC"></asp:TextBox>
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
                                                <asp:ImageButton ID="ImageQueryMEDI13FRQ" Height="25px" Width="25px" runat="server" OnClick="ImageQueryMEDI13FRQ_Click" />

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

    <asp:Label runat="server" ID="lblMEDI1SPY" Text="Beta-blocker generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI2SPY" Text="ACEI / ARB generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI3SPY" Text="ARNI generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI4SPY" Text="MRA generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI5SPY" Text="Diuretic generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI6SPY" Text="Non-steroidal MRA (Finerenone) generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI7SPY" Text="Vericiguat generic name" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI8SPY" Text="Ivabradine generic name" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI1DOSE" Text="Beta-blocker Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI2DOSE" Text="ACEI / ARB Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI3DOSE" Text="ARNI Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI4DOSE" Text="MRA Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI5DOSE" Text="Diuretic Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI6DOSE" Text="Non-steroidal MRA (Finerenone) Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI7DOSE" Text="Vericiguat Dose" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI8DOSE" Text="Ivabradine Dose" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI1FRQ" Text="Beta-blocker Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI2FRQ" Text="ACEI / ARB Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI3FRQ" Text="ARNI Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI4FRQ" Text="MRA Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI5FRQ" Text="Diuretic Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI6FRQ" Text="Non-steroidal MRA (Finerenone) Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI7FRQ" Text="Vericiguat Frequency" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI8FRQ" Text="Ivabradine Frequency" Visible="false"></asp:Label>


    <asp:Label runat="server" ID="lblMEDI9OPT" Text="Other Drugs No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI9SPY" Text="Other Generaic Name No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI9DOSE" Text="Other Dose No 1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI9FRQ" Text="Other Frequency No 1" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI10OPT" Text="Other Drugs No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI10SPY" Text="Other Generaic Name No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI10DOSE" Text="Other Dose No 2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI10FRQ" Text="Other Frequency No 2" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI11OPT" Text="Other Drugs No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI11SPY" Text="Other Generaic Name No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI11DOSE" Text="Other Dose No 3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI11FRQ" Text="Other Frequency No 3" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI12OPT" Text="Other Drugs No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI12SPY" Text="Other Generaic Name No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI12DOSE" Text="Other Dose No 4" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI12FRQ" Text="Other Frequency No 4" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMEDI13OPT" Text="Other Drugs No 5" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI13SPY" Text="Other Generaic Name No 5" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI13DOSE" Text="Other Dose No 5" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblMEDI13FRQ" Text="Other Frequency No 5" Visible="false"></asp:Label>

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
          <ASPP:PopupPanel  HeaderText="Raise Query: Beta-blocker" ID="RAISEMEDI1FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI1FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI1FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI1FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI1FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI1FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI1FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI1FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="RAISEMEDI1FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI1FRQMSG" runat="server">
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
          <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="RespondedMEDI1FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI1FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI1FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI1FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI1FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI1FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI1FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI1FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="CLOSEMEDI1FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI1FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI1FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Beta-blocker Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="CloseMEDI1FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI1FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI1FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI1FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI1FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI1FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI1FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI1FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Beta-blocker" ID="LockMEDI1FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI1FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI1FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI1FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI1FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI1FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI1FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI1FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI1FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: ACEI / ARB" ID="RAISEMEDI2FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI2FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI2FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI2FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI2FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI2FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI2FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI2FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="RAISEMEDI2FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI2FRQMSG" runat="server">
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
          <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="RespondedMEDI2FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI2FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI2FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI2FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI2FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI2FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI2FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI2FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="CLOSEMEDI2FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI2FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI2FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the ACEI / ARB Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="CloseMEDI2FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI2FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI2FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI2FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI2FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI2FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI2FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI2FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ACEI / ARB" ID="LockMEDI2FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI2FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI2FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI2FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI2FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI2FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI2FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI2FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI2FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: ARNI" ID="RAISEMEDI3FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI3FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI3FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI3FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI3FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI3FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI3FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI3FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="RAISEMEDI3FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI3FRQMSG" runat="server">
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
          <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="RespondedMEDI3FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI3FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI3FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI3FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI3FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI3FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI3FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI3FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="CLOSEMEDI3FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI3FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI3FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the ARNI Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="CloseMEDI3FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI3FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI3FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI3FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI3FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI3FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI3FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI3FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: ARNI" ID="LockMEDI3FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI3FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI3FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI3FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI3FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI3FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI3FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI3FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI3FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: MRA" ID="RAISEMEDI4FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI4FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI4FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI4FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI4FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI4FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI4FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI4FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="RAISEMEDI4FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI4FRQMSG" runat="server">
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
          <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="RespondedMEDI4FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI4FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI4FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI4FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI4FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI4FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI4FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI4FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                        
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="CLOSEMEDI4FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI4FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI4FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the MRA Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="CloseMEDI4FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI4FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI4FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI4FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI4FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI4FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI4FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI4FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: MRA" ID="LockMEDI4FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI4FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI4FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI4FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI4FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI4FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI4FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI4FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI4FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Diuretic" ID="RAISEMEDI5FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI5FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI5FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI5FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI5FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI5FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI5FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI5FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="RAISEMEDI5FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI5FRQMSG" runat="server">
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
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="RespondedMEDI5FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI5FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI5FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI5FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI5FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI5FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI5FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI5FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="CLOSEMEDI5FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI5FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI5FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Diuretic Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="CloseMEDI5FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI5FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI5FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI5FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI5FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI5FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI5FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI5FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Diuretic" ID="LockMEDI5FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI5FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI5FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI5FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI5FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI5FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI5FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI5FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI5FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="RAISEMEDI6FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI6FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI6FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI6FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI6FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI6FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI6FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI6FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="RAISEMEDI6FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI6FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Non-steroidal MRA (Finerenone) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="RespondedMEDI6FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI6FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI6FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI6FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI6FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI6FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI6FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI6FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="CLOSEMEDI6FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI6FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI6FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Non-steroidal MRA (Finerenone) Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="CloseMEDI6FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI6FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI6FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI6FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI6FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI6FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI6FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI6FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Non-steroidal MRA (Finerenone)" ID="LockMEDI6FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI6FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI6FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI6FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI6FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI6FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI6FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI6FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI6FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Vericiguat" ID="RAISEMEDI7FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI7FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI7FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI7FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI7FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI7FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI7FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI7FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="RAISEMEDI7FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI7FRQMSG" runat="server">
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
          <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="RespondedMEDI7FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI7FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI7FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI7FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI7FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI7FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI7FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI7FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="CLOSEMEDI7FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI7FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI7FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Vericiguat Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="CloseMEDI7FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI7FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI7FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI7FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI7FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI7FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI7FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI7FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Vericiguat" ID="LockMEDI7FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI7FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI7FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI7FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI7FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI7FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI7FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI7FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI7FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Ivabradine" ID="RAISEMEDI8FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI8FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI8FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI8FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI8FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI8FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI8FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI8FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="RAISEMEDI8FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI8FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Ivabradine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="RespondedMEDI8FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI8FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI8FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI8FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI8FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI8FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI8FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI8FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="CLOSEMEDI8FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI8FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI8FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Ivabradine Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="CloseMEDI8FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI8FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI8FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI8FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI8FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI8FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI8FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI8FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                 
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Ivabradine" ID="LockMEDI8FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI8FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI8FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI8FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI8FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI8FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI8FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI8FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI8FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 1" ID="RAISEMEDI9FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI9FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI9FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI9FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI9FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI9FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI9FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI9FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="RAISEMEDI9FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI9FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="RespondedMEDI9FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI9FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI9FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI9FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI9FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI9FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI9FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI9FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="CLOSEMEDI9FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI9FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI9FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 1 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="CloseMEDI9FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI9FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI9FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI9FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI9FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI9FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI9FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI9FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 1" ID="LockMEDI9FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI9FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI9FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI9FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI9FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI9FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI9FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI9FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI9FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 2" ID="RAISEMEDI10FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI10FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI10FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI10FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI10FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI10FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI10FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI10FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="RAISEMEDI10FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI10FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="RespondedMEDI10FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI10FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI10FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI10FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI10FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI10FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI10FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI10FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                   
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="CLOSEMEDI10FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI10FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI10FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 2 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="CloseMEDI10FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI10FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI10FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI10FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI10FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI10FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI10FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI10FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 2" ID="LockMEDI10FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI10FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI10FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI10FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI10FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI10FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI10FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI10FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI10FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 3" ID="RAISEMEDI11FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI11FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI11FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI11FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI11FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI11FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI11FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI11FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="RAISEMEDI11FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI11FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="RespondedMEDI11FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI11FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI11FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI11FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI11FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI11FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI11FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI11FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="CLOSEMEDI11FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI11FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI11FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 3 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="CloseMEDI11FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI11FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI11FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI11FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI11FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI11FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI11FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI11FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 3" ID="LockMEDI11FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI11FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI11FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI11FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI11FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI11FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI11FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI11FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI11FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 4" ID="RAISEMEDI12FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI12FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI12FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI12FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI12FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI12FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI12FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI12FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                     
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="RAISEMEDI12FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI12FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="RespondedMEDI12FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI12FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI12FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI12FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI12FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI12FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI12FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI12FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="CLOSEMEDI12FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI12FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI12FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 4 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="CloseMEDI12FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI12FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI12FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI12FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI12FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI12FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI12FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI12FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 4" ID="LockMEDI12FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI12FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI12FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI12FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI12FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI12FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI12FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI12FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI12FRQText" runat="server" BorderStyle="Solid" >
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
          <ASPP:PopupPanel  HeaderText="Raise Query: Details of Other Drugs No 5" ID="RAISEMEDI13FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI13FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRaiseMEDI13FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRaiseMEDI13FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRaiseMEDI13FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRaiseMEDI13FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRaiseMEDI13FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRaiseMEDI13FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                    
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="RAISEMEDI13FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEMEDI13FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid" >

                             Query has been Raised to the Details of Other Drugs No 5 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="RespondedMEDI13FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRespondedMEDI13FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelRespondedMEDI13FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelRespondedMEDI13FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelRespondedMEDI13FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelRespondedMEDI13FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelRespondedMEDI13FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelRespondedMEDI13FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                       
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="CLOSEMEDI13FRQMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCLOSEMEDI13FRQMSG" runat="server">
                     <div align="center" style="width: 300px; height: 200px">
                        <br />
                    <asp:Panel ID="PanelCLOSEMEDI13FRQMSG" runat="server" BorderStyle="Solid" >

                            Query is Closed of the Details of Other Drugs No 5 Field
                             </asp:Panel>
                         </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <div id="ct100_PopupWindow1">
          <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="CloseMEDI13FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
           <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowCloseMEDI13FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelCloseMEDI13FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelCloseMEDI13FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelCloseMEDI13FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelCloseMEDI13FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelCloseMEDI13FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelCloseMEDI13FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                  
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
        </div>
    <div id="ct100_PopupWindow1">
                        <ASPP:PopupPanel HeaderText="Raise Query: Details of Other Drugs No 5" ID="LockMEDI13FRQ" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowLockMEDI13FRQ" runat="server">
                    <div align="left" style="width: 300px"  >
                        <asp:Panel ID="PanelLockMEDI13FRQ" runat="server" BorderStyle="Solid" BackColor="Red">
                        <asp:Label ID="LabelLockMEDI13FRQ" runat="server"  > </asp:Label>
                            </asp:Panel>
                        <br />
                          <asp:Panel ID="PanelLockMEDI13FRQ2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                         <asp:Label ID="LabelLockMEDI13FRQ2" runat="server"  > </asp:Label>
                              </asp:Panel>
                        <br />
                                <asp:Panel ID="PanelLockMEDI13FRQ3" runat="server" BorderStyle="Solid" BackColor="#009933">
                         <asp:Label ID="LabelLockMEDI13FRQ3" runat="server"   > </asp:Label>
                                    </asp:Panel>
                      <br />
                        <asp:Panel ID="PanelLockMEDI13FRQText" runat="server" BorderStyle="Solid" >
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
