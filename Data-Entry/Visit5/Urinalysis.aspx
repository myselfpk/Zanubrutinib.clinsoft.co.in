<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Urinalysis.aspx.cs" Inherits="Data_Entry_Visit5_Urinalysis" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Data Entry | Visit 5 | Urinalysis</title>
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
            height: 50px;
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
    </style>
    <script type="text/javascript">
        function Confirm() {
            var validated = Page_ClientValidate('IC');
            if (validated) {
                var confirm_value = document.createElement("INPUT");

                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to Submit Urinalysis page?")) {
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
            if (confirm("Do you want to Save Urinalysis page?")) {

                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
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
                        <asp:Label runat="server" ID="lblPage">Urinalysis</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Visit 5</asp:LinkButton></li>
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
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLABASS">Blood Sample collected for Laboratory Assessment?</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLABASS" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention Blood Sample collected for Laboratory Assessment?"
                                                    ControlToValidate="RadioButtonListLABASS"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListLABASS" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryLABASS" Height="25px" Width="25px" runat="server" OnClick="ImageQueryLABASS_Click" />
                                            </td>
                                        </tr>
                                    </table>


                                    <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                        <colgroup>

                                            <col width="20%" />
                                            <col width="15%" />
                                            <col width="15%" />
                                            <col width="20%" />
                                            <col width="20%" />
                                            <col width="10%" />
                                        </colgroup>

                                        <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                            <td class="text-center"><b>Parameters</b></td>
                                            <td class="text-center"><b>Results</b></td>
                                            <td class="text-center"><b>Units</b></td>
                                            <td class="text-center"><b>Normal/Abnormal</b></td>
                                            <td class="text-center"><b>CS/NCS</b></td>
                                            <td></td>
                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB1OPT">Colour</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT1OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN1OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB1OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN1OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT1OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB2OPT">Appearance</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT2OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN2OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB2OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN2OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT2OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT2OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB3OPT">Specific Gravity</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT3OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN3OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB3OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN3OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT3OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT3OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB4OPT">pH</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT4OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN4OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB4OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN4OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT4OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT4OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB5OPT">Urinary Protein</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT5OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN5OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB5OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN5OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT5OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT5OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB6OPT">Urinary Glucose</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT6OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN6OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB6OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN6OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT6OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT6OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB7OPT">Urine Ketone</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT7OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN7OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB7OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN7OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT7OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT7OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB8OPT">Urinary Bilirubin</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT8OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN8OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB8OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN8OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT8OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT8OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB9OPT">Urobilinogen</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT9OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN9OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB9OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN9OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT9OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT9OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB10OPT">Bile Salt</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT10OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN10OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB10OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN10OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT10OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT10OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB11OPT">Bile Pigment</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT11OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN11OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB11OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN11OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT11OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT11OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB12OPT">Urine Blood</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT12OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN12OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB12OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN12OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT12OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT12OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB13OPT">Nitrite</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT13OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN13OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB13OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN13OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT13OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT13OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB14OPT">Mucuse</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT14OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN14OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB14OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN14OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT14OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT14OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB15OPT">Red Blood Cells</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT15OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN15OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB15OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN15OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT15OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT15OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB16OPT">Pus Cells</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT16OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN16OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB16OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN16OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT16OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT16OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB17OPT">Epithelial Cells</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT17OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN17OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB17OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN17OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT17OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT17OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB18OPT">Casts</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT18OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN18OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB18OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN18OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT18OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT18OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB19OPT">Crystals</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT19OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN19OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB19OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN19OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT19OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT19OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB20OPT">Bacteria</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT20OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN20OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB20OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN20OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT20OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT20OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB21OPT">Yeast</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT21OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN21OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB21OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN21OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT21OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT21OPT_Click" />

                                            </td>

                                        </tr>
                                        <tr class="auto-style2">
                                            <td>
                                                <asp:Label runat="server" ID="lblLAB22OPT">Parasites</asp:Label>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TextBoxRSLT22OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxUN22OPT" runat="server" class="form-control" Height="45px" Width="95%" ValidationGroup="IC"></asp:TextBox>
                                            </td>

                                            <td>
                                                <asp:DropDownList ID="RadioButtonListNAB22OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Abnormal</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListABN22OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>CS</asp:ListItem>
                                                    <asp:ListItem>NCS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:ImageButton ID="ImageQueryRSLT22OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryRSLT22OPT_Click" />

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

    <asp:Label runat="server" ID="lblRSLT1OPT" Text="Colour Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT2OPT" Text="Appearance Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT3OPT" Text="Specific Gravity Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT4OPT" Text="pH Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT5OPT" Text="Urinary Protein Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT6OPT" Text="Urinary Glucose Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT7OPT" Text="Urine Ketone count Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT8OPT" Text="Urinary Bilirubin Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT9OPT" Text="Urobilinogen Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT10OPT" Text="Bile Salt Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT11OPT" Text="Bile Pigment Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT12OPT" Text="Urine Blood Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT13OPT" Text="Nitrite Results" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblUN1OPT" Text="Colour Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN2OPT" Text="Appearance Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN3OPT" Text="Specific Gravity Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN4OPT" Text="pH Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN5OPT" Text="Urinary Protein Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN6OPT" Text="Urinary Glucose Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN7OPT" Text="Urine Ketone count Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN8OPT" Text="Urinary Bilirubin Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN9OPT" Text="Urobilinogen Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN10OPT" Text="Bile Salt Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN11OPT" Text="Bile Pigment Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN12OPT" Text="Urine Blood Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN13OPT" Text="Nitrite Units" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblNAB1OPT" Text="Colour Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB2OPT" Text="Appearance Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB3OPT" Text="Specific Gravity Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB4OPT" Text="pH Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB5OPT" Text="Urinary Protein Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB6OPT" Text="Urinary Glucose Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB7OPT" Text="Urine Ketone count Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB8OPT" Text="Urinary Bilirubin Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB9OPT" Text="Urobilinogen Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB10OPT" Text="Bile Salt Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB11OPT" Text="Bile Pigment Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB12OPT" Text="Urine Blood Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB13OPT" Text="Nitrite Normal/Abnormal" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblABN1OPT" Text="Colour CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN2OPT" Text="Appearance CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN3OPT" Text="Specific Gravity CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN4OPT" Text="pH CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN5OPT" Text="Urinary Protein CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN6OPT" Text="Urinary Glucose CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN7OPT" Text="Urine Ketone count CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN8OPT" Text="Urinary Bilirubin CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN9OPT" Text="Urobilinogen CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN10OPT" Text="Bile Salt CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN11OPT" Text="Bile Pigment CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN12OPT" Text="Urine Blood CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN13OPT" Text="Nitrite CS/NCS" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblRSLT14OPT" Text="Mucuse Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT15OPT" Text="Red Blood Cells  Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT16OPT" Text="Pus Cells Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT17OPT" Text="Epithelial Cells Results" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblUN14OPT" Text="Mucuse Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN15OPT" Text="Red Blood Cells  Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN16OPT" Text="Pus Cells Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN17OPT" Text="Epithelial Cells Units" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblNAB14OPT" Text="Mucuse Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB15OPT" Text="Red Blood Cells  Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB16OPT" Text="Pus Cells Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB17OPT" Text="Epithelial Cells Normal/Abnormal" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblABN14OPT" Text="Mucuse CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN15OPT" Text="Red Blood Cells  CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN16OPT" Text="Pus Cells CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN17OPT" Text="Epithelial Cells CS/NCS" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblRSLT18OPT" Text="Casts Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT19OPT" Text="Crystals Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT20OPT" Text="Bacteria Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT21OPT" Text="Yeast Results" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblRSLT22OPT" Text="Parasites Results" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblUN18OPT" Text="Casts Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN19OPT" Text="Crystals Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN20OPT" Text="Bacteria Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN21OPT" Text="Yeast Units" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUN22OPT" Text="Parasites Units" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblNAB18OPT" Text="Casts Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB19OPT" Text="Crystals Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB20OPT" Text="Bacteria Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB21OPT" Text="Yeast Normal/Abnormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblNAB22OPT" Text="Parasites Normal/Abnormal" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblABN18OPT" Text="Casts CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN19OPT" Text="Crystals CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN20OPT" Text="Bacteria CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN21OPT" Text="Yeast CS/NCS" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblABN22OPT" Text="Parasites CS/NCS" Visible="false"></asp:Label>

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

    <!-- Query Blood Sample collected for Laboratory Assessment?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Blood Sample collected for Laboratory Assessment?:" ID="RAISELABASS" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELABASS" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseLABASS" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseLABASS" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseLABASS2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseLABASS2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseLABASS3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseLABASS3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideLABASS" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondLABASS" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseLABASS" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseLABASS" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseLABASS" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseLABASS_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Blood Sample collected for Laboratory Assessment?:" ID="RAISELABASSMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISELABASSMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Blood Sample collected for Laboratory Assessment? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Colour Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Colour Details:" ID="RAISERSLT1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT1OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT1OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT1OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT1OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT1OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT1OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT1OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT1OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT1OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT1OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Colour Details:" ID="RAISERSLT1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT1OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Colour Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Appearance Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Appearance Details:" ID="RAISERSLT2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT2OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT2OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT2OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT2OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT2OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT2OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT2OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT2OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT2OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT2OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Appearance Details:" ID="RAISERSLT2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT2OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Appearance Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Specific Gravity Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Specific Gravity Details:" ID="RAISERSLT3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT3OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT3OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT3OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT3OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT3OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT3OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT3OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT3OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT3OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT3OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Specific Gravity Details:" ID="RAISERSLT3OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT3OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Specific Gravity Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query pH Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: pH Details:" ID="RAISERSLT4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT4OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT4OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT4OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT4OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT4OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT4OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT4OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT4OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT4OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT4OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: pH Details:" ID="RAISERSLT4OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT4OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Responded of the pH Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Urinary Protein Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Urinary Protein Details:" ID="RAISERSLT5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT5OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT5OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT5OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT5OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT5OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT5OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT5OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT5OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT5OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT5OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Urinary Protein Details:" ID="RAISERSLT5OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT5OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Urinary Protein Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Urinary Glucose Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Urinary Glucose Details:" ID="RAISERSLT6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT6OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT6OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT6OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT6OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT6OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT6OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT6OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT6OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT6OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT6OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Urinary Glucose Details:" ID="RAISERSLT6OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT6OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Urinary Glucose Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Urine Ketone count Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Urine Ketone count Details:" ID="RAISERSLT7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT7OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT7OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT7OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT7OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT7OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT7OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT7OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT7OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT7OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT7OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Urine Ketone count Details:" ID="RAISERSLT7OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT7OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Urine Ketone count Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Urinary Bilirubin Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Urinary Bilirubin Details:" ID="RAISERSLT8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT8OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT8OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT8OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT8OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT8OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT8OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT8OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT8OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT8OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT8OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Urinary Bilirubin Details:" ID="RAISERSLT8OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT8OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Urinary Bilirubin Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Urobilinogen Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Urobilinogen Details:" ID="RAISERSLT9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT9OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT9OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT9OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT9OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT9OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT9OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT9OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT9OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT9OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT9OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Urobilinogen Details:" ID="RAISERSLT9OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT9OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Urobilinogen Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Bile Salt Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Bile Salt Details:" ID="RAISERSLT10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT10OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT10OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT10OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT10OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT10OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT10OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT10OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT10OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT10OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT10OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Bile Salt Details:" ID="RAISERSLT10OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT10OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Bile Salt Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Bile Pigment Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Bile Pigment Details:" ID="RAISERSLT11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT11OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT11OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT11OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT11OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT11OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT11OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT11OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT11OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT11OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT11OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Bile Pigment Details:" ID="RAISERSLT11OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT11OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Bile Pigment Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Urine Blood Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Urine Blood Details:" ID="RAISERSLT12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT12OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT12OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT12OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT12OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT12OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT12OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT12OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT12OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT12OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT12OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Urine Blood Details:" ID="RAISERSLT12OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT12OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Urine Blood Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Nitrite Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Nitrite Details:" ID="RAISERSLT13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT13OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT13OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT13OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT13OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT13OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT13OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT13OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT13OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT13OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT13OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Nitrite Details:" ID="RAISERSLT13OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT13OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Nitrite Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Mucuse Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Mucuse Details:" ID="RAISERSLT14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT14OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT14OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT14OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT14OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT14OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT14OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT14OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT14OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT14OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT14OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Mucuse Details:" ID="RAISERSLT14OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT14OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Mucuse Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Red Blood Cells Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Red Blood Cells Details:" ID="RAISERSLT15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT15OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT15OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT15OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT15OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT15OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT15OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT15OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT15OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT15OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT15OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Red Blood Cells Details:" ID="RAISERSLT15OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT15OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel16" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Red Blood Cells Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Pus Cells Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Pus Cells Details:" ID="RAISERSLT16OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT16OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT16OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT16OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT16OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT16OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT16OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT16OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT16OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT16OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT16OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT16OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT16OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT16OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Pus Cells Details:" ID="RAISERSLT16OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT16OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel17" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Pus Cells Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Epithelial Cells Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Epithelial Cells Details:" ID="RAISERSLT17OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT17OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT17OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT17OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT17OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT17OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT17OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT17OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT17OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT17OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT17OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT17OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT17OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT17OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Epithelial Cells Details:" ID="RAISERSLT17OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT17OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel18" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Epithelial Cells Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Casts Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Casts Details:" ID="RAISERSLT18OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT18OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT18OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT18OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT18OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT18OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT18OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT18OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT18OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT18OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT18OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT18OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT18OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT18OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Casts Details:" ID="RAISERSLT18OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT18OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel19" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Casts Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Crystals Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Crystals Details:" ID="RAISERSLT19OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT19OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT19OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT19OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT19OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT19OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT19OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT19OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT19OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT19OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT19OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT19OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT19OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT19OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Crystals Details:" ID="RAISERSLT19OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT19OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel20" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Crystals Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Bacteria Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Bacteria Details:" ID="RAISERSLT20OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT20OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT20OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT20OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT20OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT20OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT20OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT20OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT20OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT20OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT20OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT20OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT20OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT20OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Bacteria Details:" ID="RAISERSLT20OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT20OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel21" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Bacteria Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Yeast Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Yeast Details:" ID="RAISERSLT21OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT21OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT21OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT21OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT21OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT21OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT21OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT21OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT21OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT21OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT21OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT21OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT21OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT21OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Yeast Details:" ID="RAISERSLT21OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT21OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel22" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Yeast Details Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Parasites Details: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Parasites Details:" ID="RAISERSLT22OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT22OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseRSLT22OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseRSLT22OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT22OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseRSLT22OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseRSLT22OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseRSLT22OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideRSLT22OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondRSLT22OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseRSLT22OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseRSLT22OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseRSLT22OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseRSLT22OPT_Click" />
                                        </center>

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
        <ASPP:PopupPanel HeaderText="Respond Query: Parasites Details:" ID="RAISERSLT22OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISERSLT22OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel23" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Parasites Details Field
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
