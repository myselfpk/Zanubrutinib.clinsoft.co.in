<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HRQoL_Questionnaire.aspx.cs" Inherits="Data_Entry_Visit8_HRQoL_Questionnaire" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Clinsoft | Data Entry | Visit 8 | HRQoL Questionnaire</title>
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
            text-align: left;
            font-weight: bold;
            text-indent: 20px;
            background-color: cornsilk;
            color: red;
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
                if (confirm("Do you want to Submit HRQoL Questionnaire page?")) {
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
            if (confirm("Do you want to Save HRQoL Questionnaire page?")) {

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
                        <asp:Label runat="server" ID="lblPage">HRQoL Questionnaire</asp:Label></h1>

                </div>
                <div>
                    <ul class="breadcrumb">
                        <li><i class="fa fa-home fa-lg"></i></li>
                        <li>Data Entry</li>
                        <li>
                            <asp:LinkButton ID="lblVisit" runat="server" OnClick="lblVisit_Click">Visit 8</asp:LinkButton></li>
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
                                                <asp:Label runat="server" ID="lblHRPER">HRQoL done</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorHRPER" runat="server"
                                                    CssClass="Validators" Display="None" ErrorMessage="please mention HRQoL done"
                                                    ControlToValidate="RadioButtonListHRPER"
                                                    ValidationGroup="IC"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RadioButtonListHRPER" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListHRPER_SelectedIndexChanged">
                                                    <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageQueryHRPER" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHRPER_Click" />
                                            </td>
                                        </tr>

                                    </table>

                                    <asp:Panel ID="hideHRQOL" runat="server" Visible="false">
                                        <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                            <colgroup>

                                                <col width="5%" />
                                                <col width="55%" />
                                                <col width="30%" />
                                                <col width="10%" />
                                            </colgroup>

                                            <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                                <td class="text-center"><b>S. No. </b></td>
                                                <td class="text-center"><b>EORTC- HRQoL</b></td>
                                                <td class="text-center"><b>Results</b></td>
                                                <td></td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>1.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR1OPT">Do you have any trouble doing strenuous activities, like carrying a heavy shopping bag or a suitcase?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR1OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Do you have any trouble doing strenuous activities, like carrying a heavy shopping bag or a suitcase?"
                                                        ControlToValidate="RadioButtonListHR1OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR1OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR1OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR1OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>2.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR2OPT">Do you have any trouble taking a long walk?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR2OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Do you have any trouble taking a long walk?"
                                                        ControlToValidate="RadioButtonListHR2OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR2OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR2OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR2OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>3.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR3OPT">Do you have any trouble taking a short walk outside of the house?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR3OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Do you have any trouble taking a short walk outside of the house?"
                                                        ControlToValidate="RadioButtonListHR3OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR3OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR3OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR3OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>4.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR4OPT">Do you need to stay in bed or a chair during the day?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR4OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Do you need to stay in bed or a chair during the day?"
                                                        ControlToValidate="RadioButtonListHR4OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR4OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR4OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR4OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>5.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR5OPT">Do you need help with eating, dressing, washing yourself or using the toilet?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR5OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Do you need help with eating, dressing, washing yourself or using the toilet?"
                                                        ControlToValidate="RadioButtonListHR5OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR5OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR5OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR5OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>6.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR6OPT">Were you limited in doing either your work or other daily activities?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR6OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Were you limited in doing either your work or other daily activities?"
                                                        ControlToValidate="RadioButtonListHR6OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR6OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR6OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR6OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>7.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR7OPT">Were you limited in pursuing your hobbies or other leisure time activities?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR7OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Were you limited in pursuing your hobbies or other leisure time activities?"
                                                        ControlToValidate="RadioButtonListHR7OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR7OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR7OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR7OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>8.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR8OPT">Were you short of breath?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR8OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Were you short of breath?"
                                                        ControlToValidate="RadioButtonListHR8OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR8OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR8OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR8OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>9.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR9OPT">Have you had pain?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR9OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you had pain?"
                                                        ControlToValidate="RadioButtonListHR9OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR9OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR9OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR9OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>10.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR10OPT">Did you need to rest?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR10OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Did you need to rest?"
                                                        ControlToValidate="RadioButtonListHR10OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR10OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR10OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR10OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>11.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR11OPT">Have you had trouble sleeping?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR11OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you had trouble sleeping?"
                                                        ControlToValidate="RadioButtonListHR11OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR11OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR11OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR11OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>12.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR12OPT">Have you felt weak?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR12OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you felt weak?"
                                                        ControlToValidate="RadioButtonListHR12OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR12OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR12OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR12OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>13.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR13OPT">Have you lacked appetite?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR13OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you lacked appetite?"
                                                        ControlToValidate="RadioButtonListHR13OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR13OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR13OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR13OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>14.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR14OPT">Have you felt nauseated?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR14OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you felt nauseated?"
                                                        ControlToValidate="RadioButtonListHR14OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR14OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR14OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR14OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>15.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR15OPT">Have you vomited?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR15OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you vomited?"
                                                        ControlToValidate="RadioButtonListHR15OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR15OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR15OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR15OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>16.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR16OPT">Have you been constipated?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR16OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you been constipated?"
                                                        ControlToValidate="RadioButtonListHR16OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR16OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR16OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR16OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>17.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR17OPT">Have you had diarrhea?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR17OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you had diarrhea?"
                                                        ControlToValidate="RadioButtonListHR17OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR17OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR17OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR17OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>18.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR18OPT">Were you tired?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR18OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Were you tired?"
                                                        ControlToValidate="RadioButtonListHR18OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR18OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR18OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR18OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>19.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR19OPT">Did pain interfere with your daily activities?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR19OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Did pain interfere with your daily activities?"
                                                        ControlToValidate="RadioButtonListHR19OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR19OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR19OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR19OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>20.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR20OPT">Have you had difficulty in concentrating on things, like reading a newspaper or watching television</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR20OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you had difficulty in concentrating on things, like reading a newspaper or watching television"
                                                        ControlToValidate="RadioButtonListHR20OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR20OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR20OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR20OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>21.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR21OPT">Did you feel tense?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR21OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Did you feel tense?"
                                                        ControlToValidate="RadioButtonListHR21OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR21OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR21OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR21OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>22.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR22OPT">Did you worry?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR22OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Did you worry?"
                                                        ControlToValidate="RadioButtonListHR22OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR22OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR22OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR22OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>23.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR23OPT">Did you feel irritable</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR23OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Did you feel irritable"
                                                        ControlToValidate="RadioButtonListHR23OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR23OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR23OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR23OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>24.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR24OPT">Did you feel depressed?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR24OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Did you feel depressed?"
                                                        ControlToValidate="RadioButtonListHR24OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR24OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR24OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR24OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>25.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR25OPT">Have you had difficulty remembering things?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR25OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Have you had difficulty remembering things?"
                                                        ControlToValidate="RadioButtonListHR25OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR25OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR25OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR25OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>26.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR26OPT">Has your physical condition or medical treatment interfered with your family life?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR26OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Has your physical condition or medical treatment interfered with your family life?"
                                                        ControlToValidate="RadioButtonListHR26OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR26OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR26OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR26OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>27.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR27OPT">Has your physical condition or medical treatment interfered with your social activities?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR27OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Has your physical condition or medical treatment interfered with your social activities?"
                                                        ControlToValidate="RadioButtonListHR27OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR27OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR27OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR27OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>28.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR28OPT">Has your physical condition or medical treatment caused you financial difficulties?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR28OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention Has your physical condition or medical treatment caused you financial difficulties?"
                                                        ControlToValidate="RadioButtonListHR28OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR28OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Not at all</asp:ListItem>
                                                        <asp:ListItem>2 - A little</asp:ListItem>
                                                        <asp:ListItem>3 - Quite a Bit</asp:ListItem>
                                                        <asp:ListItem>4 - Very Much</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR28OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR28OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style3" style="background-color: cadetblue; font: bold; color: cornsilk">
                                                <td class="text-center" colspan="4"><b>For the following questions please circle the number between 1 and 7 that best applies to you</b></td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>29.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR29OPT">How would you rate your overall health during the past week?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR29OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention How would you rate your overall health during the past week?"
                                                        ControlToValidate="RadioButtonListHR29OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR29OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Very Poor</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7 - Excellent</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR29OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR29OPT_Click" />
                                                </td>
                                            </tr>
                                            <tr class="auto-style2">
                                                <td>30.</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblHR30OPT">How would you rate your overall quality of life during the past week?</asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorHR30OPT" runat="server"
                                                        CssClass="Validators" Display="None" ErrorMessage="please mention How would you rate your overall quality of life during the past week?"
                                                        ControlToValidate="RadioButtonListHR30OPT"
                                                        ValidationGroup="IC"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RadioButtonListHR30OPT" class="form-control" Height="45px" Width="95%" runat="server" ValidationGroup="IC">
                                                        <asp:ListItem Value="">Please Select Option</asp:ListItem>
                                                        <asp:ListItem>1 - Very Poor</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7 - Excellent</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageQueryHR30OPT" Height="25px" Width="25px" runat="server" OnClick="ImageQueryHR30OPT_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>


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

    <!-- Query HRQoL done: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: HRQoL done:" ID="RAISEHRPER" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHRPER" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHRPER" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHRPER" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHRPER2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHRPER2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHRPER3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHRPER3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHRPER" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHRPER" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHRPER" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHRPER" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHRPER" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHRPER_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: HRQoL done:" ID="RAISEHRPERMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHRPERMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid">
                            Query has been Responded of the HRQoL done Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Do you have any trouble doing strenuous activities, like carrying a heavy shopping bag or a suitcase?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Do you have any trouble doing strenuous activities, like carrying a heavy shopping bag or a suitcase?:" ID="RAISEHR1OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR1OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR1OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR1OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR1OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR1OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR1OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR1OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR1OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR1OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR1OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR1OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR1OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR1OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Do you have any trouble doing strenuous activities, like carrying a heavy shopping bag or a suitcase?:" ID="RAISEHR1OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR1OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Do you have any trouble doing strenuous activities, like carrying a heavy shopping bag or a suitcase? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Do you have any trouble taking a long walk?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Do you have any trouble taking a long walk?:" ID="RAISEHR2OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR2OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR2OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR2OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR2OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR2OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR2OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR2OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR2OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR2OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR2OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR2OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR2OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR2OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Do you have any trouble taking a long walk?:" ID="RAISEHR2OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR2OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Do you have any trouble taking a long walk? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Do you have any trouble taking a short walk outside of the house?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Do you have any trouble taking a short walk outside of the house?:" ID="RAISEHR3OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR3OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR3OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR3OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR3OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR3OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR3OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR3OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR3OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR3OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR3OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR3OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR3OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR3OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Do you have any trouble taking a short walk outside of the house?:" ID="RAISEHR3OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR3OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Do you have any trouble taking a short walk outside of the house? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Do you need to stay in bed or a chair during the day?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Do you need to stay in bed or a chair during the day?:" ID="RAISEHR4OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR4OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR4OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR4OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR4OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR4OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR4OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR4OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR4OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR4OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR4OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR4OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR4OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR4OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Do you need to stay in bed or a chair during the day?:" ID="RAISEHR4OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR4OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Do you need to stay in bed or a chair during the day? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Do you need help with eating, dressing, washing yourself or using the toilet?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Do you need help with eating, dressing, washing yourself or using the toilet?:" ID="RAISEHR5OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR5OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR5OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR5OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR5OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR5OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR5OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR5OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR5OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR5OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR5OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR5OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR5OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR5OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Do you need help with eating, dressing, washing yourself or using the toilet?:" ID="RAISEHR5OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR5OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel6" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Do you need help with eating, dressing, washing yourself or using the toilet? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Were you limited in doing either your work or other daily activities?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Were you limited in doing either your work or other daily activities?:" ID="RAISEHR6OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR6OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR6OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR6OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR6OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR6OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR6OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR6OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR6OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR6OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR6OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR6OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR6OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR6OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Were you limited in doing either your work or other daily activities?:" ID="RAISEHR6OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR6OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel7" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Were you limited in doing either your work or other daily activities? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Were you limited in pursuing your hobbies or other leisure time activities?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Were you limited in pursuing your hobbies or other leisure time activities?:" ID="RAISEHR7OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR7OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR7OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR7OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR7OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR7OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR7OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR7OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR7OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR7OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR7OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR7OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR7OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR7OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Were you limited in pursuing your hobbies or other leisure time activities?:" ID="RAISEHR7OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR7OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Were you limited in pursuing your hobbies or other leisure time activities? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Were you short of breath?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Were you short of breath?:" ID="RAISEHR8OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR8OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR8OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR8OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR8OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR8OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR8OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR8OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR8OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR8OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR8OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR8OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR8OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR8OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Were you short of breath?:" ID="RAISEHR8OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR8OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel9" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Were you short of breath? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you had pain?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had pain?:" ID="RAISEHR9OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR9OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR9OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR9OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR9OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR9OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR9OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR9OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR9OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR9OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR9OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR9OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR9OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR9OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had pain?:" ID="RAISEHR9OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR9OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel10" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you had pain? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Did you need to rest?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Did you need to rest?:" ID="RAISEHR10OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR10OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR10OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR10OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR10OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR10OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR10OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR10OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR10OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR10OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR10OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR10OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR10OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR10OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Did you need to rest?:" ID="RAISEHR10OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR10OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel11" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Did you need to rest? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you had trouble sleeping?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had trouble sleeping?:" ID="RAISEHR11OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR11OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR11OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR11OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR11OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR11OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR11OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR11OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR11OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR11OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR11OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR11OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR11OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR11OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had trouble sleeping?:" ID="RAISEHR11OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR11OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel12" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you had trouble sleeping? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you felt weak?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you felt weak?:" ID="RAISEHR12OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR12OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR12OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR12OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR12OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR12OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR12OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR12OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR12OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR12OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR12OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR12OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR12OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR12OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you felt weak?:" ID="RAISEHR12OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR12OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel13" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you felt weak? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you lacked appetite?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you lacked appetite?:" ID="RAISEHR13OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR13OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR13OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR13OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR13OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR13OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR13OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR13OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR13OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR13OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR13OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR13OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR13OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR13OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you lacked appetite?:" ID="RAISEHR13OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR13OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel14" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you lacked appetite? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you felt nauseated?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you felt nauseated?:" ID="RAISEHR14OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR14OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR14OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR14OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR14OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR14OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR14OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR14OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR14OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR14OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR14OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR14OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR14OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR14OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you felt nauseated?:" ID="RAISEHR14OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR14OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel15" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you felt nauseated? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you vomited?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you vomited?:" ID="RAISEHR15OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR15OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR15OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR15OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR15OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR15OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR15OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR15OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR15OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR15OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR15OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR15OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR15OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR15OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you vomited?:" ID="RAISEHR15OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR15OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel16" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you vomited? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you been constipated?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you been constipated?:" ID="RAISEHR16OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR16OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR16OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR16OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR16OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR16OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR16OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR16OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR16OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR16OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR16OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR16OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR16OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR16OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you been constipated?:" ID="RAISEHR16OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR16OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel17" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you been constipated? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you had diarrhea?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had diarrhea?:" ID="RAISEHR17OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR17OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR17OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR17OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR17OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR17OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR17OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR17OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR17OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR17OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR17OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR17OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR17OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR17OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had diarrhea?:" ID="RAISEHR17OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR17OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel18" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you had diarrhea? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Were you tired?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Were you tired?:" ID="RAISEHR18OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR18OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR18OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR18OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR18OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR18OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR18OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR18OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR18OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR18OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR18OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR18OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR18OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR18OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Were you tired?:" ID="RAISEHR18OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR18OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel19" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Were you tired? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Did pain interfere with your daily activities?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Did pain interfere with your daily activities?:" ID="RAISEHR19OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR19OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR19OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR19OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR19OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR19OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR19OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR19OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR19OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR19OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR19OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR19OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR19OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR19OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Did pain interfere with your daily activities?:" ID="RAISEHR19OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR19OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel20" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Did pain interfere with your daily activities? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you had difficulty in concentrating on things, like reading a newspaper or watching television: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had difficulty in concentrating on things, like reading a newspaper or watching television:" ID="RAISEHR20OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR20OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR20OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR20OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR20OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR20OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR20OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR20OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR20OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR20OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR20OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR20OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR20OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR20OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had difficulty in concentrating on things, like reading a newspaper or watching television:" ID="RAISEHR20OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR20OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel21" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you had difficulty in concentrating on things, like reading a newspaper or watching television Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Did you feel tense?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Did you feel tense?:" ID="RAISEHR21OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR21OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR21OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR21OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR21OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR21OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR21OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR21OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR21OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR21OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR21OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR21OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR21OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR21OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Did you feel tense?:" ID="RAISEHR21OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR21OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel22" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Did you feel tense? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Did you worry?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Did you worry?:" ID="RAISEHR22OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR22OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR22OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR22OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR22OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR22OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR22OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR22OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR22OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR22OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR22OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR22OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR22OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR22OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Did you worry?:" ID="RAISEHR22OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR22OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel23" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Did you worry? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Did you feel irritable?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Did you feel irritable?:" ID="RAISEHR23OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR23OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR23OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR23OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR23OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR23OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR23OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR23OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR23OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR23OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR23OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR23OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR23OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR23OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Did you feel irritable?:" ID="RAISEHR23OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR23OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel24" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Did you feel irritable? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Did you feel depressed?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Did you feel depressed?:" ID="RAISEHR24OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR24OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR24OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR24OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR24OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR24OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR24OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR24OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR24OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR24OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR24OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR24OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR24OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR24OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Did you feel depressed?:" ID="RAISEHR24OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR24OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel25" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Did you feel depressed? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Have you had difficulty remembering things?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had difficulty remembering things?:" ID="RAISEHR25OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR25OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR25OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR25OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR25OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR25OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR25OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR25OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR25OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR25OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR25OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR25OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR25OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR25OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Have you had difficulty remembering things?:" ID="RAISEHR25OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR25OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel26" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Have you had difficulty remembering things? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Has your physical condition or medical treatment interfered with your family life?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Has your physical condition or medical treatment interfered with your family life?:" ID="RAISEHR26OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR26OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR26OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR26OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR26OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR26OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR26OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR26OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR26OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR26OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR26OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR26OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR26OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR26OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Has your physical condition or medical treatment interfered with your family life?:" ID="RAISEHR26OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR26OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel27" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Has your physical condition or medical treatment interfered with your family life? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Has your physical condition or medical treatment interfered with your social activities?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Has your physical condition or medical treatment interfered with your social activities?:" ID="RAISEHR27OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR27OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR27OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR27OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR27OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR27OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR27OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR27OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR27OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR27OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR27OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR27OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR27OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR27OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Has your physical condition or medical treatment interfered with your social activities?:" ID="RAISEHR27OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR27OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel28" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Has your physical condition or medical treatment interfered with your social activities? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query Has your physical condition or medical treatment caused you financial difficulties?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: Has your physical condition or medical treatment caused you financial difficulties?:" ID="RAISEHR28OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR28OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR28OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR28OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR28OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR28OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR28OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR28OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR28OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR28OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR28OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR28OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR28OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR28OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: Has your physical condition or medical treatment caused you financial difficulties?:" ID="RAISEHR28OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR28OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel29" runat="server" BorderStyle="Solid">
                            Query has been Responded of the Has your physical condition or medical treatment caused you financial difficulties? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query How would you rate your overall health during the past week?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: How would you rate your overall health during the past week?:" ID="RAISEHR29OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR29OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR29OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR29OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR29OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR29OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR29OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR29OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR29OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR29OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR29OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR29OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR29OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR29OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: How would you rate your overall health during the past week?:" ID="RAISEHR29OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR29OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel30" runat="server" BorderStyle="Solid">
                            Query has been Responded of the How would you rate your overall health during the past week? Field
                        </asp:Panel>
                    </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
    <!-- Query How would you rate your overall quality of life during the past week?: -->
    <div id="ct100_PopupWindow1">
        <ASPP:PopupPanel HeaderText="Respond Query: How would you rate your overall quality of life during the past week?:" ID="RAISEHR30OPT" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR30OPT" runat="server">
                    <div align="left" style="width: 300px">
                        <asp:Panel ID="PanelRaiseHR30OPT" runat="server" BorderStyle="Solid" BackColor="Red">
                            <asp:Label ID="LabelRaiseHR30OPT" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR30OPT2" runat="server" BorderStyle="Solid" BackColor="Yellow">
                            <asp:Label ID="LabelRaiseHR30OPT2" runat="server"> </asp:Label><br />
                        </asp:Panel>

                        <asp:Panel ID="PanelRaiseHR30OPT3" runat="server" BorderStyle="Solid" BackColor="#009933">
                            <asp:Label ID="LabelRaiseHR30OPT3" runat="server"> </asp:Label><br />
                        </asp:Panel>
                        <asp:Panel ID="PanelHideHR30OPT" runat="server" Visible="false">
                            <table cellpadding="5px;" cellspacing="0" border="Solid" width="100%" class="CSSTableGenerator">
                                <colgroup>


                                    <col width="40%" />
                                    <col width="60%" />


                                </colgroup>

                                <tr class="auto-style2">
                                    <td>
                                        <asp:Label ID="LabelRespondHR30OPT" runat="server" Text="Query Response"> </asp:Label>

                                    </td>
                                    <td>
                                        <center>
                                            <asp:TextBox ID="TextBoxRaiseHR30OPT" class="form-control" runat="server" Height="50" Width="150" ValidationGroup="IC"
                                                TextMode="MultiLine">
                                            </asp:TextBox>

                                        </center>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" BackColor="Red" runat="server" ErrorMessage="*"
                                            ControlToValidate="TextBoxRaiseHR30OPT" ValidationGroup="IC"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Button ID="QueryRaiseHR30OPT" class="btn btn-primary icon-btn" runat="server" Text="Respond Query" ValidationGroup="IC"
                                                OnClick="QueryRaiseHR30OPT_Click" />
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
        <ASPP:PopupPanel HeaderText="Respond Query: How would you rate your overall quality of life during the past week?:" ID="RAISEHR30OPTMSG" runat="server" OnCloseWindowClick="MycloseWindow">
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindowRAISEHR30OPTMSG" runat="server">
                    <div align="center" style="width: 300px; height: 200px">
                        <br />
                        <asp:Panel ID="Panel31" runat="server" BorderStyle="Solid">
                            Query has been Responded of the How would you rate your overall quality of life during the past week? Field
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
